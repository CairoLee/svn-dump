using System;

namespace FreeWorld.Game.Tests.Tmx {

	[Flags]
	public enum ETmxLayerTileFlip : uint {
		None = 0x0,

		Horizontally = 0x80000000,
		Vertically = 0x40000000,
		Diagonally = 0x20000000
	}

}