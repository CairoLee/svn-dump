using System.IO;
using GodLesZ.Library.Network.Packet.Utils;

namespace GodLesZ.Library.Network.Packet {
	/// <summary>
	/// Encapsulates and ensures that we have either a Packet OR
	/// a ByteArraySegment but not both
	/// </summary>
	internal class PacketOrByteArraySegment {
		private ByteArraySegment theByteArraySegment;
		public ByteArraySegment TheByteArraySegment {
			get {
				return theByteArraySegment;
			}

			set {
				thePacket = null;
				theByteArraySegment = value;
			}
		}

		private Packet thePacket;
		public Packet ThePacket {
			get {
				return thePacket;
			}

			set {
				theByteArraySegment = null;
				thePacket = value;
			}
		}

		/// <summary>
		/// Appends to the MemoryStream either the byte[] represented by TheByteArray, or
		/// if ThePacket is non-null, the Packet.Bytes will be appended to the memory stream
		/// which will append ThePacket's header and any encapsulated packets it contains
		/// </summary>
		/// <param name="ms">
		/// A <see cref="MemoryStream"/>
		/// </param>
		public void AppendToMemoryStream(MemoryStream ms) {
			if (ThePacket != null) {
				var theBytes = ThePacket.Bytes;
				ms.Write(theBytes, 0, theBytes.Length);
			} else if (TheByteArraySegment != null) {
				var theBytes = TheByteArraySegment.ActualBytes();
				ms.Write(theBytes, 0, theBytes.Length);
			}
		}

		/// <value>
		/// Whether or not this container contains a packet, a byte[] or neither
		/// </value>
		public PayloadType Type {
			get {
				if (ThePacket != null) {
					return PayloadType.Packet;
				} else if (TheByteArraySegment != null) {
					return PayloadType.Bytes;
				} else {
					return PayloadType.None;
				}
			}
		}
	}
}