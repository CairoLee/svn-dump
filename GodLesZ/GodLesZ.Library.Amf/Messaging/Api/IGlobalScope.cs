using System;

namespace GodLesZ.Library.Amf.Messaging.Api {
	/// <summary>
	/// The global scope that acts as root for all applications in a host.
	/// </summary>
	[CLSCompliant(false)]
	public interface IGlobalScope : IScope {
		/// <summary>
		/// Register the global scope in the server and initialize it.
		/// </summary>
		void Register();
	}
}
