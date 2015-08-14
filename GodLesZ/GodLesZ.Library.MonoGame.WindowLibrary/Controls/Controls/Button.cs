
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class Button : ButtonBase {

		private const string skButton = "Button";
		private const string lrButton = "Control";

		private Glyph glyph = null;
		private EModalResult modalResult = EModalResult.None;
		private EButtonMode mode = EButtonMode.Normal;
		private bool pushed = false;

		public Glyph Glyph {
			get { return glyph; }
			set {
				glyph = value;
				if (!Suspended)
					OnGlyphChanged(new EventArgs());
			}
		}

		public EModalResult ModalResult {
			get { return modalResult; }
			set { modalResult = value; }
		}

		public EButtonMode Mode {
			get { return mode; }
			set { mode = value; }
		}

		public bool Pushed {
			get { return pushed; }
			set {
				pushed = value;
				Invalidate();
			}
		}

		public event EventHandler GlyphChanged;

		public Button(Manager manager)
			: base(manager) {
			SetDefaultSize(72, 24);
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
			}
			base.Dispose(disposing);
		}

		public override void Init() {
			base.Init();
		}

		protected internal override void InitSkin() {
			base.InitSkin();
			Skin = new SkinControl(Manager.Skin.Controls[skButton]);
		}

		protected override void DrawControl(Renderer renderer, Rectangle rect, GameTime gameTime) {

			if (mode == EButtonMode.PushButton && pushed) {
				SkinLayer l = Skin.Layers[lrButton];
				renderer.DrawLayer(l, rect, l.States.Pressed.Color, l.States.Pressed.Index);
				if (l.States.Pressed.Overlay) {
					renderer.DrawLayer(l, rect, l.Overlays.Pressed.Color, l.Overlays.Pressed.Index);
				}
			} else {
				base.DrawControl(renderer, rect, gameTime);
			}

			SkinLayer layer = Skin.Layers[lrButton];
			SpriteFont font = (layer.Text != null && layer.Text.Font != null) ? layer.Text.Font.Resource : null;
			Color col = Color.White;
			int ox = 0;
			int oy = 0;

			if (ControlState == EControlState.Pressed) {
				if (layer.Text != null)
					col = layer.Text.Colors.Pressed;
				ox = 1;
				oy = 1;
			}
			if (glyph != null) {
				Margins cont = layer.ContentMargins;
				Rectangle r = new Rectangle(rect.Left + cont.Left,
											rect.Top + cont.Top,
											rect.Width - cont.Horizontal,
											rect.Height - cont.Vertical);
				renderer.DrawGlyph(glyph, r);
			} else {
				renderer.DrawString(this, layer, Text, rect, true, ox, oy);
			}
		}

		private void OnGlyphChanged(EventArgs e) {
			if (GlyphChanged != null)
				GlyphChanged.Invoke(this, e);
		}

		protected override void OnClick(EventArgs e) {
			MouseEventArgs ex = (e is MouseEventArgs) ? (MouseEventArgs)e : new MouseEventArgs();

			if (ex.Button == EMouseButton.Left || ex.Button == EMouseButton.None) {
				pushed = !pushed;
			}

			base.OnClick(e);

			if ((ex.Button == EMouseButton.Left || ex.Button == EMouseButton.None) && Root != null) {
				if (Root is Window) {
					Window wnd = (Window)Root;
					if (ModalResult != EModalResult.None) {
						wnd.Close(ModalResult);
					}
				}
			}
		}

	}

}
