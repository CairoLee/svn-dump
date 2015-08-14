using GodLesZ.Library.MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Globalization;

namespace GodLesZ.Library.MySql.Data.Types {

	[StructLayout(LayoutKind.Sequential)]
	internal struct MySqlByte : IMySqlValue {
		private sbyte mValue;
		private bool isNull;
		private bool treatAsBool;
		public MySqlByte(bool isNull) {
			this.isNull = isNull;
			this.mValue = 0;
			this.treatAsBool = false;
		}

		public MySqlByte(sbyte val) {
			this.isNull = false;
			this.mValue = val;
			this.treatAsBool = false;
		}

		public bool IsNull {
			get { return this.isNull; }
		}
		MySqlDbType IMySqlValue.MySqlDbType {
			get { return MySqlDbType.Byte; }
		}
		DbType IMySqlValue.DbType {
			get {
				if (this.TreatAsBoolean) {
					return DbType.Boolean;
				}
				return DbType.SByte;
			}
		}
		object IMySqlValue.Value {
			get {
				if (this.TreatAsBoolean) {
					return Convert.ToBoolean(this.mValue);
				}
				return this.mValue;
			}
		}
		public sbyte Value {
			get { return this.mValue; }
			set { this.mValue = value; }
		}
		Type IMySqlValue.SystemType {
			get {
				if (this.TreatAsBoolean) {
					return typeof(bool);
				}
				return typeof(sbyte);
			}
		}
		string IMySqlValue.MySqlTypeName {
			get { return "TINYINT"; }
		}
		void IMySqlValue.WriteValue(MySqlStream stream, bool binary, object val, int length) {
			sbyte num = ((IConvertible)val).ToSByte(null);
			if (binary) {
				stream.WriteByte((byte)num);
			} else {
				stream.WriteStringNoNull(num.ToString());
			}
		}

		IMySqlValue IMySqlValue.ReadValue(MySqlStream stream, long length, bool nullVal) {
			if (nullVal) {
				return new MySqlByte(true);
			}
			if (length == -1L) {
				return new MySqlByte((sbyte)stream.ReadByte());
			}
			string s = stream.ReadString(length);
			MySqlByte num = new MySqlByte(sbyte.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture));
			num.TreatAsBoolean = this.TreatAsBoolean;
			return num;
		}

		void IMySqlValue.SkipValue(MySqlStream stream) {
			stream.ReadByte();
		}

		internal bool TreatAsBoolean {
			get { return this.treatAsBool; }
			set { this.treatAsBool = value; }
		}
		internal static void SetDSInfo(DataTable dsTable) {
			DataRow row = dsTable.NewRow();
			row["TypeName"] = "TINYINT";
			row["ProviderDbType"] = MySqlDbType.Byte;
			row["ColumnSize"] = 0;
			row["CreateFormat"] = "TINYINT";
			row["CreateParameters"] = null;
			row["DataType"] = "System.SByte";
			row["IsAutoincrementable"] = true;
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

