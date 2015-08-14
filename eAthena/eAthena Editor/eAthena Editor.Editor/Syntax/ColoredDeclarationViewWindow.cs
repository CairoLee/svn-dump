using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GodLesZ.eAthenaEditor.Library.Gui.CompletionWindow;
using System.Windows.Forms;

namespace GodLesZ.eAthenaEditor.Editor.Syntax {

	public class ColoredDeclarationViewWindow : DeclarationViewWindow {

		public ColoredDeclarationViewWindow(Form parent)
			: base(parent) {
		}


		protected override void OnPaint(PaintEventArgs pe) {
			if (Description != null && Description.Length > 0) {
				
			}
		}

	}
}
