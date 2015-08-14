using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GodLesZ.FunRO.Patcher.Controls {

	public class ImageButon : PictureBox {
		private Image mOldImage;

		[Browsable(true)]
		[DefaultValue("")]
		public Image BackgroundImageHover {
			get;
			set;
		}
		[Browsable(true)]
		[DefaultValue("")]
		public Image BackgroundImageClicked {
			get;
			set;
		}


		public ImageButon() {
			MouseEnter += new EventHandler(ImageButon_MouseEnter);
			MouseLeave += new EventHandler(ImageButon_MouseLeave);
			MouseDown += new MouseEventHandler(ImageButon_MouseDown);
			MouseUp += new MouseEventHandler(ImageButon_MouseUp);

			Cursor = Cursors.Hand;
		}


		private void ImageButon_MouseEnter(object sender, EventArgs e) {
			if (Enabled == false) {
				return;
			}

			mOldImage = BackgroundImage;
			BackgroundImage = BackgroundImageHover;
		}

		private void ImageButon_MouseLeave(object sender, EventArgs e) {
			if (Enabled == false) {
				return;
			}

			BackgroundImage = mOldImage;
		}

		private void ImageButon_MouseDown(object sender, MouseEventArgs e) {
			if (BackgroundImageClicked == null || e.Button != System.Windows.Forms.MouseButtons.Left) {
				return;
			}

			// Hover image should be the old one, so dont save it
			BackgroundImage = BackgroundImageClicked;
		}

		private void ImageButon_MouseUp(object sender, MouseEventArgs e) {
			if (BackgroundImageClicked == null) {
				return;
			}

			// Restore base image
			BackgroundImage = mOldImage;
		}

	}

}
