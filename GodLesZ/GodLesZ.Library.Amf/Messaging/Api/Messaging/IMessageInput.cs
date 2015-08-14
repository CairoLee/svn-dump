using System;
using System.Collections;
#if !(NET_1_1)
using System.Collections.Generic;
#endif
using GodLesZ.Library.Amf.Messaging.Messages;

namespace GodLesZ.Library.Amf.Messaging.Api.Messaging {
	/// <summary>
	/// Input Endpoint for a consumer to connect.
	/// </summary>
	[CLSCompliant(false)]
	public interface IMessageInput {
		/// <summary>
		/// Pull message from this input endpoint. Return w/o waiting.
		/// </summary>
		/// <returns>The pulled message or null if message is not available.</returns>
		IMessage PullMessage();
		/// <summary>
		/// Pull message from this input endpoint. Wait "wait" milliseconds if message is not available.
		/// </summary>
		/// <param name="wait">Milliseconds to wait when message is not available.</param>
		/// <returns>The pulled message or null if message is not available.</returns>
		IMessage PullMessage(long wait);
#if !(NET_1_1)
		/// <summary>
		/// Connect to a consumer.
		/// </summary>
		/// <param name="consumer">Consumer object.</param>
		/// <param name="parameterMap">Parameters map.</param>
		/// <returns>true when successfully subscribed, false otherwise.</returns>
		bool Subscribe(IConsumer consumer, Dictionary<string, object> parameterMap);
#else
        /// <summary>
        /// Connect to a consumer.
        /// </summary>
        /// <param name="consumer">Consumer object.</param>
        /// <param name="parameterMap">Parameters map.</param>
        /// <returns>true when successfully subscribed, false otherwise.</returns>
        bool Subscribe(IConsumer consumer, Hashtable parameterMap);
#endif
		/// <summary>
		/// Disconnect from a consumer.
		/// </summary>
		/// <param name="consumer">Consumer to disconnect.</param>
		/// <returns>true when successfully unsubscribed, false otherwise.</returns>
		bool Unsubscribe(IConsumer consumer);
		/// <summary>
		/// Returns a collection of IConsumer objects.
		/// </summary>
		/// <returns>A collection of IConsumer objects.</returns>
		ICollection GetConsumers();
		/// <summary>
		/// Sends OOB Control Message to all providers on the other side of pipe.
		/// </summary>
		/// <param name="consumer">The consumer that sends the message.</param>
		/// <param name="oobCtrlMsg">Out-of-band control message.</param>
		void SendOOBControlMessage(IConsumer consumer, OOBControlMessage oobCtrlMsg);
	}
}
