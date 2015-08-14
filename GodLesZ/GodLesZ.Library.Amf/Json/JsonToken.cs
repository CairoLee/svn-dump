
namespace GodLesZ.Library.Amf.Json {
	/// <summary>
	/// Specifies the type of Json token.
	/// </summary>
	public enum JsonToken {
		/// <summary>
		/// This is returned by the <see cref="JsonReader"/> if a <see cref="JsonReader.Read"/> method has not been called. 
		/// </summary>
		None,
		/// <summary>
		/// An object start token.
		/// </summary>
		StartObject,
		/// <summary>
		/// An array start token.
		/// </summary>
		StartArray,
		/// <summary>
		/// An object property name.
		/// </summary>
		PropertyName,
		/// <summary>
		/// A comment.
		/// </summary>
		Comment,
		/// <summary>
		/// An interger.
		/// </summary>
		Integer,
		/// <summary>
		/// A float.
		/// </summary>
		Float,
		/// <summary>
		/// A string.
		/// </summary>
		String,
		/// <summary>
		/// A boolean.
		/// </summary>
		Boolean,
		/// <summary>
		/// A null token.
		/// </summary>
		Null,
		/// <summary>
		/// An undefined token.
		/// </summary>
		Undefined,
		/// <summary>
		/// An object end token.
		/// </summary>
		EndObject,
		/// <summary>
		/// An array end token.
		/// </summary>
		EndArray,
		/// <summary>
		/// A JavaScript object constructor.
		/// </summary>
		Constructor,
		/// <summary>
		/// A Date.
		/// </summary>
		Date
	}
}
