using System;
using GodLesZ.Library.Amf.IO;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.IO.Flv {
	/// <summary>
	/// A FlvService sets up the service and hands out FLV objects to its callers
	/// </summary>
	[CLSCompliant(false)]
	public interface IFlvService : IStreamableFileService {
		/// <summary>
		/// Gets or sets the serializer.
		/// </summary>
		AMFWriter Serializer { get; set; }
	}
}
