using System;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream.Support {
	/// <summary>
	/// Stream security handler that denies access to all streams.
	/// </summary>
	[CLSCompliant(false)]
	public class DenyAllStreamAccess : IStreamPublishSecurity, IStreamPlaybackSecurity {
		#region IStreamPublishSecurity Members

		/// <summary>
		/// Check if publishing a stream with the given name is allowed.
		/// </summary>
		/// <param name="scope">Scope the stream is about to be published in.</param>
		/// <param name="name">Name of the stream to publish.</param>
		/// <param name="mode">Publishing mode.</param>
		/// <returns>true if publishing is allowed, otherwise false.</returns>
		public bool IsPublishAllowed(IScope scope, string name, string mode) {
			return false;
		}

		#endregion

		#region IStreamPlaybackSecurity Members

		/// <summary>
		/// Check if playback of a stream with the given name is allowed.
		/// </summary>
		/// <param name="scope">Scope the stream is about to be played back from.</param>
		/// <param name="name">Name of the stream to play.</param>
		/// <param name="start">Position to start playback from (in milliseconds).</param>
		/// <param name="length">Duration to play (in milliseconds).</param>
		/// <param name="flushPlaylist">Flush playlist.</param>
		/// <returns>true if playback is allowed, otherwise false.</returns>
		public bool IsPlaybackAllowed(IScope scope, string name, long start, long length, bool flushPlaylist) {
			return false;
		}

		#endregion
	}
}
