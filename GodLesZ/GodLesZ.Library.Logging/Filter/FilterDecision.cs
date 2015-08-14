using System;

using GodLesZ.Library.Logging.Core;

namespace GodLesZ.Library.Logging.Filter {
	/// <summary>
	/// The return result from <see cref="IFilter.Decide"/>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The return result from <see cref="IFilter.Decide"/>
	/// </para>
	/// </remarks>
	public enum FilterDecision : int {
		/// <summary>
		/// The log event must be dropped immediately without 
		/// consulting with the remaining filters, if any, in the chain.
		/// </summary>
		Deny = -1,

		/// <summary>
		/// This filter is neutral with respect to the log event. 
		/// The remaining filters, if any, should be consulted for a final decision.
		/// </summary>
		Neutral = 0,

		/// <summary>
		/// The log event must be logged immediately without 
		/// consulting with the remaining filters, if any, in the chain.
		/// </summary>
		Accept = 1,
	}
}
