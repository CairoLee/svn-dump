
namespace GodLesZ.Library.Amf.Messaging.Rtmp.SO {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public enum SharedObjectEventType {
		/// <summary>
		/// Connect.
		/// </summary>
		SERVER_CONNECT = 1,
		/// <summary>
		/// Disconnect.
		/// </summary>
		SERVER_DISCONNECT = 2,
		/// <summary>
		/// Set Attribute.
		/// </summary>
		SERVER_SET_ATTRIBUTE = 3,
		/// <summary>
		/// Update Data.
		/// </summary>
		CLIENT_UPDATE_DATA = 4,
		/// <summary>
		/// Update Attribute.
		/// </summary>
		CLIENT_UPDATE_ATTRIBUTE = 5,
		/// <summary>
		/// Send Message.
		/// </summary>
		SERVER_SEND_MESSAGE = 6,
		/// <summary>
		/// Status.
		/// </summary>
		CLIENT_STATUS = 7,
		/// <summary>
		/// Clear Data.
		/// </summary>
		CLIENT_CLEAR_DATA = 8,
		/// <summary>
		/// Delete Data.
		/// </summary>
		CLIENT_DELETE_DATA = 9,
		/// <summary>
		/// Delete Attribute.
		/// </summary>
		SERVER_DELETE_ATTRIBUTE = 0xa,
		/// <summary>
		/// Initial Data.
		/// </summary>
		CLIENT_INITIAL_DATA = 0xb,
		/// <summary>
		/// Send Message.
		/// </summary>
		CLIENT_SEND_MESSAGE,
		/// <summary>
		/// Delete Attribute.
		/// </summary>
		CLIENT_DELETE_ATTRIBUTE
	};

	/// <summary>
	/// One update event for a shared object received through a connection.
	/// </summary>
	public interface ISharedObjectEvent {
		/// <summary>
		/// Gets the type of the event.
		/// </summary>
		SharedObjectEventType Type { get; }
		/// <summary>
		/// Gets the key of the event.
		/// </summary>
		/// <remarks>
		/// Depending on the type this contains:
		/// <ul>
		/// <li>The attribute name to set for SET_ATTRIBUTE</li>
		/// <li>The attribute name to delete for DELETE_ATTRIBUTE</li>
		/// <li>The handler name to call for SEND_MESSAGE</li>
		/// </ul>
		/// In all other cases the key is <code>null</code>.
		/// </remarks>
		string Key { get; }
		/// <summary>
		/// Gets the value of the event.
		/// </summary>
		/// <remarks>
		/// Depending on the type this contains:
		/// <ul>
		/// <li>The attribute value to set for SET_ATTRIBUTE</li>
		/// <li>A list of parameters to pass to the handler for SEND_MESSAGE</li>
		/// </ul>
		/// In all other cases the value is <code>null</code>.
		/// </remarks>
		object Value { get; }
	}
}
