using System;
using System.Collections.Generic;
using System.Text;

namespace Shaiya.Extended.Library.Geometry {

	public struct Rectangle3D {
		private Point3D mStart;
		private Point3D mEnd;

		public Point3D Start {
			get { return mStart; }
			set { mStart = value; }
		}

		public Point3D End {
			get { return mEnd; }
			set { mEnd = value; }
		}

		public int Width {
			get { return mEnd.X - mStart.X; }
		}

		public int Height {
			get { return mEnd.Y - mStart.Y; }
		}

		public int Depth {
			get { return mEnd.Z - mStart.Z; }
		}


		public Rectangle3D( Point3D start, Point3D end ) {
			mStart = start;
			mEnd = end;
		}

		public Rectangle3D( int x, int y, int z, int width, int height, int depth ) {
			mStart = new Point3D( x, y, z );
			mEnd = new Point3D( x + width, y + height, z + depth );
		}




		public bool Contains( Point3D p ) {
			return ( p.mX >= mStart.mX )
				&& ( p.mX < mEnd.mX )
				&& ( p.mY >= mStart.mY )
				&& ( p.mY < mEnd.mY )
				&& ( p.mZ >= mStart.mZ )
				&& ( p.mZ < mEnd.mZ );
		}

		public bool Contains( IPoint3D p ) {
			return ( p.X >= mStart.mX )
				&& ( p.X < mEnd.mX )
				&& ( p.Y >= mStart.mY )
				&& ( p.Y < mEnd.mY )
				&& ( p.Z >= mStart.mZ )
				&& ( p.Z < mEnd.mZ );
		}

	}

}
