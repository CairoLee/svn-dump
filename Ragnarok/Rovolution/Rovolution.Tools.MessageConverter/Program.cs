using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Rovolution.Tools.MessageConverter {

	public class Program {

		public static void Main(string[] args) {
			string filepath = @"C:\Users\Jonathan\Desktop\eathena-project\conf\msg_athena.conf";
			string[] lines = File.ReadAllLines(filepath);

			string xml = "";
			xml += "<?xml version=\"1.0\"?>\n";
			xml += "<Messages xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\n";

			for (int i = 0; i < lines.Length; i++) {
				string line = lines[i].Trim();
				if (line.Length == 0 || line.StartsWith("//")) {
					continue;
				}

				int pos = line.IndexOf(':');
				if (pos == -1) {
					continue;
				}

				string indexString = line.Substring(0, pos).Trim();
				string message = line.Substring(pos + 1).Trim();

				message = ParseArguments(message);

				xml += "\t<Message Index=\"" + indexString + "\">" + message + "</Message>\n";
			}

			// Close doc
			xml += "</Messages>\n";

			// Write config
			if (File.Exists("Config/Internal/Messages.xml")) {
				File.Delete("Config/Internal/Messages.xml");
			}
			File.WriteAllText("Config/Internal/Messages.xml", xml);

			Console.WriteLine("done");
			Console.ReadLine();
		}


		private static string ParseArguments(string message) {
			return ParseArguments(message, 0, 0);
		}

		private static string ParseArguments(string message, int start, int replaces) {
			// Replace %<char>
			// Note: %% escape the sign

			// Dont overflow..
			if (start >= message.Length) {
				return message;
			}

			int pos = message.IndexOf('%', start);
			// Dont touch end of string
			if (pos == -1 || (pos + 1) >= message.Length) {
				return message;
			}

			// Check for escape
			if (message[pos + 1] == '%') {
				// Next recursice call
				return ParseArguments(message, pos + 2, replaces);
			}

			// No escape, check for common chars (s, d)
			char c = message[pos + 1];
			if (c == 'd' || c == 's') {
				message = message.Substring(0, pos) + "{" + replaces + "}" + message.Substring(pos + 2);
				replaces++;
				return ParseArguments(message, pos + 2, replaces);
			}

			Console.WriteLine("\tunable to convert: " + message);
			return message;
		}

	}

}
