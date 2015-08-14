using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;

namespace eACGUI {

	public partial class Core : Office2007Form {
		private bool mColorSelected = false;
		private eOffice2007ColorScheme mBaseColorScheme = eOffice2007ColorScheme.Blue;
		private EathenaConfigFileCollection mFiles = new EathenaConfigFileCollection();
		private string mSelectedFile = string.Empty;

		public Core() {
			InitializeComponent();
		}

		#region MainForm Events
		private void Core_FormClosing( object sender, FormClosingEventArgs e ) {
			Properties.Settings.Default.Save();
		}
		private void Core_Load( object sender, EventArgs e ) {
			if( LoadSettings() == false ) {
				this.Close();
				return;
			}

			ConfGrid.ClearSelection();
			ConfGrid.Rows.Clear();

			FileTree.Nodes.Clear();
			foreach( string key in mFiles.Keys )
				FileTree.Nodes.Add( key );

			SetStatus( "Application is Ready to Start!" );
		} 
		#endregion

		#region MainMenu Events
		private void btnMenuGUICcCustom_ColorPreview( object sender, ColorPreviewEventArgs e ) {
			RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable( mBaseColorScheme, e.Color );
		}
		private void btnMenuGUICcCustom_SelectedColorChanged( object sender, EventArgs e ) {
			mColorSelected = true;
			RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable( mBaseColorScheme, btnMenuGUICcCustom.SelectedColor );
		}
		private void btnMenuGUICcCustom_ExpandChange( object sender, EventArgs e ) {
			if( btnMenuGUICcCustom.Expanded ) {
				mColorSelected = false;
				mBaseColorScheme = ( (Office2007Renderer)GlobalManager.Renderer ).ColorTable.InitialColorScheme;
			} else if( !mColorSelected )
				RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable( mBaseColorScheme );
		}

		private void btnMenuGUICcBlue_MouseHover( object sender, EventArgs e ) {
			RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable( eOffice2007ColorScheme.Blue );
		}
		private void btnMenuGUICcBlue_MouseLeave( object sender, EventArgs e ) {
			RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable( mBaseColorScheme );
		}
		private void btnMenuGUICcBlue_Click( object sender, EventArgs e ) {
			RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable( eOffice2007ColorScheme.Blue );
		}

		private void btnMenuGUICcSilver_MouseHover( object sender, EventArgs e ) {
			RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable( eOffice2007ColorScheme.Silver );
		}
		private void btnMenuGUICcSilver_MouseLeave( object sender, EventArgs e ) {
			RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable( mBaseColorScheme );
		}
		private void btnMenuGUICcSilver_Click( object sender, EventArgs e ) {
			RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable( eOffice2007ColorScheme.Silver );
		}

		private void btnMenuGUICcBlack_MouseHover( object sender, EventArgs e ) {
			RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable( eOffice2007ColorScheme.Black );
		}
		private void btnMenuGUICcBlack_MouseLeave( object sender, EventArgs e ) {
			RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable( mBaseColorScheme );
		}
		private void btnMenuGUICcBlack_Click( object sender, EventArgs e ) {
			RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable( eOffice2007ColorScheme.Black );
		}

