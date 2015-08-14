using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.MonoGame.Geometry.Camera {

	public class Camera2D : BaseCamera, ICamera2D {
		protected float mZoom = 1f;

		/// <summary>
		/// Gets or sets the zoom.
		/// </summary>
		public float Zoom {
			get { return mZoom; }
			set {
				mZoom = value;
				mZoom = Math.Min(mZoom, 5f);
				mZoom = Math.Max(mZoom, 0.1f);
			}
		}

		public Rectangle ViewportScaled {
			get {
				var baseVp = Viewport;
				return new Rectangle(baseVp.X, baseVp.Y, (int)(baseVp.Width * Zoom), (int)(baseVp.Height * Zoom));
			}
		}

		public Camera2D(GraphicsDevice graphicsDevice)
			: base(graphicsDevice) {
			Zoom = 1;
		}


		public bool IsInViewport(IPoint2D p) {
			return Viewport.Contains(new Point(p.X, p.Y));
		}

		public bool IsInViewport(IRectangle2D rect) {
			throw new NotImplementedException();
		}

	}

}