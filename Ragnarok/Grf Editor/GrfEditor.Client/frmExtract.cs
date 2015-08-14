using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using GodLesZ.Library.Ragnarok.Grf;
using GodLesZ.Library.Win7.Taskbar;

namespace GrfEditor.Client {

	public partial class FrmExtract : Form {
		private BackgroundWorker mWorker;
		private RoGrfFile mGrfFile;
		private string mRootDir;
		private ArrayList mToExtract;

		private TaskbarManager mWin7Taskbar;


		public FrmExtract(RoGrfFile grf, string rootDir, ArrayList toExtract) {
			InitializeComponent();

			mWin7Taskbar = TaskbarManager.Instance;

			mGrfFile = grf;
			mRootDir = rootDir;
			mToExtract = toExtract;

			mWorker = new BackgroundWorker();
			mWorker.WorkerReportsProgress = true;
			mWorker.WorkerSupportsCancellation = true;
			mWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(mWorker_RunWorkerCompleted);
			mWorker.ProgressChanged += new ProgressChangedEventHandler(mWorker_ProgressChanged);
			mWorker.DoWork += new DoWorkEventHandler(mWorker_DoWork);
		}


		private void mWorker_DoWork(object sender, DoWorkEventArgs e) {
			if (mToExtract.Count == 0) {
				mToExtract.AddRange(mGrfFile.Files.Values);
			}

			int maxCount = mToExtract.Count;
			DateTime timeStart = DateTime.Now;
			for (int i = 0; i < maxCount; i++) {
				if (mWorker.CancellationPending) {
					break;
				}

				object oItem = mToExtract[i];
				if (oItem != null) {
					string nameHash = (oItem as RoGrfFileItem).NameHash;
					try {
						mGrfFile.ExtractFile(mRootDir, nameHash, true);
					} catch (Exception ex) {
						MessageBox.Show("Failed to extract: " + (oItem as RoGrfFileItem).Filepath + Environment.NewLine + Environment.NewLine + ex.ToString(), "Extract error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				} else {
					MessageBox.Show("Null-item in collection!?", "Extract error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				int p = (int)(((float)i / maxCount) * 100);
				mWorker.ReportProgress(p, new object[] { i, (oItem as RoGrfFileItem).Filepath });
			}

		}

		private void mWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			object[] o = (object[])e.UserState;
			int currentNum = (int)o[0];
			string filepath = (string)o[1];

			string startPadding = currentNum.ToString(new string('0', mToExtract.Count.ToString().Length));

			int p = Math.Min(100, e.ProgressPercentage);
			progressFiles.Value = p;
			lblInfo.Text = "[" + startPadding + "/" + mToExtract.Count + "] File: " + filepath;
			Text = "Extracting.. " + p + "%";

			if (TaskbarManager.IsPlatformSupported) {
				mWin7Taskbar.SetProgressValue(p, 100);
			}
		}

		private void mWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if (TaskbarManager.IsPlatformSupported) {
				mWin7Taskbar.SetProgressState(TaskbarProgressBarState.NoProgress);
			}

			DialogResult = System.Windows.Forms.DialogResult.OK;
			Close();
		}


		private void frmExtract_Load(object sender, EventArgs e) {
			if (TaskbarManager.IsPlatformSupported) {
				mWin7Taskbar.SetProgressState(TaskbarProgressBarState.Normal);
				mWin7Taskbar.SetProgressValue(0, 100);
			}
			mWorker.RunWorkerAsync();
		}

		private void frmExtract_FormClosing(object sender, FormClosingEventArgs e) {
			if (mWorker.IsBusy == false) {
				if (TaskbarManager.IsPlatformSupported) {
					mWin7Taskbar.SetProgressState(TaskbarProgressBarState.NoProgress);
				}
				DialogResult = System.Windows.Forms.DialogResult.OK;
				return;
			}

			if (MessageBox.Show("Extracting not finished!" + Environment.NewLine + Environment.NewLine + "Sure to cancel it?", "Extracting in progress", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No) {
				e.Cancel = true;
				return;
			}

			// Dialog will be closed on worker close!
			e.Cancel = true;
			if (mWorker.CancellationPending == false) {
				mWorker.CancelAsync();
			}
			/*
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
			if (TaskbarManager.IsPlatformSupported) {
				mWin7Taskbar.SetProgressState(TaskbarProgressBarState.NoProgress);
			}
			*/
		}

	}

}
