using System.IO;

namespace PathDefence.Screens
{
    internal class SelectLevelScreen : MenuScreen
    {
        public SelectLevelScreen() : base("Levelauswahl")
        {
            foreach (string s in Directory.GetFiles("Content/Map", "*.xml"))
            {
                var entry = new MenuEntry(Path.GetFileNameWithoutExtension(s));
                entry.Selected += entry_Selected;
                MenuEntries.Add(entry);
            }
            var exitEntry = new MenuEntry("Abbrechen");
            exitEntry.Selected += exitEntry_Selected;
            MenuEntries.Add(new MenuEntry(""));
            MenuEntries.Add(exitEntry);
        }

        private void exitEntry_Selected(object sender, PlayerIndexEventArgs e)
        {
            ExitScreen();
        }

        private void entry_Selected(object sender, PlayerIndexEventArgs e)
        {
            string Level = ((MenuEntry) sender).Text;
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex, new GamePlayScreen(Level,ScreenManager));
        }
    }
}