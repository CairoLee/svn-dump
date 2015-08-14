using System;
using GodLesZ.Library.Amf.IO;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.IO.Mp4 {
	/// <summary>
	/// A MP4Service sets up the service and hands out MP4 objects to its callers.
	/// </summary>
	[CLSCompliant(false)]
	public interface IMp4Service : IStreamableFileService {
		/// <summary>
		/// Gets or sets the serializer.
		/// </summary>
		AMFWriter Serializer { get; set; }
	}
}
