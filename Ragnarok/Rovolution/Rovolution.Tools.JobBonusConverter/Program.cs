using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Rovolution.Tools.JobBonusConverter {

	public class Program {

		public static void Main(string[] args) {
			string filepath = @"C:\Users\Jonathan\Desktop\eathena-project\db\job_db2.txt";
			string[] lines = File.ReadAllLines(filepath);
			string xml = "";
			xml += "<?xml version=\"1.0\"?>\n";
			xml += "<JobBonus xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\n";

			string lastComment = "";
			foreach (string _line in lines) {
				string line = _line.Trim();
				if (line.Length == 0) {
					continue;
				}
				if (line.StartsWith("//")) {
					lastComment = line.Substring(2).Trim(); // Cap //
					continue;
				}
	
				// JobID,JobLv1,JobLv2,JobLv3,...
				string[] parts = line.Split(',');
				int[] partsClean = Array.ConvertAll<string, int>(parts,
					delegate(string s) {
						int i;
						if (s.ToLower().StartsWith("0x")) {
							s = s.Substring(2);
							return int.Parse(s, System.Globalization.NumberStyles.HexNumber);
						}
						if (int.TryParse(s, out i)) { return i; }
						throw new ArgumentException("Unable to convert string: " + s, "s");
					}
				);

				// Add last comment, if given
				if (lastComment.Length > 0) {
					xml += "\t<!-- " + lastComment + " -->\n";
					lastComment = "";
				}
				// Add job
				xml += "\t<Job ID=\"" + partsClean[0] + "\">\n";
				// Add eah bonus, if > 0
				for (int i = 1; i < partsClean.Length; i++) {
					// Skip zero vars
					if (partsClean[i] == 0) {
						continue;
					}
					string typName = GetTypeName(partsClean[i]);
					xml += "\t\t<Bonus Type=\"" + typName + "\" Level=\"" + i + "\" />\n";
				}

				// Close job
				xml += "\t</Job>\n";
			}

			// Close doc
			xml += "</JobBonus>\n";

			// Write it
			File.WriteAllText("Config/Database/JobBonus.xml", xml);

			Console.WriteLine("done");
			Console.ReadLine();
		}

		private static string GetTypeName(int i) {
			switch (i) {
				default:
					throw new ArgumentException("Unknown value: " + i, "i");

				case 1:
					return "Str";
				case 2:
					return "Agi";
				case 3:
					return "Vit";
				case 4:
					return "Int";
				case 5:
					return "Dex";
				case 6:
					return "Luk";
			}
		}

	}

}
