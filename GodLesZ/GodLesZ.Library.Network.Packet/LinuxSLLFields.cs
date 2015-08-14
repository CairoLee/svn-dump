
namespace GodLesZ.Library.Network.Packet {
	/// <summary>
	/// Lengths and offsets to the fields in the LinuxSLL packet
	/// See http://github.com/mcr/libpcap/blob/master/pcap/sll.h
	/// </summary>
	public class LinuxSLLFields {
		/// <summary>
		/// Length of the packet type field
		/// </summary>
		public readonly static int PacketTypeLength = 2;

		/// <summary>
		/// Link layer address type
		/// </summary>
		public readonly static int LinkLayerAddressTypeLength = 2;

		/// <summary>
		/// Link layer address length
		/// </summary>
		public readonly static int LinkLayerAddressLengthLength = 2;

		/// <summary>
		/// The link layer address field length
		/// NOTE: the actual link layer address MAY be shorter than this
		/// </summary>
		public readonly static int LinkLayerAddressMaximumLength = 8;

		/// <summary>
		/// Number of bytes in a SLL header
		/// </summary>
		public readonly static int SLLHeaderLength = 16;

		/// <summary>
		/// Length of the ethernet protocol field
		/// </summary>
		public readonly static int EthernetProtocolTypeLength = 2;

		/// <summary>
		/// Position of the packet type field
		/// </summary>
		public readonly static int PacketTypePosition = 0;

		/// <summary>
		/// Position of the link layer address type field
		/// </summary>
		public readonly static int LinkLayerAddressTypePosition;

		/// <summary>
		/// Positino of the link layer address length field
		/// </summary>
		public readonly static int LinkLayerAddressLengthPosition;

		/// <summary>
		/// Position of the link layer address field
		/// </summary>
		public readonly static int LinkLayerAddressPosition;

		/// <summary>
		/// Position of the ethernet protocol type field
		/// </summary>
		public readonly static int EthernetProtocolTypePosition;

		static LinuxSLLFields() {
			LinkLayerAddressTypePosition = PacketTypePosition + PacketTypeLength;
			LinkLayerAddressLengthPosition = LinkLayerAddressTypePosition + LinkLayerAddressTypeLength;
			LinkLayerAddressPosition = LinkLayerAddressLengthPosition + LinkLayerAddressLengthLength;
			EthernetProtocolTypePosition = LinkLayerAddressPosition + LinkLayerAddressMaximumLength;
		}
	}
}
