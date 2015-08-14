using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GodLesZ.eAthenaEditor.Editor.Syntax {

	public class ScriptEntityMob : ScriptEntity {
		private string mClass = "";
		private string mCount = "";

		public ScriptEntityMob(string name, string mapDef, string amountDef, bool isBoss, int offsetStart, int offsetEnd)
			: base(mapDef, (isBoss ? "monster" : "boss_monster"), name, amountDef, (isBoss ? EScriptEnityType.BossMonster : EScriptEnityType.Monster), offsetStart, offsetEnd) {
			FetchMobData();
		}


		public override string GetComboListItemTitle() {
			return string.Format("{0}{1} (ID {2}, {3}x)", (Type == EScriptEnityType.BossMonster ? "[BOSS]" : ""), W3, mClass, mCount);
		}


		private void FetchMobData() {
			Regex reCount = new Regex("^([0-9]+),([0-9]+)", RegexOptions.Compiled);
			Match m = null;

			if ((m = reCount.Match(W4)).Success == true) {
				mClass = m.Groups[1].Captures[0].Value;
				mCount = m.Groups[2].Captures[0].Value;
			}

		}


		public override string ToString() {
			return string.Format("{0}Mob: {1} (ID {2}, {3}x)", (Type == EScriptEnityType.BossMonster ? "Boss " : ""), W3, mClass, mCount);
		}

	}

}
