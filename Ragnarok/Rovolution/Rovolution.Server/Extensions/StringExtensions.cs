using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server {

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


		public static string MysqlEscape(this string Text) {
			return GodLesZ.Library.MySql.Data.MySqlClient.MySqlHelper.EscapeString(Text);
		}

	}

}
