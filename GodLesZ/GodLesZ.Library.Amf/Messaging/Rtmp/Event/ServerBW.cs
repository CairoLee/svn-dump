using System;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Event;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Event {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public sealed class ServerBW : BaseEvent {
		private int _bandwidth;

		internal ServerBW(int bandwidth)
			: base(EventType.STREAM_CONTROL) {
			_dataType = Constants.TypeServerBandwidth;
			_bandwidth = bandwidth;
		}
		/// <summary>
		/// Gets or sets the bandwidth value.
		/// </summary>
		public int Bandwidth {
			get { return _bandwidth; }
			set { _bandwidth = value; }
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
			return value;
		}
	}
}
