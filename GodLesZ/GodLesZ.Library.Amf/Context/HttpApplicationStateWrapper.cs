using System.Collections;
using System.Web;

namespace GodLesZ.Library.Amf.Context {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class HttpApplicationStateWrapper : IApplicationState {
		public HttpApplicationStateWrapper() {
		}

		#region IApplicationState Members

		public object this[int index] {
			get {
				return HttpContext.Current.Application[index];
			}
		}

		public object this[string name] {
			get {
				return HttpContext.Current.Application[name];
			}
			set {
				HttpContext.Current.Application[name] = value;
			}
		}

		public void Remove(string key) {
			HttpContext.Current.Application.Remove(key);
		}

		public void RemoveAt(int index) {
			HttpContext.Current.Application.RemoveAt(index);
		}

		public void Add(string name, object value) {
			HttpContext.Current.Application.Add(name, value);
		}

		/// <summary>
		/// Locks access to an IApplicationState variable to facilitate access synchronization.
		/// </summary>
		public void Lock() {
			HttpContext.Current.Application.Lock();
		}
		/// <summary>
		/// Unlocks access to an IApplicationState variable to facilitate access synchronization.
		/// </summary>
		public void UnLock() {
			HttpContext.Current.Application.UnLock();
		}

		#endregion

		#region IEnumerable Members

		public IEnumerator GetEnumerator() {
			return HttpContext.Current.Application.GetEnumerator();
		}

		#endregion
	}
}
