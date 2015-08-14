using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public enum ESkillInf2 {
		Quest = 1,
		Npc = 0x2,
		Wedding = 0x4,
		Spirit = 0x8,
		Guild = 0x10,
		SongDance = 0x20,
		Esemble = 0x40,
		Trap = 0x80,
		TargetSelf = 0x100,
		NoTragetSelf = 0x200,
		PartyOnly = 0x400,
		GuildOnly = 0x800,
		NoEnemy = 0x1000
	}

}
