using System.Runtime.InteropServices;

namespace FreeWorld.Server.Shared.Packets {
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct WhoisRequest : IPacketBase {
		private PacketHeader mHeader;

		public PacketHeader Header {
			get { return mHeader; }
		}

		public int WorldID {
			get;
			set;
		}

		public void SetupHeader() {
			mHeader = new PacketHeader {
				OpCode = EPacketCode.WhoisRequest,
				SizeInBytes = (short)Marshal.SizeOf(this)
			};
		}
	}
}