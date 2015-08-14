using GodLesZ.Library.MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Runtime.InteropServices;

namespace GodLesZ.Library.MySql.Data.Types {

	[StructLayout(LayoutKind.Sequential)]
	internal struct MySqlDecimal : IMySqlValue {
		private byte precision;
		private byte scale;
		private decimal mValue;
		private bool isNull;
		public MySqlDecimal(bool isNull) {
			this.isNull = isNull;
			this.mValue = 0M;
			this.precision = (byte)(this.scale = 0);
		}

		public MySqlDecimal(decimal val) {
			this.isNull = false;
			this.precision = (byte)(this.scale = 0);
			this.mValue = val;
		}

		public bool IsNull {
			get { return this.isNull; }
		}
		MySqlDbType IMySqlValue.MySqlDbType {
			get { return MySqlDbType.Decimal; }
		}
		public byte Precision {
			get { return this.precision; }
			set { this.precision = value; }
		}
		public byte Scale {
			get { return this.scale; }
			set { this.scale = value; }
		}
		DbType IMySqlValue.DbType {
			get { return DbType.Decimal; }
		}
		object IMySqlValue.Value {
			get { return this.mValue; }
		}
		public decimal Value {
			get { return this.mValue; }
		}
		Type IMySqlValue.SystemType {
			get { return typeof(decimal); }
		}
		string IMySqlValue.MySqlTypeName {
			get { return "DECIMAL"; }
		}
		void IMySqlValue.WriteValue(MySqlStream stream, bool binary, object val, int length) {
			string s = Convert.ToDecimal(val).ToString(CultureInfo.InvariantCulture);
			if (binary) {
				stream.WriteLenString(s);
			} else {
				stream.WriteStringNoNull(s);
			}
		}

		IMySqlValue IMySqlValue.ReadValue(MySqlStream stream, long length, bool nullVal) {
			if (nullVal) {
				return new MySqlDecimal(true);
			}
			if (length == -1L) {
				return new MySqlDecimal(decimal.Parse(stream.ReadLenString(), CultureInfo.InvariantCulture));
			}
			return new MySqlDecimal(decimal.Parse(stream.ReadString(length), CultureInfo.InvariantCulture));
		}

		void IMySqlValue.SkipValue(MySqlStream stream) {
			long num = stream.ReadFieldLength();
			stream.SkipBytes((int)num);
		}

		internal static void SetDSInfo(DataTable dsTable) {
			DataRow row = dsTable.NewRow();
			row["TypeName"] = "DECIMAL";
			row["ProviderDbType"] = MySqlDbType.NewDecimal;
			row["ColumnSize"] = 0;
			row["CreateFormat"] = "DECIMAL({0},{1})";
			row["CreateParameters"] = "precision,scale";
			row["DataType"] = "System.Decimal";
			row["IsAutoincrementable"] = false;
			row["IsBestMatch"] = true;
			row["IsCaseSensitive"] = false;
			row["IsFixedLength"] = true;
			row["IsFixedPrecisionScale"] = true;
			row["IsLong"] = false;
			row["IsNullable"] = true;
			row["IsSearchable"] = true;
			row["IsSearchableWithLike"] = false;
			row["IsUnsigned"] = false;
			row["MaximumScale"] = 0;
			row["MinimumScale"] = 0;
			row["IsConcurrencyType"] = DBNull.Value;
			row["IsLiteralsSupported"] = false;
			row["LiteralPrefix"] = null;
			row["LiteralSuffix"] = null;
			row["NativeDataType"] = null;
			dsTable.Rows.Add(row);
		}
	}
}

