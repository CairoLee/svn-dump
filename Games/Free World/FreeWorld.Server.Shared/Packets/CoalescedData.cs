using System;
using System.Runtime.InteropServices;

namespace FreeWorld.Server.Shared.Packets {
	/// <summary>
	///     Represents a collection of other packets, packed in to one buffer
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public unsafe struct CoalescedData : IPacketBase {
		//Should fit within standard MTU of 1500
		private const int BUFFER_SIZE = 1400;

		private PacketHeader mHeader;
		private byte mPacketCount;
		private short mUsedBytes;

		/// <summary>
		///     <see cref="Buffer" /> for all other packets
		/// </summary>
		public fixed byte DataBuffer [BUFFER_SIZE];

		public PacketHeader Header {
			get { return mHeader; }
		}

		/// <summary>
		///     Amount of packets contained within the buffer
		/// </summary>
		public byte PacketCount {
			get { return mPacketCount; }
			set { mPacketCount = value; }
		}

		/// <summary>
		///     Try to add a <paramref name="packet" /> into the buffer. Returns
		///     <see langword="true" /> if the <paramref name="packet" /> was
		///     successfully copied.
		/// </summary>
		public bool TryAddPacket(IPacketBase packet) {
			fixed (byte* buf = DataBuffer) {
				int packetSize = packet.Header.SizeInBytes;

				if (mUsedBytes + packetSize < BUFFER_SIZE) {
					//Copy packet into buffer
					Marshal.StructureToPtr(packet, (IntPtr)(buf + mUsedBytes), false);

					//Update used bytes and packet count
					mUsedBytes += (short)packetSize;
					mPacketCount++;

					//Update actual size
					mHeader.SizeInBytes = (short)(Marshal.SizeOf(this) - BUFFER_SIZE + mUsedBytes);

					return true;
				}
			}

			return false;
		}

		public void SetupHeader() {
			mHeader = new PacketHeader {
				OpCode = EPacketCode.CoalescedData,
				SizeInBytes = (short)(Marshal.SizeOf(this) - BUFFER_SIZE)
			};
		}
	}
}