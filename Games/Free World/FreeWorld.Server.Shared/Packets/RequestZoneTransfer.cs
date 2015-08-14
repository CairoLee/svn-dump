using System.Runtime.InteropServices;

namespace FreeWorld.Server.Shared.Packets {
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct RequestZoneTransfer : IPacketBase {
		private PacketHeader mHeader;

		public PacketHeader Header {
			get { return mHeader; }
		}

		public int ZoneID { get; set; }

		public void SetupHeader() {
			mHeader = new PacketHeader {
				OpCode = EPacketCode.RequestZoneTransfer,
				SizeInBytes = (short)Marshal.SizeOf(this)
			};
		}
	}
}