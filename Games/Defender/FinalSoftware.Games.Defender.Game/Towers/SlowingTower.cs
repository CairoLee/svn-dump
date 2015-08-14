using FinalSoftware.Games.Defender.Game.Projectiles;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Game.Towers {

	public class SlowingTower : GameTower {
		protected float mSlowEffect = .5f;
		protected int mSRange = 60;
		protected int mDuration = 6;
		protected Vector2 mPOrigin;

		public float SlowEffect {
			get { return mSlowEffect; }
		}
		public int Duration {
			get { return mDuration; }
		}
		public int SRange {
			get { return mSRange; }
		}


		public SlowingTower( Rectangle towerBase )
			: base( towerBase ) {
			textureMM = GameWorld.TexMMconcussive;
			mName = "Concussion Tower";
			mFireSound = null;

			texture = GameWorld.TexTowerConcussion;
			mMinimapColor = Color.LightBlue;

			mFiringRate = 5000.0f;
			mDmg = 0;
			mRange = 200;
			mProjectileSpeed = 5f;

			mDefaultFiringRate = mFiringRate;
			mDefaultDmg = mDmg;
			mDefaultRange = mRange;

			mCost = 25;

			SetDrawRectangle();
			mPOrigin = new Vector2( mCenter.X, mCenter.Y - 35 );
			mFiringTimer = mFiringRate;
		}


		protected override void Fire( Unit target ) {
			mProjectiles.Add( new Concussion( mWorld, mPOrigin, AcquireClosestTarget(), mDmg, mProjectileSpeed, mImprecision, mSRange, mSlowEffect, mDuration ) );
			mFiringTimer = 0;
		}

		public override int Upgrade() {
			if( mLevel < MAX_LVL ) {
				int changeSplash = (int)( mSRange * .10f );
				mSRange += changeSplash;
				mDuration += 1;

				int changeRange = (int)( mDefaultRange * .10f );
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
			text += "Splash Range + 10% \nDuration + 1sec\nRange + 10%";
			Batch.DrawString( Font, text, BasePos, Color.White, 0, Vector2.Zero, 0.4f, SpriteEffects.None, 0 );
		}

		public override void DrawUpgradeDescription( SpriteBatch Batch, SpriteFont Font, Vector2 BasePos ) {
			string desc = "";
			desc += Name;
			desc += "\nSlow Effect: " + SlowEffect * 100.0f + "%";
			desc += "\nDuration: " + Duration + "secs";
			desc += "\nRange: " + Range;

			Batch.DrawString( Font, desc, BasePos, Color.White, 0, Vector2.Zero, 0.4f, SpriteEffects.None, 0 );
		}

		public override void DrawTowerDescription( SpriteBatch Batch, SpriteFont Font, Vector2 BasePos ) {
			string desc = "";
			desc += "The slowing tower fires a stun grenade which disrupts\n";
			desc += "ground units and slowing them down.";
			Batch.DrawString( Font, desc, BasePos, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0 );
		}

		public override void DrawStatusDescription( SpriteBatch Batch, SpriteFont Font, Vector2 Pos, int LineSpace, Color Color, float Scale ) {
			Batch.DrawString( Font, "Slow Effect: " + SlowEffect * 100 + "%", new Vector2( Pos.X, Pos.Y + LineSpace * 2 ), Color, 0, Vector2.Zero, Scale, SpriteEffects.None, 0 );
			Batch.DrawString( Font, "Effect Size: " + SRange, new Vector2( Pos.X, Pos.Y + LineSpace * 3 ), Color, 0, Vector2.Zero, Scale, SpriteEffects.None, 0 );
			Batch.DrawString( Font, "Duration: " + Duration, new Vector2( Pos.X, Pos.Y + LineSpace * 4 ), Color, 0, Vector2.Zero, Scale, SpriteEffects.None, 0 );
			Batch.DrawString( Font, "Range: " + Range, new Vector2( Pos.X, Pos.Y + LineSpace * 5 ), Color, 0, Vector2.Zero, Scale, SpriteEffects.None, 0 );
		}

	}

}
