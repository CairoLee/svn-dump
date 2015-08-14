using System;
using Microsoft.Xna.Framework;

namespace FinalSoftware.Games.Defender.Library.Map {

	public class Path {
		private int mX, mY, mWidth, mHeight, mQuadrant, mTileSize;
		private float mAngle;
		private float mLeftBound, mRightBound, mBottomBound1, mBottomBound2, mTopBound1, mTopBound2;
		private float mVHeight;


		public Vector4 Bounds {
			get { return new Vector4( mLeftBound, mRightBound, mBottomBound1, mTopBound1 ); }
		}

		public Vector2 Bounds2 {
			get { return new Vector2( mBottomBound2, mTopBound2 ); }
		}

		public float VHeight {
			get { return mVHeight; }
		}

		public float Height {
			get { return (float)mHeight; }
		}

		public int Quadrant {
			get { return mQuadrant; }
		}

		public float Angle {
			get { return mAngle; }
		}


		public Rectangle Rectangle {
			get { return new Rectangle( mX, mY, mWidth, mHeight ); }
		}

		public Vector2 Position {
			get { return new Vector2( mX, mY ); }
			set {
				mX = (int)value.X;
				mY = (int)value.Y;
			}
		}


		public Path( int x, int y, int width, int height, float angle, int quadrant, float lBound, float rBound,
			float bBound1, float tBound1, float vHeight, int tileSize ) {
			mX = x;
			mY = y;
			mWidth = width;
			mHeight = height;
			mAngle = angle;
			mQuadrant = quadrant;
			mTileSize = tileSize;

			mLeftBound = lBound;
			mRightBound = rBound;
			mBottomBound1 = bBound1;
			mTopBound1 = tBound1;
			mVHeight = vHeight;
		}


		public bool Intersects( Rectangle target, int increment ) {
			bool intersects = false;

			intersects |= IntersectsPT( target.X + 1, target.Y + 1 );
			intersects |= IntersectsPT( target.Right - 1, target.Y + 1 );
			intersects |= IntersectsPT( target.Right - 1, target.Bottom - 1 );
			intersects |= IntersectsPT( target.X + 1, target.Bottom - 1 );
			if( intersects == true )
				return true;

			for( int i = target.X + mTileSize; i < target.Right; i += mTileSize )
				for( int j = target.Y + mTileSize; j < target.Bottom; j += mTileSize ) {
					intersects |= IntersectsPT( i, j );
					if( intersects == true )
						return true;
				}

			return intersects;
		}


		private bool IntersectsPT( int tX, int tY ) {
			if( mVHeight == 0 ) {
				if( tX > mLeftBound && tX < mRightBound && tY > mTopBound1 && tY < mBottomBound1 )
					return true;
			} else if( mQuadrant == 1 || mQuadrant == 4 ) {
				mTopBound2 = (float)( mY + ( tX - mX ) * Math.Tan( mAngle ) );
				mBottomBound2 = (float)( mTopBound2 + mVHeight );
			} else if( mQuadrant == 2 ) {
				mBottomBound2 = (float)( mY - ( mX - tX ) * Math.Tan( mAngle ) );
				mTopBound2 = (float)( mBottomBound2 + mVHeight );
			} else if( mQuadrant == 3 ) {
				mBottomBound2 = (float)( mY - ( mX - tX ) * Math.Tan( mAngle ) );
				mTopBound2 = (float)( mBottomBound2 - mVHeight );
			}


			if( tX > mLeftBound && tX < mRightBound && tY > mTopBound1 && tY < mBottomBound1 &&
				tY > mTopBound2 && tY < mBottomBound2 )
				return true;

			return false;
		}

	}

}