		private void btnMenuProgramClose_Click( object sender, EventArgs e ) {
			this.Close();
		}
		private void btnMenuEditPath_Click( object sender, EventArgs e ) {
			Properties.Settings.Default.ConfigDirectory = string.Empty;

			Core_Load( null, EventArgs.Empty ); // OpenPath, clear Tree and fill new
			ConfGrid.Rows.Clear();
		}
		private void btnMenuAbout_Click( object sender, EventArgs e ) {
			string Desc = @"Simple Editor/GUI for eAthena Config Files
Contains loading, editing and saving.
Bug Reports may be send to GodLesz on eAthena.ws

Thanks @...
  - Gomen for the Idea
  - DarkDevine for Styling, GUI Tips && Merge Images
  - Elene for Exe Icon && AboutBox Image

... but most thanks go's to my Wife <3


© 2009 Blubb Gaming - by GodLesZ";
			AboutBox dlg = new AboutBox( Desc );
			dlg.ShowDialog();
		}
		private void btnMenuRefresh_Click( object sender, EventArgs e ) {
			Core_Load( null, EventArgs.Empty ); // OpenPath, clear Tree and fill new
			ConfGrid.Rows.Clear();
		}
		private void btnMenuMerge_Click( object sender, EventArgs e ) {
			this.Hide();
			using( frmMerge frm = new frmMerge( mFiles ) )
				frm.ShowDialog();
			this.Show();
		}
		private void btnMenuExport_Click( object sender, EventArgs e ) {
			if( mFiles.Count == 0 )
				return;

			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "eACGUI XML Export (*.xml)|*.xml";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			if( mFiles.Export( dlg.FileName ) == true )
				Tools.Info( "Config Export", "Das Exportieren der Einstellug war erfolgreich!" );
			else
				Tools.Error( "Config Export", "Es ist ein Fehler beim Exportieren der Einstellug aufgetreten!\nBitte wende dich an GodLesZ" );
		}
		private void btnMenuImport_Click( object sender, EventArgs e ) {
			string path = string.Empty;
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "eACGUI XML Export (*.xml)|*.xml";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			mFiles = new EathenaConfigFileCollectionSerializeable().Import( dlg.FileName );
			if( mFiles == null ) {
				Tools.Error( "Fehler beim Importieren", "Das Importieren der Datei ist fehlgeschlagen!\nFalls dies öfter vorkommt, wende dich an GodLesZ!" );
				return;
			}

			FileTree.Nodes.Clear();
			foreach( string key in mFiles.Keys )
				FileTree.Nodes.Add( key );

			Tools.Info( "Import erfolgreich Abgeschlossen", "Der Config Import wurde erfolgreich abgeschlossen!\n\nAber beachte:\nWenn du nun speicherst werden deine Config Datein mit den soeben geladenen komplett ersetzt! (Backup vorhanden)" );
		}

		private void chkSettingComments_CheckedChanged( object sender, CheckBoxChangeEventArgs e ) {
			if( mSelectedFile != string.Empty )
				FillGrid( mSelectedFile );

			Properties.Settings.Default.ShowComments = chkSettingComments.Checked;
		}
		private void chkSettingSaveOnExit_CheckedChanged( object sender, CheckBoxChangeEventArgs e ) {
			Properties.Settings.Default.SaveOnExit = chkSettingSaveOnExit.Checked;
		}

		private void comboSettingSearch_SelectedIndexChanged( object sender, EventArgs e ) {
			if( comboSettingSearch.Items.Count == 0 )
				return;

			string SearchValue = (string)comboSettingSearch.SelectedItem;
			int i;
			for( i = 0; i < ConfGrid.Rows.Count; i++ )
				if( (string)ConfGrid.Rows[ i ].Cells[ 0 ].Value == SearchValue )
					break;

			if( i >= ConfGrid.Rows.Count ) {
				MessageBoxEx.Show( "Eintrag im Grid nicht gefunden!", "Fehler beim Suchen", MessageBoxButtons.OK, MessageBoxIcon.Error );
				return;
			}

			ConfGrid.FirstDisplayedScrollingRowIndex = i;
		}
		#endregion

		#region List Events
		private void FileTree_AfterSelect( object sender, TreeViewEventArgs e ) {
			if( FileTree.Nodes.Count == 0 )
				return;

			SetStatus( "Lade GridInfo für die Datei `" + FileTree.SelectedNode.Text + "` ...", Color.Blue );
			FillGrid( FileTree.SelectedNode.Text );
			mSelectedFile = FileTree.SelectedNode.Text;

			SetStatus( "GridInfo erfolgreich geladen! Zeige: `" + FileTree.SelectedNode.Text + "`" );
			this.Text = Tools.AssemblyProduct + " - " + FileTree.SelectedNode.Text;
		} 
		#endregion

		#region Grid Events
		private void ConfGrid_CellEndEdit( object sender, DataGridViewCellEventArgs e ) {
			object value = ConfGrid.Rows[ e.RowIndex ].Cells[ e.ColumnIndex ].Value;
			int i = (int)ConfGrid.Rows[ e.RowIndex ].Tag;
			switch( e.ColumnIndex ) {
				case 0:
					mFiles[ mSelectedFile ].Configs[ i ].Name = (string)value;
					SetStatus( mFiles[ mSelectedFile ].Configs[ i ].Name + ": der Name wurde zu '" + (string)value + "' geändert" );
					break;
				case 1:
					mFiles[ mSelectedFile ].Configs[ i ].Value = value;
					SetStatus( mFiles[ mSelectedFile ].Configs[ i ].Name +": Einstellung `" + mFiles[ mSelectedFile ].Configs[ i ].Value + "` wurde zu '" + value + "' geändert" );
					break;
			}
		}

