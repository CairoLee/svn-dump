using System;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Library.Projectiles {

	public class Projectile {

		protected bool mHoming = false;
		protected bool mActive = true;
		protected Vector2 mPosition;
		protected Vector2 mMovement;
		protected float mMinSpeed = 0;
		protected float mMaxSpeed = 50;
		protected float mSpeed = 1;
		protected float mAcceleration = 0;
		protected float mAngle = 0;

		protected DefenderWorld mWorld;
		protected Unit mTarget;
		protected Vector2 mTargetPos;
		protected Rectangle mTargetArea;
		protected Random mRand = new Random();
		protected bool mDirectHit = false;
		protected bool mSplash = false;
		protected int mImprecision = 0;
		protected int mDmg = 0;
		protected int mSplashDmg = 0;
		protected int mSplashRange = 0;
		protected float mDistToMove;
		protected float mMoveLength;
		protected EUnitDamageType mDmgType;
		protected float mCalcMoveTimer;
		protected float mCalcMoveInterval = 100;

		protected bool mAdditive = false;
		protected Color mColor = Color.White;
		protected string mMissAnimation, mHitAnimation;
		protected float mScale = 1.0f;
		protected int mWidth, mHeight;

		protected bool mPlaySound = true;
		protected string mHitSound;

		protected Texture2D texProjectile;

		public Rectangle Area {
			get { return new Rectangle( (int)mPosition.X, (int)mPosition.Y, mWidth, mHeight ); }
		}

		public Texture2D Texture {
			get { return texProjectile; }
		}

		public bool Active {
			get { return mActive; }
		}

		public Vector2 Position {
			get { return mPosition; }
			set { mPosition = value; }
		}

		public float Angle {
			get { return mAngle; }
		}

		public bool Additive {
			get { return mAdditive; }
		}

		public Color Color {
			get { return mColor; }
		}

		public bool PlaySound {
			get { return mPlaySound; }
			set { mPlaySound = value; }
		}

		public Rectangle TargetArea {
			get { return mTargetArea; }
		}


		public Projectile( DefenderWorld world, Vector2 position, Unit target, int dmg, float speed, int imprecision ) {
			mWorld = world;
			mTarget = target;
			mPosition = position;
			mDmg = dmg;
			mSpeed = speed;
			mImprecision = imprecision;
			texProjectile = world.texArrow;
		}


		public void SetPlaySound( Rectangle camArea ) {
			mPlaySound = ( camArea.Intersects( mTargetArea ) );
		}

		protected void SetupProjectile() {
			mWidth = (int)( texProjectile.Width * mScale );
			mHeight = (int)( texProjectile.Height * mScale );
			mTargetArea = mTarget.Rectangle;
		}

		public virtual void UpdateProjectile() {
			if( HitTarget() ) {
				if( mSplash )
					ApplySplashDamage();
				else
					ApplySingleDamage();

				if( mHitSound != null && mPlaySound )
					mWorld.PlaySound( mHitSound, mTarget.Position );

				mActive = false;
			} else if( Overshot() ) {
				mPosition = mTargetPos;
				if( mSplash )
					ApplySplashDamage();
				else
					ApplySingleDamage();

				if( mHitSound != null && mPlaySound )
					mWorld.PlaySound( mHitSound, mTarget.Position );

				mActive = false;
			} else {
				Move();
			}
		}

		protected bool HitTarget() {
			if( Area.Intersects( mTarget.Rectangle ) ) {
				mDirectHit = true;
				return true;
			}
			if( !mHoming && Area.Intersects( mTargetArea ) )
				return true;

			return false;
		}

		protected virtual void ApplySingleDamage() {
			if( mDirectHit ) {
				mTarget.Damage( mDmg, mDmgType );
				PlayHitAnimation();
			} else {
				foreach( Unit u in mWorld.Waves.GetUnits() ) {
					if( Area.Intersects( u.Rectangle ) ) {
						mDirectHit = true;
						u.Damage( mDmg, mDmgType );
						PlayHitAnimation();
						break;
					}
				}
			}

			if( !mDirectHit )
				PlayMissAnimation();
		}

		protected virtual void ApplySplashDamage() {
			Rectangle splashArea = new Rectangle( Area.X - mSplashRange / 2, Area.Y - mSplashRange / 2, mSplashRange, mSplashRange );

			if( Area.Intersects( mTarget.Rectangle ) )
				mTarget.Damage( mDmg, mDmgType );

			foreach( Unit u in mWorld.Waves.GetUnits() ) {
				if( splashArea.Intersects( u.Rectangle ) )
					u.Damage( mSplashDmg, mDmgType );
			}
			PlayHitAnimation();
		}


		protected virtual void PlayHitAnimation() {
			mWorld.CreateAnimation( mHitAnimation, mPosition, 1.0f, mAngle, 100.0f );
		}


		protected virtual void PlayMissAnimation() {
			mWorld.CreateAnimation( mMissAnimation, mPosition, 1.0f, mAngle, 100.0f );
		}

		protected virtual void PlayNonEffectiveHitAnnimation() {
			PlayMissAnimation();
			mWorld.PlaySound( "Sword Hit 04", mTarget.Position );
		}


		protected bool IsInSRange( Unit target ) {
			if( ( Math.Sqrt( Math.Pow( target.Position.X - mPosition.X, 2 ) + Math.Pow( target.Position.Y - mPosition.Y, 2 ) ) ) < mSplashRange )
				return true;

			return false;
		}

		protected void CalculateMovement() {
			Vector2 toMove;
			float maxValue;

			mTargetPos = mTarget.Center;

			if( !mHoming && mImprecision > 0 ) {

				mTargetPos.X += mRand.Next( -mImprecision, mImprecision );
				mTargetPos.Y += mRand.Next( -mImprecision, mImprecision );
				mTargetArea = mTarget.Rectangle;
			}

			toMove = mTargetPos - mPosition;

			maxValue = Math.Max( Math.Abs( toMove.X ), Math.Abs( toMove.Y ) );
			mMovement = ( toMove / maxValue );

			mAngle = CalculateAngle( toMove );

			if( !mHoming && mAcceleration == 0 ) {
				Vector2 aMove = mMovement * mSpeed;
				mMoveLength = aMove.Length();
				mDistToMove = toMove.Length();
			}
		}

		protected float CalculateAngle( Vector2 toMove ) {
			if( mTarget.Center.X == mPosition.X ) {
				if( mTarget.Center.Y < mPosition.Y )
					return MathHelper.PiOver2;
				else
					return -MathHelper.PiOver2;
			} else if( mTarget.Center.Y == mPosition.Y ) {
				if( mTarget.Center.X > mPosition.Y )
					return 0;
				else
					return MathHelper.Pi;
			} else if( mTarget.Center.X < mPosition.X )
				return (float)( Math.Atan( toMove.Y / toMove.X ) + Math.PI );
			else
				return (float)( Math.Atan( toMove.Y / toMove.X ) );
		}

		protected bool Overshot() {
			if( !mHoming && mAcceleration == 0 ) {
				if( mDistToMove <= 0 )
					return true;
				return false;
			}

			Vector2 distTT = mTargetPos - mPosition;
			if( Math.Abs( distTT.X ) <= Math.Abs( mMovement.X * mSpeed ) && Math.Abs( distTT.Y ) <= Math.Abs( mMovement.Y * mSpeed ) )
				return true;
			return false;
		}

		protected virtual void Move() {
			Vector2 nextMove;
			AdjustSpeed();

			mCalcMoveTimer += 16;
			if( mHoming && mCalcMoveTimer > mCalcMoveInterval ) {
				CalculateMovement();
				mCalcMoveTimer = 0f;
			}

			nextMove = mMovement * mSpeed;
			mPosition += nextMove;

			if( !mHoming && mAcceleration == 0 )
				mDistToMove -= mMoveLength;
		}

		protected void AdjustSpeed() {
			if( mAcceleration > 0 )
				mSpeed += mAcceleration;

			if( mSpeed < mMinSpeed )
				mSpeed = mMinSpeed;
			else if( mSpeed > mMaxSpeed ) {
				mAcceleration = 0;
				mSpeed = mMaxSpeed;
			}
		}

	}

}
