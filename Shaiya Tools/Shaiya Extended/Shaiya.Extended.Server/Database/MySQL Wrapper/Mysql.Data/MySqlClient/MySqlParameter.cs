namespace Shaiya.Extended.Server.MySql.Data.MySqlClient
{
    using Shaiya.Extended.Server.MySql.Data.Types;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Common;

    [TypeConverter(typeof(MySqlParameterConverter))]
    public sealed class MySqlParameter : DbParameter, IDbDataParameter, IDataParameter, ICloneable
    {
        private MySqlParameterCollection collection;
        private System.Data.DbType dbType;
        private ParameterDirection direction;
        private bool inferType;
        private bool isNullable;
        private Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType mySqlDbType;
        private string paramName;
        private object paramValue;
        private byte precision;
        private byte scale;
        private int size;
        private string sourceColumn;
        private bool sourceColumnNullMapping;
        private DataRowVersion sourceVersion;
        private const int UNSIGNED_MASK = 0x8000;

        public MySqlParameter()
        {
            this.direction = ParameterDirection.Input;
            this.sourceVersion = DataRowVersion.Current;
            this.inferType = true;
        }

        public MySqlParameter(string parameterName, Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType dbType) : this(parameterName, null)
        {
            this.MySqlDbType = dbType;
        }

        public MySqlParameter(string parameterName, object value) : this()
        {
            this.ParameterName = parameterName;
            this.Value = value;
        }

        public MySqlParameter(string parameterName, Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType dbType, int size) : this(parameterName, dbType)
        {
            this.size = size;
        }

        public MySqlParameter(string parameterName, Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType dbType, int size, string sourceColumn) : this(parameterName, dbType)
        {
            this.size = size;
            this.direction = ParameterDirection.Input;
            this.sourceColumn = sourceColumn;
            this.sourceVersion = DataRowVersion.Current;
        }

        internal MySqlParameter(string name, Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType type, ParameterDirection dir, string col, DataRowVersion ver, object val) : this(name, type)
        {
            this.direction = dir;
            this.sourceColumn = col;
            this.sourceVersion = ver;
            this.Value = val;
        }

        public MySqlParameter(string parameterName, Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType dbType, int size, ParameterDirection direction, bool isNullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value) : this(parameterName, dbType, size, sourceColumn)
        {
            this.direction = direction;
            this.sourceVersion = sourceVersion;
            this.Value = value;
        }

        internal long EstimatedSize()
        {
            if ((this.Value == null) || (this.Value == DBNull.Value))
            {
                return 4L;
            }
            if (this.Value is byte[])
            {
                return (long) (this.Value as byte[]).Length;
            }
            if (this.Value is string)
            {
                return (long) ((this.Value as string).Length * 4);
            }
            if ((this.Value is decimal) || (this.Value is float))
            {
                return 0x40L;
            }
            return 0x20L;
        }

        internal int GetPSType()
        {
            switch (this.mySqlDbType)
            {
                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.UByte:
                    return 0x8001;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.UInt16:
                    return 0x8002;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.UInt32:
                    return 0x8003;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.UInt64:
                    return 0x8008;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.UInt24:
                    return 0x8003;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Bit:
                    return 0x8008;
            }
            return (int) this.mySqlDbType;
        }

        public override void ResetDbType()
        {
            this.inferType = true;
        }

        internal void Serialize(MySqlStream stream, bool binary)
        {
            IMySqlValue iMySqlValue = MySqlField.GetIMySqlValue(this.mySqlDbType);
            if (!binary && ((this.paramValue == null) || (this.paramValue == DBNull.Value)))
            {
                stream.WriteStringNoNull("NULL");
            }
            else
            {
                iMySqlValue.WriteValue(stream, binary, this.paramValue, this.size);
            }
        }

        private void SetDbType(System.Data.DbType db_type)
        {
            this.dbType = db_type;
            switch (this.dbType)
            {
                case System.Data.DbType.AnsiString:
                case System.Data.DbType.Guid:
                case System.Data.DbType.String:
                    this.mySqlDbType = Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.VarChar;
                    return;

                case System.Data.DbType.Byte:
                case System.Data.DbType.Boolean:
                    this.mySqlDbType = Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.UByte;
                    return;

                case System.Data.DbType.Currency:
                case System.Data.DbType.Decimal:
                    this.mySqlDbType = Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Decimal;
                    return;

                case System.Data.DbType.Date:
                    this.mySqlDbType = Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Date;
                    return;

                case System.Data.DbType.DateTime:
                    this.mySqlDbType = Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.DateTime;
                    return;

                case System.Data.DbType.Double:
                    this.mySqlDbType = Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Double;
                    return;

                case System.Data.DbType.Int16:
                    this.mySqlDbType = Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Int16;
                    return;

                case System.Data.DbType.Int32:
                    this.mySqlDbType = Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Int32;
                    return;

                case System.Data.DbType.Int64:
                    this.mySqlDbType = Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Int64;
                    return;

                case System.Data.DbType.SByte:
                    this.mySqlDbType = Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Byte;
                    return;

                case System.Data.DbType.Single:
                    this.mySqlDbType = Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Float;
                    return;

                case System.Data.DbType.Time:
                    this.mySqlDbType = Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Time;
                    return;

                case System.Data.DbType.UInt16:
                    this.mySqlDbType = Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.UInt16;
                    return;

                case System.Data.DbType.UInt32:
                    this.mySqlDbType = Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.UInt32;
                    return;

                case System.Data.DbType.UInt64:
                    this.mySqlDbType = Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.UInt64;
                    return;

                case System.Data.DbType.AnsiStringFixedLength:
                case System.Data.DbType.StringFixedLength:
                    this.mySqlDbType = Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.String;
                    return;
            }
            this.mySqlDbType = Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Blob;
        }

        private void SetMySqlDbType(Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType mysql_dbtype)
        {
            this.mySqlDbType = mysql_dbtype;
            switch (this.mySqlDbType)
            {
                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Decimal:
                    this.dbType = System.Data.DbType.Decimal;
                    return;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Byte:
                    this.dbType = System.Data.DbType.SByte;
                    return;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Int16:
                    this.dbType = System.Data.DbType.Int16;
                    return;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Int32:
                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Int24:
                    this.dbType = System.Data.DbType.Int32;
                    return;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Float:
                    this.dbType = System.Data.DbType.Single;
                    return;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Double:
                    this.dbType = System.Data.DbType.Double;
                    return;

                case (Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Float | Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Int16):
                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.VarString:
                case ((Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType) 0x1f8):
                case ((Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType) 0x1f9):
                case ((Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType) 0x1fa):
                case ((Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType) 0x1fb):
                    break;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Timestamp:
                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.DateTime:
                    this.dbType = System.Data.DbType.DateTime;
                    return;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Int64:
                    this.dbType = System.Data.DbType.Int64;
                    return;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Date:
                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Year:
                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Newdate:
                    this.dbType = System.Data.DbType.Date;
                    return;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Time:
                    this.dbType = System.Data.DbType.Time;
                    return;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Bit:
                    this.dbType = System.Data.DbType.UInt64;
                    return;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Enum:
                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Set:
                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.VarChar:
                    this.dbType = System.Data.DbType.String;
                    return;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.TinyBlob:
                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.MediumBlob:
                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.LongBlob:
                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.Blob:
                    this.dbType = System.Data.DbType.Object;
                    return;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.String:
                    this.dbType = System.Data.DbType.StringFixedLength;
                    break;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.UByte:
                    this.dbType = System.Data.DbType.Byte;
                    return;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.UInt16:
                    this.dbType = System.Data.DbType.UInt16;
                    return;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.UInt32:
                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.UInt24:
                    this.dbType = System.Data.DbType.UInt32;
                    return;

                case Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType.UInt64:
                    this.dbType = System.Data.DbType.UInt64;
                    return;

                default:
                    return;
            }
        }

        private void SetTypeFromValue()
        {
            if ((this.paramValue != null) && (this.paramValue != DBNull.Value))
            {
                if (this.paramValue is Guid)
                {
                    this.DbType = System.Data.DbType.String;
                }
                else if (this.paramValue is TimeSpan)
                {
                    this.DbType = System.Data.DbType.Time;
                }
                else if (this.paramValue is bool)
                {
                    this.DbType = System.Data.DbType.Byte;
                }
                else
                {
                    switch (Type.GetTypeCode(this.paramValue.GetType()))
                    {
                        case TypeCode.SByte:
                            this.DbType = System.Data.DbType.SByte;
                            return;

                        case TypeCode.Byte:
                            this.DbType = System.Data.DbType.Byte;
                            return;

                        case TypeCode.Int16:
                            this.DbType = System.Data.DbType.Int16;
                            return;

                        case TypeCode.UInt16:
                            this.DbType = System.Data.DbType.UInt16;
                            return;

                        case TypeCode.Int32:
                            this.DbType = System.Data.DbType.Int32;
                            return;

                        case TypeCode.UInt32:
                            this.DbType = System.Data.DbType.UInt32;
                            return;

                        case TypeCode.Int64:
                            this.DbType = System.Data.DbType.Int64;
                            return;

                        case TypeCode.UInt64:
                            this.DbType = System.Data.DbType.UInt64;
                            return;

                        case TypeCode.Single:
                            this.DbType = System.Data.DbType.Single;
                            return;

                        case TypeCode.Double:
                            this.DbType = System.Data.DbType.Double;
                            return;

                        case TypeCode.Decimal:
                            this.DbType = System.Data.DbType.Decimal;
                            return;

                        case TypeCode.DateTime:
                            this.DbType = System.Data.DbType.DateTime;
                            return;

                        case TypeCode.String:
                            this.DbType = System.Data.DbType.String;
                            return;
                    }
                    this.DbType = System.Data.DbType.Object;
                }
            }
        }

        object ICloneable.Clone()
        {
            MySqlParameter parameter = new MySqlParameter(this.paramName, this.mySqlDbType, this.direction, this.sourceColumn, this.sourceVersion, this.paramValue);
            parameter.inferType = this.inferType;
            return parameter;
        }

        public override string ToString()
        {
            return this.paramName;
        }

        internal MySqlParameterCollection Collection
        {
            get
            {
                return this.collection;
            }
            set
            {
                this.collection = value;
            }
        }

        public override System.Data.DbType DbType
        {
            get
            {
                return this.dbType;
            }
            set
            {
                this.SetDbType(value);
                this.inferType = false;
            }
        }

        [Category("Data")]
        public override ParameterDirection Direction
        {
            get
            {
                return this.direction;
            }
            set
            {
                this.direction = value;
            }
        }

        [Browsable(false)]
        public override bool IsNullable
        {
            get
            {
                return this.isNullable;
            }
            set
            {
                this.isNullable = value;
            }
        }

        [Category("Data"), DbProviderSpecificTypeProperty(true)]
        public Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType MySqlDbType
        {
            get
            {
                return this.mySqlDbType;
            }
            set
            {
                this.SetMySqlDbType(value);
                this.inferType = false;
            }
        }

        [Category("Misc")]
        public override string ParameterName
        {
            get
            {
                return this.paramName;
            }
            set
            {
                if (this.collection != null)
                {
                    this.collection.ParameterNameChanged(this, this.paramName, value);
                }
                this.paramName = value;
            }
        }

        [Category("Data")]
        public byte Precision
        {
            get
            {
                return this.precision;
            }
            set
            {
                this.precision = value;
            }
        }

        [Category("Data")]
        public byte Scale
        {
            get
            {
                return this.scale;
            }
            set
            {
                this.scale = value;
            }
        }

        [Category("Data")]
        public override int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }

        [Category("Data")]
        public override string SourceColumn
        {
            get
            {
                return this.sourceColumn;
            }
            set
            {
                this.sourceColumn = value;
            }
        }

        public override bool SourceColumnNullMapping
        {
            get
            {
                return this.sourceColumnNullMapping;
            }
            set
            {
                this.sourceColumnNullMapping = value;
            }
        }

        [Category("Data")]
        public override DataRowVersion SourceVersion
        {
            get
            {
                return this.sourceVersion;
            }
            set
            {
                this.sourceVersion = value;
            }
        }

        internal bool TypeHasBeenSet
        {
            get
            {
                return !this.inferType;
            }
        }

        [TypeConverter(typeof(StringConverter)), Category("Data")]
        public override object Value
        {
            get
            {
                return this.paramValue;
            }
            set
            {
                this.paramValue = value;
                if (value is byte[])
                {
                    this.size = (value as byte[]).Length;
                }
                else if (value is string)
                {
                    this.size = (value as string).Length;
                }
                if (this.inferType)
                {
                    this.SetTypeFromValue();
                }
            }
        }
    }
}

