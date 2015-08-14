using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Collections;
using Shaiya.Extended.Server.Objects;
using Shaiya.Extended.Server.Network.Packets;
using Shaiya.Extended.Library.Utility;
using Shaiya.Extended.Library.Network;

namespace Shaiya.Extended.Server.Network {

	public interface IPacketEncoder {
		void EncodeOutgoingPacket( NetState to, ref byte[] buffer, ref int length );
		void DecodeIncomingPacket( NetState from, ref byte[] buffer, ref int length );
	}

	public delegate void NetStateCreatedCallback( NetState ns );

	public class NetState {
		[Flags]
		public enum AsyncNetState {
			Pending = 0x01,
			Paused = 0x02
		}

		private static bool mPaused;
		private static NetStateCreatedCallback mCreatedCallback;
		private static List<NetState> mInstances = new List<NetState>();
		private static Queue mDisposed = Queue.Synchronized( new Queue() );
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
		private string mToString;
		private bool mSentFirstPacket;
		private bool mBlockAllPackets;

		private DateTime mConnectedOn;

		private int mFlags;

		private AsyncNetState mAsyncState;
		private object mAsyncLock = new object();
		private IPacketEncoder mEncoder = null;

		private DateTime mNextCheckActivity;
		private static TimeSpan mCheckInterval = TimeSpan.FromSeconds( 20 );
		private bool mHasPing;
		private bool mDisposing;


		public static List<NetState> Instances {
			get { return mInstances; }
		}

		public static NetStateCreatedCallback CreatedCallback {
			get { return mCreatedCallback; }
			set { mCreatedCallback = value; }
		}

		public AsyncNetState AsyncState {
			get {
				lock( mAsyncLock )
					return mAsyncState;
			}
			set {
				lock( mAsyncLock )
					mAsyncState = value;
			}
		}

		public DateTime ConnectedOn {
			get { return mConnectedOn; }
		}

