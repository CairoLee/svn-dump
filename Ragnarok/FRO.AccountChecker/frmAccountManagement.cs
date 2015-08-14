using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace FRO.AccountChecker {

	public partial class frmAccountManagement : Form {

		public frmAccountManagement() {
			InitializeComponent();
			
			dataAccounts.DataSource = frmMain.Accounts.DefaultView;
			dataAccounts.Columns["Username"].Width = 150;
			dataAccounts.Columns["Password"].Width = 150;
			dataAccounts.Columns["Email"].Width = 150;
			dataAccounts.Columns["Notes"].Width = 150;
		}


		private void frmAccountManagement_Load(object sender, EventArgs e) {
		}

		private void frmAccountManagement_FormClosing(object sender, FormClosingEventArgs e) {
			frmMain.Accounts.AcceptChanges();
		}


		private void dataAccounts_UserAddedRow(object sender, DataGridViewRowEventArgs e) {
			//frmMain.Accounts.AcceptChanges();
		}

		private void dataAccounts_UserDeletedRow(object sender, DataGridViewRowEventArgs e) {
			frmMain.Accounts.AcceptChanges();
		}

		private void dataAccounts_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
			//frmMain.Accounts.AcceptChanges();
		}


		private void menuAccountsManagerClose_Click(object sender, EventArgs e) {
			Hide();
		}

	}

}
