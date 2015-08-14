using System;

namespace GodLesZ.Library.Network.Packet {
	/// <summary>
	/// Channel flags
	/// </summary>
	[Flags]
	public enum Ieee80211RadioTapChannelFlags {
		/// <summary>Turbo channel</summary>
		IEEE80211_CHAN_TURBO = 0x0010,
		///<summary>CCK channel</summary>
		IEEE80211_CHAN_CCK = 0x0020,
		/// <summary>OFDM channel</summary>
		IEEE80211_CHAN_OFDM = 0x0040,
		/// <summary>2 GHz spectrum channel</summary>
		IEEE80211_CHAN_2GHZ = 0x0080,
		/// <summary>5 GHz spectrum channel</summary>
		IEEE80211_CHAN_5GHZ = 0x0100,
		/// <summary>Only passive scan allowed</summary>
		IEEE80211_CHAN_PASSIVE = 0x0200,
		/// <summary>Dynamic CCK-OFDM channel</summary>
		IEEE80211_CHAN_DYN = 0x0400,
		/// <summary>GFSK channel (FHSS PHY)</summary>
		IEEE80211_CHAN_GFSK = 0x0800,
		/// <summary>11a static turbo channel only</summary>
		IEEE80211_CHAN_STURBO = 0x2000
	};
}
