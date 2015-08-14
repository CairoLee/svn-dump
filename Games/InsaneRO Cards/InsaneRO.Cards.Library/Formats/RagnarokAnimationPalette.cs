using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Microsoft.Xna.Framework;

namespace InsaneRO.Cards.Library.Formats {

	public class RagnarokAnimationPalette : List<Color> {

		public RagnarokAnimationPalette(int num)
			: base(num) {
		}


		public void ReadColor(BinaryReader Reader) {
			byte r = Reader.ReadByte();
			byte g = Reader.ReadByte();
			byte b = Reader.ReadByte();
			this.Add(new Color(r, g, b));
		}


		public void WriteColor(int i, BinaryWriter Writer) {
			Color c = this[i];
			Writer.Write(c.R);
			Writer.Write(c.G);
			Writer.Write(c.B);
		}

	}

}
