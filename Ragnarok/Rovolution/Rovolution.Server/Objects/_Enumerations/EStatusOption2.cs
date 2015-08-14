using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	/// <summary>
	/// Stackable status changes
	/// </summary>
	[Flags()]
	public enum EStatusOption2 {
		None = 0,
		Poison = 0x0001,
		Curse = 0x0002,
		Silence = 0x0004,
		Signumcrucis = 0x0008,
		Blind = 0x0010,
		Angelus = 0x0020,
		Bleeding = 0x0040,
		Dpoison = 0x0080,
		Fear = 0x0100
	}

}
