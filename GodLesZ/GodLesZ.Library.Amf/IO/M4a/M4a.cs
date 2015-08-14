using System.IO;
using log4net;

namespace GodLesZ.Library.Amf.IO.M4a {
	/// <summary>
	/// M4a implements the IM4a API.
	/// </summary>
	class M4a : IM4a {
		private static readonly ILog log = LogManager.GetLogger(typeof(M4a));

		private FileInfo _file;

		public M4a(FileInfo file) {
			_file = file;
		}

		#region IStreamableFile Members

		public ITagReader GetReader() {
			return new M4aReader(_file);
		}

		public ITagWriter GetWriter() {
			return null;
		}

		public ITagWriter GetAppendWriter() {
			return null;
		}

		#endregion
	}
}
