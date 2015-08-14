using PathDefence.Screens;
using TomShane.Neoforce.Controls;
using EventArgs=TomShane.Neoforce.Controls.EventArgs;
using Microsoft.Xna.Framework;

namespace PathDefence.InGameGui
{
    class GameOverWindow : Window
    {
        private Label LostMessage;
        private Label Points;
        private Button RestartGame;
        private Button GoMainMenu;
        private Button ExitGame;
        private GamePlayScreen GamePlayScreen;

        public GameOverWindow(Manager manager, GamePlayScreen screen)
            : base(manager)
        {
            GamePlayScreen = screen;
            LostMessage = new RappingLabel(manager);
            Points = new Label(manager);
            RestartGame = new Button(manager);
            GoMainMenu = new Button(manager);
            ExitGame = new Button(manager);
            manager.Add(this);
        }

        public override void Init()
        {
            base.Init();
            Height = 200;
            Width = 200;
            Text = "Game Over!";
            Center();
            Resizable = false;
            CloseButtonVisible = false;

            LostMessage.Init();
            LostMessage.Parent = this;
            LostMessage.Alignment = Alignment.TopLeft;
            LostMessage.Width = LostMessage.Parent.Width - 5;
            LostMessage.Height = 30;
            LostMessage.Text = "Sie haben keine Energie mehr,\ndas Spiel ist verloren.";
            LostMessage.Alignment = Alignment.TopLeft;
            LostMessage.Top = 5;
            LostMessage.Left = 5;
            LostMessage.TextColor = Color.LightGray;
            

            Points.Init();
            Points.Parent = this;
            Points.Text = string.Format("Erreichte Punkte: {0}", GamePlayScreen.PointsManager.Points);
            Points.Top = LostMessage.Top + LostMessage.Height + 2;
            Points.Left = 5;
            Points.Width = Points.Parent.Width - 5;

            RestartGame.Init();
            RestartGame.Parent = this;
            RestartGame.Text = "Level neustarten";
            RestartGame.Top = Points.Top + Points.Height + 20;
            RestartGame.Left = 5;
            RestartGame.Width = RestartGame.Parent.Width - 10;
            RestartGame.Click += RestartGame_Click;

            GoMainMenu.Init();
            GoMainMenu.Parent = this;
            GoMainMenu.Text = "Zum Hauptmenü";
            GoMainMenu.Top = RestartGame.Top + RestartGame.Height + 5;
            GoMainMenu.Left = 5;
            GoMainMenu.Width = GoMainMenu.Parent.Width - 10;
            GoMainMenu.Click += GoMainMenu_Click;

            ExitGame.Init();
            ExitGame.Parent = this;
            ExitGame.Text = "Spiel beenden";
            ExitGame.Top = GoMainMenu.Top + GoMainMenu.Height + 5;
            ExitGame.Left = 5;
            ExitGame.Width = ExitGame.Parent.Width - 10;
            ExitGame.Click += ExitGame_Click;
        }

        private void ExitGame_Click(object sender, EventArgs e)
        {
            GamePlayScreen.CurrGame.Exit();
        }

        private void GoMainMenu_Click(object sender, EventArgs e)
        {
            foreach (var screen in GamePlayScreen.ScreenManager.GetScreens())
            {
                GamePlayScreen.ScreenManager.RemoveScreen(screen);
            }
            GamePlayScreen.ScreenManager.AddScreen(new BackgroundScreen(), null);
            GamePlayScreen.ScreenManager.AddScreen(new MainMenuScreen(),null);
        }

        void RestartGame_Click(object sender, EventArgs e)
        {
            GamePlayScreen.RestartLevel();
        }
    }
}
