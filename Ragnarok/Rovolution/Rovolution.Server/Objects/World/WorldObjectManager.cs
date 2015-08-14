using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Objects;

namespace Rovolution.Server {

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

		public Dictionary<uint, WorldObject> Guild {
			get { return this; }
		}

		public Dictionary<uint, WorldObject> Homunculus {
			get { return this; }
		}

		public Dictionary<uint, WorldObject> Items {
			get { return this; }
		}

		public Dictionary<uint, WorldObject> Monster {
			get { return this; }
		}

		public Dictionary<uint, WorldObject> Npc {
			get { return this; }
		}

		public Dictionary<uint, WorldObject> Party {
			get { return this; }
		}

		public Dictionary<uint, WorldObject> Pet {
			get { return this; }
		}

		public Dictionary<uint, WorldObject> Skill {
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

		public Account SearchAccount(string name) {
			foreach (WorldObject acc in Account.Values) {
				if ((acc is Account) && (acc as Account).Name == name) {
					return (acc as Account);
				}
			}

			return null;
		}

		public Character SearchCharacter(string name) {
			foreach (WorldObject ch in Character.Values) {
				if ((ch is Character) && (ch as Character).Status.Name == name) {
					return (ch as Character);
				}
			}

			return null;
		}

		#region Clear
		public void Clear(bool dispose) {
			if (dispose == false) {
				All.Clear();
				return;
			}

			// Call dispose on each
			WorldObject[] objects = new WorldObject[All.Values.Count];
			All.Values.CopyTo(objects, 0);
			for (int i = 0; i < objects.Length; i++) {
				objects[i].Dispose();
			}

			// Now clear them
			objects = null;
			All.Clear();
		}
		#endregion

	}

}
