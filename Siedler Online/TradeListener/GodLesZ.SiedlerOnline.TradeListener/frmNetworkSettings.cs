using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PcapDotNet.Core;

namespace GodLesZ.SiedlerOnline.TradeListener {

	public partial class frmNetworkSettings : Form {
		private string mDefaultDevice = null;
		private IList<LivePacketDevice> mDevices;

		public PacketDevice SelectedDevice {
			get;
			private set;
		}


		public frmNetworkSettings()
			: this("") {
		}

		public frmNetworkSettings(string selectedDevice) {
			InitializeComponent();

			if (string.IsNullOrEmpty(selectedDevice) == false) {
				mDefaultDevice = selectedDevice;
			}
		}


		private void frmNetworkSettings_Load(object sender, EventArgs e) {
			btnSave.Enabled = false;

			// Retrieve the device list from the local machine
			mDevices = LivePacketDevice.AllLocalMachine;
			if (mDevices.Count == 0) {
				MessageBox.Show("No interfaces found! Make sure WinPcap is installed.", "Interface error");
				return;
			}

			// Fill combo box
			cmbInterfaces.Items.Clear();
			foreach (var device in mDevices) {
				cmbInterfaces.Items.Add(device.Description);
			}

			if (string.IsNullOrEmpty(mDefaultDevice) == false) {
				int i = cmbInterfaces.Items.IndexOf(mDefaultDevice);
				if (i != -1) {
					cmbInterfaces.SelectedIndex = i;
				}
			}
		}

		private void cmbInterfaces_SelectedIndexChanged(object sender, EventArgs e) {
			if (cmbInterfaces.SelectedIndex == -1) {
				SelectedDevice = null;
				return;
			}

			SelectedDevice = mDevices[cmbInterfaces.SelectedIndex];
			btnSave.Enabled = true;
		}

		private void btnSave_Click(object sender, EventArgs e) {
			Hide();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Hide();
		}

	}

}
