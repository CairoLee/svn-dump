using System;

namespace Rovolution.Server {

	/// <summary>
	/// A unique number for each object from the database, represents the <see cref="DatabaseID"/> property in a object
	/// </summary>
	public class DatabaseID : IComparable, IComparable<DatabaseID> {
		/// <summary>
		/// Zero-based DatabaseID, used to identify the first unused DatabaseID
		/// </summary>
		public static readonly DatabaseID Zero = new DatabaseID(0, EDatabaseType.None);
		/// <summary>
		/// A null-based DatabaseID, yet faked with uint.MaxValue
		/// <para>Becaue of we work with uint and cant set -1 or other values</para>
		/// <para>Assumes we nether reach uint.MaxValue (> 4mrd) in a normal way..</para>
		/// </summary>
		public static readonly DatabaseID Null = new DatabaseID(uint.MaxValue, EDatabaseType.None);

		private EDatabaseType mType;

		public uint ID {
			get;
			protected set;
		}

		public EDatabaseType Type {
			get { return mType; }
			protected set {
				mType = value;
				//ServerConsole.DebugLine("Det Serial.Type to " + value + " (ID " + ID + ")");
			}
		}


		public DatabaseID(uint id, EDatabaseType type) {
			ID = id;
			Type = type;
		}

		public DatabaseID(int id, EDatabaseType type)
			: this((uint)id, type) {
		}

		public DatabaseID(long id, EDatabaseType type)
			: this((uint)id, type) {
		}




		#region Object overrides
		/// <summary>
		/// compare the DatabaseID.ID with another one
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(DatabaseID other) {
			if (other == null) {
				return -1;
			}

			return (Type == other.Type ? ID.CompareTo(other.ID) : -1);
		}

		/// <summary>
		/// compare the DatabaseID with another one
		/// <para>Will throw <see cref="ArgumentException"/> on none-DatabaseID objects</para>
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(object other) {
			if (other is DatabaseID) {
				return this.CompareTo((DatabaseID)other);
			} else if (other == null) {
				return -1;
			}

			throw new ArgumentException("Object has to be instance of DatabaseID", "other");
		}


		/// <summary>
		/// Returns a hashcode of DatabaseID.ID
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode() {
			// TODO: Objects with a DatabaseID.ID above int.MaxValue will have the same hash!
			return (int)ID;
		}

		/// <summary>
		/// Checks if the given object is typeof DatabaseID and equals to the current instance
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public override bool Equals(object o) {
			if (!(o is DatabaseID)) {
				return false;
			}

			DatabaseID obj = o as DatabaseID;
			return (obj == this);
		}
		#endregion

		#region operator override
		public static bool operator ==(DatabaseID l, DatabaseID r) {
			return (l.ID == r.ID && l.Type == r.Type);
		}

		public static bool operator !=(DatabaseID l, DatabaseID r) {
			return (l.ID != r.ID || l.Type != r.Type);
		}

		public static bool operator >(DatabaseID l, DatabaseID r) {
			return l.ID > r.ID;
		}

		public static bool operator <(DatabaseID l, DatabaseID r) {
			return l.ID < r.ID;
		}

		public static bool operator >=(DatabaseID l, DatabaseID r) {
			return (l.Type == r.Type ? l.ID >= r.ID : false);
		}

		public static bool operator <=(DatabaseID l, DatabaseID r) {
			return (l.Type == r.Type ? l.ID <= r.ID : false);
		}

		public static implicit operator int(DatabaseID a) {
			throw new NotImplementedException("Typcast to integer is not allowed! Use unsigned integer.");
		}

		public static implicit operator uint(DatabaseID a) {
			return a.ID;
		}

		public static implicit operator long(DatabaseID a) {
			return (long)a.ID;
		}

		public static implicit operator DatabaseID(int a) {
			return new DatabaseID(a, EDatabaseType.None);
		}

		public static implicit operator DatabaseID(uint a) {
			return new DatabaseID(a, EDatabaseType.None);
		}

		public static implicit operator DatabaseID(long a) {
			return new DatabaseID(a, EDatabaseType.None);
		}
		#endregion


		public override string ToString() {
			return String.Format("[{0}] 0x{1:X8}", Type, ID);
		}

	}

}
