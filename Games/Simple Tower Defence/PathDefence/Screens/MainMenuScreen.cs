using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;

namespace PathDefence.Screens
{
    /// <summary>
    /// The main menu screen is the first thing displayed when the game starts up.
    /// </summary>
    internal class MainMenuScreen : MenuScreen
    {
        #region Initialization

        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public MainMenuScreen() : base("Hauptmenu")
        {
            // Create our menu entries.
            var playGameMenuEntry = new MenuEntry("Spiel starten");
            var optionsMenuEntry = new MenuEntry("Options");
            var exitMenuEntry = new MenuEntry("Beenden");
            var levelEditorMenuEntry = new MenuEntry("Leveleditor");
            var towerEditorMenuEntry = new MenuEntry("Turmeditor");

            // Hook up menu event handlers.
            playGameMenuEntry.Selected += PlayGameMenuEntrySelected;
            optionsMenuEntry.Selected += OptionsMenuEntrySelected;
            exitMenuEntry.Selected += OnCancel;
            levelEditorMenuEntry.Selected += levelEditorMenuEntrySelected;
            towerEditorMenuEntry.Selected += towerEditorMenuEntry_Selected;

            // Add entries to the menu.
            MenuEntries.Add(playGameMenuEntry);
            //MenuEntries.Add(optionsMenuEntry);
            MenuEntries.Add(levelEditorMenuEntry);
            MenuEntries.Add(towerEditorMenuEntry);
            MenuEntries.Add(exitMenuEntry);
        }

        private static void towerEditorMenuEntry_Selected(object sender, PlayerIndexEventArgs e)
        {
            Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                          "\\Towereditor\\Towereditor.exe");
        }

        #endregion

        #region Handle Input

        /// <summary>
        /// Event handler for when the Play Game menu entry is selected.
        /// </summary>
        private void PlayGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new SelectLevelScreen(), e.PlayerIndex);
        }

        /// <summary>
        /// Event handler for when the Options menu entry is selected.
        /// </summary>
        private void OptionsMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            //ScreenManager.AddScreen(new OptionsMenuScreen(), e.PlayerIndex);
        }

        /// <summary>
        /// When the user cancels the main menu, ask if they want to exit the sample.
        /// </summary>
        protected override void OnCancel(PlayerIndex playerIndex)
        {
            const string message = "Wollen Sie dieses Spiel wirklich beenden?";

            var confirmExitMessageBox = new MessageBoxScreen(message);

            confirmExitMessageBox.Accepted += ConfirmExitMessageBoxAccepted;

            ScreenManager.AddScreen(confirmExitMessageBox, playerIndex);
        }

        private void levelEditorMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                          "\\Leveleditor\\Leveleditor.exe");
        }

        /// <summary>
        /// Event handler for when the user selects ok on the "are you sure
        /// you want to exit" message box.
        /// </summary>
        private void ConfirmExitMessageBoxAccepted(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.Game.Exit();
        }

        #endregion
    }
}