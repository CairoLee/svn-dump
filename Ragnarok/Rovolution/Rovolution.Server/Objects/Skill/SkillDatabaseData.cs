using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Rovolution.Server.Objects {

	public class SkillDatabaseData : DatabaseObject {

		public int SkillID {
			get { return (int)base.ID; }
			set { base.Serial = new DatabaseID(value, EDatabaseType.Skill); }
		}

		public ESkill Index {
			get;
			protected set;
		}


		public string Name {
			get;
			protected set;
		}

		public string Description {
			get;
			protected set;
		}

		public List<SkillLevel> Level {
			get;
			protected set;
		}

		public int Hit {
			get;
			protected set;
		}

		public ESkillInf Inf {
			get;
			protected set;
		}

		public ESkillNk Nk {
			get;
			protected set;
		}

		public int Max {
			get;
			protected set;
		}

		public bool CastCancel {
			get;
			protected set;
		}

		public int CastDefRate {
			get;
			protected set;
		}

		public ESkillInf2 Inf2 {
			get;
			protected set;
		}

		public EBattleFlag SkillType {
			get;
			protected set;
		}

		public int Weapon {
			get;
			protected set;
		}

		public int Ammo {
			get;
			protected set;
		}

		public int State {
			get;
			protected set;
		}

		public List<SkillRequireItem> Require {
			get;
			protected set;
		}

		public int NoCast {
			get;
			protected set;
		}

		public int[] UnitID {
			get;
			protected set;
		}

		public int UnitInterval {
			get;
			protected set;
		}

		public int UnitTarget {
			get;
			protected set;
		}

		public int UnitFlag {
			get;
			protected set;
		}


		public SkillDatabaseData()
			: this(null) {
		}

		public SkillDatabaseData(DataRow row)
			: base() {
			Level = new List<SkillLevel>();
			if (row != null) {
				LoadFromDatabase(row);
			}
		}


		public static SkillDatabaseData Load(DataRow row) {
			SkillDatabaseData skill = new SkillDatabaseData();
			if (skill.LoadFromDatabase(row) == false) {
				return null;
			}

			return skill;
		}


		protected override bool LoadFromDatabase(DataRow row) {

			SkillID = row.Field<int>("skillID");
			Index = (ESkill)SkillID;
			Name = row.Field<string>("name");
			Description = row.Field<string>("description");
			Hit = row.Field<short>("hit");
			Inf = (ESkillInf)row.Field<int>("inf");
			Inf2 = (ESkillInf2)row.Field<int>("inf2");
			CastCancel = row.Field<bool>("castCancel");
			CastDefRate = row.Field<int>("castDefRate");
			Nk = (ESkillNk)row.Field<short>("nk");
			SkillType = (EBattleFlag)row.Field<short>("type");

			// Load level
			DataTable table = Core.Database.Query("SELECT * FROM dbskill_level WHERE skillID = {0} ORDER BY level ASC", SkillID);
			if (table != null && table.Rows.Count > 0) {
				SkillLevel level;
				foreach (DataRow levelRow in table.Rows) {
					level = SkillLevel.Load(levelRow);
					if (level == null) {
						ServerConsole.ErrorLine("Failed to load skill level #" + levelRow.Field<int>("skillID") + " lv " + levelRow.Field<int>("level"));
						continue;
					}

					Level.Add(level);
				}
			}

			return true;
		}

	}

}
