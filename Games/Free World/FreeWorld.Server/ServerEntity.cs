using System.Globalization;
using System.Net.Sockets;
using FreeWorld.Server.Shared;
using FreeWorld.Server.Shared.Packets;

namespace FreeWorld.Server {

	/// <summary>
	/// Represents a player connected to the server.
	/// </summary>
	public class ServerEntity : NetEntity {
		private readonly SocketAsyncPool mAsyncPool;

		/// <summary>
		/// Reference to the world
		/// </summary>
		private readonly World mWorld;

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


		public ServerEntity(Socket socket, int worldID, World world, SocketAsyncPool asyncPool)
			: base(socket, worldID, asyncPool.GetArgs(), asyncPool.GetArgs()) {
			mAsyncPool = asyncPool;
			Name = worldID.ToString(CultureInfo.InvariantCulture);
			mWorld = world;
		}

		public override void Dispose() {
			base.Dispose();

			mAsyncPool.ReturnArgs(mReceiveArgs);
			mAsyncPool.ReturnArgs(mSendArgs);
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

			//Move the user in to a new zone
			else if (packet is RequestZoneTransfer) {
				var request = (RequestZoneTransfer)packet;

				mWorld.ZoneManager.RequestZoneTransfer(this, request.ZoneID);
			}

			//Resolve names
			else if (packet is WhoisRequest) {
				var request = (WhoisRequest)packet;
				var response = PacketFactory.CreatePacket<WhoisResponse>();
				response.WorldID = request.WorldID;
				var name = mWorld.GetNameForWorldID(request.WorldID);
				TextHelpers.StringToBuffer(name, response.Name, name.Length);
				DeferredSendPacket(response);
			}
		}
	}
}
