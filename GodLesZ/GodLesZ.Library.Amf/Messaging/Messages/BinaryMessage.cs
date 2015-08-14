
using System;
using System.Text;
using GodLesZ.Library.Amf.Messaging.Api;

namespace GodLesZ.Library.Amf.Messaging.Messages {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class BinaryMessage : MessageBase {
		public const string DestinationClientGuid = "05537234-9CF3-4907-8DD0-CD50C28C8409";
		public static byte[] DestinationClientGuidPattern;

		byte[] _lastPattern;

		static BinaryMessage() {
			UTF8Encoding utf8Encoding = new UTF8Encoding();
			DestinationClientGuidPattern = utf8Encoding.GetBytes(BinaryMessage.DestinationClientGuid);
		}

		/// <summary>
		/// Initializes a new instance of the BinaryMessage class.
		/// </summary>
		public BinaryMessage() {
			_lastPattern = DestinationClientGuidPattern;
		}

		private static int Scan(byte[] value, byte[] find, int start) {
			bool matched = false;

			// Cycle through each byte of the searched.  Do not search past
			// searched.Length - find.Length bytes, since it's impossible
			// for the value to be found at that point.
			for (int index = start; index <= value.Length - find.Length; ++index) {
				// Assume the values matched.
				matched = true;
				// Search in the values to be found.
				for (int subIndex = 0; subIndex < find.Length; ++subIndex) {
					// Check the value in the searched array vs the value
					// in the find array.
					if (find[subIndex] != value[index + subIndex]) {
						// The values did not match.
						matched = false;
						break;
					}
				}
				// If the values matched, return the index.
				if (matched)
					return index;
			}
			// None of the values matched.
			return -1;
		}

		internal void Update(IMessageClient messageClient) {
			byte[] binaryContent = this.body as byte[];
			byte[] destClientBinaryId = messageClient.GetBinaryId();
			int patternPosition = Scan(binaryContent, _lastPattern, 0);
			while (patternPosition != -1) {
				Array.Copy(destClientBinaryId, 0, binaryContent, patternPosition, destClientBinaryId.Length);
				patternPosition = Scan(binaryContent, _lastPattern, 0);
			}
			_lastPattern = destClientBinaryId;
		}
	}
}
