using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ZenAIConfigPanel.Library {

	public class HomuConfig {
		public const string Filename = "Config.lua";

		private HomuSkill mAS_AMI_BULW = new HomuSkill("AS_AMI_BULW", "Bulwark", 40, 5);
		private HomuSkill mAS_AMI_CAST = new HomuSkill("AS_AMI_CAST", "Castling", 10, 0);
		private HomuSkill mAS_FIL_MOON = new HomuSkill("AS_FIL_MOON", "Moonlight", 20, 5);
		private HomuSkill mAS_FIL_ACCL = new HomuSkill("AS_FIL_ACCL", "Acceleratd Flight", 70, 0);
		private HomuSkill mAS_FIL_FLTT = new HomuSkill("AS_FIL_FLTT", "Flitting", 70, 5);
		private HomuSkill mAS_LIF_HEAL = new HomuSkill("AS_LIF_HEAL", "Healing Touch", 40, 5);
		private HomuSkill mAS_LIF_ESCP = new HomuSkill("AS_LIF_ESCP", "Urgent Escape", 40, 5);
		private HomuSkill mAS_VAN_CAPR = new HomuSkill("AS_VAN_CAPR", "Caprice", 1, 5);
		private HomuSkill mAS_VAN_BLES = new HomuSkill("AS_VAN_BLES", "Chaotic Blessing", 4000000, 0);

		public bool CIRCLE_ON_IDLE = true;
		public bool FOLLOW_AT_ONCE = true;
		public bool HELP_OWNER_1ST = true;
		public bool KILL_YOUR_ENEMIES_1ST = false;
		public bool LONG_RANGE_SHOOTER = false;
		public int HP_PERC_DANGER = 0;
		public int HP_PERC_SAFE2ATK = 50;
		public int OWNER_CLOSEDISTANCE = 2;
		public int TOO_FAR_TARGET = 14;
		public int SKILL_TIME_OUT = 1000;
		public bool NO_MOVING_TARGETS = false;
		public bool ADV_MOTION_CHECK = false;

		public HomuSkill AS_AMI_BULW {
			get { return mAS_AMI_BULW; }
			set { UpdateSkill(mAS_AMI_BULW, value); }
		}

		public HomuSkill AS_AMI_CAST {
			get { return mAS_AMI_CAST; }
			set { UpdateSkill(mAS_AMI_CAST, value); }
		}

		public HomuSkill AS_FIL_MOON {
			get { return mAS_FIL_MOON; }
			set { UpdateSkill(mAS_FIL_MOON, value); }
		}

		public HomuSkill AS_FIL_ACCL {
			get { return mAS_FIL_ACCL; }
			set { UpdateSkill(mAS_FIL_ACCL, value); }
		}

		public HomuSkill AS_FIL_FLTT {
			get { return mAS_FIL_FLTT; }
			set { UpdateSkill(mAS_FIL_FLTT, value); }
		}

		public HomuSkill AS_LIF_HEAL {
			get { return mAS_LIF_HEAL; }
			set { UpdateSkill(mAS_LIF_HEAL, value); }
		}

		public HomuSkill AS_LIF_ESCP {
			get { return mAS_LIF_ESCP; }
			set { UpdateSkill(mAS_LIF_ESCP, value); }
		}

		public HomuSkill AS_VAN_CAPR {
			get { return mAS_VAN_CAPR; }
			set { UpdateSkill(mAS_VAN_CAPR, value); }
		}

		public HomuSkill AS_VAN_BLES {
			get { return mAS_VAN_BLES; }
			set { UpdateSkill(mAS_VAN_BLES, value); }
		}

		public int OWNER_HP_PERC = 30; // for healing touch

		public EHomuBehavior DEFAULT_BEHA = EHomuBehavior.Attack;
		public EHomuSkillUsage DEFAULT_WITH = EHomuSkillUsage.FullPower;

		public HomuTactList TactList;



		public HomuConfig() {
			TactList = new HomuTactList();
		}


		public void LoadDefaultTact() {
			TactList.Clear();
			TactList.AddTact(1068, "Hydra", EHomuBehavior.AttackWeak, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1189, "Orc Archer", EHomuBehavior.React1st, EHomuSkillUsage.FullPower, 5);
			TactList.AddTact(1177, "Zenorc", EHomuBehavior.Attack1st, EHomuSkillUsage.FullPower, 5);
			TactList.AddTact(1152, "Orc Skeleton", EHomuBehavior.Attack, EHomuSkillUsage.OneSkill, 5);
			TactList.AddTact(1111, "Drainliar", EHomuBehavior.AttackWeak, EHomuSkillUsage.NoSkill, 1);
			TactList.AddTact(1042, "Steel Chonchon", EHomuBehavior.AttackLast, EHomuSkillUsage.OneSkill, 1);
			TactList.AddTact(1015, "Zombie", EHomuBehavior.AttackWeak, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1130, "Jakk", EHomuBehavior.Attack, EHomuSkillUsage.OneSkill, 5);
			TactList.AddTact(1061, "Nightmare", EHomuBehavior.Attack, EHomuSkillUsage.TwoSkills, 5);
			TactList.AddTact(1368, "Geographer", EHomuBehavior.Avoid, EHomuSkillUsage.FullPower, 5);
			TactList.AddTact(1613, "Metaling", EHomuBehavior.Attack1st, EHomuSkillUsage.OneSkill, 3);
			TactList.AddTact(1031, "Poporing", EHomuBehavior.AttackWeak, EHomuSkillUsage.OneSkill, 1);
			TactList.AddTact(1242, "Marin", EHomuBehavior.AttackWeak, EHomuSkillUsage.OneSkill, 1);
			TactList.AddTact(1113, "Drops", EHomuBehavior.Attack, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1002, "Poring", EHomuBehavior.AttackLast, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1627, "Anopheles", EHomuBehavior.AttackWeak, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1261, "Wild Rose", EHomuBehavior.Attack1st, EHomuSkillUsage.TwoSkills, 5);
			TactList.AddTact(1008, "Pupa", EHomuBehavior.AttackLast, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1048, "Thief Bug Egg", EHomuBehavior.AttackLast, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1047, "Peco Peco Egg", EHomuBehavior.AttackLast, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1097, "Ant Egg", EHomuBehavior.AttackLast, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1555, "Sm. Parasite", EHomuBehavior.Avoid, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1575, "Sm. Flora", EHomuBehavior.Avoid, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1579, "Sm. Hydra", EHomuBehavior.Avoid, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1589, "Sm. Mandragora", EHomuBehavior.Avoid, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1590, "Sm. Geographer", EHomuBehavior.Avoid, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1285, "WoE Guardian 1", EHomuBehavior.Avoid, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1286, "WoE Guardian 2", EHomuBehavior.Avoid, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1287, "WoE Guardian 3", EHomuBehavior.Avoid, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1288, "Emperium", EHomuBehavior.Attack1st, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1078, "Red Plant", EHomuBehavior.React, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1079, "Blue Plant", EHomuBehavior.React, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1080, "Green Plant", EHomuBehavior.React, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1081, "Yellow Plant", EHomuBehavior.React, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1082, "White Plant", EHomuBehavior.React, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1083, "Shining Plant", EHomuBehavior.React, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1084, "Black Mushroom", EHomuBehavior.React, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1085, "Red Mushroom", EHomuBehavior.React, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1102, "Bathory", EHomuBehavior.Attack1st, EHomuSkillUsage.FullPower, 5);
			TactList.AddTact(1179, "Whisper", EHomuBehavior.AttackWeak, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1131, "Joker", EHomuBehavior.Coward, EHomuSkillUsage.FullPower, 5);
			TactList.AddTact(1203, "Mysteltainn", EHomuBehavior.Coward, EHomuSkillUsage.FullPower, 5);
			TactList.AddTact(1204, "Ogretooth", EHomuBehavior.Coward, EHomuSkillUsage.FullPower, 5);
			TactList.AddTact(1205, "Executioner", EHomuBehavior.Coward, EHomuSkillUsage.FullPower, 5);
			TactList.AddTact(1256, "Pest", EHomuBehavior.AttackWeak, EHomuSkillUsage.FullPower, 5);
			TactList.AddTact(1314, "Permeter", EHomuBehavior.Avoid, EHomuSkillUsage.NoSkill, 5);
			TactList.AddTact(1321, "Dragon Tail", EHomuBehavior.Attack, EHomuSkillUsage.FullPower, 5);
			TactList.AddTact(1322, "Spring Rabbit", EHomuBehavior.Attack, EHomuSkillUsage.FullPower, 5);
			TactList.AddTact(1776, "Siroma", EHomuBehavior.Attack1st, EHomuSkillUsage.FullPower, 5);
			TactList.AddTact(1780, "Muscipular", EHomuBehavior.React, EHomuSkillUsage.FullPower, 5);
			TactList.AddTact(1778, "Gazeti", EHomuBehavior.React1st, EHomuSkillUsage.FullPower, 5);
			TactList.AddTact(1789, "Iceicle", EHomuBehavior.Attack, EHomuSkillUsage.OneSkill, 1);
		}

		public int LoadConfig() {
			string filePath = AppDomain.CurrentDomain.BaseDirectory + Filename;
			if (File.Exists(filePath) == false)
				return -1;

			List<string> Lines = new List<string>(File.ReadAllLines(filePath, ASCIIEncoding.Default));
			for (int i = 0; i < Lines.Count; i++) {
				string line = Lines[i].Trim();
				// kill comments
				if (line.Length < 2 || line.StartsWith("--")) {
					Lines.RemoveAt(i);
					i--;
					continue;
				}
				if (line.Contains("--")) {
					// contains comment, remove it
					Lines[i] = Lines[i].Substring(0, Lines[i].IndexOf("--")).Trim();
				}
			}

			ParseConfigs(Lines);


			return 1;
		}

		public void SaveConfig() {
			string filePath = AppDomain.CurrentDomain.BaseDirectory + Filename;
			if (File.Exists(filePath) == true)
				File.Delete(filePath);

			using (StreamWriter file = new StreamWriter(File.OpenWrite(filePath), ASCIIEncoding.Default)) {
				string nl = Environment.NewLine;
				file.WriteLine("--------------------------------------------------");
				file.WriteLine("-- ZenAI 1.1a configuration file (Homunculus)");
				file.WriteLine("-- [created with GodLesZ " + frmMain.APP_VERSION + "]");
				file.WriteLine("--------------------------------------------------");

				// Options
				file.WriteLine("{0}-- Options{1}", nl, nl);
				file.WriteLine("CIRCLE_ON_IDLE = {0};", (CIRCLE_ON_IDLE ? 1 : 0));
				file.WriteLine("FOLLOW_AT_ONCE = {0};", (FOLLOW_AT_ONCE ? 1 : 0));
				file.WriteLine("HELP_OWNER_1ST = {0};", HELP_OWNER_1ST.ToString().ToLower());
				file.WriteLine("KILL_YOUR_ENEMIES_1ST = {0};", KILL_YOUR_ENEMIES_1ST.ToString().ToLower());
				file.WriteLine("LONG_RANGE_SHOOTER = {0};", LONG_RANGE_SHOOTER.ToString().ToLower());
				file.WriteLine("HP_PERC_DANGER = {0};", HP_PERC_DANGER);
				file.WriteLine("HP_PERC_SAFE2ATK = {0};", HP_PERC_SAFE2ATK);
				file.WriteLine("OWNER_CLOSEDISTANCE = {0};", OWNER_CLOSEDISTANCE);
				file.WriteLine("TOO_FAR_TARGET = {0};", TOO_FAR_TARGET);
				file.WriteLine("SKILL_TIME_OUT = {0};", SKILL_TIME_OUT);
				file.WriteLine("NO_MOVING_TARGETS = {0};", NO_MOVING_TARGETS.ToString().ToLower());
				file.WriteLine("ADV_MOTION_CHECK = {0};", ADV_MOTION_CHECK.ToString().ToLower());

				file.WriteLine(nl);

				// Skills
				file.WriteLine("-- Homunculus skills -----------------------------");
				file.WriteLine();
				file.WriteLine("-- Amistr");
				file.WriteLine("{0}{1}", AS_AMI_BULW.ToString(), nl);
				file.WriteLine("{0}{1}", AS_AMI_CAST.ToString(), nl);

				file.WriteLine();
				file.WriteLine("-- Filir");
				file.WriteLine("{0}{1}", AS_FIL_MOON.ToString(), nl);
				file.WriteLine("{0}{1}", AS_FIL_ACCL.ToString(), nl);
				file.WriteLine("{0}{1}", AS_FIL_FLTT.ToString(), nl);

				file.WriteLine();
				file.WriteLine("-- Lif");
				file.WriteLine("{0}{1}", AS_LIF_HEAL.ToString(), nl);
				file.WriteLine("OWNER_HP_PERC = {0};", OWNER_HP_PERC);
				file.WriteLine("{0}{1}", AS_LIF_ESCP.ToString(), nl);

				file.WriteLine();
				file.WriteLine("-- Vanilmirth");
				file.WriteLine("{0}{1}", AS_VAN_CAPR.ToString(), nl);
				file.WriteLine("{0}{1}", AS_VAN_BLES.ToString(), nl);

				// TactList
				file.WriteLine();
				file.WriteLine("-- TactList --------------------------------------");
				file.WriteLine("DEFAULT_BEHA = {0};", Tools.GetConfigName(DEFAULT_BEHA));
				file.WriteLine("DEFAULT_WITH = {0};", Tools.GetConfigName(DEFAULT_WITH));
				file.WriteLine();
				file.WriteLine(TactList.ToString());
				file.Write("-- ZenAI © by Zenia-chan, Config Panel © by GodLesZ - its magic :D");
			}

		}


		private void UpdateSkill(HomuSkill Skill, HomuSkill NewData) {
			Skill.Level = NewData.Level;
			Skill.MinSP = NewData.MinSP;
		}

		private void ParseConfigs(List<string> Lines) {
			Match m;
			Regex rMatchLine = new Regex(@"^([^=]+)=([^;{}]+)", RegexOptions.Compiled);
			Regex rTableStart = new Regex("{[ \t]*}", RegexOptions.Compiled);
			Regex rTacticLine = new Regex(@"Tact\[(.*)\].*=.*\{([^,]*),([^,]*),([^,]*),([^\}]*)\}", RegexOptions.Compiled);

			for (int i = 0; i < Lines.Count; i++) {
				string line = Lines[i];
				string pairName = "", pairValue = "";
				string skillName = "";
				m = rMatchLine.Match(line);

				#region check: start of a Table
				if (rTableStart.IsMatch(line)) {

					// A skill define?
					#region Skill defines
					if (line.StartsWith("AS_") == true && m.Groups.Count > 1 && (skillName = m.Groups[1].Value.Trim()).Length == 11) {
						string pairSubName;
						int minSP = 0, lvl = 0;
						for (int v = 0; v < 2 && i < Lines.Count; v++) {
							i++;
							line = Lines[i];
							m = Regex.Match(line, @"^([^=]+)=([^;{}]+)");
							pairName = m.Groups[1].Value.Trim();
							pairValue = m.Groups[2].Value.Trim();
							if (pairName.IndexOf('.') == -1)
								continue; // huh, wtf is this? oO

							pairSubName = pairName.Substring(pairName.IndexOf('.') + 1).Trim().ToLower();
							if (pairSubName == "minsp")
								minSP = int.Parse(pairValue);
							else if (pairSubName == "level")
								lvl = int.Parse(pairValue);
						}

						HomuSkill skill = new HomuSkill(skillName, "", minSP, lvl);
						if (SetReflectionProp(skillName, skill) == false)
							MessageBox.Show("Die Eigenschaft \"" + skillName + "\" konnte nicht gefunden werden!", "Config Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);

						continue;
					}
					#endregion

					if (line.StartsWith("Tact") == true) {
						i++;
						for (; i < Lines.Count; i++) {
							line = Lines[i];
							if (line.StartsWith("--") == true)
								continue;
							m = rTacticLine.Match(line);
							if (m.Groups.Count < 6) {
								MessageBox.Show("Die Zeile hat ein falsches Taktik-format: " + line, "Config Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
								break; // assume no more tacts left?
							}
							int mobID = int.Parse(m.Groups[1].Value.Trim());
							string mobName = m.Groups[2].Value.Replace("\"", "").Trim();
							string attBehav = m.Groups[3].Value.Trim();
							string skillBehav = m.Groups[4].Value.Trim();
							int prio = int.Parse(m.Groups[5].Value.Trim());

							if (TactList.AddTact(mobID, mobName, attBehav, skillBehav, prio) == false)
								MessageBox.Show("Fehler beim einlesen der Taktik: " + line, "Config Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}

						continue;
					}
				}
				#endregion

				#region check: name = value
				if (m != null && m.Success) {
					pairName = m.Groups[1].Value.Trim();
					pairValue = m.Groups[2].Value.Trim();
					if (pairValue.EndsWith(";") == true)
						pairValue = pairValue.Substring(0, pairValue.IndexOf(';')).Trim();

					if (SetReflectionField(pairName, pairValue) == false) {
						MessageBox.Show("Die Eigenschaft \"" + pairName + "\" konnte nicht gefunden werden!", "Config Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
						continue;
					}
					continue;
				}
				#endregion

				MessageBox.Show("Unbekanntes Zeilenformat: " + line, "Config Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private bool SetReflectionField(string FieldName, object Value) {
			EHomuBehavior homBehav;
			EHomuSkillUsage homSkill;
			Type reflectionObject = this.GetType();
			FieldInfo field = reflectionObject.GetField(FieldName);
			if (field == null)
				return false;

			if (field.FieldType == typeof(int)) {
				field.SetValue(this, int.Parse((string)Value));
			} else if (field.FieldType == typeof(bool)) {
				field.SetValue(this, (Value.ToString() == "1" || Value.ToString().ToLower() == "true" ? true : false));
			} else if (EHomuBehaviorExtension.FromConfig((string)Value, out homBehav)) {
				field.SetValue(this, homBehav);
			} else if (EHomuSkillUsageExtension.FromConfig((string)Value, out homSkill)) {
				field.SetValue(this, homSkill);
			} else {
				MessageBox.Show("Unbekannter FeldTyp von \"" + FieldName + "\": " + field.FieldType.Name, "Config Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return true;
		}

		private bool SetReflectionProp(string FieldName, object Value) {
			Type reflectionObject = this.GetType();
			PropertyInfo prop = reflectionObject.GetProperty(FieldName);
			if (prop == null)
				return false;

			if (prop.PropertyType == typeof(HomuSkill)) {
				prop.SetValue(this, (HomuSkill)Value, null);
			} else {
				MessageBox.Show("Unbekannter EigenschaftenTyp von \"" + FieldName + "\": " + prop.PropertyType.Name, "Config Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return true;
		}

	}

}
