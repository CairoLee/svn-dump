using System.IO;
using GodLesZ.Library.Amf.IO;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.IO.M4a {
	class M4aService : BaseStreamableFileService, IM4aService {
		private AMFWriter _amfWriter;

		public override string Prefix {
			get { return "f4a"; }
		}

		/// <summary>
		/// Gets the file extensions handled by this service.
		/// </summary>
		/// <value>The extensions.</value>
		public override string Extension {
			get { return ".f4a,.m4a,.aac"; }
		}

		public override IStreamableFile GetStreamableFile(FileInfo file) {
			return new GodLesZ.Library.Amf.IO.M4a.M4a(file);
		}

		#region IM4aService Members

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
