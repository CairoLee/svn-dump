using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Healbot.Library;

namespace Healbot {
	/*
		Position:	21/30
		Farbe:		#A4435E
		leer:		#0F0F0F

		Next:		21/82
	*/

	public partial class frmMain : Form {
		public static Color ColorHPFull = "#A4435E".HexToColor();
		public static Color ColorHPEmpty = "#0F0F0F".HexToColor();
		public static bool ShowDebug = false;
		public static bool Paused = false;

		private BackgroundWorker mWorker;
		private PixelSearch mPixelSearch = new PixelSearch( new Size( 0, 0 ) );

		public frmMain() {
			InitializeComponent();

			mWorker = new BackgroundWorker();
			mWorker.WorkerReportsProgress = true;
			mWorker.WorkerSupportsCancellation = true;
			mWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler( mWorker_RunWorkerCompleted );
			mWorker.ProgressChanged += new ProgressChangedEventHandler( mWorker_ProgressChanged );
			mWorker.DoWork += new DoWorkEventHandler( mWorker_DoWork );

			AddLog( "ready to Rumble!" );
		}

		#region Form Events
		private void frmMain_FormClosing( object sender, FormClosingEventArgs e ) {
			Paused = true;
			if( mWorker != null && mWorker.IsBusy )
				mWorker.CancelAsync();
		} 
		#endregion

		#region BackgroundWorker
		private void mWorker_DoWork( object sender, DoWorkEventArgs e ) {
			PixelInfo info = new PixelInfo();
			List<Bitmap> images = new List<Bitmap>();

			while( true ) {
				if( Paused == true )
					break;

				images.Clear();
				for( int i = 0; i < 7; i++ ) {
					images.Add( PixelSearch.CaptureScreenRegion( new Rectangle( 21, 30 + ( i * 52 ), 120, 5 ) ).Clone() as Bitmap );
					Color col = images[ i ].GetPixel( 0, 0 );
					if( col != ColorHPFull && col != ColorHPEmpty )
						images[ i ] = null;
				}

				mWorker.ReportProgress( 0, images );

				System.Threading.Thread.Sleep( 250 );
			}
		}
		private void mWorker_ProgressChanged( object sender, ProgressChangedEventArgs e ) {
			List<Bitmap> images = e.UserState as List<Bitmap>;
			Label lbl;
			PictureBox pic;

			for( int i = 0; i < images.Count; i++ ) {
				lbl = this.Controls[ "lblColor" + ( i + 1 ) ] as Label;
				pic = this.Controls[ "imgParty" + ( i + 1 ) ] as PictureBox;

				pic.Image = images[ i ];
				if( images[ i ] == null ) {
					lbl.Text = "";
					continue;
				}

				int hp = 0;
				for( ; hp < images[ i ].Width; hp++ )
					if( images[ i ].GetPixel( hp, 0 ) == ColorHPEmpty )
						break;

				string text = (int)( hp / ( (float)images[ i ].Width / 100f ) ) + "%";
				if( lbl.Text != text )
					lbl.Text = text;

				// check for Heal
				CheckHP( i + 1, int.Parse( text.Substring( 0, text.Length - 1 ) ) );
			}
		}
		private void mWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e ) {

		} 
		#endregion

		#region Menu Events
		private void MenuProgramExit_Click( object sender, EventArgs e ) {
			this.Close();
		}

		private void MenuSettingsHealsettings_Click( object sender, EventArgs e ) {
			frmHealsettings frm = new frmHealsettings();
			frm.ShowDialog();
		}

		private void MenuSettingsShowDebug_Click( object sender, EventArgs e ) {
			ShowDebug = !ShowDebug;
			AddLog( "Debug-Hinweise " + ( !ShowDebug ? "deaktiviert" : "aktiviert" ) );
		}
		#endregion

		#region Start/Stop
		private void btnRun_Click( object sender, EventArgs e ) {
			if( btnRun.Text == "Run" ) {
				btnRun.Text = "Pause";
				Paused = false;
				mWorker.RunWorkerAsync();

				AddLog( "Healbot started" );
				return;
			}

			btnRun.Text = "Run";
			mWorker.CancelAsync();
			Paused = true;

			AddLog( "Healbot paused" );
		}
		#endregion




		private void CheckHP( int PlayerNum, int HPValue ) {
			int settingVal = (int)( (decimal)Properties.Settings.Default.PropertyValues[ "HealPlayer" + PlayerNum ].PropertyValue );
			if( HPValue > settingVal )
				return;

			//AutoItX.MouseMove( 30, 30 + ( ( PlayerNum - 1 ) * 52 ), 3 );
			AutoItX.MouseClick( "left", 30, 30 + ( ( PlayerNum - 1 ) * 52 ), 2, 20 ); // 2 Clicks, Movespeed 20
			AutoItX.Send( "1", 1 ); // Mode 1 [raw], assume Heal on Slot 1

			AddLog( "healing Player " + PlayerNum + ", " + HPValue + "/" + settingVal + " HP" );
		}

		private void AddLog( string Log ) {
			txtLog.AppendText( "[" + DateTime.Now.ToString( "HH:mm:ss" ) + "] " + Log + "\r\n" );
		}

	}



	#region Program.Main
	static class Program {
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new frmMain() );
		}
	}
	#endregion

}
