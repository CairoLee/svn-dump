using System.IO;

using Color = System.Drawing.Color;

namespace GodLesZ.Library.Ragnarok {

	public static class StreamExtensions {

		public static Color ReadRoSpriteColor(this BinaryReader bin) {
			return bin.ReadRoSpriteColor(true);
		}

		public static Color ReadRoSpriteColor(this BinaryReader bin, bool revertAlpha) {
			byte r = bin.ReadByte();
			byte g = bin.ReadByte();
			byte b = bin.ReadByte();
			byte a = bin.ReadByte();
			// Sprites using 255 for alpha, actions not..
			if (revertAlpha) {
				return Color.FromArgb(255 - a, r, g, b);
			}

			return Color.FromArgb(a, r, g, b);
		}

		public static void WriteRoSpriteColor(this BinaryWriter writer, Color c) {
			writer.WriteRoSpriteColor(c, true);
		}

		public static void WriteRoSpriteColor(this BinaryWriter writer, Color c, bool revertAlpha) {
			writer.Write(c.R);
			writer.Write(c.G);
			writer.Write(c.B);
			if (revertAlpha) {
				writer.Write((byte)(255 - c.A));
			} else {
				writer.Write(c.A);
			}
		}

	}

}
