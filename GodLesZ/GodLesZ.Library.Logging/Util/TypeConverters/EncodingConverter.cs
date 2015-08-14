using System;
using System.Text;

namespace GodLesZ.Library.Logging.Util.TypeConverters {
	/// <summary>
	/// Supports conversion from string to <see cref="Encoding"/> type.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Supports conversion from string to <see cref="Encoding"/> type.
	/// </para>
	/// </remarks>
	/// <seealso cref="ConverterRegistry"/>
	/// <seealso cref="IConvertFrom"/>
	/// <seealso cref="IConvertTo"/>
	/// <author>Nicko Cadell</author>
	/// <author>Gert Driesen</author>
	internal class EncodingConverter : IConvertFrom {
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
		/// Overrides the ConvertFrom method of IConvertFrom.
		/// </summary>
		/// <param name="source">the object to convert to an encoding</param>
		/// <returns>the encoding</returns>
		/// <remarks>
		/// <para>
		/// Uses the <see cref="Encoding.GetEncoding(string)"/> method to 
		/// convert the <see cref="String"/> argument to an <see cref="Encoding"/>.
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
				return Encoding.GetEncoding(str);
			}
			throw ConversionNotSupportedException.Create(typeof(Encoding), source);
		}

		#endregion
	}
}
