using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;

namespace eACGUI {
	public partial class frmMerge : Office2007Form {
		private EathenaConfigFileCollection mFilesMy;
		private EathenaConfigFileCollection mFilesExtern;
		private string mSelectedFileMy;
		private string mSelectedFileExtern;

		public EathenaConfigFileCollection Files {
			get { return mFilesMy; }
		}


		public frmMerge( EathenaConfigFileCollection Files ) {
			mFilesMy = Files;
			InitializeComponent();
		}

		private void frmMerge_Load( object sender, EventArgs e ) {
			DevComponents.Editors.ComboItem item;
			foreach( string key in mFilesMy.Keys ) {
				item = new DevComponents.Editors.ComboItem();
				item.TextAlignment = StringAlignment.Near;
				item.Text = key;
				comboFiles.Items.Add( item );
			}
		}

		private void comboFiles_SelectedIndexChanged( object sender, EventArgs e ) {
			string key = comboFiles.SelectedItem.ToString();
			if( key == null )
				return;

			mSelectedFileMy = mSelectedFileExtern = key;
			if( mFilesMy.ContainsKey( key ) == true )
				Tools.FillGrid( ref ConfGridMy, mFilesMy[ key ], true );

			if( mFilesExtern != null && mFilesExtern.ContainsKey( key ) == true )
				Tools.FillGrid( ref ConfGridExtern, mFilesExtern[ key ], true );

			// highlight Grid
			ParseGrids();
		}

		private void comboChanges_SelectedIndexChanged( object sender, EventArgs e ) {
			string SearchValue = comboChanges.SelectedItem.ToString();
			int i;
			for( i = 0; i < ConfGridMy.Rows.Count; i++ )
				if( (string)ConfGridMy.Rows[ i ].Cells[ 0 ].Value == SearchValue )
					break;

			if( i >= ConfGridMy.Rows.Count ) {
				Tools.Error( "Fehler beim Suchen", "Eintrag im Grid nicht gefunden!" );
				return;
			}

			ConfGridMy.FirstDisplayedScrollingRowIndex = i;
			if( ConfGridExtern.RowCount < i )
				ConfGridExtern.FirstDisplayedScrollingRowIndex = i;
		}

		private void btnChangeUP_Click( object sender, EventArgs e ) {
			if( comboChanges.Items.Count == 0 )
				return;
			if( comboChanges.SelectedIndex == 0 )
				return;

			comboChanges.SelectedIndex--;
		}
		private void btnChangeDOWN_Click( object sender, EventArgs e ) {
			if( comboChanges.Items.Count == 0 )
				return;
			if( ( comboChanges.SelectedIndex + 1 ) >= comboChanges.Items.Count )
				return;

			comboChanges.SelectedIndex++;
		}




		private void btnConfImport_Click( object sender, EventArgs e ) {
			string path = string.Empty;
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "eACGUI XML Export (*.xml)|*.xml";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			mFilesExtern = new EathenaConfigFileCollectionSerializeable().Import( dlg.FileName );
			if( mFilesExtern == null ) {
				Tools.Error( "Fehler beim Importieren", "Das Importieren der Datei ist fehlgeschlagen!\nFalls dies öfter vorkommt, wende dich an GodLesZ!" );
				return;
			}

			DevComponents.Editors.ComboItem item;
			foreach( string key in mFilesMy.Keys )
				if( comboFiles.Items.Contains( key ) == false ) {
					item = new DevComponents.Editors.ComboItem();
					item.TextAlignment = StringAlignment.Far;
					item.Text = key;
					comboFiles.Items.Add( item );
				}

			if( comboFiles.SelectedIndex != -1 )
				comboFiles_SelectedIndexChanged( null, EventArgs.Empty ); // try to select in both Combo's the same File

			Tools.Info( "Import erfolgreich Abgeschlossen", "Der Config Import wurde erfolgreich abgeschlossen!\nDu kannst die importieren Datein nun in der rechten DropDown Box auswählen." );
		}
		private void btnConfWeb_Click( object sender, EventArgs e ) {
			Tools.Info( "Moep", "ToDo ^.^" );
		}

		private void btnSave_Click( object sender, EventArgs e ) {
			if( mFilesExtern.Count == 0 )
				return;

		}
		private void btnClose_Click( object sender, EventArgs e ) {
			this.Hide();
		}

