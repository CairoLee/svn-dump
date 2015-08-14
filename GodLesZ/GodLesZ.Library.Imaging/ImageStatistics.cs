namespace GodLesZ.Library.Imaging {
	using System.Drawing;
	using System.Drawing.Imaging;
	using GodLesZ.Library.Imaging.Mathematic;

	public class ImageStatistics {
		private Histogram blue;
		private Histogram gray;
		private bool grayscale;
		private Histogram green;
		private HistogramD luminance;
		private int pixels;
		private Histogram red;
		private HistogramD saturation;

		public ImageStatistics(Bitmap image)
			: this(image, false) {
		}

		public unsafe ImageStatistics(Bitmap image, bool collectHSL) {
			int width = image.Width;
			int height = image.Height;
			this.pixels = width * height;
			if (this.grayscale = image.PixelFormat == PixelFormat.Format8bppIndexed) {
				BitmapData bitmapdata = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
				int[] values = new int[0x100];
				int num3 = bitmapdata.Stride - width;
				byte* numPtr = (byte*)bitmapdata.Scan0.ToPointer();
				for (int i = 0; i < height; i++) {
					int num5 = 0;
					while (num5 < width) {
						values[numPtr[0]]++;
						num5++;
						numPtr++;
					}
					numPtr += num3;
				}
				image.UnlockBits(bitmapdata);
				this.gray = new Histogram(values);
			} else {
				BitmapData data2 = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
				int[] numArray2 = new int[0x100];
				int[] numArray3 = new int[0x100];
				int[] numArray4 = new int[0x100];
				int[] numArray5 = new int[0x100];
				int[] numArray6 = new int[0x100];
				RGB rgb = new RGB();
				HSL hsl = new HSL();
				int num6 = data2.Stride - (width * 3);
				byte* numPtr2 = (byte*)data2.Scan0.ToPointer();
				for (int j = 0; j < height; j++) {
					int num8 = 0;
					while (num8 < width) {
						numArray2[numPtr2[2]]++;
						numArray3[numPtr2[1]]++;
						numArray4[numPtr2[0]]++;
						if (collectHSL) {
							rgb.Red = numPtr2[2];
							rgb.Green = numPtr2[1];
							rgb.Blue = numPtr2[0];
							if (collectHSL) {
								GodLesZ.Library.Imaging.ColorConverter.RGB2HSL(rgb, hsl);
								numArray5[(int)(hsl.Saturation * 255.0)]++;
								numArray6[(int)(hsl.Luminance * 255.0)]++;
							}
						}
						num8++;
						numPtr2 += 3;
					}
					numPtr2 += num6;
				}
				image.UnlockBits(data2);
				this.red = new Histogram(numArray2);
				this.green = new Histogram(numArray3);
				this.blue = new Histogram(numArray4);
				if (collectHSL) {
					this.saturation = new HistogramD(numArray5, new RangeD(0.0, 1.0));
					this.luminance = new HistogramD(numArray6, new RangeD(0.0, 1.0));
				}
			}
		}

		public Histogram Blue {
			get {
				return this.blue;
			}
		}

		public Histogram Gray {
			get {
				return this.gray;
			}
		}

		public Histogram Green {
			get {
				return this.green;
			}
		}

		public bool IsGrayscale {
			get {
				return this.grayscale;
			}
		}

		public HistogramD Luminance {
			get {
				return this.luminance;
			}
		}

		public int PixelsCount {
			get {
				return this.pixels;
			}
		}

		public Histogram Red {
			get {
				return this.red;
			}
		}

		public HistogramD Saturation {
			get {
				return this.saturation;
			}
		}
	}
}

