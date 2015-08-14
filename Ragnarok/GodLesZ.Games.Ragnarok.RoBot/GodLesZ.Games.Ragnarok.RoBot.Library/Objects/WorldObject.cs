using System;
using GodLesZ.Games.Ragnarok.RoBot.Library.Objects.Enumerations;

namespace GodLesZ.Games.Ragnarok.RoBot.Library.Objects {

	/// <summary>Reflects an object in the world using an unique ID for each object</summary>
	public class WorldObject : IComparable<WorldObject>, IDisposable {
		public static readonly WorldObject Empty = new WorldObject(WorldID.Null, false);

		protected WorldID mWorldID;
		protected bool mAddToWorld = false;

		public WorldID WorldID {
			get { return mWorldID; }
			set {
				mWorldID = value;
				if (mWorldID == null) {
					return;
				}

				if (mAddToWorld && Library.World.Objects[value] == null) {
					Library.World.Objects.Add(this);
				}
			}
		}

		public uint ID {
			get { return WorldID.ID; }
		}

		public EDatabaseType Type {
			get { return WorldID.Type; }
		}


		public WorldObject(WorldID dbID, bool addToWorld) {
			mWorldID = dbID;
			mAddToWorld = addToWorld;

			WorldID = WorldID.Dynamic(dbID.Type);
			if (mAddToWorld && Library.World.Objects[dbID] == null) {
				Library.World.Objects.Add(this);
			}
		}

		public WorldObject(WorldID dbID)
			: this(dbID, false) {
		}


		#region IComparable Member
		public int CompareTo(WorldObject other) {
			if (other == null) {
				return -1;
			}

			return mWorldID.CompareTo(other.WorldID);
		}

		public int CompareTo(object other) {
			var worldObject = other as WorldObject;
			if (worldObject != null) {
				return CompareTo(worldObject);
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
			Library.World.Objects.Remove(this);
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

		public virtual bool Save() {
			return false;
		}

		/// <summary>Gets the object type as used in packets.</summary>
		/// <returns>The object type.</returns>
		public virtual byte GetPacketType() {
			byte type = 0x0;
			switch (Type) {
				case EDatabaseType.Char:
					//type = (byte)((this as Character).Disguise > 0 ? 0x1 : 0x0); //PC_TYPE
					type = 0x0; //PC_TYPE
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
					//type = (byte)(Character.CheckID((int)(this as Monster).Database.ID) ? 0x0 : 0x5); //NPC_MOB_TYPE
					type = 0x5; //NPC_MOB_TYPE
					break;
				case EDatabaseType.Npc:
					type = 0x6; //NPC_EVT_TYPE
					break;
				case EDatabaseType.Pet:
					//type = (byte)(Character.CheckID((int)(this as Monster).Database.ID) ? 0x0 : 0x7); //NPC_PET_TYPE
					type = 0x7; //NPC_PET_TYPE
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

	}

}
