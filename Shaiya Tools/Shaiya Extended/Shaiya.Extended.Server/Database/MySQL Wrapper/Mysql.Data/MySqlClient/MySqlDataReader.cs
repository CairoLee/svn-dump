namespace Shaiya.Extended.Server.MySql.Data.MySqlClient
{
    using Shaiya.Extended.Server.MySql.Data.MySqlClient.Properties;
    using Shaiya.Extended.Server.MySql.Data.Types;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlTypes;
    using System.Reflection;

    public sealed class MySqlDataReader : DbDataReader, IDataReader, IDisposable, IDataRecord
    {
        private long affectedRows;
        private bool canRead;
        private MySqlCommand command;
        private CommandBehavior commandBehavior;
        private MySqlConnection connection;
        private Driver driver;
        private Hashtable fieldHashCI;
        private Hashtable fieldHashCS;
        private MySqlField[] fields;
        private bool hasRead;
        private bool hasRows;
        private bool isOpen = true;
        private long lastInsertId;
        private bool nextResultDone;
        private int seqIndex;
        private PreparableStatement statement;
        private bool[] uaFieldsUsed;
        internal IMySqlValue[] values;

        internal MySqlDataReader(MySqlCommand cmd, PreparableStatement statement, CommandBehavior behavior)
        {
            this.command = cmd;
            this.connection = this.command.Connection;
            this.commandBehavior = behavior;
            this.driver = this.connection.driver;
            this.affectedRows = -1L;
            this.statement = statement;
            this.nextResultDone = false;
            this.fieldHashCS = new Hashtable();
            this.fieldHashCI = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
        }

        private void ClearCurrentResultset()
        {
            if (this.canRead)
            {
                while (this.driver.SkipDataRow())
                {
                }
                if (this.connection.Settings.UseUsageAdvisor)
                {
                    if (this.canRead)
                    {
                        this.connection.UsageAdvisor.ReadPartialResultSet(this.command.CommandText);
                    }
                    bool flag = true;
                    foreach (bool flag2 in this.uaFieldsUsed)
                    {
                        flag &= flag2;
                    }
                    if (!flag)
                    {
                        this.connection.UsageAdvisor.ReadPartialRowSet(this.command.CommandText, this.uaFieldsUsed, this.fields);
                    }
                }
            }
        }

        public override void Close()
        {
            if (this.isOpen)
            {
                bool flag = (this.commandBehavior & CommandBehavior.CloseConnection) != CommandBehavior.Default;
                this.commandBehavior = CommandBehavior.Default;
                this.connection.Reader = null;
                if (!this.nextResultDone)
                {
                    while (this.NextResult())
                    {
                    }
                }
                this.command.Close();
                if (flag)
                {
                    this.connection.Close();
                }
                this.command = null;
                this.connection = null;
                this.isOpen = false;
            }
        }

        public override bool GetBoolean(int i)
        {
            return Convert.ToBoolean(this.GetValue(i));
        }

        public bool GetBoolean(string name)
        {
            return this.GetBoolean(this.GetOrdinal(name));
        }

        public override byte GetByte(int i)
        {
            IMySqlValue fieldValue = this.GetFieldValue(i, false);
            if (fieldValue is MySqlUByte)
            {
                MySqlUByte num = (MySqlUByte) fieldValue;
                return num.Value;
            }
            MySqlByte num2 = (MySqlByte) fieldValue;
            return (byte) num2.Value;
        }

        public byte GetByte(string name)
        {
            return this.GetByte(this.GetOrdinal(name));
        }

        public override long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            if (i >= this.fields.Length)
            {
                throw new IndexOutOfRangeException();
            }
            IMySqlValue fieldValue = this.GetFieldValue(i, false);
            if (!(fieldValue is MySqlBinary))
            {
                throw new MySqlException("GetBytes can only be called on binary columns");
            }
            MySqlBinary binary = (MySqlBinary) fieldValue;
            if (buffer == null)
            {
                return (long) binary.Value.Length;
            }
            if ((bufferoffset >= buffer.Length) || (bufferoffset < 0))
            {
                throw new IndexOutOfRangeException("Buffer index must be a valid index in buffer");
            }
            if (buffer.Length < (bufferoffset + length))
            {
                throw new ArgumentException("Buffer is not large enough to hold the requested data");
            }
            if ((fieldOffset < 0L) || ((fieldOffset >= binary.Value.Length) && (binary.Value.Length > 0L)))
            {
                throw new IndexOutOfRangeException("Data index must be a valid index in the field");
            }
            byte[] src = binary.Value;
            if (binary.Value.Length < (fieldOffset + length))
            {
                length = binary.Value.Length - ((int) fieldOffset);
            }
            Buffer.BlockCopy(src, (int) fieldOffset, buffer, bufferoffset, length);
            return (long) length;
        }

        public override char GetChar(int i)
        {
            return this.GetString(i)[0];
        }

        public char GetChar(string name)
        {
            return this.GetChar(this.GetOrdinal(name));
        }

        public override long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            if (i >= this.fields.Length)
            {
                throw new IndexOutOfRangeException();
            }
            string str = this.GetString(i);
            if (buffer == null)
            {
                return (long) str.Length;
            }
            if ((bufferoffset >= buffer.Length) || (bufferoffset < 0))
            {
                throw new IndexOutOfRangeException("Buffer index must be a valid index in buffer");
            }
            if (buffer.Length < (bufferoffset + length))
            {
                throw new ArgumentException("Buffer is not large enough to hold the requested data");
            }
            if ((fieldoffset < 0L) || (fieldoffset >= str.Length))
            {
                throw new IndexOutOfRangeException("Field offset must be a valid index in the field");
            }
            if (str.Length < length)
            {
                length = str.Length;
            }
            str.CopyTo((int) fieldoffset, buffer, bufferoffset, length);
            return (long) length;
        }

        public override string GetDataTypeName(int i)
        {
            if (!this.isOpen)
            {
                throw new Exception("No current query in data reader");
            }
            if (i >= this.fields.Length)
            {
                throw new IndexOutOfRangeException();
            }
            return this.values[i].MySqlTypeName;
        }

        public override DateTime GetDateTime(int i)
        {
            MySqlDateTime time;
            IMySqlValue fieldValue = this.GetFieldValue(i, true);
            if (fieldValue is MySqlDateTime)
            {
                time = (MySqlDateTime) fieldValue;
            }
            else
            {
                time = MySqlDateTime.Parse(this.GetString(i), this.connection.driver.Version);
            }
            if (this.connection.Settings.ConvertZeroDateTime && !time.IsValidDateTime)
            {
                return DateTime.MinValue;
            }
            return time.GetDateTime();
        }

        public DateTime GetDateTime(string column)
        {
            return this.GetDateTime(this.GetOrdinal(column));
        }

        public override decimal GetDecimal(int i)
        {
            IMySqlValue fieldValue = this.GetFieldValue(i, true);
            if (fieldValue is MySqlDecimal)
            {
                MySqlDecimal num = (MySqlDecimal) fieldValue;
                return num.Value;
            }
            return Convert.ToDecimal(fieldValue.Value);
        }

        public decimal GetDecimal(string column)
        {
            return this.GetDecimal(this.GetOrdinal(column));
        }

        public override double GetDouble(int i)
        {
            IMySqlValue fieldValue = this.GetFieldValue(i, true);
            if (fieldValue is MySqlDouble)
            {
                MySqlDouble num = (MySqlDouble) fieldValue;
                return num.Value;
            }
            return Convert.ToDouble(fieldValue.Value);
        }

        public double GetDouble(string column)
        {
            return this.GetDouble(this.GetOrdinal(column));
        }

        public override IEnumerator GetEnumerator()
        {
            return new DbEnumerator(this, (this.commandBehavior & CommandBehavior.CloseConnection) != CommandBehavior.Default);
        }

        public override Type GetFieldType(int i)
        {
            if (!this.isOpen)
            {
                throw new Exception("No current query in data reader");
            }
            if (i >= this.fields.Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (!(this.values[i] is MySqlDateTime))
            {
                return this.values[i].SystemType;
            }
            if (!this.connection.Settings.AllowZeroDateTime)
            {
                return typeof(DateTime);
            }
            return typeof(MySqlDateTime);
        }

        private IMySqlValue GetFieldValue(int index, bool checkNull)
        {
            if ((index < 0) || (index >= this.fields.Length))
            {
                throw new ArgumentException("You have specified an invalid column ordinal.");
            }
            if (!this.hasRead)
            {
                throw new MySqlException("Invalid attempt to access a field before calling Read()");
            }
            this.uaFieldsUsed[index] = true;
            if (((this.commandBehavior & CommandBehavior.SequentialAccess) != CommandBehavior.Default) && (index != this.seqIndex))
            {
                if (index < this.seqIndex)
                {
                    throw new MySqlException("Invalid attempt to read a prior column using SequentialAccess");
                }
                while (this.seqIndex < (index - 1))
                {
                    this.driver.SkipColumnValue(this.values[++this.seqIndex]);
                }
                this.values[index] = this.driver.ReadColumnValue(index, this.fields[index], this.values[index]);
                this.seqIndex = index;
            }
            IMySqlValue value2 = this.values[index];
            if (checkNull && value2.IsNull)
            {
                throw new SqlNullValueException();
            }
            return value2;
        }

        public override float GetFloat(int i)
        {
            IMySqlValue fieldValue = this.GetFieldValue(i, true);
            if (fieldValue is MySqlSingle)
            {
                MySqlSingle num = (MySqlSingle) fieldValue;
                return num.Value;
            }
            return Convert.ToSingle(fieldValue.Value);
        }

        public float GetFloat(string column)
        {
            return this.GetFloat(this.GetOrdinal(column));
        }

        public override Guid GetGuid(int i)
        {
            return new Guid(this.GetString(i));
        }

        public Guid GetGuid(string column)
        {
            return this.GetGuid(this.GetOrdinal(column));
        }

        public override short GetInt16(int i)
        {
            IMySqlValue fieldValue = this.GetFieldValue(i, true);
            if (fieldValue is MySqlInt16)
            {
                MySqlInt16 num = (MySqlInt16) fieldValue;
                return num.Value;
            }
            this.connection.UsageAdvisor.Converting(this.command.CommandText, this.fields[i].ColumnName, fieldValue.MySqlTypeName, "Int16");
            return ((IConvertible) fieldValue.Value).ToInt16(null);
        }

        public short GetInt16(string column)
        {
            return this.GetInt16(this.GetOrdinal(column));
        }

        public override int GetInt32(int i)
        {
            IMySqlValue fieldValue = this.GetFieldValue(i, true);
            if (fieldValue is MySqlInt32)
            {
                MySqlInt32 num = (MySqlInt32) fieldValue;
                return num.Value;
            }
            this.connection.UsageAdvisor.Converting(this.command.CommandText, this.fields[i].ColumnName, fieldValue.MySqlTypeName, "Int32");
            return ((IConvertible) fieldValue.Value).ToInt32(null);
        }

        public int GetInt32(string column)
        {
            return this.GetInt32(this.GetOrdinal(column));
        }

        public override long GetInt64(int i)
        {
            IMySqlValue fieldValue = this.GetFieldValue(i, true);
            if (fieldValue is MySqlInt64)
            {
                MySqlInt64 num = (MySqlInt64) fieldValue;
                return num.Value;
            }
            this.connection.UsageAdvisor.Converting(this.command.CommandText, this.fields[i].ColumnName, fieldValue.MySqlTypeName, "Int64");
            return ((IConvertible) fieldValue.Value).ToInt64(null);
        }

        public long GetInt64(string column)
        {
            return this.GetInt64(this.GetOrdinal(column));
        }

        public MySqlDateTime GetMySqlDateTime(int column)
        {
            return (MySqlDateTime) this.GetFieldValue(column, true);
        }

        public MySqlDateTime GetMySqlDateTime(string column)
        {
            return this.GetMySqlDateTime(this.GetOrdinal(column));
        }

        public override string GetName(int i)
        {
            return this.fields[i].ColumnName;
        }

        public override int GetOrdinal(string name)
        {
            if (!this.isOpen)
            {
                throw new Exception("No current query in data reader");
            }
            object obj2 = this.fieldHashCS[name];
            if (obj2 == null)
            {
                obj2 = this.fieldHashCI[name];
                if (obj2 == null)
                {
                    throw new IndexOutOfRangeException("Could not find specified column in results");
                }
            }
            return (int) obj2;
        }

        private long GetResultSet()
        {
            ulong num;
        Label_0000:
            num = 0L;
            long num2 = this.driver.ReadResult(ref num, ref this.lastInsertId);
            if (num2 > 0L)
            {
                return num2;
            }
            if (num2 == 0L)
            {
                this.command.lastInsertedId = this.lastInsertId;
                if (this.affectedRows == -1L)
                {
                    this.affectedRows = (long) num;
                }
                else
                {
                    this.affectedRows += (long) num;
                }
                goto Label_0000;
            }
            if ((num2 != -1L) || this.statement.ExecuteNext())
            {
                goto Label_0000;
            }
            return -1L;
        }

        public sbyte GetSByte(int i)
        {
            IMySqlValue fieldValue = this.GetFieldValue(i, false);
            if (fieldValue is MySqlByte)
            {
                MySqlByte num = (MySqlByte) fieldValue;
                return num.Value;
            }
            MySqlByte num2 = (MySqlByte) fieldValue;
            return num2.Value;
        }

        public byte GetSByte(string name)
        {
            return this.GetByte(this.GetOrdinal(name));
        }

        public override DataTable GetSchemaTable()
        {
            if ((this.fields == null) || (this.fields.Length == 0))
            {
                return null;
            }
            DataTable table = new DataTable("SchemaTable");
            table.Columns.Add("ColumnName", typeof(string));
            table.Columns.Add("ColumnOrdinal", typeof(int));
            table.Columns.Add("ColumnSize", typeof(int));
            table.Columns.Add("NumericPrecision", typeof(int));
            table.Columns.Add("NumericScale", typeof(int));
            table.Columns.Add("IsUnique", typeof(bool));
            table.Columns.Add("IsKey", typeof(bool));
            DataColumn column = table.Columns["IsKey"];
            column.AllowDBNull = true;
            table.Columns.Add("BaseCatalogName", typeof(string));
            table.Columns.Add("BaseColumnName", typeof(string));
            table.Columns.Add("BaseSchemaName", typeof(string));
            table.Columns.Add("BaseTableName", typeof(string));
            table.Columns.Add("DataType", typeof(Type));
            table.Columns.Add("AllowDBNull", typeof(bool));
            table.Columns.Add("ProviderType", typeof(int));
            table.Columns.Add("IsAliased", typeof(bool));
            table.Columns.Add("IsExpression", typeof(bool));
            table.Columns.Add("IsIdentity", typeof(bool));
            table.Columns.Add("IsAutoIncrement", typeof(bool));
            table.Columns.Add("IsRowVersion", typeof(bool));
            table.Columns.Add("IsHidden", typeof(bool));
            table.Columns.Add("IsLong", typeof(bool));
            table.Columns.Add("IsReadOnly", typeof(bool));
            int num = 1;
            for (int i = 0; i < this.fields.Length; i++)
            {
                MySqlField field = this.fields[i];
                DataRow row = table.NewRow();
                row["ColumnName"] = field.ColumnName;
                row["ColumnOrdinal"] = num++;
                row["ColumnSize"] = field.IsTextField ? (field.ColumnLength / field.MaxLength) : field.ColumnLength;
                int precision = field.Precision;
                int scale = field.Scale;
                if (precision != -1)
                {
                    row["NumericPrecision"] = (short) precision;
                }
                if (scale != -1)
                {
                    row["NumericScale"] = (short) scale;
                }
                row["DataType"] = this.GetFieldType(i);
                row["ProviderType"] = (int) field.Type;
                row["IsLong"] = field.IsBlob && (field.ColumnLength > 0xff);
                row["AllowDBNull"] = field.AllowsNull;
                row["IsReadOnly"] = false;
                row["IsRowVersion"] = false;
                row["IsUnique"] = field.IsUnique;
                row["IsKey"] = field.IsPrimaryKey;
                row["IsAutoIncrement"] = field.IsAutoIncrement;
                row["BaseSchemaName"] = field.DatabaseName;
                row["BaseCatalogName"] = null;
                row["BaseTableName"] = field.RealTableName;
                row["BaseColumnName"] = field.OriginalColumnName;
                table.Rows.Add(row);
            }
            return table;
        }

        public override string GetString(int i)
        {
            IMySqlValue fieldValue = this.GetFieldValue(i, true);
            if (fieldValue is MySqlBinary)
            {
                MySqlBinary binary = (MySqlBinary) fieldValue;
                byte[] bytes = binary.Value;
                return this.fields[i].Encoding.GetString(bytes, 0, bytes.Length);
            }
            return fieldValue.Value.ToString();
        }

        public string GetString(string column)
        {
            return this.GetString(this.GetOrdinal(column));
        }

        public TimeSpan GetTimeSpan(int column)
        {
            MySqlTimeSpan fieldValue = (MySqlTimeSpan) this.GetFieldValue(column, true);
            return fieldValue.Value;
        }

        public TimeSpan GetTimeSpan(string column)
        {
            return this.GetTimeSpan(this.GetOrdinal(column));
        }

        public ushort GetUInt16(int column)
        {
            IMySqlValue fieldValue = this.GetFieldValue(column, true);
            if (fieldValue is MySqlUInt16)
            {
                MySqlUInt16 num = (MySqlUInt16) fieldValue;
                return num.Value;
            }
            this.connection.UsageAdvisor.Converting(this.command.CommandText, this.fields[column].ColumnName, fieldValue.MySqlTypeName, "UInt16");
            return Convert.ToUInt16(fieldValue.Value);
        }

        public ushort GetUInt16(string column)
        {
            return this.GetUInt16(this.GetOrdinal(column));
        }

        public uint GetUInt32(int column)
        {
            IMySqlValue fieldValue = this.GetFieldValue(column, true);
            if (fieldValue is MySqlUInt32)
            {
                MySqlUInt32 num = (MySqlUInt32) fieldValue;
                return num.Value;
            }
            this.connection.UsageAdvisor.Converting(this.command.CommandText, this.fields[column].ColumnName, fieldValue.MySqlTypeName, "UInt32");
            return Convert.ToUInt32(fieldValue.Value);
        }

        public uint GetUInt32(string column)
        {
            return this.GetUInt32(this.GetOrdinal(column));
        }

        public ulong GetUInt64(int column)
        {
            IMySqlValue fieldValue = this.GetFieldValue(column, true);
            if (fieldValue is MySqlUInt64)
            {
                MySqlUInt64 num = (MySqlUInt64) fieldValue;
                return num.Value;
            }
            this.connection.UsageAdvisor.Converting(this.command.CommandText, this.fields[column].ColumnName, fieldValue.MySqlTypeName, "UInt64");
            return Convert.ToUInt64(fieldValue.Value);
        }

        public ulong GetUInt64(string column)
        {
            return this.GetUInt64(this.GetOrdinal(column));
        }

        public override object GetValue(int i)
        {
            if (!this.isOpen)
            {
                throw new Exception("No current query in data reader");
            }
            if (i >= this.fields.Length)
            {
                throw new IndexOutOfRangeException();
            }
            IMySqlValue fieldValue = this.GetFieldValue(i, false);
            if (fieldValue.IsNull)
            {
                return DBNull.Value;
            }
            if (!(fieldValue is MySqlDateTime))
            {
                return fieldValue.Value;
            }
            MySqlDateTime time = (MySqlDateTime) fieldValue;
            if (!time.IsValidDateTime && this.connection.Settings.ConvertZeroDateTime)
            {
                return DateTime.MinValue;
            }
            if (this.connection.Settings.AllowZeroDateTime)
            {
                return fieldValue;
            }
            return time.GetDateTime();
        }

        public override int GetValues(object[] values)
        {
            if (!this.hasRead)
            {
                return 0;
            }
            int num = Math.Min(values.Length, this.fields.Length);
            for (int i = 0; i < num; i++)
            {
                values[i] = this.GetValue(i);
            }
            return num;
        }

        public override bool IsDBNull(int i)
        {
            return (DBNull.Value == this.GetValue(i));
        }

        public override bool NextResult()
        {
            bool flag2;
            if (!this.isOpen)
            {
                throw new MySqlException(Resources.NextResultIsClosed);
            }
            bool flag = this.fields == null;
            if (this.fields != null)
            {
                this.ClearCurrentResultset();
                this.fields = null;
            }
            if (!flag && ((this.commandBehavior & CommandBehavior.SingleResult) != CommandBehavior.Default))
            {
                return false;
            }
            try
            {
                long resultSet = this.GetResultSet();
                if (resultSet == -1L)
                {
                    this.nextResultDone = true;
                    this.hasRows = this.canRead = false;
                    return false;
                }
                if (this.connection.Settings.UseUsageAdvisor)
                {
                    if ((this.connection.driver.ServerStatus & ServerStatusFlags.NoIndex) != 0)
                    {
                        this.connection.UsageAdvisor.UsingNoIndex(this.command.CommandText);
                    }
                    if ((this.connection.driver.ServerStatus & ServerStatusFlags.BadIndex) != 0)
                    {
                        this.connection.UsageAdvisor.UsingBadIndex(this.command.CommandText);
                    }
                }
                this.fields = this.driver.ReadColumnMetadata((int) resultSet);
                this.fieldHashCS.Clear();
                this.fieldHashCI.Clear();
                this.values = new IMySqlValue[this.fields.Length];
                for (int i = 0; i < this.fields.Length; i++)
                {
                    string columnName = this.fields[i].ColumnName;
                    if (!this.fieldHashCS.ContainsKey(columnName))
                    {
                        this.fieldHashCS.Add(columnName, i);
                    }
                    if (!this.fieldHashCI.ContainsKey(columnName))
                    {
                        this.fieldHashCI.Add(columnName, i);
                    }
                    this.values[i] = this.fields[i].GetValueObject();
                }
                this.hasRead = false;
                this.uaFieldsUsed = new bool[this.fields.Length];
                this.hasRows = this.canRead = this.driver.FetchDataRow(this.statement.StatementId, 0, this.fields.Length);
                flag2 = true;
            }
            catch (MySqlException exception)
            {
                if (exception.IsFatal)
                {
                    this.connection.Abort();
                }
                this.nextResultDone = true;
                this.hasRows = this.canRead = false;
                if (this.command.TimedOut)
                {
                    throw new MySqlException(Resources.Timeout);
                }
                if (exception.Number == 0)
                {
                    throw new MySqlException(Resources.FatalErrorReadingResult, exception);
                }
                throw;
            }
            return flag2;
        }

        public override bool Read()
        {
            if (!this.isOpen)
            {
                throw new MySqlException("Invalid attempt to Read when reader is closed.");
            }
            if (!this.canRead)
            {
                return false;
            }
            if ((this.Behavior == CommandBehavior.SingleRow) && this.hasRead)
            {
                return false;
            }
            try
            {
                bool flag = (this.Behavior & CommandBehavior.SequentialAccess) != CommandBehavior.Default;
                this.seqIndex = -1;
                if (this.hasRead)
                {
                    this.canRead = this.driver.FetchDataRow(this.statement.StatementId, 0, this.fields.Length);
                }
                this.hasRead = true;
                if (this.canRead && !flag)
                {
                    for (int i = 0; i < this.fields.Length; i++)
                    {
                        this.values[i] = this.driver.ReadColumnValue(i, this.fields[i], this.values[i]);
                    }
                }
                return this.canRead;
            }
            catch (MySqlException exception)
            {
                if (exception.IsFatal)
                {
                    this.connection.Abort();
                }
                if (exception.Number != 0x525)
                {
                    throw new MySqlException(Resources.FatalErrorDuringRead, exception);
                }
                this.nextResultDone = true;
                this.canRead = false;
                if (this.command.TimedOut)
                {
                    throw new MySqlException(Resources.Timeout);
                }
                return false;
            }
        }

        IDataReader IDataRecord.GetData(int i)
        {
            return base.GetData(i);
        }

        internal CommandBehavior Behavior
        {
            get
            {
                return this.commandBehavior;
            }
        }

        public override int Depth
        {
            get
            {
                return 0;
            }
        }

        public override int FieldCount
        {
            get
            {
                if (this.fields != null)
                {
                    return this.fields.Length;
                }
                return 0;
            }
        }

        public override bool HasRows
        {
            get
            {
                return this.hasRows;
            }
        }

        internal long InsertedId
        {
            get
            {
                return this.lastInsertId;
            }
        }

        public override bool IsClosed
        {
            get
            {
                return !this.isOpen;
            }
        }

        public override object this[int i]
        {
            get
            {
                return this.GetValue(i);
            }
        }

        public override object this[string name]
        {
            get
            {
                return this[this.GetOrdinal(name)];
            }
        }

        public override int RecordsAffected
        {
            get
            {
                return (int) this.affectedRows;
            }
        }
    }
}

