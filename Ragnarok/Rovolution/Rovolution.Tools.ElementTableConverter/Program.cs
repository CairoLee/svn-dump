using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Rovolution.Tools.ElementTableConverter {

	public class Program {
		private static string[] NAMES = new string[]{
			"Neutral",
			"Water",
			"Earth",
			"Fire",
			"Wind",
			"Poison",
			"Holy",
			"Shadow",
			"Ghost",
			"Undead"
		};


		public static void Main(string[] args) {
			string filepath = @"C:\Users\Jonathan\Desktop\eathena-project\db\attr_fix.txt";
			string[] lines = File.ReadAllLines(filepath);
			string xml = "";
			xml += "<?xml version=\"1.0\"?>\n";
			xml += "<Elements xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\n";

			int currentLevel = -1;
			int currentElement = -1;
			foreach (string _line in lines) {
				string line = _line.Trim();
				if (line.Length == 0 || line.StartsWith("//")) {
					continue;
				}

				int countComma = line.Count<char>(new Func<char,bool>(delegate(char c) { return (c == ','); }));
				if (countComma == 0) {
					continue;
				} else if(countComma == 1) {
					// New level
					// Close old table, if present
					if (currentLevel != -1) {
						xml += "\t</Level>\n";
					}
					currentLevel++;
					currentElement = 0; // Reset element
					xml += "\t<Level Level=\"" + currentLevel + "\">\n";
				} else if(countComma >= 5) {
					// Element list of current level
					// Fix: remove comment
					int pos = line.IndexOf(",  //");
					if (pos != -1) {
						line = line.Substring(0, pos).Trim();
					}
					string[] parts = line.Split(',');
					for (int i = 0; i < parts.Length; i++) {
						xml += "\t\t<Element Attack=\"" + NAMES[currentElement] + "\" Defence=\"" + NAMES[i] + "\" Value=\"" + parts[i].Trim() + "\" />\n";
					}

					currentElement++;
				}
			}

			// Close last table
			xml += "\t</Element>\n";

			// Close doc
			xml += "</Elements>\n";

			// Write it
			File.WriteAllText("Config/Database/ElementTable.xml", xml);

			Console.WriteLine("done");
			Console.ReadLine();
		}

	}

}
