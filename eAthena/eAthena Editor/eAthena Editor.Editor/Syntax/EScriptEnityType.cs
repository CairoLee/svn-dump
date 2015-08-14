using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.eAthenaEditor.Editor.Syntax {

	public enum EScriptEnityType {
		Unknown = -1,

		ScriptNpc = 1,
		ScriptFunctionAbstract,
		ScriptFunctionInline,
		Warp,
		Shop,
		Cashshop,
		Monster,
		BossMonster,
		Mapflag
	}

}
