using Microsoft.Xna.Framework;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class CheckBox : ButtonBase {

		private const string skCheckBox = "CheckBox";
		private const string lrCheckBox = "Control";
		private const string lrChecked = "Checked";

		private bool state = false;

		public virtual bool Checked {
			get {
				return state;
			}
			set {
				state = value;
				Invalidate();
				if (!Suspended)
					OnCheckedChanged(new EventArgs());
			}
		}

		public event EventHandler CheckedChanged;

		public CheckBox(Manager manager)
			: base(manager) {
			CheckLayer(Skin, lrChecked);

			Width = 64;
			Height = 16;
		}

		public override void Init() {
			base.Init();
		}

		protected internal override void InitSkin() {
			base.InitSkin();
			Skin = new SkinControl(Manager.Skin.Controls[skCheckBox]);
		}

		protected override void DrawControl(Renderer renderer, Rectangle rect, GameTime gameTime) {
			SkinLayer layer = Skin.Layers[lrChecked];
			SkinText font = Skin.Layers[lrChecked].Text;

			if (!state) {
				layer = Skin.Layers[lrCheckBox];
				font = Skin.Layers[lrCheckBox].Text;
			}

			rect.Width = layer.Width;
			rect.Height = layer.Height;
			Rectangle rc = new Rectangle(rect.Left + rect.Width + 4, rect.Y, Width - (layer.Width + 4), rect.Height);

			renderer.DrawLayer(this, layer, rect);
			renderer.DrawString(this, layer, Text, rc, false, 0, 0);
		}

		protected override void OnClick(EventArgs e) {
			MouseEventArgs ex = (e is MouseEventArgs) ? (MouseEventArgs)e : new MouseEventArgs();

			if (ex.Button == EMouseButton.Left || ex.Button == EMouseButton.None) {
				Checked = !Checked;
			}
			base.OnClick(e);
		}

		protected virtual void OnCheckedChanged(EventArgs e) {
			if (CheckedChanged != null)
				CheckedChanged.Invoke(this, e);
		}


	}

}
