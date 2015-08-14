using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Rovolution.Server.Objects {

	public class MonsterSkill : MonsterSkillDatabaseData {

		public MonsterSkill() {
		}

		public MonsterSkill(DataRow row)
			: base(row) {
		}


		protected override bool LoadFromDatabase(DataRow row) {
			if (base.LoadFromDatabase(row) == false) {
				return false;
			}

			return true;
		}


		public static MonsterSkill Load(DataRow row) {
			MonsterSkill skill = new MonsterSkill();
			if (skill.LoadFromDatabase(row) == false) {
				return null;
			}

			return skill;
		}

	}
}
