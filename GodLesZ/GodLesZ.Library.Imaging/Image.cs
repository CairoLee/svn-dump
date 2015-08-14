namespace GodLesZ.Library.Imaging {
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;

	public class Image {
		public static Bitmap Clone(Bitmap src) {
			int width = src.Width;
			int height = src.Height;
			BitmapData bitmapdata = src.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, src.PixelFormat);
			Bitmap bitmap = new Bitmap(width, height, src.PixelFormat);
			BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
			Win32.memcpy(data2.Scan0, bitmapdata.Scan0, height * bitmapdata.Stride);
			bitmap.UnlockBits(data2);
			src.UnlockBits(bitmapdata);
			if (((src.PixelFormat == PixelFormat.Format1bppIndexed) || (src.PixelFormat == PixelFormat.Format4bppIndexed)) || ((src.PixelFormat == PixelFormat.Format8bppIndexed) || (src.PixelFormat == PixelFormat.Indexed))) {
				ColorPalette palette = src.Palette;
				ColorPalette palette2 = bitmap.Palette;
				int length = palette.Entries.Length;
				for (int i = 0; i < length; i++) {
					palette2.Entries[i] = palette.Entries[i];
				}
				bitmap.Palette = palette2;
			}
			return bitmap;
		}

		public static Bitmap Clone(Bitmap src, PixelFormat format) {
			if (src.PixelFormat == format) {
				return Clone(src);
			}
			int width = src.Width;
			int height = src.Height;
			Bitmap image = new Bitmap(width, height, format);
			Graphics graphics = Graphics.FromImage(image);
			graphics.DrawImage(src, 0, 0, width, height);
			graphics.Dispose();
			return image;
		}

		public static Bitmap CreateGrayscaleImage(int width, int height) {
			Bitmap srcImg = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
			SetGrayscalePalette(srcImg);
			return srcImg;
		}

		public static void FormatImage(ref Bitmap src) {
			if (src.PixelFormat != PixelFormat.Format24bppRgb) {
				Bitmap bitmap = src;
				src = Clone(bitmap, PixelFormat.Format24bppRgb);
				bitmap.Dispose();
			}
		}

		public static bool IsGrayscale(Bitmap bmp) {
			bool flag = false;
			if (bmp.PixelFormat == PixelFormat.Format8bppIndexed) {
				flag = true;
				ColorPalette palette = bmp.Palette;
				for (int i = 0; i < 0x100; i++) {
					Color color = palette.Entries[i];
					if (((color.R != i) || (color.G != i)) || (color.B != i)) {
						return false;
					}
				}
			}
			return flag;
		}

		public static void SetGrayscalePalette(Bitmap srcImg) {
			if (srcImg.PixelFormat != PixelFormat.Format8bppIndexed) {
				throw new ArgumentException();
			}
			ColorPalette palette = srcImg.Palette;
			for (int i = 0; i < 0x100; i++) {
				palette.Entries[i] = Color.FromArgb(i, i, i);
			}
			srcImg.Palette = palette;
		}

		public static void ReplacePaletteColor(Bitmap srcImg, Color srcColor, Color destColor) {
			ColorPalette palette = srcImg.Palette;
			for (int i = 0; i < palette.Entries.Length; i++) {
				if (palette.Entries[i] == srcColor) {
					palette.Entries[i] = destColor;
				}
			}
			srcImg.Palette = palette;
		}

		public static void ReplaceNativeColor(Bitmap srcImg, byte minR, byte maxR, byte minG, byte maxG, byte minB, byte maxB, Color destColor) {
			Color c;
			using (FastBitmap bmp = new FastBitmap(srcImg, true)) {
				for (int x = 0; x < bmp.Width; x++) {
					for (int y = 0; y < bmp.Height; y++) {
						c = bmp.GetPixel(x, y);
						if (
							(c.R >= minR && c.R <= maxR) &&
							(c.G >= minG && c.G <= maxG) &&
							(c.B >= minB && c.B <= maxB)
						) {
							bmp.SetPixel(x, y, destColor);
						}
					}
				}
			}
		}

	}

}

