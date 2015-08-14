using System;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// Interface for handlers that control access to stream playback.
	/// </summary>
	[CLSCompliant(false)]
	public interface IStreamPlaybackSecurity {
		/// <summary>
		/// Check if playback of a stream with the given name is allowed.
		/// </summary>
		/// <param name="scope">Scope the stream is about to be played back from.</param>
		/// <param name="name">Name of the stream to play.</param>
		/// <param name="start">Position to start playback from (in milliseconds).</param>
		/// <param name="length">Duration to play (in milliseconds).</param>
		/// <param name="flushPlaylist">Flush playlist.</param>
		/// <returns>true if playback is allowed, otherwise false.</returns>
		bool IsPlaybackAllowed(IScope scope, string name, long start, long length, bool flushPlaylist);
	}
}
