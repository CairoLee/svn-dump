using System;

namespace GodLesZ.Library.Amf.IO {
	/// <summary>
	/// Tag reader interface.
	/// </summary>
	[CLSCompliant(false)]
	public interface ITagReader {
		/// <summary>
		/// Gets the file that is loaded.
		/// </summary>
		IStreamableFile File { get; }
		/// <summary>
		/// Gets the offet length.
		/// </summary>
		int Offset { get; }
		/// <summary>
		/// Gets the amount of bytes read.
		/// </summary>
		long BytesRead { get; }
		/// <summary>
		/// Gets length in milliseconds.
		/// </summary>
		long Duration { get; }
		/// <summary>
		/// Decode the header of the stream.
		/// </summary>
		void DecodeHeader();
		/// <summary>
		/// Moves the reader pointer to given position in file.
		/// </summary>
		long Position { get; set; }
		/// <summary>
		/// Returns a boolean stating whether the FLV has more tags.
		/// </summary>
		/// <returns></returns>
		bool HasMoreTags();
		/// <summary>
		/// Returns a Tag object.
		/// </summary>
		/// <returns>Tag.</returns>
		ITag ReadTag();
		/// <summary>
		/// Closes the reader and free any allocated memory.
		/// </summary>
		void Close();
		/// <summary>
		/// Checks if the reader also has video tags.
		/// </summary>
		/// <returns></returns>
		bool HasVideo();
	}
}
