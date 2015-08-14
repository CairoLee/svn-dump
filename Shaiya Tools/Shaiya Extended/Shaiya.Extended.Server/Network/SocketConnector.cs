using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using Shaiya.Extended.Library.Network;
using Shaiya.Extended.Library.Utility;
using System.IO;
using Shaiya.Extended.Server.Network.Packets;


namespace Shaiya.Extended.Server.Network {

	public class SocketConnector {
		private SocketListener mListener;
		private Queue<NetState> mQueue;
		private Queue<NetState> mWorkingQueue;
		private Queue<NetState> mThrottled;
		private byte[] mPeek;

		private string mIP;
		private int mPort;

		public string IP {
			get { return mIP; }
		}
		public int Port {
			get { return mPort; }
		}
		public SocketListener Listener {
			get { return mListener; }
			set { mListener = value; }
		}


		public SocketConnector( string IP, int Port ) {
			mIP = IP;
			mPort = Port;
			IPHostEntry iphe = null;
			try {
				iphe = Dns.GetHostEntry( mIP );
				if( iphe == null || iphe.AddressList.Length < 1 )
					throw new Exception( "Unable to fetch IP Address from: " + mIP + "::" + mPort );
			} catch( Exception e ) {
				throw e;
			}

			IPEndPoint EndPoint = new IPEndPoint( iphe.AddressList[ 0 ], mPort );

			bool bSuccess = false;
			do {
				SocketListener Listener = new SocketListener( EndPoint, this );
				if( bSuccess == false && Listener != null )
					bSuccess = true;
				mListener = Listener;

				if( bSuccess == false ) {
					CConsole.ErrorLine( "Unable to Connect - retrying in 10sec..." );
					Thread.Sleep( 10000 );
				}
			} while( bSuccess == false );

			mQueue = new Queue<NetState>();
			mWorkingQueue = new Queue<NetState>();
			mThrottled = new Queue<NetState>();
			mPeek = new byte[ 4 ];
		}

		private void CheckListener() {
			Socket[] accepted = mListener.Slice();

			for( int i = 0; i < accepted.Length; ++i ) {
				NetState ns = new NetState( accepted[ i ], this );
				ns.Start();

				if( ns.Running ) {
					CConsole.StatusLine( "{0}: Connected. [{1} Online]", ns, NetState.Instances.Count );
					ns.Send( new Packet0xA101( ns ) );
				}
			}
		}

		public void OnReceive( NetState ns ) {
			lock( this )
				mQueue.Enqueue( ns );

			Core.Set();
		}

		public void Slice() {
			CheckListener();

			lock( this ) {
				Queue<NetState> temp = mWorkingQueue;
				mWorkingQueue = mQueue;
				mQueue = temp;
			}

			while( mWorkingQueue.Count > 0 ) {
				NetState ns = mWorkingQueue.Dequeue();

				if( ns.Running )
					HandleReceive( ns );
			}

			lock( this ) {
				while( mThrottled.Count > 0 )
					mQueue.Enqueue( mThrottled.Dequeue() );
			}
		}

		private const int mBufferSize = 4096;
		private BufferPool mBuffers = new BufferPool( "Processor", 4, mBufferSize );

		public bool HandleReceive( NetState ns ) {
			ByteQueue buffer = ns.Buffer;

			if( buffer == null || buffer.Length <= 0 )
				return true;

			CConsole.DebugLine( "{0}: Incoming Data - {1} Bytes", ns, buffer.Length );

			/*
			 * Packet Analyse/verify && Parsing
			 */

			lock( buffer ) {
				int length = buffer.Length;
				// debug Data
				while( length > 0 && ns.Running ) {
					short packetID = buffer.GetPacketID();
					
					// debug log
					using( TextWriter writer = File.CreateText( AppDomain.CurrentDomain.BaseDirectory + @"\packet_" + DateTime.Now.UnixTimestamp() + ".log" ) ) {
						using( MemoryStream ms = new MemoryStream( buffer.ByteBuffer ) )
							Tools.FormatBuffer( writer, ms, (int)ms.Length );
					}

					CConsole.DebugLine( "{0}: packetID {1}, {2} bytes", ns, packetID, length );

					PacketHandler handler = PacketHandlers.GetHandler( packetID );
					if( handler == null ) {
						byte[] data = new byte[ length ];
						length = buffer.Dequeue( data, 0, length );

						CConsole.ErrorLine( "{0}: no Handler found! Data dispose", ns );
						break;
					}
					
					CConsole.StatusLine(  "{0}: Handler found ({1} bytes)! Trigger Callback...", ns, handler.Length );

					byte[] packetBuffer;
					if( mBufferSize >= handler.Length )
						packetBuffer = mBuffers.AcquireBuffer();
					else
						packetBuffer = new byte[ handler.Length ];

					buffer.Dequeue( packetBuffer, 0, handler.Length );

					PacketReader r = new PacketReader( packetBuffer, handler.Length, 0 );
					handler.OnReceive( ns, r );
					length = buffer.Length;

					if( mBufferSize >= handler.Length )
						mBuffers.ReleaseBuffer( packetBuffer );


				} // end while()*/

			} // end Lock()

			return true;
		}
	}


}
