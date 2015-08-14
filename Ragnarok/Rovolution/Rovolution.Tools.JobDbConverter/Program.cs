using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Rovolution.Tools.JobDbConverter {

	public class Program {

		public static void Main(string[] args) {
			string filepath = @"C:\Users\Jonathan\Desktop\eathena-project\db\job_db1.txt";
			string[] lines = File.ReadAllLines(filepath);
			string xml = "";
			xml += "<?xml version=\"1.0\"?>\n";
			xml += "<JobModifer xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\n";

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

				// JobID,Weight,HPFactor,HPMultiplicator,SPFactor,Unarmed,Dagger,1HSword,2HSword,1HSpear,2HSpear,1HAxe,2HAxe,1HMace,2HMace(unused),Rod,Bow,Knuckle,Instrument,Whip,Book,Katar,Revolver,Rifle,Gatling Gun,Shotgun,Grenade Launcher,Fuuma Shuriken,2HStaff
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

				// Modifer 
				xml += "\t\t<Mod Name=\"Weight\" Value=\"" + partsClean[1] + "\" />\n";
				xml += "\t\t<Mod Name=\"HPFactor\" Value=\"" + partsClean[2] + "\" />\n";
				xml += "\t\t<Mod Name=\"HPMultiplicator\" Value=\"" + partsClean[3] + "\" />\n";
				xml += "\t\t<Mod Name=\"SPFactor\" Value=\"" + partsClean[4] + "\" />\n";
				// Weapon types
				for (int i = 5; i < partsClean.Length; i++) {
					int type = (i - 5); // Types start with 0

					xml += "\t\t<Weapon Type=\"" + type + "\" Value=\"" + partsClean[i] + "\" />\n";
				}

				// Close job node
				xml += "\t</Job>\n";
			}

			// Close doc
			xml += "</JobModifer>\n";
			// Write it
			File.WriteAllText("Config/Database/JobModifer.xml", xml);

			Console.WriteLine("done");
			Console.ReadLine();
		}

	}

}
