
using System.Collections;
using GodLesZ.Library.Amf.Data.Messages;

namespace GodLesZ.Library.Amf.Data {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class MessageBatch {
		DataMessage _incomingMessage;
		IList _messages;

		public MessageBatch(DataMessage incomingMessage, IList messages) {
			_incomingMessage = incomingMessage;
			_messages = messages;
		}

		public DataMessage IncomingMessage {
			get { return _incomingMessage; }
		}

		public IList Messages {
			get { return _messages; }
		}
	}
}
