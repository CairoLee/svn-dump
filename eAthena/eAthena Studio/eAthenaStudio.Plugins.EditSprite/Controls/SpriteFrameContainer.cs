using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace eAthenaStudio.Plugins.EditSprite.Controls {

	public class SpriteFrameContainer : Panel {

		public ZoomableSpriteFrame SpriteFrameControl {
			get { return (ZoomableSpriteFrame)Controls[0]; }
		}

		public Bitmap SpriteFrame {
			get { return SpriteFrameControl.SpriteFrame; }
			set { SpriteFrameControl.SpriteFrame = value; }
		}

		public float Zoom {
			get { return SpriteFrameControl.Zoom; }
			set { SpriteFrameControl.Zoom = value; }
		}

		public int PaddingLeft {
			get { return SpriteFrameControl.PaddingLeft; }
			set { SpriteFrameControl.PaddingLeft = value; }
		}

		public int PaddingBottom {
			get { return SpriteFrameControl.PaddingBottom; }
			set { SpriteFrameControl.PaddingBottom = value; }
		}

		new public Color BackColor {
			get { return base.BackColor; }
			set {
				base.BackColor = value;
				SpriteFrameControl.BackColor = value;
			}
		}

		public Color HoverColor {
			get { return SpriteFrameControl.HoverColor; }
			set { SpriteFrameControl.HoverColor = value; }
		}

		public Color SelectedColor {
			get { return SpriteFrameControl.SelectedColor; }
			set { SpriteFrameControl.SelectedColor = value; }
		}




		public SpriteFrameContainer()
			: base() {
			AutoScroll = true;
			Controls.Add(new ZoomableSpriteFrame());
			SpriteFrameControl.Resize += new EventHandler(SpriteFrameControl_Resize);

			SpriteFrameControl.Width = Width;
			SpriteFrameControl.Height = Height;
		}


		public void OnMouseScroll(MouseEventArgs e) {
			Zoom += (float)e.Delta / 1000f;
		}

		// dirty hack to recalc size & location >.<
		public void DoResize() {
			SpriteFrameControl_Resize(this, EventArgs.Empty);
		}


		private void SpriteFrameControl_Resize(object sender, EventArgs e) {
			// spriteFrame to large?
			if (SpriteFrameControl.Width >= Width && SpriteFrameControl.Height >= Height)
				return;

			// center it
			SpriteFrameControl.Location = new Point(Width / 2 - SpriteFrameControl.Width / 2, Height / 2 - SpriteFrameControl.Height / 2);
		}

	}

}
