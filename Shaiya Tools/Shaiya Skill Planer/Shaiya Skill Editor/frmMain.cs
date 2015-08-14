using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Shaiya_Skill_Ressources.Structs;

namespace Shaiya_Skill_Editor {

	public partial class frmMain : Form {
		private SkillList mSkilllist;
		private List<string> mIconNames = new List<string>();


		public frmMain() {
			InitializeComponent();

			Skill.MainAssembly = Assembly.GetAssembly( typeof( Shaiya_Skill_Ressources.Dummy ) );

			LoadIcons();
			SetStatus( "Ready!" );
		}


		private void LoadIcons() {
			Assembly asm = Assembly.GetAssembly( typeof( Shaiya_Skill_Ressources.Dummy ) );
			List<string> tmpIconNames = new List<string>( asm.GetManifestResourceNames() );

			SetStatus( "Loading Icons..." );

			tmpIconNames.Sort( 
				new Comparison<string>(
					delegate( string s1, string s2 ) {
						int i1, i2;
						if( s1.EndsWith( ".png" ) == false || s2.EndsWith( ".png" ) == false )
							return 0;
						s1 = s1.Replace( "Shaiya_Skill_Ressources.Embedded.icons.icon-", "" ).Replace( ".png", "" );
						s2 = s2.Replace( "Shaiya_Skill_Ressources.Embedded.icons.icon-", "" ).Replace( ".png", "" );
						if( s1.StartsWith( "new-" ) == true && s2.StartsWith( "new-" ) ) {
							i1 = int.Parse( s1.Replace( "new-", "" ) ) + 1000;
							i2 = int.Parse( s2.Replace( "new-", "" ) ) + 1000;
							return i1.CompareTo( i2 );
						} else if( s1.StartsWith( "new-" ) == false && s2.StartsWith( "new-" ) == true ) {
							i1 = int.Parse( s1 );
							i2 = int.Parse( s2.Replace( "new-", "" ) ) + 1000;
							return i1.CompareTo( i2 );
						} else if( s1.StartsWith( "new-" ) == true && s2.StartsWith( "new-" ) == false ) {
							i1 = int.Parse( s1.Replace( "new-", "" ) ) + 1000;
							i2 = int.Parse( s2 );
							return i1.CompareTo( i2 );
						}
						i1 = int.Parse( s1 );
						i2 = int.Parse( s2 );
						return i1.CompareTo( i2 );
					}
				)
			);
			for( int i = 0; i < tmpIconNames.Count; i++ ) {
				if( tmpIconNames[ i ].StartsWith( "Shaiya_Skill_Ressources.Embedded.icons" ) == false )
					continue;
				using( Stream s = asm.GetManifestResourceStream( tmpIconNames[ i ] ) ) {
					iconList.Images.Add( tmpIconNames[ i ].CleanIcon(), Image.FromStream( s ) );
					mIconNames.Add( tmpIconNames[ i ].CleanIcon() );
				}
			}

			for( int i = 0; i < mIconNames.Count; i++ )
				cbIcon.Items.Add( new Ssc.ImageComboItem( mIconNames[ i ], this.Font, Color.Black, i, Ssc.EImageComboItemTextAlign.Right ) );


			string[] gameModes = Enum.GetNames( typeof( Shaiya_Skill_Ressources.EGameMode ) );
			string[] skillTypes = Enum.GetNames( typeof( Shaiya_Skill_Ressources.ESkillType ) );

			for( int i = 0; i < gameModes.Length; i++ )
				cbGameMode.Items.Add( gameModes[ i ] );
			for( int i = 0; i < skillTypes.Length; i++ )
				cbSkillType.Items.Add( skillTypes[ i ] );

			cbIcon.SelectedIndex = 0;
			cbGameMode.SelectedIndex = 0;
			cbSkillType.SelectedIndex = 0;
		}



		#region frmMain Events
		private void frmMain_KeyUp( object sender, KeyEventArgs e ) {
			switch( e.KeyCode ) {
				case Keys.Back:
					MenuSkillsDelete.PerformClick();
					e.Handled = true;
					break;
			}

		}
		#endregion

		#region MenuProgram
		private void MenuProgramClose_Click( object sender, EventArgs e ) {
			SetStatus( "shutting down..", Color.Maroon );
			Close();
		} 
		#endregion

		#region MenuSkill
		private void MenuSkillsOpen_Click( object sender, EventArgs e ) {
			LoadSkillList();
		}

		private void MenuSkillsSave_Click( object sender, EventArgs e ) {
			SaveSkillList();
		}

		private void MenuSkillsAdd_Click( object sender, EventArgs e ) {
			Skill s = new Skill();
			s.Level.Add( new SkillLevel( "Neuer Skill Level 1" ) );
			s.Level.Add( new SkillLevel( "Neuer Skill Level 2" ) );
			s.Level.Add( new SkillLevel( "Neuer Skill Level 3" ) );

			mSkilllist.Skills.Add( s );
			int key = iconList.Images.IndexOfKey( s.IconName.CleanIcon() );
			listSkills.Items.Add( new ListViewItem( s.Name, key ) );
			listSkills.SelectedIndices.Add( listSkills.Items.Count - 1 );
		}

		private void MenuSkillsDelete_Click( object sender, EventArgs e ) {
			if( listSkills.SelectedIndices.Count == 0 ) {
				MenuSkillsDelete.Enabled = false;
				return;
			}

			int oldIndex = listSkills.SelectedIndices[ 0 ];
			mSkilllist.Skills.RemoveAt( listSkills.SelectedIndices[ 0 ] );
			listSkills.Items.RemoveAt( listSkills.SelectedIndices[ 0 ] );
			if( oldIndex >= 1 )
				listSkills.SelectedIndices.Add( oldIndex - 1 );
			else if( listSkills.Items.Count > 0 )
				listSkills.SelectedIndices.Add( 0 );
		}
		#endregion

