using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

using Worker = Shaiya.Reader.API.Worker;


namespace Shaiya.Reader.Client {

	public partial class frmMain : Form {
		public static DateTime DateTimeZero = new DateTime( 1970, 1, 1 );
		public static string InstanceName = "game";

		public static bool ActiveTime = true;
		public static int LoopTime = 100;
		public static int LastEXP = 0;
		public static int EarnedEXP = 0;
		public static int KillCount = 0;
		public static PlayerStatus Status = new PlayerStatus();

		private string mLastCharName = string.Empty;
		private DateTime mStartTime = DateTime.Now;
		private DateTime mLastUpdate = DateTime.Now;
		private DateTime mPauseStart;
		private TimeSpan mPausedTimeSpan = TimeSpan.Zero;

		private BackgroundWorker mBackgroundWorker = new BackgroundWorker();

		private Shaiya.Reader.API.HotKey mHotkey = new Shaiya.Reader.API.HotKey();

		private Brush mBrushHP = Brushes.Red;
		private Brush mBrushMP = Brushes.Blue;
		private Brush mBrushAP = Brushes.Yellow;


		public frmMain() {
			InitializeComponent();

			InitializeHelper();
			InitializeWorker();

			// Warp Hack test
			mHotkey.KeyPressed += new EventHandler<Shaiya.Reader.API.HotKey.KeyPressedEventArgs>( mHotkey_HotKeyPressed );
			mHotkey.RegisterHotKey( Shaiya.Reader.API.HotKey.ModifierKeys.Control, Keys.X );
			mHotkey.RegisterHotKey( Shaiya.Reader.API.HotKey.ModifierKeys.Control, Keys.Y );
			mHotkey.RegisterHotKey( Shaiya.Reader.API.HotKey.ModifierKeys.Control, Keys.Z );

			if( Worker.AttachInstance( InstanceName ) == false ) {
				MessageBox.Show( "Der Shaiya Prozess konnte nicht gefunden werden!\nBitte starte Shaiya und dann klicke auf \"Attach\"" );

				btnAttach.Enabled = true;
				Status.Update();
				UpdateForm();
				return;
			}

			mBackgroundWorker.RunWorkerAsync();
		}

		private void mHotkey_HotKeyPressed( object sender, Shaiya.Reader.API.HotKey.KeyPressedEventArgs e ) {
			if( Worker.Level < 1 || frmMain.ActiveTime == false )
				return;

			switch( e.Key ) {
				case Keys.X:
					Worker.writeCharFloat( Shaiya.Reader.API.Constants.EOffsets.PositionX, Worker.PositionX + 10 );
					break;
				case Keys.Y:
					Worker.writeCharFloat( Shaiya.Reader.API.Constants.EOffsets.PositionY, Worker.PositionY + 10 );
					break;
				case Keys.Z:
					Worker.writeCharFloat( Shaiya.Reader.API.Constants.EOffsets.PositionZ, Worker.PositionZ + 10 );
					break;
			}

		}

		private void InitializeHelper() {
			DrawHelper.BorderPen = Pens.Black;
			DrawHelper.BrushStringBlack = Brushes.Black;
			DrawHelper.BrushStringWhite = Brushes.White;
			DrawHelper.Font = new Font( "Arial", 8f );
		}
		private void InitializeWorker() {
			mBackgroundWorker.WorkerReportsProgress = true;
			mBackgroundWorker.WorkerSupportsCancellation = true;
			mBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler( mBackgroundWorker_RunWorkerCompleted );
			mBackgroundWorker.ProgressChanged += new ProgressChangedEventHandler( mBackgroundWorker_ProgressChanged );
			mBackgroundWorker.DoWork += new DoWorkEventHandler( mBackgroundWorker_DoWork );
		}

		#region BackgroundWorker Methods
		private void mBackgroundWorker_DoWork( object sender, DoWorkEventArgs e ) {
			while( true ) {
				Worker.ReCache();
				Status.Update();

				mBackgroundWorker.ReportProgress( 0 );

				Thread.Sleep( frmMain.LoopTime );
			}
		}

