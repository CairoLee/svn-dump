namespace GodLesZ.Library.Imaging.Filters {
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;

	public class Threshold : IFilter {
		private byte max;
		private byte min;

		public Threshold() {
			this.min = 0x80;
			this.max = 0xff;
		}

		public Threshold(byte min, byte max) {
			this.min = 0x80;
			this.max = 0xff;
			this.min = Math.Min(min, max);
			this.max = Math.Max(min, max);
		}

		public unsafe Bitmap Apply(Bitmap srcImg) {
			int width = srcImg.Width;
			int height = srcImg.Height;
			PixelFormat format = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
			BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
			Bitmap bitmap = GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height);
			BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
			int num3 = bitmapdata.Stride - ((format == PixelFormat.Format8bppIndexed) ? width : (width * 3));
			int num4 = data2.Stride - width;
			byte* numPtr = (byte*)bitmapdata.Scan0.ToPointer();
			byte* numPtr2 = (byte*)data2.Scan0.ToPointer();
			if (format == PixelFormat.Format8bppIndexed) {
				for (int i = 0; i < height; i++) {
					int num6 = 0;
					while (num6 < width) {
						numPtr2[0] = ((numPtr[0] >= this.min) && (numPtr[0] <= this.max)) ? ((byte)0xff) : ((byte)0);
						num6++;
						numPtr++;
						numPtr2++;
					}
					numPtr += num3;
					numPtr2 += num4;
				}
			} else {
				for (int j = 0; j < height; j++) {
					int num9 = 0;
					while (num9 < width) {
						byte num7 = (byte)(((0.2125f * numPtr[2]) + (0.7154f * numPtr[1])) + (0.0721f * numPtr[0]));
						numPtr2[0] = ((num7 >= this.min) && (num7 <= this.max)) ? ((byte)0xff) : ((byte)0);
						num9++;
						numPtr += 3;
						numPtr2++;
					}
					numPtr += num3;
					numPtr2 += num4;
				}
			}
			bitmap.UnlockBits(data2);
			srcImg.UnlockBits(bitmapdata);
			return bitmap;
		}

		public byte Max {
			get {
				return this.max;
			}
			set {
				this.max = value;
			}
		}

		public byte Min {
			get {
				return this.min;
			}
			set {
				this.min = value;
			}
		}
	}
}

