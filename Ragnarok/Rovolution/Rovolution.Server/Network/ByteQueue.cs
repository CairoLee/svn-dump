using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Network {

	public class ByteQueue {
		private int mSize;
		private int mIndex;
		private byte[] mBuffer;

		public int Length {
			get { return mSize; }
		}

		public byte[] ByteBuffer {
			get { return mBuffer; }
		}



		public ByteQueue() {
			Clear();
		}


		public void Clear() {
			mBuffer = new byte[0];
			mIndex = 0;
			mSize = 0;
		}

		private void SetCapacity(int capacity) {
			byte[] newBuffer = new byte[capacity];

			if (mSize > 0 && mSize != capacity) {
				int copyLength = Math.Min(mSize, newBuffer.Length);
				Buffer.BlockCopy(mBuffer, 0, newBuffer, 0, copyLength);
			}

			mSize = newBuffer.Length;
			mIndex = (mIndex < mSize ? mIndex : mSize - 1);
			mBuffer = newBuffer;
		}

		public short GetPacketID() {
			if (mSize >= 2) {
				return BitConverter.ToInt16(mBuffer, 0);
			}
			return -1;
		}

		public int GetPacketLength() {
			if (mSize >= 4) {
				BitConverter.ToInt16(mBuffer, 2);
			}
			return -1;
		}

		public int Dequeue(byte[] buffer, int offset, int size) {
			if (size > mSize) {
				size = mSize;
			}

			if (size == 0 || mBuffer == null) {
				return 0;
			}

			Buffer.BlockCopy(mBuffer, mIndex, buffer, offset, size);

			mIndex += size;
			mSize -= size;

			if (mSize == 0) {
				Clear();
			}

			return size;
		}

		public void Enqueue(byte[] buffer, int offset, int size) {
			SetCapacity(mSize + size);

			Buffer.BlockCopy(buffer, offset, mBuffer, mIndex, size);
		}

	}

}
