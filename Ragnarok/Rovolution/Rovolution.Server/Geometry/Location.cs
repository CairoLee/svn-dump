using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Objects;

namespace Rovolution.Server.Geometry {

	public class Location {

		public Map Map {
			get;
			protected set;
		}

		public Point2D Point {
			get;
			set;
		}

		public int X {
			get { return Point.X; }
		}

		public int Y {
			get { return Point.Y; }
		}

		public EDirection Direction {
			get;
			set;
		}


		public Location(int mapID, Point2D p)
			: this(mapID, p.X, p.Y) {
		}

		public Location(int mapID, Point2D p, EDirection dir)
			: this(mapID, p.X, p.Y, dir) {
		}

		public Location(int mapID, int x, int y)
			: this(mapID, x, y, EDirection.Up) {
		}

		public Location(int mapID, int x, int y, EDirection dir) {
			Map = Mapcache.Maps[mapID];
			Point = new Point2D(x, y);
			Direction = dir;
		}


		public override string ToString() {
			return string.Format("{0} @ {1} ({2})", Map, Point, Direction);
		}

	}

}
