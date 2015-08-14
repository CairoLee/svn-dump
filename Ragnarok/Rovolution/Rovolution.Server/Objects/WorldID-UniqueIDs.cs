using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Geometry;

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
		private static WorldID mLastBattleground = new WorldID(0, EDatabaseType.Battleground);
		private static WorldID mLastChat = new WorldID(0, EDatabaseType.Chat);
		private static WorldID mLastHomunculus = new WorldID(0, EDatabaseType.Homunculus);
		private static WorldID mLastItem = new WorldID(0, EDatabaseType.Item);
		private static WorldID mLastMercenary = new WorldID(0, EDatabaseType.Mercenary);
		private static WorldID mLastMob = new WorldID(0, EDatabaseType.Mob);
		private static WorldID mLastNpc = new WorldID(0, EDatabaseType.Npc);
		private static WorldID mLastPet = new WorldID(0, EDatabaseType.Pet);

		private EDatabaseType mWorldIDType;


		#region Last<Type>
		public static WorldID LastBattleground { get { return mLastBattleground; } }
		public static WorldID LastChat { get { return mLastChat; } }
		public static WorldID LastHomunculus { get { return mLastHomunculus; } }
		public static WorldID LastItem { get { return mLastItem; } }
		public static WorldID LastMercenary { get { return mLastMercenary; } }
		public static WorldID LastMob { get { return mLastMob; } }
		public static WorldID LastNpc { get { return mLastNpc; } }
		public static WorldID LastPet { get { return mLastPet; } }
		#endregion

		#region New<Type>
		public static WorldID NewBattleground { get { return Seek(LastBattleground); } }
		public static WorldID NewChat { get { return Seek(LastChat); } }
		public static WorldID NewHomunculus { get { return Seek(LastHomunculus); } }
		public static WorldID NewItem { get { return Seek(LastItem); } }
		public static WorldID NewMercenary { get { return Seek(LastMercenary); } }
		public static WorldID NewMob { get { return Seek(LastMob); } }
		public static WorldID NewNpc { get { return Seek(LastNpc); } }
		public static WorldID NewPet { get { return Seek(LastPet); } }
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
		/// returns or sets the WorldID Type (see <see cref="EDatabaseType"/>)
		/// </summary>
		public EDatabaseType Type {
			get { return mWorldIDType; }
			set { mWorldIDType = value; }
		}


		/// <summary>
		/// Main Constructor
		/// <para>NOTE: use <see cref="WorldID.NewItem"/> and the other static properties!</para>
		/// </summary>
		/// <param name="WorldID"></param>
		/// <param name="type"></param>
		public WorldID(uint id, EDatabaseType type) {
			mWorldID = id;
			mWorldIDType = type;
		}

		/// <summary>
		/// Main Constructor
		/// <para>NOTE: use <see cref="WorldID.NewItem"/> and the other static properties!</para>
		/// </summary>
		/// <param name="WorldID"></param>
		/// <param name="type"></param>
		public WorldID(int WorldID, EDatabaseType type)
			: this((uint)WorldID, type) {
		}

		/// <summary>
		/// Main Constructor
		/// <para>NOTE: use <see cref="WorldID.NewItem"/> and the other static properties!</para>
		/// </summary>
		/// <param name="WorldID"></param>
		/// <param name="type"></param>
		public WorldID(long WorldID, EDatabaseType type)
			: this((uint)WorldID, type) {
		}


		public static WorldID Dynamic(EDatabaseType type) {
			switch (type) {
				case EDatabaseType.Battleground:
					return WorldID.NewBattleground;
				case EDatabaseType.Chat:
					return WorldID.NewChat;
				case EDatabaseType.Homunculus:
					return WorldID.NewHomunculus;
				case EDatabaseType.Item:
					return WorldID.NewItem;
				case EDatabaseType.Mercenary:
					return WorldID.NewMercenary;
				case EDatabaseType.Mob:
					return WorldID.NewMob;
				case EDatabaseType.Npc:
					return WorldID.NewNpc;
				case EDatabaseType.Pet:
					return WorldID.NewPet;
				default:
					return 0;
					//throw new Exception("Bad database type for world object: " + type);
			}
		}


		/// <summary>
		/// Increments the WorldID.Value until a free space has been found
		/// <para>Place to check is World.Objects, our global <see cref="WorldIDObjectManager"/></para>
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		private static WorldID Seek(WorldID s) {
			do {
				if (s.ID == uint.MaxValue) {
					throw new Exception("Exceeded max uint value for type " + s.Type);
				}
				s.ID++;
			} while (World.Objects[s] != null);

			return s;
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