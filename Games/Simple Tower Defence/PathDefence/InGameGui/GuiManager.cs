using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PathDefence.GamePlay;
using PathDefence.Screens;
using TomShane.Neoforce.Controls;
using TowerInterface;
using Console = TomShane.Neoforce.Controls.Console;
using EventArgs = TomShane.Neoforce.Controls.EventArgs;

namespace PathDefence.InGameGui
{
    public partial class GuiManager : DrawableGameComponent
    {
        private readonly PathDefenceGame CurrGame;
        private readonly GamePlayScreen GamePlayScreen;
        private Vector2 BackgroundPosition;
        private Vector2 BackgroundScale;
        private Vector2 BackgroundSize;
        private Texture2D BackgroundTexture;
        private List<Button> BuyTowerButtons;
        private Console Console;
        private Label CreepHealth;
        private Label CreepNumber;
        private TabPage GameplayPage;
        private ITower LastSelectedTower;
        private Manager manager;
        private Label Money;
        private Label Points;
        private Label CreepHealthLevel;
        private KeyboardState oldState;
        private TabPage OptionsPage;
        private Label OwnHealth;
        private Label RealWaveNumber;
        private Label TimeLeftNextWave;
        private Label CreepsLeft;
        private Vector2 SelectorPosition;
        private Vector2 SelectorScale;
        private Texture2D SelectorTexture;
        private SpriteBatch SpriteBatch;
        private TabControl tabControl;

        private TowerBaseInfoWindow TowerBaseWindow;
        private TowerInfoWindow TowerWindow;
        private Label WaveNumber;

        public GuiManager(Game game, GamePlayScreen screen)
            : base(game)
        {
            CurrGame = (PathDefenceGame)game;
            GamePlayScreen = screen;
        }

        public override void Initialize()
        {
            SpriteBatch = CurrGame.SpriteBatch;
            BackgroundTexture = CurrGame.Content.Load<Texture2D>("GUI/backgroundInGameMenu");
            BackgroundPosition = new Vector2(CurrGame.CreepFieldWidth, 0);
            BackgroundSize = new Vector2(CurrGame.Width - CurrGame.CreepFieldWidth, CurrGame.Height);
            BackgroundScale = new Vector2(BackgroundSize.X / BackgroundTexture.Width,
                                          BackgroundSize.Y / BackgroundTexture.Height);

            BuyTowerButtons = new List<Button>();
            InitializeControls();
            GamePlayScreen.InformationChanged += GamePlayScreen_InformationChanged;
            GamePlayScreen.MoneyManager.MoneyChanged += MoneyManager_MoneyChanged;

            base.Initialize();
        }

        private void MoneyManager_MoneyChanged(double obj)
        {
            foreach (Button buyTowerButton in BuyTowerButtons)
            {
                var towerClass = (TowerClass)buyTowerButton.Tag;
                buyTowerButton.Enabled = GamePlayScreen.MoneyManager.CanBuy(towerClass.GetPrice());
            }
        }

        protected override void LoadContent()
        {
            SelectorTexture = CurrGame.Content.Load<Texture2D>("GUI/towerSelector");
            base.LoadContent();
        }

        private void GamePlayScreen_InformationChanged()
        {
            RefreshGameInformation();
        }

        public void UpdateTowerWindow()
        {
            TowerWindow.UpdateTowerInformation();
        }

        private void RefreshGameInformation()
        {
            CreepNumber.Text = "Anzahl Creeps: " + GamePlayScreen.NumberOfCreeps;
            CreepHealth.Text = "Energie aller Creeps: " + GamePlayScreen.CreepHealth;
            WaveNumber.Text = "Wave-Nummer: " + GamePlayScreen.WaveManager.Wave;
            RealWaveNumber.Text = "Wave: " + GamePlayScreen.WaveManager.RealWave;
            CreepsLeft.Text = "Ausstehende Creeps: " + GamePlayScreen.CreepsLeft;
            CreepHealthLevel.Text = "Gesundheitsniveau: " + GamePlayScreen.WaveManager.HealthNiveau;
            OwnHealth.Text = "Eigene Energie: " + GamePlayScreen.LiveManager.Health;
            Money.Text = "Geld: " + GamePlayScreen.MoneyManager.Money;
            TimeLeftNextWave.Text = "Verbleibende Zeit bis zur nächsten Welle: " +
                                    (int)(GamePlayScreen.WaveManager.TimeLeftNextWave / 1000d);
            Points.Text = "Punkte: " + GamePlayScreen.PointsManager.Points;
            DebugLog("GameInformationUpdate");
        }

