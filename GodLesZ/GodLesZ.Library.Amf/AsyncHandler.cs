using System;
using System.Threading;
using System.Web;
using GodLesZ.Library.Amf.Threading;

namespace GodLesZ.Library.Amf {
	class AsyncHandler : IAsyncResult {
		private bool _completed;
		private readonly Object _state;
		private readonly AsyncCallback _callback;
		private HttpApplication _httpApplication;
		FluorineGateway _gateway;

		#region IAsyncResult Members

		public object AsyncState {
			get { return _state; }
		}

		public WaitHandle AsyncWaitHandle {
			get { return null; }
		}

		public bool CompletedSynchronously {
			get { return false; }
		}

		public bool IsCompleted {
			get { return _completed; }
		}

		#endregion

		public AsyncHandler(AsyncCallback callback, FluorineGateway gateway, HttpApplication httpApplication, Object state) {
			_gateway = gateway;
			_callback = callback;
			_httpApplication = httpApplication;
			_state = state;
			_completed = false;
		}

		public void Start() {
			//ThreadPool.QueueUserWorkItem(new WaitCallback(AsyncTask), null);
			ThreadPoolEx.Global.QueueUserWorkItem(AsyncTask, null);
		}

		private void AsyncTask(object state) {
			// Restore HttpContext
			//CallContext.SetData("HttpContext", _httpApplication.Context);
			HttpContext.Current = _httpApplication.Context;
			_gateway.ProcessRequest(_httpApplication);
			_gateway = null;
			_httpApplication = null;
			_completed = true;
			_callback(this);
		}
	}
}
