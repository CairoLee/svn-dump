using Ssc.Components;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using Shaiya_Skill_Ressources.Structs;
using Shaiya_Skill_Ressources;

namespace Ssc {

	public partial class frmMain : Form {
		public static Assembly ExecutingAssembly;
		public static string EmbeddedSkillFile = @"\Skills\{0}.xml";
		public static Dictionary<EClass, SkillList> SkillListDict = new Dictionary<EClass, SkillList>();

		private bool mClassChanged = false;
		private int mClassOld = -1;
		private bool mModeChanged = false;
		private int mModeOld = -1;
		private int[] mSkillsCount = new int[ Enum.GetNames( typeof( ESkillType ) ).Length ];
		private int[] mSkillsRowCount = new int[ Enum.GetNames( typeof( ESkillType ) ).Length ];
		private int mUsedSkillPunkte = 0;

		private SkillList mSkillList;
		private int mMarkedPanel = -1;

		public frmMain() {
			InitializeComponent();
		}

		#region Form Events
		private void frmMain_Load( object sender, EventArgs e ) {
			// add the Mods
			foreach( string mode in Enum.GetNames( typeof( EGameMode ) ) )
				cbMode.Items.Add( mode );

			// add the Classes with an Icon
			cbClass.Items.Add( "<Klasse wählen>" );
			cbClass.Items.Add( new ImageComboItem( EClass.Fighter_Human.ToName(), cbClass.Font, Color.Black, EClass.Fighter_Human.ToImageIndex(), EImageComboItemTextAlign.Right, EClass.Fighter_Human ) );
			cbClass.Items.Add( new ImageComboItem( EClass.Warrior_Nordein.ToName(), cbClass.Font, Color.Black, EClass.Warrior_Nordein.ToImageIndex(), EImageComboItemTextAlign.Right, EClass.Warrior_Nordein ) );
			cbClass.Items.Add( new ImageComboItem( EClass.Defender_Human.ToName(), cbClass.Font, Color.Black, EClass.Defender_Human.ToImageIndex(), EImageComboItemTextAlign.Right, EClass.Defender_Human ) );
			cbClass.Items.Add( new ImageComboItem( EClass.Guardian_Nordein.ToName(), cbClass.Font, Color.Black, EClass.Guardian_Nordein.ToImageIndex(), EImageComboItemTextAlign.Right, EClass.Guardian_Nordein ) );
			cbClass.Items.Add( new ImageComboItem( EClass.Priest_Human.ToName(), cbClass.Font, Color.Black, EClass.Priest_Human.ToImageIndex(), EImageComboItemTextAlign.Right, EClass.Priest_Human ) );
			cbClass.Items.Add( new ImageComboItem( EClass.Oracle_Vail.ToName(), cbClass.Font, Color.Black, EClass.Oracle_Vail.ToImageIndex(), EImageComboItemTextAlign.Right, EClass.Oracle_Vail ) );
			cbClass.Items.Add( new ImageComboItem( EClass.Mage_Elf.ToName(), cbClass.Font, Color.Black, EClass.Mage_Elf.ToImageIndex(), EImageComboItemTextAlign.Right, EClass.Mage_Elf ) );
			cbClass.Items.Add( new ImageComboItem( EClass.Pagan_Vail.ToName(), cbClass.Font, Color.Black, EClass.Pagan_Vail.ToImageIndex(), EImageComboItemTextAlign.Right, EClass.Pagan_Vail ) );
			cbClass.Items.Add( new ImageComboItem( EClass.Ranger_Elf.ToName(), cbClass.Font, Color.Black, EClass.Ranger_Elf.ToImageIndex(), EImageComboItemTextAlign.Right, EClass.Ranger_Elf ) );
			cbClass.Items.Add( new ImageComboItem( EClass.Assasin_Vail.ToName(), cbClass.Font, Color.Black, EClass.Assasin_Vail.ToImageIndex(), EImageComboItemTextAlign.Right, EClass.Assasin_Vail ) );
			cbClass.Items.Add( new ImageComboItem( EClass.Archer_Elf.ToName(), cbClass.Font, Color.Black, EClass.Archer_Elf.ToImageIndex(), EImageComboItemTextAlign.Right, EClass.Archer_Elf ) );
			cbClass.Items.Add( new ImageComboItem( EClass.Hunter_Nordein.ToName(), cbClass.Font, Color.Black, EClass.Hunter_Nordein.ToImageIndex(), EImageComboItemTextAlign.Right, EClass.Hunter_Nordein ) );

			for( int i = 1; i < 61; i++ )
				cmbLevel.Items.Add( i );

			mSkillPanel = new SkillControl[ Enum.GetNames( typeof( ESkillType ) ).Length ];

			cbClass.SelectedIndex = 0;
			cbMode.SelectedIndex = 1;
			cmbLevel.SelectedIndex = 0;

			//Cursor = Ssc.Native.GetCursor( "Ssc.Resources.ShaiyaCursor.png", ExecutingAssembly );
		}

