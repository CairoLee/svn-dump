using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GodLesZ.Library;
using Rovolution.Server.Diagnostics;

namespace Rovolution.Server.Network {

	public abstract class Packet {

		private const int BufferSize = 4096;
		private static BufferPool mBuffers = new BufferPool("Compressed", 16, BufferSize);

		protected PacketWriter mStream;
		private short mPacketID;
		private int mLength;
		private EPacketState mState;
		private byte[] mCompiledBuffer;
		private int mCompiledLength;

		public short PacketID {
			get { return mPacketID; }
		}

		public PacketWriter BaseStream {
			get { return mStream; }
		}


		public Packet(short packetID)
			: this(packetID, 0) {
		}

		public Packet(short packetID, int packetLength) {
			mPacketID = packetID;
			mLength = packetLength;

			mStream = PacketWriter.CreateInstance();
			mStream.Write((short)mPacketID);
			mStream.Write(mLength);

			PacketSendProfile prof = PacketSendProfile.Acquire(GetType());
			if (prof != null)
				prof.Created++;
		}


		public void EnsureCapacity(int length) {
			mStream = PacketWriter.CreateInstance(length);
			mStream.Write((short)mPacketID);
		}


		public static Packet SetStatic(Packet p) {
			p.SetStatic();
			return p;
		}

		public static Packet Acquire(Packet p) {
			p.Acquire();
			return p;
		}

		public static void Release(ref Packet p) {
			if (p != null)
				p.Release();

			p = null;
		}

		public static void Release(Packet p) {
			if (p != null)
				p.Release();
		}

		public void SetStatic() {
			mState |= EPacketState.Static | EPacketState.Acquired;
		}

		public void Acquire() {
			mState |= EPacketState.Acquired;
		}

		public void OnSend() {
			if ((mState & (EPacketState.Acquired | EPacketState.Static)) == 0)
				Free();
		}

		private void Free() {
			if (mCompiledBuffer == null)
				return;

			if ((mState & EPacketState.Buffered) != 0)
				mBuffers.ReleaseBuffer(mCompiledBuffer);

			mState &= ~(EPacketState.Static | EPacketState.Acquired | EPacketState.Buffered);

			mCompiledBuffer = null;
		}

		public void Release() {
			if ((mState & EPacketState.Acquired) != 0)
				Free();
		}


		public byte[] Compile(out int length) {
			if (mCompiledBuffer == null) {
				if ((mState & EPacketState.Accessed) == 0) {
					mState |= EPacketState.Accessed;
				} else {
					if ((mState & EPacketState.Warned) == 0) {
						mState |= EPacketState.Warned;

						try {
							using (StreamWriter op = new StreamWriter("net_opt.log", true)) {
								op.WriteLine("Redundant compile for packet {0}, use Acquire() and Release()", this.GetType());
								op.WriteLine(new System.Diagnostics.StackTrace());
							}
						} catch { }
					}

					mCompiledBuffer = new byte[0];
					mCompiledLength = 0;

					length = mCompiledLength;
					return mCompiledBuffer;
				}

				InternalCompile();
			}

			length = mCompiledLength;
			return mCompiledBuffer;
		}

		private void InternalCompile() {
			if (mLength == 0)
				mLength = (int)mStream.Length;

			if (mStream.Length != mLength) {
				int diff = (int)mStream.Length - mLength;
				ServerConsole.ErrorLine("Packet {0:X4}: Bad packet length! ({1}{2} bytes)", mPacketID, diff >= 0 ? "+" : "", diff);
			}

			mStream.Seek(2, SeekOrigin.Begin);
			mStream.Write(mLength);

			MemoryStream ms = mStream.BaseStream;
			mCompiledBuffer = ms.GetBuffer();
			mCompiledLength = (int)ms.Length;

			PacketWriter.ReleaseInstance(mStream);
			mStream = null;
		}

	}

}
