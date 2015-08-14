using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Collections;
using Rovolution.Server.Objects;
using Rovolution.Server.Network;
using GodLesZ.Library;
using Rovolution.Server.Diagnostics;

namespace Rovolution.Server.Network {

	public interface IPacketEncoder {
		void EncodeOutgoingPacket(NetState to, ref byte[] buffer, ref int length);
		void DecodeIncomingPacket(NetState from, ref byte[] buffer, ref int length);
	}

	public delegate void NetStateCreatedCallback(NetState ns);

	public class NetState {
		[Flags]
		public enum AsyncNetState {
			Pending = 0x01,
			Paused = 0x02
		}

		private static bool mPaused;
		private static NetStateCreatedCallback mCreatedCallback;
		private static Dictionary<int, NetState> mInstances = new Dictionary<int, NetState>();
		private static Queue mDisposed = Queue.Synchronized(new Queue());
		private static int mCoalesceSleep = -1;

		private const int mBufferSize = 4096;

		private Socket mSocket;
		private IPAddress mAddress;
		private ByteQueue mBuffer;
		private byte[] mRecvBuffer;
		private SendQueue mSendQueue;
		private bool mSeeded;
		private bool mRunning;
		private AsyncCallback mOnReceive, mOnSend;
		private SocketConnector mMessagePump;
		private Account mAccount;
		private int mSequence;
		private bool mSentFirstPacket;
		private bool mBlockAllPackets;

		private DateTime mConnectedOn;

		private int mFlags;

		private AsyncNetState mAsyncState;
		private object mAsyncLock = new object();
		private IPacketEncoder mEncoder = null;

		private DateTime mNextCheckActivity;
		private static TimeSpan mCheckInterval = TimeSpan.FromSeconds(1);
		private bool mDisposing;


		private static int mInstanceID = 1;
		private static object mNetstateInstancesLock = new object();
		public static Dictionary<int, NetState> Instances {
			get {
				lock (mNetstateInstancesLock) {
					return mInstances;
				}
			}
		}

		public static NetStateCreatedCallback CreatedCallback {
			get { return mCreatedCallback; }
			set { mCreatedCallback = value; }
		}

		public AsyncNetState AsyncState {
			get {
				lock (mAsyncLock)
					return mAsyncState;
			}
			set {
				lock (mAsyncLock)
					mAsyncState = value;
			}
		}

		public DateTime ConnectedOn {
			get { return mConnectedOn; }
		}

		public TimeSpan ConnectedFor {
			get { return (DateTime.Now - mConnectedOn); }
		}

		public IPAddress Address {
			get { return mAddress; }
		}

		public IPacketEncoder PacketEncoder {
			get { return mEncoder; }
			set { mEncoder = value; }
		}

		public bool SentFirstPacket {
			get { return mSentFirstPacket; }
			set { mSentFirstPacket = value; }
		}

		public bool BlockAllPackets {
			get { return mBlockAllPackets; }
			set { mBlockAllPackets = value; }
		}

		public int Flags {
			get { return mFlags; }
			set { mFlags = value; }
		}

		public int Sequence {
			get { return mSequence; }
			set { mSequence = value; }
		}

		public Account Account {
			get { return mAccount; }
			set { mAccount = value; }
		}

		public Character ActiveChar {
			get { return (mAccount != null ? mAccount.ActiveChar : null); }
		}

		public static int CoalesceSleep {
			get { return mCoalesceSleep; }
			set { mCoalesceSleep = value; }
		}

		public bool Running {
			get { return mRunning; }
		}

		public bool Seeded {
			get { return mSeeded; }
			set { mSeeded = value; }
		}

		public Socket Socket {
			get { return mSocket; }
		}

		public ByteQueue Buffer {
			get { return mBuffer; }
		}

		public int InstanceID {
			get;
			private set;
		}



		public NetState(Socket socket, SocketConnector messagePump) {
			mSocket = socket;
			mBuffer = new ByteQueue();
			mSeeded = false;
			mRunning = false;
			mRecvBuffer = new byte[mBufferSize];
			mMessagePump = messagePump;

			mSendQueue = new SendQueue();
			UpdateAcitivty();

			InstanceID = mInstanceID++;
			Instances.Add(InstanceID, this);

			try {
				mAddress = ((IPEndPoint)mSocket.RemoteEndPoint).Address;
			} catch (Exception ex) {
				ExceptionHandler.Trace(ex);
				mAddress = IPAddress.None;
			}

			mConnectedOn = DateTime.Now;

			if (mCreatedCallback != null)
				mCreatedCallback(this);
		}


