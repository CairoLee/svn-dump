
namespace GodLesZ.Library.Network.Packet {
	/// <summary>
	/// Ethernet protocol field encoding information.
	/// </summary>
	public class EthernetFields {
		/// <summary> Width of the ethernet type code in bytes.</summary>
		public readonly static int TypeLength = 2;

		/// <summary> Position of the destination MAC address within the ethernet header.</summary>
		public readonly static int DestinationMacPosition = 0;

		/// <summary> Position of the source MAC address within the ethernet header.</summary>
		public readonly static int SourceMacPosition;

		/// <summary> Position of the ethernet type field within the ethernet header.</summary>
		public readonly static int TypePosition;

		/// <summary> Total length of an ethernet header in bytes.</summary>
		public readonly static int HeaderLength; // == 14

		static EthernetFields() {
			SourceMacPosition = EthernetFields.MacAddressLength;
			TypePosition = EthernetFields.MacAddressLength * 2;
			HeaderLength = EthernetFields.TypePosition + EthernetFields.TypeLength;
		}

		/// <summary>
		/// size of an ethernet mac address in bytes
		/// </summary>
		public readonly static int MacAddressLength = 6;
	}
}
