
namespace GodLesZ.Library.Amf.IO {
	/// <summary>
	/// Keyframe metadata.
	/// </summary>
	public class KeyFrameMeta {
		long _duration;
		/// <summary>
		/// Gets or sets duration in milliseconds.
		/// </summary>
		public long Duration {
			get { return _duration; }
			set { _duration = value; }
		}
		bool _audioOnly;
		/// <summary>
		/// Gets or sets whether only audio frames are present.
		/// </summary>
		public bool AudioOnly {
			get { return _audioOnly; }
			set { _audioOnly = value; }
		}
		int[] _timestamps;
		/// <summary>
		/// Gets or sets keyframe timestamps.
		/// </summary>
		public int[] Timestamps {
			get { return _timestamps; }
			set { _timestamps = value; }
		}
		long[] _positions;
		/// <summary>
		/// Gets or sets keyframe positions.
		/// </summary>
		public long[] Positions {
			get { return _positions; }
			set { _positions = value; }
		}
	}
}
