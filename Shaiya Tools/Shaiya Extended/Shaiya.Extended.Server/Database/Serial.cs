using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shaiya.Extended.Server.Geometry;
using Shaiya.Extended.Library.Geometry;

namespace Shaiya.Extended.Server {

	public enum ESerialType {
		None,

		Account,
		Char,

		Mob,
		Item,
		Npc,

		Map,
	}

	/// <summary>
	/// a Unique Number for each Object
	/// </summary>
	public class Serial : IComparable, IComparable<Serial> {
		public static readonly Serial Zero = new Serial( 0, ESerialType.None );
		public static readonly Serial Null = new Serial( -1, ESerialType.None );

		private int mSerial;

		private static Serial mLastAccount = new Serial( 0, ESerialType.Account );
		private static Serial mLastChar = new Serial( 0, ESerialType.Char );
		private static Serial mLastMob = new Serial( 0, ESerialType.Mob );
		private static Serial mLastItem = new Serial( 0, ESerialType.Item );
		private static Serial mLastNpc = new Serial( 0, ESerialType.Npc );
		private static Serial mLastMap = new Serial( 0, ESerialType.Map );

		private ESerialType mUnitType;



		#region Last<Type>
		/// <summary>
		/// returnes the last Serial form a Player
		/// </summary>
		public static Serial LastAccount {
			get { return mLastAccount; }
		}

		/// <summary>
		/// returnes the last Serial form a Character
		/// </summary>
		public static Serial LastChar {
			get { return mLastChar; }
		}

		/// <summary>
		/// returnes the last Serial form a Mob
		/// </summary>
		public static Serial LastMob {
			get { return mLastMob; }
		}

		/// <summary>
		/// returnes the last Serial form a Item
		/// </summary>
		public static Serial LastItem {
			get { return mLastItem; }
		}

		/// <summary>
		/// returnes the last Serial form a Npc
		/// </summary>
		public static Serial LastNpc {
			get { return mLastNpc; }
		}

		/// <summary>
		/// returnes the last Serial form a Map
		/// </summary>
		public static Serial LastMap {
			get { return mLastMap; }
		}
		#endregion

		#region New<Type>
		/// <summary>
		/// creates a new Serial for a Player
		/// </summary>
		public static Serial NewAccount {
			get { return Serial.Seek( mLastAccount ); }
		}

		/// <summary>
		/// creates a new Serial for a Character
		/// </summary>
		public static Serial NewChar {
			get { return Serial.Seek( mLastChar ); }
		}

		/// <summary>
		/// creates a new Serial for a Mob
		/// </summary>
		public static Serial NewMob {
			get { return Serial.Seek( mLastMob ); }
		}

		/// <summary>
		/// creates a new Serial for a Item
		/// </summary>
		public static Serial NewItem {
			get { return Serial.Seek( mLastItem ); }
		}

		/// <summary>
		/// creates a new Serial for a Npc
		/// </summary>
		public static Serial NewNpc {
			get { return Serial.Seek( mLastNpc ); }
		}

		/// <summary>
		/// creates a new Serial for a Map
		/// </summary>
		public static Serial NewMap {
			get { return Serial.Seek( mLastMap ); }
		}
		#endregion



		/// <summary>
		/// returnes or sets the internal Serial Number
		/// </summary>
		public int Value {
			get { return mSerial; }
			set {
				mSerial = value;
				if( World.Objects.Get( this ) != null )
					throw new Exception( "Serial " + value + " already exists!" );
			}
		}

		/// <summary>
		/// returns or sets the Serial Type (see <see cref="EUnitType"/>)
		/// </summary>
		public ESerialType Type {
			get { return mUnitType; }
			set { mUnitType = value; }
		}






		/// <summary>
		/// Dummy Constructor
		/// <para>NOTE: use <see cref="Serial.NewItem"/> and <see cref="Serial.NewUnit"/>!</para>
		/// </summary>
		public Serial() {
			mSerial = Serial.Null;
		}

		/// <summary>
		/// Main Constructor
		/// <para>NOTE: use <see cref="Serial.NewItem"/> and <see cref="Serial.NewUnit"/>!</para>
		/// </summary>
		/// <param name="serial"></param>
		/// <param name="type"></param>
		public Serial( int serial, ESerialType type ) {
			mSerial = serial;
			mUnitType = type;
		}

