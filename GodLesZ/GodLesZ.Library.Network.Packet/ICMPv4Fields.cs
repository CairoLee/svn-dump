
namespace GodLesZ.Library.Network.Packet {
	/// <summary>
	/// ICMP protocol field encoding information.
	/// See http://en.wikipedia.org/wiki/ICMPv6
	/// </summary>
	public class ICMPv4Fields {
		/// <summary> Length of the ICMP message type code in bytes.</summary>
		public readonly static int TypeCodeLength = 2;
		/// <summary> Length of the ICMP header checksum in bytes.</summary>
		public readonly static int ChecksumLength = 2;
		/// <summary> Length of the ICMP ID field in bytes.</summary>
		public readonly static int IDLength = 2;
		/// <summary> Length of the ICMP Sequence field in bytes </summary>
		public readonly static int SequenceLength = 2;

		/// <summary> Position of the ICMP message type/code.</summary>
		public readonly static int TypeCodePosition = 0;
		/// <summary> Position of the ICMP header checksum.</summary>
		public readonly static int ChecksumPosition;
		/// <summary> Position of the ICMP ID field </summary>
		public readonly static int IDPosition;
		/// <summary> Position of the Sequence field </summary>
		public readonly static int SequencePosition;
		/// <summary> Length in bytes of an ICMP header.</summary>
		public readonly static int HeaderLength;

		static ICMPv4Fields() {
			TypeCodePosition = 0;
			ChecksumPosition = TypeCodePosition + TypeCodeLength;
			IDPosition = ChecksumPosition + ChecksumLength;
			SequencePosition = IDPosition + IDLength;
			HeaderLength = SequencePosition + SequenceLength;
		}
	}
}
