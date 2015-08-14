using System.Collections;

namespace GodLesZ.Library.Amf.Net {
	/// <summary>
	/// Event dispatched when a remote SharedObject receives a message from the server.
	/// </summary>
	public class SendMessageEventArgs {
		readonly string _message;
		readonly IList _arguments;

		internal SendMessageEventArgs(string message, IList arguments) {
			_message = message;
			_arguments = arguments;
		}

		/// <summary>
		/// Gets the message name.
		/// </summary>
		public string Message {
			get { return _message; }
		}
		/// <summary>
		/// Gets the message parameters.
		/// </summary>
		public IList Arguments {
			get { return _arguments; }
		}
	}
}
