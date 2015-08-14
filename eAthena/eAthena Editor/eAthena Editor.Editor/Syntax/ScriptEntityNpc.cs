using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GodLesZ.eAthenaEditor.Editor.Syntax {

	public class ScriptEntityNpc : ScriptEntity {

		public ScriptEntityNpc(string name, string mapDef, int offsetStart, int offsetEnd)
			: base(mapDef, "script", name, "", EScriptEnityType.ScriptNpc, offsetStart, offsetEnd) {
		}


		public override string GetComboListItemTitle() {
			string name = string.Format("{0} ({1})", W3, FetchNpcHidden());
			return name;
		}

		private string FetchNpcHidden() {
			Regex reMap = new Regex("^([0-9a-z_]+),([0-9]+),([0-9]+)", RegexOptions.Compiled);
			Match m = null;
			string name = "";

			if (W1 == "-" || W1 == "-1" || (m = reMap.Match(W1)).Success == false) {
				name = "hidden";
			} else {
				name = string.Format("{0} [{1}/{2}]", m.Groups[1].Captures[0].Value, m.Groups[2].Captures[0].Value, m.Groups[3].Captures[0].Value);
			}

			return name;
		}


		public override string ToString() {
			return string.Format("NPC: {0} ({1})", Name, FetchNpcHidden());
		}
	}

}