		private void mBackgroundWorker_ProgressChanged( object sender, ProgressChangedEventArgs e ) {
			UpdateForm();
		}

		private void mBackgroundWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e ) {
			Status.Update();
			UpdateForm();
		}
		#endregion

		#region Menu Events
		private void ProgramSettingsUpdateIntervalInput_TextChanged( object sender, EventArgs e ) {
			int test = 100;
			if( int.TryParse( ProgramSettingsUpdateIntervalInput.Text, out test ) == false || test < 100 ) {
				ProgramSettingsUpdateIntervalInput.Text = "100";
				return;
			}
			Properties.Settings.Default.UpdateInterval = ProgramSettingsUpdateIntervalInput.Text;
			frmMain.LoopTime = int.Parse( Properties.Settings.Default.UpdateInterval );
		}
		#endregion

		#region Button Actions
		private void btnStop_Click( object sender, EventArgs e ) {
			mBackgroundWorker.CancelAsync();
			this.Close();
		}

		private void btnAttach_Click( object sender, EventArgs e ) {
			if( Worker.AttachInstance( frmMain.InstanceName ) == false ) {
				MessageBox.Show( "Der Shaiya Prozess konnte nicht gefunden werden!\nBitte starte Shaiya und dann klicke auf \"Attach\"" );

				btnAttach.Enabled = true;
				return;
			}

			mStartTime = DateTime.Now;
			btnAttach.Enabled = false;
			mBackgroundWorker.RunWorkerAsync();
		}

		private void btnPause_Click( object sender, EventArgs e ) {
			if( frmMain.ActiveTime == false ) {
				TimeSpan span = DateTime.Now - mPauseStart;
				mPausedTimeSpan += span;

				btnReset.Enabled = true;
				btnPause.Text = "Pause";
				frmMain.ActiveTime = true;
				return;
			}

			btnReset.Enabled = false;
			btnPause.Text = "Start";
			frmMain.ActiveTime = false;
			mPauseStart = DateTime.Now;
		}

		private void btnReset_Click( object sender, EventArgs e ) {
			mPausedTimeSpan = TimeSpan.Zero;
			mStartTime = DateTime.Now;
			LastEXP = 0;
			EarnedEXP = 0;
			KillCount = 0;
			Status = new PlayerStatus();

			lblExpProMin.Text = "0";
			lblExpProStunde.Text = "0";
			lblExpProKill.Text = "0";
			lblTimeTillUp.Text = "0";

		}

		private void btnLogin_Click( object sender, EventArgs e ) {
			frmLogin frm = new frmLogin();
			if( frm.ShowDialog() != DialogResult.OK )
				return;

			PlayerStatus.ForumUsername = FinalSoftware.MySql.HelperCrypt.Decrypt( Properties.Settings.Default.ForumUsername );
			PlayerStatus.ForumPassword = FinalSoftware.MySql.HelperCrypt.Decrypt( Properties.Settings.Default.ForumPassword );

			if( Status.SqlUpdate() == 0 ) {
				MessageBox.Show( "Der Forum-Account konnte nicht bestätigt werden!" );
				return;
			}

			lblSqlStatus.ForeColor = Color.Maroon;
			lblSqlStatus.Text = "<nicht im Spiel eingelogged>";
			btnLogin.Enabled = false;
		}
		#endregion






		private void UpdateForm() {
			RedrawBars();

			if( Worker.IsActive() == false ) {
				// try re-attach
				Worker.AttachInstance( frmMain.InstanceName );
				if( Worker.IsActive() == false ) {
					lblSqlStatus.Text = "<nicht im Spiel eingelogged>";
					lblSqlStatus.ForeColor = Color.Maroon;
					return;
				}
			}
			if( frmMain.ActiveTime == false )
				return;


			btnPause.Enabled = true;
			lblSqlStatus.ForeColor = Color.ForestGreen;

			TimeSpan time = DateTime.Now - mStartTime - mPausedTimeSpan;
			UpdateLabels( time );
		}

