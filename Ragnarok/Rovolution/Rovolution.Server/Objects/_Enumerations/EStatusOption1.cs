using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	/// <summary>
	/// Non-stackable status changes
	/// </summary>
	public enum EStatusOption1 {
		None = 0,
		Stone = 1, // Petrified
		Freeze,
		Stun,
		Sleep,
		// Aegis uses OPT1 = 5 to identify undead enemies (which also grants them immunity to the other opt1 changes)
		Stonewait = 6, // Petrifying
		Burning,
		Imprison,
	}

}
