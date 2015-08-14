using System;

using GodLesZ.Library.Logging.Core;

namespace GodLesZ.Library.Logging.Filter {
	/// <summary>
	/// This filter drops all <see cref="LoggingEvent"/>. 
	/// </summary>
	/// <remarks>
	/// <para>
	/// You can add this filter to the end of a filter chain to
	/// switch from the default "accept all unless instructed otherwise"
	/// filtering behavior to a "deny all unless instructed otherwise"
	/// behavior.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	/// <author>Gert Driesen</author>
	public sealed class DenyAllFilter : FilterSkeleton {
		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		public DenyAllFilter() {
		}

		#endregion

		#region Override implementation of FilterSkeleton

		/// <summary>
		/// Always returns the integer constant <see cref="FilterDecision.Deny"/>
		/// </summary>
		/// <param name="loggingEvent">the LoggingEvent to filter</param>
		/// <returns>Always returns <see cref="FilterDecision.Deny"/></returns>
		/// <remarks>
		/// <para>
		/// Ignores the event being logged and just returns
		/// <see cref="FilterDecision.Deny"/>. This can be used to change the default filter
		/// chain behavior from <see cref="FilterDecision.Accept"/> to <see cref="FilterDecision.Deny"/>. This filter
		/// should only be used as the last filter in the chain
		/// as any further filters will be ignored!
		/// </para>
		/// </remarks>
		override public FilterDecision Decide(LoggingEvent loggingEvent) {
			return FilterDecision.Deny;
		}

		#endregion
	}
}
