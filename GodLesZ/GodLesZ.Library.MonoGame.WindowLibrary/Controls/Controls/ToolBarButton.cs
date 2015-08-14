using Microsoft.Xna.Framework;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class ToolBarButton : Button {

		public ToolBarButton(Manager manager)
			: base(manager) {
			CanFocus = false;
			Text = "";
		}

		public override void Init() {
			base.Init();
		}

		protected internal override void InitSkin() {
			base.InitSkin();
			Skin = new SkinControl(Manager.Skin.Controls["ToolBarButton"]);
		}

		protected override void DrawControl(Renderer renderer, Rectangle rect, GameTime gameTime) {
			base.DrawControl(renderer, rect, gameTime);
		}

	}

}
