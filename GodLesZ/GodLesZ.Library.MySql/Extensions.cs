using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GodLesZ.Library.MySql {

	public static class StringExtensions {

		public static bool IsNumeric(this string Text, out double RetValue) {
			return Double.TryParse(Convert.ToString(Text), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out RetValue);
		}

		public static bool IsNullOrEmpty(this string Text) {
			return String.IsNullOrEmpty(Text);
		}

		public static string MysqlEscape(this string Text) {
			return GodLesZ.Library.MySql.Data.MySqlClient.MySqlHelper.EscapeString(Text);
		}

		public static string ToProgramming(this string Text) {
			return Text.Replace(',', '.');
		}

	}

}
