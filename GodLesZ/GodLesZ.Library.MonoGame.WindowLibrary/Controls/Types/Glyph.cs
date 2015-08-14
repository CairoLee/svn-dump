using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class Glyph {
		public Texture2D Image = null;
		public ESizeMode SizeMode = ESizeMode.Stretched;
		public Color Color = Color.White;
		public Point Offset = Point.Zero;
		public Rectangle SourceRect = Rectangle.Empty;

		public Glyph(Texture2D image) {
			Image = image;
		}

		public Glyph(Texture2D image, Rectangle sourceRect)
			: this(image) {
			SourceRect = sourceRect;
		}
	}

}
