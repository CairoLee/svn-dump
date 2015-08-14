using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	[Flags]
	public enum EInputMethods {
		None = 0x00,
		Keyboard = 0x01,
		Mouse = 0x02,
		GamePad = 0x04,
		All = Keyboard | Mouse | 0x04
	}

}
