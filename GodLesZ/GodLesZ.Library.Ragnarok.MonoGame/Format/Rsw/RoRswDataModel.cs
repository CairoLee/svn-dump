using System.IO;
using GodLesZ.Library.Formats;
using GodLesZ.Library.MonoGame.Extensions;
using Microsoft.Xna.Framework;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Rsw {

	public class RoRswDataModel : GenericFileFormatData {

		/// <summary>40 chars, prefixed with: "data\model\"</summary>
		public string name;
		public int unk1;// (version >= 1.3)
		public float unk2;// (version >= 1.3)
		public float unk3;// (version >= 1.3)
		public string filename; // 40
		public string reserved; // 40
		public string type; // 20
		public string sound; // 20
		public string todo1; // 40
		public Vector3 pos;
		public Vector3 rot;
		public Vector3 scale;


		public RoRswDataModel(BinaryReader reader, GenericFileFormatVersion version)
			: base(reader, version) {
			name = reader.ReadWord(40);
			if (version.IsCompatible(1, 3)) {
				unk1 = reader.ReadInt32();
				unk2 = reader.ReadSingle();
				unk3 = reader.ReadSingle();
			}
			filename = reader.ReadWord(40);
			reserved = reader.ReadWord(40);
			type = reader.ReadWord(20);
			sound = reader.ReadWord(20);
			todo1 = reader.ReadWord(40);
			pos = reader.ReadVector3();
			rot = reader.ReadVector3();
			scale = reader.ReadVector3();
		}

	}

}
