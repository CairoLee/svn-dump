using System;

namespace GodLesZ.Library.Amf.Messaging.Api {
	/// <summary>
	/// MessageClient interface.
	/// </summary>
	[CLSCompliant(false)]
	public interface IMessageClient {
		/// <summary>
		/// Gets an object that can be used to synchronize access. 
		/// </summary>
		object SyncRoot { get; }
		/// <summary>
		/// Gets the message client identity.
		/// </summary>
		/// <value>The message client identity.</value>
		string ClientId { get; }
		/// <summary>
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		void Renew();
		/// <summary>
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		/// <returns></returns>
		byte[] GetBinaryId();
		/// <summary>
		/// Gets whether the MessageClient is being disconnected.
		/// </summary>
		bool IsValid { get; }
		/// <summary>
		/// Gets the endpoint identity the MessageClient is subscribed to.
		/// </summary>
		string EndpointId { get; }
		/// <summary>
		/// Adds a MessageClient destroy listener.
		/// </summary>
		/// <param name="listener">The listener to add.</param>
		void AddMessageClientDestroyedListener(IMessageClientListener listener);
		/// <summary>
		/// Removes a MessageClient destroyed listener.
		/// </summary>
		/// <param name="listener">The listener to remove.</param>
		void RemoveMessageClientDestroyedListener(IMessageClientListener listener);
		/// <summary>
		/// Gets the Client associated with this MessageClient.
		/// </summary>
		IClient Client { get; }
		/// <summary>
		/// Gets the Session associated with this MessageClient.
		/// </summary>
		ISession Session { get; }
		/// <summary>
		/// Invalidates the MessageClient.
		/// </summary>
		void Invalidate();
	}
}
