using System;
using System.Collections.Generic;
using System.Text;
using GodLesZ.Library.Network.Packet.Utils;
using MiscUtil.Conversion;

namespace GodLesZ.Library.Network.Packet {
	/// <summary>
	/// PPP packet
	/// See http://en.wikipedia.org/wiki/Point-to-Point_Protocol
	/// </summary>
	public class PPPPacket : Packet {
#if DEBUG
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#else
        // NOTE: No need to warn about lack of use, the compiler won't
        //       put any calls to 'log' here but we need 'log' to exist to compile
#pragma warning disable 0169, 0649
        private static readonly ILogInactive log;
#pragma warning restore 0169, 0649
#endif

		/// <summary>
		/// See http://www.iana.org/assignments/ppp-numbers
		/// </summary>
		public PPPProtocol Protocol {
			get {
				return (PPPProtocol)EndianBitConverter.Big.ToUInt16(header.Bytes,
													  header.Offset + PPPFields.ProtocolPosition);
			}

			set {
				var val = (UInt16)value;
				EndianBitConverter.Big.CopyBytes(val,
												 header.Bytes,
												 header.Offset + PPPFields.ProtocolPosition);
			}
		}

		/// <summary>
		/// Construct a new PPPPacket from source and destination mac addresses
		/// </summary>
		public PPPPacket(PPPoECode Code,
					 UInt16 SessionId) {
			log.Debug("");

			// allocate memory for this packet
			int offset = 0;
			int length = PPPFields.HeaderLength;
			var headerBytes = new byte[length];
			header = new ByteArraySegment(headerBytes, offset, length);

			// setup some typical values and default values
			this.Protocol = PPPProtocol.Padding;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="bas">
		/// A <see cref="ByteArraySegment"/>
		/// </param>
		public PPPPacket(ByteArraySegment bas) {
			log.Debug("");

			// slice off the header portion as our header
			header = new ByteArraySegment(bas);
			header.Length = PPPFields.HeaderLength;

			// parse the encapsulated bytes
			payloadPacketOrData = ParseEncapsulatedBytes(header, Protocol);
		}

		internal static PacketOrByteArraySegment ParseEncapsulatedBytes(ByteArraySegment Header,
																		PPPProtocol Protocol) {
			// slice off the payload
			var payload = Header.EncapsulatedBytes();

			log.DebugFormat("payload: {0}", payload);

			var payloadPacketOrData = new PacketOrByteArraySegment();

			switch (Protocol) {
				case PPPProtocol.IPv4:
					payloadPacketOrData.ThePacket = new IPv4Packet(payload);
					break;
				case PPPProtocol.IPv6:
					payloadPacketOrData.ThePacket = new IPv6Packet(payload);
					break;
				default:
					throw new System.NotImplementedException("Protocol of " + Protocol + " is not implemented");
			}

			return payloadPacketOrData;
		}

		/// <summary> Fetch ascii escape sequence of the color associated with this packet type.</summary>
		public override System.String Color {
			get {
				return AnsiEscapeSequences.DarkGray;
			}
		}

		/// <summary cref="Packet.ToString(StringOutputType)" />
		public override string ToString(StringOutputType outputFormat) {
			var buffer = new StringBuilder();
			string color = "";
			string colorEscape = "";

			if (outputFormat == StringOutputType.Colored || outputFormat == StringOutputType.VerboseColored) {
				color = Color;
				colorEscape = AnsiEscapeSequences.Reset;
			}

			if (outputFormat == StringOutputType.Normal || outputFormat == StringOutputType.Colored) {
				// build the output string
				buffer.AppendFormat("{0}[PPPPacket: Protocol={2}]{1}",
					color,
					colorEscape,
					Protocol);
			}

			if (outputFormat == StringOutputType.Verbose || outputFormat == StringOutputType.VerboseColored) {
				// collect the properties and their value
				Dictionary<string, string> properties = new Dictionary<string, string>();
				properties.Add("protocol", Protocol.ToString() + " (0x" + Protocol.ToString("x") + ")");

				// calculate the padding needed to right-justify the property names
				int padLength = Utils.RandomUtils.LongestStringLength(new List<string>(properties.Keys));

				// build the output string
				buffer.AppendLine("PPP:  ******* PPP - \"Point-to-Point Protocol\" - offset=? length=" + TotalPacketLength);
				buffer.AppendLine("PPP:");
				foreach (var property in properties) {
					buffer.AppendLine("PPP: " + property.Key.PadLeft(padLength) + " = " + property.Value);
				}
				buffer.AppendLine("PPP:");
			}

			// append the base output
			buffer.Append(base.ToString(outputFormat));

			return buffer.ToString();
		}

		/// <summary>
		/// Returns the encapsulated PPPPacket of the Packet p or null if
		/// there is no encapsulated packet
		/// </summary>
		/// <param name="p">
		/// A <see cref="Packet"/>
		/// </param>
		/// <returns>
		/// A <see cref="PPPPacket"/>
		/// </returns>
		public static PPPPacket GetEncapsulated(Packet p) {
			if (p is EthernetPacket) {
				var payload = p.PayloadPacket;
				if (payload is PPPoEPacket) {
					return (PPPPacket)payload.PayloadPacket;

				}
			}

			return null;
		}

		/// <summary>
		/// Generate a random PPPoEPacket
		/// </summary>
		/// <returns>
		/// A <see cref="PPPoEPacket"/>
		/// </returns>
		public static PPPoEPacket RandomPacket() {
			throw new System.NotImplementedException();
		}
	}
}

