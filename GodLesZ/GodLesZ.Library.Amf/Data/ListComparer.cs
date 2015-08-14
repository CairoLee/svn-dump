
using System.Collections;

namespace GodLesZ.Library.Amf.Data {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	sealed class ListComparer : IComparer {
		public ListComparer() {
		}

		#region IComparer Members

		public int Compare(object x, object y) {
			IList list1 = x as IList;
			IList list2 = y as IList;
			if (list1 != null && list2 != null) {
				if (list1.Count != list2.Count)
					return -1;
				for (int i = 0; i < list1.Count; i++) {
					bool equal = (list1[i] != null ? list1[i].Equals(list2[i]) : list2[i] == null);
					if (!equal)
						return -1;
				}
			}
			return 0;
		}

		#endregion
	}
}
