using System;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// Stream codec information.
	/// </summary>
	[CLSCompliant(false)]
	public interface IStreamCodecInfo {
		/// <summary>
		/// Gets whether stream codec has audio support.
		/// </summary>
		bool HasAudio { get; }
		/// <summary>
		/// Gets whether stream codec has video support.
		/// </summary>
		bool HasVideo { get; }
		/// <summary>
		/// Gets audio codec name.
		/// </summary>
		string AudioCodecName { get; }
		/// <summary>
		/// Gets video codec name.
		/// </summary>
		string VideoCodecName { get; }
		/// <summary>
		/// Gets video codec used by stream codec.
		/// </summary>
		IVideoStreamCodec VideoCodec { get; }
		/// <summary>
		/// Gets the audio codec used by stream codec.
		/// </summary>
		/// <value>The audio codec.</value>
		IAudioStreamCodec AudioCodec { get; }
	}
}
