using System;
using GodLesZ.Library.Amf.Messaging.Messages;

namespace GodLesZ.Library.Amf.Messaging.Api.Messaging {
	/// <summary>
	/// A provider that supports passive pulling of messages.
	/// </summary>
	[CLSCompliant(false)]
	public interface IPullableProvider : IProvider {
		IMessage PullMessage(IPipe pipe);
		IMessage PullMessage(IPipe pipe, long wait);
	}
}
