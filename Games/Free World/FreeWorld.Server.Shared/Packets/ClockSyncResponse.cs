using System.Runtime.InteropServices;

namespace FreeWorld.Server.Shared.Packets {
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ClockSyncResponse : IPacketBase {
		private PacketHeader mHeader;

		public PacketHeader Header {
			get { return mHeader; }
		}

		public int Time {
			get;
			set;
		}

		public void SetupHeader() {
			mHeader = new PacketHeader {
				OpCode = EPacketCode.ClockSyncResponse,
				SizeInBytes = (short)Marshal.SizeOf(this)
			};
		}
	}
}