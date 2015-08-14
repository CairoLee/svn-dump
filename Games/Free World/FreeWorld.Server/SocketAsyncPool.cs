using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Collections.Concurrent;
using System.Threading;

namespace FreeWorld.Server {
	/// <summary>
	/// Pool for socket async context objects that share the same memory buffer
	/// </summary>
	public class SocketAsyncPool {
		/// <summary>
		/// Memory pool for all send / receive buffers
		/// </summary>
		private readonly byte[] mBuffer;

		/// <summary>
		/// GCHandle for the buffer, so that it can be pinned.
		/// </summary>
		private GCHandle mBufferHandle;

		/// <summary>
		/// Pool of async context objects
		/// </summary>
		private readonly SocketAsyncEventArgs[] mEventArgs;

		/// <summary>
		/// Queue of which objects are free
		/// </summary>
		private readonly ConcurrentQueue<int> mFreeObjects;

		/// <summary>
		/// How many bytes each buffer contains
		/// </summary>
		private int mBufferSize;


		/// <summary>
		/// Create a pool of async socket context objects
		/// </summary>
		public SocketAsyncPool(int bufferSize, int maxCount) {
			mBufferSize = bufferSize;

			//Allocate and pin memory pool
			mBuffer = new byte[maxCount * bufferSize];
			mBufferHandle = GCHandle.Alloc(mBuffer, GCHandleType.Pinned);

			mEventArgs = new SocketAsyncEventArgs[maxCount];
			mFreeObjects = new ConcurrentQueue<int>();

			//Setup all context objects with their buffers
			for (var i = 0; i < maxCount; i++) {
				mEventArgs[i] = new SocketAsyncEventArgs {
					UserToken = i
				};
				mEventArgs[i].SetBuffer(mBuffer, i * bufferSize, bufferSize);

				mFreeObjects.Enqueue(i);
			}
		}

		/// <summary>
		/// Get a context object from the pool
		/// </summary>
		public SocketAsyncEventArgs GetArgs() {
			int freeIndex;

			while (!mFreeObjects.TryDequeue(out freeIndex)) {
				Thread.Sleep(0);
			}

			return mEventArgs[freeIndex];
		}

		/// <summary>
		/// Return a context object to the pool
		/// </summary>
		/// <param name="args"></param>
		public void ReturnArgs(SocketAsyncEventArgs args) {
			mFreeObjects.Enqueue((int)args.UserToken);
		}

	}

}
