using System;
using GodLesZ.Library.Amf.Messaging.Messages;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream.Messages {
	/// <summary>
	/// To notify the client to reset the playing state.
	/// </summary>
	[CLSCompliant(false)]
	public class ResetMessage : AsyncMessage {
		protected override MessageBase CopyImpl(MessageBase clone) {
			// Instantiate the clone, if a derived type hasn't already.
			if (clone == null)
				clone = new ResetMessage();
			return base.CopyImpl(clone);
		}

	}
}
