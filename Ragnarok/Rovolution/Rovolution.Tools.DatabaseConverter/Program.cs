using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Rovolution.Server.Database;
using GodLesZ.Library.MySql;
using Rovolution.Server.Objects;
using System.Data;

namespace Rovolution.Tools.DatabaseConverter {

	public class Program {
		private static RovolutionDatabase db = new RovolutionDatabase("localhost", 3306, "root", "", "rovolution");

		public static void Main(string[] args) {
			db.Prepare();

			// Rename item_db to itemdb
			//db.QuerySimple("RENAME TABLE `item_db` TO `dbitem` ");

			// item_trade.txt to itemdb
			//ParseItemTrade(@"C:\Users\Jonathan\Desktop\eAthena\db\item_trade.txt");
			// item_noequip.txt to itemdb
			//ParseItemNoequip(@"C:\Users\Jonathan\Desktop\eAthena\db\item_noequip.txt");

			// Split mob drops
			//DatabaseSplitMobDrops();
			// mob_skill_db.txt to dbmob_skill
			//ParseMobSkills(@"C:\Users\Jonathan\Desktop\eAthena\db\mob_skill_db.txt");
			// skill_db.txt to dbskill
			ParseSkills(@"C:\Users\Jonathan\Desktop\eAthena\db\skill_db.txt");

			Console.WriteLine("conversion done");
			Console.ReadKey();
		}


		private static void ParseItemTrade(string path) {
			Console.WriteLine("load item_trade.txt");
			//db.QuerySimple("ALTER TABLE `dbitem` ADD `notrade` INT( 11 ) NOT NULL DEFAULT '0',ADD `notrade_override` INT( 11 ) NOT NULL DEFAULT '0'");

			string[] lines = File.ReadAllLines(path);
			for (int i = 0; i < lines.Length; i++) {
				string line = lines[i].Trim();
				if (line.Length == 0 || line.StartsWith("//") == true) {
					continue;
				}
				string[] parts = line.Split(',');

				int nameID = int.Parse(parts[0]);
				int mask = int.Parse(parts[1]);
				int gmOverride = 0;
				if (parts.Length == 3) {
					string gmString = (parts[2].IndexOf('\t') > -1 ? parts[2].Substring(0, parts[2].IndexOf('\t')).Trim() : parts[2]);
					gmOverride = int.Parse(gmString);
				}

				db.QuerySimple("UPDATE dbitem SET notrade = {0}, notrade_override = '{1}' WHERE id = {2}", mask, gmOverride, nameID);
			}
		}

		private static void ParseItemNoequip(string path) {
			Console.WriteLine("load item_noequip.txt");
			//db.QuerySimple("ALTER TABLE `dbitem` ADD `noequip` INT( 11 ) NOT NULL DEFAULT '0'");

			string[] lines = File.ReadAllLines(path);
			for (int i = 0; i < lines.Length; i++) {
				string line = lines[i].Trim();
				if (line.Length == 0 || line.StartsWith("//") == true) {
					continue;
				}
				string[] parts = line.Split(',');

				int nameID = int.Parse(parts[0]);
				string modeString = (parts[1].IndexOf('/') > -1 ? parts[1].Substring(0, parts[1].IndexOf('/')).Trim() : parts[1]);
				int mode = int.Parse(modeString);

				db.QuerySimple("UPDATE dbitem SET noequip = {0} WHERE id = {1}", mode, nameID);
			}
		}


		private static void DatabaseSplitMobDrops() {
			Console.WriteLine("Split mob drops..");

			DataTable table = db.Query("SELECT * FROM dbmob");
			foreach (DataRow row in table.Rows) {
				int mobID = row.Field<int>("ID");
				int amount = 1; // eA didnt implement that
				int itemID, chance, isMVP, isCard;
				string query;

				Console.WriteLine("\tparse #" + mobID + "..");

				// for each mvp drop..
				for (int i = 1; i < 4; i++) {
					itemID = row.Field<int>("Drop" + i + "id");
					chance = row.Field<int>("Drop" + i + "per");
					if (itemID == 0 || chance == 0) {
						continue;
					}
					isMVP = 1;
					isCard = 0;
					//										 `mobID`, `itemID`, `amount`, `chance`, `isMVP`
					query = "INSERT INTO dbmob_drop VALUES(NULL,'{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";
					db.QuerySimple(query, mobID, itemID, amount, chance, isMVP, isCard);
				}

				// for each normal drop..
				for (int i = 1; i < 10; i++) {
					itemID = row.Field<int>("Drop" + i + "id");
					chance = row.Field<int>("Drop" + i + "per");
					if (itemID == 0 || chance == 0) {
						continue;
					}
					isMVP = 0;
					isCard = 0;
					//										 `mobID`, `itemID`, `amount`, `chance`, `isMVP`
					query = "INSERT INTO dbmob_drop VALUES(NULL,'{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";
					db.QuerySimple(query, mobID, itemID, amount, chance, isMVP, isCard);
				}

				// Card
				itemID = row.Field<int>("DropCardid");
				chance = row.Field<int>("DropCardper");
				if (itemID > 0 && chance > 0) {
					isMVP = 0;
					isCard = 1;
					//										 `mobID`, `itemID`, `amount`, `chance`, `isMVP`
					query = "INSERT INTO dbmob_drop VALUES(NULL,'{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";
					db.QuerySimple(query, mobID, itemID, amount, chance, isMVP, isCard);
				}
			}

		}

