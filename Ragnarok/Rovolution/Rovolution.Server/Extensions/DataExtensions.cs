using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Rovolution.Server {

	public static class DataTableExtensions {

		public static bool HasResults(this DataTable table) {
			return (table.Rows != null && table.Rows.Count > 0);
		}


		/// <summary>
		/// Allows System.DbNull values in the column and returns default(T), if is DbNull
		/// <pr>OOtherwise row.Field&lt;T&gt; is returned</pr>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="row"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		public static T FieldNull<T>(this DataRow row, string column) {
			if (row[column] is DBNull) {
				return default(T);
			}
			return row.Field<T>(column);
		}

		/// <summary>
		/// Returns a DateTime from the column, must be a valid <see cref="GodLesZ.Library.MySql.Data.Types.MySqlDateTime"/> column
		/// </summary>
		/// <param name="row"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		public static DateTime FieldDateTime(this DataRow row, string column) {
			if (row[column] is GodLesZ.Library.MySql.Data.Types.MySqlDateTime) {
				return ((GodLesZ.Library.MySql.Data.Types.MySqlDateTime)row[column]).GetDateTime();
			}

			return DateTime.MinValue;
		}

	}

}
