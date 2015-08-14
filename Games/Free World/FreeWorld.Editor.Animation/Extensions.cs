using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FreeWorld.Editor.Animation {

	public static class ColorExtensions {

		public static System.Drawing.Color ToWinColor(this Color c) {
			return System.Drawing.Color.FromArgb(c.A, c.R, c.G, c.B);
		}

		public static Color SetR(this Color col, byte red) {
			return new Color(red, col.G, col.B, col.A);
		}

		public static Color SetG(this Color col, byte green) {
			return new Color(col.R, green, col.B, col.A);
		}

		public static Color SetB(this Color col, byte blue) {
			return new Color(col.R, blue, col.B, col.A);
		}

	}

}
