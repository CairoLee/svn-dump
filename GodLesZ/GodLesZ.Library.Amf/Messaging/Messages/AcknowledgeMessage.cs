
using System;

namespace GodLesZ.Library.Amf.Messaging.Messages {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public class AcknowledgeMessage : AsyncMessage {
		/// <summary>
		/// Initializes a new instance of the AcknowledgeMessage class.
		/// </summary>
		public AcknowledgeMessage() {
			_messageId = Guid.NewGuid().ToString("D");
			_timestamp = System.Environment.TickCount;
		}

		protected override MessageBase CopyImpl(MessageBase clone) {
			// Instantiate the clone, if a derived type hasn't already.
			if (clone == null)
				clone = new AcknowledgeMessage();
			return base.CopyImpl(clone);
		}
	}
}
