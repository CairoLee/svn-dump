using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Updater.Library;
using System.Xml.Serialization;
using System.IO;
using System.Net;

namespace Updater {

	public partial class frmMain : Form {
		private SVersionFile mVersionFile;
		private BackgroundWorker mBackgroundWorker;

		public frmMain() {
			InitializeComponent();

			mBackgroundWorker = new BackgroundWorker();
			mBackgroundWorker.WorkerReportsProgress = true;
			mBackgroundWorker.WorkerSupportsCancellation = true;
			mBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(mBackgroundWorker_RunWorkerCompleted);
			mBackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(mBackgroundWorker_ProgressChanged);
			mBackgroundWorker.DoWork += new DoWorkEventHandler(mBackgroundWorker_DoWork);
		}

		private void frmMain_Load(object sender, EventArgs e) {
			if (File.Exists(UpdateHandler.VersionFileName) == false) {
				MessageBox.Show("Cant find VersionFile!\nCancel Updating...");
				this.Close();
				return;
			}
			XmlSerializer xml = new XmlSerializer(typeof(SVersionFile));
			using (FileStream fs = File.OpenRead(UpdateHandler.VersionFileName))
				mVersionFile = xml.Deserialize(fs) as SVersionFile;

			this.Text += mVersionFile.ApplicationName;
			StatusRtb.Text += "Initialize Update...\n";
			mBackgroundWorker.RunWorkerAsync();
		}


		private void mBackgroundWorker_DoWork(object workerSender, DoWorkEventArgs workerE) {
			HttpWebRequest webRequest;
			HttpWebResponse webResponse;
			try {
				for (int i = 0; i < mVersionFile.Files.Count; i++) {
					webRequest = (HttpWebRequest)WebRequest.Create(mVersionFile.Files[i].Url);
					webRequest.Credentials = CredentialCache.DefaultCredentials;
					webResponse = (HttpWebResponse)webRequest.GetResponse();

					Int64 fileSize = webResponse.ContentLength;
					using (Stream strResponse = webResponse.GetResponseStream()) {
						string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, mVersionFile.Files[i].Name);
						string tempPath = Path.GetTempFileName();
						using (FileStream strLocal = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None)) {
							int bytesSize = 0;
							byte[] downBuffer = new byte[2048];
							long[] progress;
							while ((bytesSize = strResponse.Read(downBuffer, 0, downBuffer.Length)) > 0) {
								strLocal.Write(downBuffer, 0, bytesSize);

								progress = new long[]{
									strLocal.Length, 
									fileSize,
									i,
								};
								mBackgroundWorker.ReportProgress(0, progress);
							}
						}

						try {
							File.Delete(filePath);
							File.Move(tempPath, filePath);
						} catch { }

					}
				}
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine(ex);
			}

		}

		private int mOldFileLog = -1;
		private void mBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			long[] progress = e.UserState as long[];
			int fileNum = (int)progress[2];
			if (fileNum != mOldFileLog) {
				mOldFileLog = fileNum;
				StatusRtb.Text += "Download File: " + Path.GetFileName(mVersionFile.Files[fileNum].Name) + "\n";
			}

			StatusProgress.Value = Convert.ToInt32((progress[0] * 100) / progress[1]);
			StatusLabel.Text = string.Format("lade Datei {0}/{1} - {2:00.00}%", fileNum + 1, mVersionFile.Files.Count, (float)(progress[0] * 100) / (float)progress[1]);
		}
		private void mBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			StatusRtb.Text += "Update complete!\n";
			// finished, start App and close
			System.Diagnostics.Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, mVersionFile.ApplicationName + ".exe"));
			UpdateHandler.CleanUp();
			this.Close();
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
			if (mBackgroundWorker.IsBusy == false)
				return;

			if (MessageBox.Show("Ein Update ist noch nicht beendet!\nSicher das du beenden un das Update abbrechen möchtest?", "Update nicht abgeschlossen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
				e.Cancel = true;
				mBackgroundWorker.CancelAsync();
			}
		}

	}

	#region Program.Main
	static class Program {
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmMain());
		}
	}
	#endregion

}