		public void Start() {
			mOnReceive = new AsyncCallback(OnReceive);
			mOnSend = new AsyncCallback(OnSend);

			mRunning = true;

			if (mSocket == null || mPaused)
				return;

			try {
				if ((AsyncState & (AsyncNetState.Pending | AsyncNetState.Paused)) == 0)
					InternalBeginReceive();
			} catch (Exception ex) {
				ExceptionHandler.Trace(ex);
				Dispose(false);
			}
		}




		public static void Pause() {
			mPaused = true;

			foreach (NetState ns in mInstances.Values) {
				ns.AsyncState |= AsyncNetState.Paused;
			}
		}

		public static void Resume() {
			mPaused = false;

			foreach (NetState ns in mInstances.Values) {
				if (ns.mSocket == null)
					continue;

				ns.AsyncState &= ~AsyncNetState.Paused;
				try {
					if ((ns.AsyncState & AsyncNetState.Pending) == 0)
						ns.InternalBeginReceive();
				} catch (Exception ex) {
					ExceptionHandler.Trace(ex);
					ns.Dispose(false);
				}
			}
		}

		public static void FlushAll() {
			foreach (NetState ns in mInstances.Values) {
				ns.Flush();
			}
		}

		public static void Initialize() {
			Timer.DelayCall(mCheckInterval, mCheckInterval, new TimerCallback(CheckAllAlive));
		}

		public static void CheckAllAlive() {
			//ServerConsole.StatusLine("CheckAllAlive() for {0} Instances", mInstances.Count);
			try {
				foreach (NetState ns in mInstances.Values) {
					ns.CheckAlive();
				}
			} catch (Exception ex) {
				ExceptionHandler.Trace(ex);
			}
		}

		public static void ProcessDisposedQueue() {
			int breakout = 0;
			while (breakout < 200 && mDisposed.Count > 0) {
				++breakout;

				NetState ns = (NetState)mDisposed.Dequeue();
				if (ns != null) {

					ns.Account = null;
					Instances.Remove(ns.InstanceID);
					ns.Dispose(false);
				}
			}
		}

		public virtual void Send(Packet p) {
			if (mSocket == null || mBlockAllPackets) {
				ServerConsole.ErrorLine("{0}: Socket is null! Packet {1:X4} ({2} bytes) cant be send", this, p.PacketID, p.Length);
				// Wont send packet, but trigger OnSend to free data..
				p.OnSend(this);
				Dispose();
				return;
			}

			// Allow APIs to break sending
			if (p.OnBeforeSend(this) == false) {
				// Didnt send the packet, so let the APIs know that (2nd param, false)
				p.OnSend(this, false);
				return;
			}
			PacketSendProfile prof = PacketSendProfile.Acquire(p.GetType());

			int length = 0;
			byte[] buffer = p.Compile(out length);
			if (buffer == null) {
				ServerConsole.ErrorLine("{0}: null buffer send, disconnecting...", this);
				using (StreamWriter op = new StreamWriter("null_send.log", true)) {
					op.WriteLine("{0} Client", "{1}: null buffer send, disconnecting...", DateTime.Now, this);
					op.WriteLine(new System.Diagnostics.StackTrace());
				}
				Dispose();
				return;
			}

			if (buffer.Length <= 0 || length <= 0) {
				p.OnSend(this);
				return;
			}

			if (prof != null)
				prof.Start();

			if (mEncoder != null)
				mEncoder.EncodeOutgoingPacket(this, ref buffer, ref length);

			try {
				ServerConsole.DebugLine("{0}: sending Packet 0x{1:X4} ({2} bytes)", this, p.PacketID, length);
				mSocket.BeginSend(buffer, 0, length, SocketFlags.None, mOnSend, mSocket);
			} catch (Exception ex) {
				ExceptionHandler.Trace(ex);
				Dispose(false);
			}

			p.OnSend(this);

			if (prof != null)
				prof.Finish(length);
		}

		public bool Flush() {
			if (mSocket == null || !mSendQueue.IsFlushReady)
				return false;

			SendQueue.PendingData gram;
			lock (mSendQueue) {
				gram = mSendQueue.CheckFlushReady();
			}

			if (gram != null) {
				try {
					mSocket.BeginSend(gram.Buffer, 0, gram.Length, SocketFlags.None, mOnSend, mSocket);
					return true;
				} catch (Exception ex) {
					ExceptionHandler.Trace(ex);
					Dispose(false);
				}
			}

			return false;
		}

		public bool CheckAlive() {
			if (mSocket == null)
				return false;

			// TODO any effective keep-alive thing?
			Flush();
			return true;
		}



		private void InternalBeginReceive() {
			AsyncState |= AsyncNetState.Pending;
			if (mSocket != null)
				mSocket.BeginReceive(mRecvBuffer, 0, mRecvBuffer.Length, SocketFlags.None, mOnReceive, mSocket);
		}

