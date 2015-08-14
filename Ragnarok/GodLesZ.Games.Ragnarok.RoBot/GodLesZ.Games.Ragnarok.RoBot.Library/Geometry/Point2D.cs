using System;
using GodLesZ.Games.Ragnarok.RoBot.Library.Objects;

namespace Rovolution.Server.Geometry {

	public class Point2D : IPoint2D, IComparable, IComparable<Point2D> {
		public static readonly Point2D Zero = new Point2D(0, 0);

		public int X {
			get;
			set;
		}

		public int Y {
			get;
			set;
		}


		public Point2D(int x, int y) {
			X = x;
			Y = y;
		}

		public Point2D(IPoint2D p)
			: this(p.X, p.Y) {
		}

		public Point2D()
			: this(0, 0) {
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

		public void ToPoint(EDirection D) {
			switch (D) {
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

		public static void ToPoint(EDirection D, ref Point2D p) {
			p.ToPoint(D);
		}
		#endregion

		public EDirection ToDirection() {
			if (X == 0 && Y == 0) {
				return EDirection.None;
			} else if (X == 0 && Y > 0) {
				return EDirection.Up;
			} else if (X == 0 && Y < 0) {
				return EDirection.Down;
			} else if (X < 0 && Y == 0) {
				return EDirection.Left;
			} else if (X > 0 && Y == 0) {
				return EDirection.Right;
			} else if (X < 0 && Y > 0) {
				return EDirection.UpLeft;
			} else if (X > 0 && Y > 0) {
				return EDirection.UpRight;
			} else if (X < 0 && Y < 0) {
				return EDirection.DownLeft;
			} else if (X > 0 && Y < 0) {
				return EDirection.DownRight;
			}

			return EDirection.None;
		}


		#region CompareTo
		public bool CompareTo(IMap Map) {
			return (X >= 0 && X < Map.Width && Y >= 0 && Y < Map.Height);
		}

		public int CompareTo(Point2D other) {
			int v = (X.CompareTo(other.X));

			if (v == 0)
				v = (Y.CompareTo(other.Y));

			return v;
		}

		public int CompareTo(object other) {
			if (other is Point2D)
				return this.CompareTo((Point2D)other);
			else if (other == null)
				return -1;

			throw new ArgumentException();
		}
		#endregion


		public bool InRange(Point2D p, int range) {
			return PathHelper.InRange(X - p.X, Y - p.Y, range);
		}


		#region operator override
		public static Point2D operator +(Point2D l, Point2D r) {
			return new Point2D(l.X + r.X, l.Y + r.Y);
		}

		public static Point2D operator -(Point2D l, Point2D r) {
			return new Point2D(l.X - r.X, l.Y - r.Y);
		}

		public static bool operator ==(Point2D l, Point2D r) {
			return l.X == r.X && l.Y == r.Y;
		}

		public static bool operator !=(Point2D l, Point2D r) {
			return l.X != r.X || l.Y != r.Y;
		}

		public static bool operator >(Point2D l, Point2D r) {
			return l.X > r.X && l.Y > r.Y;
		}

		public static bool operator <(Point2D l, Point2D r) {
			return l.X < r.X && l.Y < r.Y;
		}

		public static bool operator >=(Point2D l, Point2D r) {
			return l.X >= r.X && l.Y >= r.Y;
		}

		public static bool operator <=(Point2D l, Point2D r) {
			return l.X <= r.X && l.Y <= r.Y;
		}
		#endregion


		public override bool Equals(object o) {
			if (o == null || !(o is IPoint2D))
				return false;

			IPoint2D p = (IPoint2D)o;

			return X == p.X && Y == p.Y;
		}

		public override int GetHashCode() {
			return X ^ Y;
		}

		public override string ToString() {
			return String.Format("{0}, {1}", X, Y);
		}

	}

}
