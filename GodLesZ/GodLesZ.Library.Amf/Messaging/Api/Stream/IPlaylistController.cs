using System;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// A play list controller that controls the order of play items.
	/// </summary>
	[CLSCompliant(false)]
	public interface IPlaylistController {
		/// <summary>
		/// Get next item to play.
		/// </summary>
		/// <param name="playlist">The play list.</param>
		/// <param name="itemIndex">The current item index. -1 indicates to retrieve the first item for play.</param>
		/// <returns>The next item index to play. -1 reaches the end.</returns>
		int NextItem(IPlaylist playlist, int itemIndex);
		/// <summary>
		/// Get previous item to play.
		/// </summary>
		/// <param name="playlist">The play list.</param>
		/// <param name="itemIndex">The current item index. IPlaylist.Count indicates to retrieve the last item for play.</param>
		/// <returns>The previous item index to play. -1 reaches the beginning.</returns>
		int PreviousItem(IPlaylist playlist, int itemIndex);
	}
}
