using System;

namespace Bomberman_Clone {

	static class Program {
		static void Main( string[] args ) {
			using( BomberMan game = new BomberMan() ) {
				game.Run();
			}
		}
	}

}

