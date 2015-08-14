using System;

namespace PacMan {

	public static class Program {
	
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		public static void Main(string[] args) {
			using (PacMan game = new PacMan()) {
				game.Run();
			}
		}

	}
}

