using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Rovolution.Server.Objects {

	public class MonsterSkillList : List<MonsterSkill> {

		public MonsterSkillList() {
		}

		public MonsterSkillList(uint mobID) {
			LoadFromDatabase(mobID);
		}


		public void LoadFromDatabase(uint mobID) {
			DataTable table = Core.Database.Query("SELECT * FROM dbmob_skill WHERE mobID = {0}", mobID);
			if (table == null || table.Rows.Count == 0) {
				return;
			}

			MonsterSkill skill;
			foreach (DataRow row in table.Rows) {
				skill = MonsterSkill.Load(row);
				if (skill != null) {
					Add(skill);
				}
			}
		}

	}

}
