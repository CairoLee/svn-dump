using System;
using System.Collections;

#if !(NET_1_1)
using System.Collections.Generic;
#endif
#if !SILVERLIGHT

#endif
using GodLesZ.Library.Amf.AMF3;

namespace GodLesZ.Library.Amf.IO {
	sealed class ObjectProxyRegistry {
		static object _objLock = new object();
		/// <summary>
		/// Volatile to ensure that assignment to the instance variable completes before the instance variable can be accessed.
		/// </summary>
		static volatile ObjectProxyRegistry _instance;
		static IObjectProxy _defaultObjectProxy;

#if !(NET_1_1)
		Dictionary<Type, IObjectProxy> _registeredProxies;
#else
        Hashtable	_registeredProxies;
#endif

		private ObjectProxyRegistry() {
		}

		static public ObjectProxyRegistry Instance {
			get {
				if (_instance == null) {
					lock (_objLock) {
						if (_instance == null) {
#if WCF
                            _defaultObjectProxy = new WcfProxy();
#else
							_defaultObjectProxy = new ObjectProxy();
#endif
							ObjectProxyRegistry instance = new ObjectProxyRegistry();
							instance.Init();
							_instance = instance;
						}
					}
				}
				return _instance;
			}
		}

		private void Init() {
#if !(NET_1_1)
			_registeredProxies = new Dictionary<Type, IObjectProxy>();
#else
            _registeredProxies = new Hashtable();
#endif

			_registeredProxies.Add(typeof(ASObject), new ASObjectProxy());
			_registeredProxies.Add(typeof(IExternalizable), new ExternalizableProxy());
			_registeredProxies.Add(typeof(Exception), new ExceptionProxy());
			//_registeredProxies.Add(typeof(System.Data.Objects.DataClasses.EntityObject), new EntityObjectProxy());
#if !(NET_1_1) && !(NET_2_0) && !(SILVERLIGHT)
			_registeredProxies.Add(typeof(System.Data.Objects.DataClasses.StructuralObject), new EntityObjectProxy());
#endif
		}

		public IObjectProxy GetObjectProxy(Type type) {
			if (type.GetInterface(typeof(IExternalizable).FullName, true) != null)
				return _registeredProxies[typeof(IExternalizable)] as IObjectProxy;
			if (type.GetInterface("INHibernateProxy", false) != null) {
				//TODO
				//Quick fix for INHibernateProxy
				type = type.BaseType;
			}
			if (_registeredProxies.ContainsKey(type))
				return _registeredProxies[type] as IObjectProxy;
			foreach (DictionaryEntry entry in (IDictionary)_registeredProxies) {
				if (type.IsSubclassOf(entry.Key as Type))
					return entry.Value as IObjectProxy;
			}
			return _defaultObjectProxy;
		}
	}
}
