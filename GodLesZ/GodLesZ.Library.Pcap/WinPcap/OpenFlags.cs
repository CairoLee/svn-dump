using System;

namespace GodLesZ.Library.Pcap.WinPcap {
	/// <summary>
	/// The mode used when opening a device
	/// </summary>
	[Flags]
	public enum OpenFlags : short {
		/// <summary>
		/// Defines if the adapter has to go in promiscuous mode. 
		/// </summary>
		Promiscuous = 1,

		/// <summary>
		/// Defines if the data trasfer (in case of a remote capture)
		/// has to be done with UDP protocol. 
		/// </summary>
		DataTransferUdp = 2,

		/// <summary>
		/// Defines if the remote probe will capture its own generated traffic. 
		/// </summary>
		NoCaptureRemote = 4,

		/// <summary>
		/// Defines if the local adapter will capture its own generated traffic. 
		/// </summary>
		NoCaptureLocal = 8,

		/// <summary>
		/// This flag configures the adapter for maximum responsiveness. 
		/// </summary>
		MaxResponsiveness = 16
	}
}