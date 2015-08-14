using System;

namespace GodLesZ.Library.Amf.Messaging.Api {
	/// <summary>
	/// Interface to be notified when a Client is created or destroyed.
	/// </summary>
	[CLSCompliant(false)]
	public interface IClientListener {
		/// <summary>
		/// Notification that a Client instance was created.
		/// </summary>
		/// <param name="client">The Client that was created.</param>
		void ClientCreated(IClient client);
		/// <summary>
		/// Notification that a Client is about to be destroyed.
		/// </summary>
		/// <param name="client">The Client that will be destroyed.</param>
		void ClientDestroyed(IClient client);
	}
}
