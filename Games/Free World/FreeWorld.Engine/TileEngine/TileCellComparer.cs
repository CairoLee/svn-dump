using System.Collections.Generic;

namespace FreeWorld.Engine.TileEngine {

	public class TileCellComparer : IComparer<ITileCell> {

		public int Compare(ITileCell x, ITileCell y) {
			if (x == null || y == null) {
				if (y == null) {
					return 0;
				}

				return (x == null ? -1 : 1);
			}

			// #1 - Compare Y
			if (x.Y != y.Y) {
				return x.Y.CompareTo(y.Y);
			}

			// #2 Compare X
			return x.X.CompareTo(y.X);
		}

	}

}
