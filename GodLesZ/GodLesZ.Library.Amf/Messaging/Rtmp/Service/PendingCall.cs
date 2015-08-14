
#if !(NET_1_1)
using System.Collections.Generic;
#endif
using GodLesZ.Library.Amf.Messaging.Api.Service;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Service {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class PendingCall : Call, IPendingServiceCall {
		object _result;
#if !(NET_1_1)
		List<IPendingServiceCallback> _callbacks = new List<IPendingServiceCallback>();
#else
		ArrayList	_callbacks = new ArrayList();
#endif

		public PendingCall(string method)
			: base(method) {
		}

		public PendingCall(string method, object[] args)
			: base(method, args) {
		}

		public PendingCall(string name, string method, object[] args)
			: base(name, method, args) {
		}

		#region IPendingServiceCall Members

		public object Result {
			get {
				return _result;
			}
			set {
				_result = value;
			}
		}

		public void RegisterCallback(IPendingServiceCallback callback) {
			_callbacks.Add(callback);
		}

		public void UnregisterCallback(IPendingServiceCallback callback) {
			_callbacks.Remove(callback);
		}

		public IPendingServiceCallback[] GetCallbacks() {
#if !(NET_1_1)
			return _callbacks.ToArray();
#else
			return _callbacks.ToArray(typeof(IPendingServiceCallback)) as IPendingServiceCallback[];
#endif
		}

		#endregion

	}
}
