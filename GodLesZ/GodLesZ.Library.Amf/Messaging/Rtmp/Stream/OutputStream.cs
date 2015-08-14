using System;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream {
	/// <summary>
	/// Output stream that consists of audio, video and data channels.
	/// </summary>
	[CLSCompliant(false)]
	public class OutputStream {
		/// <summary>
		/// Video channel.
		/// </summary>
		private RtmpChannel _video;
		/// <summary>
		/// Audio channel.
		/// </summary>
		private RtmpChannel _audio;
		/// <summary>
		/// Data channel.
		/// </summary>
		private RtmpChannel _data;

		/// <summary>
		/// Creates output stream from channels.
		/// </summary>
		/// <param name="video">Video channel.</param>
		/// <param name="audio">Audio channel.</param>
		/// <param name="data">Data channel.</param>
		internal OutputStream(RtmpChannel video, RtmpChannel audio, RtmpChannel data) {
			_video = video;
			_audio = audio;
			_data = data;
		}
		/// <summary>
		/// Closes audio, video and data channels.
		/// </summary>
		public void Close() {
			_video.Close();
			_audio.Close();
			_data.Close();
		}
		/// <summary>
		/// Gets the audio channel.
		/// </summary>
		public RtmpChannel Audio {
			get { return _audio; }
		}
		/// <summary>
		/// Gets the data channel.
		/// </summary>
		public RtmpChannel Data {
			get { return _data; }
		}
		/// <summary>
		/// Gets the video channel.
		/// </summary>
		public RtmpChannel Video {
			get { return _video; }
		}
	}
}
