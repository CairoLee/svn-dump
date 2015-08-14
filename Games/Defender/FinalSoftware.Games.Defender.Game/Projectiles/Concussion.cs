using FinalSoftware.Games.Defender.Game.Units;
using FinalSoftware.Games.Defender.Library.Projectiles;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using FinalSoftware.Games.Defender.Library;

namespace FinalSoftware.Games.Defender.Game.Projectiles {

	public class Concussion : Projectile {
		protected int mNetSize;
		protected float mSlowEffect;
		protected int mDuration;


		public Concussion( DefenderWorld world, Vector2 position, Unit target, int dmg, float speed, int imprecision, int netSize, float slowEffect, int duration )
			: base( world, position, target, dmg, speed, imprecision ) {
			texProjectile = world.texConcussion;
			mMissAnimation = "concussion";
			mHitAnimation = "concussion";
			mSplash = true;

			mDmgType = EUnitDamageType.Energy;

			mNetSize = netSize;
			mSlowEffect = slowEffect;
			mDuration = duration;

			CalculateMovement();
			SetupProjectile();
		}


		protected override void ApplySingleDamage() {
			if( mDirectHit ) {
				mTarget.Damage( mDmg, mDmgType );
				mTarget.AddEffect( "Slowing", new UnitEffectSlow( mDuration, mSlowEffect ) );
				PlayHitAnimation();
			} else {
				foreach( Unit u in mWorld.Waves.GetUnits() ) {
					if( Area.Intersects( u.Rectangle ) ) {
						mDirectHit = true;
						u.Damage( mDmg, mDmgType );
						u.AddEffect( "Slowing", new UnitEffectSlow( mDuration, mSlowEffect ) );
						PlayHitAnimation();
						break;
					}
				}
			}

			if( !mDirectHit )
				PlayMissAnimation();
		}

		protected override void ApplySplashDamage() {
			Rectangle splashArea = new Rectangle( Area.X - mNetSize / 2, Area.Y - mNetSize / 2, mNetSize, mNetSize );

			if( Area.Intersects( mTarget.Rectangle ) ) {
				mTarget.Damage( mDmg, mDmgType );
				mTarget.AddEffect( "Slowing", new UnitEffectSlow( mDuration, mSlowEffect ) );
			}

			foreach( Unit u in mWorld.Waves.GetUnits() ) {
				if( splashArea.Intersects( u.Rectangle ) ) {
					u.Damage( mSplashDmg, mDmgType );
					u.AddEffect( "Slowing", new UnitEffectSlow( mDuration, mSlowEffect ) );
				}
			}
			PlayHitAnimation();
		}

		protected override void PlayHitAnimation() {
			mWorld.CreateAnimation( mHitAnimation, mPosition, .9f, 0, 25.0f );
		}

	}

}
