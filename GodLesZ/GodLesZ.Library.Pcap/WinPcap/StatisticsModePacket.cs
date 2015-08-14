using System;

namespace GodLesZ.Library.Pcap.WinPcap {
	/// <summary>
	/// Holds network statistics entry from winpcap when in statistics mode
	/// See http://www.winpcap.org/docs/docs_41b5/html/group__wpcap__tut9.html
	/// </summary>
	public class StatisticsModePacket {
		/// <summary>
		/// This holds time value
		/// </summary>
		public PosixTimeval Timeval {
			get;
			set;
		}

		/// <summary>
		/// This holds byte received and packets received
		/// </summary>
		private byte[] m_pktData;

		internal StatisticsModePacket(RawCapture p) {
			this.Timeval = p.Timeval;
			this.m_pktData = p.Data;
		}

		/// <summary>
		/// Number of packets received since last sample
		/// </summary>
		public Int64 RecievedPackets {
			get {
				return BitConverter.ToInt64(m_pktData, 0);
			}
		}

		/// <summary>
		/// Number of bytes received since last sample
		/// </summary>
		public Int64 RecievedBytes {
			get {
				return BitConverter.ToInt64(m_pktData, 8);
			}
		}
	}
}
