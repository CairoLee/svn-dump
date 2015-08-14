using System;

#if !SILVERLIGHT

#endif
using GodLesZ.Library.Amf.Messaging.Api.Service;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Service {
	/// <summary>
	/// Basic service call (remote call) implementation.
	/// </summary>
	[CLSCompliant(false)]
	public class Call : IServiceCall {
		internal static readonly object[] EmptyArguments;

		/// <summary>
		/// Pending status constant.
		/// </summary>
		public const byte STATUS_PENDING = 0x01;
		/// <summary>
		/// Success result constant.
		/// </summary>
		public const byte STATUS_SUCCESS_RESULT = 0x02;
		/// <summary>
		/// Returned value is null constant.
		/// </summary>
		public const byte STATUS_SUCCESS_NULL = 0x03;
		/// <summary>
		/// Service returns no value constant.
		/// </summary>
		public const byte STATUS_SUCCESS_VOID = 0x04;
		/// <summary>
		/// Service not found constant.
		/// </summary>
		public const byte STATUS_SERVICE_NOT_FOUND = 0x10;
		/// <summary>
		/// Service's method not found constant.
		/// </summary>
		public const byte STATUS_METHOD_NOT_FOUND = 0x11;
		/// <summary>
		/// Access denied constant.
		/// </summary>
		public const byte STATUS_ACCESS_DENIED = 0x12;
		/// <summary>
		/// Exception on invocation constant.
		/// </summary>
		public const byte STATUS_INVOCATION_EXCEPTION = 0x13;
		/// <summary>
		/// General exception constant.
		/// </summary>
		public const byte STATUS_GENERAL_EXCEPTION = 0x14;
		/// <summary>
		/// The application for this service is currently shutting down.
		/// </summary>
		public const byte STATUS_APP_SHUTTING_DOWN = 0x15;

		/// <summary>
		/// Service name.
		/// </summary>
		protected string _serviceName;
		/// <summary>
		/// Service method name.
		/// </summary>
		protected string _serviceMethodName;
		/// <summary>
		/// Call arguments.
		/// </summary>
		protected object[] _arguments;
		/// <summary>
		/// Call status, initial one is pending.
		/// </summary>
		protected byte _status = STATUS_PENDING;
		/// <summary>
		/// Call exception if any, null by default.
		/// </summary>
		protected Exception _exception;

		static Call() {
			EmptyArguments = new object[0];
		}

		/// <summary>
		/// Initializes a new instance of the Call class.
		/// </summary>
		/// <param name="method">Method name.</param>
		public Call(string method) {
			_serviceMethodName = method;
		}
		/// <summary>
		/// Initializes a new instance of the Call class.
		/// </summary>
		/// <param name="method">Method name.</param>
		/// <param name="args">Call parameters.</param>
		public Call(string method, object[] args) {
			_serviceMethodName = method;
			_arguments = args;
		}
		/// <summary>
		/// Initializes a new instance of the Call class.
		/// </summary>
		/// <param name="name">Service name</param>
		/// <param name="method">Method name.</param>
		/// <param name="args">Call parameters.</param>
		public Call(string name, string method, object[] args) {
			_serviceName = name;
			_serviceMethodName = method;
			_arguments = args;
		}

		#region IServiceCall Members

		/// <summary>
		/// Gets a value indicating if the call was successful or not.
		/// </summary>
		public bool IsSuccess {
			get {
				return (_status == STATUS_SUCCESS_RESULT)
					|| (_status == STATUS_SUCCESS_NULL)
					|| (_status == STATUS_SUCCESS_VOID);
			}
		}
		/// <summary>
		/// Gets service method name.
		/// </summary>
		public string ServiceMethodName {
			get { return _serviceMethodName; }
		}
		/// <summary>
		/// Gets service name.
		/// </summary>
		public string ServiceName {
			get { return _serviceName; }
		}
		/// <summary>
		/// Gets array of service method arguments.
		/// </summary>
		public object[] Arguments {
			get { return _arguments; }
		}
		/// <summary>
		/// Gets or sets service call status.
		/// </summary>
		public byte Status {
			get {
				return _status;
			}
			set {
				_status = value;
			}
		}
		/// <summary>
		/// Get or sets service call exception.
		/// </summary>
		public Exception Exception {
			get {
				return _exception;
			}
			set {
				_exception = value;
			}
		}

		#endregion
	}
}
