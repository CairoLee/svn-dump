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

using Sbt.Compontents;
using Sbt.Structs;
using System.Drawing.Drawing2D;
using OverlayLib;

namespace Sbt {

	public partial class frmMain : Form {
		public static frmMain FormInstance = null;

		private SBossList mBossList = new SBossList();
		private OverlayRender mOverlay;
		private Dictionary<string, BossPanel> mActivePanels = new Dictionary<string,BossPanel>();
		private bool mSaveOverlay = false;


		public frmMain() {
			InitializeComponent();

			if( FormInstance == null )
				FormInstance = this;
		}

		#region Form Events
		private void frmMain_Load( object sender, EventArgs e ) {
			// 1.3 - by GodLesZ 4 Blubb Gaming
			System.Reflection.Assembly Asm = System.Reflection.Assembly.GetExecutingAssembly();
			this.Text += " v" + string.Format( "{0}.{1}", Asm.GetName().Version.Major, Asm.GetName().Version.Minor );
			this.Text += " - by GodLesZ 4 Blubb Gaming";

			if( Properties.Settings.Default.LastList != string.Empty && File.Exists( Properties.Settings.Default.LastList ) )
				LoadList( Properties.Settings.Default.LastList );

			if( Properties.Settings.Default.OverlayActive == true )
				OverlayInitialize();
		}

		private void frmMain_FormClosing( object sender, FormClosingEventArgs e ) {
			Properties.Settings.Default.Save();
			OverlayDestroy();
			trayIco.Dispose();
		}

		private void frmMain_Resize( object sender, EventArgs e ) {
			if( FormWindowState.Minimized == WindowState )
				Hide();
		}

		private void notifyIcon1_DoubleClick( object sender, EventArgs e ) {
			Show();
			WindowState = FormWindowState.Normal;
		}
		#endregion

		#region Menu Events
		private void MenuProgramOpenList_Click( object sender, EventArgs e ) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Xml Boss Liste (*.xml)|*.xml";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			LoadList( dlg.FileName );
		}

		private void MenuProgramClose_Click( object sender, EventArgs e ) {
			this.Close();
		}

		private void MenuSettingsPlaySound_Click( object sender, EventArgs e ) {
			Properties.Settings.Default.PlaySound = !Properties.Settings.Default.PlaySound;
		}

		private void MenuSettingsTimerPerRowInput_TextChanged( object sender, EventArgs e ) {
			int perRow = 0;
			if( int.TryParse( MenuSettingsTimerPerRowInput.Text, out perRow ) == false || perRow < 1 || perRow > 15 ) {
				MessageBox.Show( "Das willst du nich wirklich...", "Fehler.." );
				MenuSettingsTimerPerRowInput.Text = "7";
			}

			Properties.Settings.Default.TimerPerRow = MenuSettingsTimerPerRowInput.Text;

			if( Properties.Settings.Default.LastList != string.Empty && File.Exists( Properties.Settings.Default.LastList ) )
				LoadList( Properties.Settings.Default.LastList );
		}

		private void MenuSettingsTimerWidth_TextChanged( object sender, EventArgs e ) {
			Properties.Settings.Default.TimerWidth = MenuSettingsTimerWidth.Text;
			if( Properties.Settings.Default.LastList != string.Empty && File.Exists( Properties.Settings.Default.LastList ) )
				LoadList( Properties.Settings.Default.LastList );
		}

		private void MenuSettingsOverlaySettings_Click( object sender, EventArgs e ) {
			frmOverlaySetting frm = new frmOverlaySetting();
			frm.OnOverlayChanged += delegate( bool Active, int X, int Y ) {
				if( Active == false )
					OverlayDestroy();
				else {
					if( mOverlay == null )
						OverlayInitialize();
					if( mOverlay != null )
						mOverlay.Position = new Point( X, Y );
				}
			};
			if( frm.ShowDialog() != DialogResult.OK ) {
				OverlayDestroy();
				return;
			}
		}

		private void MenuProgramSaveOverlay_Click( object sender, EventArgs e ) {
			mSaveOverlay = true;
		}
		#endregion

		#region System Tray Events
		private void trayIcon_MouseClick( object sender, MouseEventArgs e ) {
			if( e.Button != MouseButtons.Right )
				return;

			UpdateInfoText();
		}
		private void trayIcon_MouseMove( object sender, MouseEventArgs e ) {
			UpdateInfoText();
		}

		private void UpdateInfoText() {
			string infoText = "Shaiya Boss Timer";
			for( int i = 0; i < panelBossList.Controls.Count; i++ ) {
				BossPanel p = panelBossList.Controls[ i ] as BossPanel;
				if( p.TimerActive == false )
					continue;

				infoText += "\n" + p.lblName.Text + ": " + p.lblTime.Text;
			}

			if( infoText.Length > 63 ) {
				infoText = infoText.Substring( 0, 60 ) + "...";
			}
			trayIco.Text = infoText;
		}
		#endregion



