
namespace GodLesZ.Library.Amf.Messaging.Rtmp {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public enum HeaderType : byte {
		/// <summary>
		/// New header marker.
		/// </summary>
		HeaderNew = 0,
		/// <summary>
		/// Same source marker.
		/// </summary>
		HeaderSameSource = 1,
		/// <summary>
		/// Timer change marker.
		/// </summary>
		HeaderTimerChange = 2,
		/// <summary>
		/// Continuation marker.
		/// </summary>
		HeaderContinue = 3
	}

	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public enum RtmpState {
		Connect = 0,
		Handshake = 1,
		Connected = 2,
		Error = 3,
		Disconnected = 4
	}

	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public enum RtmpMode {
		Server = 0,
		Client = 1
	}

	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	enum ScopeLevel {
		Global = 0,
		Application = 1,
		Room = 2
	}
}
