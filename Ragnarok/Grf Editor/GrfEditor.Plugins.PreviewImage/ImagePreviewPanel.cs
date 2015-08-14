using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GodLesZ.Library.Imaging.Targa;

namespace GrfEditor.Library.Controls {

	public partial class ImagePreviewPanel : UserControl, IPreviewPanel, IEditorPlugin {
		private List<string> mValidExtensions = new List<string>(
			new string[] {
				"bmp",
				"jpg",
				"jepg",
				"png",
				"tga"
			}
		);
		private Form mParentForm;
		private string mName;
		private bool mIsTga;

		public Image ImagePreview {
			get { return imagePreview.Image; }
			set { imagePreview.Image = value; }
		}


		public ImagePreviewPanel() {
			InitializeComponent();
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

		public bool IsSupported(string extension) {
			mIsTga = extension.ToLower() == "tga";
			return mValidExtensions.Contains(extension);
		}

		public bool BlockListView() {
			return false;
		}

		public string GetPluginName() {
			return "Image Preview";
		}

		public string GetPluginDescription() {
			return "Displays the image";
		}

		public void SetData(byte[] data, string filename) {
			mName = filename;
			try {
				using (MemoryStream ms = new MemoryStream(data)) {
					if (mIsTga) {
						using (TargaImage tga = new TargaImage(ms)) {
							ImagePreview = tga.Image.Clone() as Image;
						}
					} else {
						ImagePreview = Image.FromStream(ms);
					}
				}
			} catch {
				ImagePreview = GrfEditor.Library.Properties.Resources.image_error;
			}
		}

	}

}