		public void SetStatus( string Text ) {
			lblStatus.Text = Text;
		}

		private void LoadList( string Filename ) {
			Properties.Settings.Default.LastList = Filename;
			panelBossList.Controls.Clear();

			try {
				XmlSerializer xml = new XmlSerializer( typeof( SBossList ) );
				using( FileStream fs = File.OpenRead( Filename ) )
					mBossList = xml.Deserialize( fs ) as SBossList;
			} catch( Exception e ) {
				System.Diagnostics.Debug.WriteLine( e );
			}

			int perRow = int.Parse( Properties.Settings.Default.TimerPerRow );
			int pad = 10;
			int column = 0, row = 0, maxRow = 0;
			int panelWidth = 0;
			for( int i = 0; i < mBossList.Count; i++ ) {
				if( ( i - ( column * perRow ) ) == perRow ) {
					column++;
					row = 0;
				}

				BossPanel p = new BossPanel( mBossList[ i ], int.Parse( Properties.Settings.Default.TimerWidth ) );
				p.Location = new Point( 10 + ( column * ( p.Width + 10 ) ), ( p.Height * row ) + ( pad * row ) );
				panelWidth = p.Width;

				panelBossList.Controls.Add( p );

				maxRow = Math.Max( maxRow, ++row );
			}

			// set Window Height
			column++;
			Size = new Size( 15 + ( column * ( panelWidth + 10 ) ), 90 + ( maxRow * ( 30 + pad ) ) );

		}

		public void AddPanel( BossPanel p ) {
			if( mActivePanels.ContainsKey( p.lblName.Text ) == true )
				return;

			mActivePanels.Add( p.lblName.Text, p );
		}

		public void DelPanel( BossPanel p ) {
			if( mActivePanels.ContainsKey( p.lblName.Text ) == false )
				return;

			mActivePanels.Remove( p.lblName.Text );
		}

		private void OverlayInitialize() {
			OverlayDestroy();
			mOverlay = new OverlayRender( new Point( (int)Properties.Settings.Default.OverlayX, (int)Properties.Settings.Default.OverlayY ), new Size( 280, 30 ), 1000 );
			mOverlay.TimerTick = Overlay_TimerTick;
			mOverlay.OnRender = Overlay_OnRender;
		}

		private void OverlayDestroy() {
			try {
				if( mOverlay != null )
					mOverlay.Dispose();
			} catch { }
		}



		private Font mRenderFont = new Font( "Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.World );
		private void Overlay_TimerTick( object sender, EventArgs args ) {
			if( mActivePanels.Count == 0 )
				return;

			try {
				int timerWidth = int.Parse( Properties.Settings.Default.TimerWidth );
				Size s = new Size( 280, 10 + ( mActivePanels.Count * 20 ) );
				if( mOverlay.Size != s )
					mOverlay.Size = s;
			} catch {
			}
		}

		private void Overlay_OnRender( Graphics g ) {
			if( mActivePanels.Count == 0 ) {
				g.Clear( Color.Black );
				return;
			}

			try {
				g.Clear( Color.Gray );
				// fake trans, ugly
				//g.InterpolationMode = InterpolationMode.High;
				//g.SmoothingMode = SmoothingMode.AntiAlias;
				//g.CopyFromScreen( mOverlay.Boundings.Location, Point.Empty, mOverlay.Boundings.Size, CopyPixelOperation.SourceCopy );

				int i = 0;
				foreach( BossPanel p in mActivePanels.Values ) {
					Point basePoint = new Point( 5, 5 + ( i++ * 20 ) );

					g.DrawString( p.lblName.Text, mRenderFont, Brushes.LightSkyBlue, basePoint );
					basePoint.X += (int)g.MeasureString( p.lblName.Text, mRenderFont ).Width;

					g.DrawString( p.lblTime.Text, mRenderFont, Brushes.White, basePoint );
				}

				if( mSaveOverlay == true )
					SaveOverlay();

			} catch {
			}
		}

		private void SaveOverlay() {
			mSaveOverlay = false;
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "PNG Image|*.png";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;
			mOverlay.RenderTarget.Save( dlg.FileName );
		}


	}






	#region Program.Main
	public static class Program {
		[STAThread]
		public static void Main() {
			Updater.Library.UpdateHandler uHandler = new Updater.Library.UpdateHandler();
			if( uHandler.CheckVersion( System.Reflection.Assembly.GetExecutingAssembly(), "http://shaiya-obscura.dz-net.net/updates/bosstimer/" ) == true && uHandler.StartUpdate() == true )
				return;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new frmMain() );
		}
	}
	#endregion

}
