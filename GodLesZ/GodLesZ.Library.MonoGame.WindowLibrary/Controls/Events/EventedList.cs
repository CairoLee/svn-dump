using System;
using System.Collections.Generic;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class EventedList<T> : List<T> {

		public event EventHandler ItemAdded;
		public event EventHandler ItemRemoved;

		public EventedList() : base() { }
		public EventedList(int capacity) : base(capacity) { }
		public EventedList(IEnumerable<T> collection) : base(collection) { }

		public new void Add(T item) {
			int c = this.Count;
			base.Add(item);
			if (ItemAdded != null && c != this.Count)
				ItemAdded.Invoke(item, new EventArgs());
		}

		public new void Remove(T obj) {
			int c = this.Count;
			base.Remove(obj);
			if (ItemRemoved != null && c != this.Count)
				ItemRemoved.Invoke(obj, new EventArgs());
		}

		public new void Clear() {
			int c = this.Count;
			T[] items = ToArray();
			base.Clear();
			if (ItemRemoved != null && c != this.Count)
				ItemRemoved.Invoke(items, new EventArgs());
		}

		public new void AddRange(IEnumerable<T> collection) {
			int c = this.Count;
			base.AddRange(collection);
			if (ItemAdded != null && c != this.Count)
				ItemAdded.Invoke(collection, new EventArgs());
		}

		public new void Insert(int index, T item) {
			int c = this.Count;
			base.Insert(index, item);
			if (ItemAdded != null && c != this.Count)
				ItemAdded.Invoke(item, new EventArgs());
		}

		public new void InsertRange(int index, IEnumerable<T> collection) {
			int c = this.Count;
			base.InsertRange(index, collection);
			if (ItemAdded != null && c != this.Count)
				ItemAdded.Invoke(collection, new EventArgs());
		}

		public new int RemoveAll(Predicate<T> match) {
			int c = this.Count;
			var items = base.FindAll(match);
			int ret = base.RemoveAll(match);
			if (ItemRemoved != null && c != this.Count)
				ItemRemoved.Invoke(items, new EventArgs());
			return ret;
		}

		public new void RemoveAt(int index) {
			int c = this.Count;
			T item = (index >= 0 && index < Count ? this[index] : default(T));
			base.RemoveAt(index);
			if (ItemRemoved != null && c != this.Count)
				ItemRemoved.Invoke(item, new EventArgs());
		}

		public new void RemoveRange(int index, int count) {
			int c = this.Count;
			T[] items = new T[count];
			if (index >= 0 && index + count < Count) {
				CopyTo(index, items, 0, count);
			}
			base.RemoveRange(index, count);
			if (ItemRemoved != null && c != this.Count)
				ItemRemoved.Invoke(items, new EventArgs());
		}

	}

}