		private void ConfGrid_UserAddedRow( object sender, DataGridViewRowEventArgs e ) {
			EathenaConfig conf = new EathenaConfig();
			conf.Name = (string)e.Row.Cells[ 0 ].Value;
			conf.Value = (string)e.Row.Cells[ 1 ].Value;
			mFiles[ mSelectedFile ].Configs.Add( conf );

			SetStatus( "Einstellung `" + conf.Name + "` : '" + conf.Value + "' wurde hinzugefügt" );
		}

		private void ConfGrid_UserDeletedRow( object sender, DataGridViewRowEventArgs e ) {
			MessageBoxEx.Show( "... nich nicht implementiert" );
		} 
		#endregion

		private void btnClose_Click( object sender, EventArgs e ) {
			if( chkSettingSaveOnExit.Checked == true )
				btnSave_Click( null, EventArgs.Empty );
			this.Close();
		}
		private void btnSave_Click( object sender, EventArgs e ) {
			foreach( string key in mFiles.Keys )
				mFiles[ key ].ToFile( chkSettingBackup.Checked );

			MessageBoxEx.Show( "Alle Datein wurden gespeichert!" );
		}




		private bool LoadSettings() {
			string path = Properties.Settings.Default.ConfigDirectory;
			mBaseColorScheme = Properties.Settings.Default.GUITheme;
			chkSettingSaveOnExit.Checked = Properties.Settings.Default.SaveOnExit;
			chkSettingComments.Checked = Properties.Settings.Default.ShowComments;
			chkSettingBackup.Checked = Properties.Settings.Default.CreateBackup;

			do {
				// is <path> valid?
				if( path.IsNullOrEmpty() || System.IO.Directory.Exists( path ) == false ) {
					FolderBrowserDialog dlg = new FolderBrowserDialog();
					dlg.Description = "Bitte wähle deinen eAthena Config Ordner aus!\nz.B.: C:/eAthena/conf/";
					if( dlg.ShowDialog() != DialogResult.OK ) {
						path = string.Empty; // let the rest know what he did...
						break;
					}

					string[] pathParts = dlg.SelectedPath.Split( new char[] { '\\' } );
					if( pathParts.Length == 0 || pathParts[ pathParts.Length - 1 ].ToLower() != "conf" ) {
						path = string.Empty;
						Tools.Error( "Fehler im Pfad", "Dein angegebener Pfad is ungültig!\nDu musst einen eAthena Config Ordner auswählen!\n\nz.B.: C:/eAthena/conf/" );
						continue;
					}

					// he selected a Dir!
					path = dlg.SelectedPath;
				}

				// searching for Files in the dir
				if( path != string.Empty )
					mFiles = ConfParser.Load( path );

				if( mFiles != null && mFiles.Count > 0 ) // found some, break out!
					break;

				// nothing found, continue?
				if( MessageBoxEx.Show( "Es wurden keine Config Datein in dem Ordner gefunden!\nBitte wähle den richtigen Ordner aus!\n\nBeispiel: C:/eAthena/conf/\n\n\nMöchtest du es nochmal versuchen?", "Config Fehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error ) == DialogResult.Cancel )
					break;

				// reset if we continue so the first check show us the Dialog again
				path = string.Empty;
			} while( true );

			if( mFiles.Count == 0 ) // breaked out, no continue :/
				return false;

			// all valid, save the dir 
			if( path != Properties.Settings.Default.ConfigDirectory )
				Properties.Settings.Default.ConfigDirectory = path;

			return true;
		}
		private void FillGrid( string ArrayKey ) {
			if( mFiles.ContainsKey( ArrayKey ) == false )
				return;

			Tools.FillGrid( ref ConfGrid, ref comboSettingSearch, mFiles[ ArrayKey ], chkSettingComments.Checked );
		}

		public void SetStatus( string Status, Color StatusColor ) {
			lblStatus.ForeColor = StatusColor;
			lblStatus.Text = Status;
		}
		public void SetStatus( string Status ) {
			SetStatus( Status, Color.DarkGreen );
		}

	}

}
