using System;
using System.Runtime.InteropServices;

namespace GodLesZ.Library.Pcap.AirPcap {
	/// <summary>
	/// Capabilities for the adapter
	/// </summary>
	public class AirPcapDeviceCapabilities {
		/// <summary>
		/// An id that identifies the adapter model
		/// </summary>
		public AirPcapAdapterId AdapterId;

		/// <summary>
		/// String containing a printable adapter model
		/// </summary>
		public string /* CHAR* */ AdapterModelName;

		/// <summary>
		/// The type of bus the adapter is plugged to
		/// </summary>
		public AirPcapAdapterBus AdapterBus;

		/// <summary>
		/// TRUE if the adapter is able to perform frame injection.
		/// </summary>
		public bool CanTransmit { get; internal set; }

		/// <summary>
		/// TRUE if the adapter's transmit power is can be specified by the user application.
		/// </summary>
		public bool CanSetTransmitPower { get; internal set; }

		/// <summary>
		/// TRUE if the adapter supports plugging one or more external antennas.
		/// </summary>
		public bool ExternalAntennaPlug { get; internal set; }

		/// <summary>
		/// An OR combination of the media that the device supports. Possible values are: \ref AIRPCAP_MEDIUM_802_11_A,
		/// \ref AIRPCAP_MEDIUM_802_11_B, \ref AIRPCAP_MEDIUM_802_11_G or \ref AIRPCAP_MEDIUM_802_11_N.
		/// Not supported at the moment.
		/// </summary>
		public AirPcapMediumType /* UINT */ SupportedMedia;

		/// <summary>
		/// An OR combination of the bands that the device supports. Can be one of: \ref AIRPCAP_BAND_2GHZ, 
		/// \ref AIRPCAP_BAND_5GHZ.
		/// </summary>
		public AirPcapBands /* UINT */ SupportedBands;

		internal AirPcapDeviceCapabilities(IntPtr unmanagedCapabilities) {
			var capabilities = (AirPcapUnmanagedStructures.AirpcapDeviceCapabilities)Marshal.PtrToStructure(unmanagedCapabilities, typeof(AirPcapUnmanagedStructures.AirpcapDeviceCapabilities));

			this.AdapterId = capabilities.AdapterId;
			this.AdapterModelName = capabilities.AdapterModelName;
			this.AdapterBus = capabilities.AdapterBus;
			this.CanTransmit = capabilities.CanTransmit;
			this.CanSetTransmitPower = capabilities.CanSetTransmitPower;
			this.ExternalAntennaPlug = capabilities.ExternalAntennaPlug;
			this.SupportedMedia = (AirPcapMediumType)capabilities.SupportedMedia;
			this.SupportedBands = (AirPcapBands)capabilities.SupportedBands;
		}

		/// <summary>
		/// ToString() overload
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		public override string ToString() {
			return string.Format("[AirPcapDeviceCapabilities AdapterId: {0}, AdapterModelName: {1}, AdapterBus: {2}," +
								 " CanTransmit: {3}, CanSetTransmitPower: {4}, ExternalAntennaPlug: {5}," +
								 " SupportedMedia: {6}, SupportedBands: {7}]",
								 AdapterId, AdapterModelName, AdapterBus,
								 CanTransmit, CanSetTransmitPower, ExternalAntennaPlug,
								 SupportedMedia, SupportedBands);
		}
	}
}
