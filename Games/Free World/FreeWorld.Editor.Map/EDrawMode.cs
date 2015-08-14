using System;

namespace FreeWorld.Editor.Map {
	[Flags]
	public enum EDrawMode {
		None = 0,

		Draw = 1,
		Erase = 2,

		Rectangle = 4,

		Collision = 8,

		Rotate = 16,

		Flipping = 64,

		Fill = 128,


		Autotile = 256,
		Animation = 512,
		Objects = 1024,

		NotTilesetMode = (Autotile | Animation | Objects)
	}
}