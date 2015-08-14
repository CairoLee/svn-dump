using System;
using System.Collections.Generic;
using System.Linq;
using GodLesZ.Library.Xna.Geometry;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Engine.TileEngine.Animation {

	public delegate void OnDrawTileAnimationFrameImageDelegate(TileAnimationFrame frame, TileAnimationFrameImage image);

	[Serializable]
	public class TileAnimationFrame : List<TileAnimationFrameImage>, ICloneable {
		private int mWidth = -1;
		private int mHeight = -1;

		public int Width {
			get {
				if (mWidth == -1) {
					ForEach(img => mWidth += img.Width);
				}
				return mWidth;
			}
		}

		public int Height {
			get {
				if (mHeight == -1) {
					ForEach(img => mHeight += img.Height);
				}
				return mHeight;
			}
		}


		public TileAnimationFrame() {
		}

		public TileAnimationFrame(IEnumerable<TileAnimationFrameImage> images)
			: base(images.Select(image => image.Clone() as TileAnimationFrameImage)) {
		}

		public TileAnimationFrame(TileAnimationFrameImage image) {
			Add(image.Clone() as TileAnimationFrameImage);
		}


		public virtual void LoadContent(ContentManager content) {
			foreach (var img in this) {
				img.LoadContent(content);
			}
		}


		public void Draw(SpriteBatch spriteBatch) {
			Draw(spriteBatch, Point2D.Zero);
		}

		public void Draw(SpriteBatch spriteBatch, Point2D basePos) {
			ForEach(img => img.Draw(spriteBatch, basePos));
		}


		public void DrawBackground(SpriteBatch spriteBatch, Point2D basePos, OnDrawTileAnimationFrameImageDelegate onDraw = null) {
			Draw(spriteBatch, basePos, true, onDraw);
		}

		public void DrawBackground(SpriteBatch spriteBatch, OnDrawTileAnimationFrameImageDelegate onDraw = null) {
			Draw(spriteBatch, Point2D.Zero, true, onDraw);
		}

		public void DrawForeground(SpriteBatch spriteBatch, Point2D basePos, OnDrawTileAnimationFrameImageDelegate onDraw = null) {
			Draw(spriteBatch, basePos, false, onDraw);
		}

		public void DrawForeground(SpriteBatch spriteBatch, OnDrawTileAnimationFrameImageDelegate onDraw = null) {
			Draw(spriteBatch, Point2D.Zero, false, onDraw);
		}

		public void Draw(SpriteBatch spriteBatch, Point2D basePos, bool drawBackground, OnDrawTileAnimationFrameImageDelegate onDraw = null) {
			// Default to faster alternative
			if (onDraw == null) {
				Draw(spriteBatch, basePos);
				return;
			}

			foreach (var img in this.Where(img => img.IsBackground == drawBackground)) {
				img.Draw(spriteBatch, basePos);

				onDraw.Invoke(this, img);
			}
		}


		public object Clone() {
			return new TileAnimationFrame(this);
		}

	}

}
