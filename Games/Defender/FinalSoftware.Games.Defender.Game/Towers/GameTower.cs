using FinalSoftware.Games.Defender.Library.Towers;
using Microsoft.Xna.Framework;

namespace FinalSoftware.Games.Defender.Game.Towers {

	public class GameTower : Tower {


		public new World GameWorld {
			get { return mWorld as World; }
		}


		public GameTower( Rectangle TowerBase )
			: base( TowerBase ) {
		}

		public GameTower( Rectangle TowerBase, int Health )
			: base( TowerBase, Health ) {
		}


	}

}
