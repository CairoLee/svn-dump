using System;
using System.Collections.Generic;
using System.Text;

namespace Bomberman_Clone {

	public class Collision {

		public static bool checkDeath( Player player ) {
			foreach( Explosion exp in BomberMan.explosions ) {
				if( Math.Abs( player.center.X - exp.middleMiddle.X ) < 19 && Math.Abs( player.center.Y - exp.middleMiddle.Y ) < 20 )
					return true;
				if( Math.Abs( player.center.X - exp.lefMiddle.X ) < 19 && Math.Abs( player.center.Y - exp.lefMiddle.Y ) < 20 )
					return true;
			}
			return false;
		}

	}

}
