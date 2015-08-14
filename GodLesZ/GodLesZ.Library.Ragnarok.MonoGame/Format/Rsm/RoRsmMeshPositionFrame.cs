using System.IO;
using GodLesZ.Library.Formats;
using GodLesZ.Library.MonoGame.Extensions;
using Microsoft.Xna.Framework;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Rsm {

	public class RoRsmMeshPositionFrame : GenericFileFormatData {

		/// <summary>
		/// 4 bytes
		/// </summary>
		public int Frame {
			get;
			set;
		}

		/// <summary>
		/// 16 bytes (4x float)
		/// </summary>
		public Vector4 Position {
			get;
			set;
		}


		public RoRsmMeshPositionFrame(BinaryReader bin, GenericFileFormatVersion version)
			: base(bin, version) {
			Frame = bin.ReadInt32();
			Position = bin.ReadVector4();
		}

	}

}
