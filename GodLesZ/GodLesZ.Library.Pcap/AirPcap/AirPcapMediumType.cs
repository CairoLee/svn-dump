using System;

namespace GodLesZ.Library.Pcap.AirPcap {
	/// <summary>
	/// Medium type
	/// </summary>
	[Flags]
	public enum AirPcapMediumType : int {
		/// <summary>802.11a medium</summary>
		_802_11_A = 1,
		/// <summary>802.11b medium</summary>
		_802_11_B = 2,
		/// <summary>802.11g medium</summary>
		_802_11_G = 4,
		/// <summary>802.11n medium</summary>
		_802_11_N = 8
	};
}
