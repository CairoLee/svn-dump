using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public abstract class AbstractItemStorage : IList<CharacterItem> {
		/// <summary>
		/// Internal item list, contains all items
		/// </summary>
		private List<CharacterItem> mItems;
		/// <summary>
		/// Internal dirty list, contains the mItems index of new items
		/// </summary>
		private List<int> mItemsNew;
		/// <summary>
		/// Internal dirty list, contains the mItems index of changed items
		/// </summary>
		private List<int> mItemsUpdate;
		/// <summary>
		/// Internal dirty list, contains the EntryID of deleted items
		/// </summary>
		private List<int> mItemsDelete;
		
		public CharacterItem this[int index] {
			get { return mItems[index]; }
			set { SetItem(value, index); }
		}

		public int Count {
			get { return mItems.Count; }
		}

		public bool IsReadOnly {
			get { return false; }
		}

		public bool NeedUpdate {
			get { return mItemsNew.Count > 0 || mItemsUpdate.Count > 0 || mItemsDelete.Count > 0; }
		}

		public bool IsCleared {
			get;
			internal set;
		}


		public AbstractItemStorage() {
			mItems = new List<CharacterItem>();
			mItemsNew = new List<int>();
			mItemsUpdate = new List<int>();
			mItemsDelete = new List<int>();
		}


		public int IndexOf(CharacterItem item) {
			return mItems.IndexOf(item);
		}

		public void Insert(int index, CharacterItem item) {
			SetItem(item, index);
		}

		public void RemoveAt(int index) {
			RemoveItem(index);
		}


		public void Add(CharacterItem item) {
			SetItem(item, -1);
		}

		public void Clear() {
			IsCleared = true;
			mItems.Clear();
		}

		public bool Contains(CharacterItem item) {
			return mItems.Contains(item);
		}

		public void CopyTo(CharacterItem[] array, int arrayIndex) {
			mItems.CopyTo(array, arrayIndex);
		}

		public bool Remove(CharacterItem item) {
			return RemoveItem(item);
		}


		public IEnumerator<CharacterItem> GetEnumerator() {
			return mItems.GetEnumerator();
		}


		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}


		private void SetItem(CharacterItem item, int index) {
			if (index == -1) {
				// Add new item
				mItemsNew.Add(mItems.Count);
				mItems.Add(item);
			} else {
				// Set item to index
				mItemsNew.Add(index);
				mItems.Insert(index, item);
			}
		}

		private bool RemoveItem(int index) {
			if (index < 0 || index >= mItems.Count) {
				return false;
			}
			mItemsDelete.Add(this[index].EntryID);
			mItems.RemoveAt(index);
			return true;
		}

		private bool RemoveItem(CharacterItem item) {
			int index = mItems.IndexOf(item);
			if (index == -1) {
				return false;
			}
			mItemsDelete.Add(this[index].EntryID);
			mItems.RemoveAt(index);
			return true;
		}

	}

}
