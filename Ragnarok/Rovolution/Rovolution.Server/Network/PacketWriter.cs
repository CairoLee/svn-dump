using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GodLesZ.Library;

namespace Rovolution.Server.Network {

	/// <summary>
	/// Works like a StreamWriter, but write only Packet data
	/// </summary>
	public class PacketWriter {
		// Use a pooling to obtain new writer instances
		private static Stack<PacketWriter> mPool = new Stack<PacketWriter>();

		// We stream we are writing to
		private MemoryStream mStream;
		// The max length of this writer
		private int mCapacity;
		// Buffer used to write numeric values in binary format
		private byte[] mBuffer = new byte[4];


		/// <summary>
		/// Gets the current length of the underlying stream
		/// </summary>
		public int Length {
			get { return (int)BaseStream.Length; }
		}

		/// <summary>
		/// Gets the current position of the underlying stream
		/// </summary>
		public int Position {
			get { return (int)BaseStream.Position; }
			set { BaseStream.Position = (int)value; }
		}

		/// <summary>
		/// Returns the stream we are writing to
		/// </summary>
		public MemoryStream BaseStream {
			get { return mStream; }
		}



		/// <summary>
		/// Creates a new instance with a capacity of 32 bytes
		/// </summary>
		public PacketWriter()
			: this(32) {
		}


		/// <summary>
		/// Creates a new instance with the given amount of capacity
		/// </summary>
		/// <param name="capacity"></param>
		public PacketWriter(int capacity) {
			mStream = new MemoryStream(capacity);
			mCapacity = capacity;
		}



		/// <summary>
		/// Creates and returns a new instance of PacketWriter with a max capacity of 32 bytes
		/// </summary>
		/// <returns></returns>
		public static PacketWriter CreateInstance() {
			return CreateInstance(32);
		}

		/// <summary>
		/// Creates and returns a new instance of PacketWriter with the given amount of capacity
		/// </summary>
		/// <param name="capacity"></param>
		/// <returns></returns>
		public static PacketWriter CreateInstance(int capacity) {
			// First try to fetch one from the pool
			PacketWriter pw = null;

			// Yay, threadsafe!
			lock (mPool) {
				// Any stock left?
				if (mPool.Count > 0) {
					pw = mPool.Pop();

					// We got it?
					if (pw != null) {
						// Set internal capacity and reset length
						pw.mCapacity = capacity;
						pw.BaseStream.SetLength(0);
					}
				}
			}

			// Got a instance?
			if (pw == null) {
				// Nope, so just create one
				//TODO: maybe raise pool on this step?
				pw = new PacketWriter(capacity);
			}

			return pw;
		}

		/// <summary>
		/// Realse the given PacketWriter instance and makes it available again in the pool
		/// </summary>
		/// <param name="pw"></param>
		public static void ReleaseInstance(PacketWriter pw) {
			lock (mPool) {
				// If we fetch a writer form the pool, he will be removed from it
				// So this catches manually created writers
				if (!mPool.Contains(pw)) {
					// Then push it to our pool
					mPool.Push(pw);
				} else {
					try {
						//TODO: move to global Logger
						using (StreamWriter op = new StreamWriter("neterr.log")) {
							op.WriteLine("{0}\tInstance pool contains writer", DateTime.Now);
						}
					} catch {
						ServerConsole.ErrorLine("Error on Logging PacketWriter.ReleaseInstance() Error");
					}
				}
			}
		}



		/// <summary>
		/// Writes a boolean value to the stream (internal only 1 byte 0/1)
		/// </summary>
		/// <param name="value"></param>
		public void Write(bool value) {
			Write((byte)(value ? 1 : 0));
		}

		/// <summary>
		/// Writes 1 byte to the stream
		/// </summary>
		/// <param name="value"></param>
		public void Write(byte value) {
			BaseStream.WriteByte(value);
		}

		/// <summary>
		/// Writes a signed byte to the stream
		/// </summary>
		/// <param name="value"></param>
		public void Write(sbyte value) {
			BaseStream.WriteByte((byte)value);
		}

