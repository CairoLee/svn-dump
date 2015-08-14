using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GodLesZ.Library.Ragnarok.Sprite;

namespace eAthenaStudio.Plugins.EditSprite {

	public partial class frmSpriteFrameAdd : Form {
		private RoSprite mSprite;

		public Image NewImage {
			get { return imgNewPreview.Image; }
		}

		public int NewImagePosition {
			get {
				if (cmbAddType.SelectedIndex == 0)
					return cmbAddPosition.SelectedIndex + 1;
				return cmbAddPosition.SelectedIndex - 1;
			}
		}


		public frmSpriteFrameAdd(RoSprite Sprite) {
			mSprite = Sprite;

			InitializeComponent();

			for (int i = 0; i < mSprite.Images.Count; i++)
				cmbAddPosition.Items.Add((i + 1));

			cmbAddType.SelectedIndex = 0;
			cmbAddPosition.SelectedIndex = cmbAddPosition.Items.Count - 1;
		}


		private void btnOpen_Click(object sender, EventArgs e) {
			using (OpenFileDialog dlg = new OpenFileDialog()) {
				dlg.Filter = "Bild Datei (PNG, BMP, JPG)|*.png;*.bmp;*.jpg;*.jepg";
				if (dlg.ShowDialog(this) != DialogResult.OK)
					return;

				imgNewPreview.Image = Bitmap.FromFile(dlg.FileName);
				btnOK.Enabled = true;
			}
		}

		private void cmbAddPosition_SelectedIndexChanged(object sender, EventArgs e) {
			imgFramePreview.Image = mSprite.Images[cmbAddPosition.SelectedIndex].Image;
		}

		private void btnOK_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.Cancel;
			Close();
		}


	}

}
