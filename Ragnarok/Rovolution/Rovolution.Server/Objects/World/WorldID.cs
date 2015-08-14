using System;

namespace Rovolution.Server {

	/// <summary>
	/// A unique number for each object, represents the ID in a object
	/// </summary>
	public class WorldID : IComparable, IComparable<WorldID> {
		/// <summary>
		/// Zero-based WorldID, used to identify the first unused WorldID
		/// </summary>
		public static readonly WorldID Zero = new WorldID(0, EDatabaseType.None);
		/// <summary>
		/// A null-based WorldID, yet faked with uint.MaxValue
		/// <para>Becaue of we work with uint and cant set -1 or other values</para>
		/// <para>Assumes we nether reach uint.MaxValue (> 4mrd) in a normal way..</para>
		/// </summary>
		public static readonly WorldID Null = new WorldID(uint.MaxValue, EDatabaseType.None);

		private uint mWorldID;

		// Note: we setup the last used WorldID with 0, so WorldID.Seek() will return 1 for the first time
		// - we dont want a Monster with the WorldID 0 ..
		// Note: eA only stores one ID, npc_id, but we save an unique ID for items to
		// Hope we never get problms with it..
		// FIXME: The client wants a new ID for every new spawned object..
		//		  Means no ID should exist twice, regardless which type of unit/object
		//		  If possible, fix this in a new client and use "WorldID-UniqueID.cs"!
		// FIX: Start ID of dynamic objects by 110m, so enough room for account IDs
		private static uint mLastID = 109999999;

		private EDatabaseType mWorldIDType;


		#region New<Type>
		/// <summary>Gets a new battleground ID</summary>
		public static WorldID NewBattlegroundID {
			get { return new WorldID(Seek(mLastID), EDatabaseType.Battleground); }
		}
		/// <summary>Gets a new chat ID</summary>
		public static WorldID NewChatID {
			get { return new WorldID(Seek(mLastID), EDatabaseType.Chat); }
		}
		/// <summary>Gets a new homunculus ID</summary>
		public static WorldID NewHomunculusID {
			get { return new WorldID(Seek(mLastID), EDatabaseType.Homunculus); }
		}
		/// <summary>Gets a new item ID</summary>
		public static WorldID NewItemID {
			get { return new WorldID(Seek(mLastID), EDatabaseType.Item); }
		}
		/// <summary>Gets a new mecenary ID</summary>
		public static WorldID NewMercenaryID {
			get { return new WorldID(Seek(mLastID), EDatabaseType.Mercenary); }
		}
		/// <summary>Gets a new mob ID</summary>
		public static WorldID NewMobID {
			get { return new WorldID(Seek(mLastID), EDatabaseType.Mob); }
		}
		/// <summary>Gets a new npc ID</summary>
		public static WorldID NewNpcID {
			get { return new WorldID(Seek(mLastID), EDatabaseType.Npc); }
		}
		/// <summary>Gets a new pet ID</summary>
		public static WorldID NewPetID {
			get { return new WorldID(Seek(mLastID), EDatabaseType.Pet); }
		}
		#endregion



		/// <summary>
		/// returnes or sets the internal WorldID Number
		/// </summary>
		public uint ID {
			get { return mWorldID; }
			set {
				mWorldID = value;
				if (World.Objects[this] != null) {
					throw new Exception("WorldID " + value + " already exists!");
				}
			}
		}

		/// <summary>
		/// Gets or sets the WorldID Type (see <see cref="EDatabaseType"/>)
		/// </summary>
		public EDatabaseType Type {
			get { return mWorldIDType; }
			set { mWorldIDType = value; }
		}


		/// <summary>
		/// Main Constructor
		/// <para>NOTE: use <see cref="WorldID.NewItemID"/> and the other static properties!</para>
		/// </summary>
		/// <param name="WorldID"></param>
		/// <param name="type"></param>
		public WorldID(uint id, EDatabaseType type) {
			mWorldID = id;
			mWorldIDType = type;
		}

		/// <summary>
		/// Main Constructor
		/// <para>NOTE: use <see cref="WorldID.NewItemID"/> and the other static properties!</para>
		/// </summary>
		/// <param name="WorldID"></param>
		/// <param name="type"></param>
		public WorldID(int WorldID, EDatabaseType type)
			: this((uint)WorldID, type) {
		}

