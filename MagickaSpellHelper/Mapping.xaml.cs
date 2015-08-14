using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MagickaSpellHelper {

    /// <summary>
    ///     Interaction logic for Mapping.xaml
    /// </summary>
    public partial class Mapping : UserControl {

        private MainWindow owner;

        public string Value {
            get { return txtBinding.Text; }
            set { txtBinding.Text = value; }
        }

        public Mapping() {
            InitializeComponent();
        }

        public void Bindwindow(MainWindow win) {
            owner = win;
        }

        public int GetMap(int i) {
            switch (i) {
                case 0:
                    return cb0.SelectedIndex;
                case 1:
                    return cb1.SelectedIndex;
                case 2:
                    return cb2.SelectedIndex;
                case 3:
                    return cb3.SelectedIndex;
                case 4:
                    return cb4.SelectedIndex;
                case 5:
                    return cb5.SelectedIndex;
                case 6:
                    return cb6.SelectedIndex;
                case 7:
                    return cb7.SelectedIndex;
                case 8:
                    return cb8.SelectedIndex;
                case 9:
                    return cb9.SelectedIndex;
                default:
                    return -1;
            }
        }

        public void SetMap(int i, int value) {
            switch (i) {
                case 0:
                    cb0.SelectedIndex = value;
                    break;
                case 1:
                    cb1.SelectedIndex = value;
                    break;
                case 2:
                    cb2.SelectedIndex = value;
                    break;
                case 3:
                    cb3.SelectedIndex = value;
                    break;
                case 4:
                    cb4.SelectedIndex = value;
                    break;
                case 5:
                    cb5.SelectedIndex = value;
                    break;
                case 6:
                    cb6.SelectedIndex = value;
                    break;
                case 7:
                    cb7.SelectedIndex = value;
                    break;
                case 8:
                    cb8.SelectedIndex = value;
                    break;
                case 9:
                    cb9.SelectedIndex = value;
                    break;
            }
        }

        public void Select() {
            txtBinding.Focus();
            txtBinding.SelectAll();
        }

        private void label1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            ((Parent) as StackPanel).Children.Remove(this);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
        }

        private void cb9_KeyDown(object sender, KeyEventArgs e) {
            var b = sender as ComboBox;
            switch (e.Key) {
                case Key.Delete:
                    b.SelectedIndex = -1;
                    break;
                case Key.Space:
                    b.SelectedIndex = 12;
                    break;
                default:
                    var k = owner.GenerateBaseKey();
                    for (int i = 0; i < k.Count(); i++) {
                        if (KeyInterop.VirtualKeyFromKey(e.Key) == (int) k[i]) {
                            (sender as ComboBox).SelectedIndex = i;
                            break;
                        }
                    }
                    break;
            }
        }
    }

}