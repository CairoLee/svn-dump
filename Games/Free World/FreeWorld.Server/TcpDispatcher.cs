using System;
using System.Net;
using System.Net.Sockets;

namespace FreeWorld.Server {

	/// <summary>
	/// TCP Listener to accept people to the world
	/// </summary>
	public class TcpDispatcher {
		/// <summary>
		/// TCP listener
		/// </summary>
		private readonly TcpListener mListener;

		/// <summary>
		/// Handles user connections
		/// </summary>
		public event Action<Socket> SocketConnected;

		/// <summary>
		/// The current state of this dispatcher
		/// </summary>
		public EDispatcherState State {
			get;
			private set;
		}


		/// <summary>
		/// Create a tcp listener bound to the specified address and port
		/// </summary>
		public TcpDispatcher(IPAddress bindAddress, ushort port) {
			State = EDispatcherState.Stopped;
			mListener = new TcpListener(bindAddress, port);
		}

		/// <summary>
		/// Start listening for connections
		/// </summary>
		public void Start() {
			mListener.Start();
			BeginAcceptingSockets();
		}

		/// <summary>
		/// Handle a socket accept
		/// </summary>
		private void AcceptSocket(IAsyncResult result) {
			State = EDispatcherState.AcceptingSocket;
			var sock = mListener.EndAcceptSocket(result);

			//Queue the next accept
			BeginAcceptingSockets();

			//Fire the event handler for sockets
			if (SocketConnected != null) {
				SocketConnected(sock);
			} else {
				//boot the user if nobody is listening
				sock.Disconnect(false);
			}
		}

		/// <summary>
		/// Start an async socket accept
		/// </summary>
		private void BeginAcceptingSockets() {
			State = EDispatcherState.Listening;
			mListener.BeginAcceptSocket(AcceptSocket, null);
		}

		/// <summary>
		/// Stop listening for connections
		/// </summary>
		public void Stop() {
			mListener.Stop();
			State = EDispatcherState.Stopped;
		}

	}

}