		/// <summary>
		/// Main Constructor
		/// <para>NOTE: use <see cref="Serial.NewItem"/> and <see cref="Serial.NewUnit"/>!</para>
		/// </summary>
		/// <param name="serial"></param>
		/// <param name="type"></param>
		public Serial( uint serial, ESerialType type )
			: this( (int)serial, type ) {
		}

		/// <summary>
		/// Main Constructor
		/// <para>NOTE: use <see cref="Serial.NewItem"/> and <see cref="Serial.NewUnit"/>!</para>
		/// </summary>
		/// <param name="serial"></param>
		/// <param name="type"></param>
		public Serial( long serial, ESerialType type )
			: this( (int)serial, type ) {
		}





		private static Serial Seek( Serial s ) {
			do {
				s.Value++;
			} while( World.Objects.Get( s ) != null );

			return s;
		}



		#region Object overrides
		/// <summary>
		/// compare the Serial with another Serial
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo( Serial other ) {
			return mSerial.CompareTo( other );
		}

		/// <summary>
		/// compare the Serial with another Serial Object
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo( object other ) {
			if( other is Serial )
				return this.CompareTo( (Serial)other );
			else if( other == null )
				return -1;

			throw new ArgumentException();
		}


		public override int GetHashCode() {
			return mSerial;
		}

		public override bool Equals( object o ) {
			if( o == null || !( o is Serial ) )
				return false;

			return ( (Serial)o ).mSerial == mSerial;
		}
		#endregion

		#region operator override
		public static bool operator ==( Serial l, Serial r ) {
			return ( l.mSerial == r.mSerial && l.Type == r.Type );
		}

		public static bool operator !=( Serial l, Serial r ) {
			return ( l.mSerial != r.mSerial || l.Type != r.Type );
		}

		public static bool operator >( Serial l, Serial r ) {
			return l.mSerial > r.mSerial;
		}

		public static bool operator <( Serial l, Serial r ) {
			return l.mSerial < r.mSerial;
		}

		public static bool operator >=( Serial l, Serial r ) {
			return l.mSerial >= r.mSerial;
		}

		public static bool operator <=( Serial l, Serial r ) {
			return l.mSerial <= r.mSerial;
		}

		public static implicit operator int( Serial a ) {
			return a.mSerial;
		}

		public static implicit operator uint( Serial a ) {
			return (uint)a.mSerial;
		}

		public static implicit operator long( Serial a ) {
			return (long)a.mSerial;
		}

		public static implicit operator Serial( int a ) {
			return new Serial( a, ESerialType.None );
		}
		#endregion

		public override string ToString() {
			return String.Format( "0x{0:X8}", mSerial );
		}

	}






	public partial class SerialObject : IComparable<SerialObject>, IDisposable {

		private Serial mSerial;
		private Point3D mLocation;
		private Map mMap;

		public Serial Serial {
			get { return mSerial; }
			set { mSerial = value; }
		}

		public Point3D Location {
			get { return mLocation; }
			set { mLocation = value; }
		}

		public int X {
			get { return mLocation.X; }
		}

		public int Y {
			get { return mLocation.Y; }
		}

		public int Z {
			get { return mLocation.Z; }
		}

		public Map Map {
			get { return mMap; }
			set { mMap = value; }
		}



		public SerialObject() {
		}

		public SerialObject( Serial serial, Point3D loc, Map map ) {
			mSerial = serial;
			mLocation = loc;
			mMap = map;

			mMap.OnEnter( this );
		}



		public virtual void Delete() {
			mMap.OnLeave( this );
			World.Objects.Remove( this );
		}

		public virtual void Move( EDirection D ) {
			Point3D oldLoc = mLocation;
			mLocation += D.ToPoint3D();

			mMap.OnMove( this, oldLoc );
		}



		#region IComparable Member
		public int CompareTo( SerialObject other ) {
			if( other == null )
				return -1;

			return mSerial.CompareTo( other.Serial );
		}

		public int CompareTo( object other ) {
			if( other == null || other is SerialObject )
				return this.CompareTo( (SerialObject)other );

			throw new ArgumentException();
		}
		#endregion


		public virtual void Dispose() {
			
		}

	}




}
