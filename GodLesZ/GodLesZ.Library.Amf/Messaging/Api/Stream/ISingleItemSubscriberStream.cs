using System;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// A subscriber stream that has only one item for play.
	/// </summary>
	[CLSCompliant(false)]
	public interface ISingleItemSubscriberStream : ISubscriberStream {
		/// <summary>
		/// Sets PlayItem.
		/// </summary>
		IPlayItem PlayItem { set; }
	}
}
