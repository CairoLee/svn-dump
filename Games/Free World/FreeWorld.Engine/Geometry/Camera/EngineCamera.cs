using FreeWorld.Engine.TileEngine;
using GodLesZ.Library.Xna.Geometry;
using GodLesZ.Library.Xna.Geometry.Camera;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Engine.Geometry.Camera {

	public class EngineCamera : BaseCamera, IEngineCamera {
		protected int mTileWidth = 0;
		protected int mTileHeight = 0;
		protected float mZoom = 1f;

		public float Zoom {
			get { return mZoom; }
			set {
				if (mZoom.Equals(value)) {
					return;
				}

				mZoom = value;
				Refresh();
			}
		}
		
		public int TileWidth {
			get { return mTileWidth; }
			internal set { mTileWidth = value; }
		}

		public int TileHeight {
			get { return mTileHeight; }
			internal set { mTileHeight = value; }
		}

		public Rectangle ViewportGrid {
			get { return new Rectangle(X / mTileWidth, Y / mTileHeight, mGraphicsDevice.Viewport.Width / mTileWidth, mGraphicsDevice.Viewport.Height / mTileHeight); }
		}


		public EngineCamera(GraphicsDevice graphicsDevice)
			: base(graphicsDevice) {
			Refresh();
		}

		public override void Refresh() {
			mTileWidth = (int)(TileCell.TileWidth * Zoom);
			mTileHeight = (int)(TileCell.TileHeight * Zoom);
		}


		public bool IsInViewport(IPoint2D p) {
			return IsInViewport(p as IPoint);
		}

		public bool IsInViewport(IRectangle2D rect) {
			return IsInViewport(rect as IRectangle);
		}
		
		public void Apply(Point p, TileMap map) {
			Apply(p.X, p.Y, map);
		}

		public void Apply(IPoint p, TileMap map) {
			Apply(p.X, p.Y, map);
		}

		public void Apply(IPoint2D p, TileMap map) {
			Apply(p.X, p.Y, map);
		}

		public void Apply(int x, int y, TileMap map) {
			X = System.Math.Max(System.Math.Min(X + x, map.WidthInPixels), 0);
			Y = System.Math.Max(System.Math.Min(Y + y, map.HeightInPixels), 0);
		}

	}

}
