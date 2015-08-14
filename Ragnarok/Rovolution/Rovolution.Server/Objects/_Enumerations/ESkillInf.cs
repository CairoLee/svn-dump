using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {
	
	[Flags()]
	public enum ESkillInf {
		AttackSkill = 1,
		GroundSkill = 2,
		SelfSkill = 4,
		SupportSkill = 16,
		TargetTrap = 32
	}

}
