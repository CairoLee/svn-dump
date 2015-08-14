using System;
using GodLesZ.Library.Amf.Messaging.Messages;

namespace GodLesZ.Library.Amf.Messaging.Api.Messaging {
	/// <summary>
	/// A consumer that supports event-driven message handling and message pushing through pipes.
	/// </summary>
	[CLSCompliant(false)]
	public interface IPushableConsumer : IConsumer {
		/// <summary>
		/// Pushes message through pipe.
		/// </summary>
		/// <param name="pipe">Pipe.</param>
		/// <param name="message">Message.</param>
		void PushMessage(IPipe pipe, IMessage message);
	}
}
