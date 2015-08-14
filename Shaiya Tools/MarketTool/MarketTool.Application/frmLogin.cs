using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FinalSoftware.MySql;
using Crypter = FinalSoftware.MySql.HelperCrypt;

namespace MarketTool.Application {

	public partial class frmLogin : Form {
		public bool HasAccess = false;
		private MySqlWrapper sql;

		public frmLogin( MySqlWrapper SqlObj ) {
			sql = SqlObj;

			InitializeComponent();

			if( Properties.Settings.Default.Username != string.Empty ) {
				txtUsername.Text = Crypter.Decrypt( Properties.Settings.Default.Username );
				txtPasswort.Text = Crypter.Decrypt( Properties.Settings.Default.Password );
			}
		}


		private void frmLogin_FormClosing( object sender, FormClosingEventArgs e ) {
			Properties.Settings.Default.Username = Crypter.Encrypt( txtUsername.Text );
			Properties.Settings.Default.Password = Crypter.Encrypt( txtPasswort.Text );

			Properties.Settings.Default.Save();
		}


		private void bntLogin_Click( object sender, EventArgs e ) {
			if( sql.QueryCount( "SELECT COUNT(user_id) FROM `shaiya_user` WHERE username = '{0}' AND password = '{1}'", txtUsername.Text.MysqlEscape(), txtPasswort.Text.MysqlEscape() ) == 0 ) {
				HasAccess = false;
				if( MessageBox.Show( "Die Account-Daten sind nicht korrekt.\n\nNochmal versuchen?", "Fehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error ) == DialogResult.Cancel )
					this.Close();
				return;
			}

			HasAccess = true;
			this.Close();
		}

		private void btnSkip_Click( object sender, EventArgs e ) {
			HasAccess = false;
			this.Close();
		}

		private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e ) {
			System.Diagnostics.Process.Start( "http://de.forums.aeriagames.com/viewtopic.php?t=36881" );
		}

	}

}
