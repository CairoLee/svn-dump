using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class GroupPanel : Container {

		public GroupPanel(Manager manager)
			: base(manager) {
			CanFocus = false;
			Passive = true;
			Width = 64;
			Height = 64;
		}

		public override void Init() {
			base.Init();
		}

		protected override void DrawControl(Renderer renderer, Rectangle rect, GameTime gameTime) {
			SkinLayer layer = Skin.Layers["Control"];
			SpriteFont font = (layer.Text != null && layer.Text.Font != null) ? layer.Text.Font.Resource : null;
			Color col = (layer.Text != null) ? layer.Text.Colors.Enabled : Color.White;
			Point offset = new Point(layer.Text.OffsetX, layer.Text.OffsetY);

			renderer.DrawLayer(this, layer, rect);

			if (font != null && Text != null && Text != "") {
				renderer.DrawString(this, layer, Text, new Rectangle(rect.Left, rect.Top + layer.ContentMargins.Top, rect.Width, Skin.ClientMargins.Top - layer.ContentMargins.Horizontal), false, offset.X, offset.Y, false);
			}
		}

	}

}
