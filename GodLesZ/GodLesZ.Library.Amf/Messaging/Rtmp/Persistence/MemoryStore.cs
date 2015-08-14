using System.Collections;

using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Persistence;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Persistence {
	/// <summary>
	/// Persistence implementation that stores the objects in memory.
	/// This serves as default persistence if nothing has been configured.
	/// 
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class MemoryStore : IPersistenceStore {
		/// <summary>
		/// This is used in the id for objects that have a name of <code>null</code>
		/// </summary>
		public const string PersistenceNoName = "__null__";

		protected IScope _scope;
		/// <summary>
		/// Map(String, IPersistable)
		/// </summary>
		protected Hashtable _objects = new Hashtable();

		object _syncLock = new object();

		public MemoryStore(IScope scope) {
			_scope = scope;
		}

		public object SyncRoot { get { return _syncLock; } }

		protected string GetObjectName(string id) {
			// The format of the object id is <type>/<path>/<objectName>
			string result = id.Substring(id.LastIndexOf('/') + 1);
			if (result.Equals(PersistenceNoName))
				result = null;
			return result;
		}

		protected string GetObjectPath(string id, string name) {
			// The format of the object id is <type>/<path>/<objectName>
			id = id.Substring(id.IndexOf('/') + 1);
			if (id.StartsWith("/"))
				id = id.Substring(1);

			if (id.LastIndexOf(name) == -1)
				return id;
			return id.Substring(0, id.LastIndexOf(name) - 1);
		}

		protected string GetObjectId(IPersistable obj) {
			// The format of the object id is <type>/<path>/<objectName>
			string result = obj.GetType().Name;
			if (!obj.Path.StartsWith("/"))
				result += "/";

			result += obj.Path;
			if (!result.EndsWith("/"))
				result += "/";

			string name = obj.Name;
			if (name == null)
				name = PersistenceNoName;

			if (name.StartsWith("/")) {
				// "result" already ends with a slash
				name = name.Substring(1);
			}
			return result + name;
		}

		#region IPersistenceStore Members

		public virtual bool Save(IPersistable obj) {
			_objects[GetObjectId(obj)] = obj;
			obj.IsPersistent = true;
			return true;
		}

		public virtual IPersistable Load(string name) {
			return _objects[name] as IPersistable;
		}

		public virtual bool Load(IPersistable obj) {
			return obj.IsPersistent;
		}

		public virtual bool Remove(IPersistable obj) {
			return Remove(GetObjectId(obj));
		}

		public virtual bool Remove(string name) {
			if (!_objects.ContainsKey(name))
				return false;

			IPersistable obj = _objects[name] as IPersistable;
			_objects.Remove(name);
			obj.IsPersistent = false;
			return true;
		}

		public ICollection GetObjectNames() {
			return _objects.Keys;
		}

		public ICollection GetObjects() {
			return _objects.Values;
		}

		#endregion
	}
}
