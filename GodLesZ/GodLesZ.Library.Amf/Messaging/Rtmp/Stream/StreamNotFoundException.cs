using GodLesZ.Library.Amf.Exceptions;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream {
	/// <summary>
	/// Throwm when stream can't be found.
	/// </summary>
	public class StreamNotFoundException : FluorineException {
		/// <summary>
		/// Initializes a new instance of the StreamNotFoundException class with a specified error message.
		/// </summary>
		/// <param name="name">Stream name.</param>
		public StreamNotFoundException(string name)
			: base("Stream " + name + " not found.") {
		}
	}
}
