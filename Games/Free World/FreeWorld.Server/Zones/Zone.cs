using System.Collections.Generic;
using FreeWorld.Server.Shared;
using FreeWorld.Server.Shared.Packets;

namespace FreeWorld.Server.Zones {

	/// <summary>
	/// Represents one zone in the world
	/// </summary>
	public class Zone {
		/// <summary>
		/// Index of entities in this zone
		/// </summary>
		private readonly Dictionary<int, ServerEntity> mEntities;

		/// <summary>
		/// The ID of this zone.
		/// </summary>
		public int ID {
			get;
			private set;
		}


		/// <summary>
		/// Create a new zone
		/// </summary>
		public Zone(int id) {
			ID = id;
			mEntities = new Dictionary<int, ServerEntity>();
		}


		/// <summary>
		/// Add an entity to this zone
		/// </summary>
		public void AddEntity(ServerEntity entity) {
			mEntities.Add(entity.WorldID, entity);
		}

		/// <summary>
		/// Remove an entity from this zone
		/// </summary>
		public void RemoveEntity(ServerEntity entity) {
			if (mEntities.ContainsKey(entity.WorldID)) {
				mEntities.Remove(entity.WorldID);
			}
		}

		/// <summary>
		/// Sends states of nearby enemies to each other
		/// </summary>
		public void PushNearbyEntities(ServerEntity entity) {
			const int minSqrDistance = 768 * 768;

			foreach (var e in mEntities.Values) {
				if (e.AuthState != EEntityAuthState.Authorised || e.WorldID == entity.WorldID) {
					//Skip unauthorised entities and don't send to self
					continue;
				}

				float xDiff = entity.LastState.X - e.LastState.X;
				float yDiff = entity.LastState.Y - e.LastState.Y;

				var sqrdistance = (xDiff * xDiff) + (yDiff * yDiff);

				if (sqrdistance > minSqrDistance) {
					continue;
				}

				//Add a push state into the coalesced data packet for this entity
				var state = PacketFactory.CreatePacket<PushState>();
				state.WorldID = e.WorldID;
				state.State = e.LastState;

				entity.DeferredSendPacket(state);
			}
		}

	}

}
