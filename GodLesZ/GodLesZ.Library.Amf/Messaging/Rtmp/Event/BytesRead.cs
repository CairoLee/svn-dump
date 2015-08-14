using System;

using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Event;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Event {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public sealed class BytesRead : BaseEvent {
		private int _bytesRead = 0;

		/// <summary>
		/// Creates new event with given bytes number.
		/// </summary>
		/// <param name="bytesRead"></param>
		internal BytesRead(int bytesRead)
			: base(EventType.STREAM_CONTROL) {
			_dataType = Constants.TypeBytesRead;
			_bytesRead = bytesRead;
		}
		/// <summary>
		/// Gets the number of bytes read.
		/// </summary>
		public int Bytes {
			get { return _bytesRead; }
		}
		/// <summary>
		/// Returns a string that represents the current object fields.
		/// </summary>
		/// <param name="indentLevel">The indentation level used for tracing the members.</param>
		/// <returns>A string that represents the current object fields.</returns>
		protected override string ToStringFields(int indentLevel) {
			string sep = GetFieldSeparator(indentLevel);
			string value = base.ToStringFields(indentLevel);
			value += sep + "bytesRead = " + _bytesRead;
			return value;
		}
	}
}
