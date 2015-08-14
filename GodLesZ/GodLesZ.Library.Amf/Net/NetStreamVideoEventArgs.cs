using System;
using GodLesZ.Library.Amf.Messaging.Rtmp.Event;

namespace GodLesZ.Library.Amf.Net {
	/// <summary>
	/// A NetStream object dispatches NetStreamVideoEventArgs objects when video data is received.
	/// </summary>
	[CLSCompliant(false)]
	public class NetStreamVideoEventArgs : EventArgs {
		readonly VideoData _videoData;

		/// <summary>
		/// Initializes a new instance of the <see cref="NetStreamVideoEventArgs"/> class.
		/// </summary>
		/// <param name="videoData">The video data.</param>
		internal NetStreamVideoEventArgs(VideoData videoData) {
			_videoData = videoData;
		}

		/// <summary>
		/// Gets the video data.
		/// </summary>
		/// <value>The video data.</value>
		public VideoData VideoData {
			get { return _videoData; }
		}
	}
}