		#region MenuAbout
		private void MenuAbout_Click( object sender, EventArgs e ) {

		} 
		#endregion


		#region listSkills Events
		private void listSkills_SelectedIndexChanged( object sender, EventArgs e ) {
			if( listSkills.Items.Count == 0 || listSkills.SelectedIndices.Count == 0 ) {
				MenuSkillsDelete.Enabled = false;
				return;
			}
			MenuSkillsDelete.Enabled = true;
			SetSkill( listSkills.SelectedIndices[ 0 ] );
		}
		#endregion

		#region SkillInput Events
		private void btnSaveSkill_Click( object sender, EventArgs e ) {
			SaveSkillInput();
		} 
		#endregion



		#region Input Helper
		private void SaveSkillInput() {
			int i = listSkills.SelectedIndices[ 0 ];
			Skill s = mSkilllist[ i ];
			s.Mode = cbGameMode.SelectedIndex;
			s.Type = (Shaiya_Skill_Ressources.ESkillType)cbSkillType.SelectedIndex;
			s.IconName = cbIcon.Items[ cbIcon.SelectedIndex ].ToString().RestoreIcon();

			s.Level.Clear();
			s.Level.Add( skillLevelPanel1.GetSkill() );
			if( cbLevel.SelectedIndex >= 1 )
				s.Level.Add( skillLevelPanel2.GetSkill() );
			if( cbLevel.SelectedIndex >= 2 )
				s.Level.Add( skillLevelPanel3.GetSkill() );

			int index = iconList.Images.IndexOfKey( cbIcon.Items[ cbIcon.SelectedIndex ].ToString() );
			listSkills.SelectedItems[ 0 ].ImageIndex = index;
			SetStatus( "Skill '" + s.Name + "' saved to SkillList!", Color.ForestGreen );
		}

		private void SetSkill( int Index ) {
			ClearInputs();

			Skill s = mSkilllist[ Index ];
			if( s.Level.Count == 0 ) {
				SetStatus( "Failed to load Skill -  no Level Information found!", Color.Maroon );
				return;
			}

			cbGameMode.SelectedIndex = s.Mode;
			SelectSkillIcon( s.IconName );
			//MessageBox.Show( "Das Icon '" + s.IconName + "' konnte nicht gefunden werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
			cbSkillType.SelectedIndex = (int)s.Type;
			cbLevel.SelectedIndex = s.Level.Count - 1;

			skillLevelPanel1.SetSkill( s.Level[ 0 ] );
			if( s.Level.Count >= 2 )
				skillLevelPanel2.SetSkill( s.Level[ 1 ] );
			if( s.Level.Count >= 3 )
				skillLevelPanel3.SetSkill( s.Level[ 2 ] );

			SetStatus( "Skill '" + s.Name + "' successfull loaded to GUI", Color.ForestGreen );
		}

		private void ClearInputs() {
			cbGameMode.SelectedIndex = cbIcon.SelectedIndex = cbSkillType.SelectedIndex = cbLevel.SelectedIndex = 0;
			skillLevelPanel1.Clear();
			skillLevelPanel2.Clear();
			skillLevelPanel3.Clear();
		}

		private bool SelectSkillIcon( string Iconname ) {
			if( Iconname.StartsWith( "icons." ) )
				Iconname = Iconname.Substring( 6 );
			if( Iconname.EndsWith( ".png" ) )
				Iconname = Iconname.Substring( 0, Iconname.Length - 4 );

			for( int i = 0; i < cbIcon.Items.Count; i++ )
				if( cbIcon.Items[ i ].ToString() == Iconname ) {
					cbIcon.SelectedIndex = i;
					return true;
				}

			return false;

		}
		#endregion

		#region Load/Save List
		private void LoadSkillList() {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Skilllist (*.xml)|*.xml";
			dlg.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"Skills\";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			mSkilllist = SkillList.Load( dlg.FileName );
			listSkills.Items.Clear();
			for( int i = 0; i < mSkilllist.Count; i++ ){
				int key = iconList.Images.IndexOfKey( mSkilllist[ i ].IconName.CleanIcon() );
				listSkills.Items.Add( new ListViewItem( mSkilllist[ i ].Name, key ) );
			}

			btnSaveSkill.Enabled = true;
			MenuSkillsSave.Enabled = true;
			MenuSkillsAdd.Visible = true;
			MenuSkillsDelete.Visible = true;
			MenuSkillsSeperator1.Visible = true;
			SetStatus( "SkillList '" + Path.GetFileNameWithoutExtension( dlg.FileName ) + "' successfull loaded to GUI!", Color.ForestGreen );
		}

		private void SaveSkillList() {
			mSkilllist.Save();
			SetStatus( "SkillList '" + Path.GetFileNameWithoutExtension( mSkilllist.Filename ) + "' successfull saved!", Color.ForestGreen );
		}
		#endregion

		#region SetStatus()
		public void SetStatus( string Text ) {
			SetStatus( Text, Color.ForestGreen );
		}

		public void SetStatus( string Text, Color ForeColor ) {
			lblStatus.Text = Text;
			lblStatus.ForeColor = ForeColor;

			Application.DoEvents();
		} 
		#endregion

	}


	public static class StringExtensions {

		public static string CleanIcon( this string Iconname ) {
			return Iconname.Replace( "Shaiya_Skill_Ressources.Embedded.", "" ).Replace( "icons.", "" ).Replace( ".png", "" );
		}

		public static string RestoreIcon( this string Iconname ) {
			return "icons." + Iconname + ".png";
		}

	}

}
