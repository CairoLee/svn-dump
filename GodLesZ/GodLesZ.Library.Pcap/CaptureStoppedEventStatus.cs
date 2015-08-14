
namespace GodLesZ.Library.Pcap {
	/// <summary>
	/// Status types when capture is stopped
	/// </summary>
	public enum CaptureStoppedEventStatus {
		/// <summary>
		/// Capture completed without errors
		/// </summary>
		CompletedWithoutError,

		/// <summary>
		/// Error while capturing
		/// </summary>
		ErrorWhileCapturing
	}
}
