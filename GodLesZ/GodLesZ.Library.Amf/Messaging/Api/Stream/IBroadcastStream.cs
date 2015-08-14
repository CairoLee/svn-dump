using System;
using System.Collections;
using GodLesZ.Library.Amf.Messaging.Api.Messaging;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// A broadcast stream is a stream source to be subscribed by clients. To
	/// subscribe a stream from your client Flash application use NetStream.play
	/// method. Broadcast stream can be saved at server-side.
	/// </summary>
	[CLSCompliant(false)]
	public interface IBroadcastStream : IStream {
		/// <summary>
		/// Saves the broadcast stream as a file. 
		/// </summary>
		/// <param name="filePath">The path of the file relative to the scope.</param>
		/// <param name="isAppend">Whether to append to the end of file.</param>
		void SaveAs(string filePath, bool isAppend);
		/// <summary>
		/// Gets the filename the stream is being saved as.
		/// </summary>
		/// <value>The filename relative to the scope or null if the stream is not being saved.</value>
		String SaveFilename { get; }
		/// <summary>
		/// Gets or sets stream publish name. Publish name is the value of the first parameter
		/// had been passed to <code>NetStream.publish</code> on client side in SWF.
		/// </summary>
		String PublishedName { get; set; }
		/// <summary>
		/// Gets the provider corresponding to this stream.
		/// </summary>
		IProvider Provider { get; }
		/// <summary>
		/// Add a listener to be notified about received packets.
		/// </summary>
		/// <param name="listener">The listener to add.</param>
		void AddStreamListener(IStreamListener listener);
		/// <summary>
		/// Remove a listener from being notified about received packets.
		/// </summary>
		/// <param name="listener">The listener to remove.</param>
		void RemoveStreamListener(IStreamListener listener);
		/// <summary>
		/// Return registered stream listeners.
		/// </summary>
		/// <returns>The registered listeners.</returns>
		ICollection GetStreamListeners();

	}
}
