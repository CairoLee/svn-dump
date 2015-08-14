using FinalSoftware.Games.Defender.Game.Projectiles;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Game.Towers {

	public class ArtilleryTower : RocketTower {

		public ArtilleryTower( Rectangle towerBase )
			: base( towerBase ) {
			textureMM = GameWorld.TexMMartillery;
			texture = GameWorld.TexTowerArty;
			mName = "Artillery Tower";
			mFireSound = "artillery";
			mVolleyMode = true;
			mRange = 1250;
			mDmg = 15;
			mSDmg = 15;
			mFiringRate = 250.0f;
			mPAcceleration = 0;
			mImprecision = 40;
			mMaxMissiles = 30;
			mMissileInterval = 50;
			mHoming = false;
			mProjectileSpeed = 8.5f;
			mSRange = 115;
			mMinimapColor = Color.Orange;

			mCost = 125;

			mDefaultRange = mRange;
			mDefaultFiringRate = mFiringRate;
			mDefaultDmg = mDmg;
			mBaseDamage = mDefaultDmg;
		}


		protected override void Fire( Unit target ) {
			int offset = (int)( mImprecision * Distance( target ) / mRange );

			if( mMissilesReady > 0 && mMissileTimer > mMissileInterval && ( mVolleyReady || !mVolleyMode ) ) {
				if( mTubeLeft ) {
					mProjectiles.Add( new Shell( mWorld, new Vector2( mCenter.X - 3, mCenter.Y - 2 ), target, mDmg, mProjectileSpeed, mImprecision, mSDmg, mSRange, mPAcceleration, mHoming ) );
					mWorld.CreateAnimation( "explosion2", new Vector2( mCenter.X - 3, mCenter.Y - 2 ), 0.25f, 0, 16.0f );
				} else {
					mProjectiles.Add( new Shell( mWorld, new Vector2( mCenter.X + 3, mCenter.Y - 2 ), target, mDmg, mProjectileSpeed, mImprecision, mSDmg, mSRange, mPAcceleration, mHoming ) );
					mWorld.CreateAnimation( "explosion1", new Vector2( mCenter.X + 3, mCenter.Y - 2 ), 0.25f, 0, 16.0f );
				}

				mTubeLeft = !mTubeLeft;
				mFiringTimer -= mFiringRate;
				mMissilesReady--;
				mMissileTimer = 0;

				if( mPlaySound )
					mWorld.PlaySound( mFireSound, mCenter );
				if( mMissilesReady == 0 )
					mVolleyReady = false;
			}
		}

		public override void DrawTowerDescription( SpriteBatch Batch, SpriteFont Font, Vector2 BasePos ) {
			string desc = "";
			desc += "This tower has an extremely long range.\n";
			desc += "The artillery tower fires an explosive shell\n";
			desc += "that rains down on the enemies in a symphony of destruction.\n";
			desc += "\n";
			desc += "Damage Type: Explosive\n";
			desc += "Strong vs: Yellow (Fast) | Weak vs: Green (Medical)";
			Batch.DrawString( Font, desc, BasePos, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0 );
		}

	}

}
