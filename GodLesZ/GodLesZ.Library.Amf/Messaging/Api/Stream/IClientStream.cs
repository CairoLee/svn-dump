using System;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public interface IClientStream : IStream, IBWControllable {
		/// <summary>
		/// Gets stream id allocated in a connection.
		/// </summary>
		int StreamId { get; }
		/// <summary>
		/// Set the buffer duration for this stream as requested by the client.
		/// </summary>
		/// <param name="bufferTime">Duration in ms the client wants to buffer.</param>
		void SetClientBufferDuration(int bufferTime);
		/// <summary>
		/// Gets the connection containing the stream.
		/// </summary>
		/// <remarks>Returns the connection object or null if the connection is no longer active.</remarks>
		IStreamCapableConnection Connection { get; }
	}
}
