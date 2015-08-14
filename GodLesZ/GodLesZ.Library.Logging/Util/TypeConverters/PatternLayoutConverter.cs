using System;
using System.Text;

using GodLesZ.Library.Logging.Layout;

namespace GodLesZ.Library.Logging.Util.TypeConverters {
	/// <summary>
	/// Supports conversion from string to <see cref="PatternLayout"/> type.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Supports conversion from string to <see cref="PatternLayout"/> type.
	/// </para>
	/// <para>
	/// The string is used as the <see cref="PatternLayout.ConversionPattern"/> 
	/// of the <see cref="PatternLayout"/>.
	/// </para>
	/// </remarks>
	/// <seealso cref="ConverterRegistry"/>
	/// <seealso cref="IConvertFrom"/>
	/// <seealso cref="IConvertTo"/>
	/// <author>Nicko Cadell</author>
	internal class PatternLayoutConverter : IConvertFrom {
		#region Implementation of IConvertFrom

		/// <summary>
		/// Can the source type be converted to the type supported by this object
		/// </summary>
		/// <param name="sourceType">the type to convert</param>
		/// <returns>true if the conversion is possible</returns>
		/// <remarks>
		/// <para>
		/// Returns <c>true</c> if the <paramref name="sourceType"/> is
		/// the <see cref="String"/> type.
		/// </para>
		/// </remarks>
		public bool CanConvertFrom(System.Type sourceType) {
			return (sourceType == typeof(string));
		}

		/// <summary>
		/// Overrides the ConvertFrom method of IConvertFrom.
		/// </summary>
		/// <param name="source">the object to convert to a PatternLayout</param>
		/// <returns>the PatternLayout</returns>
		/// <remarks>
		/// <para>
		/// Creates and returns a new <see cref="PatternLayout"/> using
		/// the <paramref name="source"/> <see cref="String"/> as the
		/// <see cref="PatternLayout.ConversionPattern"/>.
		/// </para>
		/// </remarks>
		/// <exception cref="ConversionNotSupportedException">
		/// The <paramref name="source"/> object cannot be converted to the
		/// target type. To check for this condition use the <see cref="CanConvertFrom"/>
		/// method.
		/// </exception>
		public object ConvertFrom(object source) {
			string str = source as string;
			if (str != null) {
				return new PatternLayout(str);
			}
			throw ConversionNotSupportedException.Create(typeof(PatternLayout), source);
		}

		#endregion
	}
}
