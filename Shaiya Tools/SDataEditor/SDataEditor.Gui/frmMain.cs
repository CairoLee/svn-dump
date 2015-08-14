using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SDataEditor.Library;
using System.IO;


namespace SDataEditor.Gui {

	public partial class frmMain : Form {

		public frmMain() {
			InitializeComponent();
		}


		#region MenuProgram
		private void MenuProgramClose_Click( object sender, EventArgs e ) {
			this.Close();
		} 
		#endregion

		#region MenuSData
		private void MenuSDataItem_Click( object sender, EventArgs e ) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Item.SData|Item.SData";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			IShaiyaSData data = new ItemSData( dlg.FileName );
			data.Fill( gridData );
		}

		private void MenuSDataQuest_Click( object sender, EventArgs e ) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "NpcQuest.SData|NpcQuest.SData";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			IShaiyaSData data = new QuestSData( dlg.FileName );
			data.Fill( gridData );
		}
		#endregion

		#region MenuExport
		private void MenuExportGrid2Text_Click( object sender, EventArgs e ) {
			using( SaveFileDialog dlg = new SaveFileDialog() ) {
				dlg.Filter = "HTML Datei (*.html)|*.html";
				if( dlg.ShowDialog() != DialogResult.OK )
					return;

				string baseName = Path.GetDirectoryName( dlg.FileName ) + @"\" + Path.GetFileNameWithoutExtension( dlg.FileName );
				int cycles = ( ( gridData.Rows.Count / 1000 ) + 1 ) * 1000;
				for( int i = 0; i < cycles; i += 1000 ) {
					int end = i + 1000;
					if( gridData.Export( baseName + "_" + i + "-" + end + ".html", i, end ) == false ) {
						MessageBox.Show( "Failed to export Data!\nRows: " + i + " - " + end, "Ärroar", MessageBoxButtons.OK, MessageBoxIcon.Error );
					}
				}
			}
		}
		#endregion

	}



	#region Program.Main
	public static class Program {
		[STAThread]
		public static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new frmMain() );
		}
	} 
	#endregion

}
