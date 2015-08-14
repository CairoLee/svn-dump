using System;
using System.Collections.Generic;
using System.Text;

namespace GodLesZ.Library.Amf.IO.FLV {
	/// <summary>
	/// Cue point is metadata marker used to control and accompany video playback with client-side application
	/// events. Each cue point have at least one attribute, timestamp. Timestamp specifies position of cue point in
	/// FLV file.
	/// 
	/// <p>Cue points are usually used as event triggers down video flow or navigation points in a file. Cue points are of two types:
	/// <ul>
	/// <li>Embedded into FLV or SWF</li>
	/// <li>External, or added on fly (e.g. with FLVPlayback component or ActionScript) on both server-side and client-side.</li>
	/// </ul>
	/// </p>
	/// 
	/// <p>To add cue point trigger event listener at client-side in Flex/Flash application, use NetStream.onCuePoint event handler.</p>
	/// </summary>
	public class MetaCue : Dictionary<string, object>, IComparable {
		/// <summary>
		/// Gets or sets the cue point name.
		/// </summary>
		public string Name {
			get { return this["name"] as string; }
			set { this["name"] = value; }
		}
		/// <summary>
		/// Gets or sets the type. Type can be "event" or "navigation".
		/// </summary>
		public string Type {
			get { return this["type"] as string; }
			set { this["type"] = value; }
		}
		/// <summary>
		/// Gets or sets the time.
		/// </summary>
		public double Time {
			get { return (double)this["time"]; }
			set { this["time"] = value; }
		}


		#region IComparable Members
		/// <summary>
		/// Compares the current instance with another object of MetaCue type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="obj">A MetaCue object to compare with this instance.</param>
		/// <returns>A 32-bit signed integer that indicates the relative order of the objects being compared.</returns>
		public int CompareTo(object obj) {
			MetaCue cp = obj as MetaCue;
			double cpTime = cp.Time;
			double time = this.Time;

			if (cpTime > time) {
				return -1;
			} else if (cpTime < time) {
				return 1;
			}
			return 0;
		}

		#endregion

		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			foreach (string key in this.Keys) {
				if (sb.Length != 0)
					sb.Append(", ");
				sb.Append(key);
				sb.Append("=");
				sb.Append(this[key]);
			}
			return "MetaCue{" + sb.ToString() + "}";
		}
	}
}
