
namespace GodLesZ.Library.Network.Packet {
	/// <summary>
	/// As defined by Airpcap.h
	///
	/// NOTE: PresentPosition may not be the only position present
	/// as this the field can be extended if the high bit is set
	/// </summary>
	public class Ieee80211RadioFields {
		/// <summary>Length of the version field</summary>
		public readonly static int VersionLength = 1;

		/// <summary>Length of the pad field</summary>
		public readonly static int PadLength = 1;

		/// <summary>Length of the length field</summary>
		public readonly static int LengthLength = 2;

		/// <summary>Length of the first present field (others may follow)</summary>
		public readonly static int PresentLength = 4;

		/// <summary>Position of the version field</summary>
		public readonly static int VersionPosition = 0;

		/// <summary>Position of the padding field</summary>
		public readonly static int PadPosition;

		/// <summary>Position of the length field</summary>
		public readonly static int LengthPosition;

		/// <summary>Position of the first present field</summary>
		public readonly static int PresentPosition;

		/// <summary>Default header length, assuming one present field entry</summary>
		public readonly static int DefaultHeaderLength;

		static Ieee80211RadioFields() {
			PadPosition = VersionPosition + VersionLength;
			LengthPosition = PadPosition + PadLength;
			PresentPosition = LengthPosition + LengthLength;

			// default to the normal header size until the header length can be read
			DefaultHeaderLength = PresentPosition + PresentLength;
		}
	}
};

