namespace GodLesZ.Library.Imaging.Filters {
	using System.Drawing;
	using System.Drawing.Imaging;

	public class SISThreshold : IFilter {
		private byte threshold;

		public unsafe Bitmap Apply(Bitmap srcImg) {
			int width = srcImg.Width;
			int height = srcImg.Height;
			bool flag = false;
			if (srcImg.PixelFormat != PixelFormat.Format8bppIndexed) {
				flag = true;
				IFilter filter = new GrayscaleRMY();
				srcImg = filter.Apply(srcImg);
			}
			BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
			Bitmap bitmap = GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height);
			BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
			int stride = bitmapdata.Stride;
			int num4 = stride - width;
			int num5 = width - 1;
			int num6 = height - 1;
			double num10 = 0.0;
			double num11 = 0.0;
			byte* numPtr = (byte*)((byte*)bitmapdata.Scan0.ToPointer() + stride);
			byte* numPtr2 = (byte*)data2.Scan0.ToPointer();
			for (int i = 1; i < num6; i++) {
				numPtr++;
				int num13 = 1;
				while (num13 < num5) {
					double num7 = numPtr[1] - numPtr[-1];
					double num8 = numPtr[stride] - numPtr[-stride];
					double num9 = (num7 > num8) ? num7 : num8;
					num10 += num9;
					num11 += num9 * numPtr[0];
					num13++;
					numPtr++;
				}
				numPtr += num4 + 1;
			}
			this.threshold = (num10 == 0.0) ? ((byte)0) : ((byte)(num11 / num10));
			numPtr = (byte*)bitmapdata.Scan0.ToPointer();
			for (int j = 0; j < height; j++) {
				int num15 = 0;
				while (num15 < width) {
					numPtr2[0] = (numPtr[0] <= this.threshold) ? ((byte)0) : ((byte)0xff);
					num15++;
					numPtr++;
					numPtr2++;
				}
				numPtr += num4;
				numPtr2 += num4;
			}
			bitmap.UnlockBits(data2);
			srcImg.UnlockBits(bitmapdata);
			if (flag) {
				srcImg.Dispose();
			}
			return bitmap;
		}

		public byte Threshold {
			get {
				return this.threshold;
			}
		}
	}
}

