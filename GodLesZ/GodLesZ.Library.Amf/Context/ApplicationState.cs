using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace GodLesZ.Library.Amf.Context {
	class ApplicationState : IApplicationState {
		IResource _resource;

		public ApplicationState() {
			_resource = new FileSystemResource("~/Web.config");
			if (_resource == null || !_resource.Exists)
				_resource = new FileSystemResource("~/web.config");
		}

		#region IApplicationState Members

		public object this[string name] {
			get {
				return HttpRuntime.Cache[name];
			}
			set {
				Add(name, value);
			}
		}

		public void Remove(string key) {
			HttpRuntime.Cache.Remove(key);
		}

		public void Add(string name, object value) {
			//Cache can be cleared by touching Web.config
			if (_resource != null && _resource.Exists) {
				CacheDependency cacheDependency = new CacheDependency(_resource.File.FullName);
				HttpRuntime.Cache.Insert(name, value, cacheDependency, DateTime.Now.AddYears(1), TimeSpan.Zero, CacheItemPriority.NotRemovable, null);
				return;
			}
		}

		/// <summary>
		/// Locks access to an IApplicationState variable to facilitate access synchronization.
		/// </summary>
		public void Lock() {
			//System.Web.Caching.Cache is thread-safe
		}
		/// <summary>
		/// Unlocks access to an IApplicationState variable to facilitate access synchronization.
		/// </summary>
		public void UnLock() {
			//System.Web.Caching.Cache is thread-safe
		}

		#endregion

		#region IEnumerable Members

		public IEnumerator GetEnumerator() {
			return HttpRuntime.Cache.GetEnumerator();
		}

		#endregion
	}
}
