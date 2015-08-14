using System;

namespace FreeWorld.Engine.TileEngine {


	[Serializable]
	[Flags()]
	public enum EAutoTileType {
		None = 0,

		StandAlone = 1,

		Left = 2,
		Right = 4,
		Top = 8,
		Bottom = 16,

		TopLeft = 32,
		TopRight = 64,
		BottomLeft = 128,
		BottomRight = 256,
	}

	public static class EAutoTileTypeExtension {

		public static bool Has(this EAutoTileType Type, EAutoTileType HasType) {
			return (Type & HasType) != EAutoTileType.None;
		}

		public static bool HasAll(this EAutoTileType Type, EAutoTileType HasType) {
			return (Type & HasType) == HasType;
		}

		public static bool HasNot(this EAutoTileType Type, EAutoTileType HasType) {
			return Type.Has(HasType) == false;
		}

	}

}
