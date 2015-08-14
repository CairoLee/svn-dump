namespace GodLesZ.Library.Imaging.Filters {
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;

	public class EuclideanColorFiltering : IFilter {
		private Color center;
		private Color fill;
		private bool fillOutside;
		private short radius;

		public EuclideanColorFiltering() {
			this.radius = 100;
			this.center = Color.FromArgb(0xff, 0xff, 0xff);
			this.fill = Color.FromArgb(0, 0, 0);
			this.fillOutside = true;
		}

		public EuclideanColorFiltering(Color center, short radius) {
			this.radius = 100;
			this.center = Color.FromArgb(0xff, 0xff, 0xff);
			this.fill = Color.FromArgb(0, 0, 0);
			this.fillOutside = true;
			this.center = center;
			this.radius = radius;
		}

		public unsafe Bitmap Apply(Bitmap srcImg) {
			if (srcImg.PixelFormat != PixelFormat.Format24bppRgb) {
				throw new ArgumentException();
			}
			int width = srcImg.Width;
			int height = srcImg.Height;
			BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
			Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
			BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			int num3 = bitmapdata.Stride - (width * 3);
			byte r = this.center.R;
			byte g = this.center.G;
			byte b = this.center.B;
			byte num10 = this.fill.R;
			byte num11 = this.fill.G;
			byte num12 = this.fill.B;
			byte* numPtr = (byte*)bitmapdata.Scan0.ToPointer();
			byte* numPtr2 = (byte*)data2.Scan0.ToPointer();
			for (int i = 0; i < height; i++) {
				int num14 = 0;
				while (num14 < width) {
					byte num4 = numPtr[2];
					byte num5 = numPtr[1];
					byte num6 = numPtr[0];
					if (((int)Math.Sqrt((Math.Pow((double)(num4 - r), 2.0) + Math.Pow((double)(num5 - g), 2.0)) + Math.Pow((double)(num6 - b), 2.0))) <= this.radius) {
						if (this.fillOutside) {
							numPtr2[2] = num4;
							numPtr2[1] = num5;
							numPtr2[0] = num6;
						} else {
							numPtr2[2] = num10;
							numPtr2[1] = num11;
							numPtr2[0] = num12;
						}
					} else if (this.fillOutside) {
						numPtr2[2] = num10;
						numPtr2[1] = num11;
						numPtr2[0] = num12;
					} else {
						numPtr2[2] = num4;
						numPtr2[1] = num5;
						numPtr2[0] = num6;
					}
					num14++;
					numPtr += 3;
					numPtr2 += 3;
				}
				numPtr += num3;
				numPtr2 += num3;
			}
			bitmap.UnlockBits(data2);
			srcImg.UnlockBits(bitmapdata);
			return bitmap;
		}

		public Color CenterColor {
			get {
				return this.center;
			}
			set {
				this.center = value;
			}
		}

		public Color FillColor {
			get {
				return this.fill;
			}
			set {
				this.fill = value;
			}
		}

		public bool FillOutside {
			get {
				return this.fillOutside;
			}
			set {
				this.fillOutside = value;
			}
		}

		public short Radius {
			get {
				return this.radius;
			}
			set {
				this.radius = (short)Math.Max((short)0, Math.Min((short)450, value));
			}
		}
	}
}

