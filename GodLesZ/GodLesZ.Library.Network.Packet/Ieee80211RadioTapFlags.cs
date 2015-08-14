using System;

namespace GodLesZ.Library.Network.Packet {
	/// <summary>
	/// Radio tap flags
	/// </summary>
	[Flags]
	public enum Ieee80211RadioTapFlags {
		/// <summary>
		/// sent/received during cfp
		/// </summary>
		CFP = 0x01,
		/// <summary>
		/// sent/received with short preamble
		/// </summary>
		ShortPreamble = 0x02,
		/// <summary>
		/// sent/received with WEP encryption
		/// </summary>
		WepEncrypted = 0x04,
		/// <summary>
		/// sent/received with fragmentation
		/// </summary>
		Fragmentation = 0x08,
		/// <summary>
		/// frame includes FCS
		/// </summary>
		FcsIncludedInFrame = 0x10
	};
}
