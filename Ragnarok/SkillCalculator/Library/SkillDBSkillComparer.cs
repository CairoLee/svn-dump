using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.Ragnarok.SkillCalculator.Library {

	public class SkillDBSkillComparer : IComparer<SkillDBSkill> {

		public int Compare(SkillDBSkill x, SkillDBSkill y) {
			return x.ID.CompareTo(y.ID);
		}

	}

}
