using System;
using System.IO;

namespace GodLesZ.Library.Amf.IO.Mp3 {
	/// <summary>
	/// Handles mp3 files.
	/// </summary>
	[CLSCompliant(false)]
	public class Mp3File : IMp3File {
		private FileInfo _file;

		/// <summary>
		/// Initializes a new instance of the <see cref="Mp3File"/> class.
		/// </summary>
		/// <param name="file">The file.</param>
		public Mp3File(FileInfo file) {
			_file = file;
		}

		#region IStreamableFile Members

		/// <summary>
		/// Returns a reader to parse and read the tags inside the file.
		/// </summary>
		/// <returns>Tag reader.</returns>
		public ITagReader GetReader() {
			return new Mp3Reader(_file);
		}

		/// <summary>
		/// Returns a writer that creates a new file or truncates existing contents.
		/// </summary>
		/// <returns>Tag writer.</returns>
		public ITagWriter GetWriter() {
			return null;
		}

		/// <summary>
		/// Returns a Writer which is setup to append to the file.
		/// </summary>
		/// <returns>Tag writer used for append mode.</returns>
		public ITagWriter GetAppendWriter() {
			return null;
		}

		#endregion
	}
}
