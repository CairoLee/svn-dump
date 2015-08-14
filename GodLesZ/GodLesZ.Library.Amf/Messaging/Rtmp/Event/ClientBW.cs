using System;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Event;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Event {
	/// <summary>
	/// Client bandwidth event.
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public sealed class ClientBW : BaseEvent {
		private int _bandwidth;
		private byte _value2;

		/// <summary>
		/// Initializes a new instance of the ClientBW class.
		/// </summary>
		/// <param name="bandwidth"></param>
		/// <param name="value2"></param>
		public ClientBW(int bandwidth, byte value2)
			: base(EventType.STREAM_CONTROL) {
			_dataType = Constants.TypeClientBandwidth;
			_bandwidth = bandwidth;
			_value2 = value2;
		}
		/// <summary>
		/// Gets or sets the bandwidth value.
		/// </summary>
		public int Bandwidth {
			get { return _bandwidth; }
			set { _bandwidth = value; }
		}

		public byte Value2 {
			get { return _value2; }
			set { _value2 = value; }
		}
		/// <summary>
		/// Returns a string that represents the current object fields.
		/// </summary>
		/// <param name="indentLevel">The indentation level used for tracing the members.</param>
		/// <returns>A string that represents the current object fields.</returns>
		protected override string ToStringFields(int indentLevel) {
			string sep = GetFieldSeparator(indentLevel);
			string value = base.ToStringFields(indentLevel);
			value += sep + "bandwidth = " + _bandwidth;
			value += sep + "value2 = " + _value2;
			return value;
		}
	}
}
