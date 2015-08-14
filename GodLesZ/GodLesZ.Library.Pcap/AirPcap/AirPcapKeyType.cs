
namespace GodLesZ.Library.Pcap.AirPcap {
	/// <summary>
	/// Type of keys in the adapter
	/// </summary>
	public enum AirPcapKeyType : uint {
		/// <summary>
		/// Key type: WEP. The key can have an arbitrary length smaller than 32 bytes.
		/// </summary>
		Wep = 0,

		/// <summary>
		/// Key type: TKIP (WPA). NOT SUPPORTED YET by AirPcap
		/// </summary>
		Tkip = 1,

		/// <summary>
		/// Key type: CCMP (WPA2). NOT SUPPORTED YET by AirPcap
		/// </summary>
		Ccmp = 2
	};
}
