namespace Shaiya.Extended.Server.MySql.Data.Types
{
    using Shaiya.Extended.Server.MySql.Data.MySqlClient;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal struct MySqlString : IMySqlValue
    {
        private string mValue;
        private bool isNull;
        private MySqlDbType type;
        public MySqlString(MySqlDbType type, bool isNull)
        {
            this.type = type;
            this.isNull = isNull;
            this.mValue = string.Empty;
        }

        public MySqlString(MySqlDbType type, string val)
        {
            this.type = type;
            this.isNull = false;
            this.mValue = val;
        }

        public bool IsNull
        {
            get
            {
                return this.isNull;
            }
        }
        MySqlDbType IMySqlValue.MySqlDbType
        {
            get
            {
                return this.type;
            }
        }
        DbType IMySqlValue.DbType
        {
            get
            {
                return DbType.String;
            }
        }
        object IMySqlValue.Value
        {
            get
            {
                return this.mValue;
            }
        }
        public string Value
        {
            get
            {
                return this.mValue;
            }
        }
        Type IMySqlValue.SystemType
        {
            get
            {
                return typeof(string);
            }
        }
        string IMySqlValue.MySqlTypeName
        {
            get
            {
                if (this.type == MySqlDbType.Set)
                {
                    return "SET";
                }
                if (this.type != MySqlDbType.Enum)
                {
                    return "VARCHAR";
                }
                return "ENUM";
            }
        }
        void IMySqlValue.WriteValue(MySqlStream stream, bool binary, object val, int length)
        {
            string s = val.ToString();
            if (length > 0)
            {
                length = Math.Min(length, s.Length);
                s = s.Substring(0, length);
            }
            if (binary)
            {
                stream.WriteLenString(s);
            }
            else
            {
                stream.WriteStringNoNull("'" + MySqlHelper.EscapeString(s) + "'");
            }
        }

        IMySqlValue IMySqlValue.ReadValue(MySqlStream stream, long length, bool nullVal)
        {
            if (nullVal)
            {
                return new MySqlString(this.type, true);
            }
            string val = string.Empty;
            if (length == -1L)
            {
                val = stream.ReadLenString();
            }
            else
            {
                val = stream.ReadString(length);
            }
            return new MySqlString(this.type, val);
        }

        void IMySqlValue.SkipValue(MySqlStream stream)
        {
            long num = stream.ReadFieldLength();
            stream.SkipBytes((int) num);
        }

        internal static void SetDSInfo(DataTable dsTable)
        {
            string[] strArray = new string[] { "CHAR", "VARCHAR", "SET", "ENUM", "TINYTEXT", "TEXT", "MEDIUMTEXT", "LONGTEXT" };
            MySqlDbType[] typeArray = new MySqlDbType[] { MySqlDbType.String, MySqlDbType.VarChar, MySqlDbType.Set, MySqlDbType.Enum, MySqlDbType.TinyText, MySqlDbType.Text, MySqlDbType.MediumText, MySqlDbType.LongText };
            for (int i = 0; i < strArray.Length; i++)
            {
                DataRow row = dsTable.NewRow();
                row["TypeName"] = strArray[i];
                row["ProviderDbType"] = typeArray[i];
                row["ColumnSize"] = 0;
                row["CreateFormat"] = (i < 2) ? (strArray[i] + "({0})") : strArray[i];
                row["CreateParameters"] = (i < 2) ? "size" : null;
                row["DataType"] = "System.String";
                row["IsAutoincrementable"] = false;
                row["IsBestMatch"] = true;
                row["IsCaseSensitive"] = false;
                row["IsFixedLength"] = false;
                row["IsFixedPrecisionScale"] = true;
                row["IsLong"] = false;
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

