using System;

using GodLesZ.Library.Amf.Messaging.Messages;

namespace GodLesZ.Library.Amf.Messaging.Services.Messaging {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public class MessagingAdapter : ServiceAdapter {
		/// <summary>
		/// Initializes a new instance of the MessagingAdapter class.
		/// </summary>
		public MessagingAdapter() {
		}

		/// <summary>
		/// This method is responsible for handling the message and returning a result (if any).
		/// The return value of this message is used as the body of the acknowledge message returned to the client. It may be null if there is no data being returned for this message. 
		/// </summary>
		/// <param name="message">The message received from the client.</param>
		/// <returns>The body of the acknowledge message (or null if there is no body).</returns>
		public override object Invoke(IMessage message) {
			MessageService messageService = this.Destination.Service as MessageService;
			messageService.PushMessageToClients(message);
			return null;
		}

		/// <summary>
		/// Invoked before a client message is sent to a subtopic.
		/// </summary>
		/// <param name="subtopic">The subtopic the client is attempting to send a message to.</param>
		/// <returns>true to allow the message to be sent, false to prevent it.</returns>
		public bool AllowSend(Subtopic subtopic) {
			return true;
		}
		/// <summary>
		/// Invoked before a client subscribe request is processed.
		/// </summary>
		/// <param name="subtopic">The subtopic the client is attempting to subscribe to.</param>
		/// <returns>true to allow the subscription, false to prevent it.</returns>
		public bool AllowSubscribe(Subtopic subtopic) {
			return true;
		}
	}
}
