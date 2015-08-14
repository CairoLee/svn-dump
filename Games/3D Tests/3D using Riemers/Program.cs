using System;

namespace Engine3DFromRiemersTutorial {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main( string[] args ) {
			using( var game = new Engine3DTest() ) {
				game.Run();
			}
		}
	}
}

