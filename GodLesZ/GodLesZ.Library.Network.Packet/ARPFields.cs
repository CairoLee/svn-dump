
namespace GodLesZ.Library.Network.Packet {
	/// <summary> IP protocol field encoding information.
	///
	/// </summary>
	/// FIXME: These fields are partially broken because they assume the offset for
	/// several fields and the offset is actually based on the accumulated offset
	/// into the structure determined by the fields that indicate sizes
	public class ARPFields {
		/// <summary> Type code for ethernet addresses.</summary>
		public readonly static int EthernetProtocolType = 0x0001;
		/// <summary> Type code for MAC addresses.</summary>
		public readonly static int IPv4ProtocolType = 0x0800;

		/// <summary> Operation type length in bytes.</summary>
		public readonly static int OperationLength = 2;
		/// <summary>
		/// The length of the address type fields in bytes,
		/// eg. the length of hardware type or protocol type
		/// </summary>
		public readonly static int AddressTypeLength = 2;
		/// <summary>
		/// The length of the address length fields in bytes.
		/// </summary>
		public readonly static int AddressLengthLength = 1;
		/// <summary> Position of the hardware address type.</summary>
		public readonly static int HardwareAddressTypePosition = 0;
		/// <summary> Position of the protocol address type.</summary>
		public readonly static int ProtocolAddressTypePosition;
		/// <summary> Position of the hardware address length.</summary>
		public readonly static int HardwareAddressLengthPosition;
		/// <summary> Position of the protocol address length.</summary>
		public readonly static int ProtocolAddressLengthPosition;
		/// <summary> Position of the operation type.</summary>
		public readonly static int OperationPosition;
		/// <summary> Position of the sender hardware address.</summary>
		public readonly static int SenderHardwareAddressPosition;
		/// <summary> Position of the sender protocol address.</summary>
		public readonly static int SenderProtocolAddressPosition;
		/// <summary> Position of the target hardware address.</summary>
		public readonly static int TargetHardwareAddressPosition;
		/// <summary> Position of the target protocol address.</summary>
		public readonly static int TargetProtocolAddressPosition;
		/// <summary> Total length in bytes of an ARP header.</summary>
		public readonly static int HeaderLength; // == 28

		static ARPFields() {
			// NOTE: We use IPv4Fields_Fields.IP_ADDRESS_WIDTH because arp packets are
			//       only used in IPv4 networks. Neighbor discovery is used with IPv6
			//FIXME: we really should use the sizes given by the length fields to determine
			// the position offsets here instead of assuming the hw address is an ethernet mac address
			ProtocolAddressTypePosition = HardwareAddressTypePosition + AddressTypeLength;
			HardwareAddressLengthPosition = ProtocolAddressTypePosition + AddressTypeLength;
			ProtocolAddressLengthPosition = HardwareAddressLengthPosition + AddressLengthLength;
			OperationPosition = ProtocolAddressLengthPosition + AddressLengthLength;
			SenderHardwareAddressPosition = OperationPosition + OperationLength;
			SenderProtocolAddressPosition = SenderHardwareAddressPosition + EthernetFields.MacAddressLength;
			TargetHardwareAddressPosition = SenderProtocolAddressPosition + IPv4Fields.AddressLength;
			TargetProtocolAddressPosition = TargetHardwareAddressPosition + EthernetFields.MacAddressLength;

			HeaderLength = TargetProtocolAddressPosition + IPv4Fields.AddressLength;
		}
	}
}
