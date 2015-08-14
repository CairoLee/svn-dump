using System;
using System.Collections.Generic;
using System.Text;

namespace Shaiya.Extended.Library.Geometry {

	public enum EDirection {
		None = 0,
		Up = 1,
		UpLeft = 2,
		Left = 3,
		DownLeft = 4,
		Down = 5,
		DownRight = 6,
		Right = 7,
		UpRight = 8,
	}


	public static class EDirectionExtensions {
		public static Point3D ToPoint3D( this EDirection Direction ) {
			return Direction.ToPoint3D( Point3D.Zero );
		}

		public static Point3D ToPoint3D( this EDirection Direction, Point3D p ) {

			switch( Direction ) {
				case EDirection.Up:
					p.Y--;
					break;
				case EDirection.UpLeft:
					p.X--;
					p.Y--;
					break;
				case EDirection.UpRight:
					p.X++;
					p.Y--;
					break;
				case EDirection.Down:
					p.Y++;
					break;
				case EDirection.DownLeft:
					p.X--;
					p.Y++;
					break;
				case EDirection.DownRight:
					p.X++;
					p.Y++;
					break;
				case EDirection.Right:
					p.mX++;
					break;
				case EDirection.Left:
					p.X--;
					break;
			}

			return p;
		}

	}

}
