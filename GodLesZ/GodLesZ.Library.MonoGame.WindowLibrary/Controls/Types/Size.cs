using System;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public struct Size {
		public int Width;
		public int Height;

		public Size(int width, int height) {
			Width = width;
			Height = height;
		}

		public static Size Zero {
			get { return new Size(0, 0); }
		}
	}

}
