
namespace GodLesZ.Library.Pcap.WinPcap {
	/// <summary>
	/// The types of transmit modes allowed by the WinPcap specific send queue
	/// implementation
	/// </summary>
	public enum SendQueueTransmitModes {
		/// <summary>
		/// Packets are sent as fast as possible
		/// </summary>
		Normal,

		/// <summary>
		/// Packets are synchronized in the kernel with a high precision timestamp
		/// </summary>
		Synchronized
	}
}
