using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.Diagnostics;


namespace Engine3DFromRiemersTutorial {

	public interface IHeightMap {
		float this[ int x, int y ] { get; set; }
		int Width { get; }
		int Length { get; }
		int Height { get; }
		void Initialise();

	}

	public interface ILandformation {
		/// <summary>
		/// Build the landformation on the heightMap
		/// </summary>
		/// <param name="heightMap"></param>
		void Initialise( ref IHeightMap heightMap );
	}


	delegate float Mapper( Point p );

	public class HeightMap : IHeightMap {
		protected float[] mHeightMap;
		protected int mWidth, mLength;
		public List<ILandformation> Landformations = new List<ILandformation>();

		protected Vector2 Center() {
			return new Vector2( (float)( mWidth - 1 ) / 2.0f, (float)( mLength - 1 ) / 2.0f );
		}

		public int Length {
			get { return mLength; }
		}

		public int Height {
			get { return mLength; }
		}

		public int Width {
			get { return mWidth; }
		}

		public float this[ int x, int y ] {
			get { return mHeightMap[ x + y * mWidth ]; }
			set { mHeightMap[ x + y * mWidth ] = value; }
		}

		protected void LoadHeightData( Texture2D heightMap, float magnify ) {
			float minimumHeight = float.MaxValue;
			float maximumHeight = float.MinValue;

			mWidth = heightMap.Width;
			mLength = heightMap.Height;

			Color[] heightMapColors = new Color[ mWidth * mLength ];
			heightMap.GetData( heightMapColors );

			mHeightMap = new float[ mWidth * mLength ];
			for( int x = 0; x < mWidth; x++ )
				for( int y = 0; y < mLength; y++ ) {
					mHeightMap[ x + y * mWidth ] = heightMapColors[ x + y * mWidth ].R;
					if( mHeightMap[ x + y * mWidth ] < minimumHeight )
						minimumHeight = mHeightMap[ x + y * mWidth ];
					if( mHeightMap[ x + y * mWidth ] > maximumHeight )
						maximumHeight = mHeightMap[ x + y * mWidth ];
				}

			// normalise height data to be between 0 and 30.0f
			for( int x = 0; x < mWidth; x++ )
				for( int y = 0; y < mLength; y++ )
					mHeightMap[ x + y * mWidth ] = ( mHeightMap[ x + y * mWidth ] - minimumHeight ) / ( maximumHeight - minimumHeight ) * magnify;
		}

		void Map( Mapper f ) {
			Point p = Point.Zero;
			for( int x = 0; x < mWidth; x++ )
				for( int y = 0; y < mLength; y++ ) {
					p.X = x;
					p.Y = y;
					mHeightMap[ x + y * mWidth ] = f( p );
				}
		}

		protected List<Point> NeighboursOf( Point p ) {
			List<Point> result = new List<Point>();
			if( p.X > 0 ) {
				result.Add( new Point( p.X - 1, p.Y ) );
				if( p.Y > 0 )
					result.Add( new Point( p.X - 1, p.Y - 1 ) );
				if( p.Y < mLength - 1 )
					result.Add( new Point( p.X - 1, p.Y + 1 ) );
			}
			if( p.X < mWidth - 1 ) {
				result.Add( new Point( p.X + 1, p.Y ) );
				if( p.Y > 0 )
					result.Add( new Point( p.X + 1, p.Y - 1 ) );
				if( p.Y < mLength - 1 )
					result.Add( new Point( p.X + 1, p.Y + 1 ) );
			}
			if( p.Y > 0 )
				result.Add( new Point( p.X, p.Y - 1 ) );
			if( p.Y < mLength - 1 )
				result.Add( new Point( p.X, p.Y + 1 ) );
			return result;
		}

		protected Vector3 GetPosition( int x, int y ) {
			return new Vector3( x, mHeightMap[ x + y * mWidth ], -y );
		}

		protected Vector3 GetNormal( Point p ) {
			if( p.X == mWidth - 1 || p.Y == mLength - 1 )
				return new Vector3( 0, 1, 0 );
			Vector3 side1 = GetPosition( p.X + 1, p.Y );
			Vector3 side2 = GetPosition( p.X, p.Y + 1 );
			Vector3 r = Vector3.Cross( side1, side2 );
			r.Normalize();
			return r;
		}


		public virtual void Initialise() {
			IHeightMap hm = this;

			foreach( var form in Landformations )
				form.Initialise( ref hm );
			Landformations = null;
		}

	}

	public enum IslandShape {
		Circle,
		Square
	};

