using FinalSoftware.Games.Defender.Library.Map;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Game.Units {

	public class FastUnit : Unit {

		public FastUnit( Crossroad spawn, Vector2 offset, Vector2 movement, float speed, int tier, Texture2D textureLiving, Texture2D textureDead, int value, int maxHP )
			: base( spawn, offset, movement, speed, tier, textureLiving, textureDead, value, maxHP ) {
			mTint = Color.Yellow;
			mDSpeed *= 1.5f;
			mSpeed = mDSpeed;
			mMoney = value;
		}


		protected override int RealDamage( int dmg, EUnitDamageType dType ) {
			switch( dType ) {
				case EUnitDamageType.Explosive:
					dmg = (int)( 1.5 * dmg );
					break;
				case EUnitDamageType.Burn:
					dmg = (int)( 0.5 * dmg );
					break;
				default:
					break;
			}
			return dmg;
		}

	}

}
