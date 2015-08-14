using Microsoft.Xna.Framework;

namespace FinalSoftware.Games.Defender.Library.Units {

	interface IUnitWave {

		UnitList GetTargets( Vector2 Distance, int Range );
		Unit GetFirstTarget( Vector2 Distance, int Range );
		Unit GetRandomTarget( Vector2 Distance, int Range );
		Unit GetClosestTarget( Vector2 Distance, int Range );

	}

}
