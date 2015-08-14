using System;
using FinalSoftware.Games.Defender.Library.Tools;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Game.Towers {

	public class GammaRayTower : GameTower {
		private ColorFade mBeamFadeA = new ColorFade( 140, 255, 16 );
		private Rectangle mBeamOrigin;
		private Vector2 mBeamOriginV;
		private int mDmgBonus = 1;


		public GammaRayTower( Rectangle towerBase )
			: base( towerBase ) {
			textureMM = GameWorld.TexMMgamma;
			mFireSound = "gammabeam";
			mName = "GammaRay Tower";
			texture = GameWorld.TexTowerGammaRay;

			mFiringRate = 100f;
			mDmg = 6;
			mRange = 200;
			mImprecision = 0;
			mProjectileSpeed = 10;
			mMinimapColor = Color.Red;

			mDefaultRange = mRange;
			mDefaultFiringRate = mFiringRate;
			mDefaultDmg = mDmg;
			mBaseDamage = mDefaultDmg;

			mCost = 100;

			SetDrawRectangle();
			mBeamOrigin = new Rectangle( (int)mCenter.X, (int)mCenter.Y, 8, 8 );
			mBeamOrigin.Y -= 34;
			mBeamOriginV = new Vector2( mBeamOrigin.X, mBeamOrigin.Y );
		}


		public override void Update( GameTime gameTime ) {
			mBeamFadeA.Update();

			if( mTargetCheckTimer > mTargetCheckInterval ) {
				if( mTarget == null || mTarget.Dead || Distance( mTarget ) > mRange ) {
					mDmgBonus = 0;
					mTarget = AcquireClosestTarget();
					if( mTarget == null )
						mTargetCheckTimer = 0;
				} else {
					mFiringTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
					Fire( mTarget );
				}
			} else
				mTargetCheckTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
		}

		public override void Draw( SpriteBatch sbAlpha, SpriteBatch sbAdditive ) {
			base.Draw( sbAlpha, sbAdditive );

			if( mTarget != null && !mTarget.Dead ) {
				Color color = new Color( 255, 180, 0, mBeamFadeA.Value );
				Vector2 toMove = mTarget.Center - mBeamOriginV;
				Rectangle beam = CalculateBeam( toMove );
				sbAdditive.Draw( mWorld.texBullet, beam, null, color, CalculateAngle( toMove ), new Vector2( 0, beam.Height / 2 ), SpriteEffects.None, 0 );
			}
		}

		protected Rectangle CalculateBeam( Vector2 toMove ) {
			int width = 10;
			return new Rectangle( (int)mBeamOrigin.X, (int)( mBeamOrigin.Y ), (int)toMove.Length(), width );
		}

		protected float CalculateAngle( Vector2 toMove ) {
			if( mTarget.Center.X == mBeamOrigin.X ) {
				if( mTarget.Center.Y < mBeamOrigin.Y )
					return -MathHelper.PiOver2;
				else
					return MathHelper.PiOver2;
			} else if( mTarget.Center.Y == mBeamOrigin.Y ) {
				if( mTarget.Center.X > mBeamOrigin.X )
					return 0;
				else
					return MathHelper.Pi;
			} else if( mTarget.Center.X < mBeamOrigin.X )
				return (float)( Math.Atan( toMove.Y / toMove.X ) + Math.PI );
			else
				return (float)( Math.Atan( toMove.Y / toMove.X ) );
		}

		protected override void Fire( Unit target ) {
			if( mFiringTimer >= mFiringRate ) {
				if( mPlaySound )
					mWorld.PlaySound( mFireSound, mCenter );
				target.Damage( mDmg + mDmgBonus, EUnitDamageType.Energy );
				mWorld.CreateAnimation( "beamHit", target.Center, 0.25f, 0, 10f );
				mWorld.CreateAnimation( "lightCircle", target.Center, 0.25f, 0, 10f );
				mFiringTimer = 0f;
				mDmgBonus += mDmg;
			}
		}

		public override void DrawTowerDescription( SpriteBatch Batch, SpriteFont Font, Vector2 BasePos ) {
			string desc = "";
			desc += "This tower obliterates almost everything in its path.\n";
			desc += "Using concentrated gamma rays, this tower is extremely effective,\n";
			desc += "but very expensive. Its damage increases exponentially the\n";
			desc += "longer it is hitting a target.\n";
			desc += "\n";
			desc += "Damage Type: Energy\n";
			desc += "Strong vs: Blue (Shield) | Weak vs: White (Easy)";
			Batch.DrawString( Font, desc, BasePos, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0 );
		}

	}

}
