using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace eAthenaTool.Plugins.EditSprite.Controls {

	public class PaletteColorChangedEventArgs : EventArgs {
		private int mIndex;
		private Color mColor;

		public int Index {
			get { return mIndex; }
		}

		public Color Color {
			get { return mColor; }
		}


		public PaletteColorChangedEventArgs( int i, Color col )
			: base() {
			mIndex = i;
			mColor = col;
		}

	}

}
