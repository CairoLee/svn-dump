using System.IO;
using GodLesZ.Library.Formats;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Rsm {

	public class RoRsmMeshSurface : GenericFileFormatData {

		/// <summary>
		/// 3 * 2 bytes
		/// </summary>
		public ushort[] SurfaceVector {
			get;
			set;
		}

		/// <summary>
		/// 3 * 2 bytes
		/// </summary>
		public ushort[] TextureVector {
			get;
			set;
		}

		/// <summary>
		/// 2 bytes
		/// </summary>
		public ushort TextureID {
			get;
			set;
		}

		/// <summary>
		/// 2 bytes
		/// </summary>
		public ushort Padding {
			get;
			set;
		}

		/// <summary>
		/// 4 bytes
		/// </summary>
		public uint TwoSide {
			get;
			set;
		}

		/// <summary>
		/// 4 bytes
		/// </summary>
		public uint SmoothGroup {
			get;
			set;
		}


		public RoRsmMeshSurface(BinaryReader bin, GenericFileFormatVersion version)
			: base(bin, version) {
			SurfaceVector = new ushort[3];
			TextureVector = new ushort[3];
			for (int i = 0; i < SurfaceVector.Length; i++) {
				SurfaceVector[i] = bin.ReadUInt16();
			}
			for (int i = 0; i < TextureVector.Length; i++) {
				TextureVector[i] = bin.ReadUInt16();
			}

			TextureID = bin.ReadUInt16();
			Padding = bin.ReadUInt16();
			TwoSide = bin.ReadUInt32();
			if (version.IsCompatible(1, 2)) {
				SmoothGroup = bin.ReadUInt32();
			} else {
				SmoothGroup = 0;
			}
		}

	}

}
