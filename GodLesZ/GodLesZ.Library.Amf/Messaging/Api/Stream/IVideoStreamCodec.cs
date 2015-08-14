using System;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// Video codec info used by stream codec.
	/// </summary>
	[CLSCompliant(false)]
	public interface IVideoStreamCodec {
		/// <summary>
		/// Gets the name of the video codec.
		/// </summary>
		string Name { get; }
		/// <summary>
		/// Resets the codec to its initial state.
		/// </summary>
		void Reset();
		/// <summary>
		/// Gets whether the codec supports frame dropping.
		/// </summary>
		bool CanDropFrames { get; }
		/// <summary>
		/// Returns true if the codec knows how to handle the passed stream data.
		/// </summary>
		/// <param name="data">Stream data.</param>
		/// <returns><code>true</code> if codec can handle data, <code>false</code> otherwise</returns>
		bool CanHandleData(ByteBuffer data);
		/// <summary>
		/// Update the state of the codec with the passed data.
		/// </summary>
		/// <param name="data">Stream data.</param>
		/// <returns><code>true</code> if codec can handle data, <code>false</code> otherwise</returns>
		bool AddData(ByteBuffer data);
		/// <summary>
		/// Returns the data for a keyframe.
		/// </summary>
		/// <returns>Data.</returns>
		ByteBuffer GetKeyframe();
		/// <summary>
		/// Gets the decoder configuration.
		/// </summary>
		/// <returns>Data for decoder setup.</returns>
		ByteBuffer GetDecoderConfiguration();
	}
}
