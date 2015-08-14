using System;
using GodLesZ.Library.Amf.Messaging.Api.Messaging;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream {
	/// <summary>
	/// Provider that is seekable.
	/// </summary>
	[CLSCompliant(false)]
	public interface ISeekableProvider : IProvider {
		/// <summary>
		/// Seeks the provider to timestamp ts (in milliseconds).
		/// </summary>
		/// <param name="ts">Timestamp to seek to.</param>
		/// <returns>Actual timestamp seeked to.</returns>
		int Seek(int ts);
	}
}
