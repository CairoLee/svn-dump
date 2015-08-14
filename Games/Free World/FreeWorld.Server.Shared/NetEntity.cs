using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using FreeWorld.Server.Shared.Packets;

namespace FreeWorld.Server.Shared {

	/// <summary>
	/// Networking core of the server
	/// </summary>
	public abstract class NetEntity : IDisposable {
		/// <summary>
		/// Send and receive buffer size
		/// </summary>
		protected const int BufferSize = 2048;

		protected int mWorldID = -1;

		/// <summary>
		/// This entity's current authorisation state
		/// </summary>
		public EEntityAuthState AuthState {
			get;
			protected set;
		}

		/// <summary>
		/// Is this entity's socket connected?
		/// </summary>
		public bool IsConnected {
			get { return mSocket.Connected; }
		}

		/// <summary>
		/// The current network time
		/// </summary>
		public int NetworkTime {
			get { return Environment.TickCount + mClockOffset; }
		}

		/// <summary>
		/// The world ID of this entity
		/// </summary>
		/// <exception cref="Exception">Resetting world ID is not allowed!</exception>
		public int WorldID {
			get { return mWorldID; }
			set {
				if (mWorldID == -1) {
					mWorldID = value;
				} else {
					// Don't let the world ID be set more than once... 
					// this will just cause headaches and bugs with indexing players
					throw new Exception("Resetting world ID is not allowed!");
				}
			}
		}

		/// <summary>
		/// The socket for net IO with this entity
		/// </summary>
		protected readonly Socket mSocket;

		/// <summary>
		/// List of packets that have accumulated to be sent at the next update
		/// </summary>
		protected readonly List<CoalescedData> mDeferredSendList = new List<CoalescedData>();

		/// <summary>
		/// The current working deferred packet
		/// </summary>
		protected CoalescedData mCurrentDeferredPacket = PacketFactory.CreatePacket<CoalescedData>();

		/// <summary>
		/// Async send context object
		/// </summary>
		protected SocketAsyncEventArgs mSendArgs;

		/// <summary>
		/// Async receive context object
		/// </summary>
		protected SocketAsyncEventArgs mReceiveArgs;

		/// <summary>
		/// Pointer to the send buffer, used to serialize packets directly to the buffer
		/// </summary>
		protected readonly IntPtr mSendBufferPtr;

		/// <summary>
		/// Incoming IO queue
		/// </summary>
		protected readonly ConcurrentQueue<IPacketBase> mIncomingQueue = new ConcurrentQueue<IPacketBase>();

		/// <summary>
		/// Outgoing IO queue
		/// </summary>
		protected readonly ConcurrentQueue<IPacketBase> mOutgoingQueue = new ConcurrentQueue<IPacketBase>();

		/// <summary>
		/// Working buffer for constructing packets from the tcp stream
		/// </summary>
		protected readonly byte[] mWorkingPacketBuffer = new byte[BufferSize];

		/// <summary>
		/// The expected size of the working packet
		/// </summary>
		protected int mWorkingPacketSize;

		/// <summary>
		/// The amount of bytes received for the current working packet
		/// </summary>
		protected int mWorkingPacketReceivedBytes;

		/// <summary>
		/// GC handle for pinning the working buffer
		/// </summary>
		protected GCHandle mWorkingPacketBufferHandle;

		/// <summary>
		/// Cancellation token for net IO
		/// </summary>
		protected readonly CancellationTokenSource mIoStopToken;

		/// <summary>
		/// Are we waiting to get a clock sync response back?
		/// </summary>
		protected bool mAwaitingClockSyncResponse;

		/// <summary>
		/// The time that the last clock sync request was sent
		/// </summary>
		protected int mClockSyncSendTime;

		/// <summary>
		/// A list of the delta history
		/// </summary>
		protected readonly Queue<int> mRoundTripTimes = new Queue<int>();

		/// <summary>
		/// Flag to indicate whether a send is currently in progress.
		/// </summary>
		protected long mSending;

		/// <summary>
		/// The offset to apply to the local clock to get the remote time
		/// </summary>
		protected int mClockOffset;

		#region TEMPORARY COUNTERS! Clean this!
		public static int StatIncomingPackets = 0;
		public static int StatOutgoingPackets = 0;
		public static int StatOutgoingBytes = 0;
		public static int StatIncomingBytes = 0;
		#endregion

