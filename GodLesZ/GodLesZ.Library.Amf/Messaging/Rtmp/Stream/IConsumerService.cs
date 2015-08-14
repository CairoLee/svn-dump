using System;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Messaging;
using GodLesZ.Library.Amf.Messaging.Api.Stream;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream {
	/// <summary>
	/// Service for consumer objects, used to get pushed messages at consumer endpoint.
	/// </summary>
	[CLSCompliant(false)]
	public interface IConsumerService : IScopeService {
		/// <summary>
		/// Handles pushed messages.
		/// </summary>
		/// <param name="stream">Client stream object.</param>
		/// <returns>Message object.</returns>
		IMessageOutput GetConsumerOutput(IClientStream stream);
	}
}
