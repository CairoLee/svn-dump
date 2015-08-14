
#if !SILVERLIGHT

#endif

namespace GodLesZ.Library.Amf.IO.FLV {
	class FlvHeader {
		/// <summary>
		/// FLV version
		/// </summary>
		private byte _version = 0x00; //version 1

		public byte Version {
			get { return _version; }
			set { _version = value; }
		}
		/// <summary>
		/// Reserved flag, one
		/// </summary>
		private byte _flagReserved01 = 0x00;

		public byte FlagReserved01 {
			get { return _flagReserved01; }
			set { _flagReserved01 = value; }
		}
		/// <summary>
		/// Audio flag
		/// </summary>
		private bool _flagAudio;

		public bool FlagAudio {
			get { return _flagAudio; }
			set { _flagAudio = value; }
		}
		/// <summary>
		/// Reserved flag, two
		/// </summary>
		private byte _flagReserved02 = 0x00;

		public byte FlagReserved02 {
			get { return _flagReserved02; }
			set { _flagReserved02 = value; }
		}
		/// <summary>
		/// Video flag
		/// </summary>
		private bool _flagVideo;

		public bool FlagVideo {
			get { return _flagVideo; }
			set { _flagVideo = value; }
		}
		/// <summary>
		/// DATA OFFSET reserved for data up to 4,294,967,295
		/// </summary>
		private int _dataOffset = 0x00;

		public int DataOffset {
			get { return _dataOffset; }
			set { _dataOffset = value; }
		}

		/// <summary>
		/// Sets the type flags on whether this data is audio or video.
		/// </summary>
		/// <param name="typeFlags">Type flags determining data types (audio or video).</param>
		internal void SetTypeFlags(byte typeFlags) {
			_flagVideo = (((byte)(((typeFlags << 0x7) >> 0x7) & 0x01)) > 0x00);
			_flagAudio = (((byte)(((typeFlags << 0x5) >> 0x7) & 0x01)) > 0x00);
		}

		public override string ToString() {
			string ret = "";
			ret += "version: " + this.Version + " \n";
			ret += "type flags video: " + this.FlagVideo + " \n";
			ret += "type flags audio: " + this.FlagAudio + " \n";
			ret += "data offset: " + this.DataOffset + "\n";
			return ret;
		}
	}
}
