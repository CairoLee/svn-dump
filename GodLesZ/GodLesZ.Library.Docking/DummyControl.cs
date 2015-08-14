using System;
using System.Windows.Forms;

namespace GodLesZ.Library.Docking {
	internal class DummyControl : Control {
		public DummyControl() {
			SetStyle(ControlStyles.Selectable, false);
		}
	}
}