		private static void ParseMobSkills(string path) {
			Console.WriteLine("load mob_skill_db.txt");

			string[] lines = File.ReadAllLines(path);
			for (int i = 0; i < lines.Length; i++) {
				string line = lines[i].Trim();
				if (line.Length == 0 || line.StartsWith("//") == true) {
					continue;
				}
				string[] parts = line.Split(',');
				// //MOB_ID,dummy value (info only),STATE,SKILL_ID,SKILL_LV,rate (10000 = 100%),casttime,delay,cancelable,target,condition type,condition value,val1,val2,val3,val4,val5,emotion,chat
				int mobID = int.Parse(parts[0]);
				string info = parts[1].Trim();
				EMonsterSkillState state = (EMonsterSkillState)0; // 2
				int skillID = int.Parse(parts[3]);
				int skillLevel = int.Parse(parts[4]);
				int rate = int.Parse(parts[5]);
				int casttime = int.Parse(parts[6]);
				int delay = int.Parse(parts[7]);
				int cancelable = GetNumber(parts[8]);
				EMonsterSkillTarget target = (EMonsterSkillTarget)0; // 9
				EMonsterSkillCondition1 conditionType = (EMonsterSkillCondition1)0; // 10
				EMonsterSkillCondition2 conditionValue = (EMonsterSkillCondition2)0; // 11
				int value1 = GetNumber(parts[12]);
				int value2 = GetNumber(parts[13]);
				int value3 = GetNumber(parts[14]);
				int value4 = GetNumber(parts[15]);
				int value5 = GetNumber(parts[16]);
				int emotion = GetNumber(parts[17]);
				int chatID = GetNumber(parts[18]);

				#region state [2]
				switch (parts[2].Trim().ToLower()) {
					case "any":
						state = EMonsterSkillState.Any;
						break;
					case "idle":
						state = EMonsterSkillState.Idle;
						break;
					case "walk":
						state = EMonsterSkillState.Walk;
						break;
					case "loot":
						state = EMonsterSkillState.Loot;
						break;
					case "dead":
						state = EMonsterSkillState.Dead;
						break;
					case "attack":
						state = EMonsterSkillState.Berserk;
						break;
					case "angry":
						state = EMonsterSkillState.Angry;
						break;
					case "chase":
						state = EMonsterSkillState.Rush;
						break;
					case "follow":
						state = EMonsterSkillState.Follow;
						break;
					case "anytarget":
						state = EMonsterSkillState.Anytarget;
						break;
				}

				#endregion

				#region target [9]
				switch (parts[9].Trim().ToLower()) {
					case "target":
						target = EMonsterSkillTarget.Target;
						break;
					case "randomtarget":
						target = EMonsterSkillTarget.Random;
						break;
					case "self":
						target = EMonsterSkillTarget.Self;
						break;
					case "friend":
						target = EMonsterSkillTarget.Friend;
						break;
					case "master":
						target = EMonsterSkillTarget.Master;
						break;
					case "around":
						target = EMonsterSkillTarget.Around;
						break;
					case "around1":
						target = EMonsterSkillTarget.Around1;
						break;
					case "around2":
						target = EMonsterSkillTarget.Around2;
						break;
					case "around3":
						target = EMonsterSkillTarget.Around3;
						break;
					case "around4":
						target = EMonsterSkillTarget.Around4;
						break;
					case "around5":
						target = EMonsterSkillTarget.Around5;
						break;
					case "around6":
						target = EMonsterSkillTarget.Around6;
						break;
					case "around7":
						target = EMonsterSkillTarget.Around7;
						break;
					case "around8":
						target = EMonsterSkillTarget.Around8;
						break;
				}
				#endregion

				#region conditionType [10]
				switch (parts[10].Trim().ToLower()) {

					case "always":
						conditionType = EMonsterSkillCondition1.Always;
						break;
					case "myhpltmaxrate":
						conditionType = EMonsterSkillCondition1.Myhpltmaxrate;
						break;
					case "myhpinrate":
						conditionType = EMonsterSkillCondition1.Myhpinrate;
						break;
					case "friendhpltmaxrate":
						conditionType = EMonsterSkillCondition1.Friendhpltmaxrate;
						break;
					case "friendhpinrate":
						conditionType = EMonsterSkillCondition1.Friendhpinrate;
						break;
					case "mystatuson":
						conditionType = EMonsterSkillCondition1.Mystatuson;
						break;
					case "mystatusoff":
						conditionType = EMonsterSkillCondition1.Mystatusoff;
						break;
					case "friendstatuson":
						conditionType = EMonsterSkillCondition1.Friendstatuson;
						break;
					case "friendstatusoff":
						conditionType = EMonsterSkillCondition1.Friendstatusoff;
						break;
					case "attackpcgt":
						conditionType = EMonsterSkillCondition1.Attackpcgt;
						break;
					case "attackpcge":
						conditionType = EMonsterSkillCondition1.Attackpcge;
						break;
					case "slavelt":
						conditionType = EMonsterSkillCondition1.Slavelt;
						break;
					case "slavele":
						conditionType = EMonsterSkillCondition1.Slavele;
						break;
					case "closedattacked":
						conditionType = EMonsterSkillCondition1.Closedattacked;
						break;
					case "longrangeattacked":
						conditionType = EMonsterSkillCondition1.Longrangeattacked;
						break;
					case "skillused":
						conditionType = EMonsterSkillCondition1.Skillused;
						break;
					case "afterskill":
						conditionType = EMonsterSkillCondition1.Afterskill;
						break;
					case "casttargeted":
						conditionType = EMonsterSkillCondition1.Casttargeted;
						break;
					case "rudeattacked":
						conditionType = EMonsterSkillCondition1.Rudeattacked;
						break;
					case "masterhpltmaxrate":
						conditionType = EMonsterSkillCondition1.Masterhpltmaxrate;
						break;
					case "masterattacked":
						conditionType = EMonsterSkillCondition1.Masterattacked;
						break;
					case "alchemist":
						conditionType = EMonsterSkillCondition1.Alchemist;
						break;
					case "onspawn":
						conditionType = EMonsterSkillCondition1.Spawn;
						break;
				}
				#endregion

				#region conditionValue [11]
				switch (parts[11].Trim().ToLower()) {
					case "anybad":
						conditionValue = EMonsterSkillCondition2.Anybad;
						break;
					case "stone":
						conditionValue = EMonsterSkillCondition2.Stone;
						break;
					case "freeze":
						conditionValue = EMonsterSkillCondition2.Freeze;
						break;
					case "stun":
						conditionValue = EMonsterSkillCondition2.Stun;
						break;
					case "sleep":
						conditionValue = EMonsterSkillCondition2.Sleep;
						break;
					case "poison":
						conditionValue = EMonsterSkillCondition2.Poison;
						break;
					case "curse":
						conditionValue = EMonsterSkillCondition2.Curse;
						break;
					case "silence":
						conditionValue = EMonsterSkillCondition2.Silence;
						break;
					case "confusion":
						conditionValue = EMonsterSkillCondition2.Confusion;
						break;
					case "blind":
						conditionValue = EMonsterSkillCondition2.Blind;
						break;
					case "hiding":
						conditionValue = EMonsterSkillCondition2.Hiding;
						break;
					case "sight":
						conditionValue = EMonsterSkillCondition2.Sight;
						break;

					default:
						conditionValue = (EMonsterSkillCondition2)GetNumber(parts[11]);
						break;
				}
				#endregion

				string query = "INSERT INTO dbmob_skill VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}')";
				query = string.Format(query, mobID, info.MysqlEscape(), (int)state, skillID, skillLevel, rate, casttime, delay, cancelable, (int)target, (int)conditionType, (int)conditionValue, value1, value2, value3, value4, value5, emotion, chatID);

				db.Query(query);
			}

		}

