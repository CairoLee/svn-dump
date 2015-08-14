using System;

namespace GodLesZ.Library.Pcap.AirPcap {
	/// <summary>
	/// Frequency bands
	/// </summary>
	[Flags]
	public enum AirPcapBands : int {
		/// <summary>2.4 GHz band</summary>
		_2GHZ = 1,

		/// <summary>5 GHz band</summary>
		_5GHZ = 2,
	};
}
