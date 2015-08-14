using System;

namespace Tetris {

	static class Program {

		static void Main( string[] args ) {
			using( TetrisGame game = new TetrisGame() ) {
				game.Run();
			}
		}

	}

}

