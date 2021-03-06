using System;
using System.Collections;
using System.Security.Principal;

namespace GodLesZ.Library.Amf.Messaging.Api {
	/// <summary>
	/// The client object represents a single client. One client may have multiple connections to different scopes on the same host.
	/// </summary>
	[CLSCompliant(false)]
	public interface IClient : IAttributeStore, ISessionListener, IMessageClientListener {
		/// <summary>
		/// Gets the client identity.
		/// </summary>
		/// <remarks>
		/// This will be generated by the server if not passed upon connection from client-side Flex/Flash app.
		/// </remarks>
		string Id { get; }
		/// <summary>
		/// Get a set of scopes the client is connected to.
		/// </summary>
		ICollection Scopes { get; }
		/// <summary>
		/// Get a set of connections of a given scope.
		/// </summary>
		ICollection Connections { get; }
		/// <summary>
		/// Gets the MessageClients associated with this Client.
		/// </summary>
		IList MessageClients { get; }
		/// <summary>
		/// Gets whether the client is newly instantiated.
		/// </summary>
		bool IsNew { get; }
		/// <summary>
		/// Invalidates the client.
		/// </summary>
		void Invalidate();
		/// <summary>
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		void Timeout();
		/// <summary>
		/// Gets an object that can be used to synchronize access. 
		/// </summary>
		object SyncRoot { get; }
		/// <summary>
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		/// <param name="messageClient"></param>
		void RegisterMessageClient(IMessageClient messageClient);
		/// <summary>
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		/// <param name="messageClient"></param>
		void UnregisterMessageClient(IMessageClient messageClient);
		/// <summary>
		/// Renews a lease.
		/// </summary>
		void Renew();
		/// <summary>
		/// Renews a lease.
		/// </summary>
		/// <param name="clientLeaseTime">The amount of time in minutes before client times out.</param>
		void Renew(int clientLeaseTime);
		/// <summary>
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		int ClientLeaseTime { get; }
		/// <summary>
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		/// <param name="connection"></param>
		void Register(IConnection connection);
		/// <summary>
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		/// <param name="connection"></param>
		void Unregister(IConnection connection);
		/// <summary>
		/// Gets whether the client is disconnected.
		/// </summary>
		bool IsValid { get; }
		/// <summary>
		/// Registers an IEndpointPushHandler for the specified endpoint to handle pushing messages.
		/// </summary>
		/// <param name="handler">The IEndpointPushHandler to register.</param>
		/// <param name="endpointId">The endpoint identity to register for.</param>
		void RegisterEndpointPushHandler(IEndpointPushHandler handler, string endpointId);
		/// <summary>
		/// Unregisters an IEndpointPushHandler from the specified endpoint.
		/// </summary>
		/// <param name="handler">The IEndpointPushHandler to unregister.</param>
		/// <param name="endpointId">The endpoint identity to unregister from.</param>
		void UnregisterEndpointPushHandler(IEndpointPushHandler handler, string endpointId);
		/// <summary>
		/// Returns the push handler registered with the Client with the supplied endpoint id, or null if no push handler was registered with the Client
		/// </summary>
		/// <param name="endpointId">Endpoint identity.</param>
		/// <returns>The push handler registered with the Client with the supplied endpoint id, or null if no push handler was registered with the Client for that endpoint.</returns>
		IEndpointPushHandler GetEndpointPushHandler(string endpointId);
		/// <summary>
		/// Gets or sets security information for the client.
		/// </summary>
		/// <remarks>Available only when perClientAuthentication is in use.</remarks>
		IPrincipal Principal { get; set; }
		/// <summary>
		/// Adds a client destroy listener that will be notified when the client is destroyed.
		/// </summary>
		/// <param name="listener">The listener to add.</param>
		void AddClientDestroyedListener(IClientListener listener);
		/// <summary>
		/// Removes a client destroy listener.
		/// </summary>
		/// <param name="listener">The listener to remove.</param>
		void RemoveClientDestroyedListener(IClientListener listener);
		/// <summary>
		/// Associates a Session with this Client.
		/// </summary>
		/// <param name="session">The Session to associate with this Client.</param>
		void RegisterSession(ISession session);
		/// <summary>
		/// Disassociates a Session from this Client.
		/// </summary>
		/// <param name="session">The Session to disassociate from this Client.</param>
		void UnregisterSession(ISession session);
		/// <summary>
		/// Notifies client listeners.
		/// </summary>
		void NotifyCreated();
	}
}
