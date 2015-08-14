using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace GodLesZ.BlubbRO.Patcher {

	public class ImageButon : PictureBox {
		[Browsable(true)]
		[DefaultValue("")]
		public Image BackgroundImageHover {
			get { return mBackgroundImageHover; }
			set { mBackgroundImageHover = value; }
		}

		private Image mOldImage;
		private Image mBackgroundImageHover;

		public ImageButon() {
			MouseEnter += new EventHandler(ImageButon_MouseEnter);
			MouseLeave += new EventHandler(ImageButon_MouseLeave);
			Cursor = Cursors.Hand;
		}



		private void ImageButon_MouseLeave(object sender, EventArgs e) {
			if (Enabled == false)
				return;
			BackgroundImage = mOldImage;
		}

		private void ImageButon_MouseEnter(object sender, EventArgs e) {
			if (Enabled == false)
				return;
			mOldImage = BackgroundImage;
			BackgroundImage = BackgroundImageHover;
		}

	}

}
