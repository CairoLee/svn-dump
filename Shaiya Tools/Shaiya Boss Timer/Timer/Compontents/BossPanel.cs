using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sbt.Structs;

namespace Sbt.Compontents {

	public partial class BossPanel : UserControl {
		public static Font FontBase = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0 );
		public static Font FontAlert = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0 );
		public static Color ColorBase = Color.Black;
		public static Color ColorAlert = Color.Red;
		public static System.Media.SoundPlayer SoundPlayer = new System.Media.SoundPlayer( Properties.Resources.BossPing );

		public event BossTimerTimeoutHandler BossTimerTimeout;

		public bool TimerActive {
			get { return mBossTimer.Enabled; }
		}

		private SBoss mBoss;
		private Timer mBossTimer;
		private TimeSpan mTimeSpan;
		private int mBossTimerTicks;
		private int mBossTimerTicksToDo;

		public BossPanel( SBoss Boss, int Width ) {
			int defaultPanelWidth = 218;

			InitializeComponent();

			if( defaultPanelWidth != Width ) {
				int diff = Width - defaultPanelWidth;

				this.Size = new Size( this.Size.Width + diff, this.Size.Height );
				btnReset.Location = new Point( btnReset.Location.X + diff, btnReset.Location.Y );
				lblName.Size = new Size( lblName.Size.Width + diff, lblName.Size.Height );
			}
			
			mBoss = Boss;

			mBossTimerTicks = 0;
			mBossTimerTicksToDo = (int)mBoss.RespawnTimeSpan.TotalSeconds;

			mBossTimer = new Timer();
			mBossTimer.Interval = 1000;
			mBossTimer.Tick += new EventHandler( BossTimer_Tick );

			UpdateLabel();
		}


		private void BossTimer_Tick( object sender, EventArgs e ) {
			mBossTimerTicks++;
			UpdateLabel();
			if( mBossTimerTicks < mBossTimerTicksToDo )
				return;

			// Reset Timer
			btnReset_Click( null, EventArgs.Empty ); // PerformClick() dos not trigger in System Tray
			// call Callback
			OnBossTimerTimeout();
		}

		protected virtual void OnBossTimerTimeout() {
			if( Properties.Settings.Default.PlaySound == true )
				BossPanel.SoundPlayer.Play();

			if( BossTimerTimeout != null )
				BossTimerTimeout( mBoss );
		}

		private void btnReset_Click( object sender, EventArgs e ) {
			// no Timer running?
			if( mBossTimerTicks == 0 ) {
				btnReset.Text = "Stop";
				SetFontBase();

				mBossTimerTicks = 0;
				mBossTimerTicksToDo = (int)mBoss.RespawnTimeSpan.TotalSeconds;

				UpdateLabel();
				lblName.ForeColor = Color.DarkBlue;
				mBossTimer.Enabled = true;
				mBossTimer.Start();

				frmMain.FormInstance.AddPanel( this );
				return;
			}

			// stop running Timer
			lblName.ForeColor = Color.Black;
			mBossTimerTicks = 0;
			btnReset.Text = "Starten";
			mBossTimer.Enabled = false;
			mBossTimer.Stop();

			frmMain.FormInstance.DelPanel( this );
		}

		private void lblTime_Click( object sender, EventArgs e ) {
			if( mBossTimer.Enabled == false )
				return;

			frmTimerEdit frm = new frmTimerEdit();
			if( frm.ShowDialog() != DialogResult.OK )
				return;

			TimeSpan sub = new TimeSpan( (int)frm.numDay.Value,(int)frm.numHour.Value,(int)frm.numMin.Value,(int)frm.numSec.Value );
			if( frm.cbMode.SelectedIndex == 0 )
				mBossTimerTicks = Math.Min( mBossTimerTicksToDo, mBossTimerTicks + (int)sub.TotalSeconds );
			else
				mBossTimerTicks = Math.Max( 0, mBossTimerTicks - (int)sub.TotalSeconds );
		}





		private void UpdateLabel() {
			mTimeSpan = mBoss.RespawnTimeSpan.Subtract( new TimeSpan( 0, 0, mBossTimerTicks ) );
			lblName.Text = mBoss.Name;
			lblTime.Text = string.Format( "{0:00}:{1:00}:{2:00}:{3:00}", mTimeSpan.Days, mTimeSpan.Hours, mTimeSpan.Minutes, mTimeSpan.Seconds );

			if( mTimeSpan.TotalSeconds < 60 ) {
				if( mTimeSpan.TotalSeconds > 30 && ( mTimeSpan.TotalSeconds % 2 ) == 0 )
					SetFontAlert();
				else if( mTimeSpan.TotalSeconds <= 30 )
					SetFontAlert();
				else
					SetFontBase();
			} else
				SetFontBase();
		}

		private void SetFontBase() {
			lblTime.Font = BossPanel.FontBase;
			lblTime.ForeColor = BossPanel.ColorBase;
		}

		private void SetFontAlert() {
			lblTime.Font = BossPanel.FontAlert;
			lblTime.ForeColor = BossPanel.ColorAlert;
		}

	}

	public delegate void BossTimerTimeoutHandler( SBoss Boss );

}
