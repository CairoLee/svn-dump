using System.Runtime.InteropServices;

namespace FreeWorld.Server.Shared.Packets {

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct PacketHeader {
		private short mOpCode;

		public short SizeInBytes {
			get;
			set;
		}


		public EPacketCode OpCode {
			get { return (EPacketCode)mOpCode; }
			set { mOpCode = (short)value; }
		}

	}

}