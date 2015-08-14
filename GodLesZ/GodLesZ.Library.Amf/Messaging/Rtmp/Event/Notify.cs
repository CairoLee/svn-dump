using System;
using System.Collections;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Event;
using GodLesZ.Library.Amf.Messaging.Api.Service;
using GodLesZ.Library.Amf.Messaging.Api.Stream;
using GodLesZ.Library.Amf.Messaging.Rtmp.Stream;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Event {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public class Notify : BaseEvent, IStreamData, IStreamPacket {
		/// <summary>
		/// Service call.
		/// </summary>
		protected IServiceCall _serviceCall = null;
		/// <summary>
		/// Event data.
		/// </summary>
		protected ByteBuffer _data = null;
		/// <summary>
		/// Invoke id.
		/// </summary>
		int _invokeId = 0;
		/// <summary>
		/// Connection parameters.
		/// </summary>
		IDictionary _connectionParameters;

		internal Notify()
			: base(EventType.SERVICE_CALL) {
			_dataType = Constants.TypeNotify;
		}

		internal Notify(ByteBuffer data)
			: this() {
			_data = data;
		}

		internal Notify(byte[] data)
			: this() {
			_data = ByteBuffer.Wrap(data);
		}

		internal Notify(IServiceCall serviceCall)
			: this() {
			_serviceCall = serviceCall;
		}
		/// <summary>
		/// Gets or sets event data.
		/// </summary>
		public ByteBuffer Data {
			get { return _data; }
			set { _data = value; }
		}
		/// <summary>
		/// Gets or sets invocation id.
		/// </summary>
		public int InvokeId {
			get { return _invokeId; }
			set { _invokeId = value; }
		}
		/// <summary>
		/// Gets or sets the service call.
		/// </summary>
		public IServiceCall ServiceCall {
			get { return _serviceCall; }
			set { _serviceCall = value; }
		}
		/// <summary>
		/// Gets or sets connection parameters.
		/// </summary>
		public IDictionary ConnectionParameters {
			get { return _connectionParameters; }
			set { _connectionParameters = value; }
		}
		/// <summary>
		/// Returns a string that represents the current object fields.
		/// </summary>
		/// <param name="indentLevel">The indentation level used for tracing the members.</param>
		/// <returns>A string that represents the current object fields.</returns>
		protected override string ToStringFields(int indentLevel) {
			string sep = GetFieldSeparator(indentLevel);
			string value = base.ToStringFields(indentLevel);
			value += sep + "invokeId = " + _invokeId;
			if (_serviceCall != null) {
				value += sep + "service = " + _serviceCall.ServiceName;
				value += sep + "operation = " + _serviceCall.ServiceMethodName;
				if (_serviceCall.Arguments != null)
					value += sep + "parameters = " + BodyToString(_serviceCall.Arguments, indentLevel + 1);
				if (_serviceCall is IPendingServiceCall)
					value += sep + "response = " + BodyToString((_serviceCall as IPendingServiceCall).Result, indentLevel + 1);
			}
			if (_connectionParameters != null)
				value += sep + "connectionParameters = " + BodyToString(_connectionParameters, indentLevel + 1);
			return value;
		}
	}
}
