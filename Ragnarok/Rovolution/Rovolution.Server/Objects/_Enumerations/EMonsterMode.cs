using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	[Flags()]
	public enum EMonsterMode {
		CanMove = 0x0001,
		Looter = 0x0002,
		Aggressive = 0x0004,
		Assist = 0x0008,
		CastsensorIdle = 0x0010,
		Boss = 0x0020,
		Plant = 0x0040,
		CanAttack = 0x0080,
		Detector = 0x0100,
		CastsensorChase = 0x0200,
		ChangeChase = 0x0400,
		Angry = 0x0800,
		ChangeTragetMeele = 0x1000,
		ChangeTargetChase = 0x2000,
		TargetWeak = 0x4000,
		Mask = 0xFFFF
	}
}
