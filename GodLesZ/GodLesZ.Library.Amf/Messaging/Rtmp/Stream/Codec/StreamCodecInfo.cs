using GodLesZ.Library.Amf.Messaging.Api.Stream;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream.Codec {
	class StreamCodecInfo : IStreamCodecInfo {
		/// <summary>
		/// Audio support flag.
		/// </summary>
		private bool _audio;
		/// <summary>
		/// Video support flag.
		/// </summary>
		private bool _video;
		/// <summary>
		/// Video codec.
		/// </summary>
		private IVideoStreamCodec _videoCodec;
		/// <summary>
		/// Audio codec.
		/// </summary>
		private IAudioStreamCodec _audioCodec;

		#region IStreamCodecInfo Members

		public bool HasAudio {
			get { return _audio; }
			set { _audio = value; }
		}

		public bool HasVideo {
			get { return _video; }
			set { _video = value; }
		}

		public string AudioCodecName {
			get {
				return null;
			}
		}

		public string VideoCodecName {
			get {
				if (_videoCodec == null)
					return null;
				return _videoCodec.Name;
			}
		}

		public IVideoStreamCodec VideoCodec {
			get { return _videoCodec; }
			set { _videoCodec = value; }
		}

		/// <summary>
		/// Gets the audio codec used by stream codec.
		/// </summary>
		/// <value>The audio codec.</value>
		public IAudioStreamCodec AudioCodec {
			get { return _audioCodec; }
			set { _audioCodec = value; }
		}

		#endregion
	}
}
