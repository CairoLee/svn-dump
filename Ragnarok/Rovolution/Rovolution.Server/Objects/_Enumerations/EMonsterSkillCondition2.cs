using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public enum EMonsterSkillCondition2 {
		Anybad = (int)EStatusChange.None,

		Stone = (int)EStatusChange.Stone,
		Freeze = (int)EStatusChange.Freeze,
		Stun = (int)EStatusChange.Stun,
		Sleep = (int)EStatusChange.Sleep,
		Poison = (int)EStatusChange.Poison,
		Curse = (int)EStatusChange.Curse,
		Silence = (int)EStatusChange.Silence,
		Confusion = (int)EStatusChange.Confusion,
		Blind = (int)EStatusChange.Blind,
		Hiding = (int)EStatusChange.Hiding,
		Sight = (int)EStatusChange.Sight
	}

}
