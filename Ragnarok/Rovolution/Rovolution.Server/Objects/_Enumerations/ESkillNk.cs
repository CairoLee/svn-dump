using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	/// <summary>
	/// Constants to identify a skill's nk value (damage properties).
	/// The NK value applies only to non INF_GROUND_SKILL skill when determining skill castend function to invoke.
	/// </summary>
	public enum ESkillNk {
		NoDamage = 0x01,
		Splash = (0x02 | ESkillNk.SplashSplit),
		SplashSplit = 0x04,
		NoCardfixAtk = 0x08,
		NoElefix = 010,
		IgnoreDef = 0x20,
		IgnoreFlee = 0x40,
		NoCardfixDef = 0x80
	}

}
