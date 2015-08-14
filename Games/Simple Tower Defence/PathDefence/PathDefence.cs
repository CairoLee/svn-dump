using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PathDefence.Properties;
using PathDefence.ScreenManagement;
using PathDefence.Screens;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace PathDefence
{
    public class PathDefenceGame : Game
    {
        private const int HeightCreepField = WidthCreepField;
        private const int WidthCreepField = 600;
        private const int WidthMenuField = 400;

        private ScreenManager _screenManager;

        private bool TaskDialogAnswer;

        public PathDefenceGame()
        {
            if (Settings.Default.FirstStartup)
            {
                Settings.Default.FirstStartup = false;

                //Settings.Default.CheckForUpdatesOnStartup = UpdateSearcher.AskForAutoUpdates();

                //Settings.Default.UploadLogOnClose = LogFramework.AskForUploadLogOnClose();

                Settings.Default.Save();
            }
            if (Settings.Default.CheckForUpdatesOnStartup)
            {
                //UpdateSearcher.Search(Settings.Default.Version, Settings.Default.SearchForTestversion);
            }

            Graphics = new GraphicsDeviceManager(this)
                           {
                               PreferredBackBufferHeight = HeightCreepField,
                               PreferredBackBufferWidth = WidthCreepField + WidthMenuField
                           };
            IsMouseVisible = false;
            Graphics.PreparingDeviceSettings += Graphics_PreparingDeviceSettings;
            ApplicationDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Content.RootDirectory = ApplicationDirectory + "\\Content";
            //Graphics.IsFullScreen = true;
        }

        void noBtn_Click(object sender, System.EventArgs e)
        {
            TaskDialogAnswer = false;
            ((TaskDialog)((TaskDialogCommandLink)sender).HostingDialog).Close();
        }

        void yesBtn_Click(object sender, System.EventArgs e)
        {
            TaskDialogAnswer = true;
            ((TaskDialog)((TaskDialogCommandLink)sender).HostingDialog).Close();
        }

        public string ApplicationDirectory { get; set; }

        public GraphicsDeviceManager Graphics { get; private set; }

        public SpriteBatch SpriteBatch { get; private set; }

        public int Width
        {
            get { return Graphics.PreferredBackBufferWidth; }
        }

        public int Height
        {
            get { return Graphics.PreferredBackBufferHeight; }
        }

        public int CreepFieldWidth
        {
            get { return Graphics.PreferredBackBufferWidth - WidthMenuField; }
        }

        public int CreepFieldHeight
        {
            get { return Graphics.PreferredBackBufferHeight; }
        }

        private static void Graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            e.GraphicsDeviceInformation.PresentationParameters.RenderTargetUsage = RenderTargetUsage.PreserveContents;
        }

        protected override void Initialize()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);


            // Create the screen manager component.
            _screenManager = new ScreenManager(this);

            Components.Add(_screenManager);

            // Activate the first screens.
            _screenManager.AddScreen(new BackgroundScreen(), null);
            _screenManager.AddScreen(new MainMenuScreen(), null);

            base.Initialize();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
        }
    }
}