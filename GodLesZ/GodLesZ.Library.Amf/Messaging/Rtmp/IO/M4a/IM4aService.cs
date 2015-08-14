using System;
using GodLesZ.Library.Amf.IO;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.IO.M4a {
	/// <summary>
	/// An M4aService sets up the service and hands out M4A objects to its callers.
	/// </summary>
	[CLSCompliant(false)]
	public interface IM4aService : IStreamableFileService {
		/// <summary>
		/// Gets or sets the serializer.
		/// </summary>
		AMFWriter Serializer { get; set; }
	}
}
