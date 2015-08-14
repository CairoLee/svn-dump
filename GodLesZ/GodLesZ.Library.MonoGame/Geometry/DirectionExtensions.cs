namespace GodLesZ.Library.MonoGame.Geometry {

	public static class DirectionExtensions {

		public static Point2D ToPoint2D(this EDirection direction) {
			Point2D p = Point2D.Zero;
			switch (direction) {
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
					p.X++;
					break;
				case EDirection.Left:
					p.X--;
					break;
			}

			return p;
		}

		public static Point3D ToPoint3D(this EDirection direction) {
			return new Point3D(direction.ToPoint2D());
		}

	}

}