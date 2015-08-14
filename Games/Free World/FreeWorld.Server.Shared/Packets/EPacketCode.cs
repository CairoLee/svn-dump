namespace FreeWorld.Server.Shared.Packets {
	/// <summary>
	/// All packet types. Used for serialization.
	/// </summary>
	public enum EPacketCode : short {
		BadType = 0,
		AuthRequest = 1,
		AuthResponse = 2,
		PushState = 3,
		CoalescedData = 4,
		RequestZoneTransfer = 5,
		WhoisRequest = 6,
		WhoisResponse = 7,
		ChatMessage = 8,
		ClockSyncRequest = 9,
		ClockSyncResponse = 10,
	}
}