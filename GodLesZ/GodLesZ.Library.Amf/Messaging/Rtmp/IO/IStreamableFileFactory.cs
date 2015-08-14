using System;

#if !NET_1_1
using System.Collections.Generic;
#endif
using System.IO;
using GodLesZ.Library.Amf.Messaging.Api;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.IO {
	/// <summary>
	/// Scope service extension that provides method to get streamable file services set.
	/// </summary>
	[CLSCompliant(false)]
	public interface IStreamableFileFactory : IScopeService {
		/// <summary>
		/// Returns a streamable file service.
		/// </summary>
		/// <param name="file">File to be streamed.</param>
		/// <returns>A streamable file service.</returns>
		IStreamableFileService GetService(FileInfo file);

		/// <summary>
		/// Returns streamable file services.
		/// </summary>
		/// <returns>Set of streamable file services.</returns>
#if !NET_1_1
		ICollection<IStreamableFileService> GetServices();
#else
        ICollection GetServices();
#endif
	}
}
