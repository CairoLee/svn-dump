using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FinalSoftware.MySql;

namespace Shaiya.Reader.Client {

	public partial class frmLogin : Form {

		public frmLogin() {
			InitializeComponent();

			if( Properties.Settings.Default.ForumUsername != string.Empty ) {
				txtUsername.Text = HelperCrypt.Decrypt( Properties.Settings.Default.ForumUsername );
				txtPassword.Text = HelperCrypt.Decrypt( Properties.Settings.Default.ForumPassword );
			}
		}

		private void frmLogin_FormClosing( object sender, FormClosingEventArgs e ) {
			Properties.Settings.Default.ForumUsername = HelperCrypt.Encrypt( txtUsername.Text );
			Properties.Settings.Default.ForumPassword = HelperCrypt.Encrypt( txtPassword.Text );
			Properties.Settings.Default.Save();
		}

	}

}
