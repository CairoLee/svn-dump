using FinalSoftware.Games.Defender.Game.Projectiles;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Game.Towers {

	public class FlameTower : RocketTower {
		private float mSTimer, mSInterval;

		public FlameTower( Rectangle towerBase )
			: base( towerBase ) {
			textureMM = GameWorld.TexMMflame;
			texture = GameWorld.TexTowerFlame;
			mFireSound = "flamethrower";
			mName = "Flame Tower";
			mFiringRate = 100;
			mRange = 100;
			mImprecision = 16;
			mHoming = true;
			mDmg = 3;
			mSDmg = mDmg;
			mProjectileSpeed = 2.0f;
			mPAcceleration = 0;
			mSInterval = 64;
			mMinimapColor = Color.Yellow;

			mDefaultRange = mRange;
			mDefaultFiringRate = mFiringRate;
			mDefaultDmg = mDmg;
			mBaseDamage = mDefaultDmg;

			mCost = 75;
			SetDrawRectangle();
		}


		public override void Update( GameTime gameTime ) {
			mSTimer += 16;
			base.Update( gameTime );
		}

		protected override void Fire( Unit target ) {
			if( mSTimer > mSInterval ) {
				mSTimer = 0;
				if( mPlaySound )
					mWorld.PlaySound( mFireSound, mCenter );
			}
			mProjectiles.Add( new Flame( mWorld, new Vector2( mCenter.X, mCenter.Y - 2 ), target, mDmg, mProjectileSpeed,
				mImprecision, mSDmg, mSRange, mPAcceleration ) );
			mFiringTimer = 0;
		}


		public override void DrawTowerDescription( SpriteBatch Batch, SpriteFont Font, Vector2 BasePos ) {
			string desc = "";
			desc += "Shooting pressurized propane, the flame tower incinerates\n";
			desc += "everything that passes by it.\n";
			desc += "\n";
			desc += "Damage Type: Burning\n";
			desc += "Strong vs: Green (Medical) | Weak vs: Yellow (Fast)";
			Batch.DrawString( Font, desc, BasePos, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0 );
		}

	}

}
