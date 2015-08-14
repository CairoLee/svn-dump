using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace eAthenaStudio.Plugins.EditSprite.Controls {

	public class PaletteColor : Panel {
		private bool mMouseIn = false;
		private bool mSelected = false;

		public Color Color {
			get { return BackColor; }
			set { BackColor = value; }
		}

		public bool Selected {
			get { return mSelected; }
			set {
				if (mSelected == value)
					return;
				mSelected = value;
				if (mSelected == true) {
				}
				Invalidate();
			}
		}

		public event EventHandler ColorHovered;
		public event EventHandler ColorUnHovered;


		public PaletteColor(Color col)
			: base() {
			BackColor = col;
			BorderStyle = BorderStyle.None;
			Size = new Size(13, 13);
			Padding = Padding.Empty;
			Margin = Padding.Empty;

			MouseEnter += new EventHandler(PaletteColor_MouseEnter);
			MouseLeave += new EventHandler(PaletteColor_MouseLeave);
		}


		private void PaletteColor_MouseEnter(object sender, EventArgs e) {
			mMouseIn = true;
			Invalidate();
			if (ColorHovered != null)
				ColorHovered(this, EventArgs.Empty);
		}

		private void PaletteColor_MouseLeave(object sender, EventArgs e) {
			mMouseIn = false;
			Invalidate();
			if (ColorUnHovered != null)
				ColorUnHovered(this, EventArgs.Empty);
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);
			if (Selected == true) {
				e.Graphics.DrawImage(Properties.Resources.ColorOverlaySelected, new Rectangle(0, 0, Width - 1, Height - 1), new Rectangle(0, 0, Properties.Resources.ColorOverlaySelected.Width, Properties.Resources.ColorOverlaySelected.Height), GraphicsUnit.Pixel);
				e.Graphics.DrawRectangle(Pens.DarkBlue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
			} else if (mMouseIn == true) {
				e.Graphics.DrawImage(Properties.Resources.ColorOverlay, new Rectangle(0, 0, Width - 1, Height - 1), new Rectangle(0, 0, Properties.Resources.ColorOverlay.Width, Properties.Resources.ColorOverlay.Height), GraphicsUnit.Pixel);
				e.Graphics.DrawRectangle(Pens.DarkBlue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
			} else {
				e.Graphics.DrawRectangle(Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
			}

		}

	}

}
