using System;
using System.Windows.Forms;
using System.IO;

using Map_Formats;
using Microsoft.Xna.Framework;

namespace MapRead.RSM {


	public partial class RSMViewer : Form {

		public RSMViewer() {

			InitializeComponent();

		}

		private void btnOpenFile_Click( object sender, EventArgs e ) {
			OpenFileDialog dlg = new OpenFileDialog();
			string FilePath = String.Empty;
			dlg.Filter = "RSM Model (*.rsm)|*.rsm";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			FilePath = dlg.FileName;
			txtFile.Text = FilePath;

			Map_Formats.RSM rsm = new Map_Formats.RSM( FilePath, true );

		}

	}

}
