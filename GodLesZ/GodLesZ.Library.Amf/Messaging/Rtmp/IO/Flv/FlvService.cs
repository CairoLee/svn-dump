using System.IO;
using GodLesZ.Library.Amf.IO;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.IO.Flv {
	/// <summary>
	/// Sets up the service and hands out FLV objects to its callers
	/// </summary>
	class FlvService : BaseStreamableFileService, IFlvService {
		private AMFWriter _amfWriter;
		private AMFReader _amfReader;

		/// <summary>
		/// Generate FLV metadata?
		/// </summary>
		private bool _generateMetadata;

		public bool GenerateMetadata {
			get { return _generateMetadata; }
			set { _generateMetadata = value; }
		}

		public override string Prefix {
			get { return "flv"; }
		}

		public override string Extension {
			get { return ".flv"; }
		}

		public override IStreamableFile GetStreamableFile(FileInfo file) {
			return new GodLesZ.Library.Amf.IO.FLV.Flv(file, _generateMetadata);
		}

		#region IFlvService Members

		public AMFWriter Serializer {
			get {
				return _amfWriter;
			}
			set {
				_amfWriter = value;
			}
		}

		#endregion

		public AMFReader Deserializer {
			get { return _amfReader; }
			set { _amfReader = value; }
		}

	}
}
