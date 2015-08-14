using System.Collections.Generic;
using GodLesZ.Games.Ragnarok.RoBot.Library.Objects.Enumerations;

namespace GodLesZ.Games.Ragnarok.RoBot.Library.Objects {

	/// <summary>
	/// Manages all objects in the world (spawned!)
	/// <para>
	/// Note: Holds a ref of each object.
	/// To store a object outside of this class, just ref the WorldID object.
	/// </para>
	/// </summary>
	public class WorldObjectManager : Dictionary<uint, WorldObject> {

		public Dictionary<uint, WorldObject> Account {
			get { return this; }
		}

		public Dictionary<uint, WorldObject> Character {
			get { return this; }
		}

		public Dictionary<uint, WorldObject> Items {
			get { return this; }
		}

		public Dictionary<uint, WorldObject> All {
			get { return this; }
		}


		public WorldObject this[EDatabaseType type, uint id] {
			get { return this[new WorldID(id, type)]; }
		}

		public WorldObject this[EDatabaseType type, int id] {
			get { return this[type, (uint)id]; }
		}

		public WorldObject this[WorldID key] {
			get {
				WorldObject obj;
				if (TryGetValue(key, out obj) == false) {
					return null;
				}
				return obj;
			}
		}


		public WorldObjectManager() {
		}


		#region Add
		public void Add(WorldID key, WorldObject obj) {
			base.Add(key.ID, obj);
		}

		public void Add(WorldObject obj) {
			Add(obj.WorldID, obj);
		}

		public void Add(KeyValuePair<WorldID, WorldObject> item) {
			Add(item.Key, item.Value);
		}
		#endregion

		#region ContainsKey
		public bool ContainsKey(WorldID key) {
			return base.ContainsKey(key.ID);
		}

		public bool ContainsKey(WorldObject obj) {
			return ContainsKey(obj.WorldID);
		}

		public bool Contains(KeyValuePair<WorldID, WorldObject> item) {
			return ContainsKey(item.Key);
		}
		#endregion

		#region Remove
		public bool Remove(WorldID key) {
			return base.Remove(key.ID);
		}

		public bool Remove(WorldObject obj) {
			return Remove(obj.WorldID);
		}

		public bool Remove(KeyValuePair<WorldID, WorldObject> item) {
			return Remove(item.Key);
		}
		#endregion

		#region TryGetValue
		public bool TryGetValue(WorldID key, out WorldObject obj) {
			return base.TryGetValue(key.ID, out obj);
		}
		#endregion

		#region Clear
		public void Clear(bool dispose) {
			if (dispose == false) {
				All.Clear();
				return;
			}

			// Call dispose on each
			var objects = new WorldObject[All.Values.Count];
			All.Values.CopyTo(objects, 0);
			foreach (var t in objects) {
				t.Dispose();
			}

			// Now clear them
			objects = null;
			All.Clear();
		}
		#endregion

	}

}
