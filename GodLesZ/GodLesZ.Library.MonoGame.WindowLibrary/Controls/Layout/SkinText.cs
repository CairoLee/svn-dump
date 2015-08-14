using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class SkinText : SkinBase {
		public SkinFont Font;
		public int OffsetX;
		public int OffsetY;
		public EAlignment Alignment;
		public SkinStates<Color> Colors;

		public SkinText()
			: base() {
			Colors.Enabled = Color.White;
			Colors.Pressed = Color.White;
			Colors.Focused = Color.White;
			Colors.Hovered = Color.White;
			Colors.Disabled = Color.White;
		}

		public SkinText(SkinText source)
			: base(source) {
			if (source != null) {
				this.Font = new SkinFont(source.Font);
				this.OffsetX = source.OffsetX;
				this.OffsetY = source.OffsetY;
				this.Alignment = source.Alignment;
				this.Colors = source.Colors;
			}
		}

	}

}
