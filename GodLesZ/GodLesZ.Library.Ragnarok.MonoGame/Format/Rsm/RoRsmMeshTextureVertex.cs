using System.IO;
using GodLesZ.Library.Formats;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Rsm {

	public class RoRsmMeshTextureVertex : GenericFileFormatData {

		public uint Color {
			get;
			set;
		}

		public float U {
			get;
			set;
		}

		public float V {
			get;
			set;
		}


		public RoRsmMeshTextureVertex(BinaryReader bin, GenericFileFormatVersion version)
			: base(bin, version) {
			Color = (version.IsCompatible(1, 2) == false ? 0xFFFFFFFF : bin.ReadUInt32());
			U = bin.ReadSingle();
			V = bin.ReadSingle();
		}

	}

}
