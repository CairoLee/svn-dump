using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using GodLesZ.Library.Ragnarok.Grf;

namespace GodLesZ.Ragnarok.SkillCalculator.Library {

	[XmlRoot("MobDBMobList")]
	public class MobDBMobList : List<MobDBMob> {
		private static string mMoblistFilepath = "";

		public static string MoblistFilepath {
			get {
				if (mMoblistFilepath == "") {
					mMoblistFilepath = Environment.CurrentDirectory + @"\Moblist.xml";
				}
				return mMoblistFilepath;
			}
		}

		public event ReportUpdateHandler ReportUpdate;


		public MobDBMobList()
			: base() {
		}


		public bool LoadMobList() {

			ReportUpdate("Mobs");

			if (File.Exists(MoblistFilepath) == false) {
				return false;
			}

			XmlSerializer xml = new XmlSerializer(typeof(MobDBMobList));
			try {
				using (FileStream fs = new FileStream(MoblistFilepath, FileMode.Open)) {
					MobDBMobList mobs = (MobDBMobList)xml.Deserialize(fs);
					if (mobs != null && mobs.Count > 0) {
						AddRange(mobs.ToArray());
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

		public bool ParseDB(string mobdbPath, RoGrfFile grf) {

			if (File.Exists(mobdbPath) == false) {
				return false;
			}

			string[] lines = File.ReadAllLines(mobdbPath);
			for (int i = 0; i < lines.Length; i++) {
				string line = lines[i].Trim();
				if (line.Length == 0 || line.StartsWith("//") == true) {
					continue;
				}

				// ID,Sprite_Name,kROName,iROName,LV,HP,SP,EXP,JEXP,Range1,ATK1,ATK2,DEF,MDEF,STR,AGI,VIT,INT,DEX,LUK,Range2,Range3,Scale,Race,Element,Mode,Speed,aDelay,aMotion,dMotion,MEXP,ExpPer,MVP1id,MVP1per,MVP2id,MVP2per,MVP3id,MVP3per,Drop1id,Drop1per,Drop2id,Drop2per,Drop3id,Drop3per,Drop4id,Drop4per,Drop5id,Drop5per,Drop6id,Drop6per,Drop7id,Drop7per,Drop8id,Drop8per,Drop9id,Drop9per,DropCardid,DropCardper
				string[] parts = line.Split(new char[] { ',' }, StringSplitOptions.None);
				if (parts.Length != 58) {
					continue;
				}

				MobDBMob mob = new MobDBMob();
				mob.ID = int.Parse(parts[0]);
				mob.Sprite_Name = parts[1].Trim();
				mob.kROName = parts[2].Trim();
				mob.iROName = parts[3].Trim();
				mob.LV = int.Parse(parts[4]);
				mob.HP = int.Parse(parts[5]);
				mob.SP = int.Parse(parts[6]);
				mob.EXP = int.Parse(parts[7]);
				mob.JEXP = int.Parse(parts[8]);
				mob.Range1 = int.Parse(parts[9]);
				mob.ATK1 = int.Parse(parts[10]);
				mob.ATK2 = int.Parse(parts[11]);
				mob.DEF = int.Parse(parts[12]);
				mob.MDEF = int.Parse(parts[13]);
				mob.STR = int.Parse(parts[14]);
				mob.AGI = int.Parse(parts[15]);
				mob.VIT = int.Parse(parts[16]);
				mob.INT = int.Parse(parts[17]);
				mob.DEX = int.Parse(parts[18]);
				mob.LUK = int.Parse(parts[19]);
				mob.Range2 = int.Parse(parts[20]);
				mob.Range3 = int.Parse(parts[21]);
				mob.Scale = (EScale)int.Parse(parts[22]);
				mob.Race = (ERace)int.Parse(parts[23]);
				mob.Element = (EElement)(int.Parse(parts[24]) % 10);
				mob.ElementLevel = (int.Parse(parts[24]) / 20);
				mob.Mode = ParsePossibleHex(parts[25]);
				mob.Speed = int.Parse(parts[26]);
				mob.aDelay = int.Parse(parts[27]);
				mob.aMotion = int.Parse(parts[28]);
				mob.dMotion = int.Parse(parts[29]);
				mob.MEXP = int.Parse(parts[30]);
				mob.MExpPer = int.Parse(parts[31]);

				for (int c = 32; c <= 37; c += 2) {
					int mvpID = int.Parse(parts[c]);
					int mvpChance = int.Parse(parts[c + 1]);
					if (mvpID > 0 && mvpChance > 0) {
						mob.DropsMvp.Add(new MobDBMobDrop(mvpID, mvpChance));
					}
				}
				for (int c = 38; c <= 56; c += 2) {
					int dropID = int.Parse(parts[c]);
					int dropChance = int.Parse(parts[c + 1]);
					if (dropID > 0 && dropChance > 0) {
						mob.Drops.Add(new MobDBMobDrop(dropID, dropChance));
					}
				}

				if (mob.ImageExists == false) {
					// Load Image..
					// We try to get the sprite name based on eAthena's Sprite_Name field..
					RoGrfFileItem grfItem = grf.GetFileByName("data/sprite/¸ó½ºÅÍ/" + mob.Sprite_Name.ToLower() + ".spr");
					if (grfItem != null) {
						grf.CacheFileData(grfItem, true);

						mob.ExportImage(grfItem);
					} else {
						System.Diagnostics.Debug.WriteLine("Mob sprite not found: " + mob.ToString());
					}
				}

				ReportUpdate("[Mob] " + mob.ToString());

				Add(mob);
			}


			return true;
		}

		public bool ExportMobList() {
			ReportUpdate("Export mobs");

			if (Count == 0) {
				return false;
			}

			XmlSerializer xml = new XmlSerializer(GetType());
			try {
				if (File.Exists(MoblistFilepath) == true) {
					File.Delete(MoblistFilepath);
				}

				using (FileStream fs = new FileStream(MoblistFilepath, FileMode.Create)) {
					xml.Serialize(fs, this);
				}
			} catch {
				return false;
			}

			return true;
		}


		private static int ParsePossibleHex(string text) {
			int num = 0;
			if (text.StartsWith("0x") == true) {
				text = text.Substring(2);
			}
			if (int.TryParse(text, System.Globalization.NumberStyles.HexNumber, null, out num) == true) {
				return num;
			}
			if (int.TryParse(text, out num) == true) {
				return num;
			}

			return 0;
		}

	}

}
