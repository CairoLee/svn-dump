using System;

namespace GodLesZ.Library.Logging.Util.TypeConverters {
	/// <summary>
	/// Type converter for Boolean.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Supports conversion from string to <c>bool</c> type.
	/// </para>
	/// </remarks>
	/// <seealso cref="ConverterRegistry"/>
	/// <seealso cref="IConvertFrom"/>
	/// <seealso cref="IConvertTo"/>
	/// <author>Nicko Cadell</author>
	/// <author>Gert Driesen</author>
	internal class BooleanConverter : IConvertFrom {
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
		public bool CanConvertFrom(Type sourceType) {
			return (sourceType == typeof(string));
		}

		/// <summary>
		/// Convert the source object to the type supported by this object
		/// </summary>
		/// <param name="source">the object to convert</param>
		/// <returns>the converted object</returns>
		/// <remarks>
		/// <para>
		/// Uses the <see cref="Boolean.Parse"/> method to convert the
		/// <see cref="String"/> argument to a <see cref="Boolean"/>.
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
				return bool.Parse(str);
			}
			throw ConversionNotSupportedException.Create(typeof(bool), source);
		}

		#endregion
	}
}
