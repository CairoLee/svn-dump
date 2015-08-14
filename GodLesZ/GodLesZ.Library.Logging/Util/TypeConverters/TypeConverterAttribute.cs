using System;

namespace GodLesZ.Library.Logging.Util.TypeConverters {
	/// <summary>
	/// Attribute used to associate a type converter
	/// </summary>
	/// <remarks>
	/// <para>
	/// Class and Interface level attribute that specifies a type converter
	/// to use with the associated type.
	/// </para>
	/// <para>
	/// To associate a type converter with a target type apply a
	/// <c>TypeConverterAttribute</c> to the target type. Specify the
	/// type of the type converter on the attribute.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	/// <author>Gert Driesen</author>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum)]
	public sealed class TypeConverterAttribute : Attribute {
		#region Member Variables

		/// <summary>
		/// The string type name of the type converter
		/// </summary>
		private string m_typeName = null;

		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <remarks>
		/// <para>
		/// Default constructor
		/// </para>
		/// </remarks>
		public TypeConverterAttribute() {
		}

		/// <summary>
		/// Create a new type converter attribute for the specified type name
		/// </summary>
		/// <param name="typeName">The string type name of the type converter</param>
		/// <remarks>
		/// <para>
		/// The type specified must implement the <see cref="IConvertFrom"/> 
		/// or the <see cref="IConvertTo"/> interfaces.
		/// </para>
		/// </remarks>
		public TypeConverterAttribute(string typeName) {
			m_typeName = typeName;
		}

		/// <summary>
		/// Create a new type converter attribute for the specified type
		/// </summary>
		/// <param name="converterType">The type of the type converter</param>
		/// <remarks>
		/// <para>
		/// The type specified must implement the <see cref="IConvertFrom"/> 
		/// or the <see cref="IConvertTo"/> interfaces.
		/// </para>
		/// </remarks>
		public TypeConverterAttribute(Type converterType) {
			m_typeName = GodLesZ.Library.Logging.Util.SystemInfo.AssemblyQualifiedName(converterType);
		}

		#endregion

		/// <summary>
		/// The string type name of the type converter 
		/// </summary>
		/// <value>
		/// The string type name of the type converter 
		/// </value>
		/// <remarks>
		/// <para>
		/// The type specified must implement the <see cref="IConvertFrom"/> 
		/// or the <see cref="IConvertTo"/> interfaces.
		/// </para>
		/// </remarks>
		public string ConverterTypeName {
			get { return m_typeName; }
			set { m_typeName = value; }
		}
	}
}
