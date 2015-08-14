using System;
using GodLesZ.Library.Amf.Messaging.Messages;

namespace GodLesZ.Library.Amf.Messaging.Api {
	/// <summary>
	/// Defines the interface for a handler to push messages to a connected client.
	/// </summary>
	[CLSCompliant(false)]
	public interface IEndpointPushHandler {
		/// <summary>
		/// Gets the handler identity.
		/// </summary>
		string Id { get; }
		/// <summary>
		/// Gets an object that can be used to synchronize access to the connection.
		/// </summary>
		object SyncRoot { get; }
		/// <summary>
		/// Closes the handler.
		/// </summary>
		void Close();
		/// <summary>
		/// Pushes messages to the client.
		/// </summary>
		/// <param name="messages">The list of messages to push.</param>
		void PushMessages(IMessage[] messages);
		/// <summary>
		/// Pushes a message to the client.
		/// </summary>
		/// <param name="message">The message to push.</param>
		void PushMessage(IMessage message);
		/// <summary>
		/// Invoked to notify the handler that the MessageClient subscription is using this handler.
		/// </summary>
		/// <param name="messageClient">The MessageClient subscription using this handler.</param>
		void RegisterMessageClient(IMessageClient messageClient);
		/// <summary>
		/// Invoked to notify the handler that a MessageClient subscription that was using it has been invalidated.
		/// </summary>
		/// <param name="messageClient">The MessageClient subscription no longer using this handler</param>
		void UnregisterMessageClient(IMessageClient messageClient);
		/// <summary>
		/// Gets pending messages.
		/// </summary>
		/// <returns>List of pending messages.</returns>
		IMessage[] GetPendingMessages();

	}
}
