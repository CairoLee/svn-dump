using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace Ssc {

	public partial class frmMain : Form {
		private static Point PointEbil = new Point( -999, -999 );
		private Point mClick = PointEbil;
		private SPlayerStatus mStats = new SPlayerStatus();
		private XmlSerializer mXml = new XmlSerializer( typeof( SPlayerStatus ) );
		private int mStatusFree = 0;
		private int mStatusUsed = 0;
		private ItemToolTip mToolTip = new ItemToolTip();
		private Assembly mAssembly;

		public frmMain() {
			InitializeComponent();

			mAssembly = Assembly.GetExecutingAssembly();

			foreach( string name in Enum.GetNames( typeof( EGameMode ) ) )
				cbMode.Items.Add( name );
			foreach( string name in Enum.GetNames( typeof( EClass ) ) )
				cbClass.Items.Add( name );

			InitializeStats();
		}

		#region Form Events
		private void frmMain_Shown( object sender, EventArgs e ) {
			UpdateImages();
		}

		private void frmMain_FormClosing( object sender, FormClosingEventArgs e ) {
			string filePath = Properties.Settings.Default.LastOpened;
			if( File.Exists( filePath ) == false )
				filePath = AppDomain.CurrentDomain.BaseDirectory + @"Ssc.xml";

			Properties.Settings.Default.LastOpened = filePath;
			Properties.Settings.Default.Save();

			if( Properties.Settings.Default.SaveOnExit == false )
				return;

			try { File.Delete( filePath ); } catch { }
			XmlSerializer xml = new XmlSerializer( typeof( SPlayerStatus ) );
			using( FileStream fs = File.OpenWrite( filePath ) )
				xml.Serialize( fs, mStats );
		}
		#endregion

		#region Initialize
		private void InitializeStats() {
			SPlayerStatus status = SPlayerStatus.BaseAttentäter;
			if( string.IsNullOrEmpty( Properties.Settings.Default.LastOpened ) == false ) {
				try {
					using( FileStream fs = File.OpenRead( Properties.Settings.Default.LastOpened ) )
						status = mXml.Deserialize( fs ) as SPlayerStatus;
					this.Text = "Shaiya Status Calculator - " + Path.GetFileName( Properties.Settings.Default.LastOpened );
				} catch {
					status = SPlayerStatus.BaseAttentäter;
				}
			}

			cbClass.SelectedIndex = (int)status.Class;
			cbMode.SelectedIndex = (int)status.Mode;

			txtLevel.Text = status.Level.ToString();
			txtSTR.Text = status.STR.ToString();
			txtABW.Text = status.ABW.ToString();
			txtINT.Text = status.INT.ToString();
			txtWEI.Text = status.WEI.ToString();
			txtGES.Text = status.GES.ToString();
			txtGLU.Text = status.GLU.ToString();

			mStats = status;

			UpdateAll();
		}
		#endregion

		#region Dragging
		private void panelMain_MouseDown( object sender, MouseEventArgs e ) {
			if( e.Y > 20 )
				return;
			mClick = e.Location;

		}

		private void panelMain_MouseMove( object sender, MouseEventArgs e ) {
			if( mClick == PointEbil || e.Button != MouseButtons.Left )
				return;
			this.Left += e.X - mClick.X;
			this.Top += e.Y - mClick.Y;
		}

		private void panelMain_MouseUp( object sender, MouseEventArgs e ) {
			mClick = PointEbil;
		}
		#endregion

		#region btnClose
		private void btnClose_MouseDown( object sender, MouseEventArgs e ) {
			btnClose.Image = Properties.Resources.btnCloseDown;
		}

		private void btnClose_MouseUp( object sender, MouseEventArgs e ) {
			btnClose.Image = Properties.Resources.btnCloseHover;
			this.Close();
		}

		private void btnClose_MouseEnter( object sender, EventArgs e ) {
			btnClose.Image = Properties.Resources.btnCloseHover;
		}

		private void btnClose_MouseLeave( object sender, EventArgs e ) {
			btnClose.Image = Properties.Resources.btnClose;
		}
		#endregion


		#region Status Events
		private void StatusText_TextChanged( object sender, EventArgs e ) {
			MaskedTextBox txt = sender as MaskedTextBox;
			decimal tmp;
			switch( txt.Name.Replace( "txt", "" ).ToLower() ) {
				case "str":
					if( decimal.TryParse( txt.Text, out tmp ) == false )
						mStats.STR = 0;
					else
						mStats.STR = tmp;
					break;
				case "int":
					if( decimal.TryParse( txt.Text, out tmp ) == false )
						mStats.INT = 0;
					else
						mStats.INT = tmp;
					break;
				case "abw":
					if( decimal.TryParse( txt.Text, out tmp ) == false )
						mStats.ABW = 0;
					else
						mStats.ABW = tmp;
					break;
				case "ges":
					if( decimal.TryParse( txt.Text, out tmp ) == false )
						mStats.GES = 0;
					else
						mStats.GES = tmp;
					break;
				case "glu":
					if( decimal.TryParse( txt.Text, out tmp ) == false )
						mStats.GLU = 0;
					else
						mStats.GLU = tmp;
					break;
				case "wei":
					if( decimal.TryParse( txt.Text, out tmp ) == false )
						mStats.WEI = 0;
					else
						mStats.WEI = tmp;
					break;

				case "level":
					int iTmp;
					if( int.TryParse( txt.Text, out iTmp ) == false )
						mStats.Level = 1;
					else
						mStats.Level = iTmp;
					break;
			}

			UpdatePoints();
		}

		private void cbMode_SelectedIndexChanged( object sender, EventArgs e ) {
			mStats.Mode = (EGameMode)cbMode.SelectedIndex;
			UpdatePoints();
		}

		private void cbClass_SelectedIndexChanged( object sender, EventArgs e ) {
			mStats.Class = (EClass)cbClass.SelectedIndex;
			switch( mStats.Class ) {
				case EClass.Attentäter:
					mStats.SetBaseStatus( SPlayerStatus.BaseAttentäter );
					break;
				case EClass.Heide:
					mStats.SetBaseStatus( SPlayerStatus.BaseHeide );
					break;
				case EClass.Krieger:
					mStats.SetBaseStatus( SPlayerStatus.BaseKrieger );
					break;
				case EClass.Orakel:
					mStats.SetBaseStatus( SPlayerStatus.BaseOrakel );
					break;
				case EClass.Wächter:
					mStats.SetBaseStatus( SPlayerStatus.BaseWächter );
					break;
				default:
				case EClass.Jäger:
					mStats.SetBaseStatus( SPlayerStatus.BaseJäger );
					break;
			}

			UpdateAll();
		}
		#endregion

		#region Equipment Events
		private void EquipmentImg_Click( object sender, EventArgs e ) {
			if( !( sender is PictureBox ) )
				return;

			PictureBox box = sender as PictureBox;
			string itemType = box.Name.Substring( 3 );
			SItem item = mStats.GetItemFromName( itemType ).Clone() as SItem;

			if( box == imgWaffe ) {
				frmItemBonusWeapon frm = new frmItemBonusWeapon( item, itemType );
				if( frm.ShowDialog() != DialogResult.OK )
					return;
				item.Name = frm.txtName.Text;
				item.Sockel = (int)frm.numSockel.Value;
				item.Bonus = frm.GetBonusList();
				item.WeaponType = (EWeaponType)frm.cbWeaponType.SelectedIndex;
			} else {
				frmItemBonus frm = new frmItemBonus( item, itemType );
				if( frm.ShowDialog() != DialogResult.OK )
					return;
				item.Name = frm.txtName.Text;
				item.Sockel = (int)frm.numSockel.Value;
				item.Bonus = frm.GetBonusList();
				item.WeaponType = EWeaponType.None;
			}
			if( item.Name == string.Empty && item.Bonus.Count > 0 )
				item.Name = itemType;
			else if( item.Name == string.Empty && item.Bonus.Count == 0 )
				item = SItem.Empty.Clone() as SItem;

			if( item.Equals( SItem.Empty ) )
				box.Image = null;
			else
				box.Image = Bitmap.FromStream( mAssembly.GetManifestResourceStream( "Ssc.Resources.EQ_" + itemType + ".png" ) );

			mStats.SaveItemByName( itemType, item );
			if( mStats.GetItemFromName( itemType ) == SItem.Empty )
				box.Image = null;

			box.Invalidate();
			UpdateAll();
		}

		private void EquipmentImg_MouseMove( object sender, MouseEventArgs e ) {
		}

		private void EquipmentImg_MouseEnter( object sender, EventArgs e ) {
			if( !( sender is PictureBox ) )
				return;

			PictureBox box = sender as PictureBox;

			mToolTip.Item = mStats.GetItemFromName( box.Name.Substring( 3 ) ).Clone() as SItem;
			if( mToolTip.Item == SItem.Empty || mToolTip.Item.Name == string.Empty )
				return;

			mToolTip.SetToolTip( box, "Dummy" );
			mToolTip.Active = true;
		}

		private void EquipmentImg_MouseLeave( object sender, EventArgs e ) {
			mToolTip.Active = false;
		}
		#endregion




		private void UpdateImages() {
			string[] imgNames = new string[]{
				"Armreif2",
				"Armreif1",
				"Ring2",
				"Ring1",
				"Reittier",
				"Amulett",
				"Mantel",
				"Schild",
				"Waffe",
				"Schuhe",
				"Handschuh",
				"Hose",
				"Rüstung",
				"Helm"
			};
			for( int i = 0; i < imgNames.Length; i++ ) {
				PictureBox box = this.panelStatus.Controls[ "img" + imgNames[ i ] ] as PictureBox;
				if( box == null )
					continue;
				SItem item = mStats.GetItemFromName( imgNames[ i ] ).Clone() as SItem;
				if( item.Equals( SItem.Empty ) )
					continue;
				box.Image = Bitmap.FromStream( mAssembly.GetManifestResourceStream( "Ssc.Resources.EQ_" + imgNames[ i ] + ".png" ) );
			}
		}

		private void UpdateAll() {
			List<SItemBonus> list = mStats.GetAllBonus();
			Dictionary<EItemBonus, decimal> bonusList = new Dictionary<EItemBonus, decimal>();
			bonusList.Add( EItemBonus.Stärke, 0 );
			bonusList.Add( EItemBonus.Abwehr, 0 );
			bonusList.Add( EItemBonus.Intelligenz, 0 );
			bonusList.Add( EItemBonus.Weisheit, 0 );
			bonusList.Add( EItemBonus.Geschick, 0 );
			bonusList.Add( EItemBonus.Glück, 0 );
			
			bonusList.Add( EItemBonus.Verteidigung, 0 );
			bonusList.Add( EItemBonus.Resistenz, 0 );
			bonusList.Add( EItemBonus.SchadenMin, 0 );
			bonusList.Add( EItemBonus.SchadenMax, 0 );
			foreach( SItemBonus b in list )
				bonusList[ b.Type ] += b.Value;

			UpdatePoints();
			UpdateStatus( bonusList );
			UpdateLabel( mStats, bonusList );
		}

		private void UpdateLabel( SPlayerStatus state, Dictionary<EItemBonus, decimal> bonusList ) {
			if( state == null )
				state = mStats;

			cbClass.SelectedIndex = (int)state.Class;
			cbMode.SelectedIndex = (int)state.Mode;

			txtLevel.Text = state.Level.ToString();
			txtSTR.Text = state.STRAll.ToString();
			txtABW.Text = state.ABWAll.ToString();
			txtINT.Text = state.INTAll.ToString();
			txtWEI.Text = state.WEIAll.ToString();
			txtGES.Text = state.GESAll.ToString();
			txtGLU.Text = state.GLUAll.ToString();


			lblSTR.Text = bonusList[ EItemBonus.Stärke ] > 0 ? "+ " + (int)bonusList[ EItemBonus.Stärke ] : bonusList[ EItemBonus.Stärke ] < 0 ? "- " + ( (int)bonusList[ EItemBonus.Stärke ] * -1 ) : "";
			lblABW.Text = bonusList[ EItemBonus.Abwehr ] > 0 ? "+ " + (int)bonusList[ EItemBonus.Abwehr ] : bonusList[ EItemBonus.Abwehr ] < 0 ? "- " + ( (int)bonusList[ EItemBonus.Abwehr ] * -1 ) : "";
			lblINT.Text = bonusList[ EItemBonus.Intelligenz ] > 0 ? "+ " + (int)bonusList[ EItemBonus.Intelligenz ] : bonusList[ EItemBonus.Intelligenz ] < 0 ? "- " + ( (int)bonusList[ EItemBonus.Intelligenz ] * -1 ) : "";
			lblWEI.Text = bonusList[ EItemBonus.Weisheit ] > 0 ? "+ " + (int)bonusList[ EItemBonus.Weisheit ] : bonusList[ EItemBonus.Weisheit ] < 0 ? "- " + ( (int)bonusList[ EItemBonus.Weisheit ] * -1 ) : "";
			lblGES.Text = bonusList[ EItemBonus.Geschick ] > 0 ? "+ " + (int)bonusList[ EItemBonus.Geschick ] : bonusList[ EItemBonus.Geschick ] < 0 ? "- " + ( (int)bonusList[ EItemBonus.Geschick ] * -1 ) : "";
			lblGLÜ.Text = bonusList[ EItemBonus.Glück ] > 0 ? "+ " + (int)bonusList[ EItemBonus.Glück ] : bonusList[ EItemBonus.Glück ] < 0 ? "- " + ( (int)bonusList[ EItemBonus.Glück ] * -1 ) : "";
		}

		private void UpdatePoints() {
			int PointsEa = ( mStats.Mode == EGameMode.Ultimate ? 9 : mStats.Mode == EGameMode.Hart ? 7 : 5 );
			int PointsAll = PointsEa * int.Parse( txtLevel.Text.ToString() );
			mStatusUsed =
				(int)mStats.ABWPure + (int)mStats.GESPure + (int)mStats.GLUPure +
				(int)mStats.INTPure + (int)mStats.STRPure + (int)mStats.WEIPure;
			mStatusFree = ( PointsAll - mStatusUsed );

			lblPoints.ForeColor = ( mStatusFree < 0 ? Color.Red : Color.LimeGreen );
			lblPoints.Text = string.Format( "{0} / {1}", mStatusFree, PointsAll );
		}

		private void UpdateStatus( Dictionary<EItemBonus, decimal> bonusList ) {
			bonusList[ EItemBonus.Stärke ] += mStats.STR;
			bonusList[ EItemBonus.Abwehr ] += mStats.ABW;
			bonusList[ EItemBonus.Intelligenz ] += mStats.INT;
			bonusList[ EItemBonus.Weisheit ] += mStats.WEI;
			bonusList[ EItemBonus.Geschick ] += mStats.GES;
			bonusList[ EItemBonus.Glück ] += mStats.GLU;

			decimal atkBase;
			if( mStats.ItemWaffe == null || mStats.ItemWaffe.WeaponType != EWeaponType.Fernkampf ) {
				atkBase = ( bonusList[ EItemBonus.Stärke ] * 1.3m ) + ( ( 0.2m / 0.25m ) * bonusList[ EItemBonus.Geschick ] );
				lblANG.Text = ( atkBase + bonusList[ EItemBonus.SchadenMin ] ).ToString();
				lblANG.Text = ( atkBase + bonusList[ EItemBonus.SchadenMax ] ).ToString();
			} else {
				atkBase = ( bonusList[ EItemBonus.Stärke ] * 1.0m ) + ( mStats.GLU * 0.3m ) + ( ( 0.2m / 0.25m ) * bonusList[ EItemBonus.Geschick ] );
				lblANG.Text = ( atkBase + bonusList[ EItemBonus.SchadenMin ] ).ToString();
				lblANG.Text = ( atkBase + bonusList[ EItemBonus.SchadenMax ] ).ToString();
			}

			atkBase = ( 1.3m * mStats.INT ) + ( 0.2m * bonusList[ EItemBonus.Weisheit ] );
			lblMANG.Text = ( atkBase + bonusList[ EItemBonus.SchadenMin ] ).ToString();
			lblMANG.Text = ( atkBase + bonusList[ EItemBonus.SchadenMax ] ).ToString();

			lblDEF.Text = ( mStats.ABW + bonusList[ EItemBonus.Verteidigung ] ).ToString();
			lblRES.Text = ( bonusList[ EItemBonus.Weisheit ] + bonusList[ EItemBonus.Resistenz ] ).ToString();
			//lblHeilkraft.Text = ( bonusList[ EItemBonus.Weisheit ] * 2m ).ToString();
			//lblCritChance.Text = ( mStats.GLU / 5m ).ToString() + "%";
			//lblCritSchaden.Text = ( mStats.GLU * 0.75m ).ToString();
			lblHP.Text = ( mStats.ABW * 5m ).ToString();
			lblMP.Text = ( bonusList[ EItemBonus.Weisheit ] * 5m ).ToString();
			lblAP.Text = ( mStats.GES * 5m ).ToString();

		}


	}



	#region Program.Main
	static class Program {
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new frmMain() );
		}
	}
	#endregion

}
