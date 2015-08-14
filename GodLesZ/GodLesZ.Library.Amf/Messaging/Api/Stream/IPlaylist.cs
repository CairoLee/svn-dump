using System;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// Playlist.
	/// </summary>
	[CLSCompliant(false)]
	public interface IPlaylist {
		/// <summary>
		/// Adds an item to the list.
		/// </summary>
		/// <param name="item">Playlist item.</param>
		void AddItem(IPlayItem item);
		/// <summary>
		/// Adds an item to specific index.
		/// </summary>
		/// <param name="item">Playlist item.</param>
		/// <param name="index">Index in list.</param>
		void AddItem(IPlayItem item, int index);
		/// <summary>
		/// Removes an item from list.
		/// </summary>
		/// <param name="index">Index in list.</param>
		void RemoveItem(int index);
		/// <summary>
		/// Remove all items.
		/// </summary>
		void RemoveAllItems();
		/// <summary>
		/// Gets the number of items in list.
		/// </summary>
		int Count { get; }
		/// <summary>
		/// Gets the currently playing item index.
		/// </summary>
		int CurrentItemIndex { get; }
		/// <summary>
		/// Gets the currently playing item.
		/// </summary>
		IPlayItem CurrentItem { get; }
		/// <summary>
		/// Returns the item at the specified index.
		/// </summary>
		/// <param name="index">Item index.</param>
		/// <returns>Item at the specified index in list.</returns>
		IPlayItem GetItem(int index);
		/// <summary>
		/// Gets whether the playlist has more items after the currently playing one.
		/// </summary>
		bool HasMoreItems { get; }
		/// <summary>
		/// Go for the previous played item.
		/// </summary>
		void PreviousItem();
		/// <summary>
		/// Go for next item decided by controller logic.
		/// </summary>
		void NextItem();
		/// <summary>
		/// Set the current item for playing.
		/// </summary>
		/// <param name="index">Position in list</param>
		void SetItem(int index);
		/// <summary>
		/// Gets or sets whether items are randomly played.
		/// </summary>
		bool IsRandom { get; set; }
		/// <summary>
		/// Gets or sets whether rewind the list.
		/// </summary>
		bool IsRewind { get; set; }
		/// <summary>
		/// Gets or sets whether repeat playing an item.
		/// </summary>
		bool IsRepeat { get; set; }
		/// <summary>
		/// Sets list controller.
		/// </summary>
		/// <param name="controller">Playlist controller.</param>
		void SetPlaylistController(IPlaylistController controller);
	}
}
