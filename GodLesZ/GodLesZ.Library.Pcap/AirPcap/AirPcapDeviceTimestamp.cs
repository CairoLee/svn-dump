using System;

namespace GodLesZ.Library.Pcap.AirPcap {
	/// <summary>
	/// Defines the internal AirPcap device timestamp
	/// </summary>
	public class AirPcapDeviceTimestamp {
		/// <summary>Current value of the device counter, in microseconds.</summary>
		public UInt64 DeviceTimestamp;

		/// <summary>Value of the software counter used to timestamp packets before reading the device counter, in microseconds.</summary>
		public UInt64 SoftwareTimestampBefore;

		/// <summary>Value of the software counter used to timestamp packets after reading the device counter, in microseconds.</summary>
		public UInt64 SoftwareTimestampAfter;

		internal AirPcapDeviceTimestamp(AirPcapUnmanagedStructures.AirpcapDeviceTimestamp timestamp) {
			DeviceTimestamp = timestamp.DeviceTimestamp;
			SoftwareTimestampBefore = timestamp.SoftwareTimestampBefore;
			SoftwareTimestampAfter = timestamp.SoftwareTimestampAfter;
		}

		/// <summary>
		/// ToString() override
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		public override string ToString() {
			return string.Format("[AirPcapDeviceTimestamp DeviceTimestamp {0}, SoftwareTimestampBefore {1}, SoftwareTimestampAfter {2}",
								 DeviceTimestamp, SoftwareTimestampBefore, SoftwareTimestampAfter);
		}
	}
}
