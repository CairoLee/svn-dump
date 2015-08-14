using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	/// <summary>
	/// SHOW_FEST_* .. w00tever
	/// </summary>
	[Flags()]
	public enum EStatusOption3 {
		Normal = 0x00000000,
		Quicken = 0x00000001,
		Overthrust = 0x00000002,
		Energycoat = 0x00000004,
		Explosionspirits = 0x00000008,
		Steelbody = 0x00000010,
		Bladestop = 0x00000020,
		Aurablade = 0x00000040,
		Berserk = 0x00000080,
		Lightblade = 0x00000100,
		Moonlit = 0x00000200,
		Marionette = 0x00000400,
		Assumptio = 0x00000800,
		Warm = 0x00001000,
		Kaite = 0x00002000,
		Bunsin = 0x00004000,
		Soullink = 0x00008000,
		Undead = 0x00010000,
		Contract = 0x00020000
	}

}
