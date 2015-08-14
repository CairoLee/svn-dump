using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public struct CharacterSkill {

		public ushort ID;
		public ushort Level;
		public ESkillFlag Flag;

		public CharacterSkill(ushort id, ushort level, ESkillFlag flag) {
			ID = id;
			Level = level;
			Flag = flag;
		}


		public override string ToString() {
			return string.Format("[{0}] {1}, Lv {2} [{3}]", ID, (World.Database.Skill[ID] as SkillDatabaseData).Name, Level, Flag);
		}

	}

}
