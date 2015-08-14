using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Rovolution.Tools.StatpointConverter {

	public class Program {

		public static void Main(string[] args) {
			string filepath = @"C:\Users\Jonathan\Desktop\eathena-project\db\statpoint.txt";
			string[] lines = File.ReadAllLines(filepath);
			string xml = "";
			xml += "<?xml version=\"1.0\"?>\n";
			xml += "<Statpoint xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\n";

			int level = 0;
			foreach (string _line in lines) {
				string line = _line.Trim();
				if (line.Length == 0 || line.StartsWith("//")) {
					continue;

				}

				// Line = lavel = bonus
				level++;
				xml += "\t<Points Level=\"" + level + "\" Value=\"" + line + "\" />\n";
			}

			// Close doc
			xml += "</Statpoint>\n";

			// Write it
			File.WriteAllText("Config/Database/Statpoint.xml", xml);

			Console.WriteLine("done");
			Console.ReadLine();
		}

	}

}
