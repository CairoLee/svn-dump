using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using FreeWorld.Engine.Geometry.Camera;
using GodLesZ.Library.Json.Linq;
using GodLesZ.Library.Xna.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Engine.TileEngine.Animation {

	[Serializable]
	public class TileAnimation : ICloneable {
		public List<TileAnimationFrame> Frames = new List<TileAnimationFrame>();

		private float mFrameLength = 0.050f;
		private int mCurrentFrame = -1;
		private float mFrameTimer;

		[XmlAttribute]
		public float FrameLength {
			get { return mFrameLength; }
			set { mFrameLength = value; }
		}

		[XmlIgnore]
		public int CurrentFrame {
			get { return mCurrentFrame; }
			set { mCurrentFrame = value; }
		}

		public TileAnimationFrame this[int index] {
			get { return Frames[index]; }
		}


		public TileAnimation() {
		}

		public TileAnimation(TileAnimationFrame[] frames) {
			Frames = new List<TileAnimationFrame>();
			Frames.AddRange(frames.Clone() as TileAnimationFrame[]);
		}

		public TileAnimation(List<TileAnimationFrame> frames) {
			Frames = new List<TileAnimationFrame>();
			Frames.AddRange(frames.ToArray());
		}



		public void Save(System.IO.Stream stream, string filename) {
			try {
				var xml = new XmlSerializer(typeof(TileAnimation));
				using (System.IO.Stream xmlStream = new System.IO.MemoryStream()) {
					xml.Serialize(xmlStream, this);
					BlubbZipHelper.CreateBlubbZip(stream, "", filename, xmlStream);
				}

			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine(e);
			}
		}

		public void Save(string filename) {
			if (System.IO.Path.GetExtension(filename) != ".bani")
				filename += ".bani";

			if (System.IO.File.Exists(filename))
				try { System.IO.File.Delete(filename); } catch { }

			using (System.IO.FileStream fs = System.IO.File.OpenWrite(filename))
				Save(fs, filename);
		}

		public static TileLoadResult Load(System.IO.Stream fromStream, out TileAnimation ani) {
			ani = null;
			try {
				var xml = new XmlSerializer(typeof(TileAnimation));
				var streams = BlubbZipHelper.ExtractBlubbZip(fromStream, "");
				if (streams.Count == 0)
					return TileLoadResult.NoEntryInArchiv;


				foreach (var key in streams.Keys.Where(key => streams[key] != null && streams[key].Length != 0 && streams[key].CanSeek && streams[key].CanRead)) {
					streams[key].Seek(0, System.IO.SeekOrigin.Begin);
					ani = xml.Deserialize(streams[key]) as TileAnimation;

					streams[key].Dispose();
				}

			} catch (Exception e) {
				ani = null;
				System.Diagnostics.Debug.WriteLine(e);
				return TileLoadResult.UnkownError;
			}

			return TileLoadResult.Success;
		}

		public static TileLoadResult Load(string filename, out TileAnimation ani) {
			using (var fileStream = System.IO.File.OpenRead(filename))
				return Load(fileStream, out ani);
		}

		public static TileAnimation LoadFromJson(JToken json) {
			return LoadFromJson(json, Point2D.Zero);
		}

		public static TileAnimation LoadFromJson(JToken json, Point2D basePos) {
			var ani = new TileAnimation();

			// RPG Maker XP animations are based on one tileset
			var tilesetSource = new TileCellSource(json["graphic"].ToString(), 0, 0, Constants.AnimationTilesetWidth, Constants.AnimationTilesetHeight);
			var tileset = EngineCore.ContentLoader.GetAnimationTileset(tilesetSource.TextureIndex);
			var tilesPerRow = tileset.Width / tilesetSource.Width;

			var frames = (JArray)json["frames"];
			foreach (var frame in frames) {
				var frameImages = (JArray)frame;
				var tileFrame = new TileAnimationFrame();
				foreach (var frameImage in frameImages) {
					/*
					 * pattern: 1,		// 1-based tile index
					 * x: 0,			// center-based x-offset
					 * y: 16,			// center-based y-offset
					 * zoom: 30,		// 100-based scale
					 * rotation: 0,		// 360-degree
					 * opacity: 100		// 255 = full visible, 0 = full trans
					 */
					// Make index 0-based!
					var patIndex = (int)(frameImage["pattern"]) - 1;
					var patX = (int)(frameImage["x"]);
					var patY = (int)(frameImage["y"]);
					var patZoom = (int)(frameImage["zoom"]);
					var patRotation = (int)(frameImage["rotation"]);
					var patOpacity = (int)(frameImage["opacity"]);

					if (patIndex > 0) {
						tilesetSource.X = (patIndex % tilesPerRow) * tilesetSource.Width;
						tilesetSource.Y = (patIndex / tilesPerRow) * tilesetSource.Width;
					} else {
						tilesetSource.X = 0;
						tilesetSource.Y = 0;
					}
					var scale = patZoom / 100f;
					var pos = new Point2D(patX + basePos.X, patY + basePos.Y);
					var mirror = SpriteEffects.None;
					var col = new Color(Color.White.R, Color.White.G, Color.White.B, patOpacity);
					var isBackground = false; // TODO: How does RPG Maker handle this?
					var rot = (float)patRotation;
					var pattern = new TileAnimationFrameImage(tilesetSource.Clone() as TileCellSource, scale, pos, mirror, col, rot, isBackground);
					tileFrame.Add(pattern);
				}

				ani.Frames.Add(tileFrame);
			}

			return ani;
		}



		public void Update(double totalSeconds) {
			if (Frames.Count == 0) {
				mCurrentFrame = -1;
				return;
			}

			mFrameTimer += (float)totalSeconds;

			if (mFrameTimer >= mFrameLength) {
				mFrameTimer = 0f;

				mCurrentFrame = (mCurrentFrame + 1) % Frames.Count;
			}
		}

		public void Draw(SpriteBatch spriteBatch, IEngineCamera camera, double totalSeconds, Point2D basePos) {
			Update(totalSeconds);
			if (mCurrentFrame == -1) {
				return;
			}

			Frames[mCurrentFrame].Draw(spriteBatch, basePos);
		}


		public object Clone() {
			return new TileAnimation(Frames);
		}


	}

}
