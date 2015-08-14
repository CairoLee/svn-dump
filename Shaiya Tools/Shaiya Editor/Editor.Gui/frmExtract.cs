using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Editor.Gui {

	public partial class frmExtract : Form {
		private string mFlatName;
		private string mRootDir;
		private Editor.Lib.ShaiyaData mData;

		private BackgroundWorker mWorker = new BackgroundWorker();
		private int mFileCount = 0;
		private int mFileTodo = 0;

		public frmExtract( string FlatName, string RootDir, Editor.Lib.ShaiyaData Data ) {
			InitializeComponent();

			mFlatName = FlatName;
			mRootDir = RootDir;
			mData = Data;
		}


		private void frmExtract_Load( object sender, EventArgs e ) {
			if( mFlatName == string.Empty ) { // root
				foreach( Editor.Lib.ShaiyaDataEntry entry in mData.Files )
					mFileTodo += mData.GetFileCount( entry );
			} else
				mFileTodo = mData.GetFileCount( mData.GetFlatEntry( mFlatName ) );

			mWorker.WorkerReportsProgress = true;
			mWorker.WorkerSupportsCancellation = true;
			mWorker.DoWork += new DoWorkEventHandler( mWorker_DoWork );
			mWorker.ProgressChanged += new ProgressChangedEventHandler( mWorker_ProgressChanged );
			mWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler( mWorker_RunWorkerCompleted );
			mWorker.RunWorkerAsync();
		}

		private void frmExtract_FormClosing( object sender, FormClosingEventArgs e ) {
			if( mWorker != null && mWorker.IsBusy == true ) {
				if( MessageBox.Show( "Ein Entpack-Vorgang ist noch nicht beendet!\nMöchtest du trotzdem Beenden?", "Beenden?", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No ) {
					e.Cancel = true;
					return;
				}
				mWorker.CancelAsync();
			}
		}


		private void mWorker_DoWork( object sender, DoWorkEventArgs e ) {
			if( mFlatName == string.Empty ) // root node
				for( int i = 0; i < mData.Files.Count; i++ )
					Extract( mData.Files[ i ].ID, mRootDir );
			else
				Extract( mFlatName, mRootDir );
		}

		private void mWorker_ProgressChanged( object sender, ProgressChangedEventArgs e ) {
			try {
				mFileCount++;
				if( mFileTodo > 0 )
					progressStatus.Value = Math.Min( 100, ( mFileCount * 100 ) / mFileTodo );
				else
					progressStatus.Value = 0;
				lblStatus.Text = string.Format( "Datei {0}/{1} ({2:00.00}%)", mFileCount, mFileTodo, ( (double)mFileCount / (double)mFileTodo ) * 100 );
			} catch( Exception ex ) {
				System.Diagnostics.Debug.WriteLine( ex );
			}
		}

		private void mWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e ) {
			this.Close();
		}


		private void Extract( string FlatName, string RootDir ) {
			try {
				Editor.Lib.ShaiyaDataEntry entry = mData.GetFlatEntry( FlatName );
				if( entry == null )
					return;

				if( entry.IsDir == true ) {
					for( int i = 0; i < entry.Entrys.Count; i++ )
						Extract( entry.Entrys[ i ].ID, RootDir );
					return;
				}

				byte[] buffer;
				mData.GetData( entry, out buffer );


				string dataDir = mData.GetRootDir( entry );
				string saveInDir = Path.Combine( RootDir, dataDir ) + @"\" + entry.Filename;
				Directory.CreateDirectory( Path.GetDirectoryName( saveInDir ) );
				File.WriteAllBytes( saveInDir, buffer );

				mWorker.ReportProgress( 0 );

				entry = null;
				buffer = null;
			} catch( Exception ex ) {
				System.Diagnostics.Debug.WriteLine( ex );
			}
		}

	}

}
