using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GodLesZ.Library;
using GodLesZ.Library.Ragnarok.Gat;
using GrfEditor.Library;
using GrfEditor.Library.Controls;

namespace GrfEditor.Plugins.PreviewGat {

	public partial class GatPreviewPanel : UserControl, IPreviewPanel, IEditorPlugin {
		private Form mParentForm;
		private RoGatFile mGatFile;
		private Color[] mColors = new Color[7] {
			Color.Gray, // Walk
			Color.Black, // no Walk
			Color.Navy, // NoWalkNoSnipeWater
			Color.Aquamarine, // WalkWater
			Color.Black, // NoWalkWater
			Color.Violet, // Snipe
			Color.Black // NoSnipe
		};
		private Bitmap mImage;

		private BackgroundWorker mWorker;
		private int mZoom = 1;
		private string mName;


		public GatPreviewPanel() {
			InitializeComponent();

			mWorker = new BackgroundWorker();
			mWorker.WorkerReportsProgress = true;
			mWorker.WorkerSupportsCancellation = true;
			mWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(mWorker_RunWorkerCompleted);
			mWorker.ProgressChanged += new ProgressChangedEventHandler(mWorker_ProgressChanged);
			mWorker.DoWork += new DoWorkEventHandler(mWorker_DoWork);
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
			return extensions == "gat";
		}

		public bool BlockListView() {
			return true;
		}

		public string GetPluginName() {
			return "Map Ground Preview";
		}

		public string GetPluginDescription() {
			return "Displays the walkable cells from a map";
		}


		#region BackgroundWorker Events
		private void mWorker_DoWork(object sender, DoWorkEventArgs e) {
			Image img = Tools.ScalePercentPixel(mImage, (mZoom * 100), mWorker_ProgressChanged);

			e.Result = img;
		}

		private void mWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			InvokeHelper.Invoke(progressLoading, delegate() { progressLoading.Value = e.ProgressPercentage; });
		}

		private void mWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			try {
				imagePreview.Image = e.Result as Image;
				imagePreview.Invalidate();

				(Parent.Parent.Parent as IPreviewPanelHost).OnPreviewReady();
			} catch {
				imagePreview.Image = null;
			}

			progressLoading.Visible = false;

			pnlModify.Enabled = true;
			pnlModify.Visible = true;

			btnZoomIn.Enabled = (mZoom < 20);
			btnZoomOut.Enabled = (mZoom > 1);
			btnZoomReset.Enabled = (mZoom != 1);
		}
		#endregion

		#region Zoom Events
		private void btnZoomIn_Click(object sender, EventArgs e) {
			mZoom++;
			UpdateImage();
		}

		private void btnZoomReset_Click(object sender, EventArgs e) {
			mZoom = 1;
			UpdateImage();
		}

		private void btnZoomOut_Click(object sender, EventArgs e) {
			mZoom--;
			UpdateImage();
		}
		#endregion

		private void imagePreview_Click(object sender, EventArgs e) {
			if (imagePreview.Image == null) {
				return;
			}

			using (SaveFileDialog dlg = new SaveFileDialog()) {
				dlg.Filter = "PNG Image (*.png)|*.png";
				dlg.FileName = mName;
				if (dlg.ShowDialog(this) != DialogResult.OK) {
					return;
				}

				imagePreview.Image.Save(dlg.FileName);
			}
		}

		private void GatPreviewPanel_Resize(object sender, EventArgs e) {
			// center modify controls
			int pnlModCenter = (pnlModifyInner.Width / 2);
			int conCenter = (Width / 2);

			pnlModifyInner.Location = new Point((conCenter - pnlModCenter), pnlModifyInner.Location.Y);

			// center progress bar
			progressLoading.Width = (Width - (int)(((float)Width / 100) * 10));
			progressLoading.Location = new Point((conCenter - (progressLoading.Width / 2)), progressLoading.Location.Y);
		}



		public void SetData(byte[] gatData, string name) {
			if (gatData == null || gatData.Length == 0) {
				imagePreview.Image = GrfEditor.Library.Properties.Resources.image_error;
				pnlModify.Enabled = false;

				return;
			}

			mName = name;
			mGatFile = new RoGatFile(gatData);
			mImage = mGatFile.DrawImage(mColors);

			UpdateImage();
		}

		private void UpdateImage() {
			imagePreview.Image = null;
			pnlModify.Enabled = false;

			progressLoading.Visible = true;
			progressLoading.Enabled = true;
			progressLoading.Value = 0;

			if (mWorker.IsBusy == true) {
				mWorker.CancelAsync();
				while (mWorker.IsBusy == true) {
					System.Threading.Thread.Sleep(100);
				}
			}

			mWorker.RunWorkerAsync();
		}

	}




}
