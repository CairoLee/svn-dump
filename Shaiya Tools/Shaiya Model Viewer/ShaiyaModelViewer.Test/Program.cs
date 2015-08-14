using System;

namespace Shaiya_Model_Viewer.Test {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main( string[] args ) {
			using( Viewer game = new Viewer() ) {
				game.Run();
			}
		}
	}
}

