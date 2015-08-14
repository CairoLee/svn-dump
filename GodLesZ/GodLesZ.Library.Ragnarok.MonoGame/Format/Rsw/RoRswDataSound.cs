using System.IO;
using GodLesZ.Library.Formats;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Rsw {

	public class RoRswDataSound : GenericFileFormatData {

		public string name; // 80
		public string filename; // 80
		public float[] unk; // 8


		public RoRswDataSound(BinaryReader reader, GenericFileFormatVersion version)
			: base(reader, version) {
			name = reader.ReadWord(80);
			filename = reader.ReadWord(80);

			// TODO: Looks like a matrix
			unk = new float[8]{
					reader.ReadSingle(),
					reader.ReadSingle(),
					reader.ReadSingle(),
					reader.ReadSingle(),
					reader.ReadSingle(),
					reader.ReadSingle(),
					reader.ReadSingle(),
					reader.ReadSingle()
				};
		}

	}

}
