using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions;

using FinalSoftware.MySql;
using MarketTool.Library;
using System.IO;

namespace MarketTool.Application {

	public partial class frmMain : Form {
		public static frmMain Instance = null;

		private Assembly mAssembly;
		private string mUsername = "";
		private EItemType mCurrentType = EItemType.EtcItem;


		public frmMain() {
			frmMain.Instance = this;

			InitializeComponent();

			mAssembly = Assembly.GetExecutingAssembly();
			System.Reflection.AssemblyName asmName = mAssembly.GetName();
			this.Text += " v" + string.Format( "{0}.{1}.{2}.{3}", asmName.Version.Major, asmName.Version.Minor, asmName.Version.Build, asmName.Version.Revision );
			this.Text += " - by GodLesZ & r0xy.";
		}


		#region frmMain Events
		private void frmMain_Load( object sender, EventArgs e ) {
			if( SQLHelper.Initialize() == false ) {
				MessageBox.Show( "Fehler beim öffnen der MySQL Verbindung!\nDies kann verschiedene Ursachen haben.\nSollte das Problem längerfristig bestehen, kontaktiere GodLesZ.", "SQL Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
				this.Close();
				return;
			}

			frmLogin frm = new frmLogin( SQLHelper.Mysql );
			frm.ShowDialog();
			if( frm.HasAccess == false ) {
				this.Close();
				return;
			}

			mUsername = HelperCrypt.Decrypt( Properties.Settings.Default.Username ).MysqlEscape();
			LoadIcons();
			LoadTemplates();
			SetAllSockel( false );
			cmbType.SelectedIndex = 0;

			foreach( string q in QualityComboBox.Qualitys )
				cmbQuality.Items.Add( q );
			cmbQuality.SelectedIndex = 1;
			cmbQuality.SelectedIndex = 0;
			cmbASPD.SelectedIndex = 3;

			cmbFraction.SelectedIndex = 0;
			cmbItemIcon.SelectedIndex = 0;
		}

		private void frmMain_FormClosing( object sender, FormClosingEventArgs e ) {
			Properties.Settings.Default.Save();
		}
		#endregion

		#region MenuProgram Events
		private void MenuProgramClose_Click( object sender, EventArgs e ) {
			this.Close();
		}
		#endregion

		#region MenuTemplates Events
		private void MenuTemplatesSave_Click( object sender, EventArgs e ) {
			string itemname = txtName.Text;

			if( cmbType.SelectedIndex == 2 ) // Lapis name
				itemname = ( ( cmbLapi.SelectedItem as ImageComboItem ).Tag as Lapi ).Name;
			else if( cmbType.SelectedIndex == 3 ) // Lapisa name
				itemname = ( (ELapisa)cmbLapisa.SelectedIndex ).ToString();

			if( itemname == "" ) {
				MessageBox.Show( "Dein Item muss einen Namen haben um das Template zu speichern!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
				return;
			}

			ITemplate tpl = BuildTemplate();
			TemplateBuilder.SaveTemplate( tpl, (EItemType)cmbType.SelectedIndex );
			LoadTemplates(); // refresh
		}

		private void MenuTemplatesReload_Click( object sender, EventArgs e ) {
			LoadTemplates(); // will clear & reload
		}
		#endregion

		#region MenuAbout Events
		private void aboutToolStripMenuItem_Click( object sender, EventArgs e ) {
			using( frmAbout frm = new frmAbout() )
				frm.ShowDialog();
		} 
		#endregion

		#region Combobox Events
		private void cmbType_SelectedIndexChanged( object sender, EventArgs e ) {
			EItemType newType = (EItemType)cmbType.SelectedIndex;
			if( mCurrentType == newType )
				return;

			mCurrentType = newType;
			MenuTemplatesSave.Enabled = ( mCurrentType != EItemType.Lapisa );
			switch( mCurrentType ) {
				case EItemType.Waffe:
					LoadAutoComplete( mCurrentType );
					SetTypeWeapon();
					break;
				case EItemType.Rüstung:
					LoadAutoComplete( mCurrentType );
					SetTypeArmor();
					break;
				case EItemType.Lapis:
					SetTypeLapi();
					break;
				case EItemType.Lapisa:
					SetTypeLapisa();
					break;
				case EItemType.APItem:
					LoadAutoComplete( mCurrentType );
					SetTypeAP();
					break;
				case EItemType.EtcItem:
					LoadAutoComplete( mCurrentType );
					SetTypeEtc();
					break;
			}

		}

		private void cmbQuality_SelectedIndexChanged( object sender, EventArgs e ) {
			if( cmbQuality.SelectedIndex == 0 ) {
				SetAllSockel( false );
				return;
			}

			for( int i = 1; i < cmbQuality.SelectedIndex + 1; i++ )
				SetSockelVisible( i, true );
			for( int i = cmbQuality.SelectedIndex + 1; i < cmbQuality.Items.Count; i++ )
				SetSockelVisible( i, false );
		}
		#endregion

		#region Save & Reset
		private void btnReset_Click( object sender, EventArgs e ) {
			ResetGUI();
		}

		private void btnSave_Click( object sender, EventArgs e ) {
			SaveItem();
			LoadAutoComplete( (EItemType)cmbType.SelectedIndex ); // refresh Auto-complete

			if( MenuSettingsAskReset.Checked == true && MessageBox.Show( "Das Item wurde erfolgreich hinzugefügt!\n\nMöchtest du die Eingabemaske zurücksetzen?", "Item hinzugefügt", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes )
				ResetGUI();
		}
		#endregion


		private void ResetGUI() {
			cmbType.SelectedIndex = 0;
			cmbItemIcon.SelectedIndex = 0;
			cmbQuality.SelectedIndex = 0;
			txtName.Text = "";
			numEnchant.Value = 0;

			txtANG1.Text = "0";
			txtANG2.Text = "0";
			cmbASPD.SelectedIndex = 4; // normal
			txtHaltbarkeit.Text = "0";
			txtLP.Text = "0";
			txtMP.Text = "0";
			txtAP.Text = "0";
			txtGES.Text = "0";
			txtGLÜ.Text = "0";
			txtSTR.Text = "0";
			txtWEI.Text = "0";
			txtINT.Text = "0";
			txtABW.Text = "0";
			txtLPEP4.Text = "0";
			txtMPEP4.Text = "0";
			txtAPEP4.Text = "0";
			txtGESEP4.Text = "0";
			txtGLÜEP4.Text = "0";
			txtSTREP4.Text = "0";
			txtWEIEP4.Text = "0";
			txtINTEP4.Text = "0";
			txtABWEP4.Text = "0";
			txtResistenz.Text = "0";

			cmbSockel1.SelectedIndex = 0;
			cmbSockel2.SelectedIndex = 0;
			cmbSockel3.SelectedIndex = 0;
			cmbSockel4.SelectedIndex = 0;
			cmbSockel5.SelectedIndex = 0;
			cmbSockel6.SelectedIndex = 0;

			txtGold.SetGold( 0 );
			txtSeller.Text = "";
		}

		private void SaveItem() {
			string lapiChunk = CompileLapis();
			string statsChunk = CompileStats();
			string itemname = txtName.Text.MysqlEscape();
			string query;

			if( cmbType.SelectedIndex == 2 ) // Lapis name
				itemname = ( ( cmbLapi.SelectedItem as ImageComboItem ).Tag as Lapi ).Name;
			else if( cmbType.SelectedIndex == 3 ) // Lapisa name
				itemname = ( (ELapisa)cmbLapisa.SelectedIndex ).ToString();

			query = string.Format(
				"INSERT INTO `shaiya_price_db` "
				+ "(`name`, `type`, `enchant`, `lapi_chunk`, `stats_chunk`, `seller`, `add_user`, `add_price`, `add_server`, `add_fraction`, `add_date`, `clicks` ) VALUES "
				+ "( '{0}', {1}, {2}, '{3}', '{4}', '{5}', '{6}', {7}, 1, {8}, NOW(), 1 )",
				itemname, cmbType.SelectedIndex, ( cmbType.SelectedIndex < 2 ? (int)numEnchant.Value : 0 ), lapiChunk, statsChunk, txtSeller.Text.MysqlEscape(), mUsername, txtGold.GoldAmount, cmbFraction.SelectedIndex );

			if( SQLHelper.SendQuery( query ) == false )
				MessageBox.Show( SQLHelper.LastException, "MySQL Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error );
		}

		private string CompileLapis() {
			string chunk = "";

			for( int i = 1; i < cmbQuality.Items.Count; i++ ) {
				LapiImageComboBox cmb = Controls[ "cmbSockel" + i ] as LapiImageComboBox;
				ImageComboItem item = ( cmb.Items[ cmb.SelectedIndex ] as ImageComboItem );
				if( item == null ) {
					chunk += "-1:-1;";
					continue;
				}

				Lapi lapi = item.Tag as Lapi;
				if( lapi != null )
					chunk += lapi.ToImageIndex() + ":" + lapi.Level + ";";
				else // empty slot = type -1
					chunk += "-1:0;";
			}

			return chunk;
		}

		private string CompileStats() {
			string chunk = "";

			if( cmbType.SelectedIndex > 4 ) // kein Equip/Lapi/Lapisa/AP
				return chunk = (int)EStatusType.ItemIcon + ":" + ( cmbItemIcon.Items[ cmbItemIcon.SelectedIndex ] as ImageComboItem ).Text.Replace( ".png", "" ) + ";";

			if( cmbType.SelectedIndex == 2 ) { // Lapi
				Lapi l = ( cmbLapi.SelectedItem as ImageComboItem ).Tag as Lapi;
				chunk = (int)l.ToImageIndex() + ":" + l.Level;
				return chunk;
			}
			if( cmbType.SelectedIndex == 3 ) { // Lapisa
				chunk = cmbLapisa.SelectedIndex.ToString();
				return chunk;
			}
			if( cmbType.SelectedIndex == 4 ) { // APItem
				chunk = (int)EStatusType.ItemIcon + ":" + ( cmbItemIcon.Items[ cmbItemIcon.SelectedIndex ] as ImageComboItem ).Text.Replace( ".png", "" ) + ";";
				return chunk;
			}

			chunk = (int)EStatusType.Quality + ":" + cmbQuality.SelectedIndex + ";";
			chunk += (int)EStatusType.MinAngOrDef + ":" + txtANG1.Text + ";";
			if( cmbType.SelectedIndex == 0 ) { // Waffe
				chunk += (int)EStatusType.MaxAng + ":" + txtANG2.Text + ";";
				chunk += (int)EStatusType.AspdOrResist + ":" + cmbASPD.SelectedIndex + ";";
			} else // Rüstung
				chunk += (int)EStatusType.AspdOrResist + ":" + txtResistenz.Text + ";";
			chunk += (int)EStatusType.Haltbar + ":" + txtHaltbarkeit.Text + ";";
			chunk += (int)EStatusType.MaxLP + ":" + txtLP.Text + ";";
			chunk += (int)EStatusType.MaxMP + ":" + txtMP.Text + ";";
			chunk += (int)EStatusType.MaxAP + ":" + txtAP.Text + ";";
			chunk += (int)EStatusType.STR + ":" + txtSTR.Text + ";";
			chunk += (int)EStatusType.ABW + ":" + txtABW.Text + ";";
			chunk += (int)EStatusType.WEI + ":" + txtWEI.Text + ";";
			chunk += (int)EStatusType.INT + ":" + txtINT.Text + ";";
			chunk += (int)EStatusType.GES + ":" + txtGES.Text + ";";
			chunk += (int)EStatusType.GLÜ + ":" + txtGLÜ.Text + ";";
			chunk += (int)EStatusType.ItemIcon + ":" + ( cmbItemIcon.Items[ cmbItemIcon.SelectedIndex ] as ImageComboItem ).Text.Replace( ".png", "" ) + ";";
			chunk += (int)EStatusType.MaxLPEP4 + ":" + txtLPEP4.Text + ";";
			chunk += (int)EStatusType.MaxMPEP4 + ":" + txtMPEP4.Text + ";";
			chunk += (int)EStatusType.MaxAPEP4 + ":" + txtAPEP4.Text + ";";
			chunk += (int)EStatusType.STREP4 + ":" + txtSTREP4.Text + ";";
			chunk += (int)EStatusType.ABWEP4 + ":" + txtABWEP4.Text + ";";
			chunk += (int)EStatusType.WEIEP4 + ":" + txtWEIEP4.Text + ";";
			chunk += (int)EStatusType.INTEP4 + ":" + txtINTEP4.Text + ";";
			chunk += (int)EStatusType.GESEP4 + ":" + txtGESEP4.Text + ";";
			chunk += (int)EStatusType.GLÜEP4 + ":" + txtGLÜEP4.Text + ";";

			return chunk;
		}

		private void SetAllSockel( bool Visible ) {
			for( int i = 1; i < cmbQuality.Items.Count; i++ )
				SetSockelVisible( i, Visible );
			if( Visible == false || cmbType.SelectedIndex > 1 )
				return;
			for( int i = cmbQuality.SelectedIndex + 1; i < cmbQuality.Items.Count; i++ )
				SetSockelVisible( i, false );
		}

		private void SetSockelVisible( int Sockel, bool Visible ) {
			Controls[ "lblSockel" + Sockel ].Visible = Visible;
			if( Visible == false ) // reset it
				( Controls[ "cmbSockel" + Sockel ] as LapiImageComboBox ).SelectedIndex = 0;
			Controls[ "cmbSockel" + Sockel ].Visible = Visible;
		}

		private void SetEquipState( bool State ) {
			SetAllSockel( State );
			lblQuality.Visible =
			cmbQuality.Visible =
			cmbItemIcon.Visible =
			lblName.Visible =
			txtName.Visible =
			numEnchant.Visible =
			lblEnchant.Visible =
			numEnchant.Visible =
				State;

			txtANG1.Visible =
			txtANG2.Visible =
			cmbASPD.Visible =
			cmbLapi.Visible =
			cmbLapisa.Visible =
			txtResistenz.Visible =
			txtHaltbarkeit.Visible =
			txtLP.Visible =
			txtMP.Visible =
			txtAP.Visible =
			txtSTR.Visible =
			txtWEI.Visible =
			txtGES.Visible =
			txtGLÜ.Visible =
			txtABW.Visible =
			txtINT.Visible =
			lblANG.Visible =
			lblASPD.Visible =
			lblHalt.Visible =
			lblLP.Visible =
			lblMP.Visible =
			lblAP.Visible =
			lblSTR.Visible =
			lblWEI.Visible =
			lblGES.Visible =
			lblGLÜ.Visible =
			lblABW.Visible =
			lblINT.Visible =
			txtLPEP4.Visible =
			txtMPEP4.Visible =
			txtAPEP4.Visible =
			txtSTREP4.Visible =
			txtWEIEP4.Visible =
			txtGESEP4.Visible =
			txtGLÜEP4.Visible =
			txtABWEP4.Visible =
			txtINTEP4.Visible =
			lblLPEP4.Visible =
			lblMPEP4.Visible =
			lblAPEP4.Visible =
			lblSTREP4.Visible =
			lblWEIEP4.Visible =
			lblGESEP4.Visible =
			lblGLÜEP4.Visible =
			lblABWEP4.Visible =
			lblINTEP4.Visible =
				State;
		}

		private void LoadAutoComplete( EItemType type ) {
			AutoCompleteStringCollection col = new AutoCompleteStringCollection();
			ResultTable tpl;
			if( SQLHelper.SendQuery( "SELECT `name` FROM `shaiya_price_db` WHERE `type` = " + (int)type, out tpl ) == false || tpl == null )
				return;
			for( int i = 0; i < tpl.Rows.Count; i++ )
				col.Add( tpl[ i ][ "name" ].GetString() );

			txtName.AutoCompleteCustomSource = col;
		}

		private void LoadIcons() {
			Assembly asm = Assembly.GetAssembly( typeof( EItemType ) );
			List<string> ResList = new List<string>( asm.GetManifestResourceNames() );
			ResList.Sort(
				new Comparison<string>(
					delegate( string s1, string s2 ) {
						int i1 = 0, i2 = 0;
						if( s1.StartsWith( "MarketTool.Library.Icons." ) == false || s2.StartsWith( "MarketTool.Library.Icons." ) == false )
							return 0;

						s1 = s1.Replace( "MarketTool.Library.Icons.", "" );
						s2 = s2.Replace( "MarketTool.Library.Icons.", "" );
						if( s1.StartsWith( "Armor." ) || s1.StartsWith( "Weapon." ) ) {
							s1 = Regex.Replace( s1, @"[^\.]+\.Icon_[0-9]+_([0-9]+)\.png", "$1" );
							i1 = int.Parse( s1 );
						} else if( s1.Contains( ".icon-" ) )
							i1 = int.Parse( Regex.Replace( s1, @"[^\.]+\.icon-([0-9]+)\.png", "$1" ) );

						if( s2.StartsWith( "Armor." ) || s2.StartsWith( "Weapon." ) ) {
							s2 = Regex.Replace( s2, @"[^\.]+\.Icon_[0-9]+_([0-9]+)\.png", "$1" );
							i2 = int.Parse( s2 );
						} else if( s2.Contains( ".icon-" ) )
							i2 = int.Parse( Regex.Replace( s2, @"[^\.]+\.icon-([0-9]+)\.png", "$1" ) );

						return i1.CompareTo( i2 );
					}
				)
			);

			listLapis.Images.Add( "slot_empty.png", Image.FromStream( asm.GetManifestResourceStream( "MarketTool.Library.Icons.slot_empty.png" ) ) );
			for( int i = 0; i < ResList.Count; i++ ) {
				// MarketTool.Library.Icons.Weapon.Icon_15_240.png
				string res = ResList[ i ];
				if( res.StartsWith( "MarketTool.Library.Icons." ) == false )
					continue;

				string cleanRes = res.Replace( "MarketTool.Library.Icons.", "" );
				if( cleanRes.StartsWith( "AP." ) == true )
					listAPItem.Images.Add( cleanRes.Substring( 3 ), Image.FromStream( asm.GetManifestResourceStream( res ) ) );
				else if( cleanRes.StartsWith( "Armor." ) == true )
					listArmor.Images.Add( cleanRes.Substring( 6 ), Image.FromStream( asm.GetManifestResourceStream( res ) ) );
				else if( cleanRes.StartsWith( "ETC." ) == true )
					listEtcItem.Images.Add( cleanRes.Substring( 4 ), Image.FromStream( asm.GetManifestResourceStream( res ) ) );
				else if( cleanRes.StartsWith( "Lapis." ) == true )
					listLapis.Images.Add( cleanRes.Substring( 6 ), Image.FromStream( asm.GetManifestResourceStream( res ) ) );
				else if( cleanRes.StartsWith( "Lapisa." ) == true )
					listLapisa.Images.Add( cleanRes.Substring( 7 ), Image.FromStream( asm.GetManifestResourceStream( res ) ) );
				else if( cleanRes.StartsWith( "Weapon." ) == true )
					listWeapon.Images.Add( cleanRes.Substring( 7 ), Image.FromStream( asm.GetManifestResourceStream( res ) ) );
			}
		}

		#region Template Managment
		private void LoadTemplates() {
			TemplateBuilder.Initialize();
			TemplateBuilder.LoadTemplates( TemplateItem_Click, TemplateItem_OnAdd, MenuTemplatesWeapon, MenuTemplatesArmor, MenuTemplatesLapi, MenuTemplatesAPItem, MenuTemplatesETCItem );
		}

		private void TemplateItem_Click( object sender, EventArgs e ) {
			ToolStripMenuItem item = sender as ToolStripMenuItem;
			ITemplate tpl = TemplateBuilder.GetTemplate( item.Tag as string );
			if( tpl == null ) {
				( item.OwnerItem as ToolStripMenuItem ).DropDownItems.Remove( item );
				MessageBox.Show( "Das Template konnte nicht geladen werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
				return;
			}

			ApplyTemplate( tpl );
		}

		private ToolStripMenuItem TemplateItem_OnAdd( ITemplate Template, ToolStripMenuItem Item ) {
			EItemType type = (EItemType)Template.cmbType;
			if( type != EItemType.Lapis && type != EItemType.Lapisa )
				Item.Image = GetTemplateItemImage( type, Template.cmbItemIcon );
			else if( type == EItemType.Lapis ) {
				Lapi l = new Lapi( Template.LapisType, Template.LapisLevel );
				Item.Image = GetTemplateItemImage( type, l.ToImageIndex() + 1 ); // 0 = free slot
			} else if( type == EItemType.Lapisa )
				Item.Image = GetTemplateItemImage( type, Template.cmbLapisa );
			return Item;
		}

		private void ApplyTemplate( ITemplate tpl ) {
			EItemType type = (EItemType)tpl.cmbType;

			cmbType.SelectedIndex = tpl.cmbType;
			cmbItemIcon.SelectedIndex = tpl.cmbItemIcon;
			cmbQuality.SelectedIndex = tpl.cmbQuality;
			cmbASPD.SelectedIndex = tpl.cmbASPD;
			numEnchant.Value = tpl.numEnchant;
			if( type == EItemType.Lapis ) {
				Lapi tplLapi = new Lapi( tpl.LapisType, tpl.LapisLevel );
				int i = 0;
				foreach( Lapi l in LapiComboBox.Lapis ) {
					if( l.Name == tplLapi.Name ) {
						cmbLapi.SelectedIndex = i;
						break;
					}
					i++;
				}
			}

			cmbSockel1.SelectedIndex = tpl.cmbSockel1;
			cmbSockel2.SelectedIndex = tpl.cmbSockel2;
			cmbSockel3.SelectedIndex = tpl.cmbSockel3;
			cmbSockel4.SelectedIndex = tpl.cmbSockel4;
			cmbSockel5.SelectedIndex = tpl.cmbSockel5;
			cmbSockel6.SelectedIndex = tpl.cmbSockel6;

			txtGold.SetGold( tpl.txtGold );

			if( type != EItemType.Lapis && type != EItemType.Lapisa ) 
				txtName.Text = tpl.txtName;
			txtANG1.Text = tpl.txtANG1;
			txtANG2.Text = tpl.txtANG2;
			txtHaltbarkeit.Text = tpl.txtHaltbarkeit;
			txtLP.Text = tpl.txtLP;
			txtMP.Text = tpl.txtMP;
			txtAP.Text = tpl.txtAP;
			txtGES.Text = tpl.txtGES;
			txtGLÜ.Text = tpl.txtGLÜ;
			txtSTR.Text = tpl.txtSTR;
			txtWEI.Text = tpl.txtWEI;
			txtINT.Text = tpl.txtINT;
			txtABW.Text = tpl.txtABW;
			txtLPEP4.Text = tpl.txtLPEP4;
			txtMPEP4.Text = tpl.txtMPEP4;
			txtAPEP4.Text = tpl.txtAPEP4;
			txtGESEP4.Text = tpl.txtGESEP4;
			txtGLÜEP4.Text = tpl.txtGLÜEP4;
			txtSTREP4.Text = tpl.txtSTREP4;
			txtWEIEP4.Text = tpl.txtWEIEP4;
			txtINTEP4.Text = tpl.txtINTEP4;
			txtABWEP4.Text = tpl.txtABWEP4;
			txtResistenz.Text = tpl.txtResistenz;
			txtSeller.Text = tpl.txtSeller;
		}

		private ITemplate BuildTemplate() {
			ITemplate tpl = new ITemplate();
			EItemType type = (EItemType)cmbType.SelectedIndex;
			tpl.txtName = txtName.Text;
			if( type == EItemType.Lapis ) { // Lapis name
				Lapi l = ( cmbLapi.SelectedItem as ImageComboItem ).Tag as Lapi;
				tpl.txtName = l.Name;
				tpl.LapisType = l.Type;
				tpl.LapisLevel = l.Level;
			} else if( type == EItemType.Lapisa ) // Lapisa name
				tpl.txtName = ( (ELapisa)cmbLapisa.SelectedIndex ).ToString();

			tpl.cmbType = cmbType.SelectedIndex;
			tpl.cmbItemIcon = cmbItemIcon.SelectedIndex;
			tpl.cmbQuality = cmbQuality.SelectedIndex;
			tpl.cmbASPD = cmbASPD.SelectedIndex;
			tpl.numEnchant = numEnchant.Value;
			tpl.cmbLapisa = cmbLapisa.SelectedIndex;

			tpl.cmbSockel1 = cmbSockel1.SelectedIndex;
			tpl.cmbSockel2 = cmbSockel2.SelectedIndex;
			tpl.cmbSockel3 = cmbSockel3.SelectedIndex;
			tpl.cmbSockel4 = cmbSockel4.SelectedIndex;
			tpl.cmbSockel5 = cmbSockel5.SelectedIndex;
			tpl.cmbSockel6 = cmbSockel6.SelectedIndex;

			tpl.txtGold = txtGold.GoldAmount;

			tpl.txtANG1 = txtANG1.Text;
			tpl.txtANG2 = txtANG2.Text;
			tpl.txtHaltbarkeit = txtHaltbarkeit.Text;
			tpl.txtLP = txtLP.Text;
			tpl.txtMP = txtMP.Text;
			tpl.txtAP = txtAP.Text;
			tpl.txtGES = txtGES.Text;
			tpl.txtGLÜ = txtGLÜ.Text;
			tpl.txtSTR = txtSTR.Text;
			tpl.txtWEI = txtWEI.Text;
			tpl.txtINT = txtINT.Text;
			tpl.txtABW = txtABW.Text;
			tpl.txtLPEP4 = txtLPEP4.Text;
			tpl.txtMPEP4 = txtMPEP4.Text;
			tpl.txtAPEP4 = txtAPEP4.Text;
			tpl.txtGESEP4 = txtGESEP4.Text;
			tpl.txtGLÜEP4 = txtGLÜEP4.Text;
			tpl.txtSTREP4 = txtSTREP4.Text;
			tpl.txtWEIEP4 = txtWEIEP4.Text;
			tpl.txtINTEP4 = txtINTEP4.Text;
			tpl.txtABWEP4 = txtABWEP4.Text;
			tpl.txtResistenz = txtResistenz.Text;
			tpl.txtSeller = txtSeller.Text;

			return tpl;
		}

		private Image GetTemplateItemImage( EItemType Type, int Index ) {
			switch( Type ) {
				case EItemType.Waffe:
					return listWeapon.Images[ Index ];
				case EItemType.Rüstung:
					return listArmor.Images[ Index ];
				case EItemType.Lapis:
					return listLapis.Images[ Index ];
				case EItemType.Lapisa:
					return listLapisa.Images[ Index ];
				case EItemType.APItem:
					return listAPItem.Images[ Index ];
				case EItemType.EtcItem:
					return listEtcItem.Images[ Index ];
			}
			return null;
		}

		#endregion

		#region SetType
		private void SetTypeWeapon() {
			SetEquipState( true );
			lblANG.Text = "ANG         ~         ANG";
			lblASPD.Text = "ANG-Geschwindigkeit";

			cmbItemIcon.LoadList( listWeapon, EImageComboItemTextAlign.Right );

			txtResistenz.Visible =
			cmbLapi.Visible =
			cmbLapisa.Visible =
				false;
		}
		private void SetTypeArmor() {
			SetEquipState( true );
			lblANG.Text = "Verteidigung";
			lblASPD.Text = "Resistenz";

			cmbItemIcon.LoadList( listArmor, EImageComboItemTextAlign.Right );

			txtANG2.Visible =
			cmbASPD.Visible =
			cmbLapi.Visible =
			cmbLapisa.Visible =
				false;
		}
		private void SetTypeLapi() {
			SetEquipState( false );
			cmbLapi.Visible =
			lblANG.Visible =
				true;
			cmbLapi.SelectedIndex = 0;
			lblANG.Text = "Lapi";
		}
		private void SetTypeLapisa() {
			SetEquipState( false );
			lblANG.Visible =
			cmbLapisa.Visible =
				true;
			cmbLapisa.SelectedIndex = 0;
			lblANG.Text = "Lapisa";
		}
		private void SetTypeAP() {
			SetEquipState( false );
			lblName.Visible =
			txtName.Visible =
				true;

			cmbItemIcon.LoadList( listAPItem, EImageComboItemTextAlign.Right );
			cmbItemIcon.Visible = true;
		}
		private void SetTypeEtc() {
			SetEquipState( false );
			lblName.Visible =
			txtName.Visible =
				true;

			cmbItemIcon.LoadList( listEtcItem, EImageComboItemTextAlign.Right );
			cmbItemIcon.Visible = true;
		}

		#endregion

	}

	#region Program.Main
	public static class Program {
		[STAThread]
		public static void Main() {
			Updater.Library.UpdateHandler uHandler = new Updater.Library.UpdateHandler();
			if( uHandler.CheckVersion( System.Reflection.Assembly.GetExecutingAssembly(), "http://shaiya-obscura.dz-net.net/updates/shaiya_markt/" ) == true && uHandler.StartUpdate() == true )
				return;

			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault( false );
			System.Windows.Forms.Application.Run( new frmMain() );
		}
	}
	#endregion

}
