using System.IO;
using GodLesZ.Library.Formats;
using GodLesZ.Library.MonoGame.Extensions;
using Microsoft.Xna.Framework;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Gnd {

	public class RoGndTileData : GenericFileFormatData {

		/// <summary>
		/// 2 Linien, definiert mit jeweils 2 Punkten
		/// <para>Linie 1: P1 - P2 (oben)</para>
		/// <para>Linie 2: P3 - P4 (unten)</para>
		/// <para>[<c>P1</c>: Start Oben]  [<c>P2</c>: Ende Oben]</para>
		/// <para></para>
		/// <para></para>
		/// <para>[<c>P3</c>: Start Unten] [<c>P4</c>: Ende Unten]</para>
		/// </summary>
		public Vector4 VectorWidth;
		/// <summary>
		/// 2 Linien, definiert mit jeweils 2 Punkten
		/// <para>Linie 1: P1 - P3 (links)</para>
		/// <para>Linie 2: P2 - P4 (rechts)</para>
		/// <para>[<c>P1</c>: Start Links] [<c>P2</c>: Start Rechts]</para>
		/// <para></para>
		/// <para></para>
		/// <para>[<c>P3</c>: Ende Links]  [<c>P4</c>: Ende Rechts]</para>
		/// </summary>
		public Vector4 VectorHeight;
		public ushort TextureIndex;
		public ushort Lightmap;
		public char[] color;			// BGRA -- "A" seems to be ignored by the official client


		public RoGndTileData(BinaryReader bin, GenericFileFormatVersion version)
			: base(bin, version) {
			VectorWidth = bin.ReadVector4();
			VectorHeight = bin.ReadVector4();
			TextureIndex = bin.ReadUInt16();
			Lightmap = bin.ReadUInt16();
			color = bin.ReadChars(4);
		}

	}

}
