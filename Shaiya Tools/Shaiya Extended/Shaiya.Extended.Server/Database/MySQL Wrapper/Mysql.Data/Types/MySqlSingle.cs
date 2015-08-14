namespace Shaiya.Extended.Server.MySql.Data.Types
{
    using Shaiya.Extended.Server.MySql.Data.MySqlClient;
    using System;
    using System.Data;
    using System.Globalization;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal struct MySqlSingle : IMySqlValue
    {
        private float mValue;
        private bool isNull;
        public MySqlSingle(bool isNull)
        {
            this.isNull = isNull;
            this.mValue = 0f;
        }

        public MySqlSingle(float val)
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
                return MySqlDbType.Float;
            }
        }
        DbType IMySqlValue.DbType
        {
            get
            {
                return DbType.Single;
            }
        }
        object IMySqlValue.Value
        {
            get
            {
                return this.mValue;
            }
        }
        public float Value
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
                return typeof(float);
            }
        }
        string IMySqlValue.MySqlTypeName
        {
            get
            {
                return "FLOAT";
            }
        }
        void IMySqlValue.WriteValue(MySqlStream stream, bool binary, object val, int length)
        {
            float num = Convert.ToSingle(val);
            if (binary)
            {
                stream.Write(BitConverter.GetBytes(num));
            }
            else
            {
                stream.WriteStringNoNull(num.ToString("R", CultureInfo.InvariantCulture));
            }
        }

        IMySqlValue IMySqlValue.ReadValue(MySqlStream stream, long length, bool nullVal)
        {
            if (nullVal)
            {
                return new MySqlSingle(true);
            }
            if (length == -1L)
            {
                byte[] buffer = new byte[4];
                stream.Read(buffer, 0, 4);
                return new MySqlSingle(BitConverter.ToSingle(buffer, 0));
            }
            return new MySqlSingle(float.Parse(stream.ReadString(length), CultureInfo.InvariantCulture));
        }

        void IMySqlValue.SkipValue(MySqlStream stream)
        {
            stream.SkipBytes(4);
        }

        internal static void SetDSInfo(DataTable dsTable)
        {
            DataRow row = dsTable.NewRow();
            row["TypeName"] = "FLOAT";
            row["ProviderDbType"] = MySqlDbType.Float;
            row["ColumnSize"] = 0;
            row["CreateFormat"] = "FLOAT";
            row["CreateParameters"] = null;
            row["DataType"] = "System.Single";
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

