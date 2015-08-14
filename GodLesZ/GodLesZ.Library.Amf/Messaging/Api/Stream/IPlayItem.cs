using System;
using GodLesZ.Library.Amf.Messaging.Api.Messaging;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// Playlist item. Each playlist item has name, start time, length in milliseconds and message input source.
	/// </summary>
	[CLSCompliant(false)]
	public interface IPlayItem {
		/// <summary>
		/// Gets the name of item.
		/// The VOD or Live stream provider is found according to this name.
		/// </summary>
		String Name { get; }
		/// <summary>
		/// Gets the start time in millisecond.
		/// </summary>
		long Start { get; }
		/// <summary>
		/// Gets the play length in millisecond.
		/// </summary>
		long Length { get; }
		/// <summary>
		/// Gets a message input for play.
		/// This object overrides the default algorithm for finding
		/// the appropriate VOD or Live stream provider according to the item name.
		/// </summary>
		IMessageInput MessageInput { get; }
	}
}
