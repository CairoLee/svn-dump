using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GodLesZ.Library.Imaging;
using GodLesZ.Library.Imaging.Filters;
using GodLesZ.Library.Imaging.Mathematic;

namespace GodLesZ.Library.Captcha {

	public class CaptchaImageProcessor {

		public Bitmap Image {
			get;
			internal set;
		}


		public CaptchaImageProcessor(Bitmap img) {
			Image = img;
		}


		public Bitmap ProcessImage(ImageProcessorSettings settings) {
			Bitmap output = Image.Clone() as Bitmap;

			if (settings.RemoveBorder > 0) {
				int x = settings.RemoveBorder;
				output = new Crop(new Rectangle(x, x, Image.Width - (2 * x), Image.Height - (2 * x))).Apply(Image);
			}

			if (settings.RemovePixelNoise > 0) {
				for (int i = 0; i < settings.RemovePixelNoise; i++) {
					// Use a copy for iteration
					Bitmap bitmap = new Bitmap(output);

					for (int j = 1; j < (output.Height - 1); j++) {
						for (int k = 1; k < (output.Width - 1); k++) {
							if (output.GetPixel(k, j).GetBrightness() < 0.5) {
								// Top left
								float tl = output.GetPixel(k - 1, j).GetBrightness();
								// Top right
								float tr = output.GetPixel(k + 1, j).GetBrightness();
								// Bottom left
								float bl = output.GetPixel(k, j - 1).GetBrightness();
								// Bottom right
								float br = output.GetPixel(k, j + 1).GetBrightness();

								// Test the edges
								if (tl > 0.5 && tr > 0.5) {
									bitmap.SetPixel(k, j, Color.White);
								}
								if (bl > 0.5 && br > 0.5) {
									bitmap.SetPixel(k, j, Color.White);
								}
							}
						}
					}
					output = bitmap;
				}
			}
			if (settings.LinearizeColors) {
				ImageStatistics statistics = new ImageStatistics(output);
				output = new LevelsLinear {
					InRed = new Range(statistics.Red.Min, statistics.Red.Max),
					InGreen = new Range(statistics.Green.Min, statistics.Green.Max),
					InBlue = new Range(statistics.Blue.Min, statistics.Blue.Max)
				}.Apply(output);
			}
			if (settings.InvertColors) {
				output = new Invert().Apply(output);
			}
			if (settings.ImageBlur) {
				output = new Blur().Apply(output);
			}
			if (settings.BrightnessThreshold > 0) {
				// Brightness threshold is in percent..
				decimal threshold = (decimal)settings.BrightnessThreshold / 100M;
				output = new Threshold(Convert.ToByte((decimal)(threshold * 255M)), 255).Apply(output);
			}

			return output;
		}

	}

}
