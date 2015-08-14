using FinalSoftware.Games.Defender.Game.Projectiles;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Game.Towers {

	public class MGTower : GameTower {
		protected bool mBarrelLeft = true;

		public MGTower( Rectangle towerBase )
			: base( towerBase ) {
			textureMM = GameWorld.TexMMmg;
			mName = "MG Tower";
			mFireSound = "mg";
			texture = GameWorld.TexTowerMg;
			mDmg = 30;
			mRange = 175;
			mFiringRate = 70.0f;
			mProjectileSpeed = 15;
			mImprecision = 12;

			mCost = 50;
			mMinimapColor = Color.Blue;

			mDefaultRange = mRange;
			mDefaultFiringRate = mFiringRate;
			mDefaultDmg = mDmg;
			mBaseDamage = mDefaultDmg;

			SetDrawRectangle();
		}


		protected override Unit CheckForTargets() {
			return AcquireClosestTarget();
		}

		protected override void Fire( Unit target ) {
			if( mBarrelLeft ) {
				mWorld.CreateAnimation( "lightCircle", new Vector2( mCenter.X - 5, mCenter.Y - 3 ), 0.6f, 0, 15.0f );
				mProjectiles.Add( new Bullet( mWorld, new Vector2( mCenter.X - 5, mCenter.Y ), target, mDmg, mProjectileSpeed, mImprecision ) );

			} else {
				mWorld.CreateAnimation( "lightCircle", new Vector2( mCenter.X + 5, mCenter.Y - 3 ), 0.6f, 0, 15.0f );
				mProjectiles.Add( new Bullet( mWorld, new Vector2( mCenter.X + 5, mCenter.Y ), target, mDmg, mProjectileSpeed, mImprecision ) );

			}

			if( mPlaySound )
				mWorld.PlaySound( mFireSound, mCenter );

			mBarrelLeft = !mBarrelLeft;
			mFiringTimer = 0;
		}


		public override void DrawTowerDescription( SpriteBatch Batch, SpriteFont Font, Vector2 BasePos ) {
			string desc = "";
			desc += "A powerful weapon, two Browning .50 Caliber Machine Guns\n";
			desc += "provides defense against all types of units.\n";
			desc += "Its strong point is its extremely high rate of fire.\n";
			desc += "\n";
			desc += "Damage Type: Piercing\n";
			desc += "Strong vs: White (Easy) | Weak vs: Blue (Shield)";
			Batch.DrawString( Font, desc, BasePos, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0 );
		}

	}

}
