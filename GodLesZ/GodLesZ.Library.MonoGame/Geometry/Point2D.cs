using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace GodLesZ.Library.MonoGame.Geometry {

	public struct Point2D : IPoint2D, IComparable, IComparable<Point2D> {
		public static readonly Point2D Zero = new Point2D(0, 0);
		public static readonly Point2D MinisOne = new Point2D(-1, -1);

		public int X {
			get;
			set;
		}

		public int Y {
			get;
			set;
		}


		public Point2D(int x, int y)
			: this() {
			X = x;
			Y = y;
		}

		public Point2D(IPoint2D p)
			: this(p.X, p.Y) {
		}

		public Point2D(IPoint3D p)
			: this(p.X, p.Y) {
		}

		public Point2D(Point p)
			: this(p.X, p.Y) {
		}

		public Point2D(IPoint p)
			: this(p.X, p.Y) {
		}


		#region ToPoint
		public void ToPoint(string value) {
			int start = value.IndexOf('(');
			int end = value.IndexOf(',', start + 1);

			string param1 = value.Substring(start + 1, end - (start + 1)).Trim();

			start = end;
			end = value.IndexOf(')', start + 1);

			string param2 = value.Substring(start + 1, end - (start + 1)).Trim();


			X = Convert.ToInt32(param1);
			Y = Convert.ToInt32(param2);
		}

		public static void ToPoint(string value, ref Point2D p) {
			p.ToPoint(value);
		}

		public void ToPoint(EDirection direction) {
			switch (direction) {
				case EDirection.Up:
					Y++;
					break;
				case EDirection.UpLeft:
					X++;
					Y++;
					break;
				case EDirection.Left:
					X++;
					break;
				case EDirection.DownLeft:
					X++;
					Y--;
					break;
				case EDirection.Down:
					Y--;
					break;
				case EDirection.DownRight:
					X--;
					Y--;
					break;
				case EDirection.Right:
					X--;
					break;
				case EDirection.UpRight:
					X--;
					Y++;
					break;
			}
		}

		public static void ToPoint(EDirection direction, ref Point2D p) {
			p.ToPoint(direction);
		}

		#endregion

		public Vector2 ToVector2() {
			return new Vector2(X, Y);
		}


		public void ReduceY(int val = 1) {
			Y -= val;
		}

		public void ReduceX(int val = 1) {
			X -= val;
		}

		public void AddY(int val = 1) {
			Y += val;
		}

		public void AddX(int val = 1) {
			X += val;
		}


		public bool Contains(IPoint2D p, IPoint2D size) {
			// Build a rectangle based on this position and the given size
			var rect = new Rectangle2D(p.X, p.Y, size.X, size.Y);
			return rect.Contains(this);
		}

		public bool Contains(Rectangle rect) {
			return X >= rect.X && Y >= rect.Y && X <= (rect.X + rect.Width) &&  Y <= (rect.Y + rect.Height);
		}

		#region CompareTo
		public int CompareTo(Point2D other) {
			int v = (X.CompareTo(other.X));

			if (v == 0)
				v = (Y.CompareTo(other.Y));

			return v;
		}

		/// <exception cref="ArgumentException"></exception>
		public int CompareTo(object other) {
			if (other is Point2D)
				return CompareTo((Point2D)other);
			if (other == null)
				return -1;

			throw new ArgumentException();
		}
		#endregion

		#region operator override
		public static Point2D FromIPoint(IPoint p) {
			return new Point2D(p);
		}

		public static Point2D FromIPoint2D(IPoint2D p) {
			return new Point2D(p);
		}

		public static Point2D FromIPoint3D(IPoint3D p) {
			return new Point2D(p);
		}

		public static implicit operator Point(Point2D p) {
			return new Point(p.X, p.Y);
		}



		public static Point2D operator +(Point2D l, Point2D r) {
			return new Point2D(l.X + r.X, l.Y + r.Y);
		}

		public static Point2D operator +(Point2D l, IPoint2D r) {
			return new Point2D(l.X + r.X, l.Y + r.Y);
		}

		public static Point2D operator +(Point2D l, IPoint r) {
			return new Point2D(l.X + r.X, l.Y + r.Y);
		}

		public static Point2D operator +(Point2D l, Point r) {
			return new Point2D(l.X + r.X, l.Y + r.Y);
		}

		public static Point2D operator +(Point2D l, int r) {
			return new Point2D(l.X + r, l.Y + r);
		}

		public static Point2D operator +(Point2D l, float r) {
			return new Point2D((int)(l.X + r), (int)(l.Y + r));
		}

		public static Rectangle operator +(Point2D l, Rectangle r) {
			return new Rectangle(r.X + l.X, r.Y + l.Y, r.Width, r.Height);
		}

		public static Rectangle operator +(Rectangle l, Point2D r) {
			return new Rectangle(r.X + l.X, r.Y + l.Y, l.Width, l.Height);
		}

		public static Point2D operator -(Point2D l, Point2D r) {
			return new Point2D(l.X - r.X, l.Y - r.Y);
		}

		public static Point2D operator -(Point2D l, IPoint2D r) {
			return new Point2D(l.X - r.X, l.Y - r.Y);
		}

		public static Point2D operator -(Point2D l, IPoint r) {
			return new Point2D(l.X - r.X, l.Y - r.Y);
		}

		public static Point2D operator -(Point2D l, Point r) {
			return new Point2D(l.X - r.X, l.Y - r.Y);
		}

		public static Point2D operator -(Point2D l, int r) {
			return new Point2D(l.X - r, l.Y - r);
		}

		public static Point2D operator -(Point2D l, float r) {
			return new Point2D((int)(l.X - r), (int)(l.Y - r));
		}

		public static Point2D operator *(Point2D l, Point2D r) {
			return new Point2D(l.X * r.X, l.Y * r.Y);
		}

		public static Point2D operator *(Point2D l, IPoint2D r) {
			return new Point2D(l.X * r.X, l.Y * r.Y);
		}

		public static Point2D operator *(Point2D l, IPoint r) {
			return new Point2D(l.X * r.X, l.Y * r.Y);
		}

		public static Point2D operator *(Point2D l, Point r) {
			return new Point2D(l.X * r.X, l.Y * r.Y);
		}

		public static Point2D operator *(Point2D l, int r) {
			return new Point2D(l.X * r, l.Y * r);
		}

		public static Point2D operator *(Point2D l, float r) {
			return new Point2D((int)(l.X * r), (int)(l.Y * r));
		}

		public static Point2D operator /(Point2D l, Point2D r) {
			return new Point2D(l.X / r.X, l.Y / r.Y);
		}

		public static Point2D operator /(Point2D l, IPoint2D r) {
			return new Point2D(l.X / r.X, l.Y / r.Y);
		}

		public static Point2D operator /(Point2D l, IPoint r) {
			return new Point2D(l.X / r.X, l.Y / r.Y);
		}

		public static Point2D operator /(Point2D l, Point r) {
			return new Point2D(l.X / r.X, l.Y / r.Y);
		}

		public static Point2D operator /(Point2D l, int r) {
			return new Point2D(l.X / r, l.Y / r);
		}

		public static Point2D operator /(Point2D l, float r) {
			return new Point2D((int)(l.X / r), (int)(l.Y / r));
		}

		public static Point2D operator %(Point2D l, Point2D r) {
			return new Point2D(l.X % r.X, l.Y % r.Y);
		}

		public static Point2D operator %(Point2D l, IPoint2D r) {
			return new Point2D(l.X % r.X, l.Y % r.Y);
		}

		public static Point2D operator %(Point2D l, IPoint r) {
			return new Point2D(l.X % r.X, l.Y % r.Y);
		}

		public static Point2D operator %(Point2D l, int r) {
			return new Point2D(l.X % r, l.Y % r);
		}

		public static Point2D operator %(Point2D l, float r) {
			return new Point2D((int)(l.X % r), (int)(l.Y % r));
		}

		public static Point2D operator %(Point2D l, Point r) {
			return new Point2D(l.X % r.X, l.Y % r.Y);
		}

		public static bool operator ==(Point2D l, Point2D r) {
			return l.X == r.X && l.Y == r.Y;
		}

		public static bool operator ==(Point2D l, IPoint2D r) {
			Debug.Assert(r != null, "r != null");
			return l.X == r.X && l.Y == r.Y;
		}

		public static bool operator ==(Point2D l, IPoint r) {
			Debug.Assert(r != null, "r != null");
			return l.X == r.X && l.Y == r.Y;
		}

		public static bool operator !=(Point2D l, Point2D r) {
			return l.X != r.X || l.Y != r.Y;
		}

		public static bool operator !=(Point2D l, IPoint2D r) {
			Debug.Assert(r != null, "r != null");
			return l.X != r.X || l.Y != r.Y;
		}

		public static bool operator !=(Point2D l, IPoint r) {
			Debug.Assert(r != null, "r != null");
			return l.X != r.X || l.Y != r.Y;
		}

		public static bool operator >(Point2D l, Point2D r) {
			return l.X > r.X && l.Y > r.Y;
		}

		public static bool operator >(Point2D l, IPoint2D r) {
			return l.X > r.X && l.Y > r.Y;
		}

		public static bool operator >(Point2D l, IPoint r) {
			return l.X > r.X && l.Y > r.Y;
		}

		public static bool operator <(Point2D l, Point2D r) {
			return l.X < r.X && l.Y < r.Y;
		}

		public static bool operator <(Point2D l, IPoint2D r) {
			return l.X < r.X && l.Y < r.Y;
		}

		public static bool operator <(Point2D l, IPoint r) {
			return l.X < r.X && l.Y < r.Y;
		}

		public static bool operator >=(Point2D l, Point2D r) {
			return l.X >= r.X && l.Y >= r.Y;
		}

		public static bool operator >=(Point2D l, IPoint2D r) {
			return l.X >= r.X && l.Y >= r.Y;
		}

		public static bool operator >=(Point2D l, IPoint r) {
			return l.X >= r.X && l.Y >= r.Y;
		}

		public static bool operator <=(Point2D l, Point2D r) {
			return l.X <= r.X && l.Y <= r.Y;
		}

		public static bool operator <=(Point2D l, IPoint2D r) {
			return l.X <= r.X && l.Y <= r.Y;
		}

		public static bool operator <=(Point2D l, IPoint r) {
			return l.X <= r.X && l.Y <= r.Y;
		}
		#endregion

		public override bool Equals(object o) {
			if (o == null || !(o is IPoint2D))
				return false;

			var p = (IPoint2D)o;

			return X == p.X && Y == p.Y;
		}

		public override int GetHashCode() {
			return X ^ Y;
		}

		public override string ToString() {
			return String.Format("({0}, {1})", X, Y);
		}

	}

}
