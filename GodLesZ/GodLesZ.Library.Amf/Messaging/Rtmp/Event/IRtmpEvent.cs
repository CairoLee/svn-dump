using GodLesZ.Library.Amf.Messaging.Api.Event;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Event {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface IRtmpEvent : IEvent {
		/// <summary>
		/// Gets the data type.
		/// </summary>
		byte DataType { get; }
		/// <summary>
		/// Gets or sets the RTMP packet header.
		/// </summary>
		RtmpHeader Header { get; set; }
		/// <summary>
		/// Gets or sets the event timestamp.
		/// </summary>
		int Timestamp { get; set; }
		/// <summary>
		/// Gets or sets the extended timestamp.
		/// </summary>
		int ExtendedTimestamp { get; set; }
		/// <summary>
		/// Returns a string that represents the current event object.
		/// </summary>
		/// <param name="indentLevel">The indentation level used for tracing the event members.</param>
		/// <returns>A string that represents the current event object.</returns>
		string ToString(int indentLevel);
	}
}
