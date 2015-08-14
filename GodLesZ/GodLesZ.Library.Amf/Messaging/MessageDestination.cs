
using GodLesZ.Library.Amf.Messaging.Config;
using GodLesZ.Library.Amf.Messaging.Services;
using GodLesZ.Library.Amf.Messaging.Services.Messaging;
// Import log4net classes.
using log4net;

namespace GodLesZ.Library.Amf.Messaging {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class MessageDestination : Destination {
		private static readonly ILog log = LogManager.GetLogger(typeof(MessageDestination));
		SubscriptionManager _subscriptionManager;

		public MessageDestination(IService service, DestinationDefinition destinationDefinition)
			: base(service, destinationDefinition) {
			_subscriptionManager = new SubscriptionManager(this);
		}

		public SubscriptionManager SubscriptionManager { get { return _subscriptionManager; } }

		public virtual MessageClient RemoveSubscriber(string clientId) {
			if (log.IsDebugEnabled)
				log.Debug(__Res.GetString(__Res.MessageDestination_RemoveSubscriber, clientId));

			return _subscriptionManager.RemoveSubscriber(clientId);
		}
	}
}
