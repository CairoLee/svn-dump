using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BinExtract {
	class Program {
		static void Main(string[] args) {
			if (args == null || args.Length == 0) {
				Console.WriteLine("Drag some .bin files on me!");
				Console.Read();
				return;
			}

			foreach (var filepath in args) {
				ExtractBin(filepath);
			}
		}

		private static void ExtractBin(string filepath) {
			Console.WriteLine("Seek in " + Path.GetFileName(filepath));
			string bufString = File.ReadAllText(filepath);
			int p = bufString.IndexOf("PNG");
			if (p == -1) {
				return;
			}
			// PNG header starts 1 byte before
			p--;

			byte[] buf = File.ReadAllBytes(filepath);
			byte[] fileData = new byte[buf.Length - p];
			Buffer.BlockCopy(buf, p, fileData, 0, fileData.Length);
			Console.WriteLine("dump " + Path.GetFileName(filepath));
			File.WriteAllBytes(Path.Combine(Path.GetDirectoryName(filepath), Path.GetFileNameWithoutExtension(filepath)) + ".png", fileData);
		}
	}
}
