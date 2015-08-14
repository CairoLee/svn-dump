using System;
using GodLesZ.Library.Amf.Messaging.Api.Statistics;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// IPlaylistSubscriberStream inherits ISubscriberStream and IPlaylist.
	/// </summary>
	[CLSCompliant(false)]
	public interface IPlaylistSubscriberStream : ISubscriberStream, IPlaylist {
		/// <summary>
		/// Gets the statistics about this stream.
		/// </summary>
		IPlaylistSubscriberStreamStatistics Statistics { get; }
	}
}
