using System;
using GodLesZ.Library.Amf.Messaging.Messages;
using GodLesZ.Library.Amf.Messaging.Rtmp.Event;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Messaging.Rtmp {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public sealed class RtmpPacket {
		RtmpHeader _header;
		IRtmpEvent _message;
		ByteBuffer _data;

		internal RtmpPacket(RtmpHeader header) {
			_header = header;
			_data = ByteBuffer.Allocate(header.Size + (header.Timer == 0xffffff ? 4 : 0));
		}

		internal RtmpPacket(RtmpHeader header, IRtmpEvent message) {
			_header = header;
			_message = message;
		}
		/// <summary>
		/// Gets or sets the RTMP header.
		/// </summary>
		public RtmpHeader Header {
			get { return _header; }
			set { _header = value; }
		}
		/// <summary>
		/// Gets or sets the RTMP event.
		/// </summary>
		public IRtmpEvent Message {
			get { return _message; }
			set { _message = value; }
		}
		/// <summary>
		/// Gets or sets packet data.
		/// </summary>
		public ByteBuffer Data {
			get { return _data; }
			set { _data = value; }
		}

		/// <summary>
		/// Returns a string that represents the current RtmpPacket object.
		/// </summary>
		/// <returns>A string that represents the current RtmpPacket object.</returns>
		public override string ToString() {
			return ToString(1);
		}
		/// <summary>
		/// Returns a string that represents the current RtmpPacket object.
		/// </summary>
		/// <param name="indentLevel">The indentation level used for tracing the packet members.</param>
		/// <returns>A string that represents the current RtmpPacket object.</returns>
		public string ToString(int indentLevel) {
			return ToStringHeader(indentLevel) + ToStringFields(indentLevel + 1);
		}
		/// <summary>
		/// Returns a header string that represents the current RtmpPacket object.
		/// </summary>
		/// <param name="indentLevel">The indentation level used for tracing the packet members.</param>
		/// <returns>A header string that represents the current RtmpPacket object.</returns>
		private string ToStringHeader(int indentLevel) {
			string value = "RTMP Packet";
			return value;
		}
		/// <summary>
		/// Returns a string that represents the current RtmpPacket object fields.
		/// </summary>
		/// <param name="indentLevel">The indentation level used for tracing the packet members.</param>
		/// <returns>A string that represents the current RtmpPacket object fields.</returns>
		private string ToStringFields(int indentLevel) {
			String sep = MessageBase.GetFieldSeparator(indentLevel);
			String value = sep + "header = " + (_header != null ? _header.ToStringFields(indentLevel + 1) : "(null)");
			value += sep + "message = " + (_message != null ? _message.ToString(indentLevel + 1) : "(null)");
			value += sep + "data = " + (_data != null ? "buffer(" + _data.Length + ")" : "(null)");
			return value;
		}
	}
}
