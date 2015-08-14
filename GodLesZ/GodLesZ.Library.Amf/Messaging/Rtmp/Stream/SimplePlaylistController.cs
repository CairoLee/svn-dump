using System;
using GodLesZ.Library.Amf.Messaging.Api.Stream;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream {
	class SimplePlaylistController : IPlaylistController {
		#region IPlaylistController Members

		public int NextItem(IPlaylist playlist, int itemIndex) {
			if (itemIndex < 0)
				itemIndex = -1;

			if (playlist.IsRepeat)
				return itemIndex;

			if (playlist.IsRandom) {
				int lastIndex = itemIndex;
				if (playlist.Count > 1) {
					// continuously generate a random number
					// until you get one that was not the last...
					Random rand = new Random();
					while (itemIndex == lastIndex) {
						itemIndex = rand.Next(playlist.Count);
					}
				}
				return itemIndex;
			}

			int nextIndex = itemIndex + 1;

			if (nextIndex < playlist.Count) {
				return nextIndex;
			} else if (playlist.IsRewind) {
				return playlist.Count > 0 ? 0 : -1;
			} else {
				return -1;
			}
		}

		public int PreviousItem(IPlaylist playlist, int itemIndex) {
			if (itemIndex > playlist.Count) {
				return playlist.Count - 1;
			}
			if (playlist.IsRepeat) {
				return itemIndex;
			}
			if (playlist.IsRandom) {
				Random rand = new Random();
				int lastIndex = itemIndex;
				// continuously generate a random number
				// until you get one that was not the last...
				while (itemIndex == lastIndex) {
					itemIndex = rand.Next(playlist.Count);
				}
				lastIndex = itemIndex;
				return itemIndex;
			}
			int prevIndex = itemIndex - 1;
			if (prevIndex >= 0) {
				return prevIndex;
			} else if (playlist.IsRewind) {
				return playlist.Count - 1;
			} else {
				return -1;
			}
		}

		#endregion
	}
}
