using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class Panel : Container {

		private Bevel bevel = null;
		private EBevelStyle bevelStyle = EBevelStyle.None;
		private EBevelBorder bevelBorder = EBevelBorder.None;
		private int bevelMargin = 0;
		private Color bevelColor = Color.Transparent;

		public EBevelStyle BevelStyle {
			get { return bevelStyle; }
			set {
				if (bevelStyle != value) {
					bevelStyle = bevel.Style = value;
					AdjustMargins();
					if (!Suspended)
						OnBevelStyleChanged(new EventArgs());
				}
			}
		}

		public EBevelBorder BevelBorder {
			get { return bevelBorder; }
			set {
				if (bevelBorder != value) {
					bevelBorder = bevel.Border = value;
					bevel.Visible = bevelBorder != EBevelBorder.None;
					AdjustMargins();
					if (!Suspended)
						OnBevelBorderChanged(new EventArgs());
				}
			}
		}

		public int BevelMargin {
			get { return bevelMargin; }
			set {
				if (bevelMargin != value) {
					bevelMargin = value;
					AdjustMargins();
					if (!Suspended)
						OnBevelMarginChanged(new EventArgs());
				}
			}
		}

		public virtual Color BevelColor {
			get { return bevelColor; }
			set {
				bevel.Color = bevelColor = value;
			}
		}

		public event EventHandler BevelBorderChanged;
		public event EventHandler BevelStyleChanged;
		public event EventHandler BevelMarginChanged;

		public Panel(Manager manager)
			: base(manager) {
			Passive = false;
			CanFocus = false;
			Width = 64;
			Height = 64;

			bevel = new Bevel(Manager);
		}

		public override void Init() {
			base.Init();

			bevel.Init();
			bevel.Style = bevelStyle;
			bevel.Border = bevelBorder;
			bevel.Left = 0;
			bevel.Top = 0;
			bevel.Width = Width;
			bevel.Height = Height;
			bevel.Color = bevelColor;
			bevel.Visible = (bevelBorder != EBevelBorder.None);
			bevel.Anchor = EAnchors.Left | EAnchors.Top | EAnchors.Right | EAnchors.Bottom;
			Add(bevel, false);
			AdjustMargins();
		}

		protected internal override void InitSkin() {
			base.InitSkin();
			Skin = new SkinControl(Manager.Skin.Controls["Panel"]);
		}

		protected override void AdjustMargins() {
			int l = 0;
			int t = 0;
			int r = 0;
			int b = 0;
			int s = bevelMargin;

			if (bevelBorder != EBevelBorder.None) {
				if (bevelStyle != EBevelStyle.Flat) {
					s += 2;
				} else {
					s += 1;
				}

				if (bevelBorder == EBevelBorder.Left || bevelBorder == EBevelBorder.All) {
					l = s;
				}
				if (bevelBorder == EBevelBorder.Top || bevelBorder == EBevelBorder.All) {
					t = s;
				}
				if (bevelBorder == EBevelBorder.Right || bevelBorder == EBevelBorder.All) {
					r = s;
				}
				if (bevelBorder == EBevelBorder.Bottom || bevelBorder == EBevelBorder.All) {
					b = s;
				}
			}
			ClientMargins = new Margins(Skin.ClientMargins.Left + l, Skin.ClientMargins.Top + t, Skin.ClientMargins.Right + r, Skin.ClientMargins.Bottom + b);

			base.AdjustMargins();
		}

		protected override void DrawControl(Renderer renderer, Rectangle rect, GameTime gameTime) {
			int x = rect.Left;
			int y = rect.Top;
			int w = rect.Width;
			int h = rect.Height;
			int s = bevelMargin;

			if (bevelBorder != EBevelBorder.None) {
				if (bevelStyle != EBevelStyle.Flat) {
					s += 2;
				} else {
					s += 1;
				}

				if (bevelBorder == EBevelBorder.Left || bevelBorder == EBevelBorder.All) {
					x += s;
					w -= s;
				}
				if (bevelBorder == EBevelBorder.Top || bevelBorder == EBevelBorder.All) {
					y += s;
					h -= s;
				}
				if (bevelBorder == EBevelBorder.Right || bevelBorder == EBevelBorder.All) {
					w -= s;
				}
				if (bevelBorder == EBevelBorder.Bottom || bevelBorder == EBevelBorder.All) {
					h -= s;
				}
			}

			base.DrawControl(renderer, new Rectangle(x, y, w, h), gameTime);
		}

		protected virtual void OnBevelBorderChanged(EventArgs e) {
			if (BevelBorderChanged != null)
				BevelBorderChanged.Invoke(this, e);
		}

		protected virtual void OnBevelStyleChanged(EventArgs e) {
			if (BevelStyleChanged != null)
				BevelStyleChanged.Invoke(this, e);
		}

		protected virtual void OnBevelMarginChanged(EventArgs e) {
			if (BevelMarginChanged != null)
				BevelMarginChanged.Invoke(this, e);
		}

	}

}
