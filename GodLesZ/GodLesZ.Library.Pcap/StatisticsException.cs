
namespace GodLesZ.Library.Pcap {
	/// <summary>
	/// thrown when pcap_stats() reports an error
	/// </summary>
	public class StatisticsException : PcapException {
		/// <summary>
		/// string constructor
		/// </summary>
		/// <param name="msg">
		/// A <see cref="System.String"/>
		/// </param>
		public StatisticsException(string msg)
			: base(msg) {
		}
	}
}
