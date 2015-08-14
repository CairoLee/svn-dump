using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.Library.ProcessEditAPI {
	
	public partial class ProcessEdit {

		public void PerformLeftKlick(int x, int y) {
			Imports.SetCursorPos(x, y);
			Imports.mouse_event((int)(EMouseEvents.ABSOLUTE | EMouseEvents.LEFTDOWN), 0, 0, 0, 0);
			Imports.mouse_event((int)(EMouseEvents.ABSOLUTE | EMouseEvents.LEFTUP), 0, 0, 0, 0);
		}

	}

}
