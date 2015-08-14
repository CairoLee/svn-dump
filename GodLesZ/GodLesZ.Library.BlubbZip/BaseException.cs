using System;
using System.Runtime.Serialization;

namespace GodLesZ.Library.BlubbZip {
	[Serializable]
	public class BlubbZipBaseException : ApplicationException {
		/// <summary>
		/// Deserialization constructor 
		/// </summary>
		/// <param name="info"><see cref="System.Runtime.Serialization.SerializationInfo"/> for this constructor</param>
		/// <param name="context"><see cref="StreamingContext"/> for this constructor</param>
		protected BlubbZipBaseException( SerializationInfo info, StreamingContext context )
			: base( info, context ) {
		}

		/// <summary>
		/// Initializes a new instance of the BlubbZipBaseException class.
		/// </summary>
		public BlubbZipBaseException() {
		}

		/// <summary>
		/// Initializes a new instance of the BlubbZipBaseException class with a specified error message.
		/// </summary>
		/// <param name="message">A message describing the exception.</param>
		public BlubbZipBaseException( string message )
			: base( message ) {
		}

		/// <summary>
		/// Initializes a new instance of the BlubbZipBaseException class with a specified
		/// error message and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">A message describing the exception.</param>
		/// <param name="innerException">The inner exception</param>
		public BlubbZipBaseException( string message, Exception innerException )
			: base( message, innerException ) {
		}
	}
}
