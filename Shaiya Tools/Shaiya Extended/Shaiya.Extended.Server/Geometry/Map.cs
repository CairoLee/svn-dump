using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shaiya.Extended.Server.Objects;
using Shaiya.Extended.Library.Geometry;

namespace Shaiya.Extended.Server.Geometry {

	[Flags()]
	public enum CollisionType {
		Moveable = 1,
		NotMoveable = 2,
		Clifable = 4,
		Water = 8,
		Underwater = 16,
	}

	public class MapTile {
		private SerialObjectManager mUnits = new SerialObjectManager();
		private Map mMap = null;
		private CollisionType mFlag = CollisionType.NotMoveable;
		private EventTile mEvent = new EventTile();


		public SerialObject this[ ESerialType Type, int Serial ] {
			get { return mUnits[ Type ][ Serial ]; }
		}

		public SerialObjectManager Units {
			get { return mUnits; }
		}

		public Map ParentMap {
			get { return mMap; }
		}

		public CollisionType Flag {
			get { return mFlag; }
			set { mFlag = value; }
		}

		public EventTile Event {
			get { return mEvent; }
			set { mEvent = value; }
		}



		public MapTile() {
		}

		public MapTile( Map Map ) {
			mMap = Map;
		}

		public MapTile( Map Map, CollisionType Flag ) {
			mMap = Map;
			mFlag = Flag;
		}

		public MapTile( Map Map, CollisionType Flag, EventTile Event ) {
			mMap = Map;
			mFlag = Flag;
			mEvent = Event;
		}



		public void AddUnit( SerialObject Unit ) {
			mUnits.Add( Unit );
			if( mEvent.HasEvent() )
				mEvent.OnEnter( Unit );
		}

		public void DelUnit( SerialObject Unit ) {
			if( mEvent.HasEvent() )
				mEvent.OnLeave( Unit );
			mUnits.Remove( Unit );
		}

	}


	public class Map : SerialObject, IMap {
		private string mName;
		private int mWidth;
		private int mHeight;
		private MapTile[ , ] mMapTiles;
		private SerialObjectManager mObjects;
		private bool mIsChanged = false;


		public bool IsChanged {
			get { return mIsChanged; }
			set { mIsChanged = value; }
		}

		public SerialObjectManager Objects {
			get { return mObjects; }
		}

		public MapTile this[ Point2D p ] {
			get { return GetMapTile( p ); }
		}

		public MapTile this[ Point3D p ] {
			get { return GetMapTile( p ); }
		}

		public MapTile this[ int X, int Y ] {
			get { return GetMapTile( X, Y ); }
		}

		public int Width {
			get { return mWidth; }
		}

		public int Height {
			get { return mHeight; }
		}



		public Map() {
		}




		public void OnEnter( SerialObject obj ) {
			Add( obj );
		}

		public void OnLeave( SerialObject obj ) {
			Remove( obj );
		}

		public void OnMove( SerialObject obj, Point3D OldLocation ) {
			Move( obj, OldLocation );
		}



		private void Add( SerialObject obj ) {
			this[ obj.Location.X, obj.Location.Y ].AddUnit( obj );
			obj.Map = this;
		}

		private void Remove( SerialObject obj ) {
			this[ obj.Location.X, obj.Location.Y ].DelUnit( obj );
			obj.Map = null;
		}

		private void Move( SerialObject obj, Point3D OldLocation ) {
			this[ OldLocation ].DelUnit( obj );
			this[ obj.Location.X, obj.Location.Y ].AddUnit( obj );
		}

		private void Replace( SerialObject oldObj, SerialObject newObj ) {
			this[ oldObj.Location.X, oldObj.Location.Y ].Units.Replace( oldObj, newObj );
			oldObj.Map = null;
			newObj.Map = this;
		}

		#region GetMapTile
		public MapTile GetMapTile( Point3D p ) {
			if( p.CompareTo( this ) == false )
				return null;

			return GetMapTile( p.X, p.Y );
		}

		public MapTile GetMapTile( Point2D p ) {
			if( p.CompareTo( this ) == false )
				return null;

			return GetMapTile( p.X, p.Y );
		}

		public MapTile GetMapTile( int X, int Y ) {
			if( mMapTiles == null || X < 0 || X >= mWidth || Y < 0 || Y >= mHeight )
				return null;

			return mMapTiles[ X, Y ];
		}
		#endregion

		#region CheckTile
		public static bool CheckTile( Map m, int X, int Y, CollisionType flag ) {
			return ( m[ X, Y ].Flag & flag ) == flag;
		}

		public static bool CheckTile( Map m, Point2D p, CollisionType flag ) {
			return CheckTile( m, p.X, p.Y, flag );
		}

		public static bool CheckTile( Map m, Point3D p, CollisionType flag ) {
			return CheckTile( m, p.X, p.Y, flag );
		}
		#endregion

		public int PlayersInRange( Point2D Start, int Range ) {
			int count = 0;
			MapTile tile;
			for( int x = Start.X - Range; x <= Start.X + Range; ++x )
				for( int y = Start.Y - Range; y <= Start.Y + Range; ++y ) {
					if( ( tile = this[ x, y ] ) == null )
						continue;
					count += tile.Units[ ESerialType.Char ].Count;
				}

			return count;
		}



		#region IMap Member
		int IMap.Width {
			get { return Width; }
		}

		int IMap.Height {
			get { return Height; }
		}
		#endregion

	}

}
