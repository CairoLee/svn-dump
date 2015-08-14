using System.Xml.Serialization;
using FreeWorld.Engine.Geometry.Camera;
using GodLesZ.Library.Xna.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Engine.TileEngine {


	public class TileCollisionLayer {
		private ECollisionType[][] mLayoutMap;

		[XmlIgnore]
		public int Width {
			get { return mLayoutMap.Length; }
		}

		[XmlIgnore]
		public int Height {
			get { return mLayoutMap[0].Length; }
		}

		public ECollisionType[][] LayoutMap {
			get { return mLayoutMap; }
			set { mLayoutMap = value; }
		}

		public ECollisionType this[int x, int y] {
			get { return GetCell(x, y); }
			set { SetCell(x, y, value); }
		}

		public ECollisionType this[Point p] {
			get { return GetCell(p); }
			set { SetCell(p, value); }
		}

		public ECollisionType this[Point2D p] {
			get { return GetCell(p); }
			set { SetCell(p, value); }
		}



		public TileCollisionLayer() {
		}

		public TileCollisionLayer(int width, int height)
			: this(width, height, ECollisionType.Moveable) {
		}

		public TileCollisionLayer(int width, int height, ECollisionType type) {
			InitializeLayout(width, height, type);
		}

		public TileCollisionLayer(ECollisionType[][] existingMap) {
			mLayoutMap = (ECollisionType[][])existingMap.Clone();
		}

		public TileCollisionLayer(ECollisionType[][] existingMap, int newW, int newH) {
			if (existingMap == null) {
				InitializeLayout(newW, newH, ECollisionType.Moveable);
			} else {
				mLayoutMap = new ECollisionType[newW][];

				for (int x = 0; x < newW; x++) {
					mLayoutMap[x] = new ECollisionType[newH];
					for (int y = 0; y < newH; y++) {
						if (x >= existingMap.Length || y >= existingMap[x].Length) {
							mLayoutMap[x][y] = ECollisionType.Moveable;
						} else {
							mLayoutMap[x][y] = existingMap[x][y];
						}
					}
				}
			}
		}


		private void InitializeLayout(int width, int height, ECollisionType type) {
			mLayoutMap = new ECollisionType[width][];

			for (int x = 0; x < width; x++) {
				mLayoutMap[x] = new ECollisionType[height];
				for (int y = 0; y < height; y++) {
					mLayoutMap[x][y] = type;
				}
			}
		}


		#region GetCell
		public ECollisionType GetCell(int x, int y) {
			if (IsValidPoint(x, y) == false) {
				return ECollisionType.NotMoveable;
			}
			return mLayoutMap[x][y];
		}

		public ECollisionType GetCell(Point2D point) {
			return GetCell(point.X, point.Y);
		}

		public ECollisionType GetCell(Point point) {
			return GetCell(point.X, point.Y);
		}
		#endregion

		#region SetCell
		public void SetCell(int x, int y, ECollisionType Type) {
			if (IsValidPoint(x, y) == false) {
				return;
			}
			mLayoutMap[x][y] = Type;
		}

		public void SetCell(Point2D point, ECollisionType Type) {
			SetCell(point.X, point.Y, Type);
		}

		public void SetCell(Point point, ECollisionType Type) {
			SetCell(point.X, point.Y, Type);
		}
		#endregion

		public void RemoveType(ECollisionType existingType) {
			ReplaceIndex(existingType, ECollisionType.NotMoveable);
		}

		public void ReplaceIndex(ECollisionType existingType, ECollisionType newType) {
			for (int x = 0; x < Width; x++) {
				for (int y = 0; y < Height; y++) {
					if (GetCell(x, y) == existingType) {
						SetCell(x, y, newType);
					}
				}
			}
		}



		public void Draw(SpriteBatch batch, IEngineCamera camera) {
			Draw(batch, camera, new Point2D(0, 0), new Point2D(Width, Height));
		}

		public void Draw(SpriteBatch batch, IEngineCamera camera, Point2D min, Point2D max) {

			Rectangle destRect;
			Texture2D drawTex = Constants.TextureNotMoveable;
			Color drawColor = Constants.ColorNotMoveable;
			for (int x = min.X; x < max.X; x++) {
				for (int y = min.Y; y < max.Y; y++) {
					ECollisionType type = GetCell(x, y);
					if (type == ECollisionType.Moveable) {
						drawTex = Constants.TextureMoveable;
						drawColor = Constants.ColorMoveable;
					} else if (type == ECollisionType.Water) {
						drawTex = Constants.TextureWater;
						drawColor = Constants.ColorWater;
					} else if (type == ECollisionType.Underwater) {
						drawTex = Constants.TextureUnderwater;
						drawColor = Constants.ColorUnderwater;
					} else {
						// Default draw to not moveable
						drawTex = Constants.TextureNotMoveable;
						drawColor = Constants.ColorNotMoveable;
					}

					destRect = new Rectangle(x * camera.TileWidth, y * camera.TileHeight, camera.TileWidth, camera.TileHeight);
					batch.Draw(drawTex, destRect, drawColor);
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
