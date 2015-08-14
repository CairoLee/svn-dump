using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GodLesZ.FunRO.Patcher.Patches;
using GodLesZ.Library;
using GodLesZ.Library.AutoUpdater.Library;
using GodLesZ.Library.Ragnarok.Grf;
using GodLesZ.Library.Win7.Taskbar;

namespace GodLesZ.FunRO.Patcher {

	public partial class frmMain : Form {
		public const string URL_PATCHER_UPDATE = "http://funro.nu/patcher/";
		public const string URL_PATCHER_PATCHES = "http://funro.nu/patcher/";
		public const string URL_FORUM = "http://funro.nu/forum/";
		public const string URL_VOTE = "http://funro.nu/vote/";

		private static ClientPatchList mPatches;
		private static int mPatchProgress = 0;
		private static List<int> mPatchedFiles = new List<int>();

		private RegHelper mRegistry;
		private bool mGodMode;
		private bool mDragging = false;
		private bool mPatchInProgress = true;
		private Point mDragStart;

		private TaskbarManager mWin7Taskbar;


		public frmMain(bool isGod) {
			mGodMode = isGod;
			mWin7Taskbar = TaskbarManager.Instance;
			LayoutManager.Layout = Properties.Settings.Default.Layout;

			InitializeComponent();
		}


		#region frmMain Events
		private void frmMain_Shown(object sender, EventArgs e) {
			// Position
			// TODO: Subtract Vista/Win7 Taskbar height..
			//Location = new Point(Location.X, Location.Y + (ClientSize.Height / 2));

			mRegistry = new RegHelper();
			if (mRegistry.Initialize() == false) {
				MessageBox.Show("Failed to access the registry!\nPlease check your user access.", "Patch error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
				return;
			}

			if (mRegistry.FirstRun) {
				// First start, reset patches
				mRegistry.PatchReset(0);
			}

			UpdateStatus("Loading server status..");
			Application.DoEvents();
			CheckStatus();
			Application.DoEvents();

			if (mRegistry.SearchPatcherUpdates()) {
				mRegistry.SetLastPatcherUpdate();

				UpdateStatus("Searching for patcher updates..");
				UpdateHandler uHandler = new UpdateHandler();
				var asm = System.Reflection.Assembly.GetExecutingAssembly();
				if (uHandler.CheckVersion(asm, URL_PATCHER_UPDATE) == true && uHandler.StartUpdate() == true) {
					UpdateStatus("Patcher update found. Start download..");
					Close();
					return;
				}
			}
			btnGameStart.Enabled = false;
			mPatches = new ClientPatchList();
			mPatches.OnPatchProgressComplete += ProgressPatches;
			mPatches.Download(URL_PATCHER_PATCHES + "Patches.xml");
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
			mRegistry.Close();
		}
		#endregion

		#region panelHead Drag & Drop
		private void panelHead_MouseDown(object sender, MouseEventArgs e) {
			if (e.Button != MouseButtons.Left) {
				return;
			}

			mDragging = true;
			mDragStart = new Point(e.X, e.Y);
		}

		private void panelHead_MouseUp(object sender, MouseEventArgs e) {
			mDragging = false;
		}

		private void panelHead_MouseMove(object sender, MouseEventArgs e) {
			if (mDragging == false) {
				return;
			}

			Point locationPoint = this.PointToScreen(new Point(e.X, e.Y));
			this.Location = new Point(locationPoint.X - mDragStart.X, locationPoint.Y - mDragStart.Y);
		}
		#endregion

		#region Patch Handler
		public void ProgressPatches() {
			if (TaskbarManager.IsPlatformSupported) {
				mWin7Taskbar.SetProgressState(TaskbarProgressBarState.Normal);
			}
			UpdateProgressbar(0);

			if (mPatches.Count == 0 || mPatchedFiles.Count >= mPatches.Count) {
				UpdateProgressbar(100);
				if (TaskbarManager.IsPlatformSupported) {
					mWin7Taskbar.SetProgressState(TaskbarProgressBarState.NoProgress);
				}
				FinalizePatching();
				return;
			}

			if (mRegistry.HasPatch(mPatches[mPatchProgress].ID) == true) {
				mPatchedFiles.Add(mPatches[mPatchProgress].ID);
				mPatchProgress++;
				ProgressPatches();
				return;
			}

			mPatches[mPatchProgress].Download(HandlePatchProgress, HandlePatchFinish);
		}

		private void HandlePatchProgress(ClientPatch Patch, System.Net.DownloadProgressChangedEventArgs e) {
			UpdateProgressbar(e.ProgressPercentage);
			UpdateStatus("Work on: " + Patch.Displayname + " [ " + e.BytesReceived.GetFileSize() + " / " + e.TotalBytesToReceive.GetFileSize() + " ]");
		}

		private void HandlePatchFinish(ClientPatch Patch, bool Cancel) {
			UpdateProgressbar(100);
			if (TaskbarManager.IsPlatformSupported) {
				mWin7Taskbar.SetProgressState(TaskbarProgressBarState.NoProgress);
			}

			if (ApplyPatch(Patch) == true) {
				mRegistry.SavePatch(Patch.ID);
				mPatchedFiles.Add(Patch.ID);
			}

			mPatchProgress++;
			ProgressPatches();
		}

		private bool ApplyPatch(ClientPatch patch) {
			string grfPath;
			bool retVal = true;

			switch (patch.Action) {
				case EPatchAction.PatcherUpdate:
				case EPatchAction.None:
					return true;


				case EPatchAction.PatchReset:
					// Reset registry
					mRegistry.PatchReset(patch.ID);
					// Fake patch count, so no patch will be downloaded after this
					mPatches.Clear();
					// Output info
					MessageBox.Show("Your patches has been reset.\nPlease restart the Patcher to patch again.\n\nThank you.", "Patcher notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
					// Close the patcher asap
					Close();
					return false;

				case EPatchAction.GrfAdd:
					grfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, patch.Target);
					if (grfPath.EndsWith(".grf") == false) {
						grfPath += ".grf";
					}

					try {
						GrfHelper.GrfFromCache(patch.Target, grfPath); // Ensure the GRF got loaded
						GrfHelper.MergeGrf(patch.Target, patch.FilePath);
					} catch (Exception e) {
						retVal = false;
						MessageBox.Show("Failed to apply Patch \"" + patch.Name + "\".\nSkip..");
						System.Diagnostics.Debug.WriteLine(e);
					}
					break;
				case EPatchAction.GrfDelete:
					grfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, patch.Target) + ".grf";
					try {
						GrfHelper.GrfFromCache(patch.Target, grfPath); // Ensure the GRF got loaded
						GrfHelper.DeleteFromGrf(patch.Target, patch.Name);
					} catch (Exception e) {
						retVal = false;
						MessageBox.Show("Failed to apply Patch \"" + patch.Name + "\".\nSkip..");
						System.Diagnostics.Debug.WriteLine(e);
					}
					break;

				case EPatchAction.DataAdd:
					if (DataHelper.AddFiles(patch) == false) {
						retVal = false;
						MessageBox.Show("Failed to apply Patch \"" + patch.Name + "\".\nSkip..");
					}
					break;
				case EPatchAction.DataDelete:
					if (DataHelper.DeleteFile(patch.Name) == false) {
						retVal = false;
						MessageBox.Show("Failed to apply Patch \"" + patch.Name + "\".\nSkip..");
					}
					break;
			}

			return retVal;
		}

