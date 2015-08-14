using FinalSoftware.Games.Defender.Library.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Library.Units {

	public class UnitBoss : Unit {

		public UnitBoss( Crossroad spawn, Vector2 offset, Vector2 movement, float speed, int tier, Texture2D textureLiving, Texture2D textureDead, int value, int maxHP )
			: base( spawn, offset, movement, speed, tier, textureLiving, textureDead, value, maxHP ) {
			Scale = 0.8f;
			Color = Color.MediumOrchid;
		}


	}

}
