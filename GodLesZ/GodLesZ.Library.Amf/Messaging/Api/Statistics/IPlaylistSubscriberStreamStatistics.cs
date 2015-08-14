
namespace GodLesZ.Library.Amf.Messaging.Api.Statistics {
	/// <summary>
	/// Statistical informations about a stream that is subscribed by a client.
	/// </summary>
	public interface IPlaylistSubscriberStreamStatistics : IStreamStatistics {
		/// <summary>
		/// Gets the total number of bytes sent to the client from this stream.
		/// </summary>
		long BytesSent { get; }
		/// <summary>
		/// Gets the buffer duration as requested by the client.
		/// </summary>
		int ClientBufferDuration { get; }
		/// <summary>
		/// Gets the estimated fill ratio of the client buffer.
		/// </summary>
		double EstimatedBufferFill { get; }
	}
}
