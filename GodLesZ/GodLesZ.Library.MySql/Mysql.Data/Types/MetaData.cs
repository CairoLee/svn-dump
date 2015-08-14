using GodLesZ.Library.MySql.Data.MySqlClient;
using System;
using System.Globalization;

namespace GodLesZ.Library.MySql.Data.Types {

	internal class MetaData {
		public static bool IsNumericType(string typename) {
			switch (typename.ToLower(CultureInfo.InvariantCulture)) {
				case "int":
				case "integer":
				case "numeric":
				case "decimal":
				case "dec":
				case "fixed":
				case "tinyint":
				case "mediumint":
				case "bigint":
				case "real":
				case "double":
				case "float":
				case "serial":
				case "smallint":
					return true;
			}
			return false;
		}

		public static MySqlDbType NameToType(string typeName, bool unsigned, bool realAsFloat, MySqlConnection connection) {
			switch (typeName.ToLower(CultureInfo.InvariantCulture)) {
				case "char":
					return MySqlDbType.String;

				case "varchar":
					return MySqlDbType.VarChar;

				case "date":
					return MySqlDbType.Date;

				case "datetime":
					return MySqlDbType.DateTime;

				case "numeric":
				case "decimal":
				case "dec":
				case "fixed":
					if (connection.driver.Version.isAtLeast(5, 0, 3)) {
						return MySqlDbType.NewDecimal;
					}
					return MySqlDbType.Decimal;

				case "year":
					return MySqlDbType.Year;

				case "time":
					return MySqlDbType.Time;

				case "timestamp":
					return MySqlDbType.Timestamp;

				case "set":
					return MySqlDbType.Set;

				case "enum":
					return MySqlDbType.Enum;

				case "bit":
					return MySqlDbType.Bit;

				case "tinyint":
					if (!unsigned) {
						return MySqlDbType.Byte;
					}
					return MySqlDbType.UByte;

				case "bool":
				case "boolean":
					return MySqlDbType.Byte;

				case "smallint":
					if (!unsigned) {
						return MySqlDbType.Int16;
					}
					return MySqlDbType.UInt16;

				case "mediumint":
					if (unsigned) {
						return MySqlDbType.UInt24;
					}
					return MySqlDbType.Int24;

				case "int":
				case "integer":
					if (unsigned) {
						return MySqlDbType.UInt32;
					}
					return MySqlDbType.Int32;

				case "serial":
					return MySqlDbType.UInt64;

				case "bigint":
					if (!unsigned) {
						return MySqlDbType.Int64;
					}
					return MySqlDbType.UInt64;

				case "float":
					return MySqlDbType.Float;

				case "double":
					return MySqlDbType.Double;

				case "real":
					if (!realAsFloat) {
						return MySqlDbType.Double;
					}
					return MySqlDbType.Float;

				case "text":
					return MySqlDbType.Text;

				case "blob":
					return MySqlDbType.Blob;

				case "longblob":
					return MySqlDbType.LongBlob;

				case "longtext":
					return MySqlDbType.LongText;

				case "mediumblob":
					return MySqlDbType.MediumBlob;

				case "mediumtext":
					return MySqlDbType.MediumText;

				case "tinyblob":
					return MySqlDbType.TinyBlob;

				case "tinytext":
					return MySqlDbType.TinyText;

				case "binary":
					return MySqlDbType.Binary;

				case "varbinary":
					return MySqlDbType.VarBinary;
			}
			throw new MySqlException("Unhandled type encountered");
		}

		public static bool SupportScale(string typename) {
			string str2;
			if (((str2 = typename.ToLower(CultureInfo.InvariantCulture)) == null) || ((!(str2 == "numeric") && !(str2 == "decimal")) && (!(str2 == "dec") && !(str2 == "real")))) {
				return false;
			}
			return true;
		}
	}
}

