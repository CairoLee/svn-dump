using System;

namespace GodLesZ.Library.Pcap {
	/// <summary>
	/// General Pcap Exception.
	/// </summary>
	public class PcapException : Exception {
		internal PcapException()
			: base() {
		}

		internal PcapException(string msg)
			: base(msg) {
		}
	}
}
