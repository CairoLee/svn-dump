using System;
using System.Collections;

namespace GodLesZ.Library.Amf.Messaging.Api {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public sealed class BasicScopeEnumerator : IEnumerator {
		private int _index;
		private IList _enumerable;
		private IBasicScope _currentElement;


		internal BasicScopeEnumerator(IList enumerable) {
			_index = -1;
			_enumerable = enumerable;
		}

		#region IEnumerator Members

		/// <summary>
		/// Sets the enumerator to its initial position, which is before the first element in the collection.
		/// </summary>
		/// <exception cref="T:System.InvalidOperationException">
		/// The collection was modified after the enumerator was created.
		/// </exception>
		public void Reset() {
			_currentElement = null;
			_index = -1;
		}

		/// <summary>
		/// Gets the current element in the collection.
		/// </summary>
		/// <value></value>
		/// <returns>
		/// The current element in the collection.
		/// </returns>
		/// <exception cref="T:System.InvalidOperationException">
		/// The enumerator is positioned before the first element of the collection or after the last element.
		/// </exception>
		public object Current {
			get {
				if (_index == -1)
					throw new InvalidOperationException("Enum not started.");
				if (_index >= _enumerable.Count)
					throw new InvalidOperationException("Enumeration ended.");
				return _currentElement;
			}
		}

		/// <summary>
		/// Advances the enumerator to the next element of the collection.
		/// </summary>
		/// <returns>
		/// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
		/// </returns>
		/// <exception cref="T:System.InvalidOperationException">
		/// The collection was modified after the enumerator was created.
		/// </exception>
		public bool MoveNext() {
			if (_index < _enumerable.Count - 1) {
				_index++;
				_currentElement = _enumerable[_index] as IBasicScope;
				return true;
			}
			_index = _enumerable.Count;
			return false;
		}

		#endregion
	}
}
