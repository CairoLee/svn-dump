using System;
using System.Collections;
using System.Collections.Generic;

namespace GodLesZ.Library.Amf.Collections.Generic {
	/// <summary>
	/// Implements a strongly typed read-only collection.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ReadOnlyCollection<T> : ICollection<T>, IEnumerable<T>, IEnumerable {
		ICollection<T> _collection;

		/// <summary>
		/// Creates a ReadOnlyCollection wrapper for a specific collection.
		/// </summary>
		/// <param name="collection">The collection to wrap.</param>
		public ReadOnlyCollection(ICollection<T> collection) {
			if (collection == null)
				throw new ArgumentNullException("collection");
			_collection = collection;
		}

		#region ICollection<T> Members

		public void Add(T item) {
			throw new NotSupportedException("The method or operation is not implemented.");
		}

		public void Clear() {
			throw new NotSupportedException("The method or operation is not implemented.");
		}

		public bool Contains(T item) {
			return _collection.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex) {
			_collection.CopyTo(array, arrayIndex);
		}

		public int Count {
			get { return _collection.Count; }
		}

		public bool IsReadOnly {
			get { return true; }
		}

		public bool Remove(T item) {
			throw new NotSupportedException("The method or operation is not implemented.");
		}

		#endregion

		#region IEnumerable<T> Members

		public IEnumerator<T> GetEnumerator() {
			return _collection.GetEnumerator();
		}

		#endregion

		#region IEnumerable Members

		IEnumerator IEnumerable.GetEnumerator() {
			return (_collection as IEnumerable).GetEnumerator();
		}

		#endregion
	}
}
