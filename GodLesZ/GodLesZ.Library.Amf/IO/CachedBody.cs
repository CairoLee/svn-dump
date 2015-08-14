
using GodLesZ.Library.Amf.Messaging.Messages;

namespace GodLesZ.Library.Amf.IO {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class CachedBody : ResponseBody {
		/// <summary>
		/// Initializes a new instance of the CachedBody class.
		/// </summary>
		/// <param name="requestBody"></param>
		/// <param name="content"></param>
		public CachedBody(AMFBody requestBody, object content)
			: base(requestBody, content) {
		}

		public CachedBody(AMFBody requestBody, IMessage message, object content)
			: base(requestBody, content) {
			//Fix content of body for flex messages
			AcknowledgeMessage responseMessage = new AcknowledgeMessage();
			responseMessage.body = content;
			responseMessage.correlationId = message.messageId;
			responseMessage.destination = message.destination;
			responseMessage.clientId = message.clientId;

			this.Content = responseMessage;
		}

		protected override void WriteBodyData(ObjectEncoding objectEncoding, AMFWriter writer) {
			writer.WriteData(objectEncoding, this.Content);
		}

	}
}
