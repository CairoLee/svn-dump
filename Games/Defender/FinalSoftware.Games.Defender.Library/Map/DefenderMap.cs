using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;

namespace FinalSoftware.Games.Defender.Library.Map {

	public class DefenderMap {
		private int mWidth = 2048;
		private int mHeight = 2048;
		private int mLargestIndex = 0;
		private CrossroadList mCrossroads;
		private ECollisionType[ , ] mCollisionLayer;
		private bool[ , ] mTowerLayer;

		private Texture2D mCollisionTex;
		private byte[] mCollisionTexData = null;

		public int Width {
			get { return mWidth; }
			set { mWidth = value; }
		}

		public int Height {
			get { return mHeight; }
			set { mHeight = value; }
		}

		public CrossroadList Crossroads {
			get { return mCrossroads; }
			set { mCrossroads = value; }
		}

		[XmlElement( ElementName = "CollisionTexture" )]
		public byte[] CollisionTextureSerialize {
			get { return GetCollisionTextureData(); }
			set { mCollisionTexData = value; }
		}

		public Rectangle Bounds {
			get { return new Rectangle( 0, 0, Width, Height ); }
		}

		public ECollisionType this[ int x, int y ] {
			get { return GetCell( x, y ); }
		}

		public Texture2D CollisionTex {
			get { return GetCollisionTexture(); }
		}


		public DefenderMap() {
			mCrossroads = new CrossroadList();
			mWidth = mHeight = 0;
			mLargestIndex = 0;
			mCollisionLayer = new ECollisionType[ mWidth, mHeight ];
			mTowerLayer = new bool[ mWidth, mHeight ];
		}

		public DefenderMap( Texture2D Texture ) {
			mCrossroads = new CrossroadList();

			mCollisionTex = Texture;
			mWidth = mCollisionTex.Width;
			mHeight = mCollisionTex.Height;
			mCollisionLayer = new ECollisionType[ mWidth, mHeight ];
			mTowerLayer = new bool[ mWidth, mHeight ];

			mLargestIndex = ( Width - 1 ) + ( ( Height - 1 ) * Width );

			BuildCollisionLayer();
		}


		public ECollisionType GetCell( int x, int y ) {
			if( IsValid( x, y ) == false )
				return ECollisionType.NonWalkable;
			return mCollisionLayer[ x, y ];
		}

		public ECollisionType GetCell( Point Point ) {
			return GetCell( Point.X, Point.Y );
		}


		public void AddTower( Rectangle Area ) {
			for( int x = Area.X; x < Area.Right; x++ )
				for( int y = Area.Y; y < Area.Bottom; y++ )
					if( IsValid( x, y ) )
						mTowerLayer[ x, y ] = true;
		}

		public void RemoveTower( Rectangle Area ) {
			for( int x = Area.X; x < Area.Right; x++ )
				for( int y = Area.Y; y < Area.Bottom; y++ )
					if( IsValid( x, y ) )
						mTowerLayer[ x, y ] = false;
		}


		public bool IsBuildable( Rectangle Area ) {
			for( int x = Area.X; x < Area.Right; x++ )
				for( int y = Area.Y; y < Area.Bottom; y++ )
					if( !IsValid( x, y ) || mCollisionLayer[ x, y ] == ECollisionType.NonWalkable || mTowerLayer[ x, y ] == true )
						return false;
			return true;
		}

		public bool IsWalkable( Rectangle Area ) {
			for( int x = Area.X; x < Area.Right; x++ )
				for( int y = Area.Y; y < Area.Bottom; y++ )
					if( !IsValid( x, y ) || mCollisionLayer[ x, y ] == ECollisionType.NonWalkable )
						return false;
			return true;
		}



		public bool IsValid( int x, int y ) {
			return ( x >= 0 && x < Width && y >= 0 && y < Height );
		}

		public bool IsValid( Point Point ) {
			return IsValid( Point.X, Point.Y );
		}


		public int GetIndex( int x, int y ) {
			if( IsValid( x, y ) == false )
				return -1;
			return x + ( y * mWidth );
		}

		public bool GetCoords( int i, out int x, out int y ) {
			x = y = 0;
			if( i > mLargestIndex )
				return false;
			if( i == 0 )
				return true;

			y = i / Width;
			x = ( i % Width );
			return true;
		}



		private void BuildCollisionLayer() {
			int x = 0, y = 0;
			Color[] data = new Color[ mCollisionTex.Width * mCollisionTex.Height ];
			mCollisionTex.GetData<Color>( data, 0, data.Length );

			for( int i = 0; i < data.Length; i++ ) {
				if( GetCoords( i, out x, out y ) == false )
					throw new Exception( "failed to load coordinates for index " + i );
				mCollisionLayer[ x, y ] = ( data[ i ] == Color.White ? ECollisionType.NonWalkable : ECollisionType.Walkable );
			}

		}


		#region CollisionTexture building
		private Texture2D GetCollisionTexture() {
			if( mCollisionTex != null )
				return mCollisionTex;
			if( mCollisionTexData == null )
				throw new Exception( "CollisionTexData is null, can not build CollisionTexture" );

			Color[] data = new Color[ mCollisionTexData.Length ];
			for( int i = 0; i < mCollisionTexData.Length; i++ )
				data[ i ] = ( mCollisionTexData[ i ] == 0 ? Color.White : Color.Black );

			mCollisionTex = new Texture2D( DefenderWorld.Instance.Game.GraphicsDevice, Width, Height );
			mCollisionTex.SetData<Color>( data );
			return mCollisionTex;
		}

		private byte[] GetCollisionTextureData() {
			Color[] colorData = new Color[ Width * Height ];
			byte[] data = new byte[ colorData.Length ];
			mCollisionTex.GetData<Color>( colorData, 0, colorData.Length );
			for( int i = 0; i < colorData.Length; i++ )
				data[ i ] = (byte)( colorData[ i ] == Color.White ? 0 : 1 );

			return data;
		}
		#endregion

	}

}
