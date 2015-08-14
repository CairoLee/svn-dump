using System;

namespace GodLesZ.Library.MonoGame.Geometry {

	public struct Rectangle2D : IRectangle2D {
		private Point2D mStart;
		private Point2D mEnd;

		public IPoint Start {
			get { return mStart; }
			set { mStart = Point2D.FromIPoint(value); }
		}

		public IPoint End {
			get { return mEnd; }
			set { mEnd = Point2D.FromIPoint(value); }
		}

		public int X {
			get { return mStart.X; }
			set { mStart.X = value; }
		}

		public int Y {
			get { return mStart.Y; }
			set { mStart.Y = value; }
		}

		public int Width {
			get { return mEnd.X - mStart.X; }
			set { mEnd.X = mStart.X + value; }
		}

		public int Height {
			get { return mEnd.Y - mStart.Y; }
			set { mEnd.Y = mStart.Y + value; }
		}


		public Rectangle2D(IPoint2D start, IPoint2D end) {
			mStart = new Point2D(start);
			mEnd = new Point2D(end);
		}

		public Rectangle2D(int x, int y, int width, int height) {
			mStart = new Point2D(x, y);
			mEnd = new Point2D(x + width, y + height);
		}


		public void Set(int x, int y, int width, int height) {
			mStart = new Point2D(x, y);
			mEnd = new Point2D(x + width, y + height);
		}

		public static Rectangle2D Parse(string value) {
			int start = value.IndexOf('(');
			int end = value.IndexOf(',', start + 1);

			string param1 = value.Substring(start + 1, end - (start + 1)).Trim();

			start = end;
			end = value.IndexOf(',', start + 1);

			string param2 = value.Substring(start + 1, end - (start + 1)).Trim();

			start = end;
			end = value.IndexOf(',', start + 1);

			string param3 = value.Substring(start + 1, end - (start + 1)).Trim();

			start = end;
			end = value.IndexOf(')', start + 1);

			string param4 = value.Substring(start + 1, end - (start + 1)).Trim();

			return new Rectangle2D(Convert.ToInt32(param1), Convert.ToInt32(param2), Convert.ToInt32(param3), Convert.ToInt32(param4));
		}

		public void MakeHold(Rectangle2D r) {
			if (r.mStart.X < mStart.X)
				mStart.X = r.mStart.X;

			if (r.mStart.Y < mStart.Y)
				mStart.Y = r.mStart.Y;

			if (r.mEnd.X > mEnd.X)
				mEnd.X = r.mEnd.X;

			if (r.mEnd.Y > mEnd.Y)
				mEnd.Y = r.mEnd.Y;
		}

		public bool Contains(IPoint2D p) {
			return Contains((IPoint)p);
		}

		public bool Contains(IPoint3D p) {
			return Contains((IPoint)p);
		}

		public bool Contains(IPoint p) {
			return (mStart <= p && mEnd > p);
		}

		public override string ToString() {
			return String.Format("({0}, {1})+({2}, {3})", X, Y, Width, Height);
		}
	}

}
