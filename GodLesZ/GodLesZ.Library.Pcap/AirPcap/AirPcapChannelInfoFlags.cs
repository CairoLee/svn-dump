using System;

namespace GodLesZ.Library.Pcap.AirPcap {
	/// <summary>
	/// Channel info flags
	/// </summary>
	[Flags]
	public enum AirPcapChannelInfoFlags : byte {
		/// <summary>
		/// No flags set
		/// </summary>
		None = 0x0,

		/// <summary>
		/// Channel info flag: the channel is enabled for transmission, too.
		///
		/// To comply with the electomagnetic emission regulations of the different countries, the AirPcap hardware can be programmed
		/// to block transmission on specific channels. This flag is set by AirpcapGetDeviceSupportedChannels() to indicate that a 
		/// channel in the list supports transmission.
		/// </summary>
		TxEnable = 0x1
	};
}
