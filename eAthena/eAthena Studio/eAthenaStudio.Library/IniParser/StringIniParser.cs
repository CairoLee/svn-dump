using System.IO;

namespace eAthenaStudio.Library.IniParser {

	public class StringIniParser : StreamIniDataParser {

		public IniData ParseString(string dataStr) {
			return ParseString(dataStr, false);
		}

		public IniData ParseString(string dataStr, bool relaxedIniRead) {
			using (MemoryStream ms = new MemoryStream(System.Text.Encoding.Default.GetBytes(dataStr), false)) {
				using (StreamReader s = new StreamReader(ms)) {
					return ReadData(s, relaxedIniRead);
				}
			}
		}

		public string WriteString(IniData iniData) {
			using (MemoryStream ms = new MemoryStream()) {
				using (StreamWriter sw = new StreamWriter(ms)) {
					WriteData(sw, iniData);
					sw.Flush();

					string result = System.Text.Encoding.UTF8.GetString(ms.ToArray());

					ms.Close();
					sw.Close();

					return result;
				}
			}
		}

	}
}
