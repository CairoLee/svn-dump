using System.Drawing;

namespace GrfEditor.Library {

	public static class Tools {

		public static Image ScalePercent(Image SourceImage, int Percent) {
			if (SourceImage == null) {
				return null;
			}
			if (Percent == 100) {
				return SourceImage;
			}

			return ScalePercentPixel((Bitmap)SourceImage, Percent, null);
		}

		public static Image ScalePercentPixel(Bitmap SourceImage, int Percent, System.ComponentModel.ProgressChangedEventHandler Handler) {
			if (SourceImage == null) {
				return null;
			}
			if (Percent == 100) {
				return SourceImage;
			}

			float nPercent = ((float)Percent / 100);

			int sourceWidth = SourceImage.Width;
			int sourceHeight = SourceImage.Height;

			int destWidth = (int)(sourceWidth * nPercent);
			int destHeight = (int)(sourceHeight * nPercent);

			int maxIterations = (sourceWidth * sourceHeight);
			int currentProgress = 0;

			Bitmap b = new Bitmap(destWidth, destHeight);

			using (Graphics g = Graphics.FromImage(b)) {
				for (int x = 0, i = 0; x < SourceImage.Width; x++) {
					for (int y = 0; y < SourceImage.Height; y++) {
						Color drawColor = SourceImage.GetPixel(x, y);
						g.FillRectangle(new SolidBrush(drawColor), new RectangleF((float)x * nPercent, (float)y * nPercent, nPercent, nPercent));

						if (Handler != null) {
							i++;
							int p = (int)(((float)i / maxIterations) * 100);
							if (p > currentProgress) {
								currentProgress = p;
								Handler(null, new System.ComponentModel.ProgressChangedEventArgs(p, null));
							}
						}
					}
				}
			}

			return b;
		}

	}

}
