using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using ShaiyaMonsterMap.Structs;
using ShaiyaMonsterMap.Helper;
using ShaiyaMonsterMap.Enumerations;
using ShaiyaMonsterMap.Forms;
using ShaiyaMonsterMap.Components;

namespace ShaiyaMonsterMap {

	public partial class frmMain : Form {
		public static string CursorRessource = "ShaiyaMonsterMap.Resources.Shaiya.png";
		public static Cursor ShaiyaCursor;

		public FactoryMobPoint MobFactory;

		private System.Reflection.Assembly mAssembly;

		private List<int> mMarkedMobs = new List<int>();
		private List<int> mMarkedQuests = new List<int>();
		private ListViewColumnSorter mListViewColumnSorter = new ListViewColumnSorter();
		private string mOldTitle = string.Empty;


		public frmMain() {
			InitializeComponent();

			mAssembly = System.Reflection.Assembly.GetExecutingAssembly();

			System.Reflection.AssemblyName asmName = mAssembly.GetName();
			this.Text += " v" + string.Format( "{0}.{1}.{2}.{3}", asmName.Version.Major, asmName.Version.Minor, asmName.Version.Build, asmName.Version.Revision );
			this.Text += " - by GodLesZ & r0xy.";
		}


		#region Initialize
		public bool InitializeSQL() {
			//FactoryMain.Password = "EbMw9cTmgZvtUIv66oNAiw==";
			if( FactoryMain.Initialize() == false ) {
				HelperMsg.Error( "Fehler beim öffnen der MySQL Verbindung!\nDies kann verschiedene Ursachen haben.\nSollte das Problem längerfristig bestehen, kontaktiere GodLesZ.", "SQL Fehler" );
				return false;
			}

			using( frmLogin frm = new frmLogin( FactoryMain.Mysql ) ) {
				frm.ShowDialog();
				MapControl.CanEdit = frm.HasAccess;
			}

			// disable menu Buttons
			if( MapControl.CanEdit == false ) {
				MenuProgrammSave.Enabled = false;
				MenuProgrammLocalBackup.Enabled = false;

				MenuProgrammSave.Visible = false;
				MenuProgrammLocalBackup.Visible = false;
				MenuProgrammSep2.Visible = false;
			}

			return true;
		}
		public void InitializeMaps() {

		}
		public void InitializeCursor() {
			this.Cursor = frmMain.ShaiyaCursor = Native.GetCursor( frmMain.CursorRessource, mAssembly );
		}
		#endregion



		#region Form Events
		private void frmMain_Shown( object sender, EventArgs e ) {
			InitializeCursor();
			if( InitializeSQL() == false ) {
				this.Close();
				return;
			}

			InitializeMaps();

			mobMap6.cmbMap.Items.AddRange( new object[]{
				EMap.PvP_1.ToName(),
				EMap.PvP_2.ToName(),
				EMap.PvP_3.ToName(),
			} );
			btnFractionLight.PerformClick();
			mobMap6.cmbMap.SelectedIndex = 0;
		}

		private void frmMain_FormClosing( object sender, FormClosingEventArgs e ) {
			MapControl.DeinitializeAll();

			Properties.Settings.Default.Save();
		}

		private void frmMain_KeyUp( object sender, KeyEventArgs e ) {
			if( ( e.Modifiers & Keys.Control ) != Keys.Control )
				return;

			switch( e.KeyCode ) {
				case Keys.Up:
				case Keys.Down:
				case Keys.Left:
				case Keys.Right:
					int index = tabMain.SelectedIndex + 1;
					if( tabMain.SelectedIndex < 4 )
						e.Handled = ( tabMain.SelectedTab.Controls[ "mobMap" + index ] as MapControl ).MoveMobPoints( e.KeyCode );
					else
						e.Handled = ( tabMain.SelectedTab.Controls[ "mobMap" + index ] as MapControlSelector ).MoveMobPoints( e.KeyCode );
					break;
			}
		}
		#endregion

		#region Menu Programm Events
		private void MenuProgrammExit_Click( object sender, EventArgs e ) {
			this.Close();
		}

		private void MenuProgrammSave_Click( object sender, EventArgs e ) {
			if( MapControl.CanEdit == false )
				return;

			MapControl.RefreshAll();
		}

		private void MenuProgrammLocalBackup_Click( object sender, EventArgs e ) {
			MapControl.CreateBackupAll();
		}
		#endregion

		#region Menu Bearbeiten Events
		private void MenuProgrammReload_Click( object sender, EventArgs e ) {
			if( MapControl.CanEdit == true && HelperMsg.Ask( "Alle Änderungen gehen dadurch verloren!\n\nListe aktualisiern/neuladen?", "Änderungen gehen verloren!" ) == false )
				return;

			MapControl.RefreshAll();
		}
		#endregion

