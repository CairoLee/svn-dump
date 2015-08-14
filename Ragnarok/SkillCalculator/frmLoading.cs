using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GodLesZ.Library.Ragnarok.Grf;
using GodLesZ.Ragnarok.SkillCalculator.Library;

namespace GodLesZ.Ragnarok.SkillCalculator {

	public partial class frmLoading : Form {
		private BackgroundWorker mWorker;
		private frmMain mMainForm;
		private Timer mFadeInTimer;
		private Timer mFadeOutTimer;

		public frmLoading(frmMain frm) {
			InitializeComponent();

			mMainForm = frm;
			
			mFadeInTimer = new Timer();
			mFadeInTimer.Interval = 50;
			mFadeInTimer.Tick += delegate(object sender, EventArgs args) {
				if (Opacity < 1) {
					Opacity = Math.Min(1, Opacity + 0.05);
					return;
				}

				if (mWorker.IsBusy == true) {
					return;
				}

				mFadeInTimer.Stop();
				mFadeOutTimer.Start();
			};

			mFadeOutTimer = new Timer();
			mFadeOutTimer.Interval = 50;
			mFadeOutTimer.Tick += delegate(object sender, EventArgs args) {
				if (Opacity > 0) {
					Opacity = Math.Max(0, Opacity - 0.05);
					return;
				}

				mFadeOutTimer.Stop();
				Close();
			};

			Opacity = 0;

			mWorker = new BackgroundWorker();
			mWorker.WorkerSupportsCancellation = true;
			mWorker.WorkerReportsProgress = true;
			mWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(mWorker_RunWorkerCompleted);
			mWorker.ProgressChanged += new ProgressChangedEventHandler(mWorker_ProgressChanged);
			mWorker.DoWork += new DoWorkEventHandler(mWorker_DoWork);
		}


		private void mWorker_DoWork(object sender, DoWorkEventArgs e) {
			string mobdbPath = @"C:\Users\Jonathan\Desktop\eAthena\db\mob_db.txt";
			string skilldbPath = @"C:\Users\Jonathan\Desktop\eAthena\db\skill_db.txt";
			string grfPath = @"C:\Program Files\Gravity\Ragnarok_Europe\data.grf";

			RoGrfFile grf = new RoGrfFile(grfPath);

			// Load Mobs
			mMainForm.MobDB = new MobDBMobList();
			mMainForm.MobDB.ReportUpdate += new ReportUpdateHandler(Database_ReportUpdate);
			if (mMainForm.MobDB.LoadMobList() == false) {
				if (mMainForm.MobDB.ParseDB(mobdbPath, grf) == false) {
					MessageBox.Show("Failed to fetch Moblist from file!\nUnable to start without Moblist..", "Failed to fetch Moblist", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Close();
					return;
				}

				if (mMainForm.MobDB.ExportMobList() == false) {
					MessageBox.Show("Failed to export Moblist from internal array!\nThe Moblist will be recreated on next startup", "Failed to export Moblist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}

			// Load Skills..
			mMainForm.SkillDB = new SkillDBSkillList();
			mMainForm.SkillDB.ReportUpdate += new ReportUpdateHandler(Database_ReportUpdate);
			if (mMainForm.SkillDB.LoadSkillList() == false) {
				if (mMainForm.SkillDB.ParseDB(skilldbPath, grf) == false) {
					MessageBox.Show("Failed to fetch Skilllist from file!\nUnable to start without Skilllist..", "Failed to fetch Skilllist", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Close();
					return;
				}

				if (mMainForm.SkillDB.ExportSkillList() == false) {
					MessageBox.Show("Failed to export Skilllist from internal array!\nThe Skilllist will be recreated on next startup", "Failed to export Skilllist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}

			grf = null;
		}

		private void Database_ReportUpdate(string message) {
			mWorker.ReportProgress(0, message);
		}

		private void mWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			string message = e.UserState.ToString();

			lblStatus.Text = "Loading: " + message;
		}

		private void mWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {

		}


		private void frmLoading_Load(object sender, EventArgs e) {
			mFadeInTimer.Start();

			mWorker.RunWorkerAsync();
		}

	}

}