        private void InitializeControls()
        {
            manager = new Manager(CurrGame, CurrGame.Graphics, "Green") { SkinDirectory = CurrGame.ApplicationDirectory + @"\Content\GUI\Skin\" };
            try
            {
                manager.Initialize();
            }
            catch (Exception)
            {
                throw;
            }

            manager.AutoCreateRenderTarget = true;

            Console = new Console(manager);
            Console.Init();
            LoadConsoleCommands();
            manager.Add(Console);
            Console.ChannelsVisible = false;
            Console.MessageSent += Console_MessageSent;
            Console.MessageFormat = ConsoleMessageFormats.None;
            Console.Width = manager.ScreenWidth;
            Console.Channels.Add(new ConsoleChannel(0, "[System]", Color.Orange));
            Console.Channels.Add(new ConsoleChannel(1, "[User]", Color.White));
            Console.Channels.Add(new ConsoleChannel(2, "[Error]", Color.DarkRed));
            Console.SelectedChannel = 1;
            Console.Hide();

            tabControl = new TabControl(manager);
            tabControl.Init();
            tabControl.Left = CurrGame.CreepFieldWidth;
            tabControl.Top = 0;
            tabControl.Width = CurrGame.Width - CurrGame.CreepFieldWidth;
            tabControl.Height = CurrGame.Height;

            #region Gameplaypage

            GameplayPage = tabControl.AddPage();
            GameplayPage.Init();
            GameplayPage.Text = "Spiel";

            #region Turmauswahl

            var thumbnailBox = new GroupBox(manager);
            thumbnailBox.Init();
            thumbnailBox.Parent = GameplayPage;
            thumbnailBox.Left = 2;
            thumbnailBox.Top = 2;
            thumbnailBox.Width = thumbnailBox.Parent.Width - 4;
            thumbnailBox.Height = 100;

            int counter = 0;
            foreach (TowerClass towerClass in GamePlayScreen.TowerManager.TowerClassList)
            {
                var towerButton = new ImageButton(manager)
                                      {
                                          Image = GamePlayScreen.TowerManager.GetThumbnail(towerClass.TowerKey),
                                          SizeMode = SizeMode.Stretched,
                                          Top = 14,
                                          Tag = towerClass
                                      };
                towerButton.Width = towerButton.Height = 60;
                towerButton.Left = 6 + counter * (towerButton.Width + 5);
                towerButton.Click += towerButton_Click;
                towerButton.MouseOver += towerButton_MouseOver;
                towerButton.MouseOut += towerButton_MouseOut;
                towerButton.Init();
                thumbnailBox.Add(towerButton);
                BuyTowerButtons.Add(towerButton);
                counter++;
            }

            thumbnailBox.AutoScroll = true;

            var scrollBar = new ScrollBar(manager, Orientation.Horizontal);
            scrollBar.Init();
            thumbnailBox.Add(scrollBar);
            scrollBar.Visible = false;

            #endregion

            #region Informationen

            var infoBox = new GroupBox(manager);
            infoBox.Init();
            infoBox.Parent = GameplayPage;
            infoBox.Text = "Informationen";
            infoBox.Width = infoBox.Parent.Width - 4;
            infoBox.Height = 110;
            infoBox.Left = 2;
            infoBox.Top = thumbnailBox.Top + thumbnailBox.Height + 2;

            CreepNumber = new Label(manager);
            CreepNumber.Init();
            CreepNumber.Parent = infoBox;
            CreepNumber.Top = 14;
            CreepNumber.Left = 4;
            CreepNumber.Width = CreepNumber.Parent.Width - 4;
            CreepNumber.ToolTip = new ToolTip(manager) { Text = "So viele Creeps sind momentan\nauf dem Spielfeld" };
            CreepNumber.Passive = false;

            CreepHealth = new Label(manager);
            CreepHealth.Init();
            CreepHealth.Parent = infoBox;
            CreepHealth.Top = CreepNumber.Top + CreepNumber.Height + 2;
            CreepHealth.Left = CreepNumber.Left;
            CreepHealth.Width = CreepHealth.Parent.Width - 4;
            CreepHealth.ToolTip = new ToolTip(manager) { Text = "Die Gesamtenergie aller auf dem\nSpielfeld befindlicher Creeps" };
            CreepHealth.Passive = false;

            Money = new Label(manager);
            Money.Init();
            Money.Parent = infoBox;
            Money.Top = CreepHealth.Top + CreepHealth.Height + 2;
            Money.Left = CreepNumber.Left;
            Money.Width = Money.Parent.Width - 4;
            Money.ToolTip = new ToolTip(manager) { Text = "So viel Geld besitzt der Spieler" };
            Money.Passive = false;

            OwnHealth = new Label(manager);
            OwnHealth.Init();
            OwnHealth.Parent = infoBox;
            OwnHealth.Top = Money.Top + Money.Height + 2;
            OwnHealth.Left = CreepNumber.Left;
            OwnHealth.Width = OwnHealth.Parent.Width - 4;
            OwnHealth.ToolTip = new ToolTip(manager) { Text = "So viel Energie hat der Spieler noch" };
            OwnHealth.Passive = false;

            Points = new Label(manager);
            Points.Init();
            Points.Parent = infoBox;
            Points.Top = OwnHealth.Top + OwnHealth.Height + 2;
            Points.Left = CreepNumber.Left;
            Points.Width = Points.Parent.Width - 4;
            Points.ToolTip = new ToolTip(manager) { Text = "So viele Punkte hat der Spieler schon.\nDie Punkte setzen sich aus Energie\nund Geschwindigkeit der Creeps zusammen.\nJe näher ein Gegner am Ziel ist, desto mehr\nPunkte gibt er." };
            Points.Passive = false;

            #endregion

            #region Waves

            var waveBox = new GroupBox(manager);
            waveBox.Init();
            waveBox.Parent = GameplayPage;
            waveBox.Text = "Waves";
            waveBox.Left = 2;
            waveBox.Top = infoBox.Top + infoBox.Height + 2;
            waveBox.Width = waveBox.Parent.Width - 4;
            waveBox.Height = 137;

            WaveNumber = new Label(manager);
            WaveNumber.Init();
            WaveNumber.Parent = waveBox;
            WaveNumber.Top = 14;
            WaveNumber.Left = 4;
            WaveNumber.Width = WaveNumber.Parent.Width - 4;

            RealWaveNumber = new Label(manager);
            RealWaveNumber.Init();
            RealWaveNumber.Parent = waveBox;
            RealWaveNumber.Top = WaveNumber.Top + WaveNumber.Height + 2;
            RealWaveNumber.Left = WaveNumber.Left;
            RealWaveNumber.Width = RealWaveNumber.Parent.Width - 4;

            CreepsLeft = new Label(manager);
            CreepsLeft.Init();
            CreepsLeft.Parent = waveBox;
            CreepsLeft.Top = RealWaveNumber.Top + RealWaveNumber.Height + 2;
            CreepsLeft.Left = WaveNumber.Left;
            CreepsLeft.Width = CreepsLeft.Parent.Width - 4;
            CreepsLeft.Passive = false;
            CreepsLeft.ToolTip = new ToolTip(manager) { Text = "So viele Creeps werden noch im Level erscheinen,\nbevor die Aktuelle Welle vorbei ist." };

            CreepHealthLevel = new Label(manager);
            CreepHealthLevel.Init();
            CreepHealthLevel.Parent = waveBox;
            CreepHealthLevel.Top = CreepsLeft.Top + CreepsLeft.Height + 2;
            CreepHealthLevel.Left = WaveNumber.Left;
            CreepHealthLevel.Width = CreepHealthLevel.Parent.Width - 4;
            CreepHealthLevel.Passive = false;
            CreepHealthLevel.ToolTip = new ToolTip(manager) { Text = "Wenn alle Waves eines Levels fertig sind, werden die Waves von Anfang anwiederholt.\nAllerdings steigt die Energie der Creeps dabei.\nDas Gesundheitsniveau liegt dieser Energie zugrunde." };

            TimeLeftNextWave = new Label(manager);
            TimeLeftNextWave.Init();
            TimeLeftNextWave.Parent = waveBox;
            TimeLeftNextWave.Top = CreepHealthLevel.Top + CreepHealthLevel.Height + 2;
            TimeLeftNextWave.Left = WaveNumber.Left;
            TimeLeftNextWave.Width = TimeLeftNextWave.Parent.Width - 4;

            var nextWaveButton = new Button(manager);
            nextWaveButton.Init();
            nextWaveButton.Parent = waveBox;
            nextWaveButton.Text = "Nächste Welle";
            nextWaveButton.Left = 2;
            nextWaveButton.Top = TimeLeftNextWave.Top + TimeLeftNextWave.Height + 2;
            nextWaveButton.Width = nextWaveButton.Parent.Width - 4;
            nextWaveButton.Click += delegate { GamePlayScreen.StartNextWave(); };

            #endregion

            #region Spielsteuerung

            var gameBox = new GroupBox(manager);
            gameBox.Init();
            gameBox.Text = "Spielsteuerung";
            gameBox.Parent = GameplayPage;
            gameBox.Width = gameBox.Parent.Width - 4;
            gameBox.Height = 200;
            gameBox.Left = 2;
            gameBox.Top = waveBox.Top + waveBox.Height + 2;

            var playButton = new ImageButton(manager)
                                 {
                                     Image =
                                         CurrGame.Content.Load<Texture2D>(CurrGame.ApplicationDirectory + "\\Content\\GUI\\play"),
                                     SizeMode = SizeMode.Stretched,
                                     Top = 14,
                                     Left = 2,
                                     Width = 50
                                 };
            playButton.Height = playButton.Width;
            playButton.Click += ((sender, e) => GamePlayScreen.StartGame());
            playButton.Init();

            var pauseButton = new ImageButton(manager)
                                  {
                                      Image =
                                          CurrGame.Content.Load<Texture2D>(CurrGame.ApplicationDirectory +
                                                                           "\\Content\\GUI\\pause"),
                                      SizeMode = SizeMode.Stretched,
                                      Top = 14,
                                      Left = playButton.Left + playButton.Width + 4
                                  };
            pauseButton.Width = pauseButton.Height = playButton.Width;
            pauseButton.Click += ((sender, e) => GamePlayScreen.StopGame());
            pauseButton.Init();

            gameBox.Add(playButton);
            gameBox.Add(pauseButton);

            #endregion

            RefreshGameInformation();

            #endregion

            #region Optionspage

            OptionsPage = tabControl.AddPage();
            OptionsPage.Text = "Optionen";

            #endregion

            #region SaveLoadPage

            #endregion

            manager.Add(tabControl);
        }

        private void towerButton_Click(object sender, EventArgs e)
        {
            string name = ((TowerClass)((Button)sender).Tag).TowerKey;
            GamePlayScreen.TowerManager.StartTowerBuildMode(name);
            if (TowerBaseWindow != null)
                TowerBaseWindow.Close();
        }

        private void towerButton_MouseOut(object sender, MouseEventArgs e)
        {
            if (TowerBaseWindow != null)
                TowerBaseWindow.Close();
        }

        private void towerButton_MouseOver(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                var tower = ((TowerClass)((Button)sender).Tag);
                var pos =
                    new Vector2(
                        ((Button)sender).AbsoluteLeft - TowerBaseInfoWindow.DesiredWidth + ((Button)sender).Width / 2,
                        ((Button)sender).AbsoluteTop + ((Button)sender).Height / 2);
                ShowTowerBaseInfo(tower.TowerName, tower.TowerKey, pos);
            }
        }

