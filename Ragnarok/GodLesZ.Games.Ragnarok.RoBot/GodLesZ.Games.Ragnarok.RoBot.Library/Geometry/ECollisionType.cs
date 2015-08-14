using System;

namespace GodLesZ.Games.Ragnarok.RoBot.Library.Geometry {

	[Flags()]
	public enum ECollisionType : byte {
		/*
		Moveable = 1,
		NotMoveable = 2,
		Clifable = 4,
		Water = 8,
		Underwater = 16,
		*/

		// Default value
		NotWalkable = 0,
		NotReachable = 0,
		// Terrain flags
		Walkable = 1,
		Reachable = 1,
		Shootable = 2,
		Water = 4,

		// Dynamic flags
		Npc = 8,
		Basilica = 16,
		Landprotector = 32,
		NoVending = 64,
		NoChat = 128
	}

}
