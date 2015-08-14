using System.IO;
using GodLesZ.Library.Amf.IO;
using GodLesZ.Library.Amf.IO.Mp3;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.IO.Mp3 {
	/// <summary>
	/// Streamable file service extension for MP3.
	/// </summary>
	class Mp3Service : BaseStreamableFileService, IMp3Service {
		#region IStreamableFileService Members

		public override string Prefix {
			get { return "mp3"; }
		}

		public override string Extension {
			get { return ".mp3"; }
		}

		public override IStreamableFile GetStreamableFile(FileInfo file) {
			return new Mp3File(file);
		}

		#endregion
	}
}
