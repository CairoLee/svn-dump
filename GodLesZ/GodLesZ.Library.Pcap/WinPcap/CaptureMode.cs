
namespace GodLesZ.Library.Pcap.WinPcap {
	/// <summary>
	/// The working mode of a Pcap device
	/// </summary>
	public enum CaptureMode : int {
		/// <summary>
		/// Set a Pcap device to capture packets, Capture mode
		/// </summary>
		Packets = 0,

		/// <summary>
		/// Set a Pcap device to report statistics.
		/// <br/>
		/// Statistics mode is only supported in WinPcap
		/// </summary>
		Statistics = 1
	};
}
