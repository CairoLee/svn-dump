using FinalSoftware.Games.Defender.Library.Projectiles;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using FinalSoftware.Games.Defender.Library;

namespace FinalSoftware.Games.Defender.Game.Projectiles {

	public class Bullet : Projectile {

		public Bullet( DefenderWorld world, Vector2 position, Unit target, int dmg, float speed, int imprecision )
			: base( world, position, target, dmg, speed, imprecision ) {
			texProjectile = world.texBullet;
			mMissAnimation = "dirt puff";
			mHitAnimation = "red puff";

			mAdditive = true;
			mScale = 0.4f;
			mDmgType = EUnitDamageType.Pierce;

			mColor = new Color( 255, 150, 150, 255 );

			CalculateMovement();
			SetupProjectile();
		}


		protected override void Move() {
			base.Move();
			mWorld.CreateAnimation( "lightCircle", mPosition, 0.2f, 0, 10.0f );
		}

		protected override void PlayHitAnimation() {
			mWorld.CreateAnimation( mHitAnimation, mPosition, mRand.Next( 4, 6 ) / 10.0f, 0, 0.0f );
		}

		protected override void PlayMissAnimation() {
			mWorld.CreateAnimation( mMissAnimation, mPosition, mRand.Next( 2, 5 ) / 10.0f, 0, 35.0f );
		}

	}

}