		/// <summary>
		/// Main Constructor
		/// <para>NOTE: use <see cref="WorldID.NewItemID"/> and the other static properties!</para>
		/// </summary>
		/// <param name="WorldID"></param>
		/// <param name="type"></param>
		public WorldID(long WorldID, EDatabaseType type)
			: this((uint)WorldID, type) {
		}

		/// <summary>Returns a new ID for the object type</summary>
		/// <param name="type">The object type</param>
		/// <returns>The new ID</returns>
		public static WorldID Dynamic(EDatabaseType type) {
			switch (type) {
				case EDatabaseType.Battleground:
					return WorldID.NewBattlegroundID;
				case EDatabaseType.Chat:
					return WorldID.NewChatID;
				case EDatabaseType.Homunculus:
					return WorldID.NewHomunculusID;
				case EDatabaseType.Item:
					return WorldID.NewItemID;
				case EDatabaseType.Mercenary:
					return WorldID.NewMercenaryID;
				case EDatabaseType.Mob:
					return WorldID.NewMobID;
				case EDatabaseType.Npc:
					return WorldID.NewNpcID;
				case EDatabaseType.Pet:
					return WorldID.NewPetID;
				default:
					//throw new Exception("Bad database type for world object: " + type);
					return 0;
			}
		}


		/// <summary>
		/// Increments the WorldID.Value until a free space has been found
		/// <para>Place to check is World.Objects, our global <see cref="WorldIDObjectManager"/></para>
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		private static WorldID Seek(uint ID) {
			do {
				if (ID == uint.MaxValue) {
					throw new Exception("WorldID: Exceeded max uint value");
				}
				ID++;
			} while (World.Objects[ID] != null);

			return ID;
		}



		#region Object overrides
		/// <summary>
		/// compare the WorldID.Value with another WorldID.Value
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(WorldID other) {
			return mWorldID.CompareTo(other);
		}

		/// <summary>
		/// compare the WorldID with another WorldID Object
		/// <para>Will throw <see cref="ArgumentException"/> on none-WorldID objects</para>
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(object other) {
			if (other is WorldID) {
				return this.CompareTo((WorldID)other);
			} else if (other == null) {
				return -1;
			}

			throw new ArgumentException("Object has to be instance of WorldID", "other");
		}


		/// <summary>
		/// Returns a hashcode of WorldID.Value
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode() {
			// TODO: Objects with a WorldID.Value above int.MaxValue will have the same hash!
			return (int)mWorldID;
		}

		/// <summary>
		/// Checks if the given object is typeof WorldID and equals to the current instance
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public override bool Equals(object o) {
			if (o == null || !(o is WorldID)) {
				return false;
			}

			WorldID WorldIDObj = o as WorldID;
			return (WorldIDObj == this);
		}
		#endregion

		#region operator override
		public static bool operator ==(WorldID l, WorldID r) {
			return (l.mWorldID == r.mWorldID && l.Type == r.Type);
		}

		public static bool operator !=(WorldID l, WorldID r) {
			return (l.mWorldID != r.mWorldID || l.Type != r.Type);
		}

		public static bool operator >(WorldID l, WorldID r) {
			return l.mWorldID > r.mWorldID;
		}

		public static bool operator <(WorldID l, WorldID r) {
			return l.mWorldID < r.mWorldID;
		}

		public static bool operator >=(WorldID l, WorldID r) {
			return l.mWorldID >= r.mWorldID;
		}

		public static bool operator <=(WorldID l, WorldID r) {
			return l.mWorldID <= r.mWorldID;
		}

		public static implicit operator int(WorldID a) {
			// TODO: this caps out MaxValue! >.<
			return (int)a.mWorldID;
		}

		public static implicit operator uint(WorldID a) {
			return a.mWorldID;
		}

		public static implicit operator long(WorldID a) {
			return (long)a.mWorldID;
		}

		public static implicit operator WorldID(int a) {
			return new WorldID(a, EDatabaseType.None);
		}

		public static implicit operator WorldID(uint a) {
			return new WorldID(a, EDatabaseType.None);
		}
		#endregion


		public override string ToString() {
			return String.Format("[{0}] 0x{1:X8}", Type, ID);
		}

	}

}