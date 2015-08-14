using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace GodLesZ.Library.Imaging {

	unsafe public class FastBitmap : IDisposable {
		private struct PixelData {
			public byte blue;
			public byte green;
			public byte red;
			public byte alpha;

			public override string ToString() {
				return "(" + alpha.ToString() + ", " + red.ToString() + ", " + green.ToString() + ", " + blue.ToString() + ")";
			}
		}

		private Bitmap workingBitmap = null;
		private int width = 0;
		private BitmapData bitmapData = null;
		private Byte* pBase = null;
		private PixelData* pixelData = null;

		public Bitmap Image {
			get { return workingBitmap; }
		}

		public int Width {
			get { return Image.Width; }
		}

		public int Height {
			get { return Image.Height; }
		}


		public FastBitmap(Bitmap inputBitmap)
			: this(inputBitmap, false) {
		}

		public FastBitmap(Bitmap inputBitmap, bool lockImage) {
			workingBitmap = inputBitmap;

			if (lockImage == true) {
				LockImage();
			}
		}


		public void Dispose() {
			UnlockImage();
		}


		public void LockImage() {
			Rectangle bounds = new Rectangle(Point.Empty, workingBitmap.Size);

			width = (int)(bounds.Width * sizeof(PixelData));
			if (width % 4 != 0)
				width = 4 * (width / 4 + 1);

			//Lock Image
			bitmapData = workingBitmap.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
			pBase = (Byte*)bitmapData.Scan0.ToPointer();
		}

		public void UnlockImage() {
			if (bitmapData != null) {
				workingBitmap.UnlockBits(bitmapData);
				bitmapData = null;
				pBase = null;
			}
		}


		public Color GetPixel(int x, int y) {
			pixelData = (PixelData*)(pBase + y * width + x * sizeof(PixelData));
			return Color.FromArgb(pixelData->alpha, pixelData->red, pixelData->green, pixelData->blue);
		}

		public Color GetPixelNext() {
			pixelData++;
			return Color.FromArgb(pixelData->alpha, pixelData->red, pixelData->green, pixelData->blue);
		}

		public void SetPixel(int x, int y, Color color) {
			PixelData* data = (PixelData*)(pBase + y * width + x * sizeof(PixelData));
			data->alpha = color.A;
			data->red = color.R;
			data->green = color.G;
			data->blue = color.B;
		}

	}

}
