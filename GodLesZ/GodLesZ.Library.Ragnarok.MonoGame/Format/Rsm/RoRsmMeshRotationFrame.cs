using System.IO;
using GodLesZ.Library.Formats;
using GodLesZ.Library.MonoGame.Extensions;
using Microsoft.Xna.Framework;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Rsm {

	public class RoRsmMeshRotationFrame : GenericFileFormatData {

		/// <summary>
		/// 4 bytes
		/// </summary>
		public int Frame {
			get;
			set;
		}

		/// <summary>
		/// 12 bytes (3x float)
		/// </summary>
		public Vector3 Rotation {
			get;
			set;
		}


		public RoRsmMeshRotationFrame(BinaryReader bin, GenericFileFormatVersion version)
			: base(bin, version) {
			Frame = bin.ReadInt32();
			Rotation = bin.ReadVector3();
		}

	}

}
