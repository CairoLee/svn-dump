using System;
using System.Text;

namespace GodLesZ.Library.Logging.DateFormatter {
	/// <summary>
	/// Formats the <see cref="DateTime"/> as <c>"yyyy-MM-dd HH:mm:ss,fff"</c>.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Formats the <see cref="DateTime"/> specified as a string: <c>"yyyy-MM-dd HH:mm:ss,fff"</c>.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	/// <author>Gert Driesen</author>
	public class Iso8601DateFormatter : AbsoluteTimeDateFormatter {
		#region Public Instance Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <remarks>
		/// <para>
		/// Initializes a new instance of the <see cref="Iso8601DateFormatter" /> class.
		/// </para>
		/// </remarks>
		public Iso8601DateFormatter() {
		}

		#endregion Public Instance Constructors

		#region Override implementation of AbsoluteTimeDateFormatter

		/// <summary>
		/// Formats the date without the milliseconds part
		/// </summary>
		/// <param name="dateToFormat">The date to format.</param>
		/// <param name="buffer">The string builder to write to.</param>
		/// <remarks>
		/// <para>
		/// Formats the date specified as a string: <c>"yyyy-MM-dd HH:mm:ss"</c>.
		/// </para>
		/// <para>
		/// The base class will append the <c>",fff"</c> milliseconds section.
		/// This method will only be called at most once per second.
		/// </para>
		/// </remarks>
		override protected void FormatDateWithoutMillis(DateTime dateToFormat, StringBuilder buffer) {
			buffer.Append(dateToFormat.Year);

			buffer.Append('-');
			int month = dateToFormat.Month;
			if (month < 10) {
				buffer.Append('0');
			}
			buffer.Append(month);
			buffer.Append('-');

			int day = dateToFormat.Day;
			if (day < 10) {
				buffer.Append('0');
			}
			buffer.Append(day);
			buffer.Append(' ');

			// Append the 'HH:mm:ss'
			base.FormatDateWithoutMillis(dateToFormat, buffer);
		}

		#endregion Override implementation of AbsoluteTimeDateFormatter
	}
}
