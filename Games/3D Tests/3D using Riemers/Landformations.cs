using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Engine3DFromRiemersTutorial {

	abstract public class Landform : ILandformation {
		virtual public void Initialise( ref IHeightMap heightMap ) {
			Point p = Point.Zero;
			for( int x = 0; x < heightMap.Width; x++ )
				for( int y = 0; y < heightMap.Height; y++ ) {
					p.X = x;
					p.Y = y;
					heightMap[ x, y ] = GetHeight( p, heightMap[ x, y ] );
				}
		}

		abstract protected float GetHeight( Point p, float oldValue );

	}

	public class LandformVolcano : Landform {
		readonly Point mCenter;
		readonly float mRadiusOuter, mRadiusInner;
		readonly float mHeightOuter, mHeightInner;
		readonly float mHeightCenter;
		Random mRnd = new Random();
		float mMaxTurb;

		public LandformVolcano( Point center, float heightInner, float radiusOuter, float heightOuter, float radiusInner, float heightCenter ) {
			if( radiusOuter < radiusInner )
				Debug.WriteLine( string.Format( "Outer radius ({0}) must be bigger than inner ({1})", radiusOuter, radiusInner ) );
			
			mCenter = center;
			mHeightOuter = heightOuter;
			mRadiusOuter = radiusOuter;
			mHeightInner = heightInner;
			mRadiusInner = radiusInner;
			mHeightCenter = heightCenter;
			mMaxTurb = (float)Math.Sqrt( mRadiusOuter * mRadiusOuter + mHeightInner * mHeightInner ) / 20.0f;
		}

		public LandformVolcano( Point center, float heightRim, float radiusOuter )
			: this( center, heightRim, radiusOuter, 0f, radiusOuter * 0.05f, heightRim * 0.9f ) {
		}

		protected override float GetHeight( Point p, float oldValue ) {
			float distanceFromCenter = p.DistanceTo( mCenter );
			bool inInnerCircle = distanceFromCenter <= mRadiusInner;
			bool inOuterCircle = !inInnerCircle && ( distanceFromCenter < mRadiusOuter );
			float newH = oldValue;
			if( inOuterCircle )
				newH = MathHelper.Lerp( mHeightInner, mHeightOuter, ( distanceFromCenter - mRadiusInner ) / mRadiusOuter );
			else if( inInnerCircle )
				newH = MathHelper.Lerp( mHeightCenter, mHeightInner, distanceFromCenter / mRadiusInner );
			else
				return oldValue;
			float fracToCenter = ( mRadiusOuter - distanceFromCenter ) / mRadiusOuter;
			float turb = MathHelper.Lerp( 0, (float)( mRnd.NextDouble() * mMaxTurb ) - mMaxTurb / 2.0f, 1.0f - fracToCenter );
			return MathHelper.Lerp( oldValue, turb + newH, fracToCenter );
		}

	}


	public class LandformCrater : Landform {
		readonly Point mCenter;
		readonly float mRadiusOuter, mRadiusRim;
		float mHeightOuter, mHeightRim, mHeightCenter;
		Random mRandom = new Random();

		public LandformCrater( Point center, float radiusOuter, float radiusRim ) {
			mCenter = center;
			mRadiusOuter = radiusOuter;
			mRadiusRim = radiusRim;
		}

		public LandformCrater( Point center, float radiusOuter )
			: this( center, radiusOuter, radiusOuter * 0.7f ) {
		}

		public override void Initialise( ref IHeightMap heightMap ) {
			mHeightCenter = heightMap[ mCenter.X, mCenter.Y ] - mRadiusRim;
			float maxH = float.MinValue;
			float minH = float.MinValue;
			for( int x = 0; x < heightMap.Width; x++ )
				for( int y = 0; y < heightMap.Height; y++ ) {
					float distanceFromCenter = new Point( x, y ).DistanceTo( mCenter );
					bool inInnerCircle = distanceFromCenter <= mRadiusRim;
					bool inOuterCircle = !inInnerCircle && ( distanceFromCenter < mRadiusOuter );
					if( inOuterCircle && heightMap[ x, y ] > maxH )
						maxH = heightMap[ x, y ];
					if( inOuterCircle && heightMap[ x, y ] < minH )
						minH = heightMap[ x, y ];

				}
			mHeightRim = maxH + mRadiusOuter * 0.10f;
			mHeightOuter = ( maxH - minH ) / 2.0f;

			base.Initialise( ref heightMap );
		}



		protected override float GetHeight( Point p, float oldValue ) {
			float distanceFromCenter = p.DistanceTo( mCenter );
			bool inInnerCircle = distanceFromCenter <= mRadiusRim;
			bool inOuterCircle = !inInnerCircle && ( distanceFromCenter < mRadiusOuter );
			float newH = oldValue;
			float hr = oldValue + mRadiusOuter * 0.10f;
			float ho = Math.Min( mHeightOuter, oldValue );

			if( inOuterCircle ) {
				var fracOfOuter = ( mRadiusRim - distanceFromCenter ) / ( mRadiusRim - mRadiusOuter );
				return MathHelper.Lerp( hr, oldValue, fracOfOuter );

			} else if( inInnerCircle )
				return MathHelper.Lerp( mHeightCenter, ho, distanceFromCenter / mRadiusRim );

			return oldValue;
		}

	}

}
