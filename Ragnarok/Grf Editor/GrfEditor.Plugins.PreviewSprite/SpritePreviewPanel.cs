using System;
using System.Drawing;
using System.Windows.Forms;
using GodLesZ.Library.Ragnarok.Sprite;
using GrfEditor.Library;
using GrfEditor.Library.Controls;

namespace GrfEditor.Plugins.PreviewSprite {

	public partial class SpritePreviewPanel : UserControl, IPreviewPanel, IEditorPlugin {
		private Form mParentForm;
		private RoSprite mSprite;

		private int mCurrentIndex = -1;
		private bool mCurrentTypePal = true;
		private float mZoom = 1;
		private string mName;


		public SpritePreviewPanel() {
			InitializeComponent();
		}

		~SpritePreviewPanel() {
			if (mSprite != null) {
				mSprite.Dispose();
			}
		}


		public void LoadPlugin(Form form) {
			mParentForm = form;
			(mParentForm as IPreviewPanelHost).GetPreviewHost().Controls.Add(this);
		}

		public void LoadMenu(ToolStripMenuItem item) {

		}

		public void UnloadPlugin() {
			(mParentForm as IPreviewPanelHost).GetPreviewHost().Controls.Remove(this);
		}

		public bool IsSupported(string extensions) {
			return extensions == "spr";
		}

		public bool BlockListView() {
			return false;
		}

		public string GetPluginName() {
			return "Sprite Preview";
		}

		public string GetPluginDescription() {
			return "Displays sprites per image and allows to save 1 frame per click as transparent png image";
		}

		#region Image Skip Events
		private void btnFirst_Click(object sender, EventArgs e) {
			SetImage(0);
		}

		private void btnPrev_Click(object sender, EventArgs e) {
			SetImage(mCurrentIndex - 1);
		}

		private void btnNext_Click(object sender, EventArgs e) {
			SetImage(mCurrentIndex + 1);
		}

		private void btnLast_Click(object sender, EventArgs e) {
			if (mCurrentTypePal) {
				SetImage(mSprite.ImagesPal.Count - 1);
			} else {
				SetImage(mSprite.ImagesRgba.Count - 1);
			}
		}
		#endregion

		#region Zoom Events
		private void btnZoomIn_Click(object sender, EventArgs e) {
			SetZoom(1f);
		}

		private void btnZoomReset_Click(object sender, EventArgs e) {
			SetZoom(0);
		}

		private void btnZoomOut_Click(object sender, EventArgs e) {
			SetZoom(-1f);
		}
		#endregion


		private void SpritePreviewPanel_Resize(object sender, EventArgs e) {
			// Center modify controls
			int pnlCenter = (pnlModifyInner.Width / 2);
			int conCenter = (Width / 2);

			pnlModifyInner.Location = new Point((conCenter - pnlCenter), pnlModifyInner.Location.Y);
		}


		private void imgSprite_Click(object sender, EventArgs e) {
			if (imgSprite.Image == null) {
				return;
			}

			using (SaveFileDialog dlg = new SaveFileDialog()) {
				dlg.Filter = "PNG Image (*.png)|*.png";
				dlg.FileName = mName;
				if (dlg.ShowDialog(this) != DialogResult.OK) {
					return;
				}

				imgSprite.Image.Save(dlg.FileName);
			}
		}



		public void SetData(byte[] spriteData, string name) {
			if (spriteData == null || spriteData.Length == 0) {
				ResetAllOperations();
				return;
			}

			mName = name;
			mSprite = new RoSprite(spriteData);
			if (mSprite.ImagesPal.Count == 0 && mSprite.ImagesRgba.Count == 0) {
				ResetAllOperations();
				return;
			}

			mCurrentTypePal = (mSprite.ImagesPal.Count > 0);

			// force to update image
			mCurrentIndex = -1;

			SetImage(0);
		}

		private void ResetAllOperations() {
			imgSprite.Image = GrfEditor.Library.Properties.Resources.image_error;

			mCurrentIndex = -1;
			btnFirst.Enabled =
				btnLast.Enabled =
				btnNext.Enabled =
				btnPrev.Enabled =
				btnZoomOut.Enabled =
				btnZoomIn.Enabled =
				btnZoomReset.Enabled = false;
		}


		private void SetZoom(float zoom) {
			if ((zoom < 0 && mZoom == 1) || (zoom > 0 && mZoom >= 20)) {
				return;
			}

			if (zoom == 0) {
				mZoom = 1;
			} else {
				mZoom += zoom;
			}

			UpdateImage();
			return;
		}

		private void SetImage(int index) {
			if (index == mCurrentIndex) {
				return;
			}

			if (index < 0) {
				index = 0;
			} else if (mCurrentTypePal && index >= mSprite.ImagesPal.Count) {
				index = 0;
			} else if (mCurrentTypePal == false && index >= mSprite.ImagesRgba.Count) {
				index = 0;
			}

			if (mCurrentTypePal) {
				mSprite.DrawPalImage(index);
			} else {
				mSprite.DrawRgbaImage(index);
			}
			mCurrentIndex = index;

			UpdateImage();
			return;
		}




		private void UpdateImage() {
			imgSprite.Image = Tools.ScalePercent(mSprite.GetImageTransparent(mCurrentIndex, mCurrentTypePal == false), (int)(mZoom * 100));

			if (mCurrentTypePal) {
				btnFirst.Enabled = btnPrev.Enabled = (mCurrentIndex > 0);
				btnLast.Enabled = btnNext.Enabled = (mCurrentIndex + 1 < mSprite.ImagesPal.Count);
			} else {
				btnFirst.Enabled = btnPrev.Enabled = (mCurrentIndex > 0);
				btnLast.Enabled = btnNext.Enabled = (mCurrentIndex + 1 < mSprite.ImagesRgba.Count);
			}

			btnZoomIn.Enabled = (mZoom < 20);
			btnZoomOut.Enabled = (mZoom > 1);
			btnZoomReset.Enabled = (mZoom != 1);
		}

	}

}


