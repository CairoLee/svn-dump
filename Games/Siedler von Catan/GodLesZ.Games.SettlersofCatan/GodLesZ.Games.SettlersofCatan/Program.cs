using System;

namespace GodLesZ.Games.SettlersofCatan {
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (GameSettlers game = new GameSettlers())
            {
                game.Run();
            }
        }
    }
#endif
}

