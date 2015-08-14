using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GodLesZ.BlubbRO.Patcher.Download;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Xml.Serialization;
using GodLesZ.Library.AutoUpdater.Library;
using GodLesZ.Library.Ragnarok.Grf;
using GodLesZ.Library;

namespace GodLesZ.BlubbRO.Patcher {

	public partial class frmMain : Form {
		private bool mGodMode;
		private bool mDragging = false;
		private bool mPatchInProgress = true;
		private bool mBuildingChecksums = true;
		private Point mDragStart;
		private string mPatchUrl = "http://blubbro.de/patcher/";
		BackgroundWorker mChecksumWorker;
		private static int mPatchProgress = 0;
		private static List<int> mPatchedFiles = new List<int>();

		private static uint ChecksumData = 0;
		private static uint ChecksumInsane = 0;


		public frmMain(bool isGod) {
			mGodMode = isGod;
			InitializeComponent();
		}


		#region frmMain Events
		private void frmMain_Shown(object sender, EventArgs e) {
			if (RegHelper.Initialize() == false) {
				MessageBox.Show("Failed to access the registry!\nPlease check your user access.", "Patch error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
				return;
			}

			DataHelper.ValidateInstallDir();

			CheckStatus();
			Application.DoEvents();

			UpdateStatus("Check for Patcher updates..");
			UpdateHandler uHandler = new UpdateHandler();
			if (uHandler.CheckVersion(System.Reflection.Assembly.GetExecutingAssembly(), "http://blubbro.de/patcher/") == true && uHandler.StartUpdate() == true) {
				UpdateStatus("Patcher update found. Start download..");
				Close();
				return;
			}

			btnGameStart.Enabled = false;
			PatchlistHelper.OnPatchProgressComplete = ProgressPatches;
			PatchlistHelper.Download(mPatchUrl + "Patches.txt");
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
			RegHelper.Close();
		}
		#endregion

		#region panelHead Drag & Drop
		private void panelHead_MouseDown(object sender, MouseEventArgs e) {
			if (e.Button != MouseButtons.Left)
				return;

			mDragging = true;
			mDragStart = new Point(e.X, e.Y);
		}

		private void panelHead_MouseUp(object sender, MouseEventArgs e) {
			mDragging = false;
		}

		private void panelHead_MouseMove(object sender, MouseEventArgs e) {
			if (mDragging == false)
				return;

			Point locationPoint = this.PointToScreen(new Point(e.X, e.Y));
			this.Location = new Point(locationPoint.X - mDragStart.X, locationPoint.Y - mDragStart.Y);
		}
		#endregion

		#region Patch Handler
		public void ProgressPatches() {
			UpdateProgressbar(0);
			if (PatchlistHelper.Patches.Count == 0 || mPatchedFiles.Count >= PatchlistHelper.Patches.Count) {
				UpdateProgressbar(100);
				FinalizePatching();
				return;
			}

			if (RegHelper.HasPatch(PatchlistHelper.Patches[mPatchProgress].PatchID) == true) {
				mPatchedFiles.Add(PatchlistHelper.Patches[mPatchProgress].PatchID);
				mPatchProgress++;
				ProgressPatches();
				return;
			}

			PatchlistHelper.Patches[mPatchProgress].Download(HandlePatchProgress, HandlePatchFinish);
		}

		private void HandlePatchProgress(ClientPatch Patch, System.Net.DownloadProgressChangedEventArgs e) {
			UpdateProgressbar(e.ProgressPercentage);
			UpdateStatus("Work on: " + Patch.PatchDisplayname + " [ " + Tools.GetFileSize(e.BytesReceived) + " / " + Tools.GetFileSize(e.TotalBytesToReceive) + " ]");
		}

		private void HandlePatchFinish(ClientPatch Patch, bool Cancel) {
			UpdateProgressbar(100);

			if (ApplyPatch(Patch) == true) {
				RegHelper.SavePatch(Patch.PatchID);
				mPatchedFiles.Add(Patch.PatchID);
			}

			mPatchProgress++;
			ProgressPatches();
		}

		private bool ApplyPatch(ClientPatch Patch) {
			string grfPath;
			bool retVal = true;

			switch (Patch.PatchAction) {
				case EPatchAction.PatcherUpdate:
				case EPatchAction.None:
					return true;


				case EPatchAction.PatchReset:
					// reset reg
					RegHelper.PatchReset(Patch.PatchID);
					// fake count, so no patch proceed
					PatchlistHelper.Patches.Clear();
					// info
					MessageBox.Show("Your patches has been reset.\nPlease restart the Patcher to patch again.\n\nThank you.", "Patcher notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
					// close app
					Close();
					// dont try to update on success
					return false;

				case EPatchAction.GrfAdd:
					grfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Patch.Target) + ".grf";
					try {
						GrfHelper.GrfFromCache(Patch.Target, grfPath); // ensure GRF get loaded
						GrfHelper.MergeGrf(Patch.Target, Patch.FilePath);
					} catch (Exception e) {
						retVal = false;
						MessageBox.Show("Failed to apply Patch \"" + Patch.PatchName + "\".\nSkip..");
						System.Diagnostics.Debug.WriteLine(e);
					}
					break;
				case EPatchAction.GrfDelete:
					grfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Patch.Target) + ".grf";
					try {
						GrfHelper.GrfFromCache(Patch.Target, grfPath); // ensure GRF get loaded
						GrfHelper.DeleteFromGrf(Patch.Target, Patch.PatchName);
					} catch (Exception e) {
						retVal = false;
						MessageBox.Show("Failed to apply Patch \"" + Patch.PatchName + "\".\nSkip..");
						System.Diagnostics.Debug.WriteLine(e);
					}
					break;

				case EPatchAction.DataAdd:
					if (DataHelper.AddFiles(Patch.FilePath) == false) {
						retVal = false;
						MessageBox.Show("Failed to apply Patch \"" + Patch.PatchName + "\".\nSkip..");
					}
					break;
				case EPatchAction.DataDelete:
					if (DataHelper.DeleteFile(Patch.PatchName) == false) {
						retVal = false;
						MessageBox.Show("Failed to apply Patch \"" + Patch.PatchName + "\".\nSkip..");
					}
					break;
			}

			return retVal;
		}

