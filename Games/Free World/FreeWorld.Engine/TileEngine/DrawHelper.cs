using GodLesZ.Library.Xna.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Engine.TileEngine {

	public class DrawHelper {

		public static Point3D Vector2ToEngineCell(Vector2 position) {
			return new Point3D((int)(position.X / (float)TileCell.TileWidth), (int)(position.Y / (float)TileCell.TileHeight), 0);
		}

		public static Point3D Point2ToEngineCell(Point3D position) {
			return new Point3D(position.X / TileCell.TileWidth, position.Y / TileCell.TileHeight, position.Z / TileCell.TileDepth);
		}

		public static Rectangle3D EngineCellToRect(Point3D cell) {
			return new Rectangle3D(cell.X * TileCell.TileWidth, cell.Y * TileCell.TileHeight, cell.Z * TileCell.TileDepth, TileCell.TileWidth, TileCell.TileHeight, TileCell.TileDepth);
		}

		public static Point3D EngineCellToPoint(Point3D cell) {
			return new Point3D(cell.X * TileCell.TileWidth, cell.Y * TileCell.TileHeight, cell.Z * TileCell.TileDepth);
		}

		public static Vector2 EngineCellToVector(Point3D cell) {
			return new Vector2(cell.X * TileCell.TileWidth, cell.Y * TileCell.TileHeight);
		}

		/// <summary>
		/// Build's a <see cref="Texture2D"/> based on the given Width, Height, Color and Border width.
		/// </summary>
		/// <param name="Width"></param>
		/// <param name="Height"></param>
		/// <param name="BorderWidth"></param>
		/// <param name="col"></param>
		/// <returns></returns>
		public static Texture2D Rect2Texture(int Width, int Height, int BorderWidth, Color col, GraphicsDevice gd) {
			Texture2D rectangleTexture = new Texture2D(gd, Width, Height, false, SurfaceFormat.Color);
			Color[] color = new Color[Width * Height];

			for (int i = 0; i < Width * BorderWidth; i++) {
				color[i] = col;
			}
			for (int i = color.Length - (Width * BorderWidth); i < color.Length; i++) {
				color[i] = col;
			}

			for (int i = 0; i < color.Length; i += Width) {
				color[i] = col;
			}
			if (BorderWidth > 1) {
				for (int lw = 1; lw < BorderWidth; lw++) {
					for (int i = lw; i < color.Length; i += Width) {
						color[i] = col;
					}
				}
			}

			for (int i = Width - 1; i < color.Length; i += Width) {
				color[i] = col;
			}
			if (BorderWidth > 1) {
				for (int lw = 2; lw < BorderWidth + 1; lw++) {
					for (int i = Width - lw; i < color.Length; i += Width) {
						color[i] = col;
					}
				}
			}

			rectangleTexture.SetData(color);

			return rectangleTexture;
		}

		/// <summary>
		/// Build's a <see cref="Texture2D"/> from an <see cref="Bitmap"/>
		/// </summary>
		/// <param name="Bitmap"></param>
		/// <returns></returns>
		public static Texture2D Bitmap2Texture(System.Drawing.Bitmap Bitmap, GraphicsDevice gd) {
			Texture2D texture = null;
			using (System.IO.MemoryStream s = new System.IO.MemoryStream()) {
				Bitmap.Save(s, System.Drawing.Imaging.ImageFormat.Png);
				s.Seek(0, System.IO.SeekOrigin.Begin);
				texture = Texture2D.FromStream(gd, s);
			}

			return texture;
		}

		/// <summary>
		/// Builds a <see cref="Image"/> from an XNA <see cref="Texture2D"/>
		/// <para>... i hate unsafe Methods &lt;.&lt;</para>
		/// </summary>
		/// <param name="Texture"></param>
		/// <returns></returns>
		public static unsafe System.Drawing.Bitmap Texture2Image(Texture2D Texture) {
			uint[] data = new uint[Texture.Width * Texture.Height];
			Texture.GetData<uint>(data);

			System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(Texture.Width, Texture.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			System.Drawing.Imaging.BitmapData bmpd = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			uint* ptr = (uint*)bmpd.Scan0.ToPointer();

			for (int x = 0; x < Texture.Width; x++) {
				for (int y = 0; y < Texture.Height; y++) {
					ptr[x + (y * Texture.Width)] = data[x + (y * Texture.Width)];
				}
			}

			bmp.UnlockBits(bmpd);

			return bmp;
		}

	}

}
