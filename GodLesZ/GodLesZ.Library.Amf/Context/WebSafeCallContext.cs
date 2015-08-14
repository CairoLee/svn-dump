using System;
using System.Collections.Generic;
#if !FXCLIENT
using System.Web;
#endif
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Security.Permissions;

namespace GodLesZ.Library.Amf.Context {
	sealed class WebSafeCallContext {
		private WebSafeCallContext() {
		}

		public static object GetData(string name) {
#if !FXCLIENT
			HttpContext ctx = HttpContext.Current;
			if (ctx == null)
				return CallContext.GetData(name);
			return ctx.Items[name];
#else
            return CallContext.GetData(name);
#endif
		}

		public static void SetData(string name, object value) {
#if !FXCLIENT
			HttpContext ctx = HttpContext.Current;
			if (ctx == null)
				CallContext.SetData(name, value);
			else
				ctx.Items[name] = value;
#else
            CallContext.SetData(name, value);
#endif
		}

		public static void FreeNamedDataSlot(string name) {
#if !FXCLIENT
			HttpContext ctx = HttpContext.Current;
			if (ctx == null)
				CallContext.FreeNamedDataSlot(name);
			else
				ctx.Items.Remove(name);
#else
            CallContext.FreeNamedDataSlot(name);
#endif
		}
	}

	/// <summary>
	/// Provides a set of properties that are carried with the execution code path. This class cannot be inherited.
	/// <remarks>
	/// FluorineWebSafeCallContext is a specialized object similar to a Thread Local Storage for method calls and provides data slots that are unique to each logical thread of execution.
	/// </remarks>
	/// </summary>
	public sealed class FluorineWebSafeCallContext {
		[ThreadStatic]
		private static Dictionary<string, object> _data;

		private FluorineWebSafeCallContext() {
		}

		private static Dictionary<string, object> Data {
			get {
				if (_data == null)
					_data = new Dictionary<string, object>();
				return _data;
			}
		}

		/// <summary>
		/// Retrieves an object with the specified name from the FluorineWebSafeCallContext.
		/// </summary>
		/// <param name="name">The name of the item in the call context.</param>
		/// <returns>The object in the call context associated with the specified name.</returns>
		public static object GetData(string name) {
#if !FXCLIENT
			HttpContext ctx = HttpContext.Current;
			if (ctx != null)
				return ctx.Items[name];
#endif
			object value;
			try {
				// See if we're running in full trust
				new SecurityPermission(SecurityPermissionFlag.Infrastructure).Demand();
				value = WebSafeCallContext.GetData(name);
			} catch (SecurityException) {
				value = Data[name];
			}
			return value;
		}
		/// <summary>
		/// Stores a given object and associates it with the specified name. 
		/// </summary>
		/// <param name="name">The name with which to associate the new item in the call context.</param>
		/// <param name="value">The object to store in the call context.</param>
		public static void SetData(string name, object value) {
#if !FXCLIENT
			HttpContext ctx = HttpContext.Current;
			if (ctx != null) {
				ctx.Items[name] = value;
				return;
			}
#endif
			try {
				// See if we're running in full trust
				new SecurityPermission(SecurityPermissionFlag.Infrastructure).Demand();
				WebSafeCallContext.SetData(name, value);
			} catch (SecurityException) {
				Data[name] = value;
			}
		}
		/// <summary>
		/// Empties a data slot with the specified name.
		/// </summary>
		/// <param name="name">The name of the data slot to empty.</param>
		public static void FreeNamedDataSlot(string name) {
#if !FXCLIENT
			HttpContext ctx = HttpContext.Current;
			if (ctx != null) {
				ctx.Items.Remove(name);
				return;
			}
#endif

			try {
				// See if we're running in full trust
				new SecurityPermission(SecurityPermissionFlag.Infrastructure).Demand();
				WebSafeCallContext.FreeNamedDataSlot(name);
			} catch (SecurityException) {
				Data.Remove(name);
			}
		}
	}
}
