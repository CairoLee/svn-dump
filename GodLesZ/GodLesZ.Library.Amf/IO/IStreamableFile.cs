using System;

namespace GodLesZ.Library.Amf.IO {
	/// <summary>
	/// Interface represents streamable file with tag reader and writers (one for plain mode and one for append).
	/// </summary>
	[CLSCompliant(false)]
	public interface IStreamableFile {
		/// <summary>
		/// Returns a reader to parse and read the tags inside the file.
		/// </summary>
		/// <returns>Tag reader.</returns>
		ITagReader GetReader();
		/// <summary>
		/// Returns a writer that creates a new file or truncates existing contents. 
		/// </summary>
		/// <returns>Tag writer.</returns>
		ITagWriter GetWriter();
		/// <summary>
		/// Returns a Writer which is setup to append to the file.
		/// </summary>
		/// <returns>Tag writer used for append mode.</returns>
		ITagWriter GetAppendWriter();
	}
}