        private void ShowTowerBaseInfo(string name, string key, Vector2 pos)
        {
            if (TowerBaseWindow != null)
            {
                TowerBaseWindow.Close();
                TowerBaseWindow = null;
            }
            TowerBaseWindow = new TowerBaseInfoWindow(manager) { Left = (int)pos.X, Top = (int)pos.Y, TowerName = name };
            int damage;
            TowerBaseWindow.Damage = int.TryParse(TowerManager.GetTowerProperty(key, "Damage"), out damage) ? damage : 0;
            int speed;
            TowerBaseWindow.Interval = int.TryParse(TowerManager.GetTowerProperty(key, "Interval"), out speed)
                                           ? speed
                                           : 0;
            int range;
            TowerBaseWindow.Range = int.TryParse(TowerManager.GetTowerProperty(key, "Range"), out range) ? range : 0;
            int price;
            TowerBaseWindow.Price = int.TryParse(TowerManager.GetTowerProperty(key, "Price"), out price) ? price : 0;
            TowerBaseWindow.Description = TowerManager.GetTowerProperty(key, "Description");

            bool showDamage = bool.Parse(TowerManager.GetTowerProperty("Labels", key, "ShowDamage"));
            bool showRange = bool.Parse(TowerManager.GetTowerProperty("Labels", key, "ShowRange"));
            bool showInterval = bool.Parse(TowerManager.GetTowerProperty("Labels", key, "ShowInterval"));

            DebugLog("ShowTowerBaseInfo: " + key);

            TowerBaseWindow.Init(showDamage, showRange, showInterval);
            TowerBaseWindow.Show();
            TowerBaseWindow.BringToFront();
        }

