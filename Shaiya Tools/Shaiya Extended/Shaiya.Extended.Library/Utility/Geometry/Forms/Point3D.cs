using System;
using System.Collections.Generic;
using System.Text;

namespace Shaiya.Extended.Library.Geometry {

	public struct Point3D : IPoint3D, IComparable, IComparable<Point3D> {
		internal int mX;
		internal int mY;
		internal int mZ;

		public static readonly Point3D Zero = new Point3D( 0, 0, 0 );

		public int X {
			get { return mX; }
			set { mX = value; }
		}

		public int Y {
			get { return mY; }
			set { mY = value; }
		}

		public int Z {
			get { return mZ; }
			set { mZ = value; }
		}



		public Point3D( int x, int y, int z ) {
			mX = x;
			mY = y;
			mZ = z;
		}

		public Point3D( IPoint3D p )
			: this( p.X, p.Y, p.Z ) {
		}

		public Point3D( IPoint2D p, int z )
			: this( p.X, p.Y, z ) {
		}

		public Point3D( IPoint2D p )
			: this( p, 0 ) {
		}

		public Point3D( int x, int y )
			: this( x, y, 0 ) {
		}



		#region ToPoint
		public void ToPoint( string value ) {
			int start = value.IndexOf( '(' );
			int end = value.IndexOf( ',', start + 1 );

			string param1 = value.Substring( start + 1, end - ( start + 1 ) ).Trim();

			start = end;
			end = value.IndexOf( ',', start + 1 );

			string param2 = value.Substring( start + 1, end - ( start + 1 ) ).Trim();

			start = end;
			end = value.IndexOf( ')', start + 1 );

			string param3 = value.Substring( start + 1, end - ( start + 1 ) ).Trim();

			mX = Convert.ToInt32( param1 );
			mY = Convert.ToInt32( param2 );
			mZ = Convert.ToInt32( param3 );
		}

		public static void ToPoint( string value, ref Point3D p ) {
			p.ToPoint( value );
		}



		public void ToPoint( EDirection D ) {
			switch( D ) {
				case EDirection.Up:
					mY++;
					break;
				case EDirection.UpLeft:
					mX++;
					mY++;
					break;
				case EDirection.Left:
					mX++;
					break;
				case EDirection.DownLeft:
					mX++;
					mY--;
					break;
				case EDirection.Down:
					mY--;
					break;
				case EDirection.DownRight:
					mX--;
					mY--;
					break;
				case EDirection.Right:
					mX--;
					break;
				case EDirection.UpRight:
					mX--;
					mY++;
					break;
			}
		}

		public static void ToPoint( EDirection D, ref Point3D p ) {
			p.ToPoint( D );
		}
		#endregion


		#region operator override
		public static Point3D operator +( Point3D l, IPoint3D r ) {
			if( Object.ReferenceEquals( r, null ) )
				return Point3D.Zero;

			return new Point3D( l.mX + r.X, l.mY + r.Y, l.mZ + r.Z );
		}

		public static Point3D operator +( Point3D l, Point3D r ) {
			return new Point3D( l.mX + r.X, l.mY + r.Y, l.mZ + r.mZ );
		}

		public static Point3D operator -( Point3D l, IPoint3D r ) {
			if( Object.ReferenceEquals( r, null ) )
				return Point3D.Zero;

			return new Point3D( l.mX - r.X, l.mY - r.Y, l.mZ - r.Z );
		}

		public static Point3D operator -( Point3D l, Point3D r ) {
			return new Point3D( l.mX - r.X, l.mY - r.Y, l.mZ - r.mZ );
		}

		public static bool operator ==( Point3D l, Point3D r ) {
			return l.mX == r.mX && l.mY == r.mY && l.mZ == r.mZ;
		}

		public static bool operator !=( Point3D l, Point3D r ) {
			return l.mX != r.mX || l.mY != r.mY && l.mZ != r.mZ;
		}

		public static bool operator ==( Point3D l, IPoint3D r ) {
			if( Object.ReferenceEquals( r, null ) )
				return false;

			return l.mX == r.X && l.mY == r.Y && l.mZ == r.Z;
		}

		public static bool operator !=( Point3D l, IPoint3D r ) {
			if( Object.ReferenceEquals( r, null ) )
				return false;

			return l.mX != r.X || l.mY != r.Y && l.mZ != r.Z;
		}

		public static bool operator >( Point3D l, Point3D r ) {
			return l.mX > r.mX && l.mY > r.mY && l.mZ > r.mZ;
		}

		public static bool operator >( Point3D l, IPoint3D r ) {
			if( Object.ReferenceEquals( r, null ) )
				return false;

			return l.mX > r.X && l.mY > r.Y;
		}

		public static bool operator <( Point3D l, Point3D r ) {
			return l.mX < r.mX && l.mY < r.mY && l.mZ < r.mZ;
		}

		public static bool operator <( Point3D l, IPoint3D r ) {
			if( Object.ReferenceEquals( r, null ) )
				return false;

			return l.mX < r.X && l.mY < r.Y && l.mZ < r.Z;
		}

		public static bool operator >=( Point3D l, Point3D r ) {
			return l.mX >= r.mX && l.mY >= r.mY && l.mZ >= r.mZ;
		}

		public static bool operator >=( Point3D l, IPoint3D r ) {
			if( Object.ReferenceEquals( r, null ) )
				return false;

			return l.mX >= r.X && l.mY >= r.Y && l.mZ >= r.Z;
		}

		public static bool operator <=( Point3D l, Point3D r ) {
			return l.mX <= r.mX && l.mY <= r.mY && l.mZ <= r.mZ;
		}

		public static bool operator <=( Point3D l, IPoint3D r ) {
			if( Object.ReferenceEquals( r, null ) )
				return false;

			return l.mX <= r.X && l.mY <= r.Y && l.mZ <= r.Z;
		}
		#endregion


		#region CompareTo
		public bool CompareTo( IMap Map ) {
			return ( mX >= 0 && mX < Map.Width && mY >= 0 && mY < Map.Height );
		}

		public int CompareTo( Point3D other ) {
			int v = ( mX.CompareTo( other.mX ) );

			if( v == 0 ) {
				v = ( mY.CompareTo( other.mY ) );

				if( v == 0 )
					v = ( mZ.CompareTo( other.mZ ) );
			}

			return v;
		}

		public int CompareTo( object other ) {
			if( other is Point3D )
				return this.CompareTo( (Point3D)other );
			else if( other == null )
				return -1;

			throw new ArgumentException();
		}
		#endregion

		public override string ToString() {
			return String.Format( "({0}, {1}, {2})", mX, mY, mZ );
		}

		public override bool Equals( object o ) {
			if( o == null || !( o is IPoint3D ) )
				return false;

			IPoint3D p = (IPoint3D)o;

			return mX == p.X && mY == p.Y && mZ == p.Z;
		}

		public override int GetHashCode() {
			return mX ^ mY ^ mZ;
		}
	}

}
