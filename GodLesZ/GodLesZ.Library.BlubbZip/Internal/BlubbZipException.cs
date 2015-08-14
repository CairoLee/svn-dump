using System;

#if !NETCF_1_0 && !NETCF_2_0
using System.Runtime.Serialization;
#endif

namespace GodLesZ.Library.BlubbZip.Blubb {

	/// <summary>
	/// Represents exception conditions specific to Blubb archive handling
	/// </summary>
#if !NETCF_1_0 && !NETCF_2_0
	[Serializable]
#endif
	public class BlubbZipException : BlubbZipBaseException {
#if !NETCF_1_0 && !NETCF_2_0
		/// <summary>
		/// Deserialization constructor 
		/// </summary>
		/// <param name="info"><see cref="SerializationInfo"/> for this constructor</param>
		/// <param name="context"><see cref="StreamingContext"/> for this constructor</param>
		protected BlubbZipException( SerializationInfo info, StreamingContext context )
			: base( info, context ) {
		}
#endif

		/// <summary>
		/// Initializes a new instance of the BlubbException class.
		/// </summary>
		public BlubbZipException() {
		}

		/// <summary>
		/// Initializes a new instance of the BlubbException class with a specified error message.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public BlubbZipException( string message )
			: base( message ) {
		}

		/// <summary>
		/// Initialise a new instance of BlubbException.
		/// </summary>
		/// <param name="message">A message describing the error.</param>
		/// <param name="exception">The exception that is the cause of the current exception.</param>
		public BlubbZipException( string message, Exception exception )
			: base( message, exception ) {
		}
	}
}
