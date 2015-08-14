using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class SideBarPanel : Container {

		public SideBarPanel(Manager manager)
			: base(manager) {
			CanFocus = false;
			Passive = true;
			Width = 64;
			Height = 64;
		}

		public override void Init() {
			base.Init();
		}

	}

}
