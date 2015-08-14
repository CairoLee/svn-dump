using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	/// <summary>
	/// Character state status changes
	/// </summary>
	[Flags()]
	public enum EStatusOption {
		Nothing = 0x00000000,
		Sight = 0x00000001,
		Hide = 0x00000002,
		Cloak = 0x00000004,
		Cart1 = 0x00000008,
		Falcon = 0x00000010,
		Riding = 0x00000020,
		Invisible = 0x00000040,
		Cart2 = 0x00000080,
		Cart3 = 0x00000100,
		Cart4 = 0x00000200,
		Cart5 = 0x00000400,
		Orcish = 0x00000800,
		Wedding = 0x00001000,
		Ruwach = 0x00002000,
		Chasewalk = 0x00004000,
		Flying = 0x00008000,
		Xmas = 0x00010000,
		Transform = 0x00020000,
		Summer = 0x00040000,
		Dragon1 = 0x00080000,
		Wug = 0x00100000,
		Wugrider = 0x00200000,
		Madogear = 0x00400000,
		Dragon2 = 0x00800000,
		Dragon3 = 0x01000000,
		Dragon4 = 0x02000000,
		Dragon5 = 0x04000000,

		Cart = Cart1 | Cart2 | Cart3 | Cart4 | Cart5,
		Dragon = Dragon1 | Dragon2 | Dragon3 | Dragon4 | Dragon5,
		Mask = ~Invisible,
	}

}
