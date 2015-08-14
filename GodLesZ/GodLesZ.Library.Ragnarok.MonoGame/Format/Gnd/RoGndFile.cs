using System.Text;
using GodLesZ.Library.Formats;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Gnd {

	public class RoGndFile : GenericFileFormat {
		public const string FormatExtension = ".gnd";
		public static GraphicsDevice GraphicsDevice;

		private string mTextureRootPath;

		//public ExportedTextureData ExportedTexture = new ExportedTextureData();
		public Texture2D TexturesAll;

		public uint Width;
		public uint Height;
		public uint Ratio;
		public uint TextureCount;
		public uint TextureSize;

		public int LightmapCount;
		public int TileCount;
		public uint CubeCount;

		public RoGndTextureData[] Textures;
		public RoGndGridData Grid;
		public RoGndLitghmapData[] Lightmaps;
		public RoGndTileData[] Tiles;
		public RoGndCubeData[] Cubes;


		public RoGndFile(string filepath, string textureRoot)
			: base(Encoding.GetEncoding("ISO-8859-1")) {
			mTextureRootPath = textureRoot;

			if (filepath != null) {
				Read(filepath);
			}
		}


		protected override bool ReadInternal() {
			// Header
			Reader.BaseStream.Position += 4;

			Version = new GenericFileFormatVersion(Reader);
			Width = Reader.ReadUInt32();
			Height = Reader.ReadUInt32();
			Ratio = Reader.ReadUInt32();
			TextureCount = Reader.ReadUInt32();
			TextureSize = Reader.ReadUInt32();

			Textures = new RoGndTextureData[TextureCount];
			for (int i = 0; i < TextureCount; i++) {
				Textures[i] = new RoGndTextureData(Reader, Version, mTextureRootPath);
			}

			LightmapCount = Reader.ReadInt32();

			Grid = new RoGndGridData(Reader, Version);

			Lightmaps = new RoGndLitghmapData[LightmapCount];
			for (int i = 0; i < LightmapCount; i++) {
				Lightmaps[i] = new RoGndLitghmapData(Reader, Version);
			}


			TileCount = Reader.ReadInt32();
			Tiles = new RoGndTileData[TileCount];
			for (int i = 0; i < TileCount; i++) {
				Tiles[i] = new RoGndTileData(Reader, Version);
			}

			CubeCount = Width * Height;
			Cubes = new RoGndCubeData[CubeCount];
			for (int i = 0; i < CubeCount; i++) {
				Cubes[i] = new RoGndCubeData(Reader, Version);
			}
			return true;
		}


		/*
		[Serializable]
		public struct ExportedTextureDataValue {
			[XmlAttribute()]
			public int Width;
			[XmlAttribute()]
			public int Height;

			public ExportedTextureDataValue(int w, int h) {
				Width = w;
				Height = h;
			}
		}

		[Serializable]
		public struct ExportedTextureData {
			[XmlArrayItem("Data")]
			public List<ExportedTextureDataValue> Positions;

			public ExportedTextureDataValue this[int index] {
				get { return Positions[index]; }
			}

			public int Count {
				get { return Positions.Count; }
			}

			public void Add(int w, int h) {
				Add(new ExportedTextureDataValue(w, h));
			}

			public void Add(ExportedTextureDataValue pos) {
				if (Positions == null)
					Positions = new List<ExportedTextureDataValue>();

				Positions.Add(pos);
			}
		}

		public void ExportTextureMap(string Filename) {
			ExportedTexture = new ExportedTextureData();
			TexturesAll = null;

			Microsoft.Xna.Framework.Vector2 maxSize = Microsoft.Xna.Framework.Vector2.Zero;
			for (int i = 0; i < TextureCount; i++) {
				ExportedTexture.Add(Textures[i].TextureBmp.Width, Textures[i].TextureBmp.Height);
				maxSize.X += Textures[i].TextureBmp.Width;
				maxSize.Y = Math.Max(Textures[i].TextureBmp.Height, maxSize.Y);
			}

			Bitmap newImg = new Bitmap((int)maxSize.X, (int)maxSize.Y);
			int drawnWidth = 0;
			using (Graphics g = Graphics.FromImage(newImg)) {
				for (int i = 0; i < TextureCount; i++) {
					g.DrawImage(Textures[i].TextureBmp, drawnWidth, 0);
					drawnWidth += (int)ExportedTexture[i].Width;
				}
				g.Save();
			}

			TexturesAll = Convert.Image2Texture(newImg, GND.GraphicsDevice);

			if (Filename != string.Empty) {
				System.IO.File.Delete(Filename);
				newImg.Save(Filename);

				string FilenameXml = Path.Combine(Path.GetDirectoryName(Filename), Path.GetFileNameWithoutExtension(Filename)) + @".xml";
				System.IO.File.Delete(FilenameXml);

				try {
					XmlSerializer xml = new XmlSerializer(typeof(ExportedTextureData));
					using (FileStream s = System.IO.File.OpenWrite(FilenameXml))
						xml.Serialize(s, ExportedTexture);
				} catch (Exception e) {
					Debug.WriteLine(e);
				}
			}
		}
		*/

	}
}
