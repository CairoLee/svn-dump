using System;
using GodLesZ.Library.Amf.Messaging.Api.Messaging;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream {
	/// <summary>
	/// Interface for providers that know if they contain video frames.
	/// </summary>
	[CLSCompliant(false)]
	public interface IStreamTypeAwareProvider : IProvider {
		/// <summary>
		/// Checks if the provider contains video tags.
		/// </summary>
		bool HasVideo();
	}
}
