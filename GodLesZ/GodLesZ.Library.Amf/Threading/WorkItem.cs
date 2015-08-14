using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;

namespace GodLesZ.Library.Amf.Threading {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	sealed class WorkItem {
		/// <summary>
		/// Indicates the state of the work item in the thread pool.
		/// </summary>
		private enum WorkItemState {
			InQueue,
			InProgress,
			Completed,
			Canceled,
		}

		/// <summary>
		/// Holds the state of the work item.
		/// </summary>
		private WorkItemState _workItemState;
		/// <summary>
		/// Callback delegate.
		/// </summary>
		private WaitCallback _callback;
		/// <summary>
		/// An object containing data to be used by the method.
		/// </summary>
		private object _state;
		/// <summary>
		/// The exception thrown.
		/// </summary>
		private Exception _exception;

		#region Performance Counter fields

		/// <summary>
		/// The time when the work items was queued.
		/// </summary>
		private DateTime _queuedTime;
		/// <summary>
		/// The time when the work item starts its execution.
		/// </summary>
		private DateTime _beginProcessTime;
		/// <summary>
		/// The time when the work item ends its execution.
		/// </summary>
		private DateTime _endProcessTime;

		#endregion


		public WorkItem(WaitCallback callback, object state) {
			_callback = callback;
			_state = state;
			_workItemState = WorkItemState.InQueue;
		}

		private WorkItemState GetWorkItemState() {
			lock (this) {
				return _workItemState;
			}
		}
		/// <summary>
		/// Sets the work item state.
		/// </summary>
		/// <param name="workItemState">The new state.</param>
		private void SetWorkItemState(WorkItemState workItemState) {
			lock (this) {
				_workItemState = workItemState;
			}
		}
		/// <summary>
		/// Signals that the work item has been completed or canceled.
		/// </summary>
		/// <param name="canceled">Indicates that the work item has been canceled.</param>
		private void SignalComplete(bool canceled) {
			SetWorkItemState(canceled ? WorkItemState.Canceled : WorkItemState.Completed);
		}
		/// <summary>
		/// Returns true if the work item is canceled.
		/// </summary>
		public bool IsCanceled {
			get {
				return (GetWorkItemState() == WorkItemState.Canceled);
			}
		}
		/// <summary>
		/// Returns true if the work item has completed.
		/// </summary>
		private bool IsCompleted {
			get {
				WorkItemState workItemState = GetWorkItemState();
				return ((workItemState == WorkItemState.Completed) || (workItemState == WorkItemState.Canceled));
			}
		}
		/// <summary>
		/// Change the state of the work item to in progress if it wasn't canceled.
		/// </summary>
		/// <returns>
		/// Return true on success or false in case the work item was canceled.
		/// </returns>
		public bool StartingWorkItem() {
			_beginProcessTime = DateTime.Now;
			lock (this) {
				if (IsCanceled)
					return false;
				SetWorkItemState(WorkItemState.InProgress);
			}
			return true;
		}

		internal void SetQueueTime() {
			_queuedTime = DateTime.Now;
		}

		/// <summary>
		/// Execute the work item.
		/// </summary>
		public void Execute() {
			// Execute the work item if we are in the correct state
			switch (GetWorkItemState()) {
				case WorkItemState.InProgress:
					ExecuteWorkItem();
					break;
				case WorkItemState.Canceled:
					break;
				default:
					Debug.Assert(false);
					throw new NotSupportedException();
			}
			_endProcessTime = DateTime.Now;
		}

		public void DisposeState() {
			/*
			IDisposable disposable = _state as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
				_state = null;
			}
			*/
		}

		/// <summary>
		/// Execute the work item.
		/// </summary>
		private void ExecuteWorkItem() {
			Exception exception = null;
			IPrincipal principal = Thread.CurrentPrincipal;
			try {
				_callback(_state);
			} catch (Exception e) {
				// Save the exception so we can rethrow it later
				exception = e;
			} finally {
				Thread.CurrentPrincipal = principal;
			}
			SetException(exception);
		}
		/// <summary>
		/// Sets the result of the work item.
		/// </summary>
		/// <param name="exception"></param>
		internal void SetException(Exception exception) {
			_exception = exception;
			SignalComplete(false);
		}
	}
}
