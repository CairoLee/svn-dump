using System;
using GodLesZ.Library.Amf.Messaging.Messages;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream.Messages {
	/// <summary>
	/// Status message.
	/// </summary>
	[CLSCompliant(false)]
	public class StatusMessage : AsyncMessage {
		protected override MessageBase CopyImpl(MessageBase clone) {
			// Instantiate the clone, if a derived type hasn't already.
			if (clone == null)
				clone = new StatusMessage();
			return base.CopyImpl(clone);
		}
	}
}
