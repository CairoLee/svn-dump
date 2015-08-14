using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class StackPanel : Container {

		private EOrientation orientation;

		public StackPanel(Manager manager, EOrientation orientation)
			: base(manager) {
			this.orientation = orientation;
			this.Color = Color.Transparent;
		}

		private void CalcLayout() {
			int top = Top;
			int left = Left;

			foreach (Control c in ClientArea.Controls) {
				Margins m = c.Margins;

				if (orientation == EOrientation.Vertical) {
					top += m.Top;
					c.Top = top;
					top += c.Height;
					top += m.Bottom;
					c.Left = left;
				}

				if (orientation == EOrientation.Horizontal) {
					left += m.Left;
					c.Left = left;
					left += c.Width;
					left += m.Right;
					c.Top = top;
				}
			}
		}

		protected override void DrawControl(Renderer renderer, Rectangle rect, GameTime gameTime) {
			base.DrawControl(renderer, rect, gameTime);
		}

		protected override void OnResize(ResizeEventArgs e) {
			CalcLayout();
			base.OnResize(e);
		}

	}

}
