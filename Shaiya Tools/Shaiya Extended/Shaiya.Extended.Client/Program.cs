using System;

namespace Shaiya.Extended.Client {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main( string[] args ) {
			using( GameClient game = new GameClient() ) {
				game.Run();
			}
		}
	}
}

