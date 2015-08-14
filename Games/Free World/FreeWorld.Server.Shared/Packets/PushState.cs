using System.Runtime.InteropServices;

namespace FreeWorld.Server.Shared.Packets {
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct PushState : IPacketBase {
		private PacketHeader mHeader;

		public PacketHeader Header {
			get { return mHeader; }
		}

		public int WorldID { get; set; }

		public EntityState State { get; set; }

		public void SetupHeader() {
			mHeader = new PacketHeader {
				OpCode = EPacketCode.PushState,
				SizeInBytes = (short)Marshal.SizeOf(this)
			};
		}
	}
}