		private void FinalizePatching() {
			if (TaskbarManager.IsPlatformSupported) {
				mWin7Taskbar.SetProgressState(TaskbarProgressBarState.Normal);
			}

			// Clean up
			this.UpdateStatus("Cleanup Files...");
			for (int i = 0; i < mPatches.Count; i++) {
				mPatches[i].Delete();
			}

			// Did we patched something?
			if (mPatchedFiles.Count > 0) {
				// cleanup GRF cache
				UpdateStatus("Saving GRF...");
				int count = GrfHelper.GrfList.Values.Count;
				int i = 0;
				foreach (RoGrfFile grf in GrfHelper.GrfList.Values) {
					int progress = (i * 100) / count;
					grf.Save();
					i++;
					UpdateProgressbar(progress);
				}

				UpdateStatus("Finished Patching!");
			} else {
				UpdateStatus("No new Patch available");
			}

			UpdateProgressbar(100);
			if (TaskbarManager.IsPlatformSupported) {
				mWin7Taskbar.SetProgressState(TaskbarProgressBarState.NoProgress);
			}
			mPatchInProgress = false;
			FinishPatcher();
		}
		#endregion

		#region Button Handler
		private void lblClose_Click(object sender, EventArgs e) {
			if (mPatchInProgress == true) {
				MessageBox.Show("You can't close the patcher until patching operations have been finished!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Close();
		}

		private void btnForum_Click(object sender, EventArgs e) {
			System.Diagnostics.Process.Start(URL_FORUM);
		}

		private void btnWebVote_Click(object sender, EventArgs e) {
			System.Diagnostics.Process.Start(URL_VOTE);

		}

		private void btnPatcherOptions_Click(object sender, EventArgs e) {
			using (frmSettings frm = new frmSettings()) {
				if (frm.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) {
					return;
				}

				Properties.Settings.Default.Layout = frm.SelectedLayout;
				LayoutManager.Layout = frm.SelectedLayout;
				// Update layout
				UpdateLayout();
			}
		}

		private void btnGameSetup_Click(object sender, EventArgs e) {
			System.Diagnostics.Process.Start("Setup.exe");
		}

		private void btnGameStart_Click(object sender, EventArgs e) {
			if (mPatchInProgress == true) {
				return; // hack? oO
			}

			if (mGodMode == true) {
				// TODO: possible to sart a special GM exe here

			}

			if (File.Exists("FunRO.exe") == false) {
				MessageBox.Show("Unable to find the FunRO.exe Game File!\nReinstall maybe fix this.", "Start Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
				return;
			}

			System.Diagnostics.Process.Start("FunRO.exe");
			Close();
		}
		#endregion


		private void FinishPatcher() {
			UpdateStatus("Finished! You may start FunRO now.");
			btnGameStart.Enabled = true;
			btnGameStart.BackgroundImage = Properties.Resources.btn_start;
		}


		private void CheckStatus() {
			ServerStatus status = new ServerStatus();
			status.DownloadStatus();

			UpdateServerInfo(stateLogin, status.LoginServer);
			UpdateServerInfo(stateChar, status.CharServer);
			UpdateServerInfo(stateMap, status.MapServer);
			UpdateWoeInfo(status.WoeActive);
			statePlayers.Text = status.PlayerCount.ToString();
		}

		private void UpdateServerInfo(PictureBox control, bool state) {
			if (state == true) {
				control.Image = Properties.Resources.server_online;
			} else {
				control.Image = Properties.Resources.server_offline;
			}
		}

		private void UpdateWoeInfo(bool state) {
			if (state == true) {
				stateWoe.Image = Properties.Resources.woe_active;
			} else {
				stateWoe.Image = Properties.Resources.woe_inactive;
			}
		}


		private void UpdateProgressbar(int progress) {
			InvokeHelper.Invoke(stateProgress, delegate() {
				int value = Math.Max(0, Math.Min(100, progress));
				value = (int)Math.Floor((540f / 100f) * value);
				if (stateProgress.Width != value) {
					stateProgress.Width = value;
					stateProgress.Invalidate();
				}

				if (TaskbarManager.IsPlatformSupported) {
					mWin7Taskbar.SetProgressValue(value, 100);
				}
			});
		}

		private void UpdateStatus(string p) {
			InvokeHelper.Invoke(lblStatusText, delegate() {
				lblStatusText.Text = p;
				Application.DoEvents();
			});
		}

		private void UpdateLayout() {
			panelMain.BackgroundImage = LayoutManager.GetImage("background");
			stateWoe.Image = LayoutManager.GetImage("woe_inactive");
			stateMap.Image = LayoutManager.GetImage("server_online");
			stateChar.Image = LayoutManager.GetImage("server_online");
			stateLogin.Image = LayoutManager.GetImage("server_online");
			btnPatcherOptions.BackgroundImage = LayoutManager.GetImage("btn_options");
			btnPatcherOptions.BackgroundImageHover = LayoutManager.GetImage("btn_options_hover");
			btnWebVote.BackgroundImage = LayoutManager.GetImage("btn_vote");
			btnWebVote.BackgroundImageClicked = LayoutManager.GetImage("btn_vote_clicked");
			btnWebVote.BackgroundImageHover = LayoutManager.GetImage("btn_vote_hover");
			btnGameSetup.BackgroundImage = LayoutManager.GetImage("btn_setup");
			btnGameSetup.BackgroundImageClicked = LayoutManager.GetImage("btn_setup_clicked");
			btnGameSetup.BackgroundImageHover = LayoutManager.GetImage("btn_setup_hover");
			btnGameStart.BackgroundImage = LayoutManager.GetImage("btn_start");
			btnGameStart.BackgroundImageClicked = LayoutManager.GetImage("btn_start_clicked");
			btnGameStart.BackgroundImageHover = LayoutManager.GetImage("btn_start_hover");
			btnWebForum.BackgroundImage = LayoutManager.GetImage("btn_forum");
			btnWebForum.BackgroundImageClicked = LayoutManager.GetImage("btn_forum_clicked");
			btnWebForum.BackgroundImageHover = LayoutManager.GetImage("btn_forum_hover");
			btnClose.BackgroundImage = LayoutManager.GetImage("btn_close");
			btnClose.BackgroundImageHover = LayoutManager.GetImage("btn_close_hover");
		}

	}

}
