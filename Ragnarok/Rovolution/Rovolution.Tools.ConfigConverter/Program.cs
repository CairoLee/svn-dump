using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Rovolution.Tools.ConfigConverter {

	public class Program {
		private static string mAllSettings = "";


		public static void Main(string[] args) {
			// Array fo all config files, 'cause we dont want to convert every file..
			string[] settingFiles = Directory.GetFiles(@"C:\Users\Jonathan\Desktop\eathena-project\conf\battle\", "*.conf");

			foreach (string filepath in settingFiles) {
				ParseConfig(filepath);
			}

			Console.WriteLine("write command/value pairs..");
			File.WriteAllText("Config/Configs.cs", mAllSettings);
			Console.WriteLine("done");
			Console.ReadLine();
		}


		private static void ParseConfig(string filepath) {
			Console.WriteLine("parse " + Path.GetFileName(filepath));

			string filetype = Path.GetFileNameWithoutExtension(filepath);
			ParseSetting(ref filetype);
			// Add to global space
			if (mAllSettings.Length != 0) {
				mAllSettings += "\n\n";
			}
			mAllSettings += "/*******************************************************\n";
			mAllSettings += " * " + Path.GetFileName(filepath) + "\n";
			mAllSettings += " * " + filetype + "\n";
			mAllSettings += " ******************************************************/\n";

			// Build xml
			string xml = "";
			xml += "<?xml version=\"1.0\"?>\n";
			xml += GetHeader() + "\n";
			xml += "<PrivateSettingFileSerializeable xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\n";
			xml += "\t<FileName>" + filetype + ".cnfx</FileName>\n";
			xml += "\t<FileType>" + filetype + "</FileType>\n";
			xml += "\t<Settings>\n";

			string[] lines = File.ReadAllLines(filepath);
			bool isHead = true;
			List<string> lastComment = new List<string>();
			for (int i = 0; i < lines.Length; i++) {
				string line = lines[i].Trim();
				// TODO: This is hardcoded and assumes the file starts with a commented header
				//		 The end is an empty line
				if (isHead == true) {
					if (line.Length == 0) {
						isHead = false;
					}
					continue;
				}

				// Head was skiped, skip now comments and empty lines
				if (line.Length == 0) {
					continue;
				}
				if (line.StartsWith("//") == true) {
					lastComment.Add(line.Substring(2));
					continue;
				}
				int pos = line.IndexOf(':');
				if (pos == -1) {
					Console.WriteLine("\tinvalid line: " + line);
					continue;
				}

				string command = line.Substring(0, pos).Trim();
				string value = line.Substring(pos + 1).Trim();
				ParseSetting(ref command);
				ParseValue(ref value);

				// Add comments above
				if (lastComment.Count > 0) {
					xml += "\t\t<!--\n";
					foreach (string tmp in lastComment) {
						xml += "\t\t\t" + ParseComment(tmp) + "\n";
					}
					xml += "\t\t-->\n";
				}

				// Add key/value
				xml += "\t\t<Setting Name=\"" + command + "\" Value=\"" + value + "\" />\n";
				// Add internal
				AddInternal(command, value, lastComment);
				// Clear comments
				lastComment.Clear();
			}

			// Close doc
			xml += "\t</Settings>\n";
			xml += "</PrivateSettingFileSerializeable>\n";

			// Write file
			if (File.Exists("Config/Battle/" + filetype + ".cnfx")) {
				File.Delete("Config/Battle/" + filetype + ".cnfx");
			}
			File.WriteAllText("Config/Battle/" + filetype + ".cnfx", xml);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="setting"></param>
		/// <param name="value"></param>
		/// <param name="comments"></param>
		private static void AddInternal(string setting, string value, List<string> comments) {
			// Add comments
			if (comments.Count > 0) {
				// XML style <3
				mAllSettings += "/// <summary>\n";
				// First line solo
				mAllSettings += "/// " + comments[0] + "\n";
				comments.RemoveAt(0);
				// Each other line using para
				foreach (string comment in comments) {
					mAllSettings += "/// <para>" + comment + "</para>\n";
				}
				mAllSettings += "/// </summary>\n";
			}
			if (IsNumeric(value) == true) {
				mAllSettings += "public static int " + setting + " = " + value + ";\n";
				return;
			} else if (IsBool(ref value)) {
				mAllSettings += "public static bool " + setting + " = " + value + ";\n";
				return;
			}

			mAllSettings += "public static string " + setting + " = \"" + value + "\";\n";
			return;
		}

		private static bool IsNumeric(string value) {
			double d;
			int i;
			// TODO: confirm this..
			return (double.TryParse(value, out d) || int.TryParse(value.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber, null, out i));
		}

		private static bool IsBool(ref string value) {
			string valueClean = value.ToLower();
			if (valueClean == "on" || valueClean == "yes" || valueClean == "true" || valueClean == "1") {
				value = "true";
			} else if (valueClean == "off" || valueClean == "no" || valueClean == "false" || valueClean == "0") {
				value = "false";
			}
			return (value == "true" || value == "false");
		}

		private static void ParseSetting(ref string setting) {
			// #1 split by underscore (_)
			string[] parts = setting.Split('_', '.');
			// #2 make first char uppercase
			for (int i = 0; i < parts.Length; i++) {
				parts[i] = parts[i].Substring(0, 1).ToUpper() + parts[i].Substring(1);
			}
			// #3 join the parts
			setting = "";
			for (int i = 0; i < parts.Length; i++) {
				setting += parts[i];
			}
		}

		private static void ParseValue(ref string value) {
			if (value.ToLower() == "On") {
				value = "1";
			} else if (value.ToLower() == "off") {
				value = "0";
			}

			if (value == "1") {
				value = "True";
			} else if (value == "0") {
				value = "False";
			}

		}

		private static string ParseComment(string comment) {
			return comment;
		}

		private static string GetHeader() {
			string head = "";
			head += @"<!--(-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=)" + "\n";
			head += @"    ( ____                            ___             __                           )" + "\n";
			head += @"    (/\  _`\                         /\_ \           /\ \__  __                    )" + "\n";
			head += @"    (\ \ \L\ \    ___   __  __    ___\//\ \    __  __\ \ ,_\/\_\    ___     ___    )" + "\n";
			head += @"    ( \ \ ,  /   / __`\/\ \/\ \  / __`\\ \ \  /\ \/\ \\ \ \/\/\ \  / __`\ /' _ `\  )" + "\n";
			head += @"    (  \ \ \\ \ /\ \L\ \ \ \_/ |/\ \L\ \\_\ \_\ \ \_\ \\ \ \_\ \ \/\ \L\ \/\ \/\ \ )" + "\n";
			head += @"    (   \ \_\ \_\ \____/\ \___/ \ \____//\____\\ \____/ \ \__\\ \_\ \____/\ \_\ \_\)" + "\n";
			head += @"    (    \/_/\/ /\/___/  \/__/   \/___/ \/____/ \/___/   \/__/ \/_/\/___/  \/_/\/_/)" + "\n";
			head += @"    (                                                                              )" + "\n";
			head += @"    (                                                                              )" + "\n";
			head += @"    (                                  by GodLesZ                                  )" + "\n";
			head += @"    (-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=)" + "\n";
			head += @"    ( Type        : Configuration file                                             )" + "\n";
			head += @"    ( Description :                                                                )" + "\n";
			head += @"    (-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=)" + "\n";
			head += @" -->" + "\n";
			return head;
		}

	}

}
