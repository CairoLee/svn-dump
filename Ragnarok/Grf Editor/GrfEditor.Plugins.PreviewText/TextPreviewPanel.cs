using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GrfEditor.Library.Controls {

	public partial class TextPreviewPanel : UserControl, IPreviewPanel, IEditorPlugin {
		private List<string> mValidExtensions = new List<string>(
			new string[] {
				"txt",
				"lua",
				"xml"
			}
		);
		private Form mParentForm;

		public string TextPreview {
			get { return txtPreview.Text; }
			set { txtPreview.Text = value; }
		}


		public TextPreviewPanel() {
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
			return mValidExtensions.Contains(extension);
		}

		public bool BlockListView() {
			return false;
		}

		public string GetPluginName() {
			return "Text Preview";
		}

		public string GetPluginDescription() {
			return "Displays plain text";
		}

		public void SetData(byte[] data, string filename) {
			try {
				string bufString = Encoding.Default.GetString(data);
				TextPreview = bufString;
			} catch {
				TextPreview = "<Failed to decode string>";
			}
		}

	}

}
