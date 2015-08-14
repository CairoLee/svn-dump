using System;
using System.Text.RegularExpressions;

using GodLesZ.Library.Logging;
using GodLesZ.Library.Logging.Core;
using GodLesZ.Library.Logging.Util;

namespace GodLesZ.Library.Logging.Filter {
	/// <summary>
	/// Simple filter to match a string in the <see cref="NDC"/>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Simple filter to match a string in the <see cref="NDC"/>
	/// </para>
	/// <para>
	/// As the MDC has been replaced with named stacks stored in the
	/// properties collections the <see cref="PropertyFilter"/> should 
	/// be used instead.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	/// <author>Gert Driesen</author>
	/*[Obsolete("NdcFilter has been replaced by PropertyFilter")]*/
	public class NdcFilter : PropertyFilter {
		/// <summary>
		/// Default constructor
		/// </summary>
		/// <remarks>
		/// <para>
		/// Sets the <see cref="PropertyFilter.Key"/> to <c>"NDC"</c>.
		/// </para>
		/// </remarks>
		public NdcFilter() {
			base.Key = "NDC";
		}
	}
}
