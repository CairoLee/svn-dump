namespace GodLesZ.Library.Network.Packet {
	/// <summary>
	/// Defines the lengths and positions of the udp fields within
	/// a udp packet
	/// </summary>
	public struct UdpFields {
		/// <summary> Length of a UDP port in bytes.</summary>
		public readonly static int PortLength = 2;
		/// <summary> Length of the header length field in bytes.</summary>
		public readonly static int HeaderLengthLength = 2;
		/// <summary> Length of the checksum field in bytes.</summary>
		public readonly static int ChecksumLength = 2;
		/// <summary> Position of the source port.</summary>
		public readonly static int SourcePortPosition = 0;
		/// <summary> Position of the destination port.</summary>
		public readonly static int DestinationPortPosition;
		/// <summary> Position of the header length.</summary>
		public readonly static int HeaderLengthPosition;
		/// <summary> Position of the header checksum length.</summary>
		public readonly static int ChecksumPosition;
		/// <summary> Length of a UDP header in bytes.</summary>
		public readonly static int HeaderLength; // == 8

		static UdpFields() {
			DestinationPortPosition = PortLength;
			HeaderLengthPosition = DestinationPortPosition + PortLength;
			ChecksumPosition = HeaderLengthPosition + HeaderLengthLength;
			HeaderLength = ChecksumPosition + ChecksumLength;
		}
	}
}
