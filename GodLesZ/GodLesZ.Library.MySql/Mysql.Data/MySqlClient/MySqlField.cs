using GodLesZ.Library.MySql.Data.Common;
using GodLesZ.Library.MySql.Data.Types;
using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	internal class MySqlField {
		protected bool binaryOk;
		public string CatalogName;
		protected int charSetIndex;
		protected ColumnFlags colFlags;
		public int ColumnLength;
		public string ColumnName;
		protected MySqlConnection connection;
		protected DBVersion connVersion;
		public string DatabaseName;
		public System.Text.Encoding Encoding;
		public int maxLength;
		protected MySqlDbType mySqlDbType;
		public string OriginalColumnName;
		protected byte precision;
		public string RealTableName;
		protected byte scale;
		public string TableName;

		public MySqlField(MySqlConnection connection) {
			this.connection = connection;
			this.connVersion = connection.driver.Version;
			this.maxLength = 1;
			this.binaryOk = true;
		}

		private void CheckForExceptions() {
			string str = string.Empty;
			if (this.OriginalColumnName != null) {
				str = this.OriginalColumnName.ToLower(CultureInfo.InvariantCulture);
			}
			if (str.StartsWith("char(")) {
				this.binaryOk = false;
			} else if (this.connection.IsExecutingBuggyQuery) {
				this.binaryOk = false;
			}
		}

		public static IMySqlValue GetIMySqlValue(MySqlDbType type) {
			switch (type) {
				case MySqlDbType.Decimal:
				case MySqlDbType.NewDecimal:
					return new MySqlDecimal();

				case MySqlDbType.Byte:
					return new MySqlByte();

				case MySqlDbType.Int16:
					return new MySqlInt16();

				case MySqlDbType.Int32:
				case MySqlDbType.Int24:
				case MySqlDbType.Year:
					return new MySqlInt32(type, true);

				case MySqlDbType.Float:
					return new MySqlSingle();

				case MySqlDbType.Double:
					return new MySqlDouble();

				case (MySqlDbType.Float | MySqlDbType.Int16):
				case MySqlDbType.VarString:
				case MySqlDbType.Enum:
				case MySqlDbType.Set:
				case MySqlDbType.VarChar:
				case MySqlDbType.String:
				case MySqlDbType.TinyText:
				case MySqlDbType.MediumText:
				case MySqlDbType.LongText:
				case MySqlDbType.Text:
					return new MySqlString(type, true);

				case MySqlDbType.Timestamp:
				case MySqlDbType.Date:
				case MySqlDbType.DateTime:
				case MySqlDbType.Newdate:
					return new MySqlDateTime(type, true);

				case MySqlDbType.Int64:
					return new MySqlInt64();

				case MySqlDbType.Time:
					return new MySqlTimeSpan();

				case MySqlDbType.Bit:
					return new MySqlBit();

				case MySqlDbType.TinyBlob:
				case MySqlDbType.MediumBlob:
				case MySqlDbType.LongBlob:
				case MySqlDbType.Blob:
				case MySqlDbType.Geometry:
				case MySqlDbType.Binary:
				case MySqlDbType.VarBinary:
					return new MySqlBinary(type, true);

				case MySqlDbType.UByte:
					return new MySqlUByte();

				case MySqlDbType.UInt16:
					return new MySqlUInt16();

				case MySqlDbType.UInt32:
				case MySqlDbType.UInt24:
					return new MySqlUInt32(type, true);

				case MySqlDbType.UInt64:
					return new MySqlUInt64();
			}
			throw new MySqlException("Unknown data type");
		}

		public IMySqlValue GetValueObject() {
			IMySqlValue iMySqlValue = GetIMySqlValue(this.Type);
			if (((iMySqlValue is MySqlByte) && (this.ColumnLength == 1)) && ((this.MaxLength == 1) && this.connection.Settings.TreatTinyAsBoolean)) {
				MySqlByte num = (MySqlByte)iMySqlValue;
				num.TreatAsBoolean = true;
				return num;
			}
			if ((this.Type == MySqlDbType.Binary) && (this.ColumnLength == 0x10)) {
				MySqlBinary binary = (MySqlBinary)iMySqlValue;
				binary.IsGuid = true;
				iMySqlValue = binary;
			}
			return iMySqlValue;
		}

		public void SetTypeAndFlags(MySqlDbType type, ColumnFlags flags) {
			this.colFlags = flags;
			this.mySqlDbType = type;
			if ((string.IsNullOrEmpty(this.TableName) && string.IsNullOrEmpty(this.RealTableName)) && this.connection.Settings.FunctionsReturnString) {
				this.mySqlDbType = MySqlDbType.VarString;
				this.CharacterSetIndex = this.connection.driver.ConnectionCharSetIndex;
				this.binaryOk = false;
			}
			if (this.IsUnsigned) {
				switch (type) {
					case MySqlDbType.Byte:
						this.mySqlDbType = MySqlDbType.UByte;
						return;

					case MySqlDbType.Int16:
						this.mySqlDbType = MySqlDbType.UInt16;
						return;

					case MySqlDbType.Int32:
						this.mySqlDbType = MySqlDbType.UInt32;
						return;

					case MySqlDbType.Int64:
						this.mySqlDbType = MySqlDbType.UInt64;
						return;

					case MySqlDbType.Int24:
						this.mySqlDbType = MySqlDbType.UInt24;
						return;
				}
			}
			if (this.IsBlob) {
				if (this.IsBinary && this.connection.Settings.TreatBlobsAsUTF8) {
					bool flag = false;
					Regex regex = this.connection.Settings.BlobAsUTF8IncludeRegex;
					Regex regex2 = this.connection.Settings.BlobAsUTF8ExcludeRegex;
					if ((regex != null) && regex.IsMatch(this.ColumnName)) {
						flag = true;
					} else if (((regex == null) && (regex2 != null)) && !regex2.IsMatch(this.ColumnName)) {
						flag = true;
					}
					if (flag) {
						this.binaryOk = false;
						this.Encoding = System.Text.Encoding.GetEncoding("UTF-8");
						this.charSetIndex = -1;
						this.maxLength = 4;
					}
				}
				if (!this.IsBinary) {
					if (type == MySqlDbType.TinyBlob) {
						this.mySqlDbType = MySqlDbType.TinyText;
					} else if (type == MySqlDbType.MediumBlob) {
						this.mySqlDbType = MySqlDbType.MediumText;
					} else if (type == MySqlDbType.Blob) {
						this.mySqlDbType = MySqlDbType.Text;
					} else if (type == MySqlDbType.LongBlob) {
						this.mySqlDbType = MySqlDbType.LongText;
					}
				}
			}
			if (this.connection.Settings.RespectBinaryFlags) {
				this.CheckForExceptions();
			}
			if (this.IsBinary) {
				if (this.connection.Settings.RespectBinaryFlags) {
					if (type == MySqlDbType.String) {
						this.mySqlDbType = MySqlDbType.Binary;
					} else if ((type == MySqlDbType.VarChar) || (type == MySqlDbType.VarString)) {
						this.mySqlDbType = MySqlDbType.VarBinary;
					}
				}
				if (this.CharacterSetIndex == 0x3f) {
					this.CharacterSetIndex = this.connection.driver.ConnectionCharSetIndex;
				}
			}
		}

		public bool AllowsNull {
			get { return ((this.colFlags & ColumnFlags.NOT_NULL) == ((ColumnFlags)0)); }
		}

		public int CharacterSetIndex {
			get { return this.charSetIndex; }
			set { this.charSetIndex = value; }
		}

		public ColumnFlags Flags {
			get { return this.colFlags; }
		}

		public bool IsAutoIncrement {
			get { return ((this.colFlags & ColumnFlags.AUTO_INCREMENT) > ((ColumnFlags)0)); }
		}

		public bool IsBinary {
			get {
				if (this.connVersion.isAtLeast(4, 1, 0)) {
					return (this.binaryOk && (this.CharacterSetIndex == 0x3f));
				}
				return (this.binaryOk && ((this.colFlags & ColumnFlags.BINARY) > ((ColumnFlags)0)));
			}
		}

		public bool IsBlob {
			get {
				if (((this.mySqlDbType < MySqlDbType.TinyBlob) || (this.mySqlDbType > MySqlDbType.Blob)) && ((this.mySqlDbType < MySqlDbType.TinyText) || (this.mySqlDbType > MySqlDbType.Text))) {
					return ((this.colFlags & ColumnFlags.BLOB) > ((ColumnFlags)0));
				}
				return true;
			}
		}

		public bool IsNumeric {
			get { return ((this.colFlags & ColumnFlags.NUMBER) > ((ColumnFlags)0)); }
		}

		public bool IsPrimaryKey {
			get { return ((this.colFlags & ColumnFlags.PRIMARY_KEY) > ((ColumnFlags)0)); }
		}

		public bool IsTextField {
			get { return (((this.Type == MySqlDbType.VarString) || (this.Type == MySqlDbType.VarChar)) || (this.IsBlob && !this.IsBinary)); }
		}

		public bool IsUnique {
			get { return ((this.colFlags & ColumnFlags.UNIQUE_KEY) > ((ColumnFlags)0)); }
		}

		public bool IsUnsigned {
			get { return ((this.colFlags & ColumnFlags.UNSIGNED) > ((ColumnFlags)0)); }
		}

		public int MaxLength {
			get { return this.maxLength; }
			set { this.maxLength = value; }
		}

		public byte Precision {
			get { return this.precision; }
			set { this.precision = value; }
		}

		public byte Scale {
			get { return this.scale; }
			set { this.scale = value; }
		}

		public MySqlDbType Type {
			get { return this.mySqlDbType; }
		}
	}
}

