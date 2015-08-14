namespace FreeWorld.Server.Shared.Packets {
	/// <summary>
	///     Base <see langword="interface" /> of all packets
	/// </summary>
	public interface IPacketBase {
		PacketHeader Header { get; }

		void SetupHeader();
	}
}