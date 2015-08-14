using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shaiya.Extended.Library.Geometry {

	public struct Point2D : IPoint2D, IComparable, IComparable<Point2D> {
		internal int mX;
		internal int mY;

		public static readonly Point2D Zero = new Point2D( 0, 0 );

		public int X {
			get { return mX; }
			set { mX = value; }
		}

		public int Y {
			get { return mY; }
			set { mY = value; }
		}



		public Point2D( int x, int y ) {
			mX = x;
			mY = y;
		}

		public Point2D( IPoint2D p )
			: this( p.X, p.Y ) {
		}

		public Point2D( Point3D p )
			: this( p.X, p.Y ) {
		}

		public Point2D( IPoint3D p )
			: this( p.X, p.Y ) {
		}


		#region ToPoint
		public void ToPoint( string value ) {
			int start = value.IndexOf( '(' );
			int end = value.IndexOf( ',', start + 1 );

			string param1 = value.Substring( start + 1, end - ( start + 1 ) ).Trim();

			start = end;
			end = value.IndexOf( ')', start + 1 );

			string param2 = value.Substring( start + 1, end - ( start + 1 ) ).Trim();

			mX = Convert.ToInt32( param1 );
			mY = Convert.ToInt32( param2 );
		}

		public static void ToPoint( string value, ref Point2D p ) {
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

		public static void ToPoint( EDirection D, ref Point2D p ) {
			p.ToPoint( D );
		}

		#endregion


		#region CompareTo
		public bool CompareTo( IMap Map ) {
			return ( mX >= 0 && mX < Map.Width && mY >= 0 && mY < Map.Height );
		}

		public int CompareTo( Point2D other ) {
			int v = ( mX.CompareTo( other.mX ) );

			if( v == 0 )
				v = ( mY.CompareTo( other.mY ) );

			return v;
		}

		public int CompareTo( object other ) {
			if( other is Point2D )
				return this.CompareTo( (Point2D)other );
			else if( other == null )
				return -1;

			throw new ArgumentException();
		}
		#endregion


		#region operator override
		public static Point2D operator +( Point2D l, IPoint2D r ) {
			if( Object.ReferenceEquals( r, null ) )
				return Point2D.Zero;

			return new Point2D( l.mX + r.X, l.mY + r.Y );
		}

		public static Point2D operator +( Point2D l, Point2D r ) {
			return new Point2D( l.mX + r.mX, l.mY + r.mY );
		}

		public static Point2D operator -( Point2D l, IPoint2D r ) {
			if( Object.ReferenceEquals( r, null ) )
				return Point2D.Zero;

			return new Point2D( l.mX - r.X, l.mY - r.Y );
		}

		public static Point2D operator -( Point2D l, Point2D r ) {
			return new Point2D( l.mX - r.mX, l.mY - r.mY );
		}

		public static bool operator ==( Point2D l, Point2D r ) {
			return l.mX == r.mX && l.mY == r.mY;
		}

		public static bool operator ==( Point2D l, IPoint2D r ) {
			if( Object.ReferenceEquals( r, null ) )
				return false;

			return l.mX == r.X && l.mY == r.Y;
		}

		public static bool operator !=( Point2D l, Point2D r ) {
			return l.mX != r.mX || l.mY != r.mY;
		}

		public static bool operator !=( Point2D l, IPoint2D r ) {
			if( Object.ReferenceEquals( r, null ) )
				return false;

			return l.mX != r.X || l.mY != r.Y;
		}

		public static bool operator >( Point2D l, Point2D r ) {
			return l.mX > r.mX && l.mY > r.mY;
		}

		public static bool operator >( Point2D l, IPoint2D r ) {
			if( Object.ReferenceEquals( r, null ) )
				return false;

			return l.mX > r.X && l.mY > r.Y;
		}

		public static bool operator <( Point2D l, Point2D r ) {
			return l.mX < r.mX && l.mY < r.mY;
		}

		public static bool operator <( Point2D l, IPoint2D r ) {
			if( Object.ReferenceEquals( r, null ) )
				return false;

			return l.mX < r.X && l.mY < r.Y;
		}

		public static bool operator >=( Point2D l, Point2D r ) {
			return l.mX >= r.mX && l.mY >= r.mY;
		}

		public static bool operator >=( Point2D l, IPoint2D r ) {
			if( Object.ReferenceEquals( r, null ) )
				return false;

			return l.mX >= r.X && l.mY >= r.Y;
		}

		public static bool operator <=( Point2D l, Point2D r ) {
			return l.mX <= r.mX && l.mY <= r.mY;
		}

		public static bool operator <=( Point2D l, IPoint2D r ) {
			if( Object.ReferenceEquals( r, null ) )
				return false;

			return l.mX <= r.X && l.mY <= r.Y;
		}
		#endregion

		public override bool Equals( object o ) {
			if( o == null || !( o is IPoint2D ) )
				return false;

			IPoint2D p = (IPoint2D)o;

			return mX == p.X && mY == p.Y;
		}

		public override int GetHashCode() {
			return mX ^ mY;
		}

		public override string ToString() {
			return String.Format( "({0}, {1})", mX, mY );
		}

	}

}
