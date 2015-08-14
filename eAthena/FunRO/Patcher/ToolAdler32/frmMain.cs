using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using GodLesZ.Library.Compression;
using GodLesZ.Library.Ragnarok.Grf;

namespace ToolAdler32 {

	public partial class frmMain : Form {
		private BackgroundWorker mWorker;

		public frmMain() {
			InitializeComponent();

			mWorker = new BackgroundWorker();
			mWorker.WorkerReportsProgress = true;
			mWorker.DoWork += new DoWorkEventHandler(mWorker_DoWork);
			mWorker.ProgressChanged += new ProgressChangedEventHandler(mWorker_ProgressChanged);
			mWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(mWorker_RunWorkerCompleted);

			Adler32.OnUpdate += new UpdateStatusHandler(AdlerHelper_OnUpdate);
			Adler32.OnFinish += new FinishedHandler(AdlerHelper_OnFinish);
		}


		private void AdlerHelper_OnUpdate(int State) {
			mWorker.ReportProgress(State);
		}

		private void AdlerHelper_OnFinish(uint Checksum) {
		}

		private void mWorker_DoWork(object sender, DoWorkEventArgs e) {
			string filepath = e.Argument.ToString();
			string extension = Path.GetExtension(filepath).ToLower();
			// GRF? only check filetable
			if (extension == ".grf" || extension == ".gpf") {
				RoGrfFile grf = new RoGrfFile();
				grf.ReadGrf(filepath, false); // skip files!
				byte[] buf = grf.FiletableUncompressed;
				Adler32.Build(buf);

				// cleanup asap
				buf = null;
				grf = null;
			} else {
				// other file? check full path
				Adler32.Build(filepath);
			}
		}

		private void mWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			progressBar.Value = e.ProgressPercentage;
		}

		private void mWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			progressBar.Value = 0;
			if (chkHex.Checked == true)
				txtChecksum.Text = "Value: " + string.Format("0x{0:X02}", Adler32.Checksum);
			else
				txtChecksum.Text = "Value: " + Adler32.Checksum;
			btnOpen.Enabled = true;
		}



		private void btnOpen_Click(object sender, EventArgs e) {
			using (OpenFileDialog dlg = new OpenFileDialog()) {
				dlg.Filter = "any File|*.*";
				if (dlg.ShowDialog(this) != DialogResult.OK)
					return;

				txtPath.Text = dlg.FileName;
			}
		}

		private void txtPath_TextChanged(object sender, EventArgs e) {
			progressBar.Value = 0;
			btnOpen.Enabled = false;
			mWorker.RunWorkerAsync(txtPath.Text);
		}

		private void chkHex_CheckedChanged(object sender, EventArgs e) {
			if (chkHex.Checked == true)
				txtChecksum.Text = "Value: " + string.Format("0x{0:X02}", Adler32.Checksum);
			else
				txtChecksum.Text = "Value: " + Adler32.Checksum;
		}


	}



	#region Program.Main
	public static class Program {
		[STAThread]
		public static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmMain());
		}
	}
	#endregion

}
