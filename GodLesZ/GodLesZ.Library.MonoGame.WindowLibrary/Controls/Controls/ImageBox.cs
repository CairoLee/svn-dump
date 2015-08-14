using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class ImageBox : Control {

		private Texture2D image = null;
		private ESizeMode sizeMode = ESizeMode.Normal;
		private Rectangle sourceRect = Rectangle.Empty;

		public Texture2D Image {
			get { return image; }
			set {
				image = value;
				sourceRect = new Rectangle(0, 0, image.Width, image.Height);
				Invalidate();
				if (!Suspended)
					OnImageChanged(new EventArgs());
			}
		}

		public Rectangle SourceRect {
			get { return sourceRect; }
			set {
				if (value != null && image != null) {
					int l = value.Left;
					int t = value.Top;
					int w = value.Width;
					int h = value.Height;

					if (l < 0)
						l = 0;
					if (t < 0)
						t = 0;
					if (w > image.Width)
						w = image.Width;
					if (h > image.Height)
						h = image.Height;
					if (l + w > image.Width)
						w = (image.Width - l);
					if (t + h > image.Height)
						h = (image.Height - t);

					sourceRect = new Rectangle(l, t, w, h);
				} else if (image != null) {
					sourceRect = new Rectangle(0, 0, image.Width, image.Height);
				} else {
					sourceRect = Rectangle.Empty;
				}
				Invalidate();
			}
		}

		public ESizeMode SizeMode {
			get { return sizeMode; }
			set {
				if (value == ESizeMode.Auto && image != null) {
					Width = image.Width;
					Height = image.Height;
				}
				sizeMode = value;
				Invalidate();
				if (!Suspended)
					OnSizeModeChanged(new EventArgs());
			}
		}

		public event EventHandler ImageChanged;
		public event EventHandler SizeModeChanged;

		public ImageBox(Manager manager)
			: base(manager) {
		}

		public override void Init() {
			base.Init();
			CanFocus = false;
			Color = Color.White;
		}

		protected override void DrawControl(Renderer renderer, Rectangle rect, GameTime gameTime) {
			if (image != null) {
				if (sizeMode == ESizeMode.Normal) {
					renderer.Draw(image, rect.X, rect.Y, sourceRect, Color);
				} else if (sizeMode == ESizeMode.Auto) {
					renderer.Draw(image, rect.X, rect.Y, sourceRect, Color);
				} else if (sizeMode == ESizeMode.Stretched) {
					renderer.Draw(image, rect, sourceRect, Color);
				} else if (sizeMode == ESizeMode.Centered) {
					int x = (rect.Width / 2) - (image.Width / 2);
					int y = (rect.Height / 2) - (image.Height / 2);

					renderer.Draw(image, x, y, sourceRect, Color);
				}
			}
		}

		protected virtual void OnImageChanged(EventArgs e) {
			if (ImageChanged != null)
				ImageChanged.Invoke(this, e);
		}

		protected virtual void OnSizeModeChanged(EventArgs e) {
			if (SizeModeChanged != null)
				SizeModeChanged.Invoke(this, e);
		}

	}

}
