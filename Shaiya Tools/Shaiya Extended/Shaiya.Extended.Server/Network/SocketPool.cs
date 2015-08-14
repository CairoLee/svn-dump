using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Shaiya.Extended.Library.Utility;

namespace Shaiya.Extended.Server.Network {

	public class SocketPool {
		private static bool mCreated = false;
		private static int mMisses = 0;
		private static int mInitialCapacity = 32;
		private static Queue<Socket> mFreeSockets;

		public static bool Created {
			get { return mCreated; }
		}

		public static int InitialCapacity {
			get { return mInitialCapacity; }
			set {
				if( mCreated )
					return;
				mInitialCapacity = value;
			}
		}


		public static void Create() {
			if( mCreated )
				return;

			CConsole.StatusLine( "Creating {0} Sockets...", mInitialCapacity );

			mFreeSockets = new Queue<Socket>( mInitialCapacity );
			for( int i = 0; i < mInitialCapacity; ++i )
				mFreeSockets.Enqueue( new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp ) );

			mCreated = true;
		}

		public static void Destroy() {
			if( mCreated == false || mFreeSockets == null )
				return;

			CConsole.StatusLine( "Closing {0} Sockets...", mFreeSockets.Count );

			while( mFreeSockets.Count > 0 )
				mFreeSockets.Dequeue().Close();

			mFreeSockets = null;
		}

		public static Socket AcquireSocket() {
			lock( mFreeSockets ) {
				if( mFreeSockets.Count > 0 )
					return mFreeSockets.Dequeue();

				++mMisses;

				for( int i = 0; i < mInitialCapacity; ++i )
					mFreeSockets.Enqueue( new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp ) );

				return mFreeSockets.Dequeue();
			}
		}

		public static void ReleaseSocket( Socket s ) {
			if( s == null )
				return;

		}


	}


}
