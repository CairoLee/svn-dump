using System;

namespace GodLesZ.Library.Amf.IO {
	/// <summary>
	/// A Tag represents the contents or payload of a streamable file.
	/// </summary>
	[CLSCompliant(false)]
	public interface ITag {
		/// <summary>
		/// Gers or sets body as byte buffer.
		/// </summary>
		byte[] Body { get; set; }
		/// <summary>
		/// Gets or sets the size of the body.
		/// </summary>
		int BodySize { get; }
		/// <summary>
		/// Gets or sets the data type.
		/// </summary>
		byte DataType { get; set; }
		/// <summary>
		/// Gets or sets timestamp.
		/// </summary>
		int Timestamp { get; set; }
		/// <summary>
		/// Gets or sets the size of the previous tag.
		/// </summary>
		int PreviousTagSize { get; set; }
	}
}
