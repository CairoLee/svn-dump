using System.Xml.Serialization;
using FreeWorld.Engine.Geometry.Camera;
using FreeWorld.Engine.TileEngine.Animation;
using GodLesZ.Library.Xna.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Engine.TileEngine {
	
	public class TileAnimationLayer {
		private TileAnimation[][] mLayoutMap;

		[XmlIgnore]
		public int Width {
			get { return mLayoutMap.Length; }
		}

		[XmlIgnore]
		public int Height {
			get { return mLayoutMap[0].Length; }
		}

		public TileAnimation[][] LayoutMap {
			get { return mLayoutMap; }
			set { mLayoutMap = value; }
		}



		public TileAnimationLayer(int width, int height) {
			mLayoutMap = new TileAnimation[width][];

			for (int x = 0; x < width; x++) {
				mLayoutMap[x] = new TileAnimation[height];
				for (int y = 0; y < height; y++)
					mLayoutMap[x][y] = null;
			}
		}

		public TileAnimationLayer(TileAnimation[][] existingMap) {
			mLayoutMap = (TileAnimation[][])existingMap.Clone();
		}

		public TileAnimationLayer(TileAnimation[][] existingMap, int newW, int newH) {
			mLayoutMap = new TileAnimation[newW][];

			for (int x = 0; x < newW; x++) {
				mLayoutMap[x] = new TileAnimation[newH];
				for (int y = 0; y < newH; y++) {
					if (existingMap == null || x >= existingMap.Length || y >= existingMap[x].Length)
						mLayoutMap[x][y] = null;
					else
						mLayoutMap[x][y] = existingMap[x][y];
				}
			}
		}

		public TileAnimationLayer() {
		}


		public TileAnimation GetCell(int x, int y) {
			if (IsValidPoint(x, y) == false)
				return null;
			return mLayoutMap[x][y];
		}

		public TileAnimation GetCell(Point3D point) {
			return GetCell(point.X, point.Y);
		}

		public void SetCell(int x, int y, TileAnimation Ani) {
			if (IsValidPoint(x, y) == false)
				return;
			mLayoutMap[x][y] = Ani.Clone() as TileAnimation;
		}

		public void SetCell(Point point, TileAnimation Ani) {
			SetCell(point.X, point.Y, Ani);
		}


		public void Draw(SpriteBatch batch, IEngineCamera camera, double TotalSeconds) {
			Draw(batch, camera, TotalSeconds, new Point2D(0, 0), new Point2D(Width, Height));
		}

		public void Draw(SpriteBatch batch, IEngineCamera camera, double TotalSeconds, Point2D min, Point2D max) {

			for (var x = min.X; x < max.X; x++) {
				for (var y = min.Y; y < max.Y; y++) {
					var ani = GetCell(x, y);
					if (ani == null)
						continue;

					// Draw from bottom middle of the Cell
					ani.Draw(batch, camera, TotalSeconds, new Point2D(x * camera.TileWidth + camera.TileWidth / 2, y * camera.TileHeight + camera.TileHeight / 2));
				}
			}

		}


		private bool IsValidPoint(int x, int y) {
			return (mLayoutMap == null || x < 0 || x >= mLayoutMap.Length || y < 0 || y >= mLayoutMap[0].Length) == false;
		}

		private bool IsValidPoint(Point cell) {
			return IsValidPoint(cell.X, cell.Y);
		}

	}

}
