

using GodLesZ.Library.Amf.Messaging.Config;
using GodLesZ.Library.Amf.Messaging.Messages;
using GodLesZ.Library.Amf.Messaging.Services.Remoting;

namespace GodLesZ.Library.Amf.Messaging.Services {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class RemotingService : ServiceBase {
		public const string RemotingServiceId = "remoting-service";

		public RemotingService(MessageBroker broker, ServiceDefinition serviceDefinition)
			: base(broker, serviceDefinition) {
		}

		protected override Destination NewDestination(DestinationDefinition destinationDefinition) {
			RemotingDestination remotingDestination = new RemotingDestination(this, destinationDefinition);
			return remotingDestination;
		}

		public override object ServiceMessage(IMessage message) {
			RemotingMessage remotingMessage = message as RemotingMessage;
			RemotingDestination destination = GetDestination(message) as RemotingDestination;
			ServiceAdapter adapter = destination.ServiceAdapter;
			object result = adapter.Invoke(message);
			return result;
		}

	}
}
