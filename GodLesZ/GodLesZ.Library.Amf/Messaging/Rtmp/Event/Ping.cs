using System;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Event;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Event {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public class Ping : BaseEvent {
		/// <summary>
		/// Stream begin / clear event.
		/// </summary>
		public const short StreamBegin = 0;
		/// <summary>
		/// Stream EOF, playback of requested stream is completed.
		/// </summary>
		public const short StreamPlayBufferClear = 1;
		/// <summary>
		/// Stream is empty.
		/// </summary>
		public const short StreamDry = 2;
		/// <summary>
		/// Client buffer. Sent by client to indicate its buffer time in milliseconds.
		/// </summary>
		public const short ClientBuffer = 3;
		/// <summary>
		/// Recorded stream. Sent by server to indicate a recorded stream.
		/// </summary>
		public const short RecordedStream = 4;
		/// <summary>
		/// Unknown event.
		/// </summary>
		public const short Unknown5 = 5;
		/// <summary>
		/// Client ping event. Sent by server to test if client is reachable.
		/// </summary>
		public const short PingClient = 6;
		/// <summary>
		/// Server response event. A clients ping response.
		/// </summary>
		public const short PongServer = 7;
		/// <summary>
		/// Unknown event.
		/// </summary>
		public const short Unknown8 = 8;
		/// <summary>
		/// Undefined event type.
		/// </summary>
		public const int Undefined = -1;

		private short _pingType;
		private int _value2;
		private int _value3 = Undefined;
		private int _value4 = Undefined;

		internal Ping()
			: base(EventType.SYSTEM) {
			_dataType = Constants.TypePing;
		}

		internal Ping(short pingType, int value2)
			: this() {
			_pingType = pingType;
			_value2 = value2;
		}

		internal Ping(short pingType, int value2, int value3)
			: this() {
			_pingType = pingType;
			_value2 = value2;
			_value3 = value3;
		}

		internal Ping(short pingType, int value2, int value3, int value4)
			: this() {
			_pingType = pingType;
			_value2 = value2;
			_value3 = value3;
			_value4 = value4;
		}
		/// <summary>
		/// This member supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		public short PingType {
			get { return _pingType; }
			set { _pingType = value; }
		}
		/// <summary>
		/// This member supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		public int Value2 {
			get { return _value2; }
			set { _value2 = value; }
		}
		/// <summary>
		/// This member supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		public int Value3 {
			get { return _value3; }
			set { _value3 = value; }
		}
		/// <summary>
		/// This member supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		public int Value4 {
			get { return _value4; }
			set { _value4 = value; }
		}
		/// <summary>
		/// Returns a string that represents the current object fields.
		/// </summary>
		/// <param name="indentLevel">The indentation level used for tracing the members.</param>
		/// <returns>A string that represents the current object fields.</returns>
		protected override string ToStringFields(int indentLevel) {
			string sep = GetFieldSeparator(indentLevel);
			string value = base.ToStringFields(indentLevel);
			value += sep + "value1 = " + _pingType;
			value += sep + "value2 = " + _value2;
			value += sep + "value3 = " + _value3;
			value += sep + "value4 = " + _value4;
			return value;
		}
	}
}
