using System;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public interface IStream {
		/// <summary>
		/// Gets the name of the stream. The name is unique across the server. This is
		/// just an id of the stream and NOT the name that is used at client side to
		/// subscribe to the stream. For that name, use IBroadcastStream.PublishedName.
		/// </summary>
		string Name { get; }
		/// <summary>
		/// Gets the scope this stream is associated with.
		/// </summary>
		IScope Scope { get; }
		/// <summary>
		/// Starts the stream.
		/// </summary>
		void Start();
		/// <summary>
		/// Stops the stream.
		/// </summary>
		void Stop();
		/// <summary>
		/// Closes the stream.
		/// </summary>
		void Close();
		/// <summary>
		/// Gets Codec info for a stream.
		/// </summary>
		IStreamCodecInfo CodecInfo { get; }
		/// <summary>
		/// Gets an object that can be used to synchronize access. 
		/// </summary>
		object SyncRoot { get; }
		/// <summary>
		/// Gets the timestamp at which the stream was created.
		/// </summary>
		/// <value>The creation time.</value>
		long CreationTime { get; }
	}
}
