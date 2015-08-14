using System.IO;
using GodLesZ.Library.Formats;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Rsm {

	public class RoRsmMeshHeader : GenericFileFormatData {

		/// <summary>
		/// 40 bytes
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// 4 bytes
		/// </summary>
		public int UnknownInt {
			get;
			set;
		}

		/// <summary>
		/// 40 bytes
		/// </summary>
		public string ParentName {
			get;
			set;
		}


		public RoRsmMeshHeader(BinaryReader bin, GenericFileFormatVersion version)
			: base(bin, version) {
			Name = bin.ReadWord(40);
			ParentName = bin.ReadWord(40);
		}

	}

}
