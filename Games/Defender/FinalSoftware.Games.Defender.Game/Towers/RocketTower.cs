using FinalSoftware.Games.Defender.Game.Projectiles;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Game.Towers {

	public class RocketTower : GameTower {
		protected float mPOffset;
		protected float mPAcceleration;
		protected int mMissilesReady = 0;
		protected float mMissileInterval = 125;
		protected float mMissileTimer = 0.0f;
		protected int mMaxMissiles = 4;
		protected bool mTubeLeft = true;
		protected bool mVolleyReady = false;
		protected bool mVolleyMode = false;
		protected int mSDmg, mSRange;

		public RocketTower( Rectangle towerBase )
			: base( towerBase ) {
			textureMM = GameWorld.TexMMrocket;
			mName = "Rocket Tower";
			mFireSound = "Rocket";
			texture = GameWorld.TexTowerRocket;

			mFiringRate = 1000.0f;
			mHoming = true;
			mDmg = 10;
			mSDmg = mDmg;
			mSRange = 60;
			mRange = 600;
			mProjectileSpeed = 0.1f;
			mPAcceleration = 0.2f;
			mMinimapColor = new Color( 255, 200, 0, 255 );

			mCost = 50;

			mPOffset = (float)( 0.25 * towerBase.Width );

			mDefaultRange = mRange;
			mDefaultFiringRate = mFiringRate;
			mDefaultDmg = mDmg;
			mBaseDamage = mDefaultDmg;

			SetDrawRectangle();
		}


		protected override void Reload( GameTime gameTime ) {
			if( mFiringTimer < mFiringRate * mMaxMissiles ) {
				mMissileTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
				mFiringTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

				mMissilesReady = (int)( mFiringTimer / mFiringRate );
				if( mMissilesReady == mMaxMissiles )
					mVolleyReady = true;
			}
		}

		protected override Unit CheckForTargets() {
			return AcquireRandomTarget();
		}

		protected override void Fire( Unit target ) {
			int offset = (int)( mImprecision * Distance( target ) / mRange );
			if( mMissilesReady > 0 && mMissileTimer > mMissileInterval && ( mVolleyReady || !mVolleyMode ) ) {
				if( mTubeLeft )
					mProjectiles.Add( new Rocket( mWorld, new Vector2( mCenter.X - 3, mCenter.Y - 2 ), target, mDmg, mProjectileSpeed, mImprecision, mSDmg, mSRange, mPAcceleration, mHoming ) );
				else
					mProjectiles.Add( new Rocket( mWorld, new Vector2( mCenter.X + 3, mCenter.Y - 2 ), target, mDmg, mProjectileSpeed, mImprecision, mSDmg, mSRange, mPAcceleration, mHoming ) );

				mTubeLeft = !mTubeLeft;
				mFiringTimer -= mFiringRate;
				mMissilesReady--;
				mMissileTimer = 0;

				mWorld.PlaySound( mFireSound, mCenter );

				if( mMissilesReady == 0 )
					mVolleyReady = false;
			}
		}

		public override int Upgrade() {
			if( mLevel < MAX_LVL ) {
				int changeDmg = (int)( mBaseDamage * ( mLevel + 1 ) * .9f );
				mDmg += changeDmg - mDefaultDmg;
				mDefaultDmg = changeDmg;

				int changeSplash = (int)( mDefaultDmg / 3f );
				mSDmg = changeSplash;

				mLevel++;

				return mCost;
			}
			return 0;
		}

		public override void DrawUpgradeInfo( SpriteBatch Batch, SpriteFont Font, Vector2 BasePos ) {
			string text = "";
			text += "Upgrade Cost: " + UpgradeCost + "€\n";
			text += "Damage + " + ( (int)( mBaseDamage * ( mLevel + 1 ) * .9f ) - mBaseDamage ) + "\nSplash Damage + " + string.Format( "{0:0}", mDefaultDmg / 3 );
			Batch.DrawString( Font, text, BasePos, Color.White, 0, Vector2.Zero, 0.4f, SpriteEffects.None, 0 );
		}

		public override void DrawTowerDescription( SpriteBatch Batch, SpriteFont Font, Vector2 BasePos ) {
			string desc = "";
			desc += "Explosive power that delievers a payload of destruction.\n";
			desc += "The rocket tower deals splash damage\n";
			desc += "to all of those close to the explosion.\n";
			desc += "\n";
			desc += "Damage Type: Explosive\n";
			desc += "Strong vs: Yellow (Fast) | Weak vs: Green (Medical)";
			Batch.DrawString( Font, desc, BasePos, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0 );
		}

	}

}
