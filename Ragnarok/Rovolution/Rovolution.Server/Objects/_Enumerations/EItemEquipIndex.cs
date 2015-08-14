using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	/// <summary>
	/// Equip indexes constants. (eg: sd->equip_index[EQI_AMMO] returns the index where the arrows are equipped)
	/// </summary>
	public enum EItemEquipIndex {
		AccL = 0,
		AccR,
		Shoes,
		Garment,
		HeadLow,
		HeadMid,
		HeadTop,
		Armor,
		HandL,
		HandR,
		Ammo,

		Max
	}

}
