using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GodLesZ.eAthenaEditor.Library.Gui.CompletionWindow;
using GodLesZ.eAthenaEditor.Library;
using System.Windows.Forms;
using GodLesZ.eAthenaEditor.Library.Document;

namespace GodLesZ.eAthenaEditor.Editor.Syntax {

	public class ScriptCompletionData : DefaultCompletionData {


		public ScriptCompletionData(string text, string documentation, int imageIndex)
			: base(text, documentation, imageIndex) {

	
		}



		public override bool InsertAction(TextArea textArea, char ch) {
			// If we pressed space or tab, add it after the completion data
			//if (ch == ' ' || ch == '\t') {
			//	Text += ch;
			//}

			base.InsertAction(textArea, ch);
			return false; // will insert the pressed char by regualr hjandleKey event
		}

	}

}
