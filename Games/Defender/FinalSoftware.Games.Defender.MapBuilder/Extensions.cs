using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FinalSoftware.Games.Defender.MapBuilder {

	public static class Extensions {

		public static void DrawGrid(this Bitmap bmp, int gridSize, Color gridColor) {
			using (Graphics g = Graphics.FromImage(bmp)) {
				for (int y = 0; y < bmp.Height; y += gridSize) {
					for (int x = 0; x < bmp.Width; x++) {
						bmp.SetPixel(x, y, gridColor);
					}
				}
				for (int x = 0; x < bmp.Width; x += gridSize) {
					for (int y = 0; y < bmp.Height; y++) {
						bmp.SetPixel(x, y, gridColor);
					}
				}

			}
		}

	}

}
