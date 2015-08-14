using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.Ragnarok.SkillCalculator.Library {

	public enum EElement : int {
		Neutral = 0,
		Water,
		Earth,
		Fire,
		Wind,
		Poison,
		Holy,
		Dark,
		Ghost,
		Undead,

		SkillUseWeaponElement = -1,
		SkillUseEndowElement = -2,
		SkillUseRandomElement = -3
	}

}
