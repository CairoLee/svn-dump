using System.IO;
using GodLesZ.Library.Amf.IO;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.IO {
	/// <summary>
	/// Base class for streamable file services.
	/// </summary>
	abstract class BaseStreamableFileService : IStreamableFileService {
		#region IStreamableFileService Members

		public abstract string Prefix { get; }

		public abstract string Extension { get; }

		public string PrepareFilename(string name) {
			string prefix = this.Prefix + ':';
			if (name.StartsWith(prefix)) {
				name = name.Substring(prefix.Length);
				if (name.LastIndexOf('.') != name.Length - 4) {
					name = name + this.Extension.Split(new char[] { ',' })[0];
				}
			}
			return name;
		}

		public bool CanHandle(FileInfo file) {
			bool valid = false;
			if (file.Exists) {
				string[] extensions = this.Extension.Split(new char[] { ',' });
				foreach (string extension in extensions) {
					if (extension == file.Extension) {
						valid = true;
						break;
					}
				}
			}
			return valid;
		}

		public abstract IStreamableFile GetStreamableFile(FileInfo file);

		#endregion
	}
}
