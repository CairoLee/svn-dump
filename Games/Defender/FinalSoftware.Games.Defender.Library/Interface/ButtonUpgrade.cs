using FinalSoftware.Games.Defender.Library.Towers;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FinalSoftware.Games.Defender.Library.Interface {

	public class ButtonUpgrade : Button {

		public ButtonUpgrade(string label, SpriteFont font, Rectangle area, Texture2D texUp, Texture2D texDown, bool down, string tooltip)
			: base(label, font, area, texUp, texDown, down, tooltip) {

		}


		public override void Press() {
			base.Press();

			DefenderWorld world = DefenderWorld.Instance;
			if (world.Interface.SelectedTower == null || world.Interface.SelectedTower.Level >= Tower.MAX_LVL) {
				return;
			}

			if (world.Status.Money >= world.Interface.SelectedTower.UpgradeCost) {
				world.Status.Money -= world.Interface.SelectedTower.Upgrade();
			}
		}

	}

}
