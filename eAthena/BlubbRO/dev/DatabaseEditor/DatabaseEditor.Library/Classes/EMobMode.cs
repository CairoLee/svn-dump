using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseEditor.Library.Classes {

	[Flags()]
	public enum EMobMode {
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
		ChangetargetMelee = 0x1000,
		ChangetargetChase = 0x2000,
		TargetWeak = 0x4000,
	}

}
