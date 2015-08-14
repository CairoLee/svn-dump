using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace ShaiyaMonsterMap {

	public partial class frmSplash : Form {
		private int mFinalClose = 0;
		private int mCurrentStep = 0;

		private Timer mTimer = new Timer();

		public frmSplash( int MilliSec ) {
			InitializeComponent();

			this.Cursor = frmMain.ShaiyaCursor;
			Opacity = 0;
			mFinalClose = MilliSec;
			mTimer.Interval = 100;
			mTimer.Tick += new EventHandler( mTimer_Tick );
		}


		private void frmSplash_Load( object sender, EventArgs e ) {
			mTimer.Start();
		}

		private void mTimer_Tick( object sender, EventArgs e ) {
			mCurrentStep += mTimer.Interval;
			if(( mFinalClose - mCurrentStep ) <= 500 )
				this.Opacity -= 0.2f;
			else if( this.Opacity < 1 )
				this.Opacity += 0.1f;

			if( mCurrentStep < mFinalClose )
				return;

			mTimer.Stop();
			this.Close();
		}

	}

}
