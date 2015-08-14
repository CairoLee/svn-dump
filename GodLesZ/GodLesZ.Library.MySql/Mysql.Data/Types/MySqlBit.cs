using GodLesZ.Library.MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Runtime.InteropServices;

namespace GodLesZ.Library.MySql.Data.Types {

	[StructLayout(LayoutKind.Sequential)]
	internal struct MySqlBit : IMySqlValue {
		private ulong mValue;
		private bool isNull;
		private byte[] buffer;
		public MySqlBit(bool isnull) {
			this.mValue = 0L;
			this.isNull = isnull;
			this.buffer = new byte[8];
		}

		public bool IsNull {
			get { return this.isNull; }
		}
		MySqlDbType IMySqlValue.MySqlDbType {
			get { return MySqlDbType.Bit; }
		}
		DbType IMySqlValue.DbType {
			get { return DbType.UInt64; }
		}
		object IMySqlValue.Value {
			get { return this.mValue; }
		}
		Type IMySqlValue.SystemType {
			get { return typeof(ulong); }
		}
		string IMySqlValue.MySqlTypeName {
			get { return "BIT"; }
		}
		public void WriteValue(MySqlStream stream, bool binary, object value, int length) {
			ulong num = Convert.ToUInt64(value);
			if (binary) {
				stream.Write(BitConverter.GetBytes(num));
			} else {
				stream.WriteStringNoNull(num.ToString());
			}
		}

		public IMySqlValue ReadValue(MySqlStream stream, long length, bool isNull) {
			this.isNull = isNull;
			if (!isNull) {
				if (this.buffer == null) {
					this.buffer = new byte[8];
				}
				if (length == -1L) {
					length = stream.ReadFieldLength();
				}
				Array.Clear(this.buffer, 0, this.buffer.Length);
				for (long i = length - 1L; i >= 0L; i -= 1L) {
					this.buffer[(int)((IntPtr)i)] = (byte)stream.ReadByte();
				}
				this.mValue = BitConverter.ToUInt64(this.buffer, 0);
			}
			return this;
		}

		public void SkipValue(MySqlStream stream) {
			long num = stream.ReadFieldLength();
			stream.SkipBytes((int)num);
		}

		public static void SetDSInfo(DataTable dsTable) {
			DataRow row = dsTable.NewRow();
			row["TypeName"] = "BIT";
			row["ProviderDbType"] = MySqlDbType.Bit;
			row["ColumnSize"] = 0x40;
			row["CreateFormat"] = "BIT";
			row["CreateParameters"] = null;
			row["DataType"] = typeof(ulong).ToString();
			row["IsAutoincrementable"] = false;
			row["IsBestMatch"] = true;
			row["IsCaseSensitive"] = false;
			row["IsFixedLength"] = false;
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

