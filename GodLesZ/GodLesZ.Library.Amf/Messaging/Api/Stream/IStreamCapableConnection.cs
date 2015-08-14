using System;
using System.Collections;
using GodLesZ.Library.Amf.Messaging.Rtmp.Stream;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// A connection that supports streaming.
	/// </summary>
	[CLSCompliant(false)]
	public interface IStreamCapableConnection : IConnection, IBWControllable {
		/// <summary>
		/// Returns a reserved stream id for use.
		/// According to FCS/FMS regulation, the base is 1.
		/// </summary>
		/// <returns>Reserved stream id.</returns>
		int ReserveStreamId();
		/// <summary>
		/// Unreserve this id for future use.
		/// </summary>
		/// <param name="streamId">ID of stream to unreserve.</param>
		void UnreserveStreamId(int streamId);
		/// <summary>
		/// Deletes the stream with the given id.
		/// </summary>
		/// <param name="streamId">Id of stream to delete.</param>
		void DeleteStreamById(int streamId);
		/// <summary>
		/// Get a stream by its id.
		/// </summary>
		/// <param name="streamId">Stream id.</param>
		/// <returns>Stream with given id.</returns>
		IClientStream GetStreamById(int streamId);
		/// <summary>
		/// Creates a stream that can play only one item.
		/// </summary>
		/// <param name="streamId">Stream id.</param>
		/// <returns>New subscriber stream that can play only one item.</returns>
		ISingleItemSubscriberStream NewSingleItemSubscriberStream(int streamId);
		/// <summary>
		/// Creates a stream that can play a list.
		/// </summary>
		/// <param name="streamId">Stream id.</param>
		/// <returns>New stream that can play sequence of items.</returns>
		IPlaylistSubscriberStream NewPlaylistSubscriberStream(int streamId);
		/// <summary>
		/// Creates a broadcast stream.
		/// </summary>
		/// <param name="streamId">Stream id.</param>
		/// <returns>New broadcast stream.</returns>
		IClientBroadcastStream NewBroadcastStream(int streamId);
		/// <summary>
		/// Total number of video messages that are pending to be sent to a stream.
		/// </summary>
		/// <param name="streamId">Stream id.</param>
		/// <returns>Number of pending video messages.</returns>
		long GetPendingVideoMessages(int streamId);
		/// <summary>
		/// Returns a stream by given channel id.
		/// </summary>
		/// <param name="channelId">The channel id.</param>
		/// <returns>Stream that channel belongs to the specified channel.</returns>
		IClientStream GetStreamByChannelId(int channelId);
		/// <summary>
		/// Returns a collection of client streams.
		/// </summary>
		/// <returns></returns>
		ICollection GetStreams();
		/// <summary>
		/// Adds the client stream.
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		/// <param name="stream">The stream.</param>
		void AddClientStream(IClientStream stream);
		/// <summary>
		/// Creates output stream object from stream id. Output stream consists of audio, data and video channels.
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		/// <param name="streamId">Stream id.</param>
		/// <returns>Output stream object.</returns>
		OutputStream CreateOutputStream(int streamId);
	}
}
