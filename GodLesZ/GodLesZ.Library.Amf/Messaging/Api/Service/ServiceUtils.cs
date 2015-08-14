using System;

namespace GodLesZ.Library.Amf.Messaging.Api.Service {
	/// <summary>
	/// Utility functions to invoke methods on connections.
	/// </summary>
	[CLSCompliant(false)]
	public class ServiceUtils {
		/// <summary>
		/// Invoke a method on the current connection.
		/// </summary>
		/// <param name="method">Name of the method to invoke.</param>
		/// <param name="args">Parameters to pass to the method.</param>
		/// <returns><code>true</code> if the connection supports method calls, otherwise <code>false</code></returns>
		public static bool InvokeOnConnection(string method, object[] args) {
			return InvokeOnConnection(method, args, null);
		}
		/// <summary>
		/// Invoke a method on the current connection and handle result.
		/// </summary>
		/// <param name="method">Name of the method to invoke.</param>
		/// <param name="args">Parameters to pass to the method.</param>
		/// <param name="callback">Object to notify when result is received.</param>
		/// <returns><code>true</code> if the connection supports method calls, otherwise <code>false</code></returns>
		public static bool InvokeOnConnection(string method, object[] args, IPendingServiceCallback callback) {
			IConnection connection = GodLesZ.Library.Amf.Context.FluorineContext.Current.Connection;
			return InvokeOnConnection(connection, method, args, callback);
		}
		/// <summary>
		/// Invoke a method on a given connection.
		/// </summary>
		/// <param name="connection">Connection to invoke method on.</param>
		/// <param name="method">Name of the method to invoke.</param>
		/// <param name="args">Parameters to pass to the method.</param>
		/// <returns><code>true</code> if the connection supports method calls, otherwise <code>false</code></returns>
		public static bool InvokeOnConnection(IConnection connection, string method, object[] args) {
			return InvokeOnConnection(connection, method, args, null);
		}
		/// <summary>
		/// Invoke a method on a given connection and handle result.
		/// </summary>
		/// <param name="connection">Connection to invoke method on.</param>
		/// <param name="method">Name of the method to invoke.</param>
		/// <param name="args">Parameters to pass to the method.</param>
		/// <param name="callback">Object to notify when result is received.</param>
		/// <returns><code>true</code> if the connection supports method calls, otherwise <code>false</code></returns>
		public static bool InvokeOnConnection(IConnection connection, string method, object[] args, IPendingServiceCallback callback) {
			if (connection is IServiceCapableConnection) {
				if (callback == null)
					(connection as IServiceCapableConnection).Invoke(method, args);
				else
					(connection as IServiceCapableConnection).Invoke(method, args, callback);
				return true;
			} else
				return false;
		}
	}
}
