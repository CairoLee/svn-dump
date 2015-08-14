using System;
using Rovolution.Server.Database;

namespace Rovolution.Server {

	public partial class DatabaseObject : StoreableObject, IComparable<DatabaseObject>, IDisposable {

		public DatabaseID Serial {
			get;
			protected set;
		}

		public uint ID {
			get { return Serial.ID; }
		}


		public DatabaseObject() {
		}


		#region IComparable Member
		public int CompareTo(DatabaseObject other) {
			if (other is DatabaseObject) {
				return Serial.CompareTo(other.Serial);
			}

			return -1;
		}

		public int CompareTo(object other) {
			if (other is DatabaseObject) {
				return this.CompareTo((DatabaseObject)other);
			}

			throw new ArgumentException();
		}
		#endregion


		public virtual void Delete() {

		}

		public virtual void Dispose() {
			Delete();
		}

	}

}
