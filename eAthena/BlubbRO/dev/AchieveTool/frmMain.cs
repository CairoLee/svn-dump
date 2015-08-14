using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GodLesZ.Library.MySql;

namespace AchieveTool {

	public partial class frmMain : Form {
		private MySqlWrapper mMysql;

		public frmMain() {
			InitializeComponent();

		}


		private void frmMain_Shown(object sender, EventArgs e) {
			mMysql = new MySqlWrapper("178.77.65.232", 3306, "insanero", "NNDRDFFB3xmXwK9q", "insanero");
			EMysqlConnectionError result = mMysql.Prepare();
			if (result != EMysqlConnectionError.None) {
				MessageBox.Show("Datenbanmk Verbindung failed: " + result.ToString());
				Close();
				return;
			}

			cmbType.SelectedIndex = 0;
		}

		#region listRequire Events
		private void btnRequireAdd_Click(object sender, EventArgs e) {
			using (frmAddRequirement frm = new frmAddRequirement()) {
				if (frm.ShowDialog(this) != DialogResult.OK)
					return;

				listRequires.Items.Add(new ListViewItem(new string[] { (listRequires.Items.Count + 1).ToString(), frm.GetReqCount.ToString(), frm.GetReqParam }));
			}
		}

		private void btnRequireDel_Click(object sender, EventArgs e) {
			if (listRequires.SelectedIndices.Count == 0)
				return;
			listRequires.Items.RemoveAt(listRequires.SelectedIndices[0]);
		}

		private void listRequires_SelectedIndexChanged(object sender, EventArgs e) {
			if (listRequires.SelectedIndices.Count == 0) {
				btnRequireDel.Enabled = false;
				return;
			}
			btnRequireDel.Enabled = true;
		}
		#endregion

		#region listReceive Events
		private void btnReceiveAdd_Click(object sender, EventArgs e) {
			using (frmAddReceivement frm = new frmAddReceivement()) {
				if (frm.ShowDialog(this) != DialogResult.OK)
					return;

				listReceive.Items.Add(new ListViewItem(new string[] { (listReceive.Items.Count + 1).ToString(), frm.GetRecvTypeName, frm.GetRecvParam }));
			}
		}

		private void btnReceiveDel_Click(object sender, EventArgs e) {
			if (listReceive.SelectedIndices.Count == 0)
				return;
			listReceive.Items.RemoveAt(listReceive.SelectedIndices[0]);
		}

		private void listReceive_SelectedIndexChanged(object sender, EventArgs e) {
			if (listReceive.SelectedIndices.Count == 0) {
				btnReceiveDel.Enabled = false;
				return;
			}
			btnReceiveDel.Enabled = true;
		}
		#endregion

		private void btnAchieveAdd_Click(object sender, EventArgs e) {

			string query = "INSERT INTO `achieve_db` (`AchieveType`, `Name`, `NameCutin`, `Description`)VALUES('" + (cmbType.SelectedIndex + 1) + "', '" + txtName.Text.MysqlEscape() + "', '" + txtCutin.Text.MysqlEscape() + "', '" + txtDesc.Text.MysqlEscape() + "')";
			mMysql.Query(query);

			int achieveID = mMysql.GetLastInsertID();
			if (achieveID == 0) {
				MessageBox.Show("Failed to add achievement. " + Environment.NewLine + mMysql.LastError.ToString(), "Achievement error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Requirements
			for (int i = 0; i < listRequires.Items.Count; i++) {
				string count = listRequires.Items[i].SubItems[1].Text.MysqlEscape();
				string param = listRequires.Items[i].SubItems[2].Text.MysqlEscape();
				string requireQuery = "INSERT INTO `achieve_require_db` (`AchieveID`, `Count`, `Param1`)VALUES('" + achieveID + "', '" + count + "', '" + param + "')";
				mMysql.Query(requireQuery);
				if (mMysql.GetLastInsertID() == 0) {
					mMysql.QuerySimple("DELETE FROM `achieve_db` WHERE `AchieveID` = '" + achieveID + "'");

					MessageBox.Show("Failed to add achieve requirement. " + Environment.NewLine + mMysql.LastError.ToString(), "Achievement error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			// Receivements
			for (int i = 0; i < listReceive.Items.Count; i++) {
				int type = (frmAddReceivement.Types.IndexOf(listReceive.Items[i].SubItems[1].Text) + 1);
				string param = listReceive.Items[i].SubItems[2].Text.MysqlEscape();
				string receiveQuery = "INSERT INTO `achieve_receive_db` (`AchieveID`, `ReceiveType`, `Param1`)VALUES('" + achieveID + "', '" + type + "', '" + param + "')";
				mMysql.Query(receiveQuery);
				if (mMysql.GetLastInsertID() == 0) {
					mMysql.QuerySimple("DELETE FROM `achieve_db` WHERE `AchieveID` = '" + achieveID + "'");
					mMysql.QuerySimple("DELETE FROM `achieve_require_dbachieve_require_db` WHERE `AchieveID` = '" + achieveID + "'");

					MessageBox.Show("Failed to add achieve receivement. " + Environment.NewLine + mMysql.LastError.ToString(), "Achievement error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}


			cmbType.SelectedIndex = 0;
			txtCutin.Text = txtDesc.Text = txtName.Text = "";
			listReceive.Items.Clear();
			listRequires.Items.Clear();
			MessageBox.Show("Added o.o\nHorst");
		}

	}

}
