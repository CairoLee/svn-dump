using System;
using System.Collections.Generic;
using GodLesZ.Library.Amf.IO.FLV;

namespace GodLesZ.Library.Amf.IO.Mp4 {
	/// <summary>
	/// Represents MP4 file
	/// </summary>
	[CLSCompliant(false)]
	public interface IMp4 : IStreamableFile {
		/// <summary>
		/// Returns a boolean stating whether the mp4 has metadata.
		/// </summary>
		/// <value><code>true</code> if file has injected metadata, <code>false</code> otherwise.</value>
		bool HasMetaData { get; }
		/// <summary>
		/// Gets or sets the metadata.
		/// </summary>
		MetaData MetaData { get; set; }
		/// <summary>
		/// Gets or sets the MetaService.
		/// </summary>
		MetaService MetaService { get; set; }
		/// <summary>
		/// Returns a boolean stating whether a mp4 has keyframedata.
		/// </summary>
		bool HasKeyFrameData { get; }
		/// <summary>
		/// Gets or sets the keyframe data.
		/// </summary>
		Dictionary<string, object> KeyFrameData { get; set; }
		/// <summary>
		/// Refreshes the headers. Usually used after data is added to the mp4 file.
		/// </summary>
		void RefreshHeaders();
		/// <summary>
		/// Flushes the headers.
		/// </summary>
		void FlushHeaders();
		/// <summary>
		/// Returns a reader closest to the nearest keyframe.
		/// </summary>
		/// <param name="seekPoint">Point in file we are seeking around.</param>
		/// <returns>Tag reader closest to the specified point.</returns>
		ITagReader ReaderFromNearestKeyFrame(int seekPoint);
		/// <summary>
		/// Returns a writer based on the nearest key frame.
		/// </summary>
		/// <param name="seekPoint">Point in file we are seeking around.</param>
		/// <returns>Tag writer closest to the specified point.</returns>
		ITagWriter WriterFromNearestKeyFrame(int seekPoint);
	}
}
