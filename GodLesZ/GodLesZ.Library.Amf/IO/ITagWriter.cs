using System;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.IO {
	/// <summary>
	/// Writes tags to FLV file.
	/// </summary>
	[CLSCompliant(false)]
	public interface ITagWriter {
		/// <summary>
		/// Gets the file that is loaded.
		/// </summary>
		IStreamableFile File { get; }
		/// <summary>
		/// Gets the position.
		/// </summary>
		long Position { get; }
		/// <summary>
		/// Gets the amount of bytes written.
		/// </summary>
		long BytesWritten { get; }
		/// <summary>
		/// Writes the header bytes.
		/// </summary>
		void WriteHeader();
		/// <summary>
		/// Writes a Tag object.
		/// </summary>
		/// <param name="tag">Tag to write.</param>
		/// <returns>true on success, false otherwise.</returns>
		bool WriteTag(ITag tag);
		/// <summary>
		/// Write a Tag using bytes.
		/// </summary>
		/// <param name="type">Tag type.</param>
		/// <param name="data">Byte data.</param>
		/// <returns>true on success, false otherwise.</returns>
		bool WriteTag(byte type, ByteBuffer data);
		/// <summary>
		/// Write a Stream to disk using bytes.
		/// </summary>
		/// <param name="buffer">Array of bytes to write.</param>
		/// <returns>true on success, false otherwise.</returns>
		bool WriteStream(byte[] buffer);
		/// <summary>
		/// Closes a writer.
		/// </summary>
		void Close();
	}
}
