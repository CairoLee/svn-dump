using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Objects;

namespace Rovolution.Server {

	/// <summary>
	/// Manages all objects from the database
	/// <para>
	/// Note: Holds a ref of each object.
	/// To store a object outside of this class, just ref the DatabaseID object.
	/// </para>
	/// </summary>
	public class DatabaseObjectManager {
		private DatabaseObjectList mAccount;
		private DatabaseObjectList mCharacter;
		private DatabaseObjectList mGuild;
		private DatabaseObjectList mHomonculus;
		private DatabaseObjectList mItem;
		private DatabaseObjectList mMonster;
		private DatabaseObjectList mNpc;
		private DatabaseObjectList mParty;
		private DatabaseObjectList mPet;
		private SkillDatabaseDataList mSkill;

		public DatabaseObjectList Account {
			get { return mAccount; }
		}

		public DatabaseObjectList Character {
			get { return mCharacter; }
		}

		public DatabaseObjectList Guild {
			get { return mGuild; }
		}

		public DatabaseObjectList Homunculus {
			get { return mHomonculus; }
		}

		public DatabaseObjectList Items {
			get { return mItem; }
		}

		public DatabaseObjectList Monster {
			get { return mMonster; }
		}

		public DatabaseObjectList Npc {
			get { return mNpc; }
		}

		public DatabaseObjectList Party {
			get { return mParty; }
		}

		public DatabaseObjectList Pet {
			get { return mPet; }
		}

		public SkillDatabaseDataList Skill {
			get { return mSkill; }
		}


		public DatabaseObject this[EDatabaseType type, uint id] {
			get { return this[new DatabaseID(id, type)]; }
		}

		public DatabaseObject this[EDatabaseType type, int id] {
			get { return this[type, (uint)id]; }
		}

		public DatabaseObject this[DatabaseID key] {
			get {
				DatabaseObject obj;
				if (TryGetValue(key, out obj) == false) {
					return null;
				}
				return obj;
			}
		}

		public SkillDatabaseData this[ESkill key] {
			get {
				DatabaseObject obj;
				if (TryGetValue((ESkill)key, out obj) == false) {
					return null;
				}
				return obj as SkillDatabaseData;
			}
		}


		public DatabaseObjectManager() {
			mAccount = new DatabaseObjectList();
			mCharacter = new DatabaseObjectList();
			mGuild = new DatabaseObjectList();
			mHomonculus = new DatabaseObjectList();
			mItem = new DatabaseObjectList();
			mMonster = new DatabaseObjectList();
			mNpc = new DatabaseObjectList();
			mParty = new DatabaseObjectList();
			mPet = new DatabaseObjectList();
			mSkill = new SkillDatabaseDataList();
		}


		#region Add
		public void Add(DatabaseID key, DatabaseObject obj) {
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
			}
		}

		public void Add(DatabaseObject obj) {
			Add(obj.Serial, obj);
		}

		public void Add(KeyValuePair<DatabaseID, DatabaseObject> item) {
			Add(item.Key, item.Value);
		}

		public void Add(ESkill key, SkillDatabaseData obj) {
			mSkill.Add(key, obj);
		}
		#endregion

		#region ContainsKey
		public bool ContainsKey(DatabaseID key) {
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
			}

			return false;
		}

		public bool ContainsKey(DatabaseObject obj) {
			return ContainsKey(obj.Serial);
		}

		public bool Contains(KeyValuePair<DatabaseID, DatabaseObject> item) {
			return ContainsKey(item.Key);
		}

		public bool ContainsKey(ESkill key) {
			return mSkill.ContainsKey(key);
		}
		#endregion

		#region Remove
		public bool Remove(DatabaseID key) {
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
			}

			return false;
		}

		public bool Remove(DatabaseObject obj) {
			return Remove(obj.Serial);
		}

		public bool Remove(KeyValuePair<DatabaseID, DatabaseObject> item) {
			return Remove(item.Key);
		}

		public bool Remove(ESkill key) {
			return mSkill.Remove(key);
		}

		public bool Remove(SkillDatabaseData obj) {
			return Remove(obj.Index);
		}
		#endregion

		#region TryGetValue
		public bool TryGetValue(DatabaseID key, out DatabaseObject obj) {
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
			}

			obj = null;
			return false;
		}

		public bool TryGetValue(ESkill key, out DatabaseObject obj) {
			return mSkill.TryGetValue(key, out obj);
		}
		#endregion

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


		public void CopyTo(KeyValuePair<DatabaseID, DatabaseObject>[] array, int arrayIndex) {
			throw new NotImplementedException();
		}

	}

}
