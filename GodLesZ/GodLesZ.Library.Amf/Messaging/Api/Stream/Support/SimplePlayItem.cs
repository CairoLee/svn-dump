using System;
using GodLesZ.Library.Amf.Messaging.Api.Messaging;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream.Support {
	/// <summary>
	/// Simple playlist item implementation.
	/// </summary>
	[CLSCompliant(false)]
	public class SimplePlayItem : IPlayItem {
		private long _length = -1;
		private string _name;
		/// <summary>
		/// Start mark.
		/// </summary>
		private long _start = -2;
		/// <summary>
		/// Message source
		/// </summary>
		private IMessageInput _msgInput;

		#region IPlayItem Members

		/// <summary>
		/// Gets item name.
		/// </summary>
		public string Name {
			get { return _name; }
			set { _name = value; }
		}
		/// <summary>
		/// Gets or sets start position.
		/// </summary>
		public long Start {
			get { return _start; }
			set { _start = value; }
		}

		/// <summary>
		/// Gets play item length in milliseconds.
		/// </summary>
		public long Length {
			get { return _length; }
			set { _length = value; }
		}
		/// <summary>
		/// Gets or sets the message input source.
		/// </summary>
		public IMessageInput MessageInput {
			get { return _msgInput; }
			set { _msgInput = value; }
		}

		#endregion
	}
}
