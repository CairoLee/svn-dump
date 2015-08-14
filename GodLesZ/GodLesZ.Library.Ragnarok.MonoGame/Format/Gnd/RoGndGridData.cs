using System.IO;
using GodLesZ.Library.Formats;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Gnd {

	public class RoGndGridData : GenericFileFormatData {

		public uint X;
		public uint Y;
		public uint Cells;


		public RoGndGridData(BinaryReader bin, GenericFileFormatVersion version)
			: base(bin, version) {
			X = bin.ReadUInt32();
			Y = bin.ReadUInt32();
			Cells = bin.ReadUInt32();
		}

	}

}
