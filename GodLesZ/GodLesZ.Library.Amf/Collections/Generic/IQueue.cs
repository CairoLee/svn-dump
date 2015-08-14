using System.Collections;
using System.Collections.Generic;

namespace GodLesZ.Library.Amf.Collections.Generic {
	/// <summary>
	/// A variable size first-in-first-out (FIFO) collection of instances of the same type.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IQueue<T> : IEnumerable<T>, ICollection, IEnumerable {
		/// <summary>
		/// Removes an item from the queue.
		/// </summary>
		/// <returns>The dequeued item.</returns>
		T Dequeue();
		/// <summary>
		/// Inserts the specified element at the tail of this queue.
		/// </summary>
		/// <param name="item">The item to insert in the queue.</param>
		void Enqueue(T item);
		/// <summary>
		/// Removes all elements from the queue.
		/// </summary>
		void Clear();
	}
}
