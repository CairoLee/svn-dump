using System;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Engine.TileEngine {

	[Serializable]
	public class TileCellSource : ICloneable {
		protected Texture2D mTexture = null;

		[XmlIgnore]
		public static readonly TileCellSource Empty = new TileCellSource();

		[XmlAttribute]
		public string TextureIndex = "001";
		[XmlAttribute]
		public int X;
		[XmlAttribute]
		public int Y;
		[XmlAttribute]
		public int Width;
		[XmlAttribute]
		public int Height;
		[XmlAttribute]
		public bool IsAutotile;


		public TileCellSource()
			: this("", 0, 0, 0, 0) {
		}

		public TileCellSource(string index, int x, int y, int w, int h) {
			TextureIndex = index;
			X = x;
			Y = y;
			Width = w;
			Height = h;
		}


		public static TileCellSource Parse(string text) {
			var parts = text.Split(',');
			var src = new TileCellSource {
				TextureIndex = parts[0].Trim(),
				X = int.Parse(parts[1]),
				Y = int.Parse(parts[2]),
				Width = int.Parse(parts[3]),
				Height = int.Parse(parts[4])
			};

			return src;
		}


		/// <exception cref="Exception">Failed to load texture tileset</exception>
		public Texture2D LoadTexture(TileCell cell = null) {
			if (mTexture == null) {
				if (cell == null) {
					throw new Exception("Need a cell to load autotile or non autotile source");
				}

				mTexture = cell.IsAutoTexture ? EngineCore.ContentLoader.GetAutotile(TextureIndex) : EngineCore.ContentLoader.GetTileset(TextureIndex);
			}
			if (mTexture == null) {
				throw new Exception("Failed to load texture tileset");
			}

			return mTexture;
		}


		public virtual void LoadContent(ContentManager content) {

		}

		public bool IsEqualTo(TileCellSource source) {
			if (TextureIndex != source.TextureIndex) {
				return false;
			}
			if (X != source.X) {
				return false;
			}
			if (Y != source.Y) {
				return false;
			}
			if (Width != source.Width) {
				return false;
			}
			if (Height != source.Height) {
				return false;
			}
			if (IsAutotile != source.IsAutotile) {
				return false;
			}

			return true;
		}


		public Rectangle ToRectangle() {
			return new Rectangle(X, Y, Width, Height);
		}

		public override string ToString() {
			return string.Format("index={0},x={1},y={2},w={3},h={4},auto={5}", TextureIndex, X, Y, Width, Height, IsAutotile);
		}

		public object Clone() {
			return new TileCellSource(TextureIndex, X, Y, Width, Height);
		}
	}

}
