using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using GodLesZ.Library;
using GodLesZ.SiedlerOnline.TradeListener.Controls;
using GodLesZ.SiedlerOnline.TradeListener.Library;
using PcapDotNet.Core;
using PcapDotNet.Packets;

namespace GodLesZ.SiedlerOnline.TradeListener {

	public partial class frmMain : Form {

		public static AverageStorage ItemStats;

		private BackgroundWorker mWorkingThread;
		private bool mIsClosing = false;
		private bool mPauseCapture = false;

		private int mCapturedPackets = 0;

		private TabPage mSelectedTab = null;
		private System.Windows.Forms.Timer mCleanupTimer;


		public frmMain() {
			InitializeComponent();
			InitializeList();

			// Disable logging of already logged packets
			DsoChatPacket.LogPackets = false;

			mWorkingThread = new BackgroundWorker();
			mWorkingThread.WorkerSupportsCancellation = true;
			mWorkingThread.WorkerReportsProgress = true;
			mWorkingThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(mWorkingThread_RunWorkerCompleted);
			mWorkingThread.ProgressChanged += new ProgressChangedEventHandler(mWorkingThread_ProgressChanged);
			mWorkingThread.DoWork += new DoWorkEventHandler(mWorkingThread_DoWork);

			mSelectedTab = tabPageTrades;
		}

		private void InitializeList() {
			// Set getter for trade filter list
			colFilterOffer.AspectGetter = delegate(object x) {
				if (((TradeListViewFilter)x).ItemOffer == EResource.None) {
					return "";
				}
				return string.Format("{0} {1}", ((TradeListViewFilter)x).ItemOfferOperatorString, ((TradeListViewFilter)x).ItemOfferAmount);
			};
			colFilterOffer.ImageGetter = delegate(object x) {
				string resName = ((TradeListViewFilter)x).ItemOffer.ToString();
				if (TradeListView.ResourceImages.Images.ContainsKey(resName)) {
					return TradeListView.ResourceImages.Images[resName];
				}
				return null;
			};
			colFilterDemanded.AspectGetter = delegate(object x) {
				if (((TradeListViewFilter)x).ItemDemanded == EResource.None) {
					return "";
				}
				return string.Format("{0} {1}", ((TradeListViewFilter)x).ItemDemandedOperatorString, ((TradeListViewFilter)x).ItemDemandedAmount);
			};
			colFilterDemanded.ImageGetter = delegate(object x) {
				string resName = ((TradeListViewFilter)x).ItemDemanded.ToString();
				if (TradeListView.ResourceImages.Images.ContainsKey(resName)) {
					return TradeListView.ResourceImages.Images[resName];
				}
				return null;
			};
			colFilterRatio.AspectGetter = delegate(object x) {
				if (((TradeListViewFilter)x).Ratio == 0) {
					return "";
				}
				return string.Format("{0} {1}", ((TradeListViewFilter)x).RatioOperatorString, AverageCounter.FormatDouble(((TradeListViewFilter)x).Ratio));
			};
			colFilterPlayer.AspectName = "Player";
		}

		#region BackgroundWorker
		private void mWorkingThread_DoWork(object sender, DoWorkEventArgs e) {
			PacketDevice packetDevice = (PacketDevice)e.Argument;

			// Open the device
			PacketCommunicator communicator = packetDevice.Open(65536, PacketDeviceOpenAttributes.Promiscuous | PacketDeviceOpenAttributes.NoCaptureLocal | PacketDeviceOpenAttributes.MaximumResponsiveness, 30000);
			communicator.SetFilter("net (87.119.203.0/24 or 94.236.0.0/16 or 31.222.148.0/24) and port 80");
			Debug.WriteLine("Worker listening on " + packetDevice.Description + "...");

			// Retrieve the packets
			Packet packet;
			DsoChatPacket chatPacket = null;
			do {
				// Thread should exit/cancel work
				if (mWorkingThread.CancellationPending == true) {
					communicator.Break();
					break;
				}

				// Pause?
				if (mPauseCapture) {
					Thread.Sleep(1000);
					continue;
				}

				// Wait for next packet
				PacketCommunicatorReceiveResult result = communicator.ReceivePacket(out packet);
				switch (result) {
					case PacketCommunicatorReceiveResult.Timeout:
						continue;
					case PacketCommunicatorReceiveResult.Ok:
						if (packet.Buffer != null && packet.Length > 0) {
							chatPacket = DsoChatPacket.Parse(packet.Buffer);
							if (chatPacket == null || chatPacket.Messages.Count == 0) {
								// Failed to parse
								mWorkingThread.ReportProgress(0);
							} else {
								mWorkingThread.ReportProgress(0, chatPacket.Clone());
							}
						}

						break;
					default:
						throw new InvalidOperationException("The result " + result + " should never be reached here");
				}
			} while (true);

			// Set result object to handle "Cancel" correctly
			e.Result = true;
		}

