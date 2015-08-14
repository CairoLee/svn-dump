using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Shaiya.Extended.Server.Objects;

namespace Shaiya.Extended.Server {
	public delegate void CrashedEventHandler( CrashedEventArgs e );
	public delegate void ShutdownEventHandler( ShutdownEventArgs e );
	public delegate void SocketConnectEventHandler( SocketConnectEventArgs e );
	public delegate void ServerStartedEventHandler();
	public delegate void WorldLoadStartEventHandler();
	public delegate void WorldLoadFinishEventHandler();
	public delegate void PlayerUseItemEventHandler( PLayerUseItemEventArgs e );




	public class SocketConnectEventArgs : EventArgs {
		private Socket mSocket;
		private bool mAllowConnection;

		public Socket Socket {
			get { return mSocket; }
		}
		public bool AllowConnection {
			get { return mAllowConnection; }
			set { mAllowConnection = value; }
		}

		public SocketConnectEventArgs( Socket s ) {
			mSocket = s;
			mAllowConnection = true;
		}
	}

	public class ShutdownEventArgs : EventArgs {
		public ShutdownEventArgs() {
		}
	}

	public class CrashedEventArgs : EventArgs {
		private Exception mException;
		private bool mClose;

		public Exception Exception {
			get { return mException; }
		}
		public bool Close {
			get { return mClose; }
			set { mClose = value; }
		}

		public CrashedEventArgs( Exception e ) {
			mException = e;
		}
	}

	public class PLayerUseItemEventArgs : EventArgs {
		private BaseItem mBaseItem;

		public BaseItem Item {
			get { return mBaseItem; }
		}

		public PLayerUseItemEventArgs( BaseItem Item ) {
			mBaseItem = Item;
		}
	}





	public class Events {
		public static event CrashedEventHandler Crashed;
		public static event ShutdownEventHandler Shutdown;
		public static event SocketConnectEventHandler SocketConnect;
		public static event ServerStartedEventHandler ServerStarted;
		public static event WorldLoadStartEventHandler WorldLoadStart;
		public static event WorldLoadFinishEventHandler WorldLoadFinish;
		public static event PlayerUseItemEventHandler PlayerUseItem;


		public static void InvokeServerStarted() {
			if( ServerStarted != null )
				ServerStarted();
		}


		public static void InvokeSocketConnect( SocketConnectEventArgs e ) {
			if( SocketConnect != null )
				SocketConnect( e );
		}


		public static void InvokeShutdown( ShutdownEventArgs e ) {
			if( Shutdown != null )
				Shutdown( e );
		}

		public static void InvokeCrashed( CrashedEventArgs e ) {
			if( Crashed != null )
				Crashed( e );
		}


		public static void InvokeWorldLoadStart() {
			if( WorldLoadStart != null )
				WorldLoadStart();
		}

		public static void InvokeWorldLoadFinish() {
			if( WorldLoadFinish != null )
				WorldLoadFinish();
		}

		public static void InvokePlayerUseItem( PLayerUseItemEventArgs e ) {
			if( PlayerUseItem != null )
				PlayerUseItem( e );
		}


		public static void Reset() {
			Crashed = null;
			Shutdown = null;
			SocketConnect = null;
			WorldLoadFinish = null;
			PlayerUseItem = null;
		}


	}

}
