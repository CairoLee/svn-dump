using System;

namespace Shaiya.Extended.Library.Utility {

	public class BackgroundWorker {
		private bool mCancelPending = false;
		private bool mReportsProgress = false;
		private bool mSupportsCancellation = false;

		private bool mRetryTest = false;

		public delegate void DoWorkEventHandler( object sender, DoWorkEventArgsBw e );
		public delegate void ProgressChangedEventHandler( object sender, ProgressChangedEventArgsBw e );
		public delegate void RunWorkerCompletedEventHandler( object sender, RunWorkerCompletedEventArgsBw e );

		public event DoWorkEventHandler DoWork;
		public event ProgressChangedEventHandler ProgressChanged;
		public event RunWorkerCompletedEventHandler RunWorkerCompleted;

		public bool WorkerSupportsCancellation {
			get {
				lock( this ) {
					return mSupportsCancellation;
				}
			}
			set {
				lock( this ) {
					mSupportsCancellation = value;
				}
			}
		}

		public bool WorkerReportsProgress {
			get {
				lock( this ) {
					return mReportsProgress;
				}
			}
			set {
				lock( this ) {
					mReportsProgress = value;
				}
			}
		}

		public bool CancellationPending {
			get {
				lock( this ) {
					return mCancelPending;
				}
			}
		}


		public bool RetryTest {
			get {
				lock( this ) {
					return mRetryTest;
				}
			}
			set {
				lock( this ) {
					mRetryTest = value;
				}
			}
		}

		public void RunWorkerAsync() {
			RunWorkerAsync( null );
		}

		public void RunWorkerAsync( object argument ) {
			mCancelPending = false;
			if( DoWork != null ) {
				DoWorkEventArgsBw args = new DoWorkEventArgsBw( argument );
				AsyncCallback callback = new AsyncCallback( ReportCompletion );
				DoWork.BeginInvoke( this, args, callback, args );
			}
		}

		public void ReportProgress( int percent, object state ) {
			if( WorkerReportsProgress ) {
				ProgressChangedEventArgsBw progressArgs;
				progressArgs = new ProgressChangedEventArgsBw( percent, state );
				OnProgressChanged( progressArgs );
			}
		}

		public void CancelAsync() {
			lock( this ) {
				mCancelPending = true;
			}
		}

		protected virtual void OnProgressChanged( ProgressChangedEventArgsBw progressArgs ) {
			ProcessDelegate( ProgressChanged, this, progressArgs );
		}

		protected virtual void OnRunWorkerCompleted( RunWorkerCompletedEventArgsBw completedArgs ) {
			ProcessDelegate( RunWorkerCompleted, this, completedArgs );
		}

		private void ProcessDelegate( Delegate del, params object[] args ) {
			Delegate temp = del;
			if( temp == null )
				return;

			Delegate[] delegates = temp.GetInvocationList();
			foreach( Delegate handler in delegates ) {
				InvokeDelegate( handler, args );
			}
		}

		private void InvokeDelegate( Delegate del, object[] args ) {
			System.ComponentModel.ISynchronizeInvoke synchronizer = del.Target as System.ComponentModel.ISynchronizeInvoke;

			if( synchronizer != null ) {
				if( synchronizer.InvokeRequired == false ) {
					del.DynamicInvoke( args );
					return;
				}
				try {
					synchronizer.Invoke( del, args );
				} catch { }
			} else {
				del.DynamicInvoke( args );
			}
		}

		private void ReportCompletion( IAsyncResult asyncResult ) {
			System.Runtime.Remoting.Messaging.AsyncResult ar = asyncResult as System.Runtime.Remoting.Messaging.AsyncResult;
			DoWorkEventHandler del = ar.AsyncDelegate as DoWorkEventHandler;
			DoWorkEventArgsBw doWorkArgs = (DoWorkEventArgsBw)ar.AsyncState;
			object result = null;
			Exception error = null;

			try {
				del.EndInvoke( asyncResult );
				result = doWorkArgs.Result;
			} catch( Exception exception ) {
				error = exception;
			}

			RunWorkerCompletedEventArgsBw completedArgs = new RunWorkerCompletedEventArgsBw( result, error, doWorkArgs.Cancel );
			OnRunWorkerCompleted( completedArgs );
		}
	}

	public class AsyncCompletedEventArgsBw : EventArgs {
		public readonly Exception Error;
		public readonly bool Cancelled;

		public AsyncCompletedEventArgsBw( bool cancelled, Exception ex ) {
			Cancelled = cancelled;
			Error = ex;
		}

		public AsyncCompletedEventArgsBw() {
		}
	}

	public class CancelEventArgsBw : EventArgs {
		private bool mCancel = false;

		public bool Cancel {
			get { return mCancel; }
			set { mCancel = value; }
		}
	}

	public class DoWorkEventArgsBw : CancelEventArgsBw {
		public readonly object Argument;

		public bool Result {
			get { return false; }
		}

		public DoWorkEventArgsBw( object objArgument ) {
			Argument = objArgument;
		}
	}

	public class ProgressChangedEventArgsBw : EventArgs {
		public readonly int ProgressPercentage;
		public readonly object UserState;

		public ProgressChangedEventArgsBw( int intProgressPercentage, object userState ) {
			ProgressPercentage = intProgressPercentage;
			UserState = userState;
		}
	}

	public class RunWorkerCompletedEventArgsBw : AsyncCompletedEventArgsBw {
		public readonly object Result;

		public RunWorkerCompletedEventArgsBw( object objResult, Exception exException, bool bCancel )
			: base( bCancel, exException ) {
			Result = objResult;
		}
	}


}
