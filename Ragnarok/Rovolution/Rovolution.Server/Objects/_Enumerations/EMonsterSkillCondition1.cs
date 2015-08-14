using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public enum EMonsterSkillCondition1 : short {
		Always = 0x0000,
		Myhpltmaxrate,
		Myhpinrate,
		Friendhpltmaxrate,
		Friendhpinrate,
		Mystatuson,
		Mystatusoff,
		Friendstatuson,
		Friendstatusoff,
		Attackpcgt,
		Attackpcge,
		Slavelt,
		Slavele,
		Closedattacked,
		Longrangeattacked,
		Afterskill,
		Skillused,
		Casttargeted,
		Rudeattacked,
		Masterhpltmaxrate,
		Masterattacked,
		Alchemist,
		Spawn,
	}
}
