using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using GodLesZ.Library.Ragnarok.Grf;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace GodLesZ.Ragnarok.SkillCalculator.Library {

	[XmlRoot("SkillDBSkillList")]
	public class SkillDBSkillList : List<SkillDBSkill> {
		const int MAX_SKILL_ID = 8000;

		private static string mSkilllistFilepath = "";

		public static string SkilllistFilepath {
			get {
				if (mSkilllistFilepath == "") {
					mSkilllistFilepath = Environment.CurrentDirectory + @"\Skilllist.xml";
				}
				return mSkilllistFilepath;
			}
		}


		private Dictionary<string, SkillDBSkill> mSkillsTemp;

		public event ReportUpdateHandler ReportUpdate;


		public SkillDBSkillList() {
			mSkillsTemp = new Dictionary<string, SkillDBSkill>();
		}


		public bool LoadSkillList() {

			ReportUpdate("Skills");

			if (File.Exists(SkilllistFilepath) == false) {
				return false;
			}

			XmlSerializer xml = new XmlSerializer(typeof(SkillDBSkillList));
			try {
				using (FileStream fs = new FileStream(SkilllistFilepath, FileMode.Open)) {
					SkillDBSkillList skills = (SkillDBSkillList)xml.Deserialize(fs);
					if (skills != null && skills.Count > 0) {
						AddRange(skills.ToArray());
					}
				}
			} catch {
				return false;
			}

			if (Count == 0) {
				return false;
			}
			return true;
		}

		public bool ParseDB(string skilldbPath, RoGrfFile grf) {
			Clear();
			mSkillsTemp.Clear();


			// need 2 files..
			//		- eAthena's skill_db.txt for delay & usage
			//		- GRF's skilldisplaynametable.txt

			RoGrfFileItem itemSkillNameTable = grf.GetFileByName("data/skillnametable.txt");
			if (itemSkillNameTable == null) {
				return false;
			}

			byte[] skillNameTableBuf = grf.GetFileData(itemSkillNameTable, true);
			string skillNameTableString = Encoding.Default.GetString(skillNameTableBuf);
			string[] skillNameTableLines = skillNameTableString.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

			// cleanup mem
			skillNameTableBuf = null;
			itemSkillNameTable = null;
			skillNameTableString = null;

			if (skillNameTableLines == null || skillNameTableLines.Length == 0 || ParseSkillNameTable(skillNameTableLines) == false) {
				return false;
			}

			if (ParseSkillDB(skilldbPath, grf) == false) {
				return false;
			}

			// we got 2 lists.. merge them
			if (MergeDBs() == false) {
				return false;
			}

			return true;
		}

		public bool ExportSkillList() {
			if (Count == 0) {
				return false;
			}

			ReportUpdate("Export skills");

			XmlSerializer xml = new XmlSerializer(GetType());
			try {
				if (File.Exists(SkilllistFilepath) == true) {
					File.Delete(SkilllistFilepath);
				}

				using (FileStream fs = new FileStream(SkilllistFilepath, FileMode.Create)) {
					xml.Serialize(fs, this);
				}
			} catch {
				return false;
			}

			return true;
		}


		private bool ParseSkillNameTable(string[] Lines) {
			if (Lines.Length == 0) {
				return false;
			}

			ReportUpdate("Parse skillnametable.txt");

			Regex reSkillLine = new Regex("^([^#]*)#([^#]*)#$", RegexOptions.Compiled);
			Match mSkillLine = null;
			for (int i = 0; i < Lines.Length; i++) {
				string line = Lines[i].Trim();
				if (line.Length == 0 || line.StartsWith("//") == true) {
					continue;
				}

				// GRAVNAME#Display_Name#
				if ((mSkillLine = reSkillLine.Match(line)) == null || mSkillLine.Success == false) {
					continue;
				}

				string grvName = mSkillLine.Groups[1].Captures[0].Value.Trim();
				string dispName = mSkillLine.Groups[2].Captures[0].Value.Trim();

				// create skill obj
				SkillDBSkill skill = new SkillDBSkill();
				skill.NameEathena = grvName;
				skill.Name = dispName;

				ReportUpdate("[Skill Name] " + dispName + "(" + grvName + ")");

				mSkillsTemp.Add(grvName, skill);
			}
			return true;
		}

		private bool ParseSkillDB(string skilldbPath, RoGrfFile grf) {
			ReportUpdate("skill_db.txt");

			if (File.Exists(skilldbPath) == false) {
				return false;
			}

			string[] lines = File.ReadAllLines(skilldbPath);
			for (int i = 0; i < lines.Length; i++) {
				string line = lines[i].Trim();
				if (line.Length == 0 || line.StartsWith("//") == true) {
					continue;
				}

				string[] parts = line.Split(new char[] { ',' }, StringSplitOptions.None);
				if (parts.Length != 17) {
					continue;
				}
				//id,range,hit,inf,element,nk,splash,max,list_num,castcancel,cast_defence_rate,inf2,maxcount,skill_type,blow_count,name,description
				/*
					00: id
					range
					hit
					inf
					04: element
					nk
					splash
					max
					list_num
					castcancel
					cast_defence_rate
					inf2
					maxcount
					skill_type
					blow_count
					15: name
					16: description
				 */
				int id = int.Parse(parts[0].Trim());
				string grvName = parts[15].Trim();
				string eaName = parts[16].Trim();
				// Element may be splitted by level
				// ele_on_lv_1:ele_on_lv_2: ..
				// in this case, choose first element
				EElement eaElement;
				if (parts[4].Contains(':') == true) {
					string[] eleParts = parts[4].Split(':');
					eaElement = (EElement)int.Parse(eleParts[0].Trim());
				} else {
					eaElement = (EElement)int.Parse(parts[4].Trim());
				}

				if (mSkillsTemp.ContainsKey(grvName) == false) {
					// mh..
					mSkillsTemp.Remove(grvName);
					System.Diagnostics.Debug.WriteLine("Skill not found in skill_db.txt: " + grvName);
					continue;
				}
				// Skip NPC, Item, Cash, All Skills..
				if (grvName.StartsWith("NPC_") == true || grvName.StartsWith("ITEM_") == true || grvName.StartsWith("CASH_") == true || grvName.StartsWith("ALL_") == true || grvName.StartsWith("MER_") == true) {
					mSkillsTemp.Remove(grvName);
					continue;
				}
				
				if (id >= MAX_SKILL_ID) {
					mSkillsTemp.Remove(grvName);
					continue;
				}

				mSkillsTemp[grvName].ID = id;
				mSkillsTemp[grvName].Element = eaElement;
				mSkillsTemp[grvName].NameEathena = eaName;

				ReportUpdate("[Skill] " + mSkillsTemp[grvName].ToString());

				if (mSkillsTemp[grvName].ImageExists == false) {

					// Load Image..
					// We try to get the sprite name based on eAthena's Sprite_Name field..
					RoGrfFileItem grfItem = grf.GetFileByName("data/texture/À¯ÀúÀÎÅÍÆäÀÌ½º/item/" + grvName.ToLower() + ".bmp");
					if (grfItem != null) {
						grf.CacheFileData(grfItem, true);

						mSkillsTemp[grvName].ExportImage(grfItem);
					} else {
						Debug.WriteLine("Skill image not found: " + mSkillsTemp[grvName].ToString());
					}
				}

			}

			return true;
		}

		private bool MergeDBs() {
			bool result = true;

			ReportUpdate("Merge skill data");

			try {
				// all work was done in ParseSkillDB
				// we just need to copy in the values from temp list, orded by ID
				SkillDBSkill[] skills = new SkillDBSkill[mSkillsTemp.Count];
				mSkillsTemp.Values.CopyTo(skills, 0);

				AddRange(skills);
				for (int i = 0; i < Count; i++) {
					if (this[i].ID == 0) {
						this.RemoveAt(i);
						i--;
					}
				}
				Sort(new SkillDBSkillComparer());
			} catch {
				result = false;
				Clear();
			} finally {
				// anyways, clear temp table (mem clean)
				mSkillsTemp.Clear();
			}

			return result;
		}
	}

}
