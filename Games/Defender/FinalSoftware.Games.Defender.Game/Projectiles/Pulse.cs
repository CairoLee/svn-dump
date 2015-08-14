using FinalSoftware.Games.Defender.Library.Projectiles;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using FinalSoftware.Games.Defender.Library;

namespace FinalSoftware.Games.Defender.Game.Projectiles {

	public class Pulse : Projectile {

		public Pulse( DefenderWorld world, Vector2 position, Unit target, int dmg, float speed, int imprecision )
			: base( world, position, target, dmg, speed, imprecision ) {
			texProjectile = world.texBullet;
			mMissAnimation = "redCircle";
			mHitAnimation = "pulseHit";

			mDmgType = EUnitDamageType.Energy;
			mAcceleration = 0;
			mAdditive = true;
			mScale = 0.7f;

			mColor = new Color( 255, 60, 60, 255 );

			CalculateMovement();
			SetupProjectile();
		}


		protected override void Move() {
			base.Move();
			mWorld.CreateAnimation( "redCircle", mPosition, 0.6f, 0, 10.0f );
		}

		protected override void PlayHitAnimation() {
			mWorld.CreateAnimation( mHitAnimation, mPosition, .5f, 0, 10.0f );
			mWorld.CreateAnimation( mHitAnimation, mPosition, .5f, 0, 10.0f );
		}

		protected override void PlayMissAnimation() {
			PlayHitAnimation();
		}

	}

}
