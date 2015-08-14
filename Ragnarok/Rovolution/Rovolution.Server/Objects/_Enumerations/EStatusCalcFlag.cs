using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	[Flags()]
	public enum EStatusCalcFlag {
		None = 0x00000000,
		Base = 0x00000001,
		Maxhp = 0x00000002,
		Maxsp = 0x00000004,
		Str = 0x00000008,
		Agi = 0x00000010,
		Vit = 0x00000020,
		Int = 0x00000040,
		Dex = 0x00000080,
		Luk = 0x00000100,
		Batk = 0x00000200,
		Watk = 0x00000400,
		Matk = 0x00000800,
		Hit = 0x00001000,
		Flee = 0x00002000,
		Def = 0x00004000,
		Def2 = 0x00008000,
		Mdef = 0x00010000,
		Mdef2 = 0x00020000,
		Speed = 0x00040000,
		Aspd = 0x00080000,
		Dspd = 0x00100000,
		Cri = 0x00200000,
		Flee2 = 0x00400000,
		AtkEle = 0x00800000,
		DefEle = 0x01000000,
		Mode = 0x02000000,
		Size = 0x04000000,
		Race = 0x08000000,
		Range = 0x10000000,
		Regen = 0x20000000,
		Dye = 0x40000000,

		Battle = 0x3ffffffe,
		All = 0x3fffffff
	}
}
