using System;
using System.Collections;
#if !(NET_1_1)
using System.Collections.Generic;
#endif
using GodLesZ.Library.Amf.Messaging.Api.Messaging;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Messages;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream {
	/// <summary>
	/// Scope type for publishing that deals with pipe connection events.
	/// </summary>
	class BroadcastScope : BasicScope, IBroadcastScope, IPipeConnectionListener {
		/// <summary>
		/// Simple in memory push pipe, triggered by an active provider to push messages to consumer.
		/// </summary>
		private InMemoryPushPushPipe _pipe;
		/// <summary>
		/// Number of components.
		/// </summary>
		private int _compCounter;
		/// <summary>
		/// Remove flag.
		/// </summary>
		private bool _hasRemoved;

		public BroadcastScope(IScope parent, String name)
			: base(parent, Constants.BroadcastScopeType, name, false) {
			_pipe = new InMemoryPushPushPipe();
			_pipe.AddPipeConnectionListener(this);
			_compCounter = 0;
			_hasRemoved = false;
			_keepOnDisconnect = true;
		}

		#region IPipe Members

		public void AddPipeConnectionListener(IPipeConnectionListener listener) {
			_pipe.AddPipeConnectionListener(listener);
		}

		public void RemovePipeConnectionListener(IPipeConnectionListener listener) {
			_pipe.RemovePipeConnectionListener(listener);
		}

		#endregion

		#region IMessageInput Members

		public IMessage PullMessage() {
			return _pipe.PullMessage();
		}

		public IMessage PullMessage(long wait) {
			return _pipe.PullMessage(wait);
		}

#if !(NET_1_1)
		public bool Subscribe(IConsumer consumer, Dictionary<string, object> parameterMap)
#else
        public bool Subscribe(IConsumer consumer, Hashtable parameterMap)
#endif
 {
			lock (_pipe) {
				return !_hasRemoved && _pipe.Subscribe(consumer, parameterMap);
			}
		}

		public bool Unsubscribe(IConsumer consumer) {
			return _pipe.Unsubscribe(consumer);
		}

		public ICollection GetConsumers() {
			return _pipe.GetConsumers();
		}

		public void SendOOBControlMessage(IConsumer consumer, OOBControlMessage oobCtrlMsg) {
			_pipe.SendOOBControlMessage(consumer, oobCtrlMsg);
		}

		#endregion

		#region IMessageOutput Members

		public void PushMessage(IMessage message) {
			_pipe.PushMessage(message);
		}

#if !(NET_1_1)
		public bool Subscribe(IProvider provider, Dictionary<string, object> parameterMap)
#else
        public bool Subscribe(IProvider provider, Hashtable parameterMap)
#endif
 {
			lock (_pipe) {
				return !_hasRemoved && _pipe.Subscribe(provider, parameterMap);
			}
		}

		public bool Unsubscribe(IProvider provider) {
			return _pipe.Unsubscribe(provider);
		}

		public ICollection GetProviders() {
			return _pipe.GetProviders();
		}

		public void SendOOBControlMessage(IProvider provider, OOBControlMessage oobCtrlMsg) {
			_pipe.SendOOBControlMessage(provider, oobCtrlMsg);
		}

		#endregion

		#region IPipeConnectionListener Members

		public void OnPipeConnectionEvent(PipeConnectionEvent evt) {
			switch (evt.Type) {
				case PipeConnectionEvent.CONSUMER_CONNECT_PULL:
				case PipeConnectionEvent.CONSUMER_CONNECT_PUSH:
				case PipeConnectionEvent.PROVIDER_CONNECT_PULL:
				case PipeConnectionEvent.PROVIDER_CONNECT_PUSH:
					_compCounter++;
					break;
				case PipeConnectionEvent.CONSUMER_DISCONNECT:
				case PipeConnectionEvent.PROVIDER_DISCONNECT:
					_compCounter--;
					if (_compCounter <= 0) {
						// XXX should we synchronize parent before removing?
						if (HasParent) {
							IProviderService providerService = ScopeUtils.GetScopeService(this.Parent, typeof(IProviderService)) as IProviderService;
							providerService.UnregisterBroadcastStream(Parent, Name);
						}
						_hasRemoved = true;
					}
					break;
				default:
					throw new NotSupportedException("Event type not supported: " + evt.Type);
			}
		}

		#endregion
	}
}
