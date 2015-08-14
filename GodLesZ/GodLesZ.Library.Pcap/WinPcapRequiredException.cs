
namespace GodLesZ.Library.Pcap {
	/// <summary>
	/// Exception thrown when a WinPcap extension method is called from
	/// a non-Windows platform
	/// </summary>
	public class WinPcapRequiredException : PcapException {
		/// <summary>
		/// string constructor
		/// </summary>
		/// <param name="msg">
		/// A <see cref="System.String"/>
		/// </param>
		public WinPcapRequiredException(string msg)
			: base(msg) {
		}
	}
}
