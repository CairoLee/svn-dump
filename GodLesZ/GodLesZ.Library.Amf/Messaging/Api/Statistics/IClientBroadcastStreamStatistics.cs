using System;

namespace GodLesZ.Library.Amf.Messaging.Api.Statistics {
	/// <summary>
	/// Statistical informations about a stream that is broadcasted by a client.
	/// </summary>
	public interface IClientBroadcastStreamStatistics : IStreamStatistics {
		/// <summary>
		/// Gets the filename the stream is being saved as.
		/// </summary>
		/// <value>The filename relative to the scope or <code>null</code> if the stream is not being saved.</value>
		String SaveFilename { get; }
		/// <summary>
		/// Gets stream publish name. Publish name is the value of the first parameter
		/// had been passed to <code>NetStream.publish</code> on client side in SWF.
		/// </summary>
		String PublishedName { get; }
		/// <summary>
		/// Gets the total number of subscribers.
		/// </summary>
		int TotalSubscribers { get; }
		/// <summary>
		/// Gets the maximum number of concurrent subscribers.
		/// </summary>
		int MaxSubscribers { get; }
		/// <summary>
		/// Gets the current number of subscribers.
		/// </summary>
		int ActiveSubscribers { get; }
		/// <summary>
		/// Gets the total number of bytes received from client for this stream.
		/// </summary>
		long BytesReceived { get; }
	}
}
