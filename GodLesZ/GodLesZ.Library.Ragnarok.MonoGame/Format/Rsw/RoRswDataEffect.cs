using System.IO;
using GodLesZ.Library.Formats;
using GodLesZ.Library.MonoGame.Extensions;
using Microsoft.Xna.Framework;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Rsw {

	public class RoRswDataEffect : GenericFileFormatData {

		public string name; // 40
		public float unk1; // 9
		public int category;
		public Vector3 pos;
		public int type;
		public float loop;
		public float[] unk2; // 2
		public int[] unk3; // 2


		public RoRswDataEffect(BinaryReader reader, GenericFileFormatVersion version)
			: base(reader, version) {
			name = reader.ReadWord(40);
			unk1 = reader.ReadSingle();
			category = reader.ReadInt32();
			pos = reader.ReadVector3();
			type = reader.ReadInt32();
			loop = reader.ReadSingle();
			unk2 = new float[2] {
				reader.ReadSingle(),
				reader.ReadSingle()
			};
			unk3 = new int[2] {
				reader.ReadInt32(),
				reader.ReadInt32()
			};
		}

	}

}
