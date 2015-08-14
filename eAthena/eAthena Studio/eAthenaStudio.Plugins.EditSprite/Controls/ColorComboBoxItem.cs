using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace eAthenaStudio.Plugins.EditSprite.Controls {

	public class ColorComboBoxItem {
		private Color mColor;

		public Color Color {
			get { return mColor; }
			set { mColor = value; }
		}


		public ColorComboBoxItem(Color Color) {
			mColor = Color;
		}


		public override string ToString() {
			return mColor.ToString();
		}

	}

}