        private void ShowTowerInfo(ITower tower)
        {
            if (TowerWindow != null)
            {
                TowerWindow.Close();
                manager.Remove(TowerWindow);
                TowerWindow = null;
            }
            TowerWindow = new TowerInfoWindow(manager, CurrGame, GamePlayScreen);
            TowerWindow.Closed += delegate { TowerWindow = null; };
            TowerWindow.Tower = tower;
            TowerWindow.DesiredLeft = (int)(tower.Position.X + tower.Size.X / 2);
            TowerWindow.DesiredTop = (int)(tower.Position.Y + tower.Size.Y / 2);
            bool showDamage = bool.Parse(TowerManager.GetTowerProperty("Labels", tower.Key, "ShowDamage"));
            bool showRange = bool.Parse(TowerManager.GetTowerProperty("Labels", tower.Key, "ShowRange"));
            bool showInterval = bool.Parse(TowerManager.GetTowerProperty("Labels", tower.Key, "ShowInterval"));

            DebugLog("ShowTowerInfo: " + tower.Key);

            TowerWindow.Init(showDamage, showRange, showInterval);
            TowerWindow.Show();
            TowerWindow.BringToFront();
        }

        public void ShowGameOverWindow()
        {
            GamePlayScreen.StopGame();
            var gameOverWindow = new GameOverWindow(manager, GamePlayScreen);
            gameOverWindow.Init();
            gameOverWindow.ShowModal();
        }

