﻿using System;
using System.Runtime.InteropServices;

namespace GodLesZ.Library.Pcap.AirPcap {
	/// <summary>
	/// Packet header
	/// </summary>
	public class AirPcapPacketHeader {
		/// <summary>
		/// Seconds field
		/// </summary>
		public ulong TsSec {
			get;
			set;
		}

		/// <summary>
		/// Microseconds field
		/// </summary>
		public ulong TsUsec {
			get;
			set;
		}

		/// <summary>
		/// Number of bytes captured
		/// </summary>
		public long Caplen {
			get;
			set;
		}

		/// <summary>
		/// On-line packet size in bytes
		/// </summary>
		public long Originallen {
			get;
			set;
		}

		/// <summary>
		/// Header length in bytes
		/// </summary>
		public long Hdrlen {
			get;
			set;
		}

		internal AirPcapPacketHeader(IntPtr packetHeader) {
			var pkthdr = (AirPcapUnmanagedStructures.AirpcapBpfHeader)Marshal.PtrToStructure(packetHeader,
																							 typeof(AirPcapUnmanagedStructures.AirpcapBpfHeader));

			this.TsSec = (ulong)pkthdr.TsSec;
			this.TsUsec = (ulong)pkthdr.TsUsec;
			this.Caplen = (long)pkthdr.Caplen;
			this.Originallen = (long)pkthdr.Originallen;
			this.Hdrlen = (long)pkthdr.Hdrlen;
		}

		/// <summary>
		/// ToString() override
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		public override string ToString() {
			return string.Format("TsSec {0}, TsUSec {1}, Caplen {2}, Originallen {3}, Hdrlen {4}",
								 TsSec,
								 TsUsec,
								 Caplen,
								 Originallen,
								 Hdrlen);
		}
	}
}
