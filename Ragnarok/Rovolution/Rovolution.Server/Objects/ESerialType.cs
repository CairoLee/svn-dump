using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server {

	public enum ESerialType {
		None = 0,
		All = 0,

		Account,
		Char,
		// Skill ?
		Party,
		Guild,

		Mob,
		Item,
		Npc,

		Homunculus,
		Pet
	}

}