		/// <summary>
		/// Create a new entity from a socket and immediately assign it a world id.
		/// Requires async socket context objects with buffers pre-assigned
		/// </summary>
		protected NetEntity(Socket socket, int worldID, SocketAsyncEventArgs sendEventArgs, SocketAsyncEventArgs receiveEventArgs) {
			WorldID = worldID;

			mSendArgs = sendEventArgs;
			mSendArgs.Completed += SendCompleted;
			mReceiveArgs = receiveEventArgs;
			mReceiveArgs.Completed += ReceiveCompleted;

			unsafe {
				//Get the pointer for the send buffer
				byte[] buffer = mSendArgs.Buffer;
				fixed (byte* bufPtr = buffer) {
					mSendBufferPtr = (IntPtr)(bufPtr + mSendArgs.Offset);
				}
			}

			//Setup socket
			mSocket = socket;
			socket.NoDelay = true; //No nagling
			socket.ReceiveBufferSize = BufferSize;
			socket.SendBufferSize = BufferSize;

			AuthState = EEntityAuthState.Unauthorised;

			//Pin buffers so that we can block copy structs to / from them
			mWorkingPacketBufferHandle = GCHandle.Alloc(mWorkingPacketBuffer, GCHandleType.Pinned);

			mIoStopToken = new CancellationTokenSource();

			//Kick off net IO tasks
			//QueueSend();
			QueueReceive();
		}

		/// <summary>
		/// Begins data send task on the thread pool
		/// </summary>
		protected void QueueSend() {
			//Update sending flag
			Interlocked.Exchange(ref mSending, 1);

			//Start sending on the task pool
			var sendTask = new Task(Send);
			sendTask.ContinueWith(t => t.Dispose());
			sendTask.Start();
		}

		/// <summary>
		/// Begins data receive task on the thread pool
		/// </summary>
		protected void QueueReceive() {
			//Start receiving on the task pool
			var receiveTask = new Task(Receive);
			receiveTask.ContinueWith(t => t.Dispose());
			receiveTask.Start();
		}

		/// <summary>
		/// Poll the outgoing queue and send any packets
		/// </summary>
		protected void Send() {
			IPacketBase packet;

			//Grab a packet to send
			while (mOutgoingQueue.TryDequeue(out packet) == false) {
				Thread.Sleep(0);
			}

			//Bail out if we lost connection
			if (mSocket.Connected == false) {
				// @TODO: Some sort of onConnectionLost handling?
				return;
			}

			//Serialize the packet into the send buffer
			SerializePacket(packet);

			try {
				//Send packet bytes over the wire
				mSendArgs.SetBuffer(mSendArgs.Offset, packet.Header.SizeInBytes);
				if (!mSocket.SendAsync(mSendArgs)) {
					SendCompleted(mSocket, mSendArgs);
				}
			} catch (SocketException) {
				//Client disconnect
				// @TODO: Some sort of onConnectionLost handling?
			} catch (Exception ex) {
				Console.WriteLine("Send error! " + ex);
			}
		}

		/// <summary>
		/// Serialize the given packet into the send buffer.
		/// </summary>
		protected void SerializePacket(IPacketBase packet) {
			try {
				Marshal.StructureToPtr(packet, mSendBufferPtr, false);
			} catch (Exception ex) {
				Console.WriteLine("Serialization error! " + ex);
			}
		}

		/// <summary>
		/// Event handler for async send completion
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SendCompleted(object sender, SocketAsyncEventArgs e) {
			if (e.SocketError == SocketError.Success) {
				StatOutgoingBytes += e.BytesTransferred;
				StatOutgoingPackets++;

				//Send again if there are more packets in the queue
				if (mOutgoingQueue.Count > 0) {
					QueueSend();
				} else {
					//Unset the sending flag if there is nothing more to send
					Interlocked.Exchange(ref mSending, 0);
				}
			}
		}

		/// <summary>
		/// Starts an async receive from the socket
		/// </summary>
		protected void Receive() {
			try {
				if (mSocket.Connected) {
					//Receive data from the wire
					if (!mSocket.ReceiveAsync(mReceiveArgs)) {
						ReceiveCompleted(mSocket, mReceiveArgs);
					}
				} else {
					mSocket.Dispose();
				}

			} catch (SocketException) {
				//Socket disconnected
				// @TODO: Some sort of onConnectionLost handling?
			} catch (Exception ex) {
				Console.WriteLine("Receive error! " + ex);
			}
		}

