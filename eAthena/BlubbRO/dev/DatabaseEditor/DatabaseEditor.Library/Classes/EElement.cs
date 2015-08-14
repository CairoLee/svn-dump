using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseEditor.Library.Classes {

	[Flags()]
	public enum EElement {
		Neutral = 0,
		Water,
		Earth,
		Fire,
		Wind,
		Poison,
		Holy,
		Dark,
		Ghost,
		Undead,
	}

}
