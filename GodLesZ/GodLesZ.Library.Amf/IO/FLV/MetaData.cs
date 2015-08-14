using System.Collections;
using System.Collections.Generic;

namespace GodLesZ.Library.Amf.IO.FLV {
	/// <summary>
	/// FLV MetaData
	/// </summary>
	public class MetaData : Dictionary<string, object> {
		/// <summary>
		/// Cue points array. Cue points can be injected on fly like any other data even on client-side.
		/// </summary>
		MetaCue[] _cuePoints;

		/// <summary>
		/// Gets or sets whether the video can seek to end.
		/// </summary>
		public bool CanSeekToEnd {
			get { return (bool)this["canSeekToEnd"]; }
			set { this["canSeekToEnd"] = value; }
		}
		/// <summary>
		/// Gets or sets the video codec id.
		/// </summary>
		public int VideoCodecId {
			get { return (int)this["videocodecid"]; }
			set { this["videocodecid"] = value; }
		}
		/// <summary>
		/// Gets or sets the audio codec id.
		/// </summary>
		public int AudioCodecId {
			get { return (int)this["audiocodecid"]; }
			set { this["audiocodecid"] = value; }
		}
		/// <summary>
		/// Gets or sets the FLV framerate in frames per second.
		/// </summary>
		public double FrameRate {
			get { return (double)this["framerate"]; }
			set { this["framerate"] = value; }
		}
		/// <summary>
		/// Gets or sets the video data rate.
		/// </summary>
		public int VideoDataRate {
			get { return (int)this["videodatarate"]; }
			set { this["videodatarate"] = value; }
		}
		/// <summary>
		/// Gets or sets the width.
		/// </summary>
		public int Width {
			get { return (int)this["width"]; }
			set { this["width"] = value; }
		}
		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		public int Height {
			get { return (int)this["height"]; }
			set { this["height"] = value; }
		}
		/// <summary>
		/// Gets or sets the video duration in seconds.
		/// </summary>
		public double Duration {
			get { return (double)this["duration"]; }
			set { this["duration"] = value; }
		}
		/// <summary>
		/// Gets or set the cue points.
		/// </summary>
		public MetaCue[] MetaCue {
			get {
				return _cuePoints;
			}
			set {
				Dictionary<string, object> cues = new Dictionary<string, object>();
				_cuePoints = value;

				int j = 0;
				for (j = 0; j < _cuePoints.Length; j++) {
					cues.Add(j.ToString(), _cuePoints[j]);
				}
				//		"CuePoints", cuePointData
				//					'0',	MetaCue
				//							name, "test"
				//							type, "event"
				//							time, "0.1"
				//					'1',	MetaCue
				//							name, "test1"
				//							type, "event1"
				//							time, "0.5"
				this["cuePoints"] = cues;
			}
		}

		public void PutAll(IDictionary data) {
			foreach (DictionaryEntry entry in data) {
				this.Add(entry.Key.ToString(), entry.Value);
			}
		}
	}
}
