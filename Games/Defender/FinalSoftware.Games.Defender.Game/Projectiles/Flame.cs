using FinalSoftware.Games.Defender.Library.Animation;
using FinalSoftware.Games.Defender.Library.Projectiles;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using FinalSoftware.Games.Defender.Library;

namespace FinalSoftware.Games.Defender.Game.Projectiles {

	public class Flame : Projectile {

		public Flame( DefenderWorld world, Vector2 position, Unit target, int dmg, float speed, int imprecision, int sDmg, int sRange, float acceleration )
			: base( world, position, target, dmg, speed, imprecision ) {
			texProjectile = world.texFire;
			mHitAnimation = "explosion3";
			mMissAnimation = mHitAnimation;

			mDmgType = EUnitDamageType.Burn;

			mSplash = true;
			mSplashDmg = sDmg;
			mSplashRange = sRange;
			mAcceleration = acceleration;

			SetupProjectile();
			CalculateMovement();
		}

		protected override void Move() {
			base.Move();
			mWorld.CreateAnimation( "fire", mPosition, 0.30f, mAngle + MathHelper.PiOver2, 10.0f );
		}

		protected override void PlayHitAnimation() {
			mWorld.CreateAnimation( mHitAnimation, mPosition, 0.8f, MathHelper.ToRadians( mRand.Next( 0, 180 ) ), 10.0f );
			mWorld.Scorches.Add( new Scorch( new Rectangle( (int)mPosition.X, (int)mPosition.Y, 30, 30 ), 0, mRand.Next( 2, 3 ) / 10.0f ) );
		}

		protected override void PlayMissAnimation() {
			PlayHitAnimation();
		}

	}

}
