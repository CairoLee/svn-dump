
using System.Collections;

namespace GodLesZ.Library.Amf.Data {
#if (NET_1_1)
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	sealed class ListHashCodeProvider : IHashCodeProvider
	{
		public ListHashCodeProvider()
		{
		}

	#region IHashCodeProvider Members

		public int GetHashCode(object obj)
		{
			IList list = obj as IList;
			return GenerateHashCode(list);
		}

	#endregion

		static public int GenerateHashCode(IList list)
		{
			if( list != null )
			{
				int hashCode = 0;
				for(int i = 0; i < list.Count; i++)
				{
					if(list[i] != null)
						hashCode ^= list[i].GetHashCode();
					else
						hashCode ^= 0;
				}
				return hashCode;
			}
			return 0;
		}
	}
#else
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	sealed class ListHashCodeProvider : IEqualityComparer {
		public ListHashCodeProvider() {
		}

		#region IEqualityComparer Members

		public new bool Equals(object x, object y) {
			IList list1 = x as IList;
			IList list2 = y as IList;
			if (list1 != null && list2 != null) {
				if (list1.Count != list2.Count)
					return false;
				for (int i = 0; i < list1.Count; i++) {
					bool equal = (list1[i] != null ? list1[i].Equals(list2[i]) : list2[i] == null);
					if (!equal)
						return false;
				}
			}
			return true;
		}

		public int GetHashCode(object obj) {
			IList list = obj as IList;
			return GenerateHashCode(list);
		}

		#endregion

		static public int GenerateHashCode(IList list) {
			if (list != null) {
				int hashCode = 0;
				for (int i = 0; i < list.Count; i++) {
					if (list[i] != null)
						hashCode ^= list[i].GetHashCode();
					else
						hashCode ^= 0;
				}
				return hashCode;
			}
			return 0;
		}
	}
#endif

}
