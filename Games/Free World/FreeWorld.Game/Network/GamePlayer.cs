using System;
using System.Net;
using System.Net.Sockets;
using FreeWorld.Server.Shared;
using FreeWorld.Server.Shared.Packets;

namespace FreeWorld.Game.Network {

	public class GamePlayer : NetEntity {

		/// <summary>
		/// The last state received from this entity
		/// </summary>
		public EntityState LastState {
			get;
			private set;
		}

		/// <summary>
		/// The display name of this entity
		/// </summary>
		public string Name {
			get;
			private set;
		}

		public GamePlayer(Socket socket, int worldID, SocketAsyncEventArgs sendEventArgs, SocketAsyncEventArgs receiveEventArgs)
			: base(socket, worldID, sendEventArgs, receiveEventArgs) {
		}


		public static GamePlayer Create() {
			var sendArgs = new SocketAsyncEventArgs();
			var receiveArgs = new SocketAsyncEventArgs();
			var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			return new GamePlayer(socket, 1, sendArgs, receiveArgs);
		}


		public void BeginConnect() {
			mSocket.BeginConnect(new IPEndPoint(IPAddress.Any, 25189), OnSocketConnect, mSocket);
		}
		
		/// <exception cref="Exception"></exception>
		private void OnSocketConnect(IAsyncResult ar) {
			mSocket.EndConnect(ar);
			if (ar.IsCompleted == false) {
				throw new Exception("Failed to connect to host: " + mSocket.RemoteEndPoint);
			}

			// Start async receive
			Receive();
		}


		/// <summary>
		/// Incoming packets are pushed here for handling.
		/// </summary>
		protected unsafe override void HandlePacket(IPacketBase packet) {
			base.HandlePacket(packet);

			//Update state from the client
			if (packet is PushState) {
				var state = (PushState)packet;
				//Push their state if it's the correct world ID
				if (state.WorldID == WorldID) {
					LastState = state.State;
				}
			}

		}

	}

}