        public bool IsClickOnTowerWindow(Vector2 pos)
        {
            if (TowerWindow == null)
            {
                return false;
            }
            return TowerWindow.ControlRect.Intersects(new Rectangle((int)pos.X, (int)pos.Y, 0, 0));
        }

        public override void Draw(GameTime gameTime)
        {
            

            
            manager.BeginDraw(gameTime);
            base.Draw(gameTime);
            SpriteBatch.Begin();
            {
                SpriteBatch.Draw(BackgroundTexture, BackgroundPosition, null, Color.White, 0, Vector2.Zero,
                                 BackgroundScale, SpriteEffects.None, 0);
                SpriteBatch.Draw(SelectorTexture, SelectorPosition, null, Color.White, 0, Vector2.Zero, SelectorScale,
                                 SpriteEffects.None, 0);
            }
            SpriteBatch.End();
            manager.EndDraw();
        }

        public override void Update(GameTime gameTime)
        {
            manager.Update(gameTime);
            if (GamePlayScreen.TowerManager.SelectedTower != null)
            {
                if (GamePlayScreen.TowerManager.SelectedTower != LastSelectedTower)
                {
                    LastSelectedTower = GamePlayScreen.TowerManager.SelectedTower;
                    SelectorPosition = LastSelectedTower.Position;
                    SelectorScale = new Vector2(LastSelectedTower.Size.X / SelectorTexture.Width,
                                                LastSelectedTower.Size.Y / SelectorTexture.Height);
                    ShowTowerInfo(LastSelectedTower);
                }
            }
            else
            {
                SelectorScale = Vector2.Zero;
                LastSelectedTower = null;
                if (TowerWindow != null)
                {
                    TowerWindow.Close();
                }
            }

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Tab) && !oldState.IsKeyDown(Keys.Tab))
            {
                if (Console.Visible)
                    Console.Hide();
                else
                {
                    Console.Show();
                    Console.BringToFront();
                    foreach (Control control in Console.Controls)
                    {
                        if (control is TextBox)
                            control.Focused = true;
                    }
                }
            }
            oldState = state;

            base.Update(gameTime);
        }
    }
}