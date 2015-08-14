using FinalSoftware.Games.Defender.Library.Map;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Game.Units {

	public class RegenUnit : Unit {
		private float mRegenTimer = 0;
		private float mRegenSpeed = 5000.0f;
		private int mRegenAmount;

		public RegenUnit( Crossroad spawn, Vector2 offset, Vector2 movement, float speed, int tier, Texture2D textureLiving, Texture2D textureDead, int value, int maxHP )
			: base( spawn, offset, movement, speed, tier, textureLiving, textureDead, value, maxHP ) {
			mTint = Color.Green;
			mRegenAmount = (int)( mMaxHealth * 0.1f );
			mSpeed = mDSpeed;
			mMoney = value;
		}


		public override void Update( GameTime time ) {
			base.Update( time );

			mRegenTimer += (float)World.Instance.Game.TargetElapsedTime.TotalMilliseconds;
			if( mRegenTimer > mRegenSpeed ) {
				mRegenTimer = 0;
				mHealth += mRegenAmount;
				if( mHealth > mMaxHealth )
					mHealth = mMaxHealth;
			}
		}

		protected override int RealDamage( int dmg, EUnitDamageType dType ) {
			switch( dType ) {
				case EUnitDamageType.Burn:
					dmg = (int)( 1.5 * dmg );
					break;
				case EUnitDamageType.Explosive:
					dmg = (int)( 0.5 * dmg );
					break;
				default:
					break;
			}
			return dmg;
		}

	}

}
