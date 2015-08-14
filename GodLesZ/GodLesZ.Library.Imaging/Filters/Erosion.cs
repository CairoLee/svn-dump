using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace GodLesZ.Library.Imaging.Filters {

	public class Erosion : IFilter {
		private short[,] se;
		private int size;

		public Erosion() {
			this.se = new short[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
			this.size = 3;
		}

		public Erosion(short[,] se) {
			this.se = new short[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
			this.size = 3;
			int length = se.GetLength(0);
			if (((length != se.GetLength(1)) || (length < 3)) || ((length > 0x19) || ((length % 2) == 0))) {
				throw new ArgumentException();
			}
			this.se = se;
			this.size = length;
		}

		public unsafe Bitmap Apply(Bitmap srcImg) {
			if (srcImg.PixelFormat != PixelFormat.Format8bppIndexed) {
				throw new ArgumentException();
			}
			int width = srcImg.Width;
			int height = srcImg.Height;
			BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
			Bitmap bitmap = GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height);
			BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
			int stride = data2.Stride;
			int num4 = stride - width;
			int num10 = this.size >> 1;
			byte* numPtr = (byte*)bitmapdata.Scan0.ToPointer();
			byte* numPtr2 = (byte*)data2.Scan0.ToPointer();
			for (int i = 0; i < height; i++) {
				int num14 = 0;
				while (num14 < width) {
					byte num11 = 0xff;
					for (int j = 0; j < this.size; j++) {
						int num6 = j - num10;
						int num5 = i + num6;
						if (num5 >= 0) {
							if (num5 >= height) {
								goto Label_012D;
							}
							for (int k = 0; k < this.size; k++) {
								int num7 = k - num10;
								num5 = num14 + num7;
								if (((num5 >= 0) && (num5 < width)) && (this.se[j, k] == 1)) {
									byte num12 = numPtr[(num6 * stride) + num7];
									if (num12 < num11) {
										num11 = num12;
									}
								}
							}
						}
					}
				Label_012D:
					numPtr2[0] = num11;
					num14++;
					numPtr++;
					numPtr2++;
				}
				numPtr += num4;
				numPtr2 += num4;
			}
			bitmap.UnlockBits(data2);
			srcImg.UnlockBits(bitmapdata);
			return bitmap;
		}
	}
}

