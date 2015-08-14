
namespace GodLesZ.Library.Network.Packet {
	/// <summary>
	/// ICMP protocol field encoding information.
	/// See http://en.wikipedia.org/wiki/ICMPv6
	/// </summary>
	public class ICMPv6Fields {
		/// <summary> Length of the ICMP message type code in bytes.</summary>
		public readonly static int TypeLength = 1;
		/// <summary> Length of the ICMP subcode in bytes.</summary>
		public readonly static int CodeLength = 1;
		/// <summary> Length of the ICMP header checksum in bytes.</summary>
		public readonly static int ChecksumLength = 2;
		/// <summary> Position of the ICMP message type.</summary>
		public readonly static int TypePosition = 0;
		/// <summary> Position of the ICMP message subcode.</summary>
		public readonly static int CodePosition;
		/// <summary> Position of the ICMP header checksum.</summary>
		public readonly static int ChecksumPosition;
		/// <summary> Length in bytes of an ICMP header.</summary>
		public readonly static int HeaderLength; // == 4

		static ICMPv6Fields() {
			CodePosition = TypePosition + TypeLength;
			ChecksumPosition = CodePosition + CodeLength;
			HeaderLength = ChecksumPosition + ChecksumLength;
		}
	}
}
