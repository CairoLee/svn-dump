using GodLesZ.Library.Pcap.LibPcap;

namespace GodLesZ.Library.Pcap.WinPcap {
	/// <summary>
	/// Event that contains statistics mode data
	/// NOTE: WinPcap only
	/// </summary>
	public class StatisticsModeEventArgs : CaptureEventArgs {
		/// <summary>
		/// Constructor for a statistics mode event
		/// </summary>
		/// <param name="packet">
		/// A <see cref="RawCapture"/>
		/// </param>
		/// <param name="device">
		/// A <see cref="PcapDevice"/>
		/// </param>
		public StatisticsModeEventArgs(RawCapture packet, PcapDevice device)
			: base(packet, device) {
		}

		/// <summary>
		/// Statistics data for this event
		/// </summary>
		public StatisticsModePacket Statistics {
			get {
				return new StatisticsModePacket(base.Packet);
			}
		}
	}
}
