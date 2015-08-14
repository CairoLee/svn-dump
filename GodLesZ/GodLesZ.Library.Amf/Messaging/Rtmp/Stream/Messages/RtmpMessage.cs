using System;
using GodLesZ.Library.Amf.Messaging.Messages;
using GodLesZ.Library.Amf.Messaging.Rtmp.Event;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream.Messages {
	/// <summary>
	/// RTMP message
	/// </summary>
	[CLSCompliant(false)]
	public class RtmpMessage : AsyncMessage {
		/// <summary>
		/// Gets or sets the body of the message.
		/// </summary>
		/// <remarks>The body is the data that is delivered to the remote destination.</remarks>
		public new IRtmpEvent body {
			get { return _body as IRtmpEvent; }
			set { _body = value; }
		}

		protected override MessageBase CopyImpl(MessageBase clone) {
			// Instantiate the clone, if a derived type hasn't already.
			if (clone == null)
				clone = new RtmpMessage();
			return base.CopyImpl(clone);
		}
	}
}
