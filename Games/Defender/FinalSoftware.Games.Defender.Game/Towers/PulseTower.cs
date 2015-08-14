using FinalSoftware.Games.Defender.Game.Projectiles;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Game.Towers {

	public class PulseTower : RocketTower {

		public PulseTower( Rectangle towerBase )
			: base( towerBase ) {
			textureMM = GameWorld.TexMMpulse;
			mName = "Pulse Tower";
			mFireSound = "Space Gun 01";
			texture = GameWorld.TexTowerPulse;
			mDmg = 100;
			mRange = 250;
			mFiringRate = 500.0f;
			mMissileInterval = 150.0f;
			mMinimapColor = Color.OrangeRed;
			mProjectileSpeed = 25;
			mVolleyMode = true;
			mMaxMissiles = 3;
			mHoming = false;

			mCost = 50;

			mDefaultRange = mRange;
			mDefaultFiringRate = mFiringRate;
			mDefaultDmg = mDmg;
			mBaseDamage = mDefaultDmg;

			SetDrawRectangle();
		}


		public override void Update( GameTime gameTime ) {
			base.Update( gameTime );
		}

		protected override void Fire( Unit target ) {
			int offset = (int)( mImprecision * Distance( target ) / mRange );
			if( mMissilesReady > 0 && mMissileTimer > mMissileInterval && ( mVolleyReady || !mVolleyMode ) ) {
				mWorld.CreateAnimation( "redCircle", new Vector2( mCenter.X, mCenter.Y ), 0.6f, 0, 15.0f );
				mWorld.CreateAnimation( "redCircle", new Vector2( mCenter.X, mCenter.Y ), 0.6f, 0, 15.0f );
				mProjectiles.Add( new Pulse( mWorld, new Vector2( mCenter.X, mCenter.Y ), target, mDmg, mProjectileSpeed, mImprecision ) );

				mFiringTimer -= mFiringRate;
				mMissilesReady--;
				mMissileTimer = 0;

				if( mPlaySound )
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


				int changeRange = (int)( mDefaultRange * .03f );
				mRange += changeRange;
				mDefaultRange += changeRange;
				mLevel++;
				return mCost;
			}
			return 0;
		}


		public override void DrawUpgradeInfo( SpriteBatch Batch, SpriteFont Font, Vector2 BasePos ) {
			string text = "";
			text += "Upgrade Cost: " + UpgradeCost + "€\n";
			text += "Damage + " + ( (int)( mBaseDamage * ( mLevel + 1 ) * .9f ) - mBaseDamage ) + "\nRange + 3%";
			Batch.DrawString( Font, text, BasePos, Color.White, 0, Vector2.Zero, 0.4f, SpriteEffects.None, 0 );
		}

		public override void DrawTowerDescription( SpriteBatch Batch, SpriteFont Font, Vector2 BasePos ) {
			string desc = "";
			desc += "Guaranteed to decimate your enemies, the Pulse Tower\n";
			desc += "fires plasma bullets, melting armor and dealing death.\n";
			desc += "\n";
			desc += "Damage Type: Energy\n";
			desc += "Strong vs: Blue (Shield) | Weak vs: White (Easy)";
			Batch.DrawString( Font, desc, BasePos, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0 );
		}

	}

}
