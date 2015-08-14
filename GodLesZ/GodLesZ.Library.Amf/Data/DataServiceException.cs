

using GodLesZ.Library.Amf.Messaging;

namespace GodLesZ.Library.Amf.Data {
	/// <summary>
	/// DataServiceException
	/// </summary>
	public class DataServiceException : MessageException {
		/// <summary>
		/// Initializes a new instance of the DataServiceException class.
		/// </summary>
		public DataServiceException() {
		}
		/// <summary>
		/// Initializes a new instance of the DataServiceException class.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>			
		public DataServiceException(string message)
			: base(message) {
		}
	}
}
