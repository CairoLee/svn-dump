using System.Runtime.InteropServices;

namespace FreeWorld.Server.Shared.Packets {
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public unsafe struct WhoisResponse : IPacketBase {
		private PacketHeader mHeader;
		public fixed byte Name[16];

		public PacketHeader Header {
			get { return mHeader; }
		}

		public int WorldID {
			get;
			set;
		}

		public void SetupHeader() {
			mHeader = new PacketHeader {
				OpCode = EPacketCode.WhoisResponse,
				SizeInBytes = (short)Marshal.SizeOf(this)
			};
		}
	}
}