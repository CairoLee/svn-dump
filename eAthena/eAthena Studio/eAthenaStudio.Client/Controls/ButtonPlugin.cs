using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace eAthenaStudio.Client.Controls {

	public class ButtonPlugin : PictureBox {
		private Image mImageDefault;
		private Image mImageHover;
		private bool mIsRound = false;

		public Image ImageDefault {
			get { return mImageDefault; }
			set { mImageDefault = Image = value; }
		}

		public Image ImageHover {
			get { return mImageHover; }
			set { mImageHover = value; }
		}

		public bool IsRound {
			get { return mIsRound; }
			set { mIsRound = value; }
		}


		public ButtonPlugin(eAthenaStudio.Library.Plugin.PluginBase p)
			: base() {
			Tag = p;
			SizeMode = PictureBoxSizeMode.StretchImage;
			BackColor = Color.Transparent;
			//BorderStyle = BorderStyle.FixedSingle; // for debug without Images
			ImageDefault = null;
			ImageHover = null;
			IsRound = false;
			Size = new Size(206, 44);
			Cursor = Cursors.Hand; // mark it as a clickable Button

			mImageDefault = p.ButtonImage;
			mImageHover = p.ButtonImageHover;

			// set first image
			if (ImageDefault != null && Image != ImageDefault)
				Image = ImageDefault;
		}


		protected override void OnResize(EventArgs e) {
			if (IsRound)
				Width = Height;
			base.OnResize(e);
		}

		protected override void OnMouseEnter(EventArgs e) {
			if (mImageHover != null)
				Image = mImageHover;
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e) {
			if (Image != mImageDefault)
				Image = mImageDefault;
			base.OnMouseLeave(e);
		}

	}

}
