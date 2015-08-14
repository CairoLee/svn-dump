using System.Collections.Generic;

namespace FreeWorld.Server.Zones {
	/// <summary>
	/// Handles the indexing and updating of all zones in the world.
	/// </summary>
	public class ZoneManager {
		/// <summary>
		/// List of all zones
		/// </summary>
		private readonly Dictionary<int, Zone> mZones;

		/// <summary>
		/// Index of what zones all entities are in
		/// </summary>
		private readonly Dictionary<ServerEntity, Zone> mUserZones;


		/// <summary>
		/// Create a new zone manager
		/// </summary>
		public ZoneManager() {
			mZones = new Dictionary<int, Zone>();

			for (var i = 0; i < 10; i++) {
				mZones.Add(i, new Zone(i));
			}

			mUserZones = new Dictionary<ServerEntity, Zone>();
		}


		/// <summary>
		/// Tells all zones to push states to entities that are near to each other.
		/// </summary>
		public void PushNearbyEntities(ServerEntity entity) {
			Zone zone;
			mUserZones.TryGetValue(entity, out zone);
			if (zone != null) {
				zone.PushNearbyEntities(entity);
			}
		}

		/// <summary>
		/// Remove an entity from the zone that they are in
		/// </summary>
		public void RemoveEntity(ServerEntity entity) {
			Zone zone;
			mUserZones.TryGetValue(entity, out zone);
			if (zone != null) {
				zone.RemoveEntity(entity);
			}
		}

		/// <summary>
		/// Tries to move a user in to a new zone.
		/// </summary>
		public bool RequestZoneTransfer(ServerEntity entity, int newZoneID) {
			//Check the zone exists
			if (mZones.ContainsKey(newZoneID)) {
				var newZone = mZones[newZoneID];

				//See if the user is already in a zone
				if (mUserZones.ContainsKey(entity)) {
					//Remove them from their current zone
					var currentZone = mUserZones[entity];
					currentZone.RemoveEntity(entity);
				} else {
					//Add them to the zone index
					mUserZones.Add(entity, newZone);
				}

				//Move them in to their new zone
				mUserZones[entity] = newZone;
				newZone.AddEntity(entity);

				return true;
			}

			return false;
		}

	}

}
