using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {
	
	[Flags()]
	public enum EItemEquipLocation {
		None = 0x0,
		HeadLow = 0x0001,
		HeadMid = 0x0200, //512
		HeadTop = 0x0100, //256
		HandRight = 0x0002,
		HandLeft = 0x0020, //32
		Armor = 0x0010, //16
		Shoes = 0x0040, //64
		Garment = 0x0004,
		AccessoryLeft = 0x0008,
		AccessoryRight = 0x0080, //128
		Ammo = 0x8000, //32768

		Weapon = HandRight,
		Shield = HandLeft,
		Arms = (HandRight | HandLeft),
		Helm = (HeadLow | HeadMid | HeadTop),
		Accessory = (AccessoryLeft | AccessoryRight)
	}

}
