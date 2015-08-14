using FinalSoftware.Games.Defender.Library.Animation;
using FinalSoftware.Games.Defender.Library.Projectiles;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using FinalSoftware.Games.Defender.Library;

namespace FinalSoftware.Games.Defender.Game.Projectiles {

	public class Shell : Projectile {

		public Shell( DefenderWorld world, Vector2 position, Unit target, int dmg, float speed, int imprecision, int sDmg, int sRange, float acceleration, bool homing )
			: base( world, position, target, dmg, speed, imprecision ) {
			texProjectile = world.texRocket;

			mHitAnimation = "explosion1";
			mHitSound = "RndExplosion";
			mMissAnimation = mHitAnimation;

			mDmgType = EUnitDamageType.Explosive;
			mMaxSpeed = 15;
			mSplash = true;

			mSplashDmg = sDmg;
			mSplashRange = sRange;
			mHoming = homing;
			mAcceleration = acceleration;

			SetupProjectile();
			CalculateMovement();
		}


		protected override void Move() {
			base.Move();

			mWorld.CreateAnimation( "lightCircle", mPosition, 0.6f, 0, 10.0f );
		}

		protected override void PlayHitAnimation() {
			mWorld.CreateAnimation( mHitAnimation, mPosition, mRand.Next( 6, 12 ) / 10.0f,
				MathHelper.ToRadians( mRand.Next( 0, 180 ) ), 32.0f );
			mWorld.Scorches.Add( new Scorch( new Rectangle( (int)mPosition.X, (int)mPosition.Y, 60, 60 ),
				0, mRand.Next( 4, 8 ) / 10.0f ) );
		}

		protected override void PlayMissAnimation() {
			PlayHitAnimation();
		}

	}

}
