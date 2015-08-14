using System.Runtime.InteropServices;

namespace FreeWorld.Server.Shared.Packets {
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ClockSyncRequest : IPacketBase {
		private PacketHeader mHeader;

		public PacketHeader Header {
			get { return mHeader; }
		}

		public void SetupHeader() {
			mHeader = new PacketHeader {
				OpCode = EPacketCode.ClockSyncRequest,
				SizeInBytes = (short)Marshal.SizeOf(this)
			};
		}
	}
}