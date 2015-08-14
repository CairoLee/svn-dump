using GodLesZ.Library.Amf.Messaging.Config;

namespace GodLesZ.Library.Amf.Messaging.Endpoints {
	class SecureAmfEndpoint : AMFEndpoint {
		public SecureAmfEndpoint(MessageBroker messageBroker, ChannelDefinition channelDefinition)
			: base(messageBroker, channelDefinition) {
		}
	}
}
