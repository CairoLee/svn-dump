using System;
using System.IO;
using System.Drawing;

namespace GodLesZ.ROPrice.ImageTransparent {

	public class Program {
		private static bool mDelete = false;

		public static void Main(string[] args) {
			string basedir = @"C:\Users\GodLesZ\Desktop\data\texture\À¯ÀúÀÎÅÍÆäÀÌ½º\item\";

			//Console.Write("Full base dir: ");
			//string basedir = Console.ReadLine();

			Console.Write("Delete images after successfull convert? (y/n) ");
			string input = Console.ReadLine();
			if (input.ToLower() == "y") {
				mDelete = true;
			}

			string[] files = Directory.GetFiles(basedir, "*.bmp", SearchOption.AllDirectories);
			int i = 0;
			bool success;

			foreach (string filepath in files) {
				string filename = Path.GetFileNameWithoutExtension(filepath);
				Console.WriteLine("\t[" + i + "/" + files.Length + "]" + filename);
				success = TransImage(filepath);

				if (success == true && mDelete == true) {
					try {
						File.Delete(filepath);
					} catch (Exception ex) {
						Console.WriteLine("Failed to delete file: " + ex.Message);
					}
				}

				i++;
			}

			Console.WriteLine("Done");
			Console.ReadKey();
		}


		private static bool TransImage(string filepath) {
			Color trans = Color.Transparent;
			Bitmap bmp = null;

			try {
				using (bmp = (Bitmap)Bitmap.FromFile(filepath)) {
					bmp.MakeTransparent(Color.Fuchsia);

					string basepath = Path.GetDirectoryName(filepath);
					string filename = Path.GetFileNameWithoutExtension(filepath);
					string targetpath = Path.Combine(basepath, filename + ".png");
					if (File.Exists(targetpath)) {
						File.Delete(targetpath);
					}
					bmp.Save(targetpath, System.Drawing.Imaging.ImageFormat.Png);
				}
			} catch {
				Console.ForegroundColor = ConsoleColor.DarkMagenta;
				Console.WriteLine("\tFailed to open image: " + filepath);
				Console.ResetColor();
				return false;
			} finally {
				if (bmp != null) {
					bmp.Dispose();
					bmp = null;
				}
			}

			return true;
		}

	}

}
