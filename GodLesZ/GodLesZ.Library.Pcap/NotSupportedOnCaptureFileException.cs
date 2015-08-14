
namespace GodLesZ.Library.Pcap {
	/// <summary>
	/// Thrown when a method not supported on a capture file
	/// </summary>
	public class NotSupportedOnCaptureFileException : PcapException {
		/// <summary>
		/// string constructor
		/// </summary>
		/// <param name="msg">
		/// A <see cref="System.String"/>
		/// </param>
		public NotSupportedOnCaptureFileException(string msg)
			: base(msg) {
		}
	}
}