		/// <summary>
		/// Handle a received packet
		/// </summary>
		protected void ReceiveCompleted(object sender, SocketAsyncEventArgs e) {
			if (e.SocketError != SocketError.Success) {
				return;
			}

			StatIncomingBytes += e.BytesTransferred;

			if (e.BytesTransferred <= 0) {
				//We were sent junk. Disconnect...
				mSocket.Disconnect(false);
				return;
			}
			
			var bytesConsumed = 0;

			//While there are bytes to be consumed in the receive buffer...
			while (bytesConsumed < e.BytesTransferred) {
				//Work out how many bytes (if any) we need to complete the packet in the working buffer
				var bytesNeededForPacketCompletion = mWorkingPacketSize - mWorkingPacketReceivedBytes;

				//If we're awaiting a new packet...
				if (bytesNeededForPacketCompletion == 0) {
					if (e.BytesTransferred - bytesConsumed < 2) {
						//Haven't seen this happen since the refactor...
						Console.WriteLine("PROBLEM!");
					}

					//Get the size we're expecting from the receive buffer
					mWorkingPacketSize = BitConverter.ToInt16(e.Buffer, e.Offset + bytesConsumed);

					//Update the number of bytes we need to construct the whole packet
					bytesNeededForPacketCompletion = mWorkingPacketSize;
				}

				//Copy as much of the current working packet from the receive buffer as possible
				int bytesToCopy = Math.Min(bytesNeededForPacketCompletion, e.BytesTransferred - bytesConsumed);
				Buffer.BlockCopy(e.Buffer, e.Offset + bytesConsumed, mWorkingPacketBuffer, mWorkingPacketReceivedBytes, bytesToCopy);

				//If we have enough data to complete the packet, we should deserialize it from the working buffer
				if (e.BytesTransferred - bytesConsumed >= bytesNeededForPacketCompletion) {
					//Deserialize from the working buffer
					DeserializePacket(mWorkingPacketBufferHandle.AddrOfPinnedObject());

					//Expect a new packet from the stream
					mWorkingPacketReceivedBytes = 0;
					mWorkingPacketSize = 0;

					StatIncomingPackets++;
				} else {
					//If we didn't receive enough bytes to complete the packet, update the counters so that we can continue constructing it next receive
					mWorkingPacketReceivedBytes += bytesToCopy;
				}

				//Count how many bytes we've used from the buffer (there may be multiple packets per receive)
				bytesConsumed += bytesToCopy;
			}


			//m_receivePool.ReturnArgs(e);
			QueueReceive();
		}

		/// <summary>
		/// Deserializes a packet from the given buffer. Returns the amount of bytes consumed.
		/// </summary>
		protected int DeserializePacket(IntPtr buffer) {
			var packetHeader = (PacketHeader)Marshal.PtrToStructure(buffer, typeof(PacketHeader));

			//Get the type for the packet sitting in the receive buffer
			var packetType = PacketMap.GetTypeForPacketCode(packetHeader.OpCode);

			//If we can deserialize it...
			if (packetType != null) {
				try {
					//Block copy the buffer to a struct of the correct type
					var packet = (IPacketBase)Marshal.PtrToStructure(buffer, packetType);

					//Throw the strongly-typed packet into the incoming queue
					mIncomingQueue.Enqueue(packet);

					return packet.Header.SizeInBytes;
				} catch (Exception ex) {
					Console.Write("Deserialization error! " + ex);
				}
			} else {
				Console.WriteLine("Bad packet code: " + packetHeader.OpCode);
			}

			return 0;
		}

		/// <summary>
		/// Queues a packet to be send on the next update. Will coalesce these packets together.
		/// </summary>
		public void DeferredSendPacket(IPacketBase packet) {
			if (!mCurrentDeferredPacket.TryAddPacket(packet)) {
				mDeferredSendList.Add(mCurrentDeferredPacket);
				mCurrentDeferredPacket = PacketFactory.CreatePacket<CoalescedData>();
				mCurrentDeferredPacket.TryAddPacket(packet);
			}
		}

		/// <summary>
		/// Enqueue a packet for sending over the wire
		/// </summary>
		public void SendPacket(IPacketBase packet) {
			mOutgoingQueue.Enqueue(packet);

			//If we're not already sending, queue up a send on the task pool
			if (Interlocked.Read(ref mSending) == 0) {
				QueueSend();
			}
		}

