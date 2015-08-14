using GodLesZ.Library.Amf.Messaging.Config;

namespace GodLesZ.Library.Amf.Messaging.Endpoints {
	class SecureRtmpEndpoint : RtmpEndpoint {
		public SecureRtmpEndpoint(MessageBroker messageBroker, ChannelDefinition channelDefinition)
			: base(messageBroker, channelDefinition) {
		}

	}
}
