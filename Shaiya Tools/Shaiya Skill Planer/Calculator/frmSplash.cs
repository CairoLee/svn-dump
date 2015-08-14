using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shaiya_Skill_Ressources.Structs;
using Shaiya_Skill_Ressources;
using System.Reflection;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace Ssc {

	public partial class frmSplash : Form {
		private int mFinalClose = 0;
		private int mCurrentStep = 0;

		private BackgroundWorker mWorker;
		private Timer mTimer = new Timer();


		public frmSplash( int MilliSec ) {
			InitializeComponent();

			Opacity = 0;
			mFinalClose = MilliSec;
			mTimer.Interval = 100;
			mTimer.Tick += new EventHandler( mTimer_Tick );

			mWorker = new BackgroundWorker();
			mWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler( worker_RunWorkerCompleted );
			mWorker.DoWork += new DoWorkEventHandler( worker_DoWork );
			mWorker.RunWorkerAsync();
		}

		#region BackgroundWorker
		private void worker_DoWork( object sender, DoWorkEventArgs e ) {
			List<string> classNames = new List<string>( Enum.GetNames( typeof( EClass ) ) );
			string baseDir = AppDomain.CurrentDomain.BaseDirectory + frmMain.EmbeddedSkillFile;

			classNames.RemoveAt( 0 ); // __start
			classNames.RemoveAt( classNames.Count - 1 ); // __end

			// set Assembly, so we may load the Icon too
			Skill.MainAssembly = Assembly.GetAssembly( typeof( Shaiya_Skill_Ressources.Dummy ) );
			
			// load all SkillList's
			for( int i = 0; i < classNames.Count; i++ ) {
				EClass c = (EClass)Enum.Parse( typeof( EClass ), classNames[ i ] );
				frmMain.SkillListDict.Add( c, SkillList.Load( string.Format( baseDir, classNames[ i ] ) ) );
				frmMain.SkillListDict[ c ].LoadIcons();
			}

		}

		private void worker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e ) {
			mCurrentStep = mFinalClose - 500; // fake time, for proper closing fade
		}
		#endregion


		private void frmSplash_Load( object sender, EventArgs e ) {
			mTimer.Start();
		}

		private void mTimer_Tick( object sender, EventArgs e ) {
			mCurrentStep += mTimer.Interval;
			if( mWorker.IsBusy == false && ( mFinalClose - mCurrentStep ) <= 500 )
				this.Opacity -= 0.2f;
			else if( this.Opacity < 1 )
				this.Opacity += 0.1f;

			if( mCurrentStep < mFinalClose )
				return;

			if( mWorker.IsBusy == true )
				return;

			mTimer.Stop();
			this.Close();
		}

	}

}
