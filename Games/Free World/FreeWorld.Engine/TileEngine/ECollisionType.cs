using System;

namespace FreeWorld.Engine.TileEngine {

	[Flags()]
	public enum ECollisionType : byte {
		Moveable = 1,

		NotMoveable = 2,

		Clifable = 4,

		Water = 8,

		Underwater = 16,

		WalkSpot = 32,
		MobSpawn = 64,
		MobHome = 128
	}

}
