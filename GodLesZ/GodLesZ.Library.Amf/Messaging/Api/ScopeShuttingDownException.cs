using System;
using GodLesZ.Library.Amf.Exceptions;

namespace GodLesZ.Library.Amf.Messaging.Api {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public class ScopeShuttingDownException : FluorineException {
		/// <summary>
		/// Initializes a new instance of the ScopeNotFoundException class.
		/// </summary>
		/// <param name="scope"></param>
		public ScopeShuttingDownException(IScope scope)
			: base("Scope shutting down: " + scope) {
		}
	}
}