	/// <summary>
	/// Determines how the beach is formed
	/// </summary>
	public enum IslandTrimMethod {
		/// <summary>
		/// Ground is filled in to construct a beach according to specification
		/// </summary>
		Fill,
		/// <summary>
		/// Towards the land, original land form persists
		/// </summary>
		Merge,
		/// <summary>
		/// Dig a path at touching waterlevel
		/// </summary>
		/// <remarks>
		/// To see water here, make the water level slightly lower than it actually is
		/// </remarks>
		Ditch
	};
	/// <summary>
	/// Modifies the edges of the terrain to form a beach around the terrain
	/// </summary>
	public class HeightMapIslandTrim : HeightMap {
		private IHeightMap mSource;
		readonly float mShoreLength;
		readonly float mWaterLevel;
		readonly float mShoreHeight;
		readonly IslandShape mType;
		readonly IslandTrimMethod mMethod;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="source"></param>
		/// <param name="shoreLength">the distance from the start of the beach to the water</param>
		/// <param name="waterLevel"></param>
		/// <param name="shoreHeight">the height as measured from the water level</param>
		/// <param name="type"></param>
		/// <param name="method"></param>
		public HeightMapIslandTrim( IHeightMap source, float shoreLength, float waterLevel, float shoreHeight, IslandShape type, IslandTrimMethod method ) {
			mSource = source;
			mWaterLevel = waterLevel;
			mShoreHeight = shoreHeight;
			mShoreLength = shoreLength;
			mType = type;
			mMethod = method;
		}

		private float DistanceFromEdge( int x, int y ) {
			float xd = ( x < mWidth / 2 ) ? x : ( mWidth - 1 - x );
			float yd = ( y < mLength / 2 ) ? y : ( mLength - 1 - y );
			return Math.Min( xd, yd );
		}

		private void SetHeight( int x, int y ) {
			Vector2 pos = new Vector2( x, y );
			float shore;
			if( mType == IslandShape.Square )
				shore = mShoreLength - DistanceFromEdge( x, y );
			else {
				float distanceFromCenter = Vector2.Distance( Center(), pos );
				float landRadius = ( (float)mWidth / 2.0f ) - mShoreLength;
				shore = distanceFromCenter - landRadius;
			}
			var oldH = mSource[ x, y ];
			var newH = MathHelper.Lerp( mWaterLevel + mShoreHeight, mWaterLevel - mShoreHeight, shore / ( mShoreLength * 2.0f ) );
			if( shore < 0.0f )
				mHeightMap[ x + y * mWidth ] = oldH;
			else {
				switch( mMethod ) {
					case IslandTrimMethod.Fill:
						mHeightMap[ x + y * mWidth ] = newH;
						break;
					case IslandTrimMethod.Merge:
						mHeightMap[ x + y * mWidth ] = MathHelper.Lerp( oldH, newH, ( shore / mShoreLength ) );
						break;
					case IslandTrimMethod.Ditch:
						var sd = shore / 2.0f - mShoreLength / 2.0f;
						if( sd < 0.0f ) // land side
							mHeightMap[ x + y * mWidth ] = MathHelper.Lerp( oldH, newH, ( shore / mShoreLength ) );
						else  // water side
							mHeightMap[ x + y * mWidth ] = MathHelper.Lerp( newH, oldH, ( sd / mShoreLength / 2.0f ) );
						break;
				}
			}

		}

		public override void Initialise() {
			mSource.Initialise();
			mWidth = mSource.Width;
			mLength = mSource.Length;
			mHeightMap = new float[ mWidth * mLength ];
			for( int x = 0; x < mWidth; x++ )
				for( int y = 0; y < mLength; y++ )
					SetHeight( x, y );
			// release to allow collection via GC
			mSource = null;
			base.Initialise();
		}
	}


	/// <summary>
	/// Creates a 2x2 mirror of a given heightmap.  
	/// Mirrors toward the south and toward the east
	/// </summary>
	public class HeightMapMirror : HeightMap {
		private IHeightMap mSource;

		/// <summary>
		/// The source is used once and then discarded
		/// </summary>
		/// <param name="source"></param>
		public HeightMapMirror( IHeightMap source ) {
			mSource = source;
		}

		public override void Initialise() {
			mSource.Initialise();
			mWidth = mSource.Width * 2;
			mLength = mSource.Length * 2;
			mHeightMap = new float[ mWidth * mLength ];
			for( int x = 0; x < mWidth; x++ )
				for( int y = 0; y < mLength; y++ ) {
					int sx = x < mSource.Width ? x : ( mWidth - 1 - x );
					int sy = y < mSource.Length ? y : ( mLength - 1 - y );
					mHeightMap[ x + y * mWidth ] = mSource[ sx, sy ];
				}
			// release reference to source so that it can be collect by GC
			mSource = null;
			base.Initialise();
		}

	}


