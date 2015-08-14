using System;
using System.Runtime.InteropServices;

namespace GodLesZ.Library.Pcap.AirPcap {
	/// <summary>
	/// Device statistics
	/// </summary>
	public class AirPcapStatistics : ICaptureStatistics {
		/// <value>
		/// Number of packets received
		/// </value>
		public uint ReceivedPackets { get; set; }

		/// <value>
		/// Number of packets dropped
		/// </value>
		public uint DroppedPackets { get; set; }

		/// <value>
		/// Number of interface dropped packets
		/// </value>
		public uint InterfaceDroppedPackets { get; set; }

		/// <summary>
		/// Number of packets that pass the BPF filter, find place in the kernel buffer and
		/// therefore reach the application.
		/// </summary>
		public uint CapturedPackets { get; set; }

		internal AirPcapStatistics(IntPtr AirPcapDeviceHandle) {
			// allocate memory for the struct
			IntPtr stat = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(AirPcapUnmanagedStructures.AirpcapStats)));

			AirPcapSafeNativeMethods.AirpcapGetStats(AirPcapDeviceHandle, stat);

			var managedStat = (AirPcapUnmanagedStructures.AirpcapStats)Marshal.PtrToStructure(stat,
																							  typeof(AirPcapUnmanagedStructures.AirpcapStats));

			this.ReceivedPackets = managedStat.Recvs;
			this.DroppedPackets = managedStat.Drops;
			this.InterfaceDroppedPackets = managedStat.IfDrops;
			this.CapturedPackets = managedStat.Capt;

			// free the stats memory so we don't leak
			Marshal.FreeHGlobal(stat);
		}

		/// <summary>
		/// ToString override 
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return string.Format("[AirPcapStatistics {0}, CapturedPackets: {1}]",
								 base.ToString(),
								 CapturedPackets);
		}
	}
}
