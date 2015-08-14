using System.Drawing;
using System.IO;
using GodLesZ.Library.Xna.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;

namespace FreeWorld.Engine.Tools {

	public class DrawHelper {

		public static Point2D Vector2ToEngineCell(Vector2 position) {
			return new Point2D((int)(position.X / Constants.TileWidth), (int)(position.Y / Constants.TileHeight));
		}

		public static Point2D Point2ToEngineCell(Point2D position) {
			return new Point2D(position.X / Constants.TileWidth, position.Y / Constants.TileHeight);
		}

		public static Rectangle2D EngineCellToRect(Point2D cell) {
			return new Rectangle2D(cell.X * Constants.TileWidth, cell.Y * Constants.TileHeight, Constants.TileWidth, Constants.TileHeight);
		}

		public static Point2D EngineCellToPoint(Point2D cell) {
			return new Point2D(cell.X * Constants.TileWidth, cell.Y * Constants.TileHeight);
		}

		public static Vector2 EngineCellToVector(Point2D cell) {
			return new Vector2(cell.X * Constants.TileWidth, cell.Y * Constants.TileHeight);
		}

		/// <summary>
		/// Build's a <see cref="Texture2D"/> based on the given Width, Height, Color and Border width.
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="borderWidth"></param>
		/// <param name="col"></param>
		/// <returns></returns>
		public static Texture2D Rect2Texture(int width, int height, int borderWidth, Color col) {
			var rectangleTexture = new Texture2D(Constants.GraphicsDevice, width, height, false, SurfaceFormat.Color);
			var color = new Color[width * height];

			for (var i = 0; i < width * borderWidth; i++)
				color[i] = col;
			for (var i = color.Length - (width * borderWidth); i < color.Length; i++)
				color[i] = col;

			for (int i = 0; i < color.Length; i += width)
				color[i] = col;
			if (borderWidth > 1)
				for (int lw = 1; lw < borderWidth; lw++)
					for (int i = lw; i < color.Length; i += width)
						color[i] = col;

			for (int i = width - 1; i < color.Length; i += width)
				color[i] = col;
			if (borderWidth > 1)
				for (int lw = 2; lw < borderWidth + 1; lw++)
					for (int i = width - lw; i < color.Length; i += width)
						color[i] = col;

			rectangleTexture.SetData(color);

			return rectangleTexture;
		}

		/// <summary>
		/// Build's a <see cref="Texture2D"/> from a <see cref="System.Drawing.Bitmap"/>
		/// </summary>
		/// <param name="bitmap"></param>
		/// <returns></returns>
		public static Texture2D Bitmap2Texture(Bitmap bitmap) {
			Texture2D texture;
			using (var s = new MemoryStream()) {
				bitmap.Save(s, System.Drawing.Imaging.ImageFormat.Png);
				s.Seek(0, SeekOrigin.Begin);
				texture = Texture2D.FromStream(Constants.GraphicsDevice, s);
			}

			return texture;
		}

		/// <summary>
		/// Builds a <see cref="System.Drawing.Bitmap"/> from an XNA <see cref="Texture2D"/>
		/// <para>... i hate unsafe Methods &lt;.&lt;</para>
		/// </summary>
		/// <param name="texture"></param>
		/// <returns></returns>
		public static Bitmap Texture2Image(Texture2D texture) {
			/*
			var data = new uint[texture.Width * texture.Height];
			texture.GetData(data);

			var bmp = new System.Drawing.Bitmap(texture.Width, texture.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			var bmpd = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			var ptr = (uint*)bmpd.Scan0.ToPointer();

			for (var x = 0; x < texture.Width; x++) {
				for (var y = 0; y < texture.Height; y++) {
					ptr[x + (y*texture.Width)] = data[x + (y*texture.Width)];
				}
			}

			bmp.UnlockBits(bmpd);

			return bmp;
			*/
			// @TODO: How to detect PixelFormat on Texture2D?
			using (var stream = new MemoryStream()) {
				texture.SaveAsPng(stream, texture.Width, texture.Height);
				return Image.FromStream(stream) as Bitmap;
			}
		}

	}

}