		#region Menu Einstellung Events
		private void MenuSettingShowName_Click( object sender, EventArgs e ) {
			Properties.Settings.Default.ShowName = MenuSettingShowName.Checked;
			MapControl.InvalidateAll();
		}

		private void MenuSettingMarkedStandAlone_Click( object sender, EventArgs e ) {
			Properties.Settings.Default.MarkedStandAlone = MenuSettingMarkedStandAlone.Checked;
			MapControl.InvalidateAll();
		}
		#endregion

		#region Menu About Events
		private void MenuAbout_Click( object sender, EventArgs e ) {
			using( frmAbout frm = new frmAbout() )
				frm.ShowDialog();
		} 
		#endregion

		#region ToolStrip Events
		private void btnFractionLight_Click( object sender, EventArgs e ) {
			if( btnFractionLight.Checked == true )
				return;

			btnFractionDark.Checked = false;
			btnFractionLight.Checked = true;
			SetFraction( true );
		}

		private void btnFractionDark_Click( object sender, EventArgs e ) {
			if( btnFractionDark.Checked == true )
				return;

			btnFractionLight.Checked = false;
			btnFractionDark.Checked = true;
			SetFraction( false );
		}
		#endregion

		private void tabMain_SelectedIndexChanged( object sender, EventArgs e ) {
			if( tabMain.SelectedIndex != tabMain.TabCount - 1 )
				return;
			// last Tab = MobSearch, focus input
			txtMobSearch.Focus();
		}

		#region Monstersuche Events
		private void listSearchResult_DrawSubItem( object sender, DrawListViewSubItemEventArgs e ) {
			// draw Element
			if( e.ColumnIndex != 2 ) {
				e.DrawDefault = true;
				return;
			}

			SMobPointEx p = e.Item.Tag as SMobPointEx;
			if( p.Element == EMobElement.Unbekannt ) {
				e.DrawDefault = true;
				return;
			}

			if( listSearchResult.SelectedIndices.Contains( e.ItemIndex ) )
				e.Graphics.FillRectangle( Brushes.RoyalBlue, e.Bounds );
			using( Image img = p.Element.ToImage() ) {
				e.Graphics.DrawImage( img, new Rectangle( e.Bounds.X + ( e.Bounds.Width / 2 ) - img.Width / 2, e.Bounds.Y + ( e.Bounds.Height / 2 ) - img.Height / 2, img.Width, img.Height ) );
			}
		}

		private void listSearchResult_DrawColumnHeader( object sender, DrawListViewColumnHeaderEventArgs e ) {
			e.DrawDefault = true;
		}

		private void btnMobSearch_Click( object sender, EventArgs e ) {
			listSearchResult.Items.Clear();

			string mobName = txtMobSearch.Text.ToLower();
			List<SMobPointEx> points = new List<SMobPointEx>();

			points.AddRange( SearchMob( mobName, 0, mobMap1 ) );
			points.AddRange( SearchMob( mobName, 1, mobMap2 ) );
			points.AddRange( SearchMob( mobName, 2, mobMap3 ) );
			points.AddRange( SearchMob( mobName, 3, mobMap4 ) );
			points.AddRange( SearchMob( mobName, 4, mobMap5 ) );
			points.AddRange( SearchMob( mobName, 5, mobMap6 ) );

			for( int i = 0; i < points.Count; i++ ) {
				SMobPointEx p = points[ i ];
				ListViewItem item = new ListViewItem( new string[] { p.Name, p.Level, p.Element.ToName( true ), p.Anzahl, p.Mapname } );
				item.Tag = points[ i ];
				item.ToolTipText = string.Format( "{0} ({1}) | {2} [{3}]", p.Name, p.Level, p.Element, p.Anzahl );
				if( p.MapControl != null )
					item.ImageIndex = p.RuleLevelToIndex( p.MapControl.Factory );
				else
					item.ImageIndex = p.RuleLevelToIndex( p.MapControlSelector.Factory );

				listSearchResult.Items.Add( item );
			}
		}

		private void listSearchResult_DoubleClick( object sender, EventArgs e ) {
			if( listSearchResult.SelectedItems.Count == 0 )
				return;

			SMobPointEx p = listSearchResult.SelectedItems[ 0 ].Tag as SMobPointEx;
			if( p.MapControl != null )
				p.MapControl.SelectPoint( p as SMobPoint, true );
			else
				p.MapControlSelector.SelectPoint( p as SMobPoint, true );

			tabMain.SelectedIndex = p.TabIndex;
		}
		#endregion


