using System;

namespace GodLesZ.Library.Amf.Json {
	/// <summary>
	/// The exception thrown when an error occurs while reading Json text.
	/// </summary>
	public class JsonWriterException : Exception {
		/// <summary>
		/// Initializes a new instance of the <see cref="JsonWriterException"/> class.
		/// </summary>
		public JsonWriterException() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="JsonWriterException"/> class
		/// with a specified error message.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public JsonWriterException(string message)
			: base(message) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="JsonWriterException"/> class
		/// with a specified error message and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
		public JsonWriterException(string message, Exception innerException)
			: base(message, innerException) {
		}
	}
}
