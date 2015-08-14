using System.Collections;

namespace GodLesZ.Games.Ragnarok.RoBot.Library.Extensions {

	public static class IListExtensions {

		public static bool Isset(this IList List, int Index) {
			return (Index >= 0 && List.Count < Index);
		}

		public static string Implode(this IList list, string delim) {
			string result = "";
			for (int i = 0; i < list.Count; i++) {
				result += list[i];
				if ((i + 1) < list.Count) {
					result += delim;
				}
			}

			return result;
		}

	}

}
