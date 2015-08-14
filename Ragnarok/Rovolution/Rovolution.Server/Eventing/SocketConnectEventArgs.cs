using System;
using System.Net.Sockets;

namespace Rovolution.Server {

	public class SocketConnectEventArgs : EventArgs {
		private readonly Socket mSocket;

		public Socket Socket {
			get { return mSocket; }
		}

		public bool AllowConnection {
			get;
			set;
		}

		public SocketConnectEventArgs(Socket s) {
			mSocket = s;
			AllowConnection = true;
		}
	}

}
