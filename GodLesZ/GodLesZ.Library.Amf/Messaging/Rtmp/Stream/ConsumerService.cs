using GodLesZ.Library.Amf.Configuration;
using GodLesZ.Library.Amf.Messaging.Api.Messaging;
using GodLesZ.Library.Amf.Messaging.Api.Stream;
using GodLesZ.Library.Amf.Messaging.Rtmp.Stream.Consumer;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream {
	/// <summary>
	/// Basic consumer service implementation. Used to get pushed messages at consumer endpoint.
	/// </summary>
	class ConsumerService : IConsumerService {
		#region IConsumerService Members

		public IMessageOutput GetConsumerOutput(IClientStream stream) {
			IStreamCapableConnection streamConnection = stream.Connection;
			if (streamConnection == null || !(streamConnection is RtmpConnection))
				return null;
			RtmpConnection connection = streamConnection as RtmpConnection;
			// TODO Better manage channels.
			// now we use OutputStream as a channel wrapper.
			OutputStream outputStream = connection.CreateOutputStream(stream.StreamId);
			IPipe pipe = new InMemoryPushPushPipe();
			pipe.Subscribe(new ConnectionConsumer(connection, outputStream.Video.ChannelId, outputStream.Audio.ChannelId, outputStream.Data.ChannelId), null);
			return pipe;
		}

		#endregion

		#region IService Members

		public void Start(ConfigurationSection configuration) {
		}

		public void Shutdown() {
		}

		#endregion
	}
}
