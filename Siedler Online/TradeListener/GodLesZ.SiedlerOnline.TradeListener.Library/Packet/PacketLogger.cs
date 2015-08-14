using System;
using System.IO;

namespace GodLesZ.SiedlerOnline.TradeListener.Library.Packet {

	public static class PacketLogger {

		public static bool LogPackets {
			get;
			set;
		}


		static PacketLogger() {
#if DEBUG
			LogPackets = true;
#endif
		}


		private static void LogRawPacket(string data, string filename) {
			if (LogPackets == false) {
				return;
			}

			using (FileStream fs = File.Open(Environment.CurrentDirectory + "/" + filename + ".log", FileMode.Append)) {
				using (StreamWriter writer = new StreamWriter(fs)) {
					writer.WriteLine(DateTime.Now + " ---------------------------------------------------------------------");
					writer.WriteLine(data);
					writer.WriteLine("-------------------------------------------------");
				}
			}
		}

		public static void LogChatPacket(string xmlBody) {
			LogRawPacket(xmlBody, "Packets-chat");
		}

		public static void LogPacket(string xmlBody) {
			LogRawPacket(xmlBody, "Packets-raw");
		}

	}

}
