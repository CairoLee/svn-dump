using System;

namespace GodLesZ.Games.Ragnarok.RoBot.Library.Extensions {

	public static class StringExtensions {

		public static T ParseEnum<T>(this string input) {
			try {
				return (T)Enum.Parse(typeof(T), input);
			} catch {
				return default(T);
			}
		}

		public static bool IsNullOrEmpty(this string input) {
			return String.IsNullOrEmpty(input);
		}

		public static bool IsNullOrWhiteSpace(this string input) {
			return String.IsNullOrWhiteSpace(input);
		}

	}

}
