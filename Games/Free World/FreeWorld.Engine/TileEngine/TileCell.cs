using System;
using System.Xml.Serialization;
using FreeWorld.Engine.Geometry.Camera;
using GodLesZ.Library.Xna.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Engine.TileEngine {

	[Serializable]
	public class TileCell : ICloneable, ITileCell {
		public static int TileWidth = 32;
		public static int TileHeight = 32;
		public static int TileDepth = 32;
		public static int CharTileWidth = 32;
		public static int CharTileHeight = 48;

		public static int AnimationTilesetWidth = 192;
		public static int AnimationTilesetHeight = 192;
		public static int AnimationWidth = 96;
		public static int AnimationHeight = 96;

		[XmlIgnore]
		public static readonly TileCell Empty = new TileCell(Point2D.Zero, TileCellSource.Empty, 1f, 0f);


		[XmlAttribute]
		public int X {
			get;
			set;
		}

		[XmlAttribute]
		public int Y {
			get;
			set;
		}

		public TileCellSource TextureSource {
			get;
			set;
		}

		[XmlAttribute]
		public float Alpha {
			get;
			set;
		}

		[XmlAttribute]
		public float Rotation {
			get;
			set;
		}

		[XmlAttribute]
		public EAutoTileType AutoTextureType {
			get;
			set;
		}

		[XmlAttribute]
		public SpriteEffects FlipEffect {
			get;
			set;
		}

		[XmlIgnore]
		public int SourceX {
			get { return TextureSource.X; }
			set { TextureSource.X = value; }
		}

		[XmlIgnore]
		public int SourceY {
			get { return TextureSource.Y; }
			set { TextureSource.Y = value; }
		}

		[XmlIgnore]
		public int Width {
			get { return TextureSource.Width; }
			set { TextureSource.Width = value; }
		}

		[XmlIgnore]
		public int Height {
			get { return TextureSource.Height; }
			set { TextureSource.Height = value; }
		}

		[XmlIgnore]
		public bool IsAutoTexture {
			get { return AutoTextureType != EAutoTileType.None; }
		}

		[XmlIgnore]
		public int Weight {
			get;
			set;
		}

		[XmlIgnore]
		public Texture2D Texture {
			get { return TextureSource.LoadTexture(this); }
		}


		public TileCell() {
			TextureSource = TileCellSource.Empty;
		}

		public TileCell(Point dest, TileCellSource source, float alpha, float rot) :
			this(new Point2D(dest.X, dest.Y), source, alpha, rot) {
		}

		public TileCell(Point2D dest, Rectangle sourceRect, string index, float alpha, float rot) :
			this(dest, new TileCellSource(index, sourceRect.X, sourceRect.Y, sourceRect.Width, sourceRect.Height), alpha, rot) {
		}

		public TileCell(Point2D dest, TileCellSource source, float alpha, float rot) {
			X = dest.X;
			Y = dest.Y;
			TextureSource = source;
			Alpha = alpha;
			Rotation = rot;
			AutoTextureType = EAutoTileType.None;
			FlipEffect = SpriteEffects.None;
		}

		public TileCell(TileCell oldCell) :
			this(new Point2D(oldCell.X, oldCell.Y), oldCell.TextureSource, oldCell.Alpha, oldCell.Rotation) {
			AutoTextureType = oldCell.AutoTextureType;
			FlipEffect = oldCell.FlipEffect;
		}


		/// <summary>Converts a pixel point to grid point</summary>
		/// <param name="p">A point of pixel coordinates.</param>
		/// <returns>Grid point.</returns>
		public static Point2D Pixel2Grid(Point2D p) {
			return Pixel2Grid(p, null);
		}

		/// <summary>Converts a pixel point to grid point</summary>
		/// <param name="p">A point of pixel coordinates.</param>
		/// <param name="tileWidth"></param>
		/// <param name="tileHeight"></param>
		/// <returns>Grid point.</returns>
		public static Point2D Pixel2Grid(Point2D p, int tileWidth, int tileHeight) {
			return Pixel2Grid(p.X, p.Y, tileWidth, tileHeight);
		}

		/// <summary>Converts a pixel point to grid point</summary>
		/// <param name="p">A point of pixel coordinates.</param>
		/// <param name="camera">A camera to take the tile size from (defaults to TileCell constants)</param>
		/// <returns>Grid point.</returns>
		public static Point2D Pixel2Grid(Point2D p, IEngineCamera camera) {
			return Pixel2Grid(p.X, p.Y, camera);
		}

		/// <summary>Converts a pixel point to grid point</summary>
		/// <param name="x">A X point of pixel coordinates.</param>
		/// <param name="y">A Y point of pixel coordinates.</param>
		/// <returns>Grid point.</returns>
		public static Point2D Pixel2Grid(int x, int y) {
			return Pixel2Grid(x, y, null);
		}

		/// <summary>Converts a pixel point to grid point</summary>
		/// <param name="x">A X point of pixel coordinates.</param>
		/// <param name="y">A Y point of pixel coordinates.</param>
		/// <param name="camera">A camera to take the tile size from (defaults to TileCell constants)</param>
		/// <returns>Grid point.</returns>
		public static Point2D Pixel2Grid(int x, int y, IEngineCamera camera) {
			int tileWidth = (camera != null ? camera.TileWidth : TileWidth);
			int tileHeight = (camera != null ? camera.TileHeight : TileHeight);
			return Pixel2Grid(x, y, tileWidth, tileHeight);
		}

		/// <summary>Converts a pixel point to grid point</summary>
		/// <param name="x">A X point of pixel coordinates.</param>
		/// <param name="y">A Y point of pixel coordinates.</param>
		/// <param name="tileWidth"></param>
		/// <param name="tileHeight"></param>
		/// <returns>Grid point.</returns>
		public static Point2D Pixel2Grid(int x, int y, int tileWidth, int tileHeight) {
			return new Point2D(x / tileWidth, y / tileHeight);
		}

		/// <summary>Converts a grid point to pixel point</summary>
		/// <param name="p">A point of grid coordinates.</param>
		/// <returns>Pixel point.</returns>
		public static Point2D Grid2Pixel(Point2D p) {
			return Grid2Pixel(p.X, p.Y);
		}

		/// <summary>Converts a grid point to pixel point</summary>
		/// <param name="p">A point of grid coordinates.</param>
		/// <param name="tileWidth"></param>
		/// <param name="tileHeight"></param>
		/// <returns>Pixel point.</returns>
		public static Point2D Grid2Pixel(Point2D p, int tileWidth, int tileHeight) {
			return Grid2Pixel(p.X, p.Y, tileWidth, tileHeight);
		}

		/// <summary>Converts a grid point to pixel point</summary>
		/// <param name="p">A point of grid coordinates.</param>
		/// <param name="camera">A camera to take the tile size from (defaults to TileCell constants)</param>
		/// <returns>Pixel point.</returns>
		public static Point2D Grid2Pixel(Point2D p, IEngineCamera camera) {
			return Grid2Pixel(p.X, p.Y, camera);
		}

		/// <summary>Converts a grid point to pixel point</summary>
		/// <param name="x">A X point of pixel coordinates.</param>
		/// <param name="y">A Y point of pixel coordinates.</param>
		/// <returns>Pixel point.</returns>
		public static Point2D Grid2Pixel(int x, int y) {
			return Grid2Pixel(x, y, null);
		}

		/// <summary>Converts a grid point to pixel point</summary>
		/// <param name="x">A X point of pixel coordinates.</param>
		/// <param name="y">A Y point of pixel coordinates.</param>
		/// <param name="camera">A camera to take the tile size from (defaults to TileCell constants)</param>
		/// <returns>Pixel point.</returns>
		public static Point2D Grid2Pixel(int x, int y, IEngineCamera camera) {
			int tileWidth = (camera != null ? camera.TileWidth : TileWidth);
			int tileHeight = (camera != null ? camera.TileHeight : TileHeight);
			return Grid2Pixel(x, y, tileWidth, tileHeight);
		}

		/// <summary>Converts a grid point to pixel point</summary>
		/// <param name="x">A X point of pixel coordinates.</param>
		/// <param name="y">A Y point of pixel coordinates.</param>
		/// <param name="tileWidth"></param>
		/// <param name="tileHeight"></param>
		/// <returns>Pixel point.</returns>
		public static Point2D Grid2Pixel(int x, int y, int tileWidth, int tileHeight) {
			return new Point2D(x * tileWidth, y * tileHeight);
		}

		public static Point2D Grid2PixelCenter(int x, int y) {
			return Grid2PixelCenter(x, y, null);
		}

		public static Point2D Grid2PixelCenter(int x, int y, IEngineCamera camera) {
			int tileWidth = (camera != null ? camera.TileWidth : TileWidth);
			int tileHeight = (camera != null ? camera.TileHeight : TileHeight);
			return Grid2Pixel(x, y) + new Point2D(tileWidth / 2, tileHeight / 2);
		}


		public virtual void LoadContent(ContentManager content) {
			TextureSource.LoadContent(content);
		}


		public bool IsEqualTo(TileCell cell) {
			if (X != cell.X || Y != cell.Y) {
				return false;
			}
			if (Alpha.Equals(cell.Alpha) == false)
				return false;
			if (Rotation.Equals(cell.Rotation) == false)
				return false;
			if (AutoTextureType != cell.AutoTextureType)
				return false;
			if (FlipEffect != cell.FlipEffect)
				return false;

			return TextureSource.IsEqualTo(cell.TextureSource);
		}

		/// <summary>
		/// Determines whether the point p corresponds to
		/// this cell, that is its X and Y coordinates are equal
		/// to the cell coordinates X and Y.
		/// </summary>
		/// <param name="p">A point of grid coordinates</param>
		/// <returns>True if the cell matches the given coordinates</returns>
		public bool Matches(Point2D p) {
			return p.X == X && p.Y == Y;
		}


		public override string ToString() {
			return string.Format("{5},TextureSource=[{0}],Alpha={1},Rotation={2},AutoTex={3},Flip={4},Pos={5}", TextureSource, Alpha, Rotation, (IsAutoTexture == false ? "false" : AutoTextureType.ToString()), FlipEffect, new Point2D(X, Y));
		}

		public object Clone() {
			var newCell = new TileCell(new Point2D(X, Y), TextureSource, Alpha, Rotation) {
				AutoTextureType = AutoTextureType,
				FlipEffect = FlipEffect
			};
			return newCell;
		}

		object ICloneable.Clone() {
			return Clone();
		}

	}

}
