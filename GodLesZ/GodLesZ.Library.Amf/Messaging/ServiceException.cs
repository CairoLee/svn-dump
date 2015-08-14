
using System;


namespace GodLesZ.Library.Amf.Messaging {
	/// <summary>
	/// The ServiceException class is used to report exceptions within the messaging system.
	/// </summary>
	public class ServiceException : MessageException {
		/// <summary>
		/// Initializes a new instance of the ServiceException class.
		/// </summary>
		public ServiceException()
			: base() {
		}
		/// <summary>
		/// Initializes a new instance of the ServiceException class.
		/// </summary>
		/// <param name="inner">Reference to the inner exception that is the cause of this exception.</param>
		public ServiceException(Exception inner)
			: base(inner.Message, inner) {
		}
		/// <summary>
		/// Initializes a new instance of the ServiceException class.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>			
		public ServiceException(string message)
			: base(message) {
		}
	}
}
