using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {
	
	public enum EMonsterSkillState {
		Any = -1,
		Idle,
		Walk,
		Loot,
		Dead,
		Berserk,	//Aggressive mob attacking                       
		Angry,		//Mob retaliating from being attacked.           
		Rush,		//Mob following a player after being attacked.   
		Follow,		//Mob following a player without being attacked. 
		Anytarget,
	}
}
