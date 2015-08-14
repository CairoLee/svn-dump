using System;
using System.Collections;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// Service that supports protected access to streams.
	/// </summary>
	[CLSCompliant(false)]
	public interface IStreamSecurityService : IScopeService {
		/// <summary>
		/// Add handler that protects stream publishing.
		/// </summary>
		/// <param name="handler">Handler to add.</param>
		void RegisterStreamPublishSecurity(IStreamPublishSecurity handler);
		/// <summary>
		/// Remove handler that protects stream publishing.
		/// </summary>
		/// <param name="handler">Handler to remove.</param>
		void UnregisterStreamPublishSecurity(IStreamPublishSecurity handler);
		/// <summary>
		/// Returns handlers that protect stream publishing.
		/// </summary>
		/// <returns>Enumerator of handlers.</returns>
		IEnumerator GetStreamPublishSecurity();
		/// <summary>
		/// Add handler that protects stream playback.
		/// </summary>
		/// <param name="handler">Handler to add.</param>
		void RegisterStreamPlaybackSecurity(IStreamPlaybackSecurity handler);
		/// <summary>
		/// Remove handler that protects stream playback.
		/// </summary>
		/// <param name="handler">Handler to remove.</param>
		void UnregisterStreamPlaybackSecurity(IStreamPlaybackSecurity handler);
		/// <summary>
		/// Returns handlers that protect stream plaback.
		/// </summary>
		/// <returns>Enumerator of handlers.</returns>
		IEnumerator GetStreamPlaybackSecurity();
	}
}
