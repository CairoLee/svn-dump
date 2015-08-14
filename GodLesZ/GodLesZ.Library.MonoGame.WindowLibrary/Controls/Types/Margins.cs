using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public struct Margins {
		public int Left;
		public int Top;
		public int Right;
		public int Bottom;

		public int Vertical {
			get { return (Top + Bottom); }
		}
		public int Horizontal {
			get { return (Left + Right); }
		}


		public Margins(int left, int top, int right, int bottom) {
			Left = left;
			Top = top;
			Right = right;
			Bottom = bottom;
		}
	}

}
