using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;

namespace FinalSoftware.Games.Defender.Library.Projectiles {

	public class Arrow : Projectile {

		public Arrow( DefenderWorld world, Vector2 position, Unit target, int dmg, float speed, int imprecision )
			: base( world, position, target, dmg, speed, imprecision ) {
			texProjectile = world.texArrow;
			mHitAnimation = "red puff";
			mMissAnimation = "dirt puff";

			SetupProjectile();
			CalculateMovement();
		}

		protected override void PlayHitAnimation() {
			mWorld.CreateAnimation( mHitAnimation, mPosition, mRand.Next( 2, 4 ) / 10.0f, 0, 10.0f );
		}

		protected override void PlayMissAnimation() {
			mWorld.CreateAnimation( mMissAnimation, mPosition, mRand.Next( 2, 5 ) / 10.0f, 0, 35.0f );
		}

	}

}