		private void mWorkingThread_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			DsoChatPacket packet = (DsoChatPacket)e.UserState;
			if (packet == null) {
				return;
			}

			AddPacket(packet);
		}

		private void mWorkingThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			// Cancel by .CancelAsync() method or because form is closing?
			// Note: If worker canceled by exception or any other "Kill",
			//		 the "Result" property is null
			if (e.Cancelled || mIsClosing || e.Result != null) {
				return;
			}

			// Exit by "out of work", means the packet listener exited for unknown reason
			MessageBox.Show("Working thread has been closed!\nPlease restart the program and report this to GodLesZ.\n\nThank you.");
		}
		#endregion


		#region frmMain Events
		private void frmMain_Load(object sender, EventArgs e) {
			// Load locale
			if (Properties.Settings.Default.SelectedLanguage == ELanguage.None) {
				Program.LoadLanguage(this);
			}

			// Load last used device
			if (string.IsNullOrEmpty(Properties.Settings.Default.SelectedDevice) == false) {
				if (SelectDevice(Properties.Settings.Default.SelectedDevice) == false) {
					Properties.Settings.Default.SelectedDevice = null;
				}
			}

			// CLeanup timer (10sec)
			mCleanupTimer = new System.Windows.Forms.Timer();
			mCleanupTimer.Interval = 10000;
			mCleanupTimer.Tick += new EventHandler(CleanupTimer_Tick);
			mCleanupTimer.Enabled = true;
			mCleanupTimer.Start();

			// Load item stats
			var avgStorageLoadResult = AverageStorage.Load(out ItemStats);
			if (avgStorageLoadResult == EAverageStorageLoadResult.FailedException) {
				MessageBox.Show("Failed to load \"Statistics.xml\".", "Statistics load error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			// Failed or file not found
			if (ItemStats == null) {
				ItemStats = new AverageStorage();
			}

			// Load filter profiles
			if (LoadFilterProfiles() == false) {
				return;
			}
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
			// Flag for background worker
			mIsClosing = true;
			// Save user properties
			Properties.Settings.Default.Save();
			// Save statistics
			try {
				XmlSerializer xml = new XmlSerializer(typeof(AverageStorage));
				using (FileStream fs = File.Open("Statistics.xml", FileMode.OpenOrCreate, FileAccess.Write)) {
					// Truncate
					fs.SetLength(0);
					// Write
					xml.Serialize(fs, ItemStats);
				}
			} catch (Exception ex) {
				Debug.WriteLine(ex);
				MessageBox.Show("Failed to save statistic!\n\n" + ex, "Statistic save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			// Prompt for saving profile, if changed
			if (listTrades.TradeFilterList.IsChanged) {
				if (MessageBox.Show("Your trade filter profile has been changed.\nDo you want to save it?", "Filter profile changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
					listTrades.TradeFilterList.Save(true);
				}
			}

			// Hide
			// Note: This is a lil trick because we need to kill the background worker before closing
			//		 but this may take up 5 sec.. so let the user think we are ready :P
			Hide();
			// Cancel worker process
			CancelWorker();
		}

		private void CleanupTimer_Tick(object sender, EventArgs e) {
			// Iterate all objects
			List<DsoTrade> trades = new List<DsoTrade>();
			foreach (var obj in listTrades.Objects) {
				DsoTrade trade = (DsoTrade)obj;
				// Kick 
				if (trade != null && trade.IsExpired) {
					trades.Add(trade);
				}
			}

			foreach (DsoTrade trade in trades) {
				listTrades.RemoveTrade(trade);
			}
			trades.Clear();
			trades = null;
		}
		#endregion

		#region menuMain Events
		private void menuMainProgramTest_Click(object sender, EventArgs e) {
			string chatMessageData = "<body><message xmlns=\"jabber:client\" type=\"groupchat\" from=\"trade@conference.94.236.31.135/masterast\" to=\"godlesz@94.236.31.135/xiff-bosh\" id=\"m_466\"><body>Tool|230|Marble|100</body><bbmsg xmlns=\"bbmsg\" playerid=\"1033067\" playername=\"Masterast\" playertag=\"\"/></message></body>";
			DsoChatPacket chatPacket = DsoChatPacket.Parse(chatMessageData);
			AddPacket(chatPacket);
		}

		private void menuMainSettings_Click(object sender, EventArgs e) {
			// Language icon
			if (Properties.Settings.Default.SelectedLanguage == ELanguage.English || Properties.Settings.Default.SelectedLanguage == ELanguage.None) {
				menuMainSettingsLanguage.Image = Properties.Resources.flag_great_britain;
			} else {
				menuMainSettingsLanguage.Image = Properties.Resources.flag_germany;
			}
		}

		private void menuMainSettingsNetwork_Click(object sender, EventArgs e) {
			using (frmNetworkSettings frm = new frmNetworkSettings(Properties.Settings.Default.SelectedDevice)) {
				if (frm.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) {
					return;
				}
				if (frm.SelectedDevice == null) {
					return;
				}

				OpenListening(frm.SelectedDevice);
				frm.Close();
			}
		}

		private void menuMainSettingsLanguage_Click(object sender, EventArgs e) {
			Program.LoadLanguage(this, true);
		}

		private void menuMainSettingsPauseCapture_Click(object sender, EventArgs e) {
			mPauseCapture = menuMainSettingsPauseCapture.Checked;

			if (mPauseCapture) {
				SetStatus("Capturing is paused");

				menuMainSettingsPauseCapture.Text = "Pause Capture";
				menuMainSettingsPauseCapture.Image = Properties.Resources.gear_run;
			} else {
				SetStatus("Capturing resumed");

				menuMainSettingsPauseCapture.Text = "Resume Capture";
				menuMainSettingsPauseCapture.Image = Properties.Resources.gear_run;
			}
		}
		#endregion

		#region listTrades Events
		private void listTrades_SelectedIndexChanged(object sender, EventArgs e) {
			if (listTrades.SelectedIndex == -1) {
				return;
			}

			DsoTrade trade = (DsoTrade)listTrades.GetSelectedObject();
			SetStatus(string.Format("{0}x {1} => {2}x {3}", trade.OfferedItemAmount, trade.OfferedItemLocalized, trade.DemandedItemAmount, trade.DemandedItemLocalized));
		}
		#endregion

		#region listFilter Events
		private void listFilter_SelectionChanged(object sender, EventArgs e) {
			// Enable/disable delete button
			if (listFilter.SelectedObject == null) {
				btnFilterDelete.Enabled = false;
				return;
			}
			btnFilterDelete.Enabled = true;
		}

		private void listFilter_ItemChecked(object sender, ItemCheckedEventArgs e) {
			// Item "IsActive" state has changed
			// Re-apply filter
			listTrades.FilterObjects();
		}

		private void btnFilterAdd_Click(object sender, EventArgs e) {
			using (frmTradeListFilter frm = new frmTradeListFilter()) {
				if (frm.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) {
					return;
				}

				// Is the filter valid?
				if (frm.TradeFilter != null && frm.TradeFilter.IsEmpty() == false) {
					// Add filter to list (management list & filter list)
					listFilter.AddObject(frm.TradeFilter);
					listTrades.TradeFilterList.Add(frm.TradeFilter);

					// Force filter refresh
					listTrades.FilterObjects();
				}
			}
		}

		private void btnFilterDelete_Click(object sender, EventArgs e) {
			if (listFilter.SelectedObject == null) {
				btnFilterDelete.Enabled = false;
				return;
			}

			// Remove from lists
			listTrades.TradeFilterList.Remove((TradeListViewFilter)listFilter.SelectedObject);
			listFilter.RemoveObject(listFilter.SelectedObject);

			// Force filter refresh
			listTrades.FilterObjects();
		}
		#endregion

		#region Filter Profile Events
		private void btnSaveFilterProfile_Click(object sender, EventArgs e) {
			if (cmbFilterProfile.SelectedIndex == -1) {
				return;
			}

			// Save and force rename
			string oldFilename = listTrades.TradeFilterList.Filepath;
			listTrades.TradeFilterList.Save(true);
			// If saved in a different file, combobox needs to be refreshed
			if (oldFilename != listTrades.TradeFilterList.Filepath) {
				// Only reload if saved in the profiles folder
				if (Path.GetDirectoryName(listTrades.TradeFilterList.Filepath) == TradeListViewFilterList.ProfileFolder) {
					// New profile, reload all (and skip selection)
					LoadFilterProfiles(true);
					// Select new profile
					string profileName = Path.GetFileNameWithoutExtension(listTrades.TradeFilterList.Filepath);
					int index = cmbFilterProfile.Items.IndexOf(profileName);
					cmbFilterProfile.SelectedIndex = (index != -1 ? index : 0);
				}
			}
		}

		private void btnDeleteFilterProfile_Click(object sender, EventArgs e) {
			if (cmbFilterProfile.SelectedIndex == -1) {
				btnDeleteFilterProfile.Enabled = false;
				return;
			}

			string filepath = listTrades.TradeFilterList.Filepath;
			if (File.Exists(filepath)) {
				try {
					File.Delete(filepath);
					cmbFilterProfile.Items.RemoveAt(cmbFilterProfile.SelectedIndex);
					cmbFilterProfile.SelectedIndex = 0;
				} catch {
					MessageBox.Show("Failed to delete profile file!", "Profile delete error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} else {
				MessageBox.Show("This file dos not exist!", "Profile delete error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void cmbFilterProfile_SelectedIndexChanged(object sender, EventArgs e) {
			if (cmbFilterProfile.SelectedIndex == -1) {
				btnDeleteFilterProfile.Enabled = false;
				return;
			}

			string profile = cmbFilterProfile.Items[cmbFilterProfile.SelectedIndex].ToString();
			string filename = profile + "." + TradeListViewFilterList.Extension;
			string filepath = Path.Combine(TradeListViewFilterList.ProfileFolder, filename);
			if (File.Exists(filepath) == false) {
				MessageBox.Show("Failed to open profile \"" + profile + "\".\n" + filepath, "Profile load error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				// Remove form list
				cmbFilterProfile.Items.RemoveAt(cmbFilterProfile.SelectedIndex);
				// Nothing left?
				if (cmbFilterProfile.Items.Count == 0) {
					MessageBox.Show("All profiles seems to be lost!\nThe application will try to restore default profile..", "Profile load error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					// Update selection & reload profiles
					cmbFilterProfile.SelectedIndex = -1;
					LoadFilterProfiles();
					return;
				}

				// Selected not found but still somthing in the list => select/load it
				cmbFilterProfile.SelectedIndex = 0;
				btnDeleteFilterProfile.Enabled = false;
				return;
			}

			// Profile found, load it
			listTrades.TradeFilterList = TradeListViewFilterList.Read(filepath);
			// Apply as new filter list & trigger filter
			listFilter.SetObjects(listTrades.TradeFilterList);
			listTrades.FilterObjects();

			// Remember last selection
			Properties.Settings.Default.SelectedProfile = cmbFilterProfile.Items[cmbFilterProfile.SelectedIndex].ToString();
			btnDeleteFilterProfile.Enabled = (Path.GetFileNameWithoutExtension(Properties.Settings.Default.SelectedProfile) != "Default");
		}
		#endregion

		#region tabMain Events
		private void tabMain_Selected(object sender, TabControlEventArgs e) {
			// Set current as inactive
			if ((mSelectedTab as TabPage) == tabPageTrades) {
				// icon_diplomacy
				(mSelectedTab as TabPage).ImageIndex = 1;
			} else {
				(mSelectedTab as TabPage).ImageIndex = 3;
			}

			// Set active
			if (e.TabPage == tabPageTrades) {
				// icon_diplomacy
				e.TabPage.ImageIndex = 0;
			} else {
				e.TabPage.ImageIndex = 2;
			}

			// Save selected tab
			mSelectedTab = e.TabPage;
		}
		#endregion



		#region Helper
		private bool SelectDevice(string deviceName) {
			// Retrieve the device list from the local machine
			var deviceList = LivePacketDevice.AllLocalMachine;
			if (deviceList.Count == 0) {
				MessageBox.Show("No interfaces found! Make sure WinPcap is installed.", "Interface error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			foreach (var device in deviceList) {
				if (device.Description == deviceName) {
					OpenListening(device);
					return true;
				}
			}

			return false;
		}

		private void OpenListening(PacketDevice packetDevice) {
			// Kill worker
			CancelWorker();

			// Save as "latest used"
			Properties.Settings.Default.SelectedDevice = packetDevice.Description;

			// Start listen
			SetStatus("Start listen on: " + packetDevice.Description);
			mWorkingThread.RunWorkerAsync(packetDevice);
		}

		private void CancelWorker() {
			if (mWorkingThread == null) {
				return;
			}

			while (mWorkingThread.IsBusy) {
				if (mWorkingThread.CancellationPending == false) {
					mWorkingThread.CancelAsync();
				}
				Thread.Sleep(100);
				Application.DoEvents();
			}
		}


		private void AddPacket(DsoChatPacket packet) {
			foreach (DsoChatPacketMessage msg in packet.Messages) {
				switch (msg.Type) {
					case EDsoMsgTypes.ChatGlobal:
						chatGlobal.AddMessage(msg);
						HighlightTab(tabPageChatGlobal);
						break;
					case EDsoMsgTypes.ChatHelp:
						chatHelp.AddMessage(msg);
						HighlightTab(tabPageChatHelp);
						break;
					case EDsoMsgTypes.Trade:
						// Build trade instance
						// @EDIT: Trade now is a simple chat
						/*
						DsoTrade trade = DsoTrade.Create(msg, (msg.MessageDetails != null ? msg.MessageDetails.Player : "<unknown?>"));
						if (trade != null) {
							// Add to statistics
							ItemStats.CountAverage(trade.OfferedItem, trade.DemandedItem, trade.Ratio);
							// Add to trade list
							listTrades.AddTrade(trade);
							// highlight tab
							HighlightTab(tabPageTrades);
							// Refresh count
							lblStatusTrades.Text = string.Format("Trades: {0}", listTrades.GetItemCount());
						}
						*/
						break;
				}

				// Delete trades
				if ((msg.Type & EDsoMsgTypes.Clear) == EDsoMsgTypes.Clear) {
					if ((msg.Type & EDsoMsgTypes.Trade) == EDsoMsgTypes.Trade) {
						DsoTrade trade = DsoTrade.Create(msg, (msg.MessageDetails != null ? msg.MessageDetails.Player : "<unknown?>"));
						if (trade != null && listTrades.RemoveTrade(trade) == false) {
							//SetStatus("Failed to remove trade from player \"" + trade.Player + "\".");
						} else {
							// Refresh count
							lblStatusTrades.Text = string.Format("Trades: {0}", listTrades.GetItemCount());
						}
					}
				}

				// Count captured packets
				mCapturedPackets++;
				lblStatusPackets.Text = string.Format("Packets: {0}", mCapturedPackets);
			}
		}

		private void HighlightTab(TabPage tab) {
			if (tabMain.SelectedTab != tab) {
				if (tab == tabPageTrades) {
					// icon_diplomacy
					tab.ImageIndex = 0;
				} else {
					tab.ImageIndex = 2;
				}
			}
		}

		private bool LoadFilterProfiles() {
			return LoadFilterProfiles(false);
		}

		private bool LoadFilterProfiles(bool skipSelection) {
			// Get profiles
			string[] profiles = TradeListViewFilterList.GetProfiles();
			// Error? (i.e. failed to create directory)
			if (profiles == null) {
				Close();
				return false;
			}
			// Nothign found?
			if (profiles.Length == 0) {
				// Create default
				string filepath = Path.Combine(TradeListViewFilterList.ProfileFolder, "Default." + TradeListViewFilterList.Extension);
				new TradeListViewFilterList(filepath).Save();
				// Load profiles again
				profiles = TradeListViewFilterList.GetProfiles();
				// Still nothing?
				if (profiles.Length == 0) {
					MessageBox.Show("Failed to load profiles!\nPlease start again with admin rights.\n\nIf the Problem still exists, please report it to GodLesZ\nThank you", "Profile loading error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Close();
					return false;
				}
			}

			// Add all to combo box (without extension)
			foreach (string filepath in profiles) {
				cmbFilterProfile.Items.Add(Path.GetFileNameWithoutExtension(filepath));
			}

			if (skipSelection == false) {
				// Selected a profile?
				if (string.IsNullOrEmpty(Properties.Settings.Default.SelectedProfile) == false) {
					int selectedIndex = cmbFilterProfile.Items.IndexOf(Properties.Settings.Default.SelectedProfile);
					if (selectedIndex != -1) {
						cmbFilterProfile.SelectedIndex = selectedIndex;
					} else {
						// Old selection does not exist, so delete the reference
						Properties.Settings.Default.SelectedProfile = null;
					}
				}

				// Select default/first profile
				if (cmbFilterProfile.SelectedIndex == -1) {
					int selectedIndex = cmbFilterProfile.Items.IndexOf("Default");
					cmbFilterProfile.SelectedIndex = (selectedIndex != -1 ? selectedIndex : 0);
				}
			}

			return true;
		}
		#endregion

		#region SetStatus
		private void SetStatus(string message) {
			SetStatus(message, null);
		}

		private void SetStatus(string message, Image img) {
			lblStatus.Text = message;
			if (img != null) {
				lblStatus.Image = img;
			}
		}
		#endregion

	}

}
