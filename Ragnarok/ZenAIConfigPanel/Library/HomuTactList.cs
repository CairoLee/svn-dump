using System;
using System.Collections.Generic;

namespace ZenAIConfigPanel.Library {

	public class HomuTactList : List<HomuTactListEntry> {

		public bool AddTact(int ID, string Name, EHomuBehavior Behav, EHomuSkillUsage Skill, int Priority) {
			Add(new HomuTactListEntry(ID, Name, Behav, Skill, Priority));
			return true;
		}

		public bool AddTact(int ID, string Name, string Behav, string Skill, int Priority) {
			EHomuBehavior homBehav;
			EHomuSkillUsage homSkill;
			if (EHomuBehaviorExtension.FromConfig(Behav, out homBehav) == false)
				return false;
			if (EHomuSkillUsageExtension.FromConfig(Skill, out homSkill) == false)
				return false;
			return AddTact(ID, Name, homBehav, homSkill, Priority);
		}


		public override string ToString() {
			string nl = Environment.NewLine;
			string retString = "Tact = {};" + nl;
			foreach (HomuTactListEntry tact in this)
				retString += tact.ToString() + nl;
			return retString;
		}

	}

}
