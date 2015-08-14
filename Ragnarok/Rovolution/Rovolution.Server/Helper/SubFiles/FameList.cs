using System.Collections.Generic;

namespace Rovolution.Server.Helper {

	public class FameList : List<FameListEntry> {

		public FameList() {

		}

		public FameList(int cap)
			: base(cap) {
		}


		public int IndexOf(uint id) {
			if (Count == 0) {
				return -1;
			}

			for (int i = 0; i < Count; i++) {
				if (this[i].ID == id) {
					return i;
				}
			}
			return -1;
		}

		public int GetFame(uint id) {
			int rank = IndexOf(id);
			if (rank == -1) {
				return 0;
			}

			return this[rank].Fame;
		}

		public bool Contains(uint id) {
			return (IndexOf(id) != -1);
		}

	}

}
