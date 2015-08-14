using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Editor.Lib;

namespace Editor.Gui {

	public partial class frmRepack : Form {
		private string mSavePath;
		private Editor.Lib.ShaiyaData mData;

		private BackgroundWorker mWorker = new BackgroundWorker();
		private int mFileCount = 0;
		private int mFileTodo = 0;
		private EPackType mPackType;

		public frmRepack( EPackType PackType, string SavePath, ShaiyaData Data ) {
			InitializeComponent();

			mPackType = PackType;
			if( mPackType == EPackType.SaveUpdates )
				this.Text = "Daten speichern...";
			else
				this.Text = "Daten neu packen...";

			mSavePath = SavePath;
			mData = Data;
		}


		private void frmExtract_Load( object sender, EventArgs e ) {
			mFileTodo = mData.FilesFlat.Count;

			mWorker.WorkerReportsProgress = true;
			mWorker.WorkerSupportsCancellation = true;
			mWorker.DoWork += new DoWorkEventHandler( mWorker_DoWork );
			mWorker.ProgressChanged += new ProgressChangedEventHandler( mWorker_ProgressChanged );
			mWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler( mWorker_RunWorkerCompleted );
			mWorker.RunWorkerAsync();
		}

		private void frmExtract_FormClosing( object sender, FormClosingEventArgs e ) {
			if( mWorker == null || mWorker.IsBusy == false )
				return;

			if( MessageBox.Show( "Ein Speichervorgang ist noch nicht beendet!\nMöchtest du trotzdem Beenden?", "Beenden?", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No ) {
				e.Cancel = true;
				return;
			}
			mWorker.CancelAsync();
		}



		private void mWorker_DoWork( object sender, DoWorkEventArgs e ) {
			if( mPackType == EPackType.RepackAll )
				mData.Repack( mSavePath, OnWriteFile );
			else
				mData.Save( OnWriteFile );
		}

		private void OnWriteFile( ShaiyaDataEntry Entry, int Num ) {
			if( Entry == null || Num == 100 ) {
				mWorker.CancelAsync();
				return;
			}

			mFileCount++;
			mWorker.ReportProgress( 0, Entry );
		}

		private void mWorker_ProgressChanged( object sender, ProgressChangedEventArgs e ) {
			ShaiyaDataEntry Entry = e.UserState as ShaiyaDataEntry;

			if( mPackType == EPackType.SaveUpdates ) {
				lblStatus.Text = string.Format( "Saving {0}", Entry.Filename );
				return;
			}

			try {
				progressStatus.Value = Math.Min( 100, ( mFileCount * 100 ) / mFileTodo );
				lblStatus.Text = string.Format( "[{0}/{1}] {2} ({3:00.00}%)", mFileCount, mFileTodo, Entry.Filename, ( (double)mFileCount / (double)mFileTodo ) * 100 );
			} catch( Exception ex ) {
				System.Diagnostics.Debug.WriteLine( ex );
			}
		}

		private void mWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e ) {
			this.Close();
		}


	}


	public enum EPackType {
		SaveUpdates,
		RepackAll
	}

}
