
using System;
using GodLesZ.Library.Amf.Messaging.Config;
using GodLesZ.Library.Amf.Messaging.Messages;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Messaging.Endpoints {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	abstract class EndpointBase : IEndpoint {
		protected MessageBroker _messageBroker;
		protected ChannelDefinition _channelDefinition;
		object _syncLock = new object();

		public EndpointBase(MessageBroker messageBroker, ChannelDefinition channelDefinition) {
			_messageBroker = messageBroker;
			_channelDefinition = channelDefinition;
		}

		#region IEndpoint Members

		public string Id {
			get {
				return _channelDefinition.Id;
			}

		}

		public MessageBroker GetMessageBroker() {
			return _messageBroker;
		}

		public ChannelDefinition ChannelDefinition {
			get { return _channelDefinition; }
		}

		public virtual void Start() {
		}

		public virtual void Stop() {
		}

		public virtual void Push(IMessage message, MessageClient messageClient) {
			throw new NotSupportedException();
		}

		public virtual void Service() {
		}

		public virtual IMessage ServiceMessage(IMessage message) {
			ValidationUtils.ArgumentNotNull(message, "message");
			IMessage response = null;
			response = _messageBroker.RouteMessage(message, this);
			return response;
		}

		public virtual bool IsSecure {
			get {
				return false;
			}
		}

		#endregion

		public bool IsLegacyCollection {
			get {
				if (_channelDefinition.Properties != null && _channelDefinition.Properties.Serialization != null)
					return _channelDefinition.Properties.Serialization.IsLegacyCollection;
				return false;
			}
		}

		public bool IsLegacyThrowable {
			get {
				if (_channelDefinition.Properties != null && _channelDefinition.Properties.Serialization != null)
					return _channelDefinition.Properties.Serialization.IsLegacyThrowable;
				return false;
			}
		}

		/// <summary>
		/// This property supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		public abstract int ClientLeaseTime { get; }

		/// <summary>
		/// Gets an object that can be used to synchronize access to the connection.
		/// </summary>
		public object SyncRoot { get { return _syncLock; } }
	}
}