		#region Helper
		public void SetFraction( bool Light ) {
			if( Light == true ) {
				pageMap1.Text = "Map 1 - Erina";
				pageMap2.Text = "Map 2 - Willieoseu";
				pageMap3.Text = "Map 3 - Adellia";
				pageMap4.Text = "Map 4 - Skulleron";
				mobMap1.InitializeMap( EMap.Erina.ToName() );
				mobMap2.InitializeMap( EMap.Willieoseu.ToName() );
				mobMap3.InitializeMap( EMap.Adellia.ToName() );
				mobMap4.InitializeMap( EMap.Skulleron.ToName() );

				mobMap5.cmbMap.Items.Clear();
				mobMap5.cmbMap.Items.AddRange( new object[]{
					EMap.Cornwell.ToName(),
					EMap.Senechios.ToName(),
					EMap.Colorons_1.ToName(),
					EMap.Colorons_2.ToName(),
					EMap.Colorons_3.ToName(),
					EMap.ElementHöhle.ToName(),
					EMap.Maitrevan_1.ToName(),
					EMap.Maitrevan_2.ToName(),
					EMap.Sigmas.ToName()
				} );
				mobMap5.cmbMap.SelectedIndex = 0;
				
				return;
			}

			// Dark
			pageMap1.Text = "Map 1 - Reikeuseu";
			pageMap2.Text = "Map 2 - Keuraijen";
			pageMap3.Text = "Map 3 - Adeurian";
			pageMap4.Text = "Map 4 - Astenes";
			mobMap1.InitializeMap( EMap.Reikeuseu.ToName() );
			mobMap2.InitializeMap( EMap.Keuraijen.ToName() );
			mobMap3.InitializeMap( EMap.Adeurian.ToName() );
			mobMap4.InitializeMap( EMap.Astenes.ToName() );

			mobMap5.cmbMap.Items.Clear();
			mobMap5.cmbMap.Items.AddRange( new object[]{
				EMap.Argilla.ToName(),
				EMap.Fantasmas_1.ToName(),
				EMap.Fantasmas_2.ToName(),
				EMap.Fantasmas_3.ToName(),
				EMap.Kalamus_Anwesen.ToName(),
				EMap.Aidion_Neckria_1.ToName(),
				EMap.Aidion_Neckria_2.ToName(),
				EMap.RuberChaos.ToName(),
				EMap.Aurizen.ToName()
			} );
			mobMap5.cmbMap.SelectedIndex = 0;
		}

		public void SetTitle( string Mapname ) {
			string title = string.Empty;
			if( mOldTitle == string.Empty )
				mOldTitle = this.Text;

			title = mOldTitle;
			if( MapControl.CanEdit == true )
				title += " (Admin Mode)";
			else
				title += " (User Mode)";
			title += " - " + Mapname;

			this.Text = title;
		}

		public void SetStatus( string Text ) {
			SetStatus( Text, Color.DarkGreen );
		}

		public void SetStatus( string Text, Color ForeColor ) {
			lblStatus.Text = Text;
			lblStatus.ForeColor = ForeColor;
		}

		public List<SMobPointEx> SearchMob( string Mobname, int TabIndex, MapControl Map ) {
			List<SMobPointEx> list = new List<SMobPointEx>();
			SMobPoint p;
			for( int i = 0; i < Map.MobPoints.Count; i++ ) {
				p = Map.MobPoints[ i ] as SMobPoint;
				if( p == null || p.Name.ToLower().Contains( Mobname ) == false )
					continue;

				SMobPointEx newPoint = SMobPointEx.FromPoint( p );
				newPoint.MapControl = Map;
				newPoint.Mapname = Map.Mapname;
				newPoint.TabIndex = TabIndex;
				list.Add( newPoint );
			}

			return list;
		}

		public List<SMobPointEx> SearchMob( string Mobname, int TabIndex, MapControlSelector Map ) {
			List<SMobPointEx> list = new List<SMobPointEx>();
			SMobPoint p;
			for( int i = 0; i < Map.MobPoints.Count; i++ ) {
				p = Map.MobPoints[ i ] as SMobPoint;
				if( p == null || p.Name.ToLower().Contains( Mobname ) == false )
					continue;

				SMobPointEx newPoint = SMobPointEx.FromPoint( p );
				newPoint.MapControlSelector = Map;
				newPoint.Mapname = Map.Mapname;
				newPoint.TabIndex = TabIndex;
				list.Add( newPoint );
			}

			return list;
		}
		#endregion

	}


}
