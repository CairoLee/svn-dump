using System.Drawing;
using System.IO;
using GodLesZ.Library.Formats;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Gnd {

	public class RoGndTextureData : GenericFileFormatData {

		public string TexturePath;	// size: 40 [cap at \0]
		public char[] Unknown;		// size: 40

		public Bitmap TextureBmp;
		public Texture2D TextureTex;


		public RoGndTextureData(BinaryReader bin, GenericFileFormatVersion version, string texRootPath)
			: this(bin, version, texRootPath, null) {
		}

		public RoGndTextureData(BinaryReader bin, GenericFileFormatVersion version, string texRootPath, GraphicsDevice device)
			: base(bin, version) {
			TexturePath = bin.ReadWord(40).ToLower();
			Unknown = bin.ReadWord(40).ToCharArray();
			TextureBmp = Bitmap.FromFile(texRootPath + @"\" + TexturePath) as Bitmap;

			if (device != null) {
			}
		}

	}

}
