
namespace GodLesZ.Library.Pcap.AirPcap {
	/// <summary>
	/// Link type
	/// </summary>
	public enum AirPcapLinkTypes : int {
		/// <summary>
		/// plain 802.11 link type. Every packet in the buffer contains the raw 802.11 frame, including MAC FCS.
		/// </summary>
		_802_11 = 1,

		/// <summary>
		/// 802.11 plus radiotap link type. Every packet in the buffer contains a radiotap header followed by the 802.11 frame. MAC FCS is included.
		/// </summary>
		_802_11_PLUS_RADIO = 2,

		/// <summary>
		/// Unknown link type, should be seen only in error
		/// </summary>
		UNKNOWN = 3,

		/// <summary>
		/// 802.11 plus PPI header link type. Every packet in the buffer contains a PPI header followed by the 802.11 frame. MAC FCS is included.
		/// </summary>
		_802_11_PLUS_PPI = 4
	};
}
