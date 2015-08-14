using System;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// Audio codec info used by stream codec.
	/// </summary>
	[CLSCompliant(false)]
	public interface IAudioStreamCodec {
		/// <summary>
		/// Gets the name of the audio codec.
		/// </summary>
		string Name { get; }
		/// <summary>
		/// Resets the codec to its initial state.
		/// </summary>
		void Reset();
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
		/// Gets the decoder configuration.
		/// </summary>
		/// <returns>Data for decoder setup.</returns>
		ByteBuffer GetDecoderConfiguration();
	}
}
