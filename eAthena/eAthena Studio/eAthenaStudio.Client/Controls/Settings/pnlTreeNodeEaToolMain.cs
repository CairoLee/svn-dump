using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace eAthenaTool.Client {

	public partial class pnlTreeNodeEaToolMain : pnlTreeNode {
		public string EathenaRootFolder {
			get;
			set;
		}

		public string RagnarokRootFolder {
			get;
			set;
		}


		public pnlTreeNodeEaToolMain() {
			InitializeComponent();
		}


		private void btnEathenaOpen_Click( object sender, EventArgs e ) {
			txtEathenaPath.Text = EathenaRootFolder = GetPath( "Wähle dein eAthena Verzeichnis aus" );
		}

		private void btnRagnarokOpen_Click( object sender, EventArgs e ) {
			txtRagnarokPath.Text = RagnarokRootFolder = GetPath( "Wähle dein Ragnarok Verzeichnis aus" );
		}


		private string GetPath( string Desc ) {
			using( FolderBrowserDialog dlg = new FolderBrowserDialog() ) {
				dlg.Description = Desc;
				if( dlg.ShowDialog( this ) != DialogResult.OK )
					return "";

				return dlg.SelectedPath;
			}
		}

	}

}
