using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GodLesZ.eAthenaEditor.Editor.Controls;
using GodLesZ.eAthenaEditor.Library;
using GodLesZ.eAthenaEditor.Library.Document;

namespace GodLesZ.eAthenaEditor.Editor.Syntax {

	public class ScriptToolTipProvider {
		private ScriptTextEditorControl mEditor;

		public ScriptToolTipProvider(ScriptTextEditorControl Editor) {
			mEditor = Editor;
			mEditor.ActiveTextAreaControl.TextArea.ToolTipRequest += OnToolTipRequest;
		}


		private void OnToolTipRequest(object sender, ToolTipRequestEventArgs e) {
			if (e.InDocument == false || e.ToolTipShown == true) {
				return;
			}

			int offset = mEditor.Document.PositionToOffset(e.LogicalPosition);
			LineSegment line = mEditor.Document.GetLineSegmentForOffset(offset);
			TextWord word = line.GetWord(e.LogicalPosition.Column);
			if (word == null) {
				return;
			}
			
			string lineText = word.Word;
			if (lineText.Length > 0) {
				if (TextArea.ToolTipWnd == null) {

				}
				e.ShowToolTip(lineText);
			}

		}

	}

}