		public static void ParseSkills(string path) {
			Console.WriteLine("load skill_db.txt");
			db.Query("TRUNCATE TABLE dbskill");
			db.Query("TRUNCATE TABLE dbskill_level");

			string[] lines = File.ReadAllLines(path);
			for (int i = 0; i < lines.Length; i++) {
				string line = lines[i].Trim();
				if (line.Length == 0 || line.StartsWith("//") == true) {
					continue;
				}
				string[] parts = line.Split(',');
				// id,range,hit,inf,element,nk,splash,max,list_num,castcancel,cast_defence_rate,inf2,maxcount,skill_type,blow_count,name,description
				int id = GetNumber(parts[0]);
				int hit = GetNumber(parts[2]);
				int inf = GetNumber(parts[3]);
				int nk = GetNumber(parts[5]);
				int maxLevel = GetNumber(parts[7]);
				bool castcancel = (GetNumber(parts[9]) > 0 ? true : false);
				int cast_def_rate = GetNumber(parts[10]);
				int inf2 = GetNumber(parts[11]);
				EBattleFlag skill_type = (parts[13] == "weapon" ? EBattleFlag.Weapon : parts[13] == "magic" ? EBattleFlag.Magic : parts[13] == "misc" ? EBattleFlag.Misc : EBattleFlag.None);
				string name = parts[15].Trim();
				string description = parts[16].Trim();
				var levelList = BuildSkillLevel(parts, maxLevel);

				Console.WriteLine("\tskill #" + id + " [" + name + "] (" + levelList.Count + " level)");
				// Dump to DB
				// `skillID`, `name`, `description`, `hit`, `inf`, `inf2`, `castCancel`, `castDefRate`, `nk`, `type`
				string query = "INSERT INTO dbskill VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')";
				query = string.Format(query, id, name.MysqlEscape(), description.MysqlEscape(), hit, (int)inf, (int)inf2, castcancel, cast_def_rate, (int)nk, (int)skill_type);
				db.Query(query);

				// Each level..
				foreach (TmpSkillLevel level in levelList) {
					// `skillID`, `level`, `range`, `element`, `splash`, `num`, `maxcount`, `blowcount`
					query = "INSERT INTO dbskill_level VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')";
					query = string.Format(query, id, level.Level, level.Range, level.Element, level.Splash, level.Num, level.MaxCount, level.BlewCount);
					db.Query(query);
				}
			}
		}

