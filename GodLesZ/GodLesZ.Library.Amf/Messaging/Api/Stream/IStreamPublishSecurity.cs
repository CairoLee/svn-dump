using System;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// Interface for handlers that control access to stream publishing.
	/// </summary>
	[CLSCompliant(false)]
	public interface IStreamPublishSecurity {
		/// <summary>
		/// Check if publishing a stream with the given name is allowed.
		/// </summary>
		/// <param name="scope">Scope the stream is about to be published in.</param>
		/// <param name="name">Name of the stream to publish.</param>
		/// <param name="mode">Publishing mode.</param>
		/// <returns>true if publishing is allowed, otherwise false.</returns>
		bool IsPublishAllowed(IScope scope, string name, string mode);
	}
}
