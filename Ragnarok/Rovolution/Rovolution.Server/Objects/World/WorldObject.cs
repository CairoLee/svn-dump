using System;
using Rovolution.Server.Database;

namespace Rovolution.Server.Objects {

	/// <summary>Reflects an object in the world using an unique ID for each object</summary>
	public class WorldObject : StoreableObject, IComparable<WorldObject>, IDisposable {
		public static readonly WorldObject Empty = new WorldObject(DatabaseID.Null, false);

		protected DatabaseID mDatabaseID;
		protected WorldID mWorldID;
		protected bool mAddToWorld = false;
		protected DatabaseObject mDatabaseData;

		public WorldID WorldID {
			get { return mWorldID; }
			set {
				mWorldID = value;
				if ((mWorldID is WorldID)) {
					if (mAddToWorld == true && World.Objects[value] == null) {
						World.Objects.Add(this);
					}
					// Update DatabaseID, if Zero 
					if (mDatabaseID == DatabaseID.Zero) {
						UpdateDatabaseID(WorldID.ID, WorldID.Type);
					}
				}
			}
		}

		public uint ID {
			get { return WorldID.ID; }
		}

		public EDatabaseType Type {
			get { return WorldID.Type; }
		}


		public WorldObject(DatabaseID dbID, bool addToWorld) {
			mDatabaseID = dbID;
			mAddToWorld = addToWorld;

			WorldID = WorldID.Dynamic(dbID.Type);
		}

		public WorldObject(DatabaseID dbID)
			: this(dbID, false) {
		}


		#region Static getter
		public static WorldObjectViewData GetViewData(WorldObject obj) {
			switch (obj.Type) {
				case EDatabaseType.Char:
					return (obj as Character).ViewData;
				case EDatabaseType.Mob:
					return (obj as Monster).ViewData;
				//case BL_PET: return &((TBL_PET*)bl)->vd;
				//case BL_NPC: return ((TBL_NPC*)bl)->vd;
				//case BL_HOM: return ((TBL_HOM*)bl)->vd;
				//case BL_MER: return ((TBL_MER*)bl)->vd;
			}
			return null;
		}

		public static WorldObjectStatus GetStatusData(WorldObject obj) {
			switch (obj.Type) {
				case EDatabaseType.Char:
					return (obj as Character).BattleStatus;
				case EDatabaseType.Mob:
					return (obj as Monster).Status;
				//case BL_PET: return &((TBL_PET*)bl)->status;
				//case BL_HOM: return &((TBL_HOM*)bl)->battle_status;
				//case BL_MER: return &((TBL_MER*)bl)->battle_status;
			}
			return null;
		}

		public static WorldObjectStatus GetBaseStatusData(WorldObject obj) {
			switch (obj.Type) {
				case EDatabaseType.Char:
					return (obj as Character).BaseStatus;
				case EDatabaseType.Mob:
					return (obj as Monster).Database.Status;
				//case BL_PET: return &((TBL_PET*)bl)->db->status;
				//case BL_HOM: return &((TBL_HOM*)bl)->base_status;
				//case BL_MER: return &((TBL_MER*)bl)->base_status;
			}
			return null;
		}

		public static WorldObjectStatusChangeList GetStatusChange(WorldObject obj) {
			switch (obj.Type) {
				case EDatabaseType.Char:
					return (obj as Character).StatusChange;
				case EDatabaseType.Mob:
					return (obj as Monster).StatusChange;
				//case BL_NPC: return &((TBL_NPC*)bl)->sc;
				//case BL_HOM: return &((TBL_HOM*)bl)->sc;
				//case BL_MER: return &((TBL_MER*)bl)->sc;
			}
			return null;
		}

		public static int GetLevel(WorldObject obj) {
			switch (obj.Type) {
				case EDatabaseType.Char:
					return (int)(obj as Character).Status.LevelBase;
				case EDatabaseType.Mob:
					return (obj as Monster).Level;
				//case BL_PET: return ((TBL_PET*)bl)->pet.level;
				//case BL_HOM: return ((TBL_HOM*)bl)->homunculus.level;
				//case BL_MER: return ((TBL_MER*)bl)->db->lv;
			}
			return 1;
		}


		public static string GetName(WorldObject obj) {
			switch (obj.Type) {
				case EDatabaseType.Char:
					return ((obj as Character).FakeName.IsNullOrEmpty() ? (obj as Character).Status.Name : (obj as Character).FakeName);
				case EDatabaseType.Mob:
					return (obj as Monster).Database.NameInter;
				//case EDatabaseType.Pet:					return (obj as Pet).Database.Name;
				//case EDatabaseType.Homunculus:					return (obj as Pet).Database.Name;
				//case EDatabaseType.Npc:					return (obj as Pet).Name;
			}
			return "Unknown";
		}

