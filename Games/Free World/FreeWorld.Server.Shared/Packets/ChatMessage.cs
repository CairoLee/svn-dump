using System.Runtime.InteropServices;

namespace FreeWorld.Server.Shared.Packets {
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public unsafe struct ChatMessage : IPacketBase {
		private PacketHeader mHeader;

		public int RecipientId;
		public fixed byte Message[256];

		public PacketHeader Header {
			get { return mHeader; }
		}

		public void SetupHeader() {
			mHeader = new PacketHeader {
				OpCode = EPacketCode.ChatMessage,
				SizeInBytes = (short)(Marshal.SizeOf(this) - 256)
			};
		}

		public void SetText(string message) {
			fixed (byte* messageBuffer = Message) {
				TextHelpers.StringToBuffer(message, messageBuffer, 256);
			}
			mHeader.SizeInBytes = (short)(Marshal.SizeOf(this) - 256 + message.Length + 1);
		}
	}
}