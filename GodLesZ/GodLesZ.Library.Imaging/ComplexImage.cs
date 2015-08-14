namespace GodLesZ.Library.Imaging {
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using GodLesZ.Library.Imaging.Mathematic;

	public class ComplexImage : ICloneable {
		private Complex[,] data;
		private bool fmode;
		private int height;
		private int width;

		public void BackwardFourierTransform() {
			if (this.fmode) {
				FourierTransform.FFT2(this.data, FourierDirection.Backward);
				this.fmode = false;
				for (int i = 0; i < this.height; i++) {
					for (int j = 0; j < this.width; j++) {
						if (((j + i) & 1) != 0) {
							Complex complex1 = this.data[i, j];
							complex1.Re *= -1f;
							Complex complex2 = this.data[i, j];
							complex2.Im *= -1f;
						}
					}
				}
			}
		}

		public object Clone() {
			ComplexImage image = new ComplexImage();
			Complex[,] complexArray = new Complex[this.height, this.width];
			image.data = complexArray;
			image.width = this.width;
			image.height = this.height;
			image.fmode = this.fmode;
			for (int i = 0; i < this.height; i++) {
				for (int j = 0; j < this.width; j++) {
					complexArray[i, j] = this.data[i, j];
				}
			}
			return image;
		}

		public void ForwardFourierTransform() {
			if (!this.fmode) {
				for (int i = 0; i < this.height; i++) {
					for (int j = 0; j < this.width; j++) {
						if (((j + i) & 1) != 0) {
							Complex complex1 = this.data[i, j];
							complex1.Re *= -1f;
							Complex complex2 = this.data[i, j];
							complex2.Im *= -1f;
						}
					}
				}
				FourierTransform.FFT2(this.data, FourierDirection.Forward);
				this.fmode = true;
			}
		}

		public void FrequencyFilter(Range range) {
			if (this.fmode) {
				int num = this.width >> 1;
				int num2 = this.height >> 1;
				int min = (int)range.Min;
				int max = (int)range.Max;
				for (int i = 0; i < this.height; i++) {
					int num6 = i - num2;
					for (int j = 0; j < this.width; j++) {
						int num8 = j - num;
						int num9 = (int)Math.Sqrt((double)((num8 * num8) + (num6 * num6)));
						if ((num9 > max) || (num9 < min)) {
							this.data[i, j].Re = 0f;
							this.data[i, j].Im = 0f;
						}
					}
				}
			}
		}

		public static unsafe ComplexImage FromBitmap(Bitmap srcImg) {
			int width = srcImg.Width;
			int height = srcImg.Height;
			if (!Tools.IsPowerOf2(width) || !Tools.IsPowerOf2(height)) {
				throw new ArgumentException();
			}
			ComplexImage image = new ComplexImage();
			Complex[,] complexArray = new Complex[height, width];
			image.data = complexArray;
			image.width = width;
			image.height = height;
			BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, srcImg.PixelFormat);
			int num3 = bitmapdata.Stride - ((srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? width : (width * 3));
			byte* numPtr = (byte*)bitmapdata.Scan0.ToPointer();
			if (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) {
				for (int i = 0; i < height; i++) {
					int num5 = 0;
					while (num5 < width) {
						complexArray[i, num5].Re = ((float)numPtr[0]) / 255f;
						num5++;
						numPtr++;
					}
					numPtr += num3;
				}
			} else {
				for (int j = 0; j < height; j++) {
					int num7 = 0;
					while (num7 < width) {
						complexArray[j, num7].Re = (((0.2125f * numPtr[2]) + (0.7154f * numPtr[1])) + (0.0721f * numPtr[0])) / 255f;
						num7++;
						numPtr += 3;
					}
					numPtr += num3;
				}
			}
			srcImg.UnlockBits(bitmapdata);
			return image;
		}

		public unsafe Bitmap ToBitmap() {
			Bitmap bitmap = GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(this.width, this.height);
			BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, this.width, this.height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
			int num = bitmapdata.Stride - this.width;
			float num2 = this.fmode ? ((float)Math.Sqrt((double)(this.width * this.height))) : 1f;
			byte* numPtr = (byte*)bitmapdata.Scan0.ToPointer();
			for (int i = 0; i < this.height; i++) {
				int num4 = 0;
				while (num4 < this.width) {
					numPtr[0] = (byte)Math.Max(0f, Math.Min((float)255f, (float)((this.data[i, num4].Magnitude * num2) * 255f)));
					num4++;
					numPtr++;
				}
				numPtr += num;
			}
			bitmap.UnlockBits(bitmapdata);
			return bitmap;
		}

		public int Height {
			get {
				return this.height;
			}
		}

		public int Width {
			get {
				return this.width;
			}
		}
	}
}

