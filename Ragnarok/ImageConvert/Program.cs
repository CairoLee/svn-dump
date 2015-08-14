using System;
using System.Drawing;
using System.IO;

namespace ImageConvert {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("Make fuchsia trans? (y/n)");
			bool makeTrans = (Console.ReadLine().ToLower() == "y");

			string[] images = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.bmp");
			Console.WriteLine("found " + images.Length + " images..");
			foreach (string filepath in images) {
				Console.WriteLine("- parse " + Path.GetFileName(filepath));
				try {
					Bitmap bmp = null;
					string destinationPath = Path.Combine(Path.GetDirectoryName(filepath), Path.GetFileNameWithoutExtension(filepath));
					destinationPath = destinationPath + ".png";
					//if (File.Exists(destinationPath)) {
					//	File.Delete(destinationPath);
					//}

					using (Bitmap tmpBmp = (Bitmap)Bitmap.FromFile(filepath)) {
						bmp = new Bitmap(tmpBmp.Width, tmpBmp.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

						for (int x = 0; x < bmp.Width; x++) {
							for (int y = 0; y < bmp.Height; y++) {
								Color c = tmpBmp.GetPixel(x, y);
								if (makeTrans && c.R == 255 && c.G == 0 && c.B == 255) {
									bmp.SetPixel(x, y, Color.Transparent);
								} else {
									bmp.SetPixel(x, y, c);
								}
							}
						}
					}


					bmp.Save(destinationPath, System.Drawing.Imaging.ImageFormat.Png);
					if (destinationPath != filepath) {
						File.Delete(filepath);
					}
				} catch {
					Console.WriteLine("- failed!");
				}
			}
		}
	}
}
