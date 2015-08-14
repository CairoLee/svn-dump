using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eA_Script_VarParser {
	public partial class frmMain : Form {
		public frmMain() {
			InitializeComponent();

			ScriptScanner.Initialize( this );
		}

		private void btnOpen_Click( object sender, EventArgs e ) {
			using( FolderBrowserDialog dlg = new FolderBrowserDialog() ) {
				if( dlg.ShowDialog( this ) != DialogResult.OK )
					return;

				txtPath.Text = dlg.SelectedPath;
				ScriptScanner.ScanDir( txtPath.Text );
				MessageBox.Show( "Directory scanned\nlongest: " + ScriptParserList.Longest );
			}

		}


		public void AddLog( string Message ) {
			Application.DoEvents();
			listLog.Items.Add( Message );
			listLog.SelectedIndex = listLog.Items.Count - 1;
		}
	}

}
