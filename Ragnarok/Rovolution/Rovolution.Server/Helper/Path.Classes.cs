using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Geometry;

namespace Rovolution.Server.Systems {

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
			path = new EDirection[Path.MAX_WALKPATH];
		}
	}

	public class ShootpathData {
		public int rx, ry, len;
		public int[] x;
		public int[] y;

		public ShootpathData() {
			x = new int[Path.MAX_WALKPATH];
			y = new int[Path.MAX_WALKPATH];
		}
	}

}
