
using System;
using System.Collections;
using System.Reflection;
using GodLesZ.Library.Amf.Exceptions;
using GodLesZ.Library.Amf.Messaging.Config;

namespace GodLesZ.Library.Amf.Data {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class Identity : Hashtable {
		object _item;

		private Identity() {
		}

		public Identity(object item) {
			_item = item;
		}

		[Transient]
		public object Item {
			get { return _item; }
		}

		public Identity(IDictionary map) {
			foreach (DictionaryEntry entry in map) {
				this.Add(entry.Key, entry.Value);
			}
		}

		public static Identity GetIdentity(object item, DataDestination destination) {
			IdentityConfiguration[] keys = destination.GetIdentityKeys();
			Identity identity = new Identity(item);
			foreach (IdentityConfiguration ic in keys) {
				string key = ic.Property;
				PropertyInfo pi = item.GetType().GetProperty(key);
				if (pi != null) {
					try {
						identity[key] = pi.GetValue(item, new object[0]);
					} catch (Exception ex) {
						throw new FluorineException(__Res.GetString(__Res.Identity_Failed, key), ex);
					}
				} else {
					try {
						FieldInfo fi = item.GetType().GetField(key, BindingFlags.Public | BindingFlags.Instance);
						if (fi != null) {
							identity[key] = fi.GetValue(item);
						}
					} catch (Exception ex) {
						throw new FluorineException(__Res.GetString(__Res.Identity_Failed, key), ex);
					}
				}
			}
			return identity;
		}

		public override bool Equals(object obj) {
			if (obj is Identity) {
				Identity identity = obj as Identity;
				if (this.Count != identity.Count)
					return false;
				foreach (DictionaryEntry entry in this) {
					if (!identity.ContainsKey(entry.Key))
						return false;
					object value = identity[entry.Key];
					bool equal = (entry.Value != null ? entry.Value.Equals(value) : value == null);
					if (!equal)
						return false;
				}
				return true;
			}
			return base.Equals(obj);
		}

		public override int GetHashCode() {
			int hashCode = 0;
			foreach (DictionaryEntry entry in this) {
				if (entry.Value != null)
					hashCode ^= entry.Value.GetHashCode();
				else
					hashCode ^= 0;
			}
			return hashCode;
			//return base.GetHashCode ();
		}

	}
}
