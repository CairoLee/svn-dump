using FinalSoftware.Games.Defender.Library.Towers;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Game.Towers {

	public class CommandCenter : GameTower {
		protected int duration = 5;
		protected float damageInc = .1f;
		protected float rangeInc = 0;

		public float DamageInc {
			get { return damageInc; }
		}
		public float RangeInc {
			get { return rangeInc; }
		}


		public CommandCenter( Rectangle towerBase )
			: base( towerBase ) {
			textureMM = GameWorld.TexMMcommand;
			mName = "Command";
			texture = GameWorld.TexTowerCmdCenter;
			mMinimapColor = Color.Gray;

			mFiringRate = 1.0f;
			mDefaultFiringRate = mFiringRate;

			mDmg = 0;
			mDefaultDmg = mDmg;

			mRange = 50;
			mDefaultRange = mRange;

			mProjectileSpeed = 0f;
			mCost = 25;

			SetDrawRectangle();
		}


		public override void Update( GameTime gameTime ) {
			Fire( null );
		}

		protected override void Fire( Unit target ) {
			foreach( Tower t in mWorld.Towers ) {
				if( Distance( t ) < mRange ) {
					TowerEffects effect = new TowerEffectEnhance( duration, damageInc, rangeInc );
					t.AddEffect( effect.Type, effect );
				}
			}
		}

		public override void Draw( SpriteBatch sbAlpha, SpriteBatch sbAdditive ) {
			base.Draw( sbAlpha, sbAdditive );
		}

		public override int Upgrade() {
			if( mLevel < MAX_LVL ) {
				damageInc += .1f;

				int changeRange = (int)( mDefaultRange * .05 );
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
			text += "Damage Bonus + 5%\nRange Bonus + 5%\nRange of Effect + 5%";
			Batch.DrawString( Font, text, BasePos, Color.White, 0, Vector2.Zero, 0.4f, SpriteEffects.None, 0 );
		}

		public override void DrawUpgradeDescription( SpriteBatch Batch, SpriteFont Font, Vector2 BasePos ) {
			string desc = "";
			desc += Name;
			desc += "\nDamage Enhance: " + DamageInc * 100.0f + "%";
			desc += "\nRange Enhance: " + RangeInc * 100 + "%";
			desc += "\nRange: " + Range;
			desc += "\nCost: " + Cost;

			Batch.DrawString( Font, desc, BasePos, Color.White, 0, Vector2.Zero, 0.4f, SpriteEffects.None, 0 );
		}

		public override void DrawTowerDescription( SpriteBatch Batch, SpriteFont Font, Vector2 BasePos ) {
			string desc = "";
			desc += "Giving direction to your troops, the command tower increases the\n";
			desc += "effectiveness of all towers in its range.";
			Batch.DrawString( Font, desc, BasePos, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0 );
		}

		public override void DrawStatusDescription( SpriteBatch Batch, SpriteFont Font, Vector2 Pos, int LineSpace, Color Color, float Scale ) {
			Batch.DrawString( Font, "Dmg Bonus: " + DamageInc * 100 + "%", new Vector2( Pos.X, Pos.Y + LineSpace * 2 ), Color, 0, Vector2.Zero, Scale, SpriteEffects.None, 0 );
			Batch.DrawString( Font, "Range Bonus: " + RangeInc * 100 + "%", new Vector2( Pos.X, Pos.Y + LineSpace * 3 ), Color, 0, Vector2.Zero, Scale, SpriteEffects.None, 0 );
			Batch.DrawString( Font, "Range: " + Range, new Vector2( Pos.X, Pos.Y + LineSpace * 4 ), Color, 0, Vector2.Zero, Scale, SpriteEffects.None, 0 );
		}

	}

}
