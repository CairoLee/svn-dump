using System;
using System.Drawing;
using System.IO;

namespace MapImageResize {
	class Program {
		static void Main(string[] args) {
			string[] images = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.png");

			foreach (string filepath in images) {
				Console.WriteLine(" - parse " + Path.GetFileName(filepath));

				try {
					Bitmap newBmp;
					using (Bitmap bmp = (Bitmap)Bitmap.FromFile(filepath)) {
						if (bmp.Width == 40 && bmp.Height == 40) {
							continue;
						}

						newBmp = new Bitmap(40, 40);
						using (Graphics g = Graphics.FromImage(newBmp)) {
							g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
							g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
							g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
							g.DrawImage(bmp, 0, 0, newBmp.Width, newBmp.Height);
						}
					}

					File.Delete(filepath);
					newBmp.Save(filepath, System.Drawing.Imaging.ImageFormat.Png);

				} catch (Exception ex) {
					Console.WriteLine(" - failed!");
				}

			}
		}
	}
}
