using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class RadioButton : CheckBox {

		private const string skRadioButton = "RadioButton";

		private ERadioButtonMode mode = ERadioButtonMode.Auto;

		public ERadioButtonMode Mode {
			get { return mode; }
			set { mode = value; }
		}


		public RadioButton(Manager manager)
			: base(manager) {
		}

		public override void Init() {
			base.Init();
		}

		protected internal override void InitSkin() {
			base.InitSkin();
			Skin = new SkinControl(Manager.Skin.Controls[skRadioButton]);
		}

		protected override void DrawControl(Renderer renderer, Rectangle rect, GameTime gameTime) {
			base.DrawControl(renderer, rect, gameTime);
		}

		protected override void OnClick(EventArgs e) {
			MouseEventArgs ex = (e is MouseEventArgs) ? (MouseEventArgs)e : new MouseEventArgs();

			if (ex.Button == EMouseButton.Left || ex.Button == EMouseButton.None) {
				if (mode == ERadioButtonMode.Auto) {
					if (Parent != null) {
						ControlsList lst = Parent.Controls as ControlsList;
						for (int i = 0; i < lst.Count; i++) {
							if (lst[i] is RadioButton) {
								(lst[i] as RadioButton).Checked = false;
							}
						}
					} else if (Parent == null && Manager != null) {
						ControlsList lst = Manager.Controls as ControlsList;

						for (int i = 0; i < lst.Count; i++) {
							if (lst[i] is RadioButton) {
								(lst[i] as RadioButton).Checked = false;
							}
						}
					}
				}
			}
			base.OnClick(e);
		}

	}

}
