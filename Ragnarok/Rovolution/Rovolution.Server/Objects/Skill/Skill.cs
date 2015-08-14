using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Rovolution.Server.Objects {

	public class Skill : WorldObject {

		public SkillDatabaseData Database {
			get { return (SkillDatabaseData)GetDatabaseData(); }
		}


		public Skill(DatabaseID dbID, bool addToWorld)
			: base(dbID, addToWorld) {
		}

		public Skill(DatabaseID dbID)
			: base(dbID) {
		}
		/*
		public Skill(int id, int hit, int inf, int nk, bool castcancel, int cast_defence_rate, int inf2, EBattleFlag skill_type, string name, string description, List<SkillLevel> level) {
			Serial = new DatabaseID(id, EDatabaseType.Skill);
			Hit = hit;
			Inf = (ESkillInf)inf;
			Nk = (ESkillNk)nk;
			CastCancel = castcancel;
			CastDefRate = cast_defence_rate;
			Inf2 = (ESkillInf2)inf2;
			SkillType = skill_type;
			Name = name;
			Description = description;
			Level = (level == null ? new List<SkillLevel>() : level);
		}
		*/


		public override DatabaseObject GetDatabaseData() {
			if (mDatabaseData == null) {
				ESkill index = (ESkill)mDatabaseID.ID;
				mDatabaseData = World.Database[index];
			}

			return mDatabaseData;
		}

	}

}
