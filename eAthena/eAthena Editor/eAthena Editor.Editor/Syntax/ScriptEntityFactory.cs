using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.eAthenaEditor.Editor.Syntax {

	public class ScriptEntityFactory {

		public static ScriptEntity CreateEntity(string w1, string w2, string w3, string w4, int offStart, int offEnd) {
			ScriptEntity entity = null;

			string type = w2.ToLower().Trim();
			if (w1.ToLower() == "function") {
				entity = new ScriptEntityFunction(w3, false, offStart, offEnd);
			} else if (type == "script") {
				entity = new ScriptEntityNpc(w3, w1, offStart, offEnd);
			} else if (type == "monster" || type == "boss_monster") {
				entity = new ScriptEntityMob(w3, w1, w4, (w2 == "boss_monster"), offStart, offEnd);
			} else {
				entity = new ScriptEntity(w1, w2, w3, w4, EScriptEnityType.Unknown, offStart, offEnd);
			}

			return entity;
		}

	}

}
