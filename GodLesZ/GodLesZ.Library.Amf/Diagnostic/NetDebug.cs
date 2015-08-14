using System;
using System.Collections;

namespace GodLesZ.Library.Amf {

	/// <summary>
	/// NetDebug remote trace.<br/>
	/// Controls the information that appears in the NetConnection Debugger.
	/// </summary>
	public class NetDebug {
		private static ArrayList _traceStack;

		/// <summary>
		/// Initializes a new instance of the NetDebug class.
		/// </summary>
		private NetDebug() {
		}
		/// <summary>
		/// Initializes a new instance of the NetDebug class.
		/// </summary>
		static NetDebug() {
			_traceStack = ArrayList.Synchronized(new ArrayList());
		}

		/// <summary>
		/// Displays a trace message in the NetConnection Debugger.
		/// </summary>
		/// <param name="message">Message to display.</param>
		public static void Trace(string message) {
#if DEBUG
			if (message != null)
				_traceStack.Add(message);
#endif
		}
		/// <summary>
		/// Displays an object in the NetConnection Debugger.
		/// </summary>
		/// <param name="obj">Object to display.</param>
		public static void Trace(object obj) {
#if DEBUG
			if (obj != null)
				_traceStack.Add(obj);
#endif
		}

		internal static ArrayList GetTraceStack() {
			return _traceStack;
		}
		/// <summary>
		/// Clear messages collected to display.
		/// </summary>
		public static void Clear() {
			_traceStack.Clear();
		}
	}
}
