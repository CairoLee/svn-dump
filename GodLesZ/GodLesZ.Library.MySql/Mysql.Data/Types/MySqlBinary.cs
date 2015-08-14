using GodLesZ.Library.MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Runtime.InteropServices;

namespace GodLesZ.Library.MySql.Data.Types {

	[StructLayout(LayoutKind.Sequential)]
	internal struct MySqlBinary : IMySqlValue {
		private MySqlDbType type;
		private byte[] mValue;
		private bool isNull;
		internal bool IsGuid;
		public MySqlBinary(MySqlDbType type, bool isNull) {
			this.type = type;
			this.isNull = isNull;
			this.mValue = null;
			this.IsGuid = false;
		}

		public MySqlBinary(MySqlDbType type, byte[] val) {
			this.type = type;
			this.isNull = false;
			this.mValue = val;
			this.IsGuid = false;
		}

		public bool IsNull {
			get { return this.isNull; }
		}
		MySqlDbType IMySqlValue.MySqlDbType {
			get { return this.type; }
		}
		DbType IMySqlValue.DbType {
			get {
				if (!this.IsGuid) {
					return DbType.Binary;
				}
				return DbType.Guid;
			}
		}
		object IMySqlValue.Value {
			get {
				if (this.IsGuid) {
					return new Guid(this.mValue);
				}
				return this.mValue;
			}
		}
		public byte[] Value {
			get { return this.mValue; }
		}
		Type IMySqlValue.SystemType {
			get {
				if (!this.IsGuid) {
					return typeof(byte[]);
				}
				return typeof(Guid);
			}
		}
		string IMySqlValue.MySqlTypeName {
			get {
				switch (this.type) {
					case MySqlDbType.TinyBlob:
						return "TINY_BLOB";

					case MySqlDbType.MediumBlob:
						return "MEDIUM_BLOB";

					case MySqlDbType.LongBlob:
						return "LONG_BLOB";
				}
				return "BLOB";
			}
		}
		void IMySqlValue.WriteValue(MySqlStream stream, bool binary, object val, int length) {
			byte[] bytes = null;
			if (val is byte[]) {
				bytes = (byte[])val;
			} else if (val is char[]) {
				bytes = stream.Encoding.GetBytes(val as char[]);
			} else {
				string s = val.ToString();
				if (length == 0) {
					length = s.Length;
				} else {
					s = s.Substring(0, length);
				}
				bytes = stream.Encoding.GetBytes(s);
			}
			if (length == 0) {
				length = bytes.Length;
			}
			if (bytes == null) {
				throw new MySqlException("Only byte arrays and strings can be serialized by MySqlBinary");
			}
			if (binary) {
				stream.WriteLength((long)length);
				stream.Write(bytes, 0, length);
			} else {
				if (stream.Version.isAtLeast(4, 1, 0)) {
					stream.WriteStringNoNull("_binary ");
				}
				stream.WriteByte(0x27);
				this.EscapeByteArray(bytes, length, stream);
				stream.WriteByte(0x27);
			}
		}

		private void EscapeByteArray(byte[] bytes, int length, MySqlStream stream) {
			for (int i = 0; i < length; i++) {
				byte num2 = bytes[i];
				switch (num2) {
					case 0:
						stream.WriteByte(0x5c);
						stream.WriteByte(0x30);
						break;

					case 0x5c:
					case 0x27:
					case 0x22:
						stream.WriteByte(0x5c);
						stream.WriteByte(num2);
						break;

					default:
						stream.WriteByte(num2);
						break;
				}
			}
		}

		IMySqlValue IMySqlValue.ReadValue(MySqlStream stream, long length, bool nullVal) {
			MySqlBinary binary;
			if (nullVal) {
				binary = new MySqlBinary(this.type, true);
			} else {
				if (length == -1L) {
					length = stream.ReadFieldLength();
				}
				byte[] buffer = new byte[length];
				stream.Read(buffer, 0, (int)length);
				binary = new MySqlBinary(this.type, buffer);
			}
			binary.IsGuid = this.IsGuid;
			return binary;
		}

		void IMySqlValue.SkipValue(MySqlStream stream) {
			long num = stream.ReadFieldLength();
			stream.SkipBytes((int)num);
		}

		public static void SetDSInfo(DataTable dsTable) {
			string[] strArray = new string[] { "BLOB", "TINYBLOB", "MEDIUMBLOB", "LONGBLOB" };
			MySqlDbType[] typeArray = new MySqlDbType[] { MySqlDbType.Blob, MySqlDbType.TinyBlob, MySqlDbType.MediumBlob, MySqlDbType.LongBlob };
			for (int i = 0; i < strArray.Length; i++) {
				DataRow row = dsTable.NewRow();
				row["TypeName"] = strArray[i];
				row["ProviderDbType"] = typeArray[i];
				row["ColumnSize"] = 0;
				row["CreateFormat"] = strArray[i];
				row["CreateParameters"] = null;
				row["DataType"] = "System.Byte[]";
				row["IsAutoincrementable"] = false;
				row["IsBestMatch"] = true;
				row["IsCaseSensitive"] = false;
				row["IsFixedLength"] = false;
				row["IsFixedPrecisionScale"] = true;
				row["IsLong"] = true;
				row["IsNullable"] = true;
				row["IsSearchable"] = true;
				row["IsSearchableWithLike"] = true;
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
}

