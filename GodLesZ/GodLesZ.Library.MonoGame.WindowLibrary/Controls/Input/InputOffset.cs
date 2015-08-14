using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public struct InputOffset {
		public int X;
		public int Y;
		public float RatioX;
		public float RatioY;

		public InputOffset(int x, int y, float rx, float ry) {
			X = x;
			Y = y;
			RatioX = rx;
			RatioY = ry;
		}
	}

}
