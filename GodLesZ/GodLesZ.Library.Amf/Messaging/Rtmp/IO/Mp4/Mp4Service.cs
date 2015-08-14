using System.IO;
using GodLesZ.Library.Amf.IO;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.IO.Mp4 {
	class Mp4Service : BaseStreamableFileService, IMp4Service {
		private AMFWriter _amfWriter;

		public override string Prefix {
			get { return "mp4"; }
		}
		/// <summary>
		/// File extensions handled by this service.
		/// </summary>
		public override string Extension {
			get { return ".f4v,.mp4,.mov,.3gp,.3g2"; }
		}

		public override IStreamableFile GetStreamableFile(FileInfo file) {
			return new GodLesZ.Library.Amf.IO.Mp4.Mp4(file);
		}

		#region IMp4Service Members

		public AMFWriter Serializer {
			get {
				return _amfWriter;
			}
			set {
				_amfWriter = value;
			}
		}

		#endregion
	}
}
