using System;

namespace Puzzle3D {

	public static class Program {

		public static void Main() {
			using( Puzzle3D game = new Puzzle3D() ) {
				game.Run();
			}
		}

	}

}

