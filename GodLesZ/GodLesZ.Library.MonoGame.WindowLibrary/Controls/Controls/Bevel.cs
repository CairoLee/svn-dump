using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class Bevel : Control {

		private EBevelBorder border = EBevelBorder.All;
		private EBevelStyle style = EBevelStyle.Etched;

		public EBevelBorder Border {
			get { return border; }
			set {
				if (border != value) {
					border = value;
					if (!Suspended)
						OnBorderChanged(new EventArgs());
				}
			}
		}

		public EBevelStyle Style {
			get { return style; }
			set {
				if (style != value) {
					style = value;
					if (!Suspended)
						OnStyleChanged(new EventArgs());
				}
			}
		}

		public event EventHandler BorderChanged;
		public event EventHandler StyleChanged;

		public Bevel(Manager manager)
			: base(manager) {
			CanFocus = false;
			Passive = true;
			Width = 64;
			Height = 64;
		}

		public override void Init() {
			base.Init();
		}

		protected internal override void InitSkin() {
			base.InitSkin();
		}

		protected override void DrawControl(Renderer renderer, Rectangle rect, GameTime gameTime) {
			if (Border != EBevelBorder.None && Style != EBevelStyle.None) {
				if (Border != EBevelBorder.All) {
					DrawPart(renderer, rect, Border, Style, false);
				} else {
					DrawPart(renderer, rect, EBevelBorder.Left, Style, true);
					DrawPart(renderer, rect, EBevelBorder.Top, Style, true);
					DrawPart(renderer, rect, EBevelBorder.Right, Style, true);
					DrawPart(renderer, rect, EBevelBorder.Bottom, Style, true);
				}
			}
		}

		private void DrawPart(Renderer renderer, Rectangle rect, EBevelBorder pos, EBevelStyle style, bool all) {
			SkinLayer layer = Skin.Layers["Control"];
			Color c1 = Utilities.ParseColor(layer.Attributes["LightColor"].Value);
			Color c2 = Utilities.ParseColor(layer.Attributes["DarkColor"].Value);
			Color c3 = Utilities.ParseColor(layer.Attributes["FlatColor"].Value);

			if (Color != UndefinedColor)
				c3 = Color;

			Texture2D img = Skin.Layers["Control"].Image.Resource;

			int x1 = 0;
			int y1 = 0;
			int w1 = 0;
			int h1 = 0;
			int x2 = 0;
			int y2 = 0;
			int w2 = 0;
			int h2 = 0;

			if (style == EBevelStyle.Bumped || style == EBevelStyle.Etched) {
				if (all && (pos == EBevelBorder.Top || pos == EBevelBorder.Bottom)) {
					rect = new Rectangle(rect.Left + 1, rect.Top, rect.Width - 2, rect.Height);
				} else if (all && (pos == EBevelBorder.Left)) {
					rect = new Rectangle(rect.Left, rect.Top, rect.Width, rect.Height - 1);
				}
				switch (pos) {
					case EBevelBorder.Left: {
							x1 = rect.Left;
							y1 = rect.Top;
							w1 = 1;
							h1 = rect.Height;
							x2 = x1 + 1;
							y2 = y1;
							w2 = w1;
							h2 = h1;
							break;
						}
					case EBevelBorder.Top: {
							x1 = rect.Left;
							y1 = rect.Top;
							w1 = rect.Width;
							h1 = 1;
							x2 = x1;
							y2 = y1 + 1;
							w2 = w1;
							h2 = h1;
							break;
						}
					case EBevelBorder.Right: {
							x1 = rect.Left + rect.Width - 2;
							y1 = rect.Top;
							w1 = 1;
							h1 = rect.Height;
							x2 = x1 + 1;
							y2 = y1;
							w2 = w1;
							h2 = h1;
							break;
						}
					case EBevelBorder.Bottom: {
							x1 = rect.Left;
							y1 = rect.Top + rect.Height - 2;
							w1 = rect.Width;
							h1 = 1;
							x2 = x1;
							y2 = y1 + 1;
							w2 = w1;
							h2 = h1;
							break;
						}
				}
			} else {
				switch (pos) {
					case EBevelBorder.Left: {
							x1 = rect.Left;
							y1 = rect.Top;
							w1 = 1;
							h1 = rect.Height;
							break;
						}
					case EBevelBorder.Top: {
							x1 = rect.Left;
							y1 = rect.Top;
							w1 = rect.Width;
							h1 = 1;
							break;
						}
					case EBevelBorder.Right: {
							x1 = rect.Left + rect.Width - 1;
							y1 = rect.Top;
							w1 = 1;
							h1 = rect.Height;
							break;
						}
					case EBevelBorder.Bottom: {
							x1 = rect.Left;
							y1 = rect.Top + rect.Height - 1;
							w1 = rect.Width;
							h1 = 1;
							break;
						}
				}
			}

			switch (Style) {
				case EBevelStyle.Bumped: {
						renderer.Draw(img, new Rectangle(x1, y1, w1, h1), c1);
						renderer.Draw(img, new Rectangle(x2, y2, w2, h2), c2);
						break;
					}
				case EBevelStyle.Etched: {
						renderer.Draw(img, new Rectangle(x1, y1, w1, h1), c2);
						renderer.Draw(img, new Rectangle(x2, y2, w2, h2), c1);
						break;
					}
				case EBevelStyle.Raised: {
						Color c = c1;
						if (pos == EBevelBorder.Left || pos == EBevelBorder.Top)
							c = c1;
						else
							c = c2;

						renderer.Draw(img, new Rectangle(x1, y1, w1, h1), c);
						break;
					}
				case EBevelStyle.Lowered: {
						Color c = c1;
						if (pos == EBevelBorder.Left || pos == EBevelBorder.Top)
							c = c2;
						else
							c = c1;

						renderer.Draw(img, new Rectangle(x1, y1, w1, h1), c);
						break;
					}
				default: {
						renderer.Draw(img, new Rectangle(x1, y1, w1, h1), c3);
						break;
					}
			}
		}

		protected virtual void OnBorderChanged(EventArgs e) {
			if (BorderChanged != null)
				BorderChanged.Invoke(this, e);
		}

		protected virtual void OnStyleChanged(EventArgs e) {
			if (StyleChanged != null)
				StyleChanged.Invoke(this, e);
		}


	}

}
