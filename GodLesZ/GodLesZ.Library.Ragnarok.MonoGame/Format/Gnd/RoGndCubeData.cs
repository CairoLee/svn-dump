using System.IO;
using GodLesZ.Library.Formats;
using GodLesZ.Library.MonoGame.Extensions;
using Microsoft.Xna.Framework;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Gnd {

	public class RoGndCubeData : GenericFileFormatData {

		public Vector4 Height;
		public int TileUp;
		public int TileSide;
		public int TileAside;


		public RoGndCubeData(BinaryReader bin, GenericFileFormatVersion version)
			: base(bin, version) {
			Height = bin.ReadVector4();
			TileUp = bin.ReadInt32();
			TileSide = bin.ReadInt32();
			TileAside = bin.ReadInt32();
		}

	}

}
