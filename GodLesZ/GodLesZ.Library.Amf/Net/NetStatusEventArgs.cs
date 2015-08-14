using System;
using GodLesZ.Library.Amf.Messaging.Rtmp;

namespace GodLesZ.Library.Amf.Net {
	/// <summary>
	/// Base event arguments for connection events.
	/// A NetConnection or SharedObject object dispatches NetStatusEvent objects when it reports its status.
	/// </summary>
	public class NetStatusEventArgs : EventArgs {
		readonly Exception _exception;
		readonly ASObject _info;

		internal NetStatusEventArgs(Exception exception) {
			_exception = exception;
			_info = new ASObject();
			_info["level"] = "error";
			_info["code"] = StatusASO.NC_CALL_FAILED;
			//_info["description"] = exception.Message;
			_info["details"] = exception.Message;
		}

		internal NetStatusEventArgs(string code, Exception exception) {
			_exception = exception;
			_info = new ASObject();
			_info["level"] = "error";
			_info["code"] = code;
			//_info["description"] = exception.Message;
			_info["details"] = exception.Message;
		}

		internal NetStatusEventArgs(string message) {
			_info = new ASObject();
			_info["level"] = "error";
			_info["code"] = StatusASO.NC_CALL_FAILED;
			//_info["description"] = message;
			_info["details"] = message;
		}

		internal NetStatusEventArgs(ASObject info) {
			_info = info;
		}

		#region Properties

		/// <summary>
		/// Gets the exception associated with the current NetStatusEvent instance.
		/// </summary>
		/// <remarks>
		/// This member is available only when a client side exception has occured.
		/// </remarks>
		public Exception Exception {
			get { return _exception; }
		}
		/// <summary>
		/// Gets an object with properties that describe the object's status or error condition.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The information object could have a code property containing a string that represents a specific event or a level property containing a string that is either "status" or "error". 
		/// </para>
		/// <para>
		/// The code and level properties might not work for some implementations and some servers might send different objects. 
		/// </para>
		/// <para>
		/// The following table describes common string values of the code and level properties:
		/// <list type="table">
		/// <listheader>
		/// <term>code property (level)</term>
		/// <description>meaning</description>
		/// </listheader>
		/// <item><term>NetConnection.Call.BadVersion (error)</term>
		/// <description>Packet encoded in an unidentified format.</description></item>
		/// <item><term>NetConnection.Call.Failed (error)</term>
		/// <description>The NetConnection.call method was not able to invoke the server-side method or command.</description></item>
		/// <item><term>NetConnection.Connect.Failed (error)</term>
		/// <description>The connection attempt failed.</description></item>
		/// <item><term>NetConnection.Connect.Success (status)</term>
		/// <description>The connection attempt succeeded.</description></item>
		/// <item><term>NetConnection.Connect.Rejected (error)</term>
		/// <description>The connection attempt did not have permission to access the application.</description></item>
		/// <item><term>NetConnection.Connect.InvalidApp (error)</term>
		/// <description>The application name specified during connect is invalid.</description></item>
		/// </list>
		/// </para>
		/// </remarks>
		public ASObject Info {
			get { return _info; }
		}

		#endregion
	}
}