		public static int GetClass(WorldObject obj) {
			switch (obj.Type) {
				case EDatabaseType.Char:
					return (int)(obj as Character).Status.Class;
				case EDatabaseType.Mob:
					return (obj as Monster).ViewData.Class;
				//case EDatabaseType.Pet:					return (obj as Pet).Database.Class;
				//case EDatabaseType.Homunculus:					return (obj as Pet).Database.Class;
				//case EDatabaseType.Mercenary:					return (obj as Pet).Database.Class;
				//case EDatabaseType.Npc:					return (obj as Pet).Database.Class;
			}
			return 0;
		}

		public static WorldObjectRegenerationData GetRegenData(WorldObject obj) {
			switch (obj.Type) {
				case EDatabaseType.Char:
					return (obj as Character).Regen;
				//case EDatabaseType.Homunculus:					return (obj as Homunculus).Regen;
				//case EDatabaseType.Mercenary:					return (obj as Mercenary).Regen;
			}
			return null;
		}

		public static void GetRegenRate(WorldObject obj) {
		}

		public static byte GetDef(WorldObject obj) {
			/*
							struct unit_data *ud;
							struct status_data *status = status_get_status_data(bl);
							int def = status?status->def:0;
							ud = unit_bl2ud(bl);
							if (ud && ud->skilltimer != INVALID_TIMER)
								def -= def * skill_get_castdef(ud->skillid)/100;
							return cap_value(def, CHAR_MIN, CHAR_MAX);
			*/
			return 0;
		}

		public static ushort GetSpeed(WorldObject obj) {
			// Only object with speed data but no status_data
			if (obj.Type == EDatabaseType.Npc) {
				return (obj as NpcScript).Speed;
			}

			return WorldObject.GetStatusData(obj).Speed;
		}
		#endregion

		#region IComparable Member
		public int CompareTo(WorldObject other) {
			if (!(other is WorldObject)) {
				return -1;
			}

			return mWorldID.CompareTo(other.WorldID);
		}

		public int CompareTo(object other) {
			if (other is WorldObject) {
				return this.CompareTo((WorldObject)other);
			}

			throw new ArgumentException();
		}
		#endregion


		/// <summary>
		/// Deletes the object from world list
		/// <para>Note: To keep it in the list, just call Dispose()</para>
		/// </summary>
		public virtual void Delete() {
			// Remove/delete from world list
			World.Objects.Remove(this);
		}

		/// <summary>
		/// Cleans the memory
		/// <para>Note: The object is still in the world list</para>
		/// </summary>
		public virtual void Dispose() {
			// Clean memory

			// Note: dont call Delete() here!
			//		 WorldObjectList.Clear() calls Dispose()
			//		 so dont change the object list (Delete() removes the object from world lists)
		}


		public virtual void UpdateDatabaseID(uint id, EDatabaseType type) {
			mDatabaseID = new DatabaseID(id, type);
			mDatabaseData = null;
		}

		public virtual DatabaseObject GetDatabaseData() {
			if (mDatabaseData == null) {
				mDatabaseData = World.Database[mDatabaseID];
			}

			return mDatabaseData;
		}

		public virtual bool Save() {
			return false;
		}

		/// <summary>Gets the object type as used in packets.</summary>
		/// <returns>The object type.</returns>
		public virtual byte GetPacketType() {
			byte type = 0x0;
			switch (Type) {
				case EDatabaseType.Char:
					type = (byte)((this as Character).Disguise > 0 ? 0x1 : 0x0); //PC_TYPE
					break;
				case EDatabaseType.Item:
					type = 0x2; //ITEM_TYPE
					break;
				case EDatabaseType.Skill:
					type = 0x3; //SKILL_TYPE
					break;
				case EDatabaseType.Chat:
					type = 0x4; //UNKNOWN_TYPE
					break;
				case EDatabaseType.Mob:
					type = (byte)(Character.CheckID((int)(this as Monster).Database.ID) ? 0x0 : 0x5); //NPC_MOB_TYPE
					break;
				case EDatabaseType.Npc:
					type = 0x6; //NPC_EVT_TYPE
					break;
				case EDatabaseType.Pet:
					type = (byte)(Character.CheckID((int)(this as Monster).Database.ID) ? 0x0 : 0x7); //NPC_PET_TYPE
					break;
				case EDatabaseType.Homunculus:
					type = 0x8; //NPC_HOM_TYPE
					break;
				case EDatabaseType.Mercenary:
					type = 0x9; //NPC_MERSOL_TYPE
					break;
				// case BL_ELEM:  return 0xA; //NPC_ELEMENTAL_TYPE
				default:
					type = 0x1; //NPC_TYPE
					break;
			}
			return type;
		}

		// TODO: from the old scripting system/way
		//		 needs to be reimplemented
		/*
		#region Script Event Code
		public virtual void AddScript(SerialObjectScriptHandler handler) {
			mScripts.AddHandler(ESerialObjectScriptType.Generic, handler);
		}

		public virtual void ExecuteScript(params object[] args) {
			ExecuteScript(ESerialObjectScriptType.Generic, args);
		}
		public virtual void ExecuteScript(ESerialObjectScriptType type, params object[] args) {
			mScripts.Execute(this, type, args);
		}
		#endregion
		*/



	}

}
