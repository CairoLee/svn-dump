using System;
using GodLesZ.Library.Amf.Messaging.Api.Service;

namespace GodLesZ.Library.Amf.Messaging.Api.SO {
	/// <summary>
	/// Supports registration and lookup of shared object handlers.
	/// <para>
	/// Shared object handlers will be called through remoteSO.send(<i>handler</i>, <i>args</i>) from a Flash client or the corresponding serverside call. The calls will be be mapped to shared object handler methods.
	/// </para>
	/// </summary>
	public interface ISharedObjectHandlerProvider : IServiceHandlerProvider {
		/// <summary>
		/// Registers an object that provides an unnamed shared object handler that will handle calls.
		/// </summary>
		/// <param name="handler">The handler object.</param>
		void RegisterServiceHandler(Object handler);
		/// <summary>
		/// Unregisters a shared object handler without a service name.
		/// </summary>
		void UnregisterServiceHandler();
	}
}
