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
	public class WorldObjectManager {
		private WorldObjectList mAccount;
		private WorldObjectList mCharacter;
		private WorldObjectList mGuild;
		private WorldObjectList mHomonculus;
		private WorldObjectList mItem;
		private WorldObjectList mMonster;
		private WorldObjectList mNpc;
		private WorldObjectList mParty;
		private WorldObjectList mPet;
		private WorldObjectList mSkill;

		public WorldObjectList Account {
			get { return mAccount; }
		}

		public WorldObjectList Character {
			get { return mCharacter; }
		}

		public WorldObjectList Guild {
			get { return mGuild; }
		}

		public WorldObjectList Homunculus {
			get { return mHomonculus; }
		}

		public WorldObjectList Items {
			get { return mItem; }
		}

		public WorldObjectList Monster {
			get { return mMonster; }
		}

		public WorldObjectList Npc {
			get { return mNpc; }
		}

		public WorldObjectList Party {
			get { return mParty; }
		}

		public WorldObjectList Pet {
			get { return mPet; }
		}

		public WorldObjectList Skill {
			get { return mSkill; }
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
			mAccount = new WorldObjectList();
			mCharacter = new WorldObjectList();
			mGuild = new WorldObjectList();
			mHomonculus = new WorldObjectList();
			mItem = new WorldObjectList();
			mMonster = new WorldObjectList();
			mNpc = new WorldObjectList();
			mParty = new WorldObjectList();
			mPet = new WorldObjectList();
			mSkill = new WorldObjectList();
		}


		#region Add
		public void Add(WorldID key, WorldObject obj) {
			switch (key.Type) {
				case EDatabaseType.Account:
					mAccount.Add(key, obj);
					break;
				case EDatabaseType.Char:
					mCharacter.Add(key, obj);
					break;
				case EDatabaseType.Guild:
					mGuild.Add(key, obj);
					break;
				case EDatabaseType.Homunculus:
					mHomonculus.Add(key, obj);
					break;
				case EDatabaseType.Item:
					mItem.Add(key, obj);
					break;
				case EDatabaseType.Mob:
					mMonster.Add(key, obj);
					break;
				case EDatabaseType.Npc:
					mNpc.Add(key, obj);
					break;
				case EDatabaseType.Party:
					mParty.Add(key, obj);
					break;
				case EDatabaseType.Pet:
					mPet.Add(key, obj);
					break;
				case EDatabaseType.Skill:
					mSkill.Add(key, obj);
					break;
			}
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
			switch (key.Type) {
				case EDatabaseType.Account:
					return mAccount.ContainsKey(key);
				case EDatabaseType.Char:
					return mCharacter.ContainsKey(key);
				case EDatabaseType.Guild:
					return mGuild.ContainsKey(key);
				case EDatabaseType.Homunculus:
					return mHomonculus.ContainsKey(key);
				case EDatabaseType.Item:
					return mItem.ContainsKey(key);
				case EDatabaseType.Mob:
					return mMonster.ContainsKey(key);
				case EDatabaseType.Npc:
					return mNpc.ContainsKey(key);
				case EDatabaseType.Party:
					return mParty.ContainsKey(key);
				case EDatabaseType.Pet:
					return mPet.ContainsKey(key);
				case EDatabaseType.Skill:
					return mSkill.ContainsKey(key);
			}

			return false;
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
			switch (key.Type) {
				case EDatabaseType.Account:
					return mAccount.Remove(key);
				case EDatabaseType.Char:
					return mCharacter.Remove(key);
				case EDatabaseType.Guild:
					return mGuild.Remove(key);
				case EDatabaseType.Homunculus:
					return mHomonculus.Remove(key);
				case EDatabaseType.Item:
					return mItem.Remove(key);
				case EDatabaseType.Mob:
					return mMonster.Remove(key);
				case EDatabaseType.Npc:
					return mNpc.Remove(key);
				case EDatabaseType.Party:
					return mParty.Remove(key);
				case EDatabaseType.Pet:
					return mPet.Remove(key);
				case EDatabaseType.Skill:
					return mSkill.Remove(key);
			}

			return false;
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
			switch (key.Type) {
				case EDatabaseType.Account:
					return mAccount.TryGetValue(key, out obj);
				case EDatabaseType.Char:
					return mCharacter.TryGetValue(key, out obj);
				case EDatabaseType.Guild:
					return mGuild.TryGetValue(key, out obj);
				case EDatabaseType.Homunculus:
					return mHomonculus.TryGetValue(key, out obj);
				case EDatabaseType.Item:
					return mItem.TryGetValue(key, out obj);
				case EDatabaseType.Mob:
					return mMonster.TryGetValue(key, out obj);
				case EDatabaseType.Npc:
					return mNpc.TryGetValue(key, out obj);
				case EDatabaseType.Party:
					return mParty.TryGetValue(key, out obj);
				case EDatabaseType.Pet:
					return mPet.TryGetValue(key, out obj);
				case EDatabaseType.Skill:
					return mSkill.TryGetValue(key, out obj);
			}

			obj = null;
			return false;
		}
		#endregion

		public Account SearchAccount(string name) {
			foreach (WorldObject acc in Account.Values) {
				if ((acc as Account).Name == name) {
					return (acc as Account);
				}
			}

			return null;
		}

		public Character SearchCharacter(string name) {
			foreach (WorldObject ch in Character.Values) {
				if ((ch as Character).Status.Name == name) {
					return (ch as Character);
				}
			}

			return null;
		}

		#region Clear
		public void Clear() {
			Clear(true);
		}

		public void Clear(bool dispose) {
			mAccount.Clear(dispose);
			mCharacter.Clear(dispose);
			mGuild.Clear(dispose);
			mHomonculus.Clear(dispose);
			mItem.Clear(dispose);
			mMonster.Clear(dispose);
			mNpc.Clear(dispose);
			mParty.Clear(dispose);
			mPet.Clear(dispose);
			mSkill.Clear(dispose);
		}
		#endregion


		public void CopyTo(KeyValuePair<WorldID, WorldObject>[] array, int arrayIndex) {
			throw new NotImplementedException();
		}

	}

}
