using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GodLesZ.Library.Ragnarok.Palette;

namespace GrfEditor.Library.Controls {

	public partial class PalPreviewPanel : UserControl, IPreviewPanel, IEditorPlugin {
		private Form mParentForm;
		private RoPalette mPalette;
		private string mName;
		private int mChartSize = 20;

		public Image PalImage {
			get { return imagePalette.Image; }
			set { imagePalette.Image = value; }
		}


		public PalPreviewPanel() {
			InitializeComponent();
		}


		public void LoadPlugin(Form form) {
			mParentForm = form;
			(mParentForm as IPreviewPanelHost).GetPreviewHost().Controls.Add(this);
		}

		public void LoadMenu(ToolStripMenuItem item) {
			// Add option to change chart size
			var container = new ToolStripMenuItem("Chart size");
			item.DropDownItems.Add(container);
			var txtChartSize = new ToolStripTextBox("txtChartSize");
			txtChartSize.Text = "Chart size";
			txtChartSize.TextBox.Text = mChartSize.ToString();
			txtChartSize.TextChanged += new EventHandler(txtChartSize_TextChanged);
			container.DropDownItems.Add(txtChartSize);
		}

		public void UnloadPlugin() {
			(mParentForm as IPreviewPanelHost).GetPreviewHost().Controls.Remove(this);
		}

		public bool IsSupported(string extensions) {
			return extensions == "pal";
		}

		public bool BlockListView() {
			return false;
		}

		public string GetPluginName() {
			return "Palette Preview";
		}

		public string GetPluginDescription() {
			return "Displays the palette as a 256 color chart";
		}

		public void SetData(byte[] data, string filename) {
			PalImage = GrfEditor.Library.Properties.Resources.image_error;

			mName = filename;
			mPalette = new RoPalette(data);
			UpdateChart();
		}


		private void txtChartSize_TextChanged(object sender, EventArgs e) {
			int size = 0;
			if (int.TryParse((sender as ToolStripTextBox).TextBox.Text, out size)) {
				mChartSize = Math.Max(1, Math.Min(50, size));
				UpdateChart();
			}

			// Update valid text
			if (mChartSize.ToString() != (sender as ToolStripTextBox).TextBox.Text) {
				(sender as ToolStripTextBox).TextBox.Text = mChartSize.ToString();
			}
		}


		private void UpdateChart() {
			if (mPalette == null) {
				return;
			}

			using (MemoryStream ms = new MemoryStream()) {
				mPalette.CreateColorChart(mChartSize, ms);

				PalImage = Image.FromStream(ms);
			}
		}

	}

}
