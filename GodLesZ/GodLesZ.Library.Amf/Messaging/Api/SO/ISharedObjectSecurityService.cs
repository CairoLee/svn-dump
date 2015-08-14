using System;
using System.Collections;

namespace GodLesZ.Library.Amf.Messaging.Api.SO {
	/// <summary>
	/// Service that supports protecting access to shared objects.
	/// </summary>
	[CLSCompliant(false)]
	public interface ISharedObjectSecurityService : IService {
		/// <summary>
		/// Adds handler that protects shared objects.
		/// </summary>
		/// <param name="handler">The ISharedObjectSecurity handler.</param>
		void RegisterSharedObjectSecurity(ISharedObjectSecurity handler);
		/// <summary>
		/// Removes handler that protects shared objects.
		/// </summary>
		/// <param name="handler">The ISharedObjectSecurity handler.</param>
		void UnregisterSharedObjectSecurity(ISharedObjectSecurity handler);
		/// <summary>
		/// Gets the collection of security handlers that protect shared objects.
		/// </summary>
		/// <returns>Enumerator of ISharedObjectSecurity handlers.</returns>
		IEnumerator GetSharedObjectSecurity();
	}
}