		public class TmpSkillLevel {

			public int Level;
			public int Range;
			public int Element;
			public int Splash;
			public int Num;
			public int Cast;
			public int WalkDelay;
			public int Delay;
			public int UpkeepTime;
			public int UpkeepTime2;
			public int MaxCount;
			public int BlewCount;
			public int Hp;
			public int Sp;
			public int MHp;
			public int HpRate;
			public int SpRate;
			public int Zeny;
			public int AmmoQty;
			public int Spritiball;
			public int CastNoDex;
			public int DelayNoDex;
			public int UnitLayoutType;
			public int UnitRange;

			public TmpSkillLevel() {
			}

			public TmpSkillLevel(int level, int range, int element, int splash, int num, int maxcount, int blewcount) {
				Level = level;
				Range = range;
				Element = element;
				Splash = splash;
				Num = num;
				MaxCount = maxcount;
				BlewCount = blewcount;
			}
		}

		private static List<TmpSkillLevel> BuildSkillLevel(string[] parts, int maxLevel) {
			List<TmpSkillLevel> levelList = new List<TmpSkillLevel>();

			string[] range = parts[1].Split(':');
			string[] element = parts[4].Split(':');
			string[] splash = parts[6].Split(':');
			string[] num = parts[8].Split(':');
			string[] maxcount = parts[12].Split(':');
			string[] blewcount = parts[14].Split(':');

			int levelCount = Math.Max(1, range.Length);
			levelCount = Math.Max(levelCount, element.Length);
			levelCount = Math.Max(levelCount, splash.Length);
			levelCount = Math.Max(levelCount, num.Length);
			levelCount = Math.Max(levelCount, maxcount.Length);
			levelCount = Math.Max(levelCount, blewcount.Length);
			levelCount = Math.Max(levelCount, maxLevel);

			for (int i = 0; i < levelCount; i++) {
				levelList.Add(
					new TmpSkillLevel(
						(i + 1),
						range.Length > i ? GetNumber(range[i]) : GetNumber(range[range.Length - 1]),
						element.Length > i ? GetNumber(element[i]) : GetNumber(element[element.Length - 1]),
						splash.Length > i ? GetNumber(splash[i]) : GetNumber(splash[splash.Length - 1]),
						num.Length > i ? GetNumber(num[i]) : GetNumber(num[num.Length - 1]),
						maxcount.Length > i ? GetNumber(maxcount[i]) : GetNumber(maxcount[maxcount.Length - 1]),
						blewcount.Length > i ? GetNumber(blewcount[i]) : GetNumber(blewcount[blewcount.Length - 1])
					)
				);
			}

			return levelList;
		}







		private static int GetNumber(string data) {
			data = data.Trim().ToLower();
			if (data.Length == 0) {
				return 0;
			}
			if (data == "yes" || data == "1") {
				return 1;
			}
			if (data == "no" || data == "0") {
				return 0;
			}

			if (data.StartsWith("0x") == true) {
				data = data.Substring(2);
				return int.Parse(data, System.Globalization.NumberStyles.HexNumber);
			}
			return int.Parse(data);
		}

	}

}
