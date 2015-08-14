using System;
namespace LevelEditor
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            using (var game = new Leveleditor())
            {
                game.Run();
            }
        }
    }
}