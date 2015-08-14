
namespace GodLesZ.Library.Amf.IO {
	/// <summary>
	/// Analyzes key frame data.
	/// </summary>
	public interface IKeyFrameDataAnalyzer {
		/// <summary>
		/// Analyze and return keyframe metadata.
		/// </summary>
		/// <returns>Metadata object.</returns>
		KeyFrameMeta AnalyzeKeyFrames();
	}
}
