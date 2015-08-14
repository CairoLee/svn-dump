
namespace GodLesZ.Library.Pcap.AirPcap {
	/// <summary>
	/// Type of frame validation the adapter performs.
	/// An adapter can be instructed to accept different kind of frames: correct frames only, frames with wrong Frame Check Sequence (FCS) only, all frames.
	/// </summary>
	public enum AirPcapValidationType : int {
		/// <summary>Accept all the frames the device captures</summary>
		ACCEPT_EVERYTHING = 1,
		/// <summary>Accept correct frames only, i.e. frames with correct Frame Check Sequence (FCS).</summary>
		ACCEPT_CORRECT_FRAMES = 2,
		/// <summary>Accept corrupt frames only, i.e. frames with worng Frame Check Sequence (FCS).</summary>
		ACCEPT_CORRUPT_FRAMES = 3,
		/// <summary>Unknown validation type. You should see it only in case of error.</summary>
		UNKNOWN = 4
	};
}
