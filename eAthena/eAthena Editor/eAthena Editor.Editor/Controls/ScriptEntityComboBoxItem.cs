using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GodLesZ.eAthenaEditor.Editor.Syntax;

namespace GodLesZ.eAthenaEditor.Editor.Controls {

	public class ScriptEntityComboBoxItem : GodLesZ.Library.Controls.ImageComboBoxItem {

		public ScriptEntityComboBoxItem(ScriptEntityComboBox parent, IScriptEntity entity)
			: base(entity.Name, parent.Font, parent.ForeColor, GodLesZ.Library.Controls.EImageComboBoxTextAlign.Right) {
			if (entity.Type == EScriptEnityType.ScriptNpc) {
				ImageIndex = 2;
			} else if (entity.Type == EScriptEnityType.Monster || entity.Type == EScriptEnityType.BossMonster) {
				ImageIndex = 3;
			} else if (entity.Type == EScriptEnityType.ScriptFunctionAbstract) {
				ImageIndex = 1;
			} else if (entity.Type == EScriptEnityType.ScriptFunctionInline) {
				ImageIndex = 0;
			}
		}

	}

}

