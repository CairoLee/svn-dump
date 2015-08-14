using System;

namespace FreeWorld.Engine.TileEngine {

	[Flags()]
	public enum ETileDrawType {
		BackGround = 1,
		ForeGround = 2,
		Collision = 4,
		Fog = 8,
		Animation = 16,

		All = (ETileDrawType.BackGround | ETileDrawType.ForeGround | ETileDrawType.Collision | ETileDrawType.Fog | ETileDrawType.Animation)
	}

}
