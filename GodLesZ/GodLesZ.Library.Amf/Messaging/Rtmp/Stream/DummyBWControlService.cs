using System.Collections;
using GodLesZ.Library.Amf.Configuration;
using GodLesZ.Library.Amf.Messaging.Api;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream {
	/// <summary>
	/// A dummy bandwidth control service (bandwidth controller) that always has token available.
	/// </summary>
	class DummyBWControlService : IBWControlService {
		private ITokenBucket _dummyBucket = new DummyTokenBukcet();
		//Map(IBWControllable, IBWControlContext)
		private Hashtable _contextMap = new Hashtable();

		#region IService Members

		public void Start(ConfigurationSection configuration) {
		}

		public void Shutdown() {
		}

		#endregion

		#region IBWControlService Members

		public IBWControlContext RegisterBWControllable(IBWControllable bc) {
			lock (_contextMap.SyncRoot) {
				if (!_contextMap.Contains(bc)) {
					DummyBWContext context = new DummyBWContext(bc);
					_contextMap.Add(bc, context);
				}
				return _contextMap[bc] as IBWControlContext;
			}
		}

		public void UnregisterBWControllable(IBWControlContext context) {
			lock (_contextMap.SyncRoot) {
				_contextMap.Remove(context.GetBWControllable());
			}
		}

		public IBWControlContext LookupContext(IBWControllable bc) {
			lock (_contextMap.SyncRoot) {
				return _contextMap[bc] as IBWControlContext;
			}
		}

		public void UpdateBWConfigure(IBWControlContext context) {
			// do nothing
		}

		public void ResetBuckets(IBWControlContext context) {
			// do nothing
		}

		public ITokenBucket GetAudioBucket(IBWControlContext context) {
			return _dummyBucket;
		}

		public ITokenBucket GetVideoBucket(IBWControlContext context) {
			return _dummyBucket;
		}

		public ITokenBucket GetDataBucket(IBWControlContext context) {
			return _dummyBucket;
		}

		#endregion
	}

	class DummyTokenBukcet : ITokenBucket {
		#region ITokenBucket Members

		public bool AcquireToken(long tokenCount, long wait) {
			return true;
		}

		public bool AcquireTokenNonblocking(long tokenCount, ITokenBucketCallback callback) {
			return true;
		}

		public long AcquireTokenBestEffort(long upperLimitCount) {
			return upperLimitCount;
		}

		public long Capacity {
			get { return 0; }
		}

		public double Speed {
			get { return 0; }
		}

		public void Reset() {
		}

		#endregion
	}

	class DummyBWContext : IBWControlContext {
		private IBWControllable _controllable;

		public DummyBWContext(IBWControllable controllable) {
			_controllable = controllable;
		}

		#region IBWControlContext Members

		public IBWControllable GetBWControllable() {
			return _controllable;
		}

		#endregion
	}
}
