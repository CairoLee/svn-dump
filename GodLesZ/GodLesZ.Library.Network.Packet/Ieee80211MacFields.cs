
namespace GodLesZ.Library.Network.Packet {
	/// <summary>
	/// See http://www.ucertify.com/article/ieee-802-11-frame-format.html
	///
	/// NOTE: All positions are not defined here because the frame type changes
	/// whether some address fields are present or not, causing the sequence control
	/// field to move. In addition the payload size determines where the frame control
	/// sequence value is as it is after the payload bytes, if any payload is present
	/// </summary>
	class Ieee80211MacFields {
		public readonly static int FrameControlLength = 2;
		public readonly static int DurationIDLength = 2;
		public readonly static int AddressLength = EthernetFields.MacAddressLength;
		public readonly static int SequenceControlLength = 4;
		public readonly static int FrameCheckSequenceLength = 4;

		public readonly static int FrameControlPosition = 0;
		public readonly static int DurationIDPosition;
		public readonly static int Address1Position;

		static Ieee80211MacFields() {
			DurationIDPosition = FrameControlPosition + FrameControlLength;
			Address1Position = DurationIDPosition + DurationIDLength;
		}
	}
}
