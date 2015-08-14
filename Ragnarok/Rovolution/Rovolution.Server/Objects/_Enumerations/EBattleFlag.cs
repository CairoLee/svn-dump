using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {
	
	[Flags()]
	public enum EBattleFlag {
		None = 0,

		Weapon = 0x0001,
		Magic = 0x0002,
		Misc = 0x0004,
		Short = 0x0010,
		Long = 0x0040,
		Skill = 0x0100,
		Normal = 0x0200,
		Weaponmask = 0x000f,
		Rangemask = 0x00f0,
		Skillmask = 0x0f00,
	}
}
