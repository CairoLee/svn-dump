using FinalSoftware.Games.Defender.Library.Map;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Game.Units {

	public class StrongUnit : Unit {
		protected bool mShieldReady = true;
		protected bool mShieldActive = false;
		protected float mAbsorbtion = 0.8f;
		protected float mShieldDuration = 20000;
		protected float mShieldRegen = 90000;
		protected float mShieldTimer = 0;

		public StrongUnit( Crossroad spawn, Vector2 offset, Vector2 movement, float speed, int tier, Texture2D textureLiving, Texture2D textureDead, int value, int maxHP )
			: base( spawn, offset, movement, speed, tier, textureLiving, textureDead, value, maxHP ) {
			mTint = Color.CornflowerBlue;
			DSpeed *= 0.7f;
			mSpeed = DSpeed;
			mMoney = value;
			mMaxHealth *= 2;
			mHealth = mMaxHealth;
		}


		public override void Update( GameTime time ) {
			base.Update( time );

			if( mShieldActive ) {
				mShieldTimer += (float)time.ElapsedGameTime.TotalMilliseconds;
				if( mShieldTimer > mShieldDuration ) {
					mShieldTimer = 0f;
					mShieldActive = false;
					mTint = Color.Gray;
				}
			} else if( !mShieldReady ) {
				mShieldTimer += (float)time.ElapsedGameTime.TotalMilliseconds;
				if( mShieldTimer > mShieldRegen ) {
					mShieldTimer = 0f;
					mShieldReady = true;
				}
			}
		}

		public override void Damage( int dmg, EUnitDamageType dType ) {
			int unmitigated = dmg;
			if( mShieldReady ) {
				mTint = Color.MediumBlue;
				mShieldActive = true;
				mShieldReady = false;
			}

			if( mShieldActive ) {
				if( dType == EUnitDamageType.Energy )
					unmitigated = dmg;
				else
					unmitigated = (int)( ( 1 - mAbsorbtion ) * dmg );
			}

			base.Damage( unmitigated, dType );
		}


		protected override int RealDamage( int dmg, EUnitDamageType dType ) {
			switch( dType ) {
				case EUnitDamageType.Energy:
					dmg = (int)( 1.5 * dmg );
					break;
				case EUnitDamageType.Piercing:
					dmg = (int)( 0.5 * dmg );
					break;
				default:
					break;
			}
			return dmg;
		}

	}

}
