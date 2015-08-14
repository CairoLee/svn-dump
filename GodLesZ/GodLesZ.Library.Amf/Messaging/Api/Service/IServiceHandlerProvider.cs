using System;
using System.Collections.Generic;

namespace GodLesZ.Library.Amf.Messaging.Api.Service {
	/// <summary>
	/// Supports registration and lookup of service handlers.
	/// </summary>
	/// <example>
	/// If you registered a handler with the name "<code>one.two</code>" that
	/// provides a method "<code>callMe</code>", you can call the method with "<code>one.two.callMe</code>" from the client.
	/// </example>
	public interface IServiceHandlerProvider {
		/// <summary>
		/// Registers an object that provides methods which can be called from a client.
		/// </summary>
		/// <param name="name">The name of the handler.</param>
		/// <param name="handler">The handler object.</param>
		void RegisterServiceHandler(string name, object handler);
		/// <summary>
		/// Unregisters service handler.
		/// </summary>
		/// <param name="name">The name of the handler.</param>
		void UnregisterServiceHandler(string name);
		/// <summary>
		/// Returns a previously registered service handler.
		/// </summary>
		/// <param name="name">The name of the handler to return.</param>
		/// <returns>The previously registered handler.</returns>
		object GetServiceHandler(string name);
		/// <summary>
		/// Gets a list of registered service handler names.
		/// </summary>
		/// <returns>The names of the registered handlers.</returns>
		ICollection<String> GetServiceHandlerNames();
	}
}
