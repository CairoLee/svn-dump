using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GodLesZ.Library;
using Rovolution.Server.Diagnostics;
using Rovolution.Server.Geometry;

namespace Rovolution.Server.Network {

	public class Packet {

		private const int BufferSize = 128;
		private static BufferPool mBuffers = new BufferPool("Compressed", 16, BufferSize);

		protected PacketWriter mStream;
		private ushort mPacketID;
		private int mLength;
		private EPacketState mState;
		private byte[] mCompiledBuffer;
		private int mCompiledLength;

		/// <summary>
		/// Gets the packetID or sets them
		/// <para>Note: Writes the new ID also to the stream and restore the position to the prev one</para>
		/// </summary>
		public ushort PacketID {
			get { return mPacketID; }
			set {
				mPacketID = value;
				int pos = Writer.Position;
				Seek(0, SeekOrigin.Begin);
				Write(mPacketID);
				Seek(pos, SeekOrigin.Begin);
			}
		}

		public int Length {
			get { return mLength; }
			set { mLength = value; }
		}

		public PacketWriter Writer {
			get { return mStream; }
		}


		public Packet(short packetID)
			: this(packetID, 0) {
		}

		public Packet(short packetID, int packetLength) {
			mPacketID = (ushort)packetID;
			mLength = packetLength;

			mStream = PacketWriter.CreateInstance(packetLength);
			// On <= 0 packetID's we assume its a "special" packet
			// Special packets containing data without IDs..
			if (packetID > 0) {
				mStream.Write((short)mPacketID);
			}
			// Fix - not every packet has the length as second parameter..
			//mStream.Write(mLength);

			PacketSendProfile prof = PacketSendProfile.Acquire(GetType());
			if (prof != null)
				prof.Created++;
		}


		public void EnsureCapacity(int length) {
			mStream = PacketWriter.CreateInstance(length);
			mStream.Write((ushort)mPacketID);
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

		public virtual bool OnBeforeSend(NetState state) {
			// @TODO: delegates & events!
			// Return true to send
			return true;
		}

		public virtual void OnSend(NetState state) {
			// Assume data was send
			OnSend(state, true);
		}
		public virtual void OnSend(NetState state, bool wasSend) {
			// Update internal state
			if ((mState & (EPacketState.Acquired | EPacketState.Static)) == 0) {
				Free();
			}
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
			if (mLength == 0) {
				mLength = (int)mStream.Length;
			}

			if (mStream.Length != mLength) {
				int diff = (int)mStream.Length - mLength;
				ServerConsole.ErrorLine("Packet {0:X4}: Bad packet length! ({1}{2} bytes)", mPacketID, diff >= 0 ? "+" : "", diff);
			}

			//mStream.Seek(2, SeekOrigin.Begin);
			//mStream.Write(mLength);

			MemoryStream ms = mStream.BaseStream;
			//mCompiledBuffer = ms.GetBuffer();
			mCompiledLength = (int)ms.Length;
			mCompiledBuffer = new byte[mCompiledLength];
			Buffer.BlockCopy(ms.GetBuffer(), 0, mCompiledBuffer, 0, mCompiledLength);

			PacketWriter.ReleaseInstance(mStream);
			mStream = null;
		}


		#region PacketWriter overwrites/takeovers
		/// <summary>
		/// Writes a boolean value to the stream (internal only 1 byte 0/1)
		/// </summary>
		/// <param name="value"></param>
		public void Write(bool value) {
			Writer.Write(value);
		}

		/// <summary>
		/// Writes 1 byte to the stream
		/// </summary>
		/// <param name="value"></param>
		public void Write(byte value) {
			Writer.Write(value);
		}

		/// <summary>
		/// Writes a signed byte to the stream
		/// </summary>
		/// <param name="value"></param>
		public void Write(sbyte value) {
			Writer.Write(value);
		}

		/// <summary>
		/// Writes a short (2 byte) numeric value to the stream
		/// </summary>
		/// <param name="value"></param>
		public void Write(short value) {
			Writer.Write(value);
		}

		/// <summary>
		/// Writes a unsigned short (2 bytes) to the stream
		/// </summary>
		/// <param name="value"></param>
		public void Write(ushort value) {
			Writer.Write(value);
		}

		/// <summary>
		/// Writes a integer (4 byte) to the stream
		/// </summary>
		/// <param name="value"></param>
		public void Write(int value) {
			Writer.Write(value);
		}

		/// <summary>
		/// Writes a unsigned integer (4 byte) to the stream
		/// </summary>
		/// <param name="value"></param>
		public void Write(uint value) {
			Writer.Write(value);
		}

		/// <summary>
		/// Writes a whole byte[] array to the stream
		/// </summary>
		/// <param name="buffer"></param>
		/// <param name="offset"></param>
		/// <param name="size"></param>
		public void Write(byte[] buffer, int offset, int size) {
			Writer.Write(buffer, offset, size);
		}

		/// <summary>
		/// Writes a string per char to the stream (without leading zero)
		/// </summary>
		/// <param name="Text"></param>
		public void Write(string Text) {
			Write(Text, Text.Length);
		}

		/// <summary>
		/// Writes a string per char to the stream
		/// </summary>
		/// <param name="Text"></param>
		/// <param name="writeLeadingZero"></param>
		public void Write(string Text, bool writeLeadingZero) {
			Write(Text, Text.Length, writeLeadingZero);
		}

		/// <summary>
		/// Writes size-acount chars to the stream (without leading zero)
		/// </summary>
		/// <param name="Text"></param>
		/// <param name="size"></param>
		public void Write(string Text, int size) {
			Write(Text, size, false);
		}

		/// <summary>
		/// Writes size-acount chars to the stream
		/// </summary>
		/// <param name="Text"></param>
		/// <param name="size"></param>
		/// <param name="writeLeadingZero"></param>
		public void Write(string Text, int size, bool writeLeadingZero) {
			Writer.Write(Text, size, writeLeadingZero);
		}

		public void Write(Location loc) {
			Writer.Write(loc);
		}

		public void Write(Point2D p1, Point2D p2, Point2D p3) {
			Writer.Write(p1, p2, p3);
		}


		/// <summary>
		/// Fills the buffer with 0-bytes (\0) until capacity reached
		/// </summary>
		public void Fill() {
			Writer.Fill();
		}

		/// <summary>
		/// Fills the buffer with length 0-bytes (\0)
		/// </summary>
		/// <param name="length"></param>
		public void Fill(int length) {
			Writer.Fill(length);
		}



		/// <summary>
		/// Seeks to the given position
		/// </summary>
		/// <param name="offset"></param>
		/// <param name="origin"></param>
		/// <returns></returns>
		public int Seek(int offset, SeekOrigin origin) {
			return Writer.Seek(offset, origin);
		}

		/// <summary>
		/// Returns all data from the underlying stream
		/// </summary>
		/// <returns></returns>
		public byte[] ToArray() {
			return Writer.ToArray();
		}
		#endregion

	}

}
