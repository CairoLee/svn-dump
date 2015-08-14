using Rovolution.Server.Geometry;

namespace Rovolution.Server.Objects {

	public class NpcWarpData {

		public Point2D TouchArea {
			get;
			set;
		}

		public Location Destination {
			get;
			set;
		}


		public NpcWarpData(Point2D area, Location loc) {
			TouchArea = area;
			Destination = loc;
		}

	}

}
