using System;
using System.Text.RegularExpressions;

using GodLesZ.Library.Logging;
using GodLesZ.Library.Logging.Core;
using GodLesZ.Library.Logging.Util;

namespace GodLesZ.Library.Logging.Filter {
	/// <summary>
	/// Simple filter to match a keyed string in the <see cref="MDC"/>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Simple filter to match a keyed string in the <see cref="MDC"/>
	/// </para>
	/// <para>
	/// As the MDC has been replaced with layered properties the
	/// <see cref="PropertyFilter"/> should be used instead.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	/// <author>Gert Driesen</author>
	/*[Obsolete("MdcFilter has been replaced by PropertyFilter")]*/
	public class MdcFilter : PropertyFilter {
	}
}
