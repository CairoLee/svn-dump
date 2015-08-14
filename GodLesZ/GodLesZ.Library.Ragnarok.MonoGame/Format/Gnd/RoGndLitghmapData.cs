using System.IO;
using GodLesZ.Library.Formats;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Gnd {

	public class RoGndLitghmapData : GenericFileFormatData {

		public char[] brightness;	// size: 64
		public char[] colorrbg;		// size: 192


		public RoGndLitghmapData(BinaryReader bin, GenericFileFormatVersion version)
			: base(bin, version) {
			brightness = bin.ReadChars(64);
			colorrbg = bin.ReadChars(192);
		}

	}

}