	public class HeightMapPerlin : HeightMap {
		readonly float mMinimumHeight = 0.0f;
		readonly float mMaximumHeight = 30.0f;
		readonly int mSeed;
		readonly float mPersistence;
		readonly int mOctaves;


		private Game mGame;

		public HeightMapPerlin( Game g, int width, int length, float minHeight, float maxHeight, int seed, float persistence, int octaves ) {
			mWidth = width;
			mLength = length;
			mGame = g;
			mSeed = seed;
			mPersistence = persistence;
			mOctaves = octaves;
			mMinimumHeight = minHeight;
			mMaximumHeight = maxHeight;
		}

		/// <summary>
		/// Normalize the heightmap.
		/// </summary>
		void Normalise() {
			float min = float.MaxValue;
			float max = float.MinValue;

			// Get the lowest and the highest values.
			for( int x = 0; x < mWidth; ++x ) {
				for( int y = 0; y < mLength; ++y ) {
					if( mHeightMap[ x + y * mWidth ] > max ) {
						max = mHeightMap[ x + y * mWidth ];
					}

					if( mHeightMap[ x + y * mWidth ] < min ) {
						min = mHeightMap[ x + y * mWidth ];
					}
				}
			}

			// If the heightmap is flat, we set it to the average
			if( max <= min ) {
				for( int x = 0; x < mWidth; ++x ) {
					for( int y = 0; y < mLength; ++y ) {
						mHeightMap[ x + y * mWidth ] = ( mMaximumHeight - mMinimumHeight ) * 0.5f;
					}
				}

				return;
			}

			// Normalize the value between 0.0 and 1.0 then scale it between _minimumHeight and _maximumHeight.
			float diff = max - min;
			float scale = mMaximumHeight - mMinimumHeight;

			for( int x = 0; x < mWidth; ++x ) {
				for( int y = 0; y < mLength; ++y ) {
					mHeightMap[ x + y * mWidth ] = ( mHeightMap[ x + y * mWidth ] - min ) / diff * scale + mMinimumHeight;
				}
			}
		}


		private float Noise( int i ) {
			i = ( i << 13 ) ^ i;
			return ( 1.0f - ( ( i * ( i * i * 15731 + 789221 ) + 1376312589 ) & 0x7FFFFFFF ) / 1073741824.0f );
		}

		public void CreateNoise() {
			int txi, tzi;

			float freq, amp;

			float xf, tx, fracx;
			float zf, tz, fracz;

			float v1, v2, v3, v4;
			float i1, i2, total;


			// For each height..
			for( int z = 0; z < mLength; ++z ) {
				for( int x = 0; x < mWidth; ++x ) {
					// Scale x and y to the range of 0.0f, 1.0f.
					xf = (float)x / (float)mWidth;
					zf = (float)z / (float)mLength;

					total = 0.0f;

					// For each octaves..
					for( int i = 0; i < mOctaves; ++i ) {
						// Calculate frequency and amplitude (different for each octave).
						freq = (float)Math.Pow( 2.0, i );
						amp = (float)Math.Pow( mPersistence, i );

						// Calculate the x, z noise coodinates.
						tx = xf * freq;
						tz = zf * freq;

						txi = (int)tx;
						tzi = (int)tz;

						// Calculate the fractions of x and z.
						fracx = tx - txi;
						fracz = tz - tzi;

						// Get noise per octave for these four points.
						v1 = Noise( txi + tzi * 57 + mSeed );
						v2 = Noise( txi + 1 + tzi * 57 + mSeed );
						v3 = Noise( txi + ( tzi + 1 ) * 57 + mSeed );
						v4 = Noise( txi + 1 + ( tzi + 1 ) * 57 + mSeed );

						// Smooth noise in the x axis.
						i1 = MathHelper.SmoothStep( v1, v2, fracx );
						i2 = MathHelper.SmoothStep( v3, v4, fracx );

						// Smooth in the z axis.
						total += MathHelper.SmoothStep( i1, i2, fracz ) * amp;
					}

					// Save to heightmap.
					mHeightMap[ x + z * mWidth ] = total;
				}
			}


		}

		public override void Initialise() {
			mHeightMap = new float[ mWidth * mLength ];
			CreateNoise();
			Normalise();
			base.Initialise();
		}

	}



}