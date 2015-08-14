using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.eAthenaEditor.Editor.Syntax {

	public class ScriptEntityFunction : ScriptEntity {

		public bool IsAbstract {
			get { return Type == EScriptEnityType.ScriptFunctionAbstract; }
		}


		public ScriptEntityFunction(string name, bool inline, int offsetStart, int offsetEnd)
			: base("function", "script", name, "", (inline ? EScriptEnityType.ScriptFunctionInline : EScriptEnityType.ScriptFunctionAbstract), offsetStart, offsetEnd) {
		}


		public override string GetComboListItemTitle() {
			// TODO: decide between abstract and inline/macro
			return W3;
		}


		public override string ToString() {
			return string.Format("{0} function: {1}", (IsAbstract ? "Abstract" : "Inline"), Name);
		}
	}

}
