
using System;


#if !FXCLIENT
using GodLesZ.Library.Amf.Messaging.Config;
#endif
using GodLesZ.Library.Amf.Messaging.Messages;

namespace GodLesZ.Library.Amf.Messaging.Endpoints {
	/// <summary>
	/// <para>
	/// Endpoint interface.
	/// </para>
	/// <para>
	/// An endpoint receives messages from clients and decodes them, then sends them on to a MessageBroker for routing to a service.
	/// The endpoint also encodes messages and delivers them to clients. Endpoints are specific to a message format and network transport, 
	/// and are defined by the named URI path on which they are located. 
	/// </para>
	/// </summary>
	[CLSCompliant(false)]
	public interface IEndpoint {
		/// <summary>
		/// Gets the endpoint id.
		/// </summary>
		/// <remarks>All endpoints are referenceable by an id that is unique among all the endpoints registered to a single broker instance.</remarks>
		string Id { get; }
		/// <summary>
		/// Starts the endpoint.
		/// </summary>
		void Start();
		/// <summary>
		/// Stops and destroys the endpoint.
		/// </summary>
		void Stop();
		/// <summary>
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		void Service();
		/// <summary>
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		IMessage ServiceMessage(IMessage message);
		/// <summary>
		/// Specifies whether this protocol requires the secure HTTPS protocol.
		/// </summary>
		bool IsSecure { get; }
		/// <summary>
		/// This property supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		int ClientLeaseTime { get; }
#if !FXCLIENT
		/// <summary>
		/// Returns a reference to the message broker managing this endpoint.
		/// </summary>
		/// <returns></returns>
		MessageBroker GetMessageBroker();
		/// <summary>
		/// Gets channel defintion settings.
		/// </summary>
		/// <returns></returns>
		ChannelDefinition ChannelDefinition { get; }
		/// <summary>
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="messageclient"></param>
		void Push(IMessage message, MessageClient messageclient);
#endif
	}
}
