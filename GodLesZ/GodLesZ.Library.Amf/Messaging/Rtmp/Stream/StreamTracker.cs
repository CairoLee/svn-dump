using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Rtmp.Event;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream {
	class StreamTracker {
		/// <summary>
		/// Last audio flag.
		/// </summary>
		private int _lastAudio;
		/// <summary>
		/// Last video flag.
		/// </summary>
		private int _lastVideo;
		/// <summary>
		/// Last notification flag.
		/// </summary>
		private int _lastNotify;
		/// <summary>
		/// Relative flag.
		/// </summary>
		private bool _relative;
		/// <summary>
		/// First video flag.
		/// </summary>
		private bool _firstVideo;
		/// <summary>
		/// First audio flag.
		/// </summary>
		private bool _firstAudio;
		/// <summary>
		/// First notification flag.
		/// </summary>
		private bool _firstNotify;

		public StreamTracker() {
			Reset();
		}

		/// <summary>
		/// Reset state.
		/// </summary>
		public void Reset() {
			_lastAudio = 0;
			_lastVideo = 0;
			_lastNotify = 0;
			_firstVideo = true;
			_firstAudio = true;
			_firstNotify = true;
		}

		public bool IsRelative {
			get { return _relative; }
		}

		/// <summary>
		/// RTMP event handler.
		/// </summary>
		/// <param name="evt">RTMP event</param>
		/// <returns>Timeframe since last notification (or audio or video packet sending).</returns>
		public int Add(IRtmpEvent evt) {
			_relative = true;
			int timestamp = evt.Timestamp;
			int tsOut = 0;

			switch (evt.DataType) {

				case Constants.TypeAudioData:
					if (_firstAudio) {
						tsOut = evt.Timestamp;
						_relative = false;
						_firstAudio = false;
					} else {
						tsOut = timestamp - _lastAudio;
						_lastAudio = timestamp;
					}
					break;

				case Constants.TypeVideoData:
					if (_firstVideo) {
						tsOut = evt.Timestamp;
						_relative = false;
						_firstVideo = false;
					} else {
						tsOut = timestamp - _lastVideo;
						_lastVideo = timestamp;
					}
					break;

				case Constants.TypeNotify:
				case Constants.TypeInvoke:
					if (_firstNotify) {
						tsOut = evt.Timestamp;
						_relative = false;
						_firstNotify = false;
					} else {
						tsOut = timestamp - _lastNotify;
						_lastNotify = timestamp;
					}
					break;

				default:
					// ignore other types
					break;
			}
			return tsOut;
		}
	}
}
