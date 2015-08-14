using FreeWorld.Server.Shared.Packets;

namespace FreeWorld.Server.Shared {
	/// <summary>
	/// Helper for creating packets
	/// </summary>
	public static class PacketFactory {
		/// <summary>
		/// New up a packet and fill it with mandatory data
		/// </summary>
		public static T CreatePacket<T>() where T : IPacketBase, new() {
			var packet = new T();
			packet.SetupHeader();

			return packet;
		}
	}
}
