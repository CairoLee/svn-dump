namespace Shaiya.Extended.Server.MySql.Data.MySqlClient
{
    using Shaiya.Extended.Server.MySql.Data.Common;
    using Shaiya.Extended.Server.MySql.Data.Types;
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Text;

    internal abstract class Driver : IDisposable
    {
        protected Hashtable charSets;
        protected MySqlConnection connection;
        protected MySqlConnectionStringBuilder connectionString;
        protected DateTime creationTime;
        protected MySqlPromotableTransaction currentTransaction;
        protected System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(0x4e4);
        protected bool hasWarnings;
        protected bool inActiveUse;
        protected bool isOpen;
        protected long maxPacketSize;
        protected MySqlPool pool;
        protected ClientFlags serverCaps;
        protected string serverCharSet;
        protected int serverCharSetIndex;
        protected Hashtable serverProps;
        protected ServerStatusFlags serverStatus;
        protected int threadId;
        protected DBVersion version;

        public Driver(MySqlConnectionStringBuilder settings)
        {
            this.connectionString = settings;
            this.threadId = -1;
            this.serverCharSetIndex = -1;
            this.serverCharSet = null;
            this.hasWarnings = false;
            this.maxPacketSize = 0x400L;
        }

        public virtual void Close()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public abstract void CloseStatement(int id);
        public virtual void Configure(MySqlConnection connection)
        {
            this.connection = connection;
            bool flag = false;
            if (this.serverProps == null)
            {
                flag = true;
                this.serverProps = new Hashtable();
                MySqlDataReader reader = new MySqlCommand("SHOW VARIABLES", connection).ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        string str = reader.GetString(0);
                        string str2 = reader.GetString(1);
                        this.serverProps[str] = str2;
                    }
                }
                catch (Exception exception)
                {
                    Logger.LogException(exception);
                    throw;
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                }
                if (this.serverProps.Contains("max_allowed_packet"))
                {
                    this.maxPacketSize = Convert.ToInt64(this.serverProps["max_allowed_packet"]);
                }
                this.LoadCharacterSets();
            }
            if (this.Settings.ConnectionReset || flag)
            {
                string characterSet = this.connectionString.CharacterSet;
                if ((characterSet == null) || (characterSet.Length == 0))
                {
                    if (!this.version.isAtLeast(4, 1, 0))
                    {
                        if (this.serverProps.Contains("character_set"))
                        {
                            characterSet = this.serverProps["character_set"].ToString();
                        }
                    }
                    else if (this.serverCharSetIndex >= 0)
                    {
                        characterSet = (string) this.charSets[this.serverCharSetIndex];
                    }
                    else
                    {
                        characterSet = this.serverCharSet;
                    }
                }
                if (this.version.isAtLeast(4, 1, 0))
                {
                    MySqlCommand command2 = new MySqlCommand("SET character_set_results=NULL", connection);
                    object obj2 = this.serverProps["character_set_client"];
                    object obj3 = this.serverProps["character_set_connection"];
                    if (((obj2 != null) && (obj2.ToString() != characterSet)) || ((obj3 != null) && (obj3.ToString() != characterSet)))
                    {
                        command2.CommandText = "SET NAMES " + characterSet + ";" + command2.CommandText;
                    }
                    command2.ExecuteNonQuery();
                }
                if (characterSet != null)
                {
                    this.Encoding = CharSetMap.GetEncoding(this.version, characterSet);
                }
                else
                {
                    this.Encoding = CharSetMap.GetEncoding(this.version, "latin1");
                }
            }
        }

        public static Driver Create(MySqlConnectionStringBuilder settings)
        {
            Driver driver = null;
            if (settings.DriverType == MySqlDriverType.Native)
            {
                driver = new NativeDriver(settings);
            }
            driver.Open();
            return driver;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.connectionString.Pooling)
            {
                MySqlPoolManager.RemoveConnection(this);
            }
            this.isOpen = false;
        }

        public abstract void ExecuteStatement(byte[] bytes);
        public abstract bool FetchDataRow(int statementId, int pageSize, int columns);
        public bool IsTooOld()
        {
            TimeSpan span = DateTime.Now.Subtract(this.creationTime);
            return ((this.Settings.ConnectionLifeTime != 0) && (span.TotalSeconds > this.Settings.ConnectionLifeTime));
        }

        private void LoadCharacterSets()
        {
            if (this.version.isAtLeast(4, 1, 0))
            {
                MySqlCommand command = new MySqlCommand("SHOW COLLATION", this.connection);
                try
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        this.charSets = new Hashtable();
                        while (reader.Read())
                        {
                            this.charSets[Convert.ToInt32(reader["id"], NumberFormatInfo.InvariantInfo)] = reader.GetString(reader.GetOrdinal("charset"));
                        }
                    }
                }
                catch (Exception exception)
                {
                    Logger.LogException(exception);
                    throw;
                }
            }
        }

        public virtual void Open()
        {
            this.creationTime = DateTime.Now;
        }

        public abstract bool Ping();
        public abstract int PrepareStatement(string sql, ref MySqlField[] parameters);
        public string Property(string key)
        {
            return (string) this.serverProps[key];
        }

        public abstract void Query(byte[] bytes, int length);
        public abstract MySqlField[] ReadColumnMetadata(int count);
        public abstract IMySqlValue ReadColumnValue(int index, MySqlField field, IMySqlValue value);
        public abstract long ReadResult(ref ulong affectedRows, ref long lastInsertId);
        public void ReportWarnings()
        {
            ArrayList list = new ArrayList();
            MySqlCommand command = new MySqlCommand("SHOW WARNINGS", this.connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new MySqlError(reader.GetString(0), reader.GetInt32(1), reader.GetString(2)));
                }
                this.hasWarnings = false;
                if (list.Count != 0)
                {
                    MySqlInfoMessageEventArgs args = new MySqlInfoMessageEventArgs();
                    args.errors = (MySqlError[]) list.ToArray(typeof(MySqlError));
                    if (this.connection != null)
                    {
                        this.connection.OnInfoMessage(args);
                    }
                }
            }
        }

        public abstract void Reset();
        public virtual void SafeClose()
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {
            }
        }

        public abstract void SetDatabase(string dbName);
        public abstract void SkipColumnValue(IMySqlValue valObject);
        public abstract bool SkipDataRow();

        public MySqlConnection Connection
        {
            get
            {
                return this.connection;
            }
        }

        internal int ConnectionCharSetIndex
        {
            get
            {
                return this.serverCharSetIndex;
            }
        }

        public MySqlPromotableTransaction CurrentTransaction
        {
            get
            {
                return this.currentTransaction;
            }
            set
            {
                this.currentTransaction = value;
            }
        }

        public System.Text.Encoding Encoding
        {
            get
            {
                return this.encoding;
            }
            set
            {
                this.encoding = value;
            }
        }

        public bool HasWarnings
        {
            get
            {
                return this.hasWarnings;
            }
        }

        public bool IsInActiveUse
        {
            get
            {
                return this.inActiveUse;
            }
            set
            {
                this.inActiveUse = value;
            }
        }

        public bool IsOpen
        {
            get
            {
                return this.isOpen;
            }
        }

        public long MaxPacketSize
        {
            get
            {
                return this.maxPacketSize;
            }
        }

        public MySqlPool Pool
        {
            get
            {
                return this.pool;
            }
            set
            {
                this.pool = value;
            }
        }

        public ServerStatusFlags ServerStatus
        {
            get
            {
                return this.serverStatus;
            }
        }

        public MySqlConnectionStringBuilder Settings
        {
            get
            {
                return this.connectionString;
            }
            set
            {
                this.connectionString = value;
            }
        }

        public abstract bool SupportsBatch { get; }

        public int ThreadID
        {
            get
            {
                return this.threadId;
            }
        }

        public DBVersion Version
        {
            get
            {
                return this.version;
            }
        }
    }
}