		/// <summary>
		/// Writes a short (2 byte) numeric value to the stream
		/// </summary>
		/// <param name="value"></param>
		public void Write(short value) {
			mBuffer[0] = (byte)(value >> 8);
			mBuffer[1] = (byte)value;

			BaseStream.Write(mBuffer, 0, 2);
		}

		/// <summary>
		/// Writes a unsigned short (2 bytes) to the stream
		/// </summary>
		/// <param name="value"></param>
		public void Write(ushort value) {
			mBuffer[0] = (byte)(value >> 8);
			mBuffer[1] = (byte)value;

			BaseStream.Write(mBuffer, 0, 2);
		}

		/// <summary>
		/// Writes a integer (4 byte) to the stream
		/// </summary>
		/// <param name="value"></param>
		public void Write(int value) {
			mBuffer[0] = (byte)(value >> 24);
			mBuffer[1] = (byte)(value >> 16);
			mBuffer[2] = (byte)(value >> 8);
			mBuffer[3] = (byte)value;

			BaseStream.Write(mBuffer, 0, 4);
		}

		/// <summary>
		/// Writes a unsigned integer (4 byte) to the stream
		/// </summary>
		/// <param name="value"></param>
		public void Write(uint value) {
			mBuffer[0] = (byte)(value >> 24);
			mBuffer[1] = (byte)(value >> 16);
			mBuffer[2] = (byte)(value >> 8);
			mBuffer[3] = (byte)value;

			BaseStream.Write(mBuffer, 0, 4);
		}

		/// <summary>
		/// Writes a whole byte[] array to the stream
		/// </summary>
		/// <param name="buffer"></param>
		/// <param name="offset"></param>
		/// <param name="size"></param>
		public void Write(byte[] buffer, int offset, int size) {
			BaseStream.Write(buffer, offset, size);
		}

		/// <summary>
		/// Writes a stream per byte to the stream
		/// </summary>
		/// <param name="Text"></param>
		public void Write(string Text) {
			Write(Text, Text.Length);
		}

		/// <summary>
		/// Writes size chars to the stream
		/// </summary>
		/// <param name="Text"></param>
		/// <param name="size"></param>
		public void Write(string Text, int size) {
			int length = Text.Length;

			//TODO fix me.. wont work
			BaseStream.SetLength(BaseStream.Length + size);

			if (length >= size) {
				BaseStream.Position += Encoding.ASCII.GetBytes(Text, 0, size, mStream.GetBuffer(), (int)BaseStream.Position);
			} else {
				Encoding.ASCII.GetBytes(Text, 0, length, BaseStream.GetBuffer(), (int)BaseStream.Position);
				BaseStream.Position += size;
			}
		}


		/// <summary>
		/// Fills the buffer with 0-bytes (\0) until capacity reached
		/// </summary>
		public void Fill() {
			Fill((int)(mCapacity - BaseStream.Length));
		}

		/// <summary>
		/// Fills the buffer with length 0-bytes (\0)
		/// </summary>
		/// <param name="length"></param>
		public void Fill(int length) {
			// Reached the end of stream?
			if (BaseStream.Position == BaseStream.Length) {
				// Then increase it
				BaseStream.SetLength(BaseStream.Length + length);
				BaseStream.Seek(0, SeekOrigin.End);
			} else {
				// Just write length 0-bytes
				BaseStream.Write(new byte[length], 0, length);
			}
		}



		/// <summary>
		/// Seeks to the given position
		/// </summary>
		/// <param name="offset"></param>
		/// <param name="origin"></param>
		/// <returns></returns>
		public int Seek(int offset, SeekOrigin origin) {
			return (int)BaseStream.Seek(offset, origin);
		}

		/// <summary>
		/// Returns all data from the underlying stream
		/// </summary>
		/// <returns></returns>
		public byte[] ToArray() {
			return BaseStream.ToArray();
		}


	}

}
