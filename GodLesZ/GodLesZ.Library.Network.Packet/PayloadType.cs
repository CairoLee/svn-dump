
namespace GodLesZ.Library.Network.Packet {
	/// <summary>
	/// Differentiates between a packet class payload, a byte[] payload
	/// or no payload
	/// </summary>
	internal enum PayloadType {
		Packet,
		Bytes,
		None
	}
}
