using System;
using System.IO;
using GodLesZ.Library.Amf.IO;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.IO {
	/// <summary>
	/// Provides access to files that can be streamed.
	/// </summary>
	[CLSCompliant(false)]
	public interface IStreamableFileService {
		/// <summary>
		/// Gets prefix. Prefix is used in filename composition to fetch real file name.
		/// </summary>
		string Prefix { get; }
		/// <summary>
		/// Gets for extension of file
		/// </summary>
		string Extension { get; }
		/// <summary>
		/// Prepair given string to conform filename requirements, for example, add
		/// extension to the end if missing.
		/// </summary>
		/// <param name="name">String to format.</param>
		/// <returns>Filename.</returns>
		string PrepareFilename(string name);
		/// <summary>
		/// Checks whether file can be used by file service, that is, it does exist and have valid extension.
		/// </summary>
		/// <param name="file">FileInfo object.</param>
		/// <returns>true if file exist and has valid extension, false otherwise</returns>
		bool CanHandle(FileInfo file);
		/// <summary>
		/// Returns streamable file reference. For FLV files returned streamable file already has generated metadata injected.
		/// </summary>
		/// <param name="file">File resource.</param>
		/// <returns>Streamable file resource.s</returns>
		IStreamableFile GetStreamableFile(FileInfo file);
	}
}
