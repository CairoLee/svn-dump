
using System;
using GodLesZ.Library.Amf.Exceptions;

namespace GodLesZ.Library.Amf.Messaging.Rtmp {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
#if !SILVERLIGHT
	[Serializable]
#endif
	class HandshakeFailedException : FluorineException {
		/// <summary>
		/// Initializes a new instance of the HandshakeFailedException class.
		/// </summary>
		public HandshakeFailedException() {
		}
		/// <summary>
		/// Initializes a new instance of the HandshakeFailedException class with a specified error message.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>			
		public HandshakeFailedException(string message)
			: base(message) {
		}
	}
}
