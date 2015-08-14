using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using InputManager;
using Microsoft.Win32;
using MessageBox = System.Windows.MessageBox;
using Mouse = InputManager.Mouse;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace MagickaSpellHelper {

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private readonly string DefaultConfig;
        private readonly Dictionary<Keys, Bind> dictKey = new Dictionary<Keys, Bind>();
        private bool Disable = true;
        private string UpdateDownloadPath = @"http://dl.dropbox.com/u/632333/magickaspellhelper.html";
        private SpellHelper globalSpellHelper;

        public MainWindow() {
            InitializeComponent();
            KeyboardHook.KeyDown += KeyboardHook_KeyDown;
            KeyboardHook.InstallHook();

            DefaultConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Default.mmm");
            if (File.Exists(DefaultConfig)) {
                try {
                    LoadFile(DefaultConfig);
                    chkRemember.IsChecked = true;
                } catch (Exception) {
                }
            }
        }

        public static string GetDefaultBrowserPath() {
            string key = @"htmlfile\shell\open\command";
            RegistryKey registryKey =
                Registry.ClassesRoot.OpenSubKey(key, false);
            // get default browser path
            return ((string) registryKey.GetValue(null, null)).Split('"')[1];
        }

        [DllImport("user32.dll")]
        private static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(int hWnd, StringBuilder text, int count);

        public Keys[] GenerateBaseKey() {
            return new Keys[8] {
                ConvertTextToKey(textBox1.Text),
                ConvertTextToKey(textBox2.Text),
                ConvertTextToKey(textBox3.Text),
                ConvertTextToKey(textBox4.Text),
                ConvertTextToKey(textBox5.Text),
                ConvertTextToKey(textBox6.Text),
                ConvertTextToKey(textBox7.Text),
                ConvertTextToKey(textBox8.Text)
            };
        }

        private string GetActiveWindow() {
            const int nChars = 256;
            int handle = 0;
            var Buff = new StringBuilder(nChars);

            handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0) {
                return Buff.ToString();
            }
            return "";
        }

        private SpellHelper GenerateValue() {
            var sh = new SpellHelper();
            sh.BaseValue = GenerateBaseKey();
            foreach (Mapping m in pnMapper.Children) {
                var b = new Bind();
                b.BindedKey = ConvertTextToKey(m.Value);
                if (b.BindedKey == Keys.LControlKey) {
                    return null;
                }
                for (int i = 0; i < 10; i++) {
                    b.BindedValue[i] = m.GetMap(i);
                }
                sh.Binding.Add(b);
            }

            return sh;
        }

        private Keys ConvertTextToKey(string Text) {
            if (Text.Length == 1) {
                char c = Text.ToUpper()[0];
                if (('A' <= c) && (c <= 'Z')) {
                    return (Keys) c;
                }
                if (('0' <= c) && (c <= '9')) {
                    return (Keys) c;
                }
                return Keys.LControlKey;
            }
            return Keys.LControlKey;
        }

        private void KeyboardHook_KeyDown(int vkCode) {
            string Active = GetActiveWindow();
            if (vkCode == (int) Keys.Oemtilde) {
                cbTick.IsChecked = !cbTick.IsChecked;
            }
            if (Disable) {
                return;
            }
            if (!Active.Equals("Magicka")) {
                return;
            }
            bool Surprise = chkSurprised.IsChecked.Value;
            new Thread(
                delegate() {
                    var k = (Keys) (vkCode);
                    if (Surprise) {
                        if ((vkCode >= (int) Keys.D0) && ((int) Keys.D9 >= vkCode)) {
                            int NumOfSpell = new Random().Next(0, 5);
                            var l = new List<int>();
                            l.AddRange(new int[8] {0, 1, 2, 3, 4, 5, 6, 7});
                            for (int i = 0; i <= NumOfSpell; i++) {
                                int Spell = new Random().Next(0, l.Count);
                                VirtualKeyboard.KeyPress(globalSpellHelper.BaseValue[l[Spell]], Delay);
                                l.RemoveAt(Spell);
                            }
                        }
                    } else {
                        if (dictKey.ContainsKey(k)) {
                            VirtualKeyboard.KeyPress(Keys.OemMinus, KeyPress);
                            Thread.Sleep(KeyDelay0);
                            Bind b = dictKey[k];
                            var key = new List<Keys>();

                            var pressedKey = new Dictionary<int, int>();
                            int previousvalue = -1;
                            foreach (var i in b.BindedValue) {
                                if (i == 8) {
                                    Mouse.ButtonDown(Mouse.MouseKeys.Left);
                                    previousvalue = 8;
                                } else if (i == 9) {
                                    VirtualKeyboard.KeyPress(Keys.OemMinus, KeyPress/2);
                                    Thread.Sleep(KeyDelay0/2);
                                    Mouse.PressButton(Mouse.MouseKeys.Middle, Delay);
                                    previousvalue = 9;
                                } else if (i == 10) {
                                    if (previousvalue == 11) {
                                        Mouse.PressButton(Mouse.MouseKeys.Right, Delay);
                                        Thread.Sleep(Delay);
                                        VirtualKeyboard.KeyUp(Keys.LShiftKey);
                                    } else {
                                        Mouse.ButtonDown(Mouse.MouseKeys.Right);
                                    }
                                } else if (i == 11) {
                                    VirtualKeyboard.KeyDown(Keys.LShiftKey);
                                    previousvalue = 11;
                                } else if (i == 12) {
                                    VirtualKeyboard.KeyPress(Keys.OemMinus, KeyPress/2);
                                    Thread.Sleep(KeyDelay0/2);
                                    VirtualKeyboard.KeyPress(Keys.Space, Delay);
                                    Thread.Sleep(Delay);
                                    previousvalue = 12;
                                }
                                if ((i > -1) && (i < 8)) {
                                    int wait = KeyDelay1;

                                    if (pressedKey.ContainsKey(i)) {
                                        VirtualKeyboard.KeyPress(Keys.OemMinus, KeyPress);
                                        Thread.Sleep(KeyDelay0);
                                        if (previousvalue == i) {
                                            if (pressedKey[i] <= 3) {
                                                wait = KeyDelay2;
                                            }
                                            if (pressedKey[i] == 4) {
                                                wait = KeyDelay3;
                                            } else {
                                                wait = KeyDelay4;
                                            }
                                            pressedKey[i]++;
                                        }
                                    } else {
                                        VirtualKeyboard.KeyPress(Keys.OemMinus, KeyPress/2);
                                        Thread.Sleep(KeyDelay0/2);
                                        pressedKey.Add(i, 1);
                                    }
                                    VirtualKeyboard.KeyPress(globalSpellHelper.BaseValue[i], Delay);
                                    previousvalue = i;
                                    Thread.Sleep(wait);
                                }
                            }
                        }
                    }
                }).Start();
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            var m = new Mapping();
            pnMapper.Children.Add(m);
            m.Bindwindow(this);
            m.Focus();
            m.Select();
        }

        private void button3_Click(object sender, RoutedEventArgs e) {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Magicka macro mapper (*.mmm)|*.mmm";
            if (sfd.ShowDialog().Value) {
                try {
                    SpellHelper sh = GenerateValue();
                    sh.Save(sfd.FileName);

                    MessageBox.Show("File has been successfully saved", "Success",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                } catch (Exception) {
                    MessageBox.Show("File saving failed", "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }

        private void cbTick_Checked(object sender, RoutedEventArgs e) {
            pnMapper.IsEnabled = false;
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            chkSurprised.IsEnabled = false;
            button3.IsEnabled = false;
            globalSpellHelper = GenerateValue();
            dictKey.Clear();
            foreach (var b in globalSpellHelper.Binding) {
                if (!dictKey.ContainsKey(b.BindedKey)) {
                    dictKey.Add(b.BindedKey, b);
                }
            }
            Disable = false;
        }

        private void cbTick_Unchecked(object sender, RoutedEventArgs e) {
            Disable = true;
            if (!chkSurprised.IsChecked.Value) {
                pnMapper.IsEnabled = true;
                button1.IsEnabled = true;
                button2.IsEnabled = true;
                button3.IsEnabled = true;
            }
            chkSurprised.IsEnabled = true;
        }

        private void LoadFile(string filename) {
            SpellHelper sh = SpellHelper.Load(filename);
            pnMapper.Children.Clear();
            textBox1.Text = string.Concat((char) sh.BaseValue[0]);
            textBox2.Text = string.Concat((char) sh.BaseValue[1]);
            textBox3.Text = string.Concat((char) sh.BaseValue[2]);
            textBox4.Text = string.Concat((char) sh.BaseValue[3]);
            textBox5.Text = string.Concat((char) sh.BaseValue[4]);
            textBox6.Text = string.Concat((char) sh.BaseValue[5]);
            textBox7.Text = string.Concat((char) sh.BaseValue[6]);
            textBox8.Text = string.Concat((char) sh.BaseValue[7]);
            foreach (var b in sh.Binding) {
                var m = new Mapping();
                m.Value = string.Concat((char) b.BindedKey);
                for (int i = 0; i < 10; i++) {
                    m.SetMap(i, b.BindedValue[i]);
                }
                pnMapper.Children.Add(m);
                m.Bindwindow(this);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e) {
            var sfd = new OpenFileDialog();
            sfd.Filter = "Magicka macro mapper (*.mmm)|*.mmm";
            if (sfd.ShowDialog().Value) {
                try {
                    LoadFile(sfd.FileName);
                } catch (Exception) {
                    MessageBox.Show("File loading failed", "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }

        private void chkSurprised_Checked(object sender, RoutedEventArgs e) {
            pnMapper.IsEnabled = false;
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
        }

        private void chkSurprised_Unchecked(object sender, RoutedEventArgs e) {
            pnMapper.IsEnabled = true;
            button1.IsEnabled = true;
            button2.IsEnabled = true;
            button3.IsEnabled = true;
        }

        private void button4_Click(object sender, RoutedEventArgs e) {
            if (MessageBox.Show("Do you want to clear the spell list?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                pnMapper.Children.Clear();
            }
        }

        private void btnDonate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            try {
                string Path = GetDefaultBrowserPath();
                Process.Start(Path, UpdateDownloadPath);
            } catch (Exception) {
                MessageBox.Show("Cannot open browser on your computer.\nMay you please manually donate via Paypal to nkahoang@gmail.com\nThank you for your support", "Donation", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void radioButton3_Checked(object sender, RoutedEventArgs e) {
            if (radioButton1.IsChecked.Value) {
                Delay = 60;
                KeyPress = 60;
                KeyDelay0 = 65;
                KeyDelay1 = 65;
                KeyDelay2 = 70;
                KeyDelay3 = 75;
                KeyDelay4 = 80;
            } else if (radioButton2.IsChecked.Value) {
                Delay = 75;
                KeyPress = 75;
                KeyDelay0 = 85;
                KeyDelay1 = 95;
                KeyDelay2 = 95;
                KeyDelay3 = 100;
                KeyDelay4 = 105;
            } else {
                Delay = 150;
                KeyPress = 120;
                KeyDelay0 = 120;
                KeyDelay1 = 130;
                KeyDelay2 = 150;
                KeyDelay3 = 170;
                KeyDelay4 = 230;
            }
        }

        private void btnLaunchGame_Click(object sender, RoutedEventArgs e) {
            try {
                string SteamPath = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam").GetValue("SteamPath") + "";
                if (SteamPath != null) {
                    string MagickaPath = Path.Combine(SteamPath, @"steamapps\common\magicka\magicka.exe");
                    if (File.Exists(MagickaPath)) {
                        var p = new Process();
                        p.StartInfo.FileName = MagickaPath;
                        p.StartInfo.UseShellExecute = true;
                        p.Start();
                        return;
                    }
                }
            } catch (Exception) {

            }
            MessageBox.Show("Cannot find Magicka executable path. Please run the game manually", "Cannot find the game", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Window_Closing(object sender, CancelEventArgs e) {
            if (chkRemember.IsChecked.Value) {
                try {
                    SpellHelper sh = GenerateValue();
                    sh.Save(DefaultConfig);
                } catch (Exception) {
                }
            } else {
                if (File.Exists(DefaultConfig)) {
                    File.Delete(DefaultConfig);
                }
            }
        }

        #region profileUltraFast
        /*
            int Delay = 60;
            int KeyPress = 60;
            int KeyDelay0 = 65;
            int KeyDelay1 = 65;
            int KeyDelay2 = 70;
            int KeyDelay3 = 75;
            int KeyDelay4 = 80;
            */
        #endregion

        #region profileFast
        private int Delay = 75;
        private int KeyDelay0 = 85;
        private int KeyDelay1 = 95;
        private int KeyDelay2 = 95;
        private int KeyDelay3 = 100;
        private int KeyDelay4 = 105;
        private int KeyPress = 75;
        #endregion

        #region profile2
        /*
            int Delay = 70;
            int KeyPress = 70;
            int KeyDelay0 = 80;
            int KeyDelay1 = 80;
            int KeyDelay2 = 90;
            int KeyDelay3 = 100;
            int KeyDelay4 = 150;*/
        #endregion
    }

}