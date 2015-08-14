using FinalSoftware.Games.Defender.Game.Projectiles;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Game.Towers {

	public class RifleTower : GameTower {

		public RifleTower( Rectangle towerBase )
			: base( towerBase ) {
			textureMM = GameWorld.TexMMrifle;
			mFireSound = "rifle";
			mName = "Rifle Tower";
			texture = GameWorld.TexTowerRifle;

			mFiringRate = 700.0f;
			mDmg = 30;
			mRange = 225;
			mImprecision = 1;
			mProjectileSpeed = 18;
			mMinimapColor = Color.Green;

			mDefaultRange = mRange;
			mDefaultFiringRate = mFiringRate;
			mDefaultDmg = mDmg;
			mBaseDamage = mDefaultDmg;

			mCost = 10;

			SetDrawRectangle();
		}


		protected override void Fire( Unit target ) {
			mProjectiles.Add( new Bullet( mWorld, mCenter, target, mDmg, mProjectileSpeed, mImprecision ) );

			mFiringTimer = 0;
			if( mFireSound != null && mPlaySound )
				mWorld.PlaySound( mFireSound, mCenter );
		}


		public override void DrawTowerDescription( SpriteBatch Batch, SpriteFont Font, Vector2 BasePos ) {
			string desc = "";
			desc += "This is a high powered rifle that can target one unit at a time.\n";
			desc += "This entry level tower does little good in later stages,\n";
			desc += "but is good for early stages of the game.\n";
			desc += "\n";
			desc += "Damage Type: Piercing\n";
			desc += "Strong vs: White (Easy) | Weak vs: Blue (Shield)";
			Batch.DrawString( Font, desc, BasePos, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0 );
		}

	}

}