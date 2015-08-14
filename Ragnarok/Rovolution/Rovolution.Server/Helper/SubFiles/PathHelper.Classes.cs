using Rovolution.Server.Geometry;

namespace Rovolution.Server.Helper {

	public struct STmpPath {
		public int x;
		public int y;
		public short dist;
		public short before;
		public short cost;
		public short flag;
	}

	public class WalkpathData {
		public uint path_len, path_pos;
		public EDirection[] path;

		public WalkpathData() {
			path = new EDirection[PathHelper.MAX_WALKPATH];
		}
	}

	public class ShootpathData {
		public int rx, ry, len;
		public int[] x;
		public int[] y;

		public ShootpathData() {
			x = new int[PathHelper.MAX_WALKPATH];
			y = new int[PathHelper.MAX_WALKPATH];
		}
	}

}
