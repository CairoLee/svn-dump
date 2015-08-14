using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using GodLesZ.Library.Amf.IO;
using GodLesZ.SiedlerOnline.TradeListener.Library.Packet;

namespace GodLesZ.SiedlerOnline.TradeListener.Library {

	[XmlRoot("body")]
	public class DsoChatPacket : ICloneable {
		public static Encoding TextEncoding = Encoding.UTF8; //Encoding.GetEncoding("ISO-8859-1");
		public static Regex BodyDetection = new Regex("<body.*<message.*</message>.*</body>", RegexOptions.Compiled | RegexOptions.Multiline);
		public static Regex RegexMessages = new Regex("(<message[^>]*><body>(.*?)</body><bbmsg[^>]*></message>)", RegexOptions.Compiled | RegexOptions.Multiline);

#if DEBUG
		public static bool LogPackets = true;
#else
		public static bool LogPackets = false;
#endif

		[XmlArray("messages")]
		[XmlArrayItem("message")]
		public List<DsoChatPacketMessage> Messages {
			get;
			set;
		}

		public DsoChatPacket() {
			Messages = new List<DsoChatPacketMessage>();
		}


		public static DsoChatPacket Parse(byte[] data) {
			string rawXmlData = TextEncoding.GetString(data);

			return Parse(rawXmlData, data);
		}

		public static DsoChatPacket Parse(string rawXmlData) {
			return Parse(rawXmlData, new byte[0]);
		}

		public static DsoChatPacket Parse(string rawXmlData, byte[] rawData) {
			PacketLogger.LogPacket(rawXmlData);

			string xmlBody = SkipHeader(rawXmlData);
			if (string.IsNullOrEmpty(xmlBody)) {
				// Failed to match against XML
				// Try AMF
				DsoChatPacket amfPacket;
				if ((amfPacket = TryParseAmf(rawXmlData, rawData)) == null) {
					return null;
				}

				return amfPacket;
			}
			if (BodyDetection.IsMatch(xmlBody) == false) {
				return null;
			}

			PacketLogger.LogChatPacket(xmlBody);

			// Remove namespaces..
			xmlBody = Regex.Replace(xmlBody, " xmlns=(\"|')[^\"']*(\"|')", "");

			// Get all messages
			MatchCollection matches = RegexMessages.Matches(xmlBody);
			if (matches == null || matches.Count == 0) {
				return null;
			}

			// Build our xml struct
			// <body><messages>...</messages></body>
			string validXml = "<body><messages>";
			foreach (Match match in matches) {
				validXml += match.Value;
			}
			validXml += "</messages></body>";

			// Deserialize
			try {
				XmlSerializer serializer = new XmlSerializer(typeof(DsoChatPacket));
				using (StringReader stringStream = new StringReader(validXml)) {
					DsoChatPacket doc = (DsoChatPacket)serializer.Deserialize(stringStream);
					return doc;
				}
			} catch {
				// Incomplete packet maybe..

				return null;
			}
		}

		private static DsoChatPacket TryParseAmf(string rawXmlData, byte[] rawData) {
			if (rawXmlData.Contains(@"/onResult") == false || rawXmlData.Contains("\r\n\r\n") == false) {
				return null;
			}

			// Skip after \r\n\r\n
			int p = rawXmlData.IndexOf("\r\n\r\n");
			var amfBody = rawXmlData.Substring(p + 4);
			// Next \r\n denotes AMF start, i thinnk..
			if (amfBody.Contains("\r\n")) {
				p = amfBody.IndexOf("\r\n");
				amfBody = amfBody.Substring(p + 2);
			}
			var amfRawBody = TextEncoding.GetBytes(amfBody);
			
			using (var stream = new MemoryStream(amfRawBody)) {
				var deserializer = new AMFDeserializer(stream);
				var message = deserializer.ReadAMFMessage();
			}

			return null;
		}


		/// <summary>
		/// Searches for the XML namespace and returns the string from the begining of the first found tag using a namspace.
		/// </summary>
		/// <param name="xml"></param>
		/// <returns></returns>
		private static string SkipHeader(string xml) {
			if (xml.StartsWith("<body")) {
				return xml;
			}

			// Skip after \r\n\r\n
			int p = xml.IndexOf("\r\n\r\n");
			if (p != -1) {
				xml = xml.Substring(p).Trim();
				if (xml.StartsWith("<body")) {
					return xml;
				}

			}

			return null;
		}


		public virtual object Clone() {
			var p = new DsoChatPacket();
			p.Messages.AddRange(Messages);
			return p;
		}

	}

}