		private void UpdateLabels( TimeSpan ExpTimeSpan ) {
			int neededExp = ( Status.ExpMax - Status.Exp );

			lblLevel.Text = Status.Level.ToString();
			lblName.Text = Status.Name;

			lblStatusAbw.Text = Status.StatusAbw.ToString();
			lblStatusGes.Text = Status.StatusGes.ToString();
			lblStatusGlu.Text = Status.StatusGlu.ToString();
			lblStatusInt.Text = Status.StatusInt.ToString();
			lblStatusStr.Text = Status.StatusStr.ToString();
			lblStatusWei.Text = Status.StatusWei.ToString();

			lblPos.Text = Status.Position.ToString();

			lblExpBisUp.Text = neededExp.ToString( "0,0" );
			lblExpLastKill.Text = Status.ExpLastKill.ToString();
			lblRuntime.Text = ExpTimeSpan.Hours.ToString( "00" ) + ":" + ExpTimeSpan.Minutes.ToString( "00" ) + ":" + ExpTimeSpan.Seconds.ToString( "00" );

			if( EarnedEXP > 0 )
				UpdateEXP( ExpTimeSpan, neededExp );

			// logged in and still Active Game?
			if( btnLogin.Enabled == false && Worker.IsActive() == true )
				UpdateSQL();
			else if( btnLogin.Enabled == true ) {
				lblSqlStatus.Text = "<bitte erst Login klicken>";
				lblSqlStatus.ForeColor = Color.Maroon;
			}

		}

		private void UpdateEXP( TimeSpan ExpTimeSpan, int neededExp ) {
			TimeSpan timeTillUp = new TimeSpan( 0, 0, (int)( (double)neededExp / ( (double)EarnedEXP / ExpTimeSpan.TotalSeconds ) ) );
			lblExpProMin.Text = ( (double)EarnedEXP / ExpTimeSpan.TotalMinutes ).ToString( "0.00" );
			lblExpProStunde.Text = ( (double)EarnedEXP / ExpTimeSpan.TotalHours ).ToString( "0.00" );
			lblExpProKill.Text = ( (double)EarnedEXP / (double)KillCount ).ToString( "0.00" );
			if( timeTillUp.TotalDays >= 1 )
				lblTimeTillUp.Text = timeTillUp.Days.ToString( "00" ) + ":" + timeTillUp.Hours.ToString( "00" ) + ":" + timeTillUp.Minutes.ToString( "00" ) + " (dd:hh:mm)";
			else if( timeTillUp.TotalHours >= 1 )
				lblTimeTillUp.Text = timeTillUp.Hours.ToString( "00" ) + ":" + timeTillUp.Minutes.ToString( "00" ) + " (hh:mm)";
			else
				lblTimeTillUp.Text = timeTillUp.Minutes.ToString( "0" ) + " min, " + timeTillUp.Seconds.ToString( "0" ) + " sec";
		}

		private void UpdateSQL() {
			if( mLastCharName != Worker.Name || ( DateTime.Now - mLastUpdate ).TotalMinutes >= 10 ) {
				mLastUpdate = DateTime.Now;
				mLastCharName = Worker.Name;
				Status.SqlUpdate();
			} else {
				TimeSpan sqlUpdateTime = mLastUpdate.AddMinutes( 10 ) - DateTime.Now;
				lblSqlStatus.Text = "T -" + sqlUpdateTime.Minutes.ToString( "00" ) + ":" + sqlUpdateTime.Seconds.ToString( "00" );
			}
		}

		private void RedrawBars() {
			imageHPBar.Image = DrawHelper.Drawbar( imageHPBar.Width, imageHPBar.Height, Status.HP, Status.HPMax, mBrushHP );
			imageMPBar.Image = DrawHelper.Drawbar( imageMPBar.Width, imageMPBar.Height, Status.MP, Status.MPMax, mBrushMP );
			imageAPBar.Image = DrawHelper.Drawbar( imageAPBar.Width, imageAPBar.Height, Status.AP, Status.APMax, mBrushAP );
		}

	}

	#region Program.Main()
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
