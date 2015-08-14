using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FRO.AccountChecker {

	public partial class frmMain : Form {
		public static DataTable Accounts;

		private PictureBox mLoadingBox = null;
		private BackgroundWorker mWorker;



		public frmMain() {
			InitializeComponent();

			if (Accounts == null) {
				Accounts = new DataTable("AccountList");
				Accounts.Columns.Add("Username");
				Accounts.Columns.Add("Password");
				Accounts.Columns.Add("Email");
				Accounts.Columns.Add("Notes");
				Accounts.AcceptChanges();
			}

			string storeagePath = Environment.CurrentDirectory + @"\" + Properties.Settings.Default.AccountList;
			if (File.Exists(storeagePath)) {
				Accounts.ReadXml(storeagePath);

				RefreshAccountList();
			}

			mWorker = new BackgroundWorker();
			mWorker.WorkerSupportsCancellation = true;
			mWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(mWorker_RunWorkerCompleted);
			mWorker.DoWork += new DoWorkEventHandler(mWorker_DoWork);
		}


		#region BackgroundWorker
		private void mWorker_DoWork(object sender, DoWorkEventArgs e) {
			string[] args = (string[])e.Argument;
			e.Result = CharacterHelper.LoadInfos(args[0].Trim(), args[1].Trim());
		}

		private void mWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			HideLoading();

			bool result = (bool)e.Result;
			if (result == false) {
				MessageBox.Show("Invalid password or account name", "Account detail error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (CharacterHelper.Chars.Count == 0) {
				MessageBox.Show("No character found on this account.", "Account character", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			int i = 0;
			foreach (var c in CharacterHelper.Chars) {
				var con = new CharacterInfoControl(c);
				con.Location = new Point(10 + (i % 3) * (con.Width + 10), 10 + (i / 3) * (con.Height + 10));
				pnlCharacters.Controls.Add(con);

				i++;
			}
		}
		#endregion


		#region frmMain Events
		private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
			string storeagePath = Environment.CurrentDirectory + @"\" + Properties.Settings.Default.AccountList;
			Accounts.WriteXml(storeagePath);

			Properties.Settings.Default.Save();
		} 
		#endregion

		#region MenuProgram Events
		private void menuMainProgramClose_Click(object sender, EventArgs e) {
			Close();
		}
		#endregion

		private void menuMainAccountsManage_Click(object sender, EventArgs e) {
			using (frmAccountManagement frm = new frmAccountManagement()) {
				frm.ShowDialog(this);
				frm.Close();
			}

			RefreshAccountList();
		}

		private void btnLogin_Click(object sender, EventArgs e) {
			if (cmbAccounts.SelectedIndex == -1) {
				return;
			}
			DisplayLoading();

			if (mWorker.IsBusy) {
				MessageBox.Show("One operation is still pending, please wait a few seconds.", "Operation in pending", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			DataRow row = Accounts.Rows[cmbAccounts.SelectedIndex];
			mWorker.RunWorkerAsync(new string[] { row["Username"].ToString(), row["Password"].ToString() });
		}

		private void cmbAccounts_SelectedIndexChanged(object sender, EventArgs e) {
			btnLogin.PerformClick();
		}


		#region Loading Show/Hide
		private void DisplayLoading() {
			pnlCharacters.Controls.Clear();

			if (mLoadingBox == null) {
				mLoadingBox = new PictureBox();
				mLoadingBox.Image = global::FRO.AccountChecker.Properties.Resources.loading;
				mLoadingBox.Location = new System.Drawing.Point(174, 33);
				mLoadingBox.Name = "imgLoading";
				mLoadingBox.Size = new Size(235, 235);
				mLoadingBox.SizeMode = PictureBoxSizeMode.AutoSize;
				mLoadingBox.TabIndex = 0;
				mLoadingBox.TabStop = false;
			}

			pnlCharacters.Controls.Add(mLoadingBox);
			mLoadingBox.Show();
		}

		private void HideLoading() {
			mLoadingBox.Hide();
			pnlCharacters.Controls.Clear();
		}
		#endregion

		private void RefreshAccountList() {
			int padLength = 25;

			cmbAccounts.Items.Clear();
			foreach (DataRow row in Accounts.Rows) {
				string username = row["Username"].ToString();
				string password = row["Password"].ToString();
				string email = row["Email"].ToString();

				string cmbEntry = username.PadRight(padLength);
				cmbEntry += "|" + password.PadRight(padLength);
				if (email.Length > 0) {
					cmbEntry += "|" + email.PadRight(padLength);
				}

				cmbAccounts.Items.Add(cmbEntry);
			}

		}

	}

}
