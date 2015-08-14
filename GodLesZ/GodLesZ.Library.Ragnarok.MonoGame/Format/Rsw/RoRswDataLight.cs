using System.IO;
using GodLesZ.Library.Formats;
using GodLesZ.Library.MonoGame.Extensions;
using Microsoft.Xna.Framework;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Rsw {

	public class RoRswDataLight : GenericFileFormatData {

		public string name; // 40
		public Vector3 pos;
		public char[] unk1; // 40
		public Vector3 color;
		public float unk2;


		public RoRswDataLight(BinaryReader reader, GenericFileFormatVersion version)
			: base(reader, version) {
			name = reader.ReadWord(40);
			pos = reader.ReadVector3();
			unk1 = reader.ReadChars(40);
			color = reader.ReadVector3();
			unk2 = reader.ReadSingle();
		}

	}

}
