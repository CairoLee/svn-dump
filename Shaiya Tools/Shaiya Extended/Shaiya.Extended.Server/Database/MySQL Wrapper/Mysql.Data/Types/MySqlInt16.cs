namespace Shaiya.Extended.Server.MySql.Data.Types
{
    using Shaiya.Extended.Server.MySql.Data.MySqlClient;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal struct MySqlInt16 : IMySqlValue
    {
        private short mValue;
        private bool isNull;
        public MySqlInt16(bool isNull)
        {
            this.isNull = isNull;
            this.mValue = 0;
        }

        public MySqlInt16(short val)
        {
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
                return MySqlDbType.Int16;
            }
        }
        DbType IMySqlValue.DbType
        {
            get
            {
                return DbType.Int16;
            }
        }
        object IMySqlValue.Value
        {
            get
            {
                return this.mValue;
            }
        }
        public short Value
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
                return typeof(short);
            }
        }
        string IMySqlValue.MySqlTypeName
        {
            get
            {
                return "SMALLINT";
            }
        }
        void IMySqlValue.WriteValue(MySqlStream stream, bool binary, object val, int length)
        {
            int num = Convert.ToInt32(val);
            if (binary)
            {
                stream.Write(BitConverter.GetBytes(num));
            }
            else
            {
                stream.WriteStringNoNull(num.ToString());
            }
        }

        IMySqlValue IMySqlValue.ReadValue(MySqlStream stream, long length, bool nullVal)
        {
            if (nullVal)
            {
                return new MySqlInt16(true);
            }
            if (length == -1L)
            {
                return new MySqlInt16((short) stream.ReadInteger(2));
            }
            return new MySqlInt16(short.Parse(stream.ReadString(length)));
        }

        void IMySqlValue.SkipValue(MySqlStream stream)
        {
            stream.SkipBytes(2);
        }

        internal static void SetDSInfo(DataTable dsTable)
        {
            DataRow row = dsTable.NewRow();
            row["TypeName"] = "SMALLINT";
            row["ProviderDbType"] = MySqlDbType.Int16;
            row["ColumnSize"] = 0;
            row["CreateFormat"] = "SMALLINT";
            row["CreateParameters"] = null;
            row["DataType"] = "System.Int16";
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