		private void OnSend(IAsyncResult asyncResult) {
			Socket s = (Socket)asyncResult.AsyncState;
			if (s == null || s.Connected == false) {
				ServerConsole.DebugLine("socket null or connection closed");
				Dispose();
				return;
			}

			try {
				int bytes = s.EndSend(asyncResult);
				if (bytes <= 0) {
					Dispose(false);
					return;
				}

				UpdateAcitivty();

				if (mCoalesceSleep > 0)
					Thread.Sleep(mCoalesceSleep);
			} catch (Exception ex) {
				ExceptionHandler.Trace(ex);
				Dispose(false);
			}
		}

		private void OnReceive(IAsyncResult asyncResult) {
			Socket s = (Socket)asyncResult.AsyncState;

			try {
				int byteCount = s.EndReceive(asyncResult);
				if (byteCount > 0) {
					UpdateAcitivty();

					byte[] buffer = mRecvBuffer;
					if (mEncoder != null)
						mEncoder.DecodeIncomingPacket(this, ref buffer, ref byteCount);

					lock (mBuffer) {
						mBuffer.Enqueue(buffer, 0, byteCount);
					}

					//mMessagePump.OnReceive(this);
					lock (mMessagePump) {
						//Core.Set();
						mMessagePump.HandleReceive(this);
					}

					lock (mAsyncLock) {
						mAsyncState &= ~AsyncNetState.Pending;

						if ((mAsyncState & AsyncNetState.Paused) == 0) {
							try {
								InternalBeginReceive();
							} catch (Exception ex) {
								ExceptionHandler.Trace(ex);
								Dispose(false);
							}
						}
					}
				} else {
					Dispose(false);
				}
			} catch (Exception ex) {
				ServerConsole.ErrorLine(ex.Message);
				ServerConsole.ErrorLine(ex.StackTrace);
				//ServerConsole.ErrorLine(Tools.CleanExcepionStacktrace(ex.StackTrace));
				Dispose(false);
			}
		}

		public void Disconnect() {
			Dispose(true);
		}


		public void Dispose() {
			Dispose(true);
		}

		public virtual void Dispose(bool flush) {
			if (mDisposing)
				return;

			ServerConsole.StatusLine("{0}: Disconnected.", this);
			mDisposing = true;

			//##PACKET## Logout
			Thread.Sleep(100);

			if (flush) {
				flush = Flush();
			}

			// Check for existing objects in the World
			// FIXME - Account cant be removed
			// We need to check using World.GetAccount() after a new connection
			// from login -> char or char -> world
			// ...
			//if (Account != null) {
			//	World.RemoveObject(Account);
			//}

			if (mSocket != null) {
				try {
					mSocket.Shutdown(SocketShutdown.Both);
				} catch (SocketException ex) {
					ExceptionHandler.Trace(ex);
				}

				try {
					mSocket.Close();
					SocketPool.ReleaseSocket(mSocket);
				} catch (SocketException ex) {
					ExceptionHandler.Trace(ex);
				}
				mSocket = null;
			}

			mBuffer = null;
			mRecvBuffer = null;
			mOnReceive = null;
			mOnSend = null;
			mRunning = false;

			mDisposed.Enqueue(this);

			if (!mSendQueue.IsEmpty) {
				lock (mSendQueue) {
					mSendQueue.Clear();
				}
			}
		}



		public void UpdateAcitivty() {
			UpdateAcitivty(true);
		}

		public void UpdateAcitivty(bool UpdatePing) {
			mNextCheckActivity = DateTime.Now + mCheckInterval;
			// TODO: client want a ping from server?
		}

		public bool IsActive() {
			return (DateTime.Now >= mNextCheckActivity);
		}


		public bool IsValid(EAccountState state) {
			// General check
			if (Account != null && Account.AccountState != state) {
				return false;
			}

			// Login checks
			if (state == EAccountState.Login) {
			}
			// Char checks
			if (state == EAccountState.Char) {
			}
			// World checks
			if (state == EAccountState.World) {
				if (Account == null) {
					return false;
				}
				if (Account.ActiveChar == null) {
					return false;
				}
				return true;
			}

			return true;
		}


		public override string ToString() {
			string ip = mAddress.ToString();
			string ret = "";

			if (ActiveChar != null) {
				ret = string.Format("[{0} :: {1} ({2}/{3})]", ip, ActiveChar.Status.Name, ActiveChar.Status.LevelBase, ActiveChar.Status.LevelJob);
			} else if (Account != null) {
				ret = string.Format("[{0} :: {1}]", ip, Account.Name);
			} else {
				ret = string.Format("[{0}]", ip);
			}

			return ret;
		}

	}

}
