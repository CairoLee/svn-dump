using System;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// IServerStream represents a stream broadcasted from the server.
	/// </summary>
	[CLSCompliant(false)]
	public interface IServerStream : IPlaylist, IBroadcastStream {
		/// <summary>
		/// Toggles the paused state.
		/// </summary>
		void Pause();
		/// <summary>
		/// Seek to a given position in the stream.
		/// </summary>
		/// <param name="position">New playback position in milliseconds.</param>
		void Seek(int position);
	}
}