		private void FinalizePatching() {

			// cleanUp
			this.UpdateStatus("Cleanup Files...");
			for (int i = 0; i < PatchlistHelper.Patches.Count; i++) {
				PatchlistHelper.Patches[i].Delete();
			}

			// did we patched something?
			if (mPatchedFiles.Count > 0) {
				// cleanup GRF Cache
				UpdateStatus("Saving GRF...");
				int count = GrfHelper.GrfList.Values.Count;
				int i = 0;
				foreach (GrfFile grf in GrfHelper.GrfList.Values) {
					grf.Save(grf.Filename);
					i++;
					UpdateProgressbar((i * 100) / count);
				}

				UpdateStatus("Finished Patching!");
			} else
				UpdateStatus("No new Patch available");

			UpdateProgressbar(100);
			mPatchInProgress = false;
			BuildChecksums();
		}
		#endregion

		#region Button Handler
		private void btnForum_Click(object sender, EventArgs e) {
			System.Diagnostics.Process.Start("http://blubbro.de/");
		}

		private void lblClose_Click(object sender, EventArgs e) {
			if (mPatchInProgress == true) {
				MessageBox.Show("You can't close the Patcher until patching operations have been finished!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (mBuildingChecksums == true) {
				MessageBox.Show("You can't close the Patcher until client operations have been finished!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Close();
		}

		private void btnGameStart_Click(object sender, EventArgs e) {
			if (mPatchInProgress == true || mBuildingChecksums == true) {
				return; // hack? oO
			}

			if (mGodMode == true) {
				if (File.Exists("BlubbRO.GM.exe") == true) {
					System.Diagnostics.Process.Start("BlubbRO.GM.exe");
					Close();
					return;
				}
			}

			if (File.Exists("BlubbRO.exe") == false) {
				MessageBox.Show("Unable to find the BlubbRO.exe Game File!\nReinstall maybe fix this.", "Start Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
				return;
			}

			System.Diagnostics.Process.Start("BlubbRO.exe");
			Close();
		}
		#endregion


		#region Checksum Handler
		private void BuildChecksums() {
			mBuildingChecksums = true;

			UpdateStatus("Validate client files..");

			AdlerHelper.OnUpdate += new UpdateStatusHandler(AdlerHelper_OnUpdate);
			mChecksumWorker = new BackgroundWorker();
			mChecksumWorker.WorkerReportsProgress = true;
			mChecksumWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(mChecksumWorker_RunWorkerCompleted);
			mChecksumWorker.ProgressChanged += new ProgressChangedEventHandler(mChecksumWorker_ProgressChanged);
			mChecksumWorker.DoWork += new DoWorkEventHandler(mChecksumWorker_DoWork);
			mChecksumWorker.RunWorkerAsync();
		}

		private void mChecksumWorker_DoWork(object sender, DoWorkEventArgs e) {
			AdlerHelper.OnUpdate += new UpdateStatusHandler(AdlerHelper_OnUpdate);

			GrfFile grf;
			byte[] buf;

			// reset progress
			mChecksumWorker.ReportProgress(0);

			// check data.grf
			try {
				grf = new GrfFile("data.grf");
				buf = grf.FiletableUncompressed;
				ChecksumData = AdlerHelper.Build(buf);
			} catch (Exception ex) {
				MessageBox.Show(ex.ToString(), "Client check error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				ChecksumData = 0;
			}

			// reset progress
			mChecksumWorker.ReportProgress(0);

			// cleanup
			buf = null;
			grf = null;

			// check insane.grf
			try {
				grf = new GrfFile("rdata.grf");
				buf = grf.FiletableUncompressed;
				ChecksumInsane = AdlerHelper.Build(buf);
			} catch (Exception ex) {
				MessageBox.Show(ex.ToString(), "Client check error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				ChecksumInsane = 0;
			}

			// cleanup
			buf = null;
			grf = null;
		}

		private void AdlerHelper_OnUpdate(int State) {
			mChecksumWorker.ReportProgress(State);
		}

		private void mChecksumWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			UpdateProgressbar(e.ProgressPercentage);
		}

		private void mChecksumWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			// tell user we are ready
			UpdateProgressbar(100);

			// write fetched offsets
			RegHelper.WriteValue("ChkData", (int)ChecksumData);
			RegHelper.WriteValue("ChkInsane", (int)ChecksumInsane);

			// we are done!
			FinishPatcher();
		}
		#endregion


		private void FinishPatcher() {
			mBuildingChecksums = false;

			UpdateStatus("Finished! You may start BlubbRO now.");

			btnGameStart.Enabled = true;
			btnGameStart.BackgroundImage = Properties.Resources.btn_game;
		}


		private void CheckStatus() {
			// Load player count
			System.Net.WebClient client = new System.Net.WebClient();
			string pcount = "";
			try {
				pcount = client.DownloadString("http://blubbro.de/patcher/PlayerCount.php");
				string[] parts = pcount.Split(new char[] { ';' });
				if (parts.Length < 5) {
					throw new Exception();
				}

				CheckServer(stateLogin, (int.Parse(parts[0]) == 1));
				CheckServer(stateChar, (int.Parse(parts[1]) == 1));
				CheckServer(stateMap, (int.Parse(parts[2]) == 1));
				pcount = int.Parse(parts[4]).ToString();
			} catch {
				pcount = "0";
				CheckServer(stateLogin, false);
				CheckServer(stateChar, false);
				CheckServer(stateMap, false);
			}

			// Build image
			DrawPlayer(pcount);
		}

		private void CheckServer(PictureBox UpdateControl, bool State) {
			if (State == true) {
				UpdateControl.Image = Properties.Resources.state_online;
			} else {
				UpdateControl.Image = Properties.Resources.state_offline;
			}
		}

		private void DrawPlayer(string count) {
			char[] chars = count.ToCharArray();
			using (Bitmap bmp = new Bitmap((9 * chars.Length) + 2, 15)) {
				using (Graphics g = Graphics.FromImage(bmp)) {
					for (int i = 0; i < chars.Length; i++) {
						char c = chars[i];
						Point p = new Point(i * 9, 0);
						Image toDraw = null;

						switch (c) {
							case '0':
								toDraw = Properties.Resources.Zahl_0;
								break;
							case '1':
								toDraw = Properties.Resources.Zahl_1;
								break;
							case '2':
								toDraw = Properties.Resources.Zahl_2;
								break;
							case '3':
								toDraw = Properties.Resources.Zahl_3;
								break;
							case '4':
								toDraw = Properties.Resources.Zahl_4;
								break;
							case '5':
								toDraw = Properties.Resources.Zahl_5;
								break;
							case '6':
								toDraw = Properties.Resources.Zahl_6;
								break;
							case '7':
								toDraw = Properties.Resources.Zahl_7;
								break;
							case '8':
								toDraw = Properties.Resources.Zahl_8;
								break;
							case '9':
								toDraw = Properties.Resources.Zahl_9;
								break;
						}

						if (toDraw != null) {
							g.DrawImage(toDraw, new Rectangle(p.X, p.Y, toDraw.Width, toDraw.Height), new Rectangle(0, 0, toDraw.Width, toDraw.Height), GraphicsUnit.Pixel);
						}

					}

				}

				statePlayer.Image = bmp.Clone() as Bitmap;
			}
		}

		private void UpdateProgressbar(int progress) {
			InvokeHelper.Invoke(stateProgress, delegate() {
				int value = Math.Max(0, Math.Min(100, progress));
				value = (int)(((float)584 / 100f) * value);
				if (stateProgress.Width != value) {
					stateProgress.Width = value;
					stateProgress.Invalidate();
				}
			});
		}

		private void UpdateStatus(string p) {
			InvokeHelper.Invoke(lblStatusText, delegate() {
				lblStatusText.Text = p;
				Application.DoEvents();
			});
		}

	}

}