		private void frmMain_FormClosing( object sender, FormClosingEventArgs e ) {
			Properties.Settings.Default.Save();
		}
		#endregion

		#region Menu Events
		private void MenuProgramClose_Click( object sender, EventArgs e ) {
			Close();
		}

		private void MenuSettingsWarnOnReset_Click( object sender, EventArgs e ) {
			Properties.Settings.Default.WarnOnChange = !Properties.Settings.Default.WarnOnChange;
		}

		private void MenuSettingsInfoOnHover_Click( object sender, EventArgs e ) {
			Properties.Settings.Default.InfoOnHover = MenuSettingsInfoOnHover.Checked;
		}

		private void MenuAbout_Click( object sender, EventArgs e ) {
			using( frmAbout frm = new frmAbout() )
				frm.ShowDialog();
		}
		#endregion

		#region Overview Events
		private void btnGenerate_Click( object sender, EventArgs e ) {
			GenerateOverview();
		}

		private void btnSave_Click( object sender, EventArgs e ) {
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Text Datei (*.txt)|*.txt|Alle Datein (*.*)|*.*";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			using( Stream stream = dlg.OpenFile() ) {
				SaveBuild( stream );
			}
		}

		private void btnLoad_Click( object sender, EventArgs e ) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Text Datei (*.txt)|*.txt|Alle Datein (*.*)|*.*";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			LoadBuild( dlg.FileName );
		}
		#endregion

		#region ComboBox Events
		private void cmbLevel_SelectedIndexChanged( object sender, EventArgs e ) {
			UpdateSkillPoints();
			if( cbClass.SelectedIndex != 0 )
				UpdateButtons();
		}

		private void cbClass_SelectedIndexChanged( object sender, EventArgs e ) {
			if( panelSpecial.Controls.Count == 0 ) {
				mClassChanged = true;
				mClassOld = cbClass.SelectedIndex;
				mUsedSkillPunkte = 0;
				InitializeSkills();
				return;
			}

			if( mClassChanged == true && Properties.Settings.Default.WarnOnChange == true )
				if( MessageBox.Show( "Das wird alle deine Skillpunkte zurücksetzen!\nBist du dir sicher?", "Skills resetten", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) != DialogResult.Yes ) {
					mClassChanged = false;
					cbClass.SelectedIndex = mClassOld;
					return;
				}

			mClassChanged = true;
			mClassOld = cbClass.SelectedIndex;
			mUsedSkillPunkte = 0;
			InitializeSkills();
			skillDescPassive.Clear();
			skillDescBasic.Clear();
			skillDescCombat.Clear();
			skillDescSpecial.Clear();
		}

		private void cbMode_SelectedIndexChanged( object sender, EventArgs e ) {
			UpdateSkillPoints();

			if( panelSpecial.Controls.Count == 0 )
				return;

			if( mModeChanged == true )
				if( MessageBox.Show( "Das wird alle deine Skillpunkte zurücksetzen!\nBist du dir sicher?", "Skills resetten", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) != DialogResult.Yes ) {
					mModeChanged = false;
					cbMode.SelectedIndex = mModeOld;
					mUsedSkillPunkte = 0;
					InitializeSkills();
					UpdateSkillPoints();
					return;
				}

			mModeChanged = true;
			mModeOld = cbMode.SelectedIndex;

			mUsedSkillPunkte = 0;
			InitializeSkills();
			skillDescPassive.Clear();
			skillDescBasic.Clear();
			skillDescCombat.Clear();
			skillDescSpecial.Clear();
		}
		#endregion

		#region Level Up/Down Events
		private void btnDown_Click( object sender, EventArgs e ) {
			int index = 0;
			if( sender != null && sender is PictureBox )
				index = Convert.ToInt32( ( sender as PictureBox ).Tag );
			else if( sender != null )
				index = (int)sender;

			mSkillPanel[ index ].LevelDown();

			UpdateSkillInfo( index, true );
			UpdateButtons();
			UpdateSkillPoints();
		}

		private void btnUp_Click( object sender, EventArgs e ) {
			int index = 0;
			if( sender != null && sender is PictureBox )
				index = Convert.ToInt32( ( sender as PictureBox ).Tag );
			else if( sender != null )
				index = (int)sender;

			mSkillPanel[ index ].LevelUp();

			UpdateSkillInfo( index, true );
			UpdateButtons();
			UpdateSkillPoints();
		}
		#endregion

		#region SkillInfo Events (Label & Icon)
		public void sklPanel_MouseEnter( object sender, EventArgs e ) {
			if( Properties.Settings.Default.InfoOnHover == false )
				return;

			SkillControl pnlNew = sender as SkillControl;
			UpdateSkillInfo( int.Parse( pnlNew.Tag.ToString() ), false );
		}

		private void sklPanel_Click( object sender, EventArgs e ) {
			SkillControl pnlNew = sender as SkillControl;
			UpdateSkillInfo( int.Parse( pnlNew.Tag.ToString() ), false );
		}
		#endregion

		#region TabControl Events
		private void tabSkills_SelectedIndexChanged( object sender, EventArgs e ) {
			if( tabSkills.SelectedIndex == tabSkills.TabCount - 1 )
				GenerateOverview();
		}
		#endregion


		private Panel GetPanel( ESkillType Type ) {
			switch( Type ) {
				default:
					throw new ArgumentException( "Unknown type", "Type" );
				case ESkillType.Passive:
					return panelPassive;
				case ESkillType.Basic:
					return panelBasic;
				case ESkillType.Combat:
					return panelCombat;
				case ESkillType.Special:
					return panelSpecial;
			}
		}

		private void InitializeSkills() {
			if( cbClass.SelectedIndex == 0 )
				return;

			panelPassive.Controls.Clear();
			panelBasic.Controls.Clear();
			panelCombat.Controls.Clear();
			panelSpecial.Controls.Clear();
			mSkillsCount = new int[ Enum.GetNames( typeof( ESkillType ) ).Length ];
			mSkillsRowCount = new int[ Enum.GetNames( typeof( ESkillType ) ).Length ];
			mSkillList = SkillListDict[ ( (EClass)( cbClass.SelectedItem as ImageComboItem ).Tag ) ];

			mSkillPanel = new SkillControl[ mSkillList.Count ];
			for( int i = 0; i < mSkillPanel.Length; i++ ) {
				mSkillPanel[ i ] = new SkillControl( mSkillList[ i ] );
				if( mSkillList[ i ].Mode > cbMode.SelectedIndex )
					continue;

				mSkillPanel[ i ] = new SkillControl( mSkillList[ i ] );
				mSkillPanel[ i ].MouseEnter += new EventHandler( sklPanel_MouseEnter );
				mSkillPanel[ i ].Click += new EventHandler( sklPanel_Click );
				mSkillPanel[ i ].Tag = i;

				mSkillPanel[ i ].btnUp.Tag = i;
				mSkillPanel[ i ].btnUp.Click += new EventHandler( btnUp_Click );
				mSkillPanel[ i ].btnDown.Tag = i;
				mSkillPanel[ i ].btnDown.Click += new EventHandler( btnDown_Click );
				mSkillPanel[ i ].pbIcon.Tag = i;

				int type = (int)mSkillList[ i ].Type;
				if( ( mSkillsCount[ type ] % 2 ) == 0 ) {
					mSkillPanel[ i ].Location = new Point( 5, 5 + ( ( mSkillPanel[ i ].Height + 8 ) * mSkillsRowCount[ type ] ) );
				} else {
					mSkillPanel[ i ].Location = new Point( mSkillPanel[ i ].Width + 10, 5 + ( ( mSkillPanel[ i ].Height + 8 ) * mSkillsRowCount[ type ] ) );
					mSkillsRowCount[ type ]++;
				}


				GetPanel( mSkillList[ i ].Type ).Controls.Add( mSkillPanel[ i ] );
				mSkillsCount[ type ]++;
			}

			UpdateButtons();
			UpdateSkillPoints();
		}

		private void UpdateSkillInfo( int index, bool force ) {
			if( tabSkills.SelectedIndex == tabSkills.TabPages.Count - 1 ) // Overview
				return;

			if( mMarkedPanel == index && force == false )
				return;

			if( mMarkedPanel != -1 )
				mSkillPanel[ mMarkedPanel ].Unmark();
			mMarkedPanel = index;
			mSkillPanel[ mMarkedPanel ].Mark();
			switch( mSkillPanel[ index ].Skill.Type ) {
				case ESkillType.Passive:
					skillDescPassive.RefreshSkillInfo( mSkillPanel[ index ] );
					break;
				case ESkillType.Basic:
					skillDescBasic.RefreshSkillInfo( mSkillPanel[ index ] );
					break;
				case ESkillType.Combat:
					skillDescCombat.RefreshSkillInfo( mSkillPanel[ index ] );
					break;
				case ESkillType.Special:
					skillDescSpecial.RefreshSkillInfo( mSkillPanel[ index ] );
					break;
			}


		}

		private void UpdateSkillPoints() {
			EGameMode gMode = (EGameMode)cbMode.SelectedIndex;
			int level = cmbLevel.SelectedIndex;
			int skPunkte = 0;

			if( level > 0 )
				switch( gMode ) {
					case EGameMode.Easy:
						skPunkte = 3 * level;
						break;
					case EGameMode.Normal:
						skPunkte = ( 3 * level ) + 2;
						break;
					case EGameMode.Hard:
						skPunkte = ( 4 * level ) + 1;
						break;
					case EGameMode.Ultimate:
						skPunkte = 5 * level;
						break;
				}

			skPunkte += 5; // 5 Points at Game Start

			mUsedSkillPunkte = 0;
			for( int i = 0; i < mSkillPanel.Length; i++ )
				if( mSkillPanel[ i ] != null )
					mUsedSkillPunkte += mSkillPanel[ i ].UsedSp;

			lblSkillPoints.ForeColor = ( skPunkte - mUsedSkillPunkte < 0 ? Color.Red : Color.Black );
			lblSkillPoints.Text = string.Format( "{0} / {1}", skPunkte - mUsedSkillPunkte, skPunkte );
		}

		private void UpdateButtons() {
			for( int i = 0; i < mSkillList.Count; i++ ) {
				mSkillPanel[ i ].btnUp.Enabled = ( ( cmbLevel.SelectedIndex + 1 ) >= mSkillPanel[ i ].RequiredLevel && mSkillPanel[ i ].CurrentLevelNum < mSkillPanel[ i ].MaximumLevel );
				mSkillPanel[ i ].btnDown.Enabled = ( mSkillPanel[ i ].CurrentLevelNum > 0 );

				if( mSkillPanel[ i ].btnUp.Enabled == false && mSkillPanel[ i ].CurrentLevelNum < mSkillPanel[ i ].MaximumLevel )
					mSkillPanel[ i ].lblReqLvl.ForeColor = Color.Maroon;
				else
					mSkillPanel[ i ].lblReqLvl.ForeColor = Color.DarkGreen;
			}
		}

		private void GenerateOverview() {
			if( mSkillList == null )
				return;
			splOverview.Panel2.Controls.Clear();
			lblOverviewClass = new Label();
			lblOverviewSkillPoints = new Label();
			lblOverviewLevel = new Label();
			lblOverviewClass.Font = new Font( "Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0 );
			lblOverviewClass.AutoSize = true;
			lblOverviewClass.Text = ( (EClass)( cbClass.SelectedItem as ImageComboItem ).Tag ).ToName();
			splOverview.Panel2.Controls.Add( lblOverviewClass );
			lblOverviewSkills = new Label[ mSkillPanel.Length ];
			int skillLines = 0;
			int skillCount = 0;
			for( int i = 0; i < mSkillPanel.Length; i++ ) {
				lblOverviewSkills[ i ] = new Label();
				lblOverviewSkills[ i ].AutoSize = true;
				lblOverviewSkills[ i ].Tag = i;
				if( mSkillPanel[ i ].CurrentLevelNum != 0 ) {
					if( ( skillCount % 2 ) == 0 ) {
						skillLines++;
						lblOverviewSkills[ i ].Location = new Point( 10, 25 + ( 15 * ( skillLines - 1 ) ) );
					} else {
						lblOverviewSkills[ i ].Location = new Point( 250, 25 + ( 15 * ( skillLines - 1 ) ) );
					}
					lblOverviewSkills[ i ].Text = string.Format( "{0} - (Lvl {1}/{2})", mSkillList[ i ].Name, mSkillPanel[ i ].CurrentLevelNum, mSkillList[ i ].MaxLvl );
					splOverview.Panel2.Controls.Add( lblOverviewSkills[ i ] );
					skillCount++;
				}
			}

			lblOverviewSkillPoints.AutoSize = true;
			lblOverviewSkillPoints.Text = lblSkillPoints.Text;
			lblOverviewSkillPoints.ForeColor = lblSkillPoints.ForeColor;
			lblOverviewSkillPoints.Location = new Point( 35, 25 + ( 15 * ( skillLines + 1 ) ) );

			lblOverviewLevel.AutoSize = true;
			lblOverviewLevel.Text = "Level: " + ( cmbLevel.SelectedIndex + 1 );
			lblOverviewLevel.ForeColor = lblSkillPoints.ForeColor;
			lblOverviewLevel.Location = new Point( 35, 45 + ( 15 * ( skillLines + 1 ) ) );

			splOverview.Panel2.Controls.Add( lblOverviewSkillPoints );
			splOverview.Panel2.Controls.Add( lblOverviewLevel );

		}

		private void SaveBuild( Stream stream ) {
			using( StreamWriter writer = new StreamWriter( stream ) ) {
				writer.WriteLine( lblOverviewClass.Text + " - " + cbMode.SelectedItem.ToString() );
				writer.WriteLine( "----------------------------" );
				for( int i = 0; i < lblOverviewSkills.Length; i++ ) {
					if( lblOverviewSkills[ i ].Text != "" )
						writer.WriteLine( lblOverviewSkills[ i ].Text );
				}
				writer.WriteLine( "" );
				writer.WriteLine( "Skillpunkte: " + lblOverviewSkillPoints.Text );
				writer.WriteLine( lblOverviewLevel.Text );
				writer.Close();
			}
		}

		private void LoadBuild( string Filename ) {
			string charClass, charMode, charPoints, charLevel;
			List<string> skills = new List<string>();
			using( Stream stream = File.OpenRead( Filename ) ) {
				using( StreamReader reader = new StreamReader( stream ) ) {
					charClass = reader.ReadLine();
					reader.ReadLine(); // -----------

					string line = string.Empty;
					while( ( line = reader.ReadLine() ) != string.Empty ) {
						if( line.Length > 2 && line.Substring( 0, 2 ) == "//" )
							continue;
						skills.Add( line );
					}

					charPoints = reader.ReadLine();
					charLevel = reader.ReadLine();

					reader.Close();
				}
			}

			string[] parts = charClass.Split( new string[] { " - " }, StringSplitOptions.None );
			if( parts.Length != 2 ) {
				Helper.MessageError( "Fehler!\nKonnte Klasse nicht aus dem String \"" + charClass + "\" beziehen!", "Fehler!" );
				return;
			}

			charClass = parts[ 0 ].Trim();
			charMode = parts[ 1 ].Trim();
			if( cbClass.Contains( charClass ) == false ) {
				Helper.MessageError( "Fehler!\nDie Klasse \"" + charClass + "\" konnte nicht gefunden werden!", "Fehler!" );
				return;
			}

			// got all data, start Fetching
			bool old = Properties.Settings.Default.WarnOnChange;
			Properties.Settings.Default.WarnOnChange = false;

			cbClass.SelectedIndex = cbClass.IndexOf( charClass );
			cbMode.SelectedIndex = cbMode.Items.IndexOf( charMode );
			cmbLevel.SelectedIndex = int.Parse( charLevel.Replace( "Level: ", "" ) ) - 1;

			foreach( string skillData in skills ) {
				string[] skillParts = skillData.Split( new string[] { " - " }, StringSplitOptions.None );
				if( skillParts.Length != 2 ) {
					Helper.MessageError( "Fehler!\nKonnte Skill nicht auslesen!\nZeile: " + skillData, "Fehler!" );
					continue;
				}

				string skillName = skillParts[ 0 ].Trim();
				string sub = skillParts[ 1 ].Trim().Substring( 5, 1 );
				int skillLevel = int.Parse( sub );

				for( int p = 0; p < mSkillPanel.Length; p++ ) {
					if( mSkillPanel[ p ].SkillName != skillName )
						continue;
					for( int l = 0; l < skillLevel; l++ )
						btnUp_Click( p, EventArgs.Empty );
				}
			}

			Properties.Settings.Default.WarnOnChange = old;
			GenerateOverview();
		}


	}


}