		/// <summary>
		/// Updates this entity, flushes and handles any pending packets in the incoming queue.
		/// </summary>
		public void Update(TimeSpan dt) {
			//Handle all packets in the incoming queue
			IPacketBase packet;
			while (mIncomingQueue.TryDequeue(out packet)) {
				HandlePacket(packet);
			}

			//Send any packets that have been deferred
			foreach (var p in mDeferredSendList) {
				SendPacket(p);
			}
			mDeferredSendList.Clear();

			if (mCurrentDeferredPacket.PacketCount > 0) {
				SendPacket(mCurrentDeferredPacket);
			}

			//Reset the current deferred packet for next update
			mCurrentDeferredPacket = PacketFactory.CreatePacket<CoalescedData>();

			//Warn if any of the queues are getting swamped
			if (mOutgoingQueue.Count > 25) {
				Console.WriteLine("Outgoing queue swamped: " + mOutgoingQueue.Count);
			}
			if (mIncomingQueue.Count > 25) {
				Console.WriteLine("Incoming queue swamped: " + mIncomingQueue.Count);
			}
		}

		/// <summary>
		/// Clean up this entity
		/// </summary>
		public virtual void Dispose() {
			mIoStopToken.Cancel();

			mSocket.Close();
			mSocket.Dispose();

			mWorkingPacketBufferHandle.Free();
		}

		/// <summary>
		/// Packet handler logic
		/// </summary>
		protected virtual void HandlePacket(IPacketBase packet) {
			//Send auth responses for an auth request
			if (packet is AuthRequest) {
				var response = PacketFactory.CreatePacket<AuthResponse>();
				//Tell them their world ID
				response.WorldID = WorldID;
				DeferredSendPacket(response);
				AuthState = EEntityAuthState.Authorised;
			}

			//Update auth state and world ID
			else if (packet is AuthResponse) {
				var response = (AuthResponse)packet;
				WorldID = response.WorldID;
				AuthState = EEntityAuthState.Authorised;
			}

			//Unpack coalesced packets
			else if (packet is CoalescedData) {
				var data = (CoalescedData)packet;

				unsafe {
					byte* ptr = data.DataBuffer;
					//Start deserializing packets from the buffer
					for (int i = 0; i < data.PacketCount; i++) {
						//Deserialize and advance pointer to next packet in the buffer
						ptr += DeserializePacket((IntPtr)ptr);
					}
				}
			}

			//Synchronise clocks
			else if (packet is ClockSyncResponse) {
				var response = (ClockSyncResponse)packet;
				var rtt = Environment.TickCount - mClockSyncSendTime;
				mRoundTripTimes.Enqueue(rtt);
				if (mRoundTripTimes.Count > 10) {
					mRoundTripTimes.Dequeue();
				}
				SyncClock(response.Time);
				mAwaitingClockSyncResponse = false;
			} else if (packet is ClockSyncRequest) {
				var response = PacketFactory.CreatePacket<ClockSyncResponse>();
				response.Time = Environment.TickCount;
				SendPacket(response);
			}
		}

		/// <summary>
		/// Send an authorisation request.
		/// </summary>
		public virtual void Authorise() {
			//Don't send multiple auths
			if (AuthState == EEntityAuthState.Unauthorised) {
				AuthState = EEntityAuthState.Authorising;
				DeferredSendPacket(PacketFactory.CreatePacket<AuthRequest>());
			}
		}

		/// <summary>
		/// Send a clock sync request, if there is not already one pending.
		/// </summary>
		public void SendClockSync() {
			if (mAwaitingClockSyncResponse) {
				return;
			}

			mClockSyncSendTime = Environment.TickCount;
			mAwaitingClockSyncResponse = true;
			SendPacket(PacketFactory.CreatePacket<ClockSyncRequest>());
		}

		/// <summary>
		/// Synchronises the network clock using any round trip time data available.
		/// </summary>
		protected void SyncClock(int remoteTime) {
			//Calculate the offset between the remote and local time
			mClockOffset = remoteTime - Environment.TickCount;

			//Calculate the average of any round-trip times we have
			var averageRtt = mRoundTripTimes.Sum() / mRoundTripTimes.Count;

			//Calculate the standard deviation of the RTTs
			var stddev = (int)Math.Sqrt(mRoundTripTimes.Select(n => (n - averageRtt) * (n - averageRtt)).Sum() / (float)mRoundTripTimes.Count);

			//Calculate the median RTT
			var median = mRoundTripTimes.OrderBy(i => i).ElementAt(mRoundTripTimes.Count / 2);

			//Remove any RTTs that are > 1 standard deviation away from the median and calculate the average again
			var unskewedAverage = mRoundTripTimes.Where(i => Math.Abs(i - median) < stddev).Sum() / mRoundTripTimes.Count;

			//Apply half of this average to the clock offset to account for latency
			mClockOffset += unskewedAverage / 2;
		}

	}

}
