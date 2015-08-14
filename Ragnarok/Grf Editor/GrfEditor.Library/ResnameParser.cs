using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using GodLesZ.Library.Ragnarok.Grf;

namespace GrfEditor.Library {

	public class ResnameParser {
		private Dictionary<int, string> mID2Korea = new Dictionary<int, string>();
		private Dictionary<string, string> mEn2Korea = new Dictionary<string, string>();

		public Dictionary<int, string> ID2Korea {
			get { return mID2Korea; }
		}

		public Dictionary<string, string> En2Korea {
			get { return mEn2Korea; }
		}



		public ResnameParser() {
		}


		public void Clear() {
			mEn2Korea.Clear();
			mID2Korea.Clear();
		}

		public void Parse(RoGrfFile grf) {
			Clear();

			RoGrfFileItem item = grf.GetFileByName("data/idnum2itemresnametable.txt");
			if (item != null) {
				Parse(grf.GetFileData(item, true), true);

				// we need the ID to fetch korea name.. so this is the right place
				RoGrfFileItem itemDisplay = grf.GetFileByName("data/idnum2itemdisplaynametable.txt");
				if (itemDisplay != null) {
					Parse(grf.GetFileData(itemDisplay, true), false);
				}
			}
		}


		private void Parse(byte[] fileBuf, bool isID2Korea) {
			string fileDataString = Encoding.Default.GetString(fileBuf);
			string[] lines = fileDataString.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

			Regex re = new Regex(@"([0-9]+)#([^\#]+)#$");
			Match m = null;
			foreach (string line in lines) {
				string curLine = line.Trim();
				if (curLine.Length < 2 || curLine.StartsWith("//") == true) {
					continue;
				}
				if ((m = re.Match(curLine)) == null || m.Success == false || m.Groups.Count != 3) {
					continue;
				}

				string idString = m.Groups[1].Captures[0].Value.Trim();
				string nameString = m.Groups[2].Captures[0].Value.Trim();
				int realId = int.Parse(idString);

				if (isID2Korea == true) {
					if (mID2Korea.ContainsKey(realId) == true) {
						mID2Korea[realId] = nameString;
					} else {
						mID2Korea.Add(realId, nameString);
					}
				} else {
					if (mID2Korea.ContainsKey(realId) == false) {
						// failed.. oO
					} else {
						nameString = nameString.ToLower();
						if (mEn2Korea.ContainsKey(nameString) == true) {
							mEn2Korea[nameString] = mID2Korea[realId];
						} else {
							mEn2Korea.Add(nameString, mID2Korea[realId]);
						}
					}
				}
			}

		}

	}

}