		public TimeSpan ConnectedFor {
			get { return ( DateTime.Now - mConnectedOn ); }
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



		public NetState( Socket socket, SocketConnector messagePump ) {
			mSocket = socket;
			mBuffer = new ByteQueue();
			mSeeded = false;
			mRunning = false;
			mRecvBuffer = new byte[ mBufferSize ];
			mMessagePump = messagePump;

			mSendQueue = new SendQueue();
			UpdateAcitivty();

			mInstances.Add( this );

			try {
				mAddress = IP.Intern( ( (IPEndPoint)mSocket.RemoteEndPoint ).Address );
				mToString = mAddress.ToString();
			} catch( Exception ex ) {
				ExceptionHandler.Trace( ex );
				mAddress = IPAddress.None;
				mToString = "(error)";
			}

			mConnectedOn = DateTime.Now;

			if( mCreatedCallback != null )
				mCreatedCallback( this );
		}


		public void Start() {
			mOnReceive = new AsyncCallback( OnReceive );
			mOnSend = new AsyncCallback( OnSend );

			mRunning = true;

			if( mSocket == null || mPaused )
				return;

			try {
				if( ( AsyncState & ( AsyncNetState.Pending | AsyncNetState.Paused ) ) == 0 )
					InternalBeginReceive();
			} catch( Exception ex ) {
				ExceptionHandler.Trace( ex );
				Dispose( false );
			}
		}




		public static void Pause() {
			mPaused = true;

			for( int i = 0; i < mInstances.Count; ++i ) {
				NetState ns = mInstances[ i ];
				ns.AsyncState |= AsyncNetState.Paused;
			}
		}

		public static void Resume() {
			mPaused = false;

			for( int i = 0; i < mInstances.Count; ++i ) {
				NetState ns = mInstances[ i ];

				if( ns.mSocket == null )
					continue;

				ns.AsyncState &= ~AsyncNetState.Paused;
				try {
					if( ( ns.AsyncState & AsyncNetState.Pending ) == 0 )
						ns.InternalBeginReceive();
				} catch( Exception ex ) {
					ExceptionHandler.Trace( ex );
					ns.Dispose( false );
				}
			}
		}

		public static void FlushAll() {
			for( int i = 0; i < mInstances.Count; ++i ) {
				NetState ns = mInstances[ i ];
				ns.Flush();
			}
		}

		public static void Initialize() {
			Timer.DelayCall( mCheckInterval, mCheckInterval, new TimerCallback( CheckAllAlive ) );
		}

		public static void CheckAllAlive() {
			CConsole.StatusLine( "CheckAllAlive() for {0} Instances", mInstances.Count );
			try {
				for( int i = 0; i < mInstances.Count; i++ )
					mInstances[ i ].CheckAlive();

			} catch( Exception ex ) {
				ExceptionHandler.Trace( ex );
			}
		}

		public static void ProcessDisposedQueue() {
			int breakout = 0;
			while( breakout < 200 && mDisposed.Count > 0 ) {
				++breakout;

				NetState ns = (NetState)mDisposed.Dequeue();

				ns.mAccount = null;
				mInstances.Remove( ns );

				CConsole.ErrorLine( "{0}: Disconnected. [{1} Online]", ns, mInstances.Count );
			}
		}

		public virtual void Send( Packet p ) {
			if( mSocket == null || mBlockAllPackets ) {
				p.OnSend();
				return;
			}

			PacketSendProfile prof = PacketSendProfile.Acquire( p.GetType() );

			int length = 0;
			byte[] buffer = p.Compile( out length );
			if( buffer == null ) {
				CConsole.ErrorLine( "{0}: null buffer send, disconnecting...", this );
				using( StreamWriter op = new StreamWriter( "null_send.log", true ) ) {
					op.WriteLine( "{0} Client", "{1}: null buffer send, disconnecting...", DateTime.Now, this );
					op.WriteLine( new System.Diagnostics.StackTrace() );
				}
				Dispose();
				return;
			}

			if( buffer.Length <= 0 || length <= 0 ) {
				p.OnSend();
				return;
			}

			if( prof != null )
				prof.Start();

			if( mEncoder != null )
				mEncoder.EncodeOutgoingPacket( this, ref buffer, ref length );

			try {
				Int16 pID = BitConverter.ToInt16( buffer, 0 );
				CConsole.DebugLine( "{0}: sending Packet 0x{1:X4}", this, pID );
				mSocket.BeginSend( buffer, 0, length, SocketFlags.None, mOnSend, mSocket );
			} catch( Exception ex ) {
				ExceptionHandler.Trace( ex );
				Dispose( false );
			}

			p.OnSend();

			if( prof != null )
				prof.Finish( length );

		}

		public bool Flush() {
			if( mSocket == null || !mSendQueue.IsFlushReady )
				return false;

			SendQueue.PendingData gram;
			lock( mSendQueue ) {
				gram = mSendQueue.CheckFlushReady();
			}

			if( gram != null ) {
				try {
					mSocket.BeginSend( gram.Buffer, 0, gram.Length, SocketFlags.None, mOnSend, mSocket );
					return true;
				} catch( Exception ex ) {
					ExceptionHandler.Trace( ex );
					Dispose( false );
				}
			}

			return false;
		}

		public bool CheckAlive() {
			if( mSocket == null )
				return false;

			if( IsActive() == true ) {
				Flush();
				return true;
			}

			CConsole.InfoLine( "{0} = Disconnecting due to inactivity...", this );

			Dispose();
			return false;
		}



		private void InternalBeginReceive() {
			AsyncState |= AsyncNetState.Pending;
			if( mSocket != null )
				mSocket.BeginReceive( mRecvBuffer, 0, mRecvBuffer.Length, SocketFlags.None, mOnReceive, mSocket );
		}

		private void OnSend( IAsyncResult asyncResult ) {
			Socket s = (Socket)asyncResult.AsyncState;

			try {
				int bytes = s.EndSend( asyncResult );

				if( bytes <= 0 ) {
					Dispose( false );
					return;
				}

				UpdateAcitivty();

				if( mCoalesceSleep >= 0 )
					Thread.Sleep( mCoalesceSleep );
			} catch( Exception ex ) {
				ExceptionHandler.Trace( ex );
				Dispose( false );
			}
		}

		private void OnReceive( IAsyncResult asyncResult ) {
			Socket s = (Socket)asyncResult.AsyncState;

			try {
				int byteCount = s.EndReceive( asyncResult );
				if( byteCount > 0 ) {
					UpdateAcitivty();

					byte[] buffer = mRecvBuffer;
					if( mEncoder != null )
						mEncoder.DecodeIncomingPacket( this, ref buffer, ref byteCount );

					lock( mBuffer )
						mBuffer.Enqueue( buffer, 0, byteCount );

					mMessagePump.OnReceive( this );

					lock( mAsyncLock ) {
						mAsyncState &= ~AsyncNetState.Pending;

						if( ( mAsyncState & AsyncNetState.Paused ) == 0 ) {
							try {
								InternalBeginReceive();
							} catch( Exception ex ) {
								ExceptionHandler.Trace( ex );
								Dispose( false );
							}
						}
					}
				} else {
					Dispose( false );
				}
			} catch {
				Dispose( false );
			}
		}

		public void Dispose() {
			Dispose( true );
		}


		public virtual void Dispose( bool flush ) {
			if( mSocket == null || mDisposing ) 
				return;

			mDisposing = true;

			//##PACKET## Logout
			Thread.Sleep( 100 );

			if( flush )
				flush = Flush();

			try {
				mSocket.Shutdown( SocketShutdown.Both );
			} catch( SocketException ex ) {
				ExceptionHandler.Trace( ex );
			}

			try {
				mSocket.Close();
				SocketPool.ReleaseSocket( mSocket );
			} catch( SocketException ex ) {
				ExceptionHandler.Trace( ex );
			}

			mSocket = null;

			mBuffer = null;
			mRecvBuffer = null;
			mOnReceive = null;
			mOnSend = null;
			mRunning = false;

			mDisposed.Enqueue( this );

			if( !mSendQueue.IsEmpty ) 
				lock( mSendQueue )
					mSendQueue.Clear();

		}




		public override string ToString() {
			string ret = String.Format( "[{0}]", mToString );
			if( this.Account != null )
				ret = String.Format( "[{0} :: {1}]", this.Account.Name, mToString );

			return ret;
		}

		public PacketHandler GetHandler( short packetID ) {
			return PacketHandlers.GetHandler( packetID );
		}



		public void UpdateAcitivty() {
			UpdateAcitivty( true );
		}

		public void UpdateAcitivty( bool UpdatePing ) {
			mNextCheckActivity = DateTime.Now + mCheckInterval;
			if( UpdatePing == true )
				mHasPing = false;
		}

		public bool IsActive() {
			if( DateTime.Now >= mNextCheckActivity )
				return true;

			// ever pinged?
			if( mHasPing == false ) {
				mHasPing = true;
				//##PACKET## PingPong?

				// update last time without Ping update
				UpdateAcitivty( false );
				return true;
			}

			return false;
		}

	}

}
