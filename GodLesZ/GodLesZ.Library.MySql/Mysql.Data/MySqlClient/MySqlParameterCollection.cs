using GodLesZ.Library.MySql.Properties;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing.Design;
using System.Reflection;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	[ListBindable(true), Editor("GodLesZ.Library.MySql.Data.MySqlClient.Design.DBParametersEditor,MySql.Design", typeof(UITypeEditor))]
	public sealed class MySqlParameterCollection : DbParameterCollection {
		private Hashtable indexHash = new Hashtable(StringComparer.CurrentCultureIgnoreCase);
		private ArrayList items = new ArrayList();
		private MySqlCommand owningCommand;

		internal MySqlParameterCollection(MySqlCommand cmd) {
			this.Clear();
			this.owningCommand = cmd;
		}

		public MySqlParameter Add(MySqlParameter value) {
			return this.InternalAdd(value, -1);
		}

		public override int Add(object value) {
			if (!(value is MySqlParameter)) {
				throw new MySqlException("Only MySqlParameter objects may be stored");
			}
			MySqlParameter parameter = (MySqlParameter)value;
			if ((parameter.ParameterName == null) || (parameter.ParameterName == string.Empty)) {
				throw new MySqlException("Parameters must be named");
			}
			parameter = this.Add(parameter);
			return this.IndexOf(parameter);
		}

		public MySqlParameter Add(string parameterName, MySqlDbType dbType) {
			return this.Add(new MySqlParameter(parameterName, dbType));
		}

		[Obsolete("Add(String parameterName, Object value) has been deprecated.  Use AddWithValue(String parameterName, Object value)")]
		public MySqlParameter Add(string parameterName, object value) {
			return this.Add(new MySqlParameter(parameterName, value));
		}

		public MySqlParameter Add(string parameterName, MySqlDbType dbType, int size) {
			return this.Add(new MySqlParameter(parameterName, dbType, size));
		}

		public MySqlParameter Add(string parameterName, MySqlDbType dbType, int size, string sourceColumn) {
			return this.Add(new MySqlParameter(parameterName, dbType, size, sourceColumn));
		}

		public override void AddRange(Array values) {
			foreach (DbParameter parameter in values) {
				this.Add(parameter);
			}
		}

		public MySqlParameter AddWithValue(string parameterName, object value) {
			return this.Add(new MySqlParameter(parameterName, value));
		}

		private void AdjustHash(int keyIndex, bool addEntry) {
			for (int i = 0; i < this.Count; i++) {
				MySqlParameter parameter = (MySqlParameter)this.items[i];
				if (!this.indexHash.ContainsKey(parameter.ParameterName)) {
					return;
				}
				int num2 = (int)this.indexHash[parameter.ParameterName];
				if (num2 >= keyIndex) {
					this.indexHash[parameter.ParameterName] = addEntry ? ++num2 : --num2;
				}
			}
		}

		private void CheckIndex(int index) {
			if ((index < 0) || (index >= this.Count)) {
				throw new IndexOutOfRangeException("Parameter index is out of range.");
			}
		}

		public override void Clear() {
			foreach (MySqlParameter parameter in this.items) {
				parameter.Collection = null;
			}
			this.items.Clear();
			this.indexHash.Clear();
		}

		public override bool Contains(object value) {
			return this.items.Contains(value);
		}

		public override bool Contains(string parameterName) {
			return (this.IndexOf(parameterName) != -1);
		}

		public override void CopyTo(Array array, int index) {
			this.items.CopyTo(array, index);
		}

		public override IEnumerator GetEnumerator() {
			return this.items.GetEnumerator();
		}

		protected override DbParameter GetParameter(int index) {
			this.CheckIndex(index);
			return (DbParameter)this.items[index];
		}

		protected override DbParameter GetParameter(string parameterName) {
			int index = this.IndexOf(parameterName);
			if (index >= 0) {
				return (DbParameter)this.items[index];
			}
			if (parameterName.StartsWith("@") || parameterName.StartsWith("?")) {
				string str = parameterName.Substring(1);
				index = this.IndexOf(str);
				if (index != -1) {
					return (DbParameter)this.items[index];
				}
			}
			throw new ArgumentException("Parameter '" + parameterName + "' not found in the collection.");
		}

		internal MySqlParameter GetParameterFlexible(string parameterName, bool throwOnNotFound) {
			int index = this.IndexOf(parameterName);
			if (-1 == index) {
				index = this.IndexOf("?" + parameterName);
			}
			if (-1 == index) {
				index = this.IndexOf("@" + parameterName);
			}
			if ((-1 == index) && (parameterName.StartsWith("@") || parameterName.StartsWith("?"))) {
				index = this.IndexOf(parameterName.Substring(1));
			}
			if (-1 != index) {
				return this[index];
			}
			if (throwOnNotFound) {
				throw new ArgumentException("Parameter '" + parameterName + "' not found in the collection.");
			}
			return null;
		}

		public override int IndexOf(object value) {
			return this.items.IndexOf(value);
		}

		public override int IndexOf(string parameterName) {
			object obj2 = this.indexHash[parameterName];
			if (obj2 == null) {
				return -1;
			}
			return (int)obj2;
		}

		public override void Insert(int index, object value) {
			if (!(value is MySqlParameter)) {
				throw new MySqlException("Only MySqlParameter objects may be stored");
			}
			this.InternalAdd((MySqlParameter)value, index);
		}

		private MySqlParameter InternalAdd(MySqlParameter value, int index) {
			if (value == null) {
				throw new ArgumentException("The MySqlParameterCollection only accepts non-null MySqlParameter type objects.", "value");
			}
			string parameterName = value.ParameterName;
			if (this.indexHash.ContainsKey(parameterName)) {
				throw new MySqlException(string.Format(Resources.ParameterAlreadyDefined, value.ParameterName));
			}
			if ((parameterName[0] == '@') || (parameterName[0] == '?')) {
				parameterName = parameterName.Substring(1, parameterName.Length - 1);
			}
			if (this.indexHash.ContainsKey(parameterName)) {
				throw new MySqlException(string.Format(Resources.ParameterAlreadyDefined, value.ParameterName));
			}
			if (index == -1) {
				index = this.items.Add(value);
				this.indexHash.Add(value.ParameterName, index);
			} else {
				this.items.Insert(index, value);
				this.AdjustHash(index, true);
				this.indexHash.Add(value.ParameterName, index);
			}
			value.Collection = this;
			return value;
		}

		internal void ParameterNameChanged(MySqlParameter p, string oldName, string newName) {
			int index = this.IndexOf(oldName);
			this.indexHash.Remove(oldName);
			this.indexHash.Add(newName, index);
		}

		public override void Remove(object value) {
			MySqlParameter parameter = value as MySqlParameter;
			parameter.Collection = null;
			int index = this.IndexOf(parameter);
			this.items.Remove(parameter);
			this.indexHash.Remove(parameter.ParameterName);
			this.AdjustHash(index, false);
		}

		public override void RemoveAt(int index) {
			object obj2 = this.items[index];
			this.Remove(obj2);
		}

		public override void RemoveAt(string parameterName) {
			DbParameter parameter = this.GetParameter(parameterName);
			this.Remove(parameter);
		}

		protected override void SetParameter(int index, DbParameter value) {
			this.CheckIndex(index);
			MySqlParameter parameter = (MySqlParameter)this.items[index];
			this.indexHash.Remove(parameter.ParameterName);
			this.items[index] = value;
			this.indexHash.Add(value.ParameterName, index);
		}

		protected override void SetParameter(string parameterName, DbParameter value) {
			int index = this.IndexOf(parameterName);
			if (index < 0) {
				throw new ArgumentException("Parameter '" + parameterName + "' not found in the collection.");
			}
			this.SetParameter(index, value);
		}

		public override int Count {
			get { return this.items.Count; }
		}

		public override bool IsFixedSize {
			get { return this.items.IsFixedSize; }
		}

		public override bool IsReadOnly {
			get { return this.items.IsReadOnly; }
		}

		public override bool IsSynchronized {
			get { return this.items.IsSynchronized; }
		}

		new public MySqlParameter this[string name] {
			get { return (MySqlParameter)this.GetParameter(name); }
			set { this.SetParameter(name, value); }
		}

		new public MySqlParameter this[int index] {
			get { return (MySqlParameter)this.GetParameter(index); }
			set { this.SetParameter(index, value); }
		}

		public override object SyncRoot {
			get { return this.items.SyncRoot; }
		}
	}
}

