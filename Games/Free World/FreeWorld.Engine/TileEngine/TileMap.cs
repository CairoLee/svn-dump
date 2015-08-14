using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using FreeWorld.Engine.Geometry.Camera;
using GodLesZ.Library.BlubbZip;
using GodLesZ.Library.Xna.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Engine.TileEngine {

	[Serializable]
	public class TileMap {
		[XmlIgnore]
		public static int VersionMajorMin = 3;
		[XmlIgnore]
		public static int VersionMinorMin = 1;
		[XmlIgnore]
		public static int VersionMajorNow = 3;
		[XmlIgnore]
		public static int VersionMinorNow = 2;

		private List<ITileCell> mWalkpath;

		[XmlAttribute]
		public string Name {
			get;
			set;
		}

		[XmlAttribute]
		public int Width {
			get;
			set;
		}

		[XmlAttribute]
		public int Height {
			get;
			set;
		}

		public TileCollisionLayer CollisionLayer {
			get;
			set;
		}

		public TileAnimationLayer AnimationLayer {
			get;
			set;
		}

		public string FogIndex {
			get;
			set;
		}

		public float FogDense {
			get;
			set;
		}

		public Color FogColor {
			get;
			set;
		}

		[XmlArray(ElementName = "Layers")]
		[XmlArrayItem(ElementName = "Layer")]
		public List<TileLayer> Layers {
			get;
			set;
		}

		[XmlAttribute]
		public int VersionMajor {
			get;
			set;
		}

		[XmlAttribute]
		public int VersionMinor {
			get;
			set;
		}


		[XmlIgnore]
		public int WidthInPixels {
			get { return Width * TileCell.TileWidth; }
		}

		[XmlIgnore]
		public int HeightInPixels {
			get { return Height * TileCell.TileHeight; }
		}



		public TileMap()
			: this("New Map", 0, 0) {
		}

		public TileMap(string name, int width, int height) {
			Width = width;
			Height = height;
			Name = name;
			Layers = new List<TileLayer>();
			CollisionLayer = new TileCollisionLayer(Width, Height);
			AnimationLayer = new TileAnimationLayer(Width, Height);
			FogDense = 0.5f;
			FogIndex = string.Empty;
			FogColor = Color.White;
			VersionMajor = VersionMajorNow;
			VersionMinor = VersionMinorNow;
		}


		public virtual void LoadContent(ContentManager content) {
			foreach (TileLayer layer in Layers) {
				layer.LoadContent(content);
			}
		}

		public void Draw(SpriteBatch batch, IEngineCamera camera, double totalSeconds, ETileDrawType drawType, Point2D min, Point2D max, bool makePreview) {
			bool drawBackground = (drawType & ETileDrawType.BackGround) == ETileDrawType.BackGround;
			bool drawForeground = (drawType & ETileDrawType.ForeGround) == ETileDrawType.ForeGround;

			foreach (TileLayer layer in Layers) {
				if (!(layer.IsBackground && drawBackground) && !(layer.IsForeground && drawForeground)) {
					continue;
				}

				layer.Draw(batch, camera, min, max, 0f, makePreview);
			}

			if ((drawType & ETileDrawType.Animation) == ETileDrawType.Animation)
				AnimationLayer.Draw(batch, camera, totalSeconds, min, max);

			if ((drawType & ETileDrawType.Fog) == ETileDrawType.Fog)
				DrawFog(batch, camera, min, max);

		}


		public void DrawFog(SpriteBatch spriteBatch, IEngineCamera camera, Point2D min, Point2D max) {
			if (FogIndex == string.Empty) {
				return;
			}

			var fogTex = EngineCore.ContentLoader.GetFog(FogIndex);
			var screenSize = new Point(Constants.GraphicsDevice.Viewport.Width / camera.TileWidth, Constants.GraphicsDevice.Viewport.Height / camera.TileHeight);

			for (var x = 0; x < Width; x += screenSize.X) {
				for (var y = 0; y < Width; y += screenSize.Y) {
					spriteBatch.Draw(fogTex, new Rectangle(x * camera.TileWidth, y * camera.TileHeight, screenSize.X * camera.TileWidth, screenSize.Y * camera.TileHeight), FogColor * FogDense);
				}
			}

		}


		public void Resize(int w, int h) {
			Width = w;
			Height = h;

			CollisionLayer = new TileCollisionLayer(CollisionLayer.LayoutMap, Width, Height);
			AnimationLayer = new TileAnimationLayer(AnimationLayer.LayoutMap, Width, Height);
		}

		public void FixxMap() {
			#region Width/Height
			int w = 0, h = 0;
			foreach (TileLayer layer in Layers) {
				w = Math.Max(w, layer.Width);
				h = Math.Max(h, layer.Height);
			}

			Width = w;
			Height = h;
			#endregion
			#region CollisionLayer LayoutMap
			if (CollisionLayer.LayoutMap == null || CollisionLayer.LayoutMap.Length == 0) {
				CollisionLayer = new TileCollisionLayer(Width, Height);
			}
			#endregion
			#region AnimationLayer LayoutMap
			if (AnimationLayer.LayoutMap == null || AnimationLayer.LayoutMap.Length == 0) {
				AnimationLayer = new TileAnimationLayer(Width, Height);
			}
			#endregion
		}


		/// <summary>
		/// Returns a collection of neighbour cells. In a simple 2D grid that
		/// should be 8 cells surrounding the current cell. This method must
		/// not return invalid cells, that means it should not include non
		/// existing or invalid cells to begin with.
		/// </summary>
		/// <param name="layer">The layer</param>
		/// <param name="cell">A grid cell of the strategic map</param>
		/// <returns>Collection of neighbour cells</returns>
		public ICollection<ITileCell> GetNeighbourCells(int layer, ITileCell cell) {
			return Layers[layer].GetNeighbourCells(cell);
		}

		/// <summary>
		/// 		 Returns all walk spots.
		/// 		 The first Spot is the unit spawn, the last is the finish.
		/// </summary>
		/// <returns>The walk spots.</returns>
		/// <exception cref="Exception">No unit start cell found!</exception>
		public List<ITileCell> GetWalkSpots() {
			if (mWalkpath != null) {
				return mWalkpath;
			}

			mWalkpath = new List<ITileCell>();

			ITileCell cellSpawn = null;
			ITileCell cellHome = null;

			for (int x = 0; x < Width; x++) {
				for (int y = 0; y < Height; y++) {
					if (CollisionLayer[x, y].HasFlag(ECollisionType.MobHome)) {
						cellHome = Layers[0].GetCell(x, y);
					} else if (CollisionLayer[x, y].HasFlag(ECollisionType.MobSpawn)) {
						cellSpawn = Layers[0].GetCell(x, y);
					} else if (CollisionLayer[x, y].HasFlag(ECollisionType.WalkSpot)) {
						mWalkpath.Add(Layers[0].GetCell(x, y));
					}
				}
			}

			if (cellSpawn == null) {
				throw new Exception("No unit start cell found!");
			}
			if (cellHome == null) {
				throw new Exception("No unit finish cell found!");
			}

			// Sort points
			mWalkpath.Sort(new TileCellComparer());

			// Append spawn & home
			mWalkpath.Insert(0, cellSpawn);
			mWalkpath.Add(cellHome);

			return mWalkpath;
		}

		public ITileCell GetSpawnSpot() {
			List<ITileCell> spots = GetWalkSpots();
			return spots[0];
		}

		public ITileCell GetHomeSpot() {
			List<ITileCell> spots = GetWalkSpots();
			return spots[spots.Count - 1];
		}


		#region Save/Load
		public void Save(System.IO.Stream stream, string filename) {
			try {
				var xml = new XmlSerializer(typeof(TileMap));
				using (System.IO.Stream xmlStream = new System.IO.MemoryStream()) {
					xml.Serialize(xmlStream, this);
					using (System.IO.MemoryStream ms = FastBlubbZip.CreateBlubbZip("", filename, xmlStream)) {
						ms.WriteTo(stream);
					}
				}

			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine(e);
			}
		}

		public void Save(string filename) {
			if (System.IO.Path.GetExtension(filename) != ".bmap") {
				filename += ".bmap";
			}

			if (System.IO.File.Exists(filename)) {
				try { System.IO.File.Delete(filename); } catch { }
			}

			using (System.IO.FileStream fs = System.IO.File.OpenWrite(filename)) {
				Save(fs, filename);
			}
		}

		public static TileLoadResult Load(System.IO.Stream fromStream, out TileMap map) {
			map = null;
			try {
				var xml = new XmlSerializer(typeof(TileMap));
				var streams = FastBlubbZip.ExtractBlubbZip(fromStream, "");
				if (streams.Count == 0)
					return TileLoadResult.NoEntryInArchiv;


				foreach (string key in streams.Keys.Where(key => streams[key] != null && streams[key].Length != 0 && streams[key].CanSeek && streams[key].CanRead)) {
					streams[key].Seek(0, System.IO.SeekOrigin.Begin);
					map = xml.Deserialize(streams[key]) as TileMap;

					streams[key].Dispose();
				}

				if (map.VersionMajor < VersionMajorMin || map.VersionMinor < VersionMinorMin)
					return TileLoadResult.OldType;

				map.FixxMap();
			} catch (Exception e) {
				map = null;
				System.Diagnostics.Debug.WriteLine(e);
				return TileLoadResult.UnkownError;
			}

			return TileLoadResult.Success;
		}

		public static TileLoadResult Load(string filename, out TileMap map) {
			using (var fileStream = System.IO.File.OpenRead(filename))
				return Load(fileStream, out map);
		}
		#endregion

	}

}
