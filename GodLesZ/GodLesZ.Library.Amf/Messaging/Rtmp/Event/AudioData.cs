using System;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Event;
using GodLesZ.Library.Amf.Messaging.Api.Stream;
using GodLesZ.Library.Amf.Messaging.Rtmp.Stream;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Event {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public class AudioData : BaseEvent, IStreamData, IStreamPacket {
		/// <summary>
		/// Audio data.
		/// </summary>
		protected ByteBuffer _data;

		/// <summary>
		/// Initializes a new instance of the AudioData class.
		/// </summary>
		/// <param name="data">AudioData buffer.</param>
		public AudioData(ByteBuffer data)
			: base(EventType.STREAM_DATA) {
			_dataType = Constants.TypeAudioData;
			_data = data;
		}
		/// <summary>
		/// Initializes a new instance of the AudioData class.
		/// </summary>
		public AudioData()
			: this(ByteBuffer.Allocate(0)) {
		}
		/// <summary>
		/// Initializes a new instance of the AudioData class.
		/// </summary>
		/// <param name="data">AudioData buffer.</param>
		public AudioData(byte[] data)
			: this(ByteBuffer.Wrap(data)) {
		}

		#region IStreamData Members

		/// <summary>
		/// Gets audio data buffer.
		/// </summary>
		public ByteBuffer Data {
			get { return _data; }
		}

		#endregion

		/// <summary>
		/// Returns a string that represents the current object fields.
		/// </summary>
		/// <param name="indentLevel">The indentation level used for tracing the members.</param>
		/// <returns>A string that represents the current object fields.</returns>
		protected override string ToStringFields(int indentLevel) {
			string sep = GetFieldSeparator(indentLevel);
			string value = base.ToStringFields(indentLevel);
			value += sep + "data = " + (_data != null ? "buffer(" + _data.Length + ")" : "(null)");
			return value;
		}
	}
}
