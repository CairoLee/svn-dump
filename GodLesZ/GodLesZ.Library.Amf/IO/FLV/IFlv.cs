using System;
using System.Collections.Generic;

namespace GodLesZ.Library.Amf.IO.FLV {
	/// <summary>
	/// Represents a FLV file.
	/// </summary>
	[CLSCompliant(false)]
	public interface IFlv : IStreamableFile {
		/// <summary>
		/// Returns a boolean stating whether the flv has metadata.
		/// </summary>
		/// <value><code>true</code> if file has injected metadata, <code>false</code> otherwise.</value>
		bool HasMetaData { get; }
		/// <summary>
		/// Returns a boolean stating whether a flv has keyframedata.
		/// </summary>
		bool HasKeyFrameData { get; }
		/// <summary>
		/// Gets or sets the metadata.
		/// </summary>
		MetaData MetaData { get; set; }
		/// <summary>
		/// Gets or sets the MetaService.
		/// </summary>
		MetaService MetaService { get; set; }
		/// <summary>
		/// Gets or sets the keyframe data.
		/// </summary>
		Dictionary<string, object> KeyFrameData { get; set; }
		/// <summary>
		/// Refreshes the headers. Usually used after data is added to the flv file.
		/// </summary>
		void RefreshHeaders();
		/// <summary>
		/// Flushes the headers.
		/// </summary>
		void FlushHeaders();
		/// <summary>
		/// Returns a Reader closest to the nearest keyframe.
		/// </summary>
		/// <param name="seekPoint">Point in file we are seeking around.</param>
		/// <returns>Tag reader closest to the specified point.</returns>
		ITagReader ReaderFromNearestKeyFrame(int seekPoint);
		/// <summary>
		/// Returns a Writer based on the nearest key frame.
		/// </summary>
		/// <param name="seekPoint">Point in file we are seeking around.</param>
		/// <returns>Tag writer closest to the specified point.</returns>
		ITagWriter WriterFromNearestKeyFrame(int seekPoint);
	}
}
