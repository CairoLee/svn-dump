using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GodLesZ.Library.Formats;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Rsm {

	public class RoRsmFile : GenericFileFormat {

		public char[] MagicHead;	// 0: 4x Char

		public byte Alpha;
		public int AnimationLen;
		public int ShadowType;

		/// <summary>
		/// Texture Names ( 40 * TextureNameCount )
		/// </summary>
		public int TextureNameCount;	// 4 bytes
		public string[] TextureNames;	// ( 40 * TextureNameCount ) bytes

		public string MainNode;

		/// <summary>
		/// Meshes ( 94 bytes )
		/// </summary>
		public List<RoRsmMesh> Meshes = new List<RoRsmMesh>();


		public RoRsmFile()
			: base(Encoding.GetEncoding("ISO-8859-1")) {
		}

		public RoRsmFile(string filename)
			: base(filename, Encoding.GetEncoding("ISO-8859-1")) {
		}

		public RoRsmFile(Stream stream)
			: base(stream, Encoding.GetEncoding("ISO-8859-1")) {
		}


		protected override bool ReadInternal() {
			MagicHead = Reader.ReadChars(4);
			Version = new GenericFileFormatVersion(Reader);

			AnimationLen = Reader.ReadInt32();
			ShadowType = Reader.ReadInt32();
			if (Version.IsCompatible(1, 4)) {
				Alpha = Reader.ReadByte();
			}

			Reader.BaseStream.Position += 16;

			TextureNameCount = Reader.ReadInt32();
			TextureNames = new string[TextureNameCount];
			for (int i = 0; i < TextureNameCount; i++) {
				TextureNames[i] = Reader.ReadWord(40);
			}

			MainNode = Reader.ReadWord(40);
			int nodeCount = Reader.ReadInt32();
			for (int i = 0; i < nodeCount; i++) {
				ReadMesh();
			}

			if (Meshes.Count == 1) {
				Meshes[0].IsOnly = true;
			}

			return true;
		}

		protected virtual void ReadMesh() {
			RoRsmMesh m = new RoRsmMesh(Reader, Version);
			if (m.IsValid == true) {
				//m.SetUpVertices( mDevice );
				Meshes.Add(m);
			} else {
				// TODO: debug in valid meshes
			}
		}

	}

}
