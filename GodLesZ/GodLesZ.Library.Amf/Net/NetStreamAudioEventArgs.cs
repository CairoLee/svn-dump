using System;
using GodLesZ.Library.Amf.Messaging.Rtmp.Event;

namespace GodLesZ.Library.Amf.Net {
	/// <summary>
	/// A NetStream object dispatches NetStreamAudioEventArgs objects when audio data is received.
	/// </summary>
	[CLSCompliant(false)]
	public class NetStreamAudioEventArgs : EventArgs {
		readonly AudioData _audioData;

		/// <summary>
		/// Initializes a new instance of the <see cref="NetStreamAudioEventArgs"/> class.
		/// </summary>
		/// <param name="audioData">The audio data.</param>
		internal NetStreamAudioEventArgs(AudioData audioData) {
			_audioData = audioData;
		}

		/// <summary>
		/// Gets the audio data.
		/// </summary>
		/// <value>The audio data.</value>
		public AudioData AudioData {
			get { return _audioData; }
		}
	}
}