		private void ConfGridMy_Scroll( object sender, ScrollEventArgs e ) {
			if( ConfGridExtern.RowCount == 0 || ConfGridExtern.RowCount < ConfGridMy.FirstDisplayedScrollingRowIndex )
				return;
			if( e.ScrollOrientation == ScrollOrientation.VerticalScroll )
				ConfGridExtern.FirstDisplayedScrollingRowIndex = ConfGridMy.FirstDisplayedScrollingRowIndex;
			else
				ConfGridExtern.FirstDisplayedScrollingColumnIndex = ConfGridMy.FirstDisplayedScrollingColumnIndex;
		}
		private void ConfGridExtern_Scroll( object sender, ScrollEventArgs e ) {
			if( ConfGridMy.RowCount == 0 || ConfGridMy.RowCount < ConfGridMy.FirstDisplayedScrollingRowIndex )
				return;
			if( e.ScrollOrientation == ScrollOrientation.VerticalScroll )
				ConfGridMy.FirstDisplayedScrollingRowIndex = ConfGridExtern.FirstDisplayedScrollingRowIndex;
			else
				ConfGridMy.FirstDisplayedScrollingColumnIndex = ConfGridExtern.FirstDisplayedScrollingColumnIndex;
		}

		private void ConfGridMy_CellEndEdit( object sender, DataGridViewCellEventArgs e ) {
			object value = ConfGridMy.Rows[ e.RowIndex ].Cells[ e.ColumnIndex ].Value;
			int i = (int)ConfGridMy.Rows[ e.RowIndex ].Tag;
			switch( e.ColumnIndex ) {
				case 0:
					mFilesMy.Files[ mSelectedFileMy ].Configs[ i ].Name = (string)value;
					break;
				case 1:
					mFilesMy.Files[ mSelectedFileMy ].Configs[ i ].Value = value;
					break;
			}

			//Color col = Color.Empty;
			//int ret = MergeHelper.Compare( ref ConfGridMy, ref ConfGridExtern, e.RowIndex, e.ColumnIndex, ref col );
			ParseGrids();
		}
		private void ConfGridExtern_CellEndEdit( object sender, DataGridViewCellEventArgs e ) {
			object value = ConfGridExtern.Rows[ e.RowIndex ].Cells[ e.ColumnIndex ].Value;
			int i = (int)ConfGridExtern.Rows[ e.RowIndex ].Tag;
			switch( e.ColumnIndex ) {
				case 0:
					mFilesExtern.Files[ mSelectedFileExtern ].Configs[ i ].Name = (string)value;
					break;
				case 1:
					mFilesExtern.Files[ mSelectedFileExtern ].Configs[ i ].Value = value;
					break;
			}

			//Color col = Color.Empty;
			//MergeHelper.Compare( ref ConfGridExtern, ref ConfGridMy, e.RowIndex, e.ColumnIndex, ref col );
			ParseGrids();
		}



		/// <summary>
		/// Lighted all Lines based on the Equal's state
		/// <para><see cref="Color.LightCyan"/> if one Side is null or the other Side has not enoght Rows</para>
		/// <para><see cref="Color.LightSalmon"/> if the do not match</para>
		/// </summary>
		private void ParseGrids() {
			int changedGrid = 0;
			comboChanges.Items.Clear();

			if( ConfGridExtern.RowCount == 0 ) // no conf loaded yet
				return;

			// firsr check my Settings
			Color col = Color.Empty;
			DevComponents.Editors.ComboItem item;
			for( int i = 0; i < ConfGridMy.RowCount; i++ ) {
				changedGrid = MergeHelper.Compare( ref ConfGridMy, ref ConfGridExtern, i, 1, ref col );
				if( col == Color.Empty ) // nothing lighted
					continue;

				item = new DevComponents.Editors.ComboItem();
				item.BackColor = col;
				if( changedGrid == 1 ) {
					item.TextAlignment = StringAlignment.Near;
					item.Text = (string)ConfGridMy.Rows[ i ].Cells[ 0 ].Value;
					comboChanges.Items.Add( item );
				} else if( changedGrid == 2 ) {
					item.TextAlignment = StringAlignment.Far;
					item.Text = (string)ConfGridExtern.Rows[ i ].Cells[ 0 ].Value;
					comboChanges.Items.Add( item );
				} else if( changedGrid == 3 ) {
					item.TextAlignment = StringAlignment.Center;
					item.Text = (string)ConfGridMy.Rows[ i ].Cells[ 0 ].Value;
					comboChanges.Items.Add( item );
				}
			}

			// has the Target more Settings? Light them
			if( ConfGridExtern.RowCount > ConfGridMy.RowCount )
				for( int i = ConfGridMy.RowCount; i < ConfGridExtern.RowCount; i++ ) {
					if( ConfGridExtern.Rows[ i ].Cells[ 1 ] == null ) // comment
						continue;
					ConfGridExtern.Rows[ i ].DefaultCellStyle.BackColor = Color.LightCyan;
					
					item = new DevComponents.Editors.ComboItem();
					item.BackColor = Color.LightCyan;
					item.TextAlignment = StringAlignment.Far;
					item.Text = (string)ConfGridExtern.Rows[ i ].Cells[ 0 ].Value;
					comboChanges.Items.Add( item );
				}

		}

	}

}
