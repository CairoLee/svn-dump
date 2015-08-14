using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using FreeWorld.Engine.Geometry.Camera;
using GodLesZ.Library.Xna.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Engine.TileEngine {

	[Serializable]
	public class TileLayer : ICloneable {

		private TileCell[][] mLayoutMap;
		private float mAlpha = 1f;
		private string mName;
		private bool mIsBackground = true;
		private readonly Point mMinusOne = new Point(-1, -1);


		public TileCell[][] LayoutMap {
			get { return mLayoutMap; }
			set { mLayoutMap = value; }
		}

		[XmlAttribute]
		public float Alpha {
			get { return mAlpha; }
			set { mAlpha = MathHelper.Clamp(value, 0f, 1f); }
		}

		[XmlAttribute]
		public string Name {
			get { return mName; }
			set { mName = value; }
		}

		[XmlAttribute]
		public bool IsBackground {
			get { return mIsBackground; }
			set { mIsBackground = value; }
		}

		[XmlAttribute]
		public bool IsForeground {
			get { return IsBackground == false; }
		}

		[XmlIgnore]
		public int WidthInPixels {
			get { return Width * TileCell.TileWidth; }
		}

		[XmlIgnore]
		public int HeightInPixels {
			get { return Height * TileCell.TileHeight; }
		}

		[XmlIgnore]
		public int Width {
			get { return mLayoutMap.Length; }
		}

		[XmlIgnore]
		public int Height {
			get { return mLayoutMap[0].Length; }
		}

		public TileCell this[int x, int y] {
			get { return GetCell(x, y); }
			set { SetCell(x, y, value); }
		}

		public TileCell this[Point p] {
			get { return GetCell(p); }
			set { SetCell(p, value); }
		}

		public TileCell this[Point2D p] {
			get { return GetCell(p); }
			set { SetCell(p, value); }
		}


		public TileLayer() {
		}

		public TileLayer(int width, int height) {
			mLayoutMap = new TileCell[width][];

			for (int x = 0; x < width; x++) {
				mLayoutMap[x] = new TileCell[height];
				for (int y = 0; y < height; y++) {
					mLayoutMap[x][y] = TileCell.Empty;
					mLayoutMap[x][y].X = x;
					mLayoutMap[x][y].Y = y;
				}
			}
		}

		public TileLayer(TileCell[][] existingMap) {
			mLayoutMap = (TileCell[][])existingMap.Clone();
		}

		public TileLayer(TileLayer existingLayer, int newWidth, int newHeight) {
			mAlpha = existingLayer.Alpha;
			mIsBackground = existingLayer.IsBackground;
			mName = existingLayer.Name;
			mLayoutMap = new TileCell[newWidth][];

			for (int x = 0; x < newWidth; x++) {
				mLayoutMap[x] = new TileCell[newHeight];
				for (int y = 0; y < newHeight; y++) {
					if (existingLayer.LayoutMap == null || x >= existingLayer.LayoutMap.Length || y >= existingLayer.LayoutMap[x].Length) {
						mLayoutMap[x][y] = TileCell.Empty;
						mLayoutMap[x][y].X = x;
						mLayoutMap[x][y].Y = y;
					} else {
						mLayoutMap[x][y] = existingLayer.LayoutMap[x][y].Clone() as TileCell;
					}
				}
			}

		}


		#region GetCell
		public TileCell GetCell(int x, int y) {
			if (IsValidPoint(x, y) == false)
				return TileCell.Empty;
			return (TileCell)mLayoutMap[x][y].Clone();
		}

		public TileCell GetCell(Point point) {
			return GetCell(point.X, point.Y);
		}

		public TileCell GetCell(Point2D point) {
			return GetCell(point.X, point.Y);
		}
		#endregion

		#region SetCell
		public bool SetCell(int x, int y, TileCell cell) {
			if (IsValidPoint(x, y) == false) {
				return false;
			}

			mLayoutMap[x][y] = (TileCell)cell.Clone();
			// Make sure we never loose the spot information!
			mLayoutMap[x][y].X = x;
			mLayoutMap[x][y].Y = y;
			return true;
		}

		public bool SetCell(Point point, TileCell cell) {
			return SetCell(point.X, point.Y, cell);
		}

		public bool SetCell(Point2D point, TileCell cell) {
			return SetCell(point.X, point.Y, cell);
		}
		#endregion

		#region SetAutoCell
		public bool SetAutoCell(int x, int y, TileCell cell) {
			if (IsValidPoint(x, y) == false) {
				return false;
			}

			mLayoutMap[x][y] = (TileCell)cell.Clone();
			mLayoutMap[x][y].TextureSource.IsAutotile = true;
			// Make sure we never loose the spot information!
			mLayoutMap[x][y].X = x;
			mLayoutMap[x][y].Y = y;
			return true;
		}

		public bool SetAutoCell(Point point, TileCell cell) {
			return SetAutoCell(point.X, point.Y, cell);
		}

		public bool SetAutoCell(Point2D point, TileCell cell) {
			return SetAutoCell(point.X, point.Y, cell);
		}
		#endregion

		#region ReplaceCell
		public bool ReplaceCell(Point fromPoint, Point toPoint) {
			if (IsValidPoint(fromPoint) == false || IsValidPoint(toPoint) == false)
				return false;
			return SetCell(toPoint.X, toPoint.Y, GetCell(fromPoint));
		}
		public bool ReplaceCell(int fromX, int fromY, int toX, int toY) {
			return ReplaceCell(new Point(fromX, fromY), new Point(toX, toY));
		}
		#endregion

		public void RemoveTextureIndex(string index) {
			for (int x = 0; x < Width; x++) {
				for (int y = 0; y < Height; y++) {
					var cell = GetCell(x, y);
					if (cell.TextureSource.TextureIndex == index) {
						SetCell(x, y, TileCell.Empty);
					}
				}
			}
		}


		public virtual void LoadContent(ContentManager content) {
			foreach (var cells in mLayoutMap) {
				foreach (var cell in cells) {
					cell.LoadContent(content);
				}
			}
		}


		/// <summary>
		/// Draws all layers using the camera viewport
		/// </summary>
		/// <param name="batch"></param>
		/// <param name="camera"></param>
		/// <param name="alphaMod"></param>
		/// <param name="makePreview"></param>
		public void Draw(SpriteBatch batch, IEngineCamera camera, float alphaMod, bool makePreview) {
			var min = new Point2D(camera.X, camera.Y);
			var max = new Point2D(camera.X + camera.Viewport.Width, camera.Y + camera.Viewport.Height);
			min = TileCell.Pixel2Grid(min);
			max = TileCell.Pixel2Grid(max);
			Draw(batch, camera, min, max, alphaMod, makePreview);
		}

		/// <summary>
		/// Draws all layers using min/max (grid based!)
		/// </summary>
		/// <param name="batch"></param>
		/// <param name="camera"></param>
		/// <param name="min">grid based start position</param>
		/// <param name="max">grid based max position</param>
		/// <param name="alphaMod"></param>
		/// <param name="makePreview"></param>
		public void Draw(SpriteBatch batch, IEngineCamera camera, Point2D min, Point2D max, float alphaMod, bool makePreview) {
			var drawCol = new Color(new Vector4(1f, 1f, 1f, Alpha + alphaMod));
			int preX = 0, preY = 0;

			for (var layerX = min.X; layerX < max.X; layerX++, preX++) {
				for (var layerY = min.Y; layerY < max.Y; layerY++, preY++) {
					var cell = GetCell(layerX, layerY);
					if (cell.IsEqualTo(TileCell.Empty) || cell.TextureSource.TextureIndex == string.Empty)
						continue;

					var drawTo = makePreview ? new Point(preX, preY) : new Point(layerX, layerY);

					if (cell.IsAutoTexture) {
						DrawAutotile(batch, camera, cell, cell.Texture, new Point(layerX, layerY), mMinusOne);
						continue;
					}

					var texture = cell.Texture;
					var sourceRect = new Rectangle(cell.SourceX, cell.SourceY, cell.Width, cell.Height);
					Rectangle destRect;
					if (cell.Rotation.Equals(0f) == false) {
						destRect = new Rectangle(drawTo.X * camera.TileWidth + (int)Math.Ceiling(camera.TileWidth * 0.5f), drawTo.Y * camera.TileHeight + (int)Math.Ceiling(camera.TileHeight * 0.5f), camera.TileWidth, camera.TileHeight);
						batch.Draw(texture, destRect, sourceRect, drawCol, cell.Rotation, new Vector2(cell.Width * 0.5f, cell.Height * 0.5f), cell.FlipEffect, 0f);
					} else {
						destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, camera.TileHeight);
						batch.Draw(texture, destRect, sourceRect, drawCol, 0f, Vector2.Zero, cell.FlipEffect, 0);
					}
				}
				preY = 0;
			}

		}

		public void DrawAutotile(SpriteBatch batch, IEngineCamera camera, TileCell cell, Texture2D texture, Point drawTo, Point preDraw) {
			var color = new Color(new Vector4(1f, 1f, 1f, Alpha));
			var cellType = cell.AutoTextureType;
			var partWidth = camera.TileWidth / 2;
			var partHeight = camera.TileHeight / 2;
			var partWidthConst = TileCell.TileWidth / 2;
			var partheightConst = TileCell.TileHeight / 2;

			if (preDraw != mMinusOne)
				drawTo = preDraw;

			var sourceRect = new Rectangle(cell.X, cell.Y, cell.Width, cell.Height);
			var destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, camera.TileHeight);

			// keine anliegenden
			if (cellType.Has(EAutoTileType.StandAlone | EAutoTileType.BottomLeft | EAutoTileType.BottomRight | EAutoTileType.TopLeft | EAutoTileType.TopRight) && cellType.HasNot(EAutoTileType.Bottom | EAutoTileType.Left | EAutoTileType.Right | EAutoTileType.Top)) {
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#region nur Rechts, Rechts + UntenRechts, Rechts + ObenRechts
			if (cellType.Has(EAutoTileType.Right) && cellType.HasNot(EAutoTileType.Left | EAutoTileType.Top | EAutoTileType.Bottom)) {
				// linkes Eck
				sourceRect = new Rectangle(0, 0, partWidthConst, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// Mitte oben
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// Mitte unten
				sourceRect = new Rectangle(TileCell.TileWidth, texture.Height - partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region nur Links, Links + UntenLinks, Links + ObenLinks
			if (cellType.Has(EAutoTileType.Left) && cellType.HasNot(EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.Right)) {
				// rechtes Eck
				sourceRect = new Rectangle(partWidthConst, 0, partWidthConst, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// Mitte oben
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// Mitte unten
				sourceRect = new Rectangle(TileCell.TileWidth, texture.Height - partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion

			#region Rechts und Links, kein Oben und Unten
			if (cellType.HasAll(EAutoTileType.Right | EAutoTileType.Left) && cellType.HasNot(EAutoTileType.Top | EAutoTileType.Bottom)) {
				// Mitte oben
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// Mitte unten
				sourceRect = new Rectangle(TileCell.TileWidth, texture.Height - partheightConst, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Oben und Unten, kein Links und Rechts
			if (cellType.HasAll(EAutoTileType.Bottom | EAutoTileType.Top) && cellType.HasNot(EAutoTileType.Left | EAutoTileType.Right)) {
				// Mitte links
				sourceRect = new Rectangle(0, texture.Height - TileCell.TileHeight - partheightConst, partWidthConst, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// Mitte rechts
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, texture.Height - TileCell.TileHeight - partheightConst, partWidthConst, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion

			#region nur Oben, Oben + ObenLink, Oben + ObenRechts, Oben + ObenLinks + ObenRechts
			if (cellType.Has(EAutoTileType.Top) && cellType.HasNot(EAutoTileType.Bottom | EAutoTileType.Left | EAutoTileType.Right)) {
				// unteres Eck
				sourceRect = new Rectangle(0, partheightConst, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// Mitte links
				sourceRect = new Rectangle(0, texture.Height - TileCell.TileHeight - partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// Mitte rechts
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, texture.Height - TileCell.TileHeight - partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region nur Unten, Unten + UntenLink, Unten + UntenRechts, Unten + UntenLinks + UntenRechts
			if (cellType.Has(EAutoTileType.Bottom) && cellType.HasNot(EAutoTileType.Top | EAutoTileType.Left | EAutoTileType.Right)) {
				// oberes Eck
				sourceRect = new Rectangle(0, 0, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// Mitte links
				sourceRect = new Rectangle(0, texture.Height - TileCell.TileHeight - partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// Mitte rechts
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, texture.Height - TileCell.TileHeight - partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion

			#region T-Kreuzung nach Unten (Links + Rechts + Unten)
			if (cellType.HasAll(EAutoTileType.Left | EAutoTileType.Right | EAutoTileType.Bottom) && cellType.HasNot(EAutoTileType.Top | EAutoTileType.BottomLeft | EAutoTileType.BottomRight)) {
				// obere Kante
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// unten
				sourceRect = new Rectangle(TileCell.TileWidth * 2, partheightConst, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region T-Kreuzung nach Oben (Links + Rechts + Oben)
			if (cellType.HasAll(EAutoTileType.Left | EAutoTileType.Right | EAutoTileType.Top) && cellType.HasNot(EAutoTileType.Bottom | EAutoTileType.TopLeft | EAutoTileType.TopRight)) {
				// untere Kante
				sourceRect = new Rectangle(TileCell.TileWidth, texture.Height - partheightConst, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// oben
				sourceRect = new Rectangle(TileCell.TileWidth * 2, 0, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region T-Kreuzung nach Links (Oben + Unten + Links)
			if (cellType.HasAll(EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.Left) && cellType.HasNot(EAutoTileType.Right | EAutoTileType.BottomLeft | EAutoTileType.TopLeft)) {
				// rechte Kante
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, texture.Height - TileCell.TileHeight * 2, partWidthConst, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// links
				sourceRect = new Rectangle(TileCell.TileWidth * 2, 0, partWidthConst, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region T-Kreuzung nach Rechts (Oben + Unten + Rechts)
			if (cellType.HasAll(EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.Right) && cellType.HasNot(EAutoTileType.Left | EAutoTileType.TopRight | EAutoTileType.BottomRight)) {
				// linke Kante
				sourceRect = new Rectangle(0, texture.Height - TileCell.TileHeight * 2, partWidthConst, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// rechts
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, 0, partWidthConst, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion

			#region Kreuz (Oben + Unten + Links + Rechts)
			if (cellType.HasAll(EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.Right | EAutoTileType.Left) && cellType.HasNot(EAutoTileType.BottomLeft | EAutoTileType.BottomRight | EAutoTileType.TopLeft | EAutoTileType.TopRight)) {
				// mitte
				sourceRect = new Rectangle(TileCell.TileWidth * 2, 0, TileCell.TileWidth, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion

			#region Kreuz + Oben Links (Oben + Unten + Links + Rechts)
			if (cellType.HasAll(EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.Right | EAutoTileType.Left | EAutoTileType.TopLeft) && cellType.HasNot(EAutoTileType.BottomLeft | EAutoTileType.BottomRight | EAutoTileType.TopRight)) {
				// untere Kante
				sourceRect = new Rectangle(TileCell.TileWidth * 2, partheightConst, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// oben links
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// oben rechts
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, 0, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Kreuz + Oben Rechts (Oben + Unten + Links + Rechts)
			if (cellType.HasAll(EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.Right | EAutoTileType.Left | EAutoTileType.TopRight) && cellType.HasNot(EAutoTileType.BottomLeft | EAutoTileType.BottomRight | EAutoTileType.TopLeft)) {
				// untere Kante
				sourceRect = new Rectangle(TileCell.TileWidth * 2, partheightConst, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// oben links
				sourceRect = new Rectangle(TileCell.TileWidth * 2, 0, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// oben rechts
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Kreuz + Unten Links (Oben + Unten + Links + Rechts)
			if (cellType.HasAll(EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.Right | EAutoTileType.Left | EAutoTileType.BottomRight) && cellType.HasNot(EAutoTileType.TopLeft | EAutoTileType.TopRight | EAutoTileType.BottomLeft)) {
				// obere Kante
				sourceRect = new Rectangle(TileCell.TileWidth * 2, 0, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// unten links
				sourceRect = new Rectangle(TileCell.TileWidth * 2, partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// unten rechts
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Kreuz + Unten Rechts (Oben + Unten + Links + Rechts)
			if (cellType.HasAll(EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.Right | EAutoTileType.Left | EAutoTileType.BottomLeft) && cellType.HasNot(EAutoTileType.TopLeft | EAutoTileType.TopRight | EAutoTileType.BottomRight)) {
				// obere Kante
				sourceRect = new Rectangle(TileCell.TileWidth * 2, 0, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// unten links
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// unten rechts
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion

			#region Ecke unten links (Oben + Rechts)
			if (cellType.HasAll(EAutoTileType.Top | EAutoTileType.Right) && cellType.HasNot(EAutoTileType.Left | EAutoTileType.Bottom | EAutoTileType.TopRight)) {
				// Ecke unten Links 32drawTo.X16
				sourceRect = new Rectangle(0, texture.Height - partheightConst, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// Ecke oben Links 16drawTo.X16
				sourceRect = new Rectangle(0, texture.Height - TileCell.TileHeight, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// Ecke oben Rechts 16drawTo.X16
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, 0, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Ecke unten rechts (Oben + Links)
			if (cellType.HasAll(EAutoTileType.Top | EAutoTileType.Left) && cellType.HasNot(EAutoTileType.Right | EAutoTileType.Bottom | EAutoTileType.TopLeft)) {
				// Ecke unten Rechts 32drawTo.X16
				sourceRect = new Rectangle(TileCell.TileWidth * 2, texture.Height - partheightConst, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// Ecke oben Rechts 16drawTo.X16
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, texture.Height - TileCell.TileHeight, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// Ecke oben Links 16drawTo.X16
				sourceRect = new Rectangle(TileCell.TileWidth * 2, 0, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Ecke oben links (Unten + Rechts)
			if (cellType.HasAll(EAutoTileType.Bottom | EAutoTileType.Right) && cellType.HasNot(EAutoTileType.Top | EAutoTileType.Left | EAutoTileType.BottomRight)) {
				// Ecke oben Links 32drawTo.X16
				sourceRect = new Rectangle(0, TileCell.TileHeight, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// Ecke unten Links 16drawTo.X16
				sourceRect = new Rectangle(0, TileCell.TileHeight + partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// Ecke unten Rechts 16drawTo.X16
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Ecke oben rechts (Unten + Links)
			if (cellType.HasAll(EAutoTileType.Bottom | EAutoTileType.Left) && cellType.HasNot(EAutoTileType.Right | EAutoTileType.Top | EAutoTileType.BottomLeft)) {
				// Ecke oben Rechts 32drawTo.X16
				sourceRect = new Rectangle(TileCell.TileWidth * 2, TileCell.TileHeight, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// Ecke unten Rechts 16drawTo.X16
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, TileCell.TileHeight + partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// Ecke unten Links 16drawTo.X16
				sourceRect = new Rectangle(TileCell.TileWidth * 2, partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion

			#region Ecke links oben + diagonal (Unten + Rechts + UntenRechts)
			if (cellType.HasAll(EAutoTileType.Bottom | EAutoTileType.Right | EAutoTileType.BottomRight) && cellType.HasNot(EAutoTileType.Top | EAutoTileType.Left)) {
				sourceRect = new Rectangle(0, TileCell.TileHeight, TileCell.TileWidth, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Ecke rechts oben + diagonal (Unten + Links + UntenLinks)
			if (cellType.HasAll(EAutoTileType.Bottom | EAutoTileType.Left | EAutoTileType.BottomLeft) && cellType.HasNot(EAutoTileType.Top | EAutoTileType.Right)) {
				sourceRect = new Rectangle(TileCell.TileWidth * 2, TileCell.TileHeight, TileCell.TileWidth, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Ecke links unten + diagonal (Oben + Rechts + ObenRechts)
			if (cellType.HasAll(EAutoTileType.Top | EAutoTileType.Right | EAutoTileType.TopRight) && cellType.HasNot(EAutoTileType.Bottom | EAutoTileType.Left)) {
				sourceRect = new Rectangle(0, texture.Height - TileCell.TileHeight, TileCell.TileWidth, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Ecke rechts unten + diagonal (Oben + Links + ObenLinks)
			if (cellType.HasAll(EAutoTileType.Top | EAutoTileType.Left | EAutoTileType.TopLeft) && cellType.HasNot(EAutoTileType.Bottom | EAutoTileType.Right)) {
				sourceRect = new Rectangle(TileCell.TileWidth * 2, texture.Height - TileCell.TileHeight, TileCell.TileWidth, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion

			#region Seiten links mitte + diagonalen (Oben + Unten + Rechts + ObenRechts + UntenRechts)
			if (cellType.HasAll(EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.Right | EAutoTileType.BottomRight | EAutoTileType.TopRight) && cellType.HasNot(EAutoTileType.Left)) {
				sourceRect = new Rectangle(0, texture.Height - TileCell.TileHeight * 2, TileCell.TileWidth, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Seiten rechts mitte + diagonalen (Oben + Unten + Links + ObenLinks + UntenLinks)
			if (cellType.HasAll(EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.Left | EAutoTileType.BottomLeft | EAutoTileType.TopLeft) && cellType.HasNot(EAutoTileType.Right)) {
				sourceRect = new Rectangle(TileCell.TileWidth * 2, texture.Height - TileCell.TileHeight * 2, TileCell.TileWidth, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Seiten oben mitte + diagonalen (Links + Rechts + Unten + UntenLinks + UntenRechts)
			if (cellType.HasAll(EAutoTileType.Left | EAutoTileType.Right | EAutoTileType.Bottom | EAutoTileType.BottomLeft | EAutoTileType.BottomRight) && cellType.HasNot(EAutoTileType.Top)) {
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight, TileCell.TileWidth, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Seiten unten mitte + diagonalen (Links + Rechts + Oben + ObenLinks + ObenRechts)
			if (cellType.HasAll(EAutoTileType.Left | EAutoTileType.Right | EAutoTileType.Top | EAutoTileType.TopLeft | EAutoTileType.TopRight) && cellType.HasNot(EAutoTileType.Bottom)) {
				sourceRect = new Rectangle(TileCell.TileWidth, texture.Height - TileCell.TileHeight, TileCell.TileWidth, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion

			#region Seite links mitte + diagonalen + linker Ausgang (Oben + Unten + Rechts + Links + ObenRechts + UntenRechts)
			if (cellType.HasAll(EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.Right | EAutoTileType.Left | EAutoTileType.BottomRight | EAutoTileType.TopRight) && cellType.HasNot(EAutoTileType.TopLeft | EAutoTileType.BottomLeft)) {
				// linke Seite
				sourceRect = new Rectangle(TileCell.TileWidth * 2, 0, partWidthConst, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// rechte seite
				sourceRect = new Rectangle(partWidthConst, TileCell.TileHeight * 2, partWidthConst, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Seite rechts mitte + diagonalen + rechter Ausgang (Oben + Unten + Rechts + Links + ObenLinks + UntenLinks)
			if (cellType.HasAll(EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.Right | EAutoTileType.Left | EAutoTileType.BottomLeft | EAutoTileType.TopLeft) && cellType.HasNot(EAutoTileType.TopRight | EAutoTileType.BottomRight)) {
				// linke Seite
				sourceRect = new Rectangle(partWidthConst, TileCell.TileHeight * 2, partWidthConst, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// rechte seite
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, 0, partWidthConst, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Seite oben mitte + diagonalen + oberer Ausgang (Links + Rechts + Unten + Oben + UntenLinks + UntenRechts)
			if (cellType.HasAll(EAutoTileType.Left | EAutoTileType.Right | EAutoTileType.Bottom | EAutoTileType.Top | EAutoTileType.BottomLeft | EAutoTileType.BottomRight) && cellType.HasNot(EAutoTileType.TopLeft | EAutoTileType.TopRight)) {
				// obere Kante
				sourceRect = new Rectangle(TileCell.TileWidth * 2, 0, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// untere Kante
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Seite unten mitte + diagonalen + unterer Ausgang (Links + Rechts + Unten + Oben + ObenLinks + ObenRechts)
			if (cellType.HasAll(EAutoTileType.Left | EAutoTileType.Right | EAutoTileType.Bottom | EAutoTileType.Top | EAutoTileType.TopLeft | EAutoTileType.TopRight) && cellType.HasNot(EAutoTileType.BottomLeft | EAutoTileType.BottomRight)) {
				// obere Kante
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// untere Kante
				sourceRect = new Rectangle(TileCell.TileWidth * 2, partheightConst, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion

			#region Seite links mitte + Land unten rechts
			if (cellType.HasAll(EAutoTileType.Bottom | EAutoTileType.Top | EAutoTileType.Right | EAutoTileType.TopRight) && cellType.HasNot(EAutoTileType.BottomRight | EAutoTileType.Left)) {
				// links seite
				sourceRect = new Rectangle(0, TileCell.TileHeight * 2, partWidthConst, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// rechts oben
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// rechts unten
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Seite links mitte + Land oben rechts
			if (cellType.HasAll(EAutoTileType.Bottom | EAutoTileType.Top | EAutoTileType.Right | EAutoTileType.BottomRight) && cellType.HasNot(EAutoTileType.TopRight | EAutoTileType.Left)) {
				// links seite
				sourceRect = new Rectangle(0, TileCell.TileHeight * 2, partWidthConst, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// rechts oben
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, 0, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// rechts unten
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Seite oben mitte + Land unten rechts
			if (cellType.HasAll(EAutoTileType.Left | EAutoTileType.Right | EAutoTileType.Bottom | EAutoTileType.BottomLeft) && cellType.HasNot(EAutoTileType.Top | EAutoTileType.BottomRight)) {
				// obere Kante
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// unten links
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// unten rechts
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Seite oben mitte + Land unten links
			if (cellType.HasAll(EAutoTileType.Left | EAutoTileType.Right | EAutoTileType.Bottom | EAutoTileType.BottomRight) && cellType.HasNot(EAutoTileType.Top | EAutoTileType.BottomLeft)) {
				// obere Kante
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// unten links
				sourceRect = new Rectangle(TileCell.TileWidth * 2, partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// unten rechts
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Seite unten mitte + Land oben rechts
			if (cellType.HasAll(EAutoTileType.Left | EAutoTileType.Right | EAutoTileType.Top | EAutoTileType.TopLeft) && cellType.HasNot(EAutoTileType.Bottom | EAutoTileType.TopRight)) {
				// untere Kante
				sourceRect = new Rectangle(TileCell.TileWidth, texture.Height - partheightConst, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// oben links
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// oben rechts
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, 0, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Seite unten mitte + Land oben links
			if (cellType.HasAll(EAutoTileType.Left | EAutoTileType.Right | EAutoTileType.Top | EAutoTileType.TopRight) && cellType.HasNot(EAutoTileType.Bottom | EAutoTileType.TopLeft)) {
				// untere Kante
				sourceRect = new Rectangle(TileCell.TileWidth, texture.Height - partheightConst, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// oben links
				sourceRect = new Rectangle(TileCell.TileWidth * 2, 0, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// oben rechts
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Seite rechts mitte + Land unten links
			if (cellType.HasAll(EAutoTileType.Bottom | EAutoTileType.Top | EAutoTileType.Left | EAutoTileType.TopLeft) && cellType.HasNot(EAutoTileType.BottomLeft | EAutoTileType.Right)) {
				// rechts seite
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, TileCell.TileHeight * 2, partWidthConst, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// links oben
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// links unten
				sourceRect = new Rectangle(TileCell.TileWidth * 2, partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Seite rechts mitte + Land oben links
			if (cellType.HasAll(EAutoTileType.Bottom | EAutoTileType.Top | EAutoTileType.Left | EAutoTileType.BottomLeft) && cellType.HasNot(EAutoTileType.TopLeft | EAutoTileType.Right)) {
				// rechts seite
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, TileCell.TileHeight * 2, partWidthConst, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// links oben
				sourceRect = new Rectangle(TileCell.TileWidth * 2, 0, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// links unten
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion

			#region Mitte (Alles)
			if (cellType.HasAll(EAutoTileType.Left | EAutoTileType.Right | EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.BottomLeft | EAutoTileType.BottomRight | EAutoTileType.TopLeft | EAutoTileType.TopRight)) {
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, TileCell.TileWidth, TileCell.TileHeight);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, camera.TileHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Mitte - Unten Links (Alles)
			if (cellType.HasAll(EAutoTileType.Left | EAutoTileType.Right | EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.BottomRight | EAutoTileType.TopLeft | EAutoTileType.TopRight) && cellType.HasNot(EAutoTileType.BottomLeft)) {
				// obere Kante
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// unten rechts
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// unten links
				sourceRect = new Rectangle(TileCell.TileWidth * 2, partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Mitte - Unten Rechts (Alles)
			if (cellType.HasAll(EAutoTileType.Left | EAutoTileType.Right | EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.BottomLeft | EAutoTileType.TopLeft | EAutoTileType.TopRight) && cellType.HasNot(EAutoTileType.BottomRight)) {
				// obere Kante
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// unten links
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// unten rechts
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Mitte - Oben Links (Alles)
			if (cellType.HasAll(EAutoTileType.Left | EAutoTileType.Right | EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.BottomRight | EAutoTileType.BottomLeft | EAutoTileType.TopRight) && cellType.HasNot(EAutoTileType.TopLeft)) {
				// untere Kante
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// oben rechts
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// oben links
				sourceRect = new Rectangle(TileCell.TileWidth * 2, 0, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Mitte - Oben Rechts (Alles)
			if (cellType.HasAll(EAutoTileType.Left | EAutoTileType.Right | EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.BottomRight | EAutoTileType.BottomLeft | EAutoTileType.TopLeft) && cellType.HasNot(EAutoTileType.TopRight)) {
				// untere Kante
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, TileCell.TileWidth, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, camera.TileWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// oben links
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// oben rechts
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, 0, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion

			#region Mitte - Unten Links + Oben Rechts
			if (cellType.HasAll(EAutoTileType.Left | EAutoTileType.Right | EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.BottomRight | EAutoTileType.TopLeft) && cellType.HasNot(EAutoTileType.TopRight | EAutoTileType.BottomLeft)) {
				// oben links
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// unten rechts
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// oben rechts
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, 0, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// unten links
				sourceRect = new Rectangle(TileCell.TileWidth * 2, partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
				return;
			}
			#endregion
			#region Mitte - Unten Rechts + Oben Links
			if (cellType.HasAll(EAutoTileType.Left | EAutoTileType.Right | EAutoTileType.Top | EAutoTileType.Bottom | EAutoTileType.TopRight | EAutoTileType.BottomLeft) && cellType.HasNot(EAutoTileType.BottomRight | EAutoTileType.TopLeft)) {
				// oben Rechts
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// unten links
				sourceRect = new Rectangle(TileCell.TileWidth, TileCell.TileHeight * 2, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// oben links
				sourceRect = new Rectangle(TileCell.TileWidth * 2, 0, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth, drawTo.Y * camera.TileHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);

				// unten rechts
				sourceRect = new Rectangle(TileCell.TileWidth * 2 + partWidthConst, partheightConst, partWidthConst, partheightConst);
				destRect = new Rectangle(drawTo.X * camera.TileWidth + partWidth, drawTo.Y * camera.TileHeight + partHeight, partWidth, partHeight);
				batch.Draw(texture, destRect, sourceRect, color);
			}
			#endregion

		}


		/// <summary>
		/// Returns a collection of neighbour cells. In a simple 2D grid that
		/// should be 8 cells surrounding the current cell. This method must
		/// not return invalid cells, that means it should not include non
		/// existing or invalid cells to begin with.
		/// </summary>
		/// <param name="cell">A grid cell of the strategic map</param>
		/// <returns>Collection of neighbour cells</returns>
		public ICollection<ITileCell> GetNeighbourCells(ITileCell cell) {
			var cells = new List<ITileCell>();

			// Left
			if (IsValidPoint(cell.X - 1, cell.Y)) {
				cells.Add(GetCell(cell.X - 1, cell.Y));
			}
			// Right
			if (IsValidPoint(cell.X + 1, cell.Y)) {
				cells.Add(GetCell(cell.X + 1, cell.Y));
			}
			// Top
			if (IsValidPoint(cell.X, cell.Y + 1)) {
				cells.Add(GetCell(cell.X, cell.Y + 1));
			}
			// Bottom
			if (IsValidPoint(cell.X, cell.Y - 1)) {
				cells.Add(GetCell(cell.X, cell.Y - 1));
			}

			// Top Left
			if (IsValidPoint(cell.X - 1, cell.Y - 1)) {
				cells.Add(GetCell(cell.X - 1, cell.Y - 1));
			}
			// Top right
			if (IsValidPoint(cell.X + 1, cell.Y - 1)) {
				cells.Add(GetCell(cell.X + 1, cell.Y - 1));
			}
			// Bottom Left
			if (IsValidPoint(cell.X - 1, cell.Y + 1)) {
				cells.Add(GetCell(cell.X - 1, cell.Y + 1));
			}
			// Bottom Right
			if (IsValidPoint(cell.X + 1, cell.Y + 1)) {
				cells.Add(GetCell(cell.X + 1, cell.Y + 1));
			}

			return cells;
		}


		private bool IsValidPoint(int x, int y) {
			return (mLayoutMap == null || x < 0 || x >= mLayoutMap.Length || y < 0 || y >= mLayoutMap[0].Length) == false;
		}

		private bool IsValidPoint(Point cell) {
			return IsValidPoint(cell.X, cell.Y);
		}


		public object Clone() {
			var layer = new TileLayer(mLayoutMap) {
				Name = mName,
				Alpha = mAlpha,
				IsBackground = mIsBackground
			};
			return layer;
		}

		public override string ToString() {
			return string.Format("{0} [{1}x{2}]", mName, Width, Height);
		}

	}

}
