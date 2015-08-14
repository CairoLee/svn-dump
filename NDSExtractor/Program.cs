using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDSExtractor.Library;

namespace NDSExtractor {

	public class Program {

		public static void Main(string[] args) {
			string filepath = @"D:\Download\4722_Ragnarok_NDS-VENOM\v-ragnar.nds";
			NDSFile nds = new NDSFile(filepath);
			ExtractNodes(nds.Files);

		}

		private static void ExtractNodes(List<NDSFileEntry> list) {
			foreach (NDSFileEntry file in list) {
			}

		}

	}

}
