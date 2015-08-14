using System;
using System.Net.Sockets;
using GodLesZ.Library.Network;
using GodLesZ.Library.Network.Packets;

namespace GodLesZ.Games.Ragnarok.RoBot.Library {

	public class Client {
		protected static BufferPool mBuffers = new BufferPool("client_pool", 100, 1024);

		protected byte[] mReceiveBuffer;

		public TcpClient Connection {
			get;
			protected set;
		}

		public bool IsConnected {
			get { return (Connection != null && Connection.Connected); }
		}


		public Client(string host, int port) {
			Connection.BeginConnect(host, port, ConnectionRequestCallback, Connection);
		}


		#region Async callbacks

		private void ConnectionRequestCallback(IAsyncResult ar) {
			if (ar.IsCompleted == false) {
				return;
			}
			Connection.EndConnect(ar);

			if (Connection.Connected == false) {
				Connection = null;
				return;
			}

			mReceiveBuffer = mBuffers.AcquireBuffer();
			Connection.Client.BeginReceive(mReceiveBuffer, 0, mReceiveBuffer.Length, SocketFlags.None, OnReceiveCallback, Connection);
		}

		private void OnReceiveCallback(IAsyncResult ar) {
			if (ar.IsCompleted == false) {
				return;
			}

			HandleReceiveData();
		}

		#endregion


		private void HandleReceiveData() {
			var reader = new PacketReader(mReceiveBuffer, mReceiveBuffer.Length, 0);

		}

	}

}