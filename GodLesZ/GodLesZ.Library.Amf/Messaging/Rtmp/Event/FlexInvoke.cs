using System;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Event {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public sealed class FlexInvoke : Invoke {
		/// <summary>
		/// Method name
		/// </summary>
		//string _cmd;
		/// <summary>
		/// Response
		/// </summary>
		object _cmdData;
		//object[] _parameters;
		//object	_response;

		internal FlexInvoke()
			: base() {
			_dataType = Constants.TypeFlexInvoke;
			//SetResponseSuccess();
		}

		internal FlexInvoke(int invokeId, object cmdData)
			: this() {
			//_cmd = cmd;
			this.InvokeId = invokeId;
			_cmdData = cmdData;
			//_parameters = parameters;
		}

		internal FlexInvoke(ByteBuffer data)
			: base(data) {
			_dataType = Constants.TypeFlexInvoke;
		}
		/*
		/// <summary>
		/// Gets or sets the parameters.
		/// </summary>
		public object[] Parameters
		{ 
			get{ return _parameters; } 
			set{ _parameters = value; } 
		}
		/// <summary>
		/// Gets or sets the command.
		/// </summary>
		public string Cmd
		{ 
			get{ return _cmd; } 
			set{ _cmd = value; }
		}
		/// <summary>
		/// Gets or sets the response object.
		/// </summary>
		public object Response
		{
			get{ return _response; } 
			set{ _response = value; } 
		}
		/// <summary>
		/// Sets success response.
		/// </summary>
		public void SetResponseSuccess()
		{
			_cmd = "_result";
		}
		/// <summary>
		/// Sets failure response.
		/// </summary>
		public void SetResponseFailure()
		{
			_cmd = "_error";
		}
		*/
		/// <summary>
		/// Gets or sets the command data.
		/// </summary>
		public object CmdData {
			get { return _cmdData; }
		}
		/// <summary>
		/// Returns a string that represents the current object fields.
		/// </summary>
		/// <param name="indentLevel">The indentation level used for tracing the members.</param>
		/// <returns>A string that represents the current object fields.</returns>
		protected override string ToStringFields(int indentLevel) {
			string sep = GetFieldSeparator(indentLevel);
			string value = base.ToStringFields(indentLevel);
			//value += sep + "cmd = " + BodyToString(_cmd, indentLevel + 1);
			value += sep + "cmdData = " + _cmdData;
			//value += sep + "parameters = " + BodyToString(_parameters, indentLevel + 1);
			//value += sep + "response = " + BodyToString(_response, indentLevel + 1);
			return value;
		}
	}
}
