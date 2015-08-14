
namespace GodLesZ.Library.Pcap {
	/// <summary>
	/// Thrown when an operation can't be performed because
	/// a background capture has been started via PcapDevice.StartCapture()
	/// </summary>
	public class InvalidOperationDuringBackgroundCaptureException : PcapException {
		/// <summary>
		/// string constructor
		/// </summary>
		/// <param name="msg">
		/// A <see cref="System.String"/>
		/// </param>
		public InvalidOperationDuringBackgroundCaptureException(string msg)
			: base(msg) {
		}
	}
}
