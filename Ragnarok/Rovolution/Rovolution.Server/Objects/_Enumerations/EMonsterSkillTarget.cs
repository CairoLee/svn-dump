using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public enum EMonsterSkillTarget : short {
		//target: The target of the skill can be: target (current target) / self / friend / 
		// master / randomtarget (any enemy within skill's range)
		// (the following are for ground-skills, a random target tile is selected from
		// the specified area):
		// around1 (3x3 area around self) / around2 (5x5 area around self) /
		// around3 (7x7 area around self) / around4 (9x9 area around self) /
		// around5 (3x3 area around target) / around6 (5x5 area around target) /
		// around7 (7x7 area around target) / around8 (9x9 area around target) /
		// around = around4

		/// <summary>
		/// Current target
		/// </summary>
		Target = 0,
		/// <summary>
		/// Random target
		/// </summary>
		Random,
		/// <summary>
		/// To himself
		/// </summary>
		Self,
		/// <summary>
		/// Any friendship monster
		/// </summary>
		Friend,
		/// <summary>
		/// Monsters master
		/// </summary>
		Master,
		/// <summary>
		/// 3x3 area around target
		/// </summary>
		Around5,
		/// <summary>
		/// 5x5 area around target
		/// </summary>
		Around6,
		/// <summary>
		/// 7x7 area around target
		/// </summary>
		Around7,
		/// <summary>
		/// 9x9 area around target
		/// </summary>
		Around8,
		/// <summary>
		/// 3x3 area around self
		/// </summary>
		Around1,
		/// <summary>
		/// 5x5 area around self
		/// </summary>
		Around2,
		/// <summary>
		/// 7x7 area around self
		/// </summary>
		Around3,
		/// <summary>
		/// 9x9 area around self
		/// </summary>
		Around4,

		/// <summary>
		/// Common option, copy of Around4 (9x9 around self)
		/// </summary>
		Around = Around4,
	}
}
