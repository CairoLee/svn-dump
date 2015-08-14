using System;
using System.IO;

namespace GodLesZ.Library.Logging.DateFormatter {
	/// <summary>
	/// Formats the <see cref="DateTime"/> using the <see cref="DateTime.ToString(string, IFormatProvider)"/> method.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Formats the <see cref="DateTime"/> using the <see cref="DateTime"/> <see cref="DateTime.ToString(string, IFormatProvider)"/> method.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	/// <author>Gert Driesen</author>
	public class SimpleDateFormatter : IDateFormatter {
		#region Public Instance Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="format">The format string.</param>
		/// <remarks>
		/// <para>
		/// Initializes a new instance of the <see cref="SimpleDateFormatter" /> class 
		/// with the specified format string.
		/// </para>
		/// <para>
		/// The format string must be compatible with the options
		/// that can be supplied to <see cref="DateTime.ToString(string, IFormatProvider)"/>.
		/// </para>
		/// </remarks>
		public SimpleDateFormatter(string format) {
			m_formatString = format;
		}

		#endregion Public Instance Constructors

		#region Implementation of IDateFormatter

		/// <summary>
		/// Formats the date using <see cref="DateTime.ToString(string, IFormatProvider)"/>.
		/// </summary>
		/// <param name="dateToFormat">The date to convert to a string.</param>
		/// <param name="writer">The writer to write to.</param>
		/// <remarks>
		/// <para>
		/// Uses the date format string supplied to the constructor to call
		/// the <see cref="DateTime.ToString(string, IFormatProvider)"/> method to format the date.
		/// </para>
		/// </remarks>
		virtual public void FormatDate(DateTime dateToFormat, TextWriter writer) {
			writer.Write(dateToFormat.ToString(m_formatString, System.Globalization.DateTimeFormatInfo.InvariantInfo));
		}

		#endregion

		#region Private Instance Fields

		/// <summary>
		/// The format string used to format the <see cref="DateTime" />.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The format string must be compatible with the options
		/// that can be supplied to <see cref="DateTime.ToString(string, IFormatProvider)"/>.
		/// </para>
		/// </remarks>
		private readonly string m_formatString;

		#endregion Private Instance Fields
	}
}
