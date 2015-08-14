
using System;

namespace GodLesZ.Library.Amf.Exceptions {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
#if !SILVERLIGHT
	[Serializable]
#endif
	public class UnexpectedAMF : FluorineException {
		/// <summary>
		/// Initializes a new instance of the UnexpectedAMF class.
		/// </summary>
		public UnexpectedAMF() {
		}
		/// <summary>
		/// Initializes a new instance of the UnexpectedAMF class with a specified error message.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>			
		public UnexpectedAMF(string message)
			: base(message) {
		}
	}
}
