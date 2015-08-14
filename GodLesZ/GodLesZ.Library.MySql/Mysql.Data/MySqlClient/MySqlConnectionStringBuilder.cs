using GodLesZ.Library.MySql.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	public sealed class MySqlConnectionStringBuilder : DbConnectionStringBuilder {
		private bool allowBatch;
		private bool allowUserVariables;
		private bool allowZeroDatetime;
		private bool autoEnlist;
		private string blobAsUtf8ExcludePattern;
		private Regex blobAsUtf8ExcludeRegex;
		private string blobAsUtf8IncludePattern;
		private Regex blobAsUtf8IncludeRegex;
		private string charSet;
		private bool clearing;
		private bool compress;
		private uint connectionLifetime;
		private bool connectionReset;
		private uint connectionTimeout;
		private bool convertZeroDatetime;
		private string database;
		private uint defaultCommandTimeout;
		private static Dictionary<Keyword, object> defaultValues = new Dictionary<Keyword, object>();
		private MySqlDriverType driverType;
		private bool functionsReturnString;
		private bool ignorePrepare;
		private bool interactiveSession;
		private bool logging;
		private uint maxPoolSize;
		private uint minPoolSize;
		private bool oldSyntax;
		private readonly string originalConnectionString;
		private string password;
		private readonly StringBuilder persistConnString;
		private bool persistSI;
		private string pipeName;
		private bool pooling;
		private uint port;
		private uint procCacheSize;
		private MySqlConnectionProtocol protocol;
		private bool respectBinaryFlags;
		private string server;
		private string sharedMemName;
		private bool treatBlobsAsUTF8;
		private bool treatTinyAsBoolean;
		private bool usePerfMon;
		private bool useProcedureBodies;
		private string userId;
		private bool useSSL;
		private bool useUsageAdvisor;

		static MySqlConnectionStringBuilder() {
			defaultValues.Add(Keyword.ConnectionTimeout, 15);
			defaultValues.Add(Keyword.Pooling, true);
			defaultValues.Add(Keyword.Port, 0xcea);
			defaultValues.Add(Keyword.Server, "");
			defaultValues.Add(Keyword.PersistSecurityInfo, false);
			defaultValues.Add(Keyword.ConnectionLifetime, 0);
			defaultValues.Add(Keyword.ConnectionReset, false);
			defaultValues.Add(Keyword.MinimumPoolSize, 0);
			defaultValues.Add(Keyword.MaximumPoolSize, 100);
			defaultValues.Add(Keyword.UserID, "");
			defaultValues.Add(Keyword.Password, "");
			defaultValues.Add(Keyword.UseUsageAdvisor, false);
			defaultValues.Add(Keyword.CharacterSet, "");
			defaultValues.Add(Keyword.Compress, false);
			defaultValues.Add(Keyword.PipeName, "MYSQL");
			defaultValues.Add(Keyword.Logging, false);
			defaultValues.Add(Keyword.OldSyntax, false);
			defaultValues.Add(Keyword.SharedMemoryName, "MYSQL");
			defaultValues.Add(Keyword.AllowBatch, true);
			defaultValues.Add(Keyword.ConvertZeroDatetime, false);
			defaultValues.Add(Keyword.Database, "");
			defaultValues.Add(Keyword.DriverType, MySqlDriverType.Native);
			defaultValues.Add(Keyword.Protocol, MySqlConnectionProtocol.Sockets);
			defaultValues.Add(Keyword.AllowZeroDatetime, false);
			defaultValues.Add(Keyword.UsePerformanceMonitor, false);
			defaultValues.Add(Keyword.ProcedureCacheSize, 0x19);
			defaultValues.Add(Keyword.UseSSL, false);
			defaultValues.Add(Keyword.IgnorePrepare, true);
			defaultValues.Add(Keyword.UseProcedureBodies, true);
			defaultValues.Add(Keyword.AutoEnlist, true);
			defaultValues.Add(Keyword.RespectBinaryFlags, true);
			defaultValues.Add(Keyword.BlobAsUTF8ExcludePattern, null);
			defaultValues.Add(Keyword.BlobAsUTF8IncludePattern, null);
			defaultValues.Add(Keyword.TreatBlobsAsUTF8, false);
			defaultValues.Add(Keyword.DefaultCommandTimeout, 30);
			defaultValues.Add(Keyword.TreatTinyAsBoolean, true);
			defaultValues.Add(Keyword.AllowUserVariables, false);
			defaultValues.Add(Keyword.InteractiveSession, false);
			defaultValues.Add(Keyword.FunctionsReturnString, false);
		}

		public MySqlConnectionStringBuilder() {
			this.persistConnString = new StringBuilder();
			this.Clear();
		}

		public MySqlConnectionStringBuilder(string connectionString)
			: this() {
			this.originalConnectionString = connectionString;
			this.persistConnString = new StringBuilder();
			base.ConnectionString = connectionString;
		}

		public override void Clear() {
			base.Clear();
			this.persistConnString.Remove(0, this.persistConnString.Length);
			this.clearing = true;
			foreach (KeyValuePair<Keyword, object> pair in defaultValues) {
				this.SetValue(pair.Key, pair.Value);
			}
			this.clearing = false;
		}

		private static bool ConvertToBool(object value) {
			bool flag;
			if (value is string) {
				string str = value.ToString().ToLower();
				switch (str) {
					case "yes":
					case "true":
					case "1":
						return true;
				}
				if (str != "no" && str != "false" && str != "0") {
					throw new ArgumentException(Resources.ImproperValueFormat, (string)value);
				}
				return false;
			}
			try {
				flag = (value as IConvertible).ToBoolean(CultureInfo.InvariantCulture);
			} catch (InvalidCastException) {
				throw new ArgumentException(Resources.ImproperValueFormat, value.ToString());
			}
			return flag;
		}

		private static MySqlDriverType ConvertToDriverType(object value) {
			if (value is MySqlDriverType) {
				return (MySqlDriverType)value;
			}
			return (MySqlDriverType)Enum.Parse(typeof(MySqlDriverType), value.ToString(), true);
		}

		private static MySqlConnectionProtocol ConvertToProtocol(object value) {
			try {
				if (value is MySqlConnectionProtocol) {
					return (MySqlConnectionProtocol)value;
				}
				return (MySqlConnectionProtocol)Enum.Parse(typeof(MySqlConnectionProtocol), value.ToString(), true);
			} catch (Exception) {
				if (value is string) {
					switch ((value as string).ToLower()) {
						case "socket":
						case "tcp":
							return MySqlConnectionProtocol.Sockets;

						case "pipe":
							return MySqlConnectionProtocol.NamedPipe;

						case "unix":
							return MySqlConnectionProtocol.UnixSocket;

						case "memory":
							return MySqlConnectionProtocol.SharedMemory;
					}
				}
			}
			throw new ArgumentException(Resources.ImproperValueFormat, value.ToString());
		}

		private static uint ConvertToUInt(object value) {
			uint num2;
			try {
				num2 = (value as IConvertible).ToUInt32(CultureInfo.InvariantCulture);
			} catch (InvalidCastException) {
				throw new ArgumentException(Resources.ImproperValueFormat, value.ToString());
			}
			return num2;
		}

		internal string GetConnectionString(bool includePass) {
			if (includePass) {
				return this.originalConnectionString;
			}
			string str = this.persistConnString.ToString();
			return str.Remove(str.Length - 1, 1);
		}

		private static Keyword GetKey(string key) {
			switch (key.ToLower(CultureInfo.InvariantCulture)) {
				case "uid":
				case "username":
				case "user id":
				case "user name":
				case "userid":
				case "user":
					return Keyword.UserID;

				case "host":
				case "server":
				case "data source":
				case "datasource":
				case "address":
				case "addr":
				case "network address":
					return Keyword.Server;

				case "password":
				case "pwd":
					return Keyword.Password;

				case "useusageadvisor":
				case "usage advisor":
				case "use usage advisor":
					return Keyword.UseUsageAdvisor;

				case "character set":
				case "charset":
					return Keyword.CharacterSet;

				case "use compression":
				case "compress":
					return Keyword.Compress;

				case "pipe name":
				case "pipe":
					return Keyword.PipeName;

				case "logging":
					return Keyword.Logging;

				case "use old syntax":
				case "old syntax":
				case "oldsyntax":
					return Keyword.OldSyntax;

				case "shared memory name":
					return Keyword.SharedMemoryName;

				case "allow batch":
					return Keyword.AllowBatch;

				case "convert zero datetime":
				case "convertzerodatetime":
					return Keyword.ConvertZeroDatetime;

				case "persist security info":
					return Keyword.PersistSecurityInfo;

				case "initial catalog":
				case "database":
					return Keyword.Database;

				case "connection timeout":
				case "connect timeout":
					return Keyword.ConnectionTimeout;

				case "port":
					return Keyword.Port;

				case "pooling":
					return Keyword.Pooling;

				case "min pool size":
				case "minimum pool size":
					return Keyword.MinimumPoolSize;

				case "max pool size":
				case "maximum pool size":
					return Keyword.MaximumPoolSize;

				case "connection lifetime":
					return Keyword.ConnectionLifetime;

				case "driver":
					return Keyword.DriverType;

				case "protocol":
				case "connection protocol":
					return Keyword.Protocol;

				case "allow zero datetime":
				case "allowzerodatetime":
					return Keyword.AllowZeroDatetime;

				case "useperformancemonitor":
				case "use performance monitor":
					return Keyword.UsePerformanceMonitor;

				case "procedure cache size":
				case "procedurecachesize":
				case "procedure cache":
				case "procedurecache":
					return Keyword.ProcedureCacheSize;

				case "connection reset":
					return Keyword.ConnectionReset;

				case "ignore prepare":
					return Keyword.IgnorePrepare;

				case "encrypt":
					return Keyword.UseSSL;

				case "procedure bodies":
				case "use procedure bodies":
					return Keyword.UseProcedureBodies;

				case "auto enlist":
					return Keyword.AutoEnlist;

				case "respect binary flags":
					return Keyword.RespectBinaryFlags;

				case "blobasutf8excludepattern":
					return Keyword.BlobAsUTF8ExcludePattern;

				case "blobasutf8includepattern":
					return Keyword.BlobAsUTF8IncludePattern;

				case "treatblobsasutf8":
				case "treat blobs as utf8":
					return Keyword.TreatBlobsAsUTF8;

				case "default command timeout":
					return Keyword.DefaultCommandTimeout;

				case "treat tiny as boolean":
					return Keyword.TreatTinyAsBoolean;

				case "allow user variables":
					return Keyword.AllowUserVariables;

				case "interactive":
				case "interactive session":
					return Keyword.InteractiveSession;

				case "functions return string":
					return Keyword.FunctionsReturnString;
			}
			throw new ArgumentException(Resources.KeywordNotSupported, key);
		}

		protected override void GetProperties(Hashtable propertyDescriptors) {
			base.GetProperties(propertyDescriptors);
			PropertyDescriptor descriptor = (PropertyDescriptor)propertyDescriptors["Connection Protocol"];
			Attribute[] array = new Attribute[descriptor.Attributes.Count];
			descriptor.Attributes.CopyTo(array, 0);
			ConnectionProtocolDescriptor descriptor2 = new ConnectionProtocolDescriptor(descriptor.Name, array);
			propertyDescriptors["Connection Protocol"] = descriptor2;
		}

		private object GetValue(Keyword kw) {
			switch (kw) {
				case Keyword.UserID:
					return this.UserID;

				case Keyword.Password:
					return this.Password;

				case Keyword.Server:
					return this.Server;

				case Keyword.Port:
					return this.Port;

				case Keyword.UseUsageAdvisor:
					return this.UseUsageAdvisor;

				case Keyword.CharacterSet:
					return this.CharacterSet;

				case Keyword.Compress:
					return this.UseCompression;

				case Keyword.PipeName:
					return this.PipeName;

				case Keyword.Logging:
					return this.Logging;

				case Keyword.SharedMemoryName:
					return this.SharedMemoryName;

				case Keyword.AllowBatch:
					return this.AllowBatch;

				case Keyword.ConvertZeroDatetime:
					return this.ConvertZeroDateTime;

				case Keyword.PersistSecurityInfo:
					return this.PersistSecurityInfo;

				case Keyword.Database:
					return this.Database;

				case Keyword.ConnectionTimeout:
					return this.ConnectionTimeout;

				case Keyword.Pooling:
					return this.Pooling;

				case Keyword.MinimumPoolSize:
					return this.MinimumPoolSize;

				case Keyword.MaximumPoolSize:
					return this.MaximumPoolSize;

				case Keyword.ConnectionLifetime:
					return this.ConnectionLifeTime;

				case Keyword.DriverType:
					return this.DriverType;

				case Keyword.Protocol:
					return this.ConnectionProtocol;

				case Keyword.ConnectionReset:
					return this.ConnectionReset;

				case Keyword.AllowZeroDatetime:
					return this.AllowZeroDateTime;

				case Keyword.UsePerformanceMonitor:
					return this.UsePerformanceMonitor;

				case Keyword.ProcedureCacheSize:
					return this.ProcedureCacheSize;

				case Keyword.IgnorePrepare:
					return this.IgnorePrepare;

				case Keyword.UseSSL:
					return this.UseSSL;

				case Keyword.UseProcedureBodies:
					return this.UseProcedureBodies;

				case Keyword.AutoEnlist:
					return this.AutoEnlist;

				case Keyword.RespectBinaryFlags:
					return this.RespectBinaryFlags;

				case Keyword.TreatBlobsAsUTF8:
					return this.TreatBlobsAsUTF8;

				case Keyword.BlobAsUTF8IncludePattern:
					return this.blobAsUtf8IncludePattern;

				case Keyword.BlobAsUTF8ExcludePattern:
					return this.blobAsUtf8ExcludePattern;

				case Keyword.DefaultCommandTimeout:
					return this.defaultCommandTimeout;

				case Keyword.TreatTinyAsBoolean:
					return this.treatTinyAsBoolean;

				case Keyword.AllowUserVariables:
					return this.allowUserVariables;

				case Keyword.InteractiveSession:
					return this.interactiveSession;

				case Keyword.FunctionsReturnString:
					return this.functionsReturnString;
			}
			return null;
		}

		public override bool Remove(string keyword) {
			Keyword key = GetKey(keyword);
			this.SetValue(key, defaultValues[key]);
			return base.Remove(keyword);
		}

		private void SetValue(Keyword kw, object value) {
			switch (kw) {
				case Keyword.UserID:
					this.userId = (string)value;
					return;

				case Keyword.Password:
					this.password = (string)value;
					return;

				case Keyword.Server:
					this.server = (string)value;
					return;

				case Keyword.Port:
					this.port = ConvertToUInt(value);
					return;

				case Keyword.UseUsageAdvisor:
					this.useUsageAdvisor = ConvertToBool(value);
					return;

				case Keyword.CharacterSet:
					this.charSet = (string)value;
					return;

				case Keyword.Compress:
					this.compress = ConvertToBool(value);
					return;

				case Keyword.PipeName:
					this.pipeName = (string)value;
					return;

				case Keyword.Logging:
					this.logging = ConvertToBool(value);
					return;

				case Keyword.OldSyntax:
					this.oldSyntax = ConvertToBool(value);
					if (this.clearing) {
						break;
					}
					Logger.LogWarning("Use Old Syntax is now obsolete.  Please see documentation");
					return;

				case Keyword.SharedMemoryName:
					this.sharedMemName = (string)value;
					return;

				case Keyword.AllowBatch:
					this.allowBatch = ConvertToBool(value);
					return;

				case Keyword.ConvertZeroDatetime:
					this.convertZeroDatetime = ConvertToBool(value);
					return;

				case Keyword.PersistSecurityInfo:
					this.persistSI = ConvertToBool(value);
					return;

				case Keyword.Database:
					this.database = (string)value;
					return;

				case Keyword.ConnectionTimeout:
					this.connectionTimeout = ConvertToUInt(value);
					return;

				case Keyword.Pooling:
					this.pooling = ConvertToBool(value);
					return;

				case Keyword.MinimumPoolSize:
					this.minPoolSize = ConvertToUInt(value);
					return;

				case Keyword.MaximumPoolSize:
					this.maxPoolSize = ConvertToUInt(value);
					return;

				case Keyword.ConnectionLifetime:
					this.connectionLifetime = ConvertToUInt(value);
					return;

				case Keyword.DriverType:
					this.driverType = ConvertToDriverType(value);
					return;

				case Keyword.Protocol:
					this.protocol = ConvertToProtocol(value);
					return;

				case Keyword.ConnectionReset:
					this.connectionReset = ConvertToBool(value);
					return;

				case Keyword.AllowZeroDatetime:
					this.allowZeroDatetime = ConvertToBool(value);
					return;

				case Keyword.UsePerformanceMonitor:
					this.usePerfMon = ConvertToBool(value);
					return;

				case Keyword.ProcedureCacheSize:
					this.procCacheSize = ConvertToUInt(value);
					return;

				case Keyword.IgnorePrepare:
					this.ignorePrepare = ConvertToBool(value);
					return;

				case Keyword.UseSSL:
					this.useSSL = ConvertToBool(value);
					return;

				case Keyword.UseProcedureBodies:
					this.useProcedureBodies = ConvertToBool(value);
					return;

				case Keyword.AutoEnlist:
					this.autoEnlist = ConvertToBool(value);
					return;

				case Keyword.RespectBinaryFlags:
					this.respectBinaryFlags = ConvertToBool(value);
					return;

				case Keyword.TreatBlobsAsUTF8:
					this.treatBlobsAsUTF8 = ConvertToBool(value);
					return;

				case Keyword.BlobAsUTF8IncludePattern:
					this.blobAsUtf8IncludePattern = (string)value;
					return;

				case Keyword.BlobAsUTF8ExcludePattern:
					this.blobAsUtf8ExcludePattern = (string)value;
					return;

				case Keyword.DefaultCommandTimeout:
					this.defaultCommandTimeout = ConvertToUInt(value);
					return;

				case Keyword.TreatTinyAsBoolean:
					this.treatTinyAsBoolean = ConvertToBool(value);
					return;

				case Keyword.AllowUserVariables:
					this.allowUserVariables = ConvertToBool(value);
					return;

				case Keyword.InteractiveSession:
					this.interactiveSession = ConvertToBool(value);
					return;

				case Keyword.FunctionsReturnString:
					this.functionsReturnString = ConvertToBool(value);
					break;

				default:
					return;
			}
		}

		private void SetValue(string keyword, object value) {
			object obj2;
			if (value == null) {
				throw new ArgumentException(Resources.KeywordNoNull, keyword);
			}
			this.TryGetValue(keyword, out obj2);
			Keyword key = GetKey(keyword);
			this.SetValue(key, value);
			base[keyword] = value;
			if (key != Keyword.Password) {
				this.persistConnString.Replace(string.Concat(new object[] { keyword, "=", obj2, ";" }), "");
				this.persistConnString.AppendFormat(CultureInfo.InvariantCulture, "{0}={1};", new object[] { keyword, value });
			}
		}

		public override bool TryGetValue(string keyword, out object value) {
			try {
				Keyword key = GetKey(keyword);
				value = this.GetValue(key);
				return true;
			} catch (ArgumentException) {
			}
			value = null;
			return false;
		}

		[DisplayName("Allow Batch"), Description("Allows execution of multiple SQL commands in a single statement"), DefaultValue(true), RefreshProperties(RefreshProperties.All), Category("Connection")]
		public bool AllowBatch {
			get { return this.allowBatch; }
			set {
				this.SetValue("Allow Batch", value);
				this.allowBatch = value;
			}
		}

		[Category("Advanced"), DisplayName("Allow User Variables"), Description("Should the provider expect user variables to appear in the SQL."), DefaultValue(false), RefreshProperties(RefreshProperties.All)]
		public bool AllowUserVariables {
			get { return this.allowUserVariables; }
			set {
				this.SetValue("Allow User Variables", value);
				this.allowUserVariables = value;
			}
		}

		[DefaultValue(false), Description("Should zero datetimes be supported"), Category("Advanced"), RefreshProperties(RefreshProperties.All), DisplayName("Allow Zero Datetime")]
		public bool AllowZeroDateTime {
			get { return this.allowZeroDatetime; }
			set {
				this.SetValue("Allow Zero Datetime", value);
				this.allowZeroDatetime = value;
			}
		}

		[Category("Advanced"), Description("Should the connetion automatically enlist in the active connection, if there are any."), DefaultValue(true), RefreshProperties(RefreshProperties.All), DisplayName("Auto Enlist")]
		public bool AutoEnlist {
			get { return this.autoEnlist; }
			set {
				this.SetValue("Auto Enlist", value);
				this.autoEnlist = value;
			}
		}

		[DisplayName("BlobAsUTF8ExcludePattern"), Category("Advanced"), Description("Pattern that matches columns that should not be treated as UTF8"), RefreshProperties(RefreshProperties.All)]
		public string BlobAsUTF8ExcludePattern {
			get { return this.blobAsUtf8ExcludePattern; }
			set {
				this.SetValue("BlobAsUTF8ExcludePattern", value);
				this.blobAsUtf8ExcludePattern = value;
				this.blobAsUtf8ExcludeRegex = null;
			}
		}

		internal Regex BlobAsUTF8ExcludeRegex {
			get {
				if (this.blobAsUtf8ExcludePattern == null)
					return null;
				if (this.blobAsUtf8ExcludeRegex == null)
					this.blobAsUtf8ExcludeRegex = new Regex(this.blobAsUtf8ExcludePattern);
				return this.blobAsUtf8ExcludeRegex;
			}
		}

		[DisplayName("BlobAsUTF8IncludePattern"), RefreshProperties(RefreshProperties.All), Category("Advanced"), Description("Pattern that matches columns that should be treated as UTF8")]
		public string BlobAsUTF8IncludePattern {
			get { return this.blobAsUtf8IncludePattern; }
			set {
				this.SetValue("BlobAsUTF8IncludePattern", value);
				this.blobAsUtf8IncludePattern = value;
				this.blobAsUtf8IncludeRegex = null;
			}
		}

		internal Regex BlobAsUTF8IncludeRegex {
			get {
				if (this.blobAsUtf8IncludePattern == null)
					return null;
				if (this.blobAsUtf8IncludeRegex == null)
					this.blobAsUtf8IncludeRegex = new Regex(this.blobAsUtf8IncludePattern);
				return this.blobAsUtf8IncludeRegex;
			}
		}

		[Category("Advanced"), Description("Character set this connection should use"), RefreshProperties(RefreshProperties.All), DisplayName("Character Set")]
		public string CharacterSet {
			get { return this.charSet; }
			set {
				this.SetValue("Character Set", value);
				this.charSet = value;
			}
		}

		[DisplayName("Connection Lifetime"), Category("Pooling"), RefreshProperties(RefreshProperties.All), Description("The minimum amount of time (in seconds) for this connection to live in the pool before being destroyed."), DefaultValue(0)]
		public uint ConnectionLifeTime {
			get { return this.connectionLifetime; }
			set {
				this.SetValue("Connection Lifetime", value);
				this.connectionLifetime = value;
			}
		}

		[Description("Protocol to use for connection to MySQL"), Category("Connection"), DisplayName("Connection Protocol"), RefreshProperties(RefreshProperties.All), DefaultValue(0)]
		public MySqlConnectionProtocol ConnectionProtocol {
			get { return this.protocol; }
			set {
				this.SetValue("Connection Protocol", value);
				this.protocol = value;
			}
		}

		[Category("Pooling"), RefreshProperties(RefreshProperties.All), DisplayName("Connection Reset"), Description("When true, indicates the connection state is reset when removed from the pool."), DefaultValue(true)]
		public bool ConnectionReset {
			get { return this.connectionReset; }
			set {
				this.SetValue("Connection Reset", value);
				this.connectionReset = value;
			}
		}

		[Category("Connection"), DisplayName("Connect Timeout"), Description("The length of time (in seconds) to wait for a connection to the server before terminating the attempt and generating an error."), DefaultValue(15), RefreshProperties(RefreshProperties.All)]
		public uint ConnectionTimeout {
			get { return this.connectionTimeout; }
			set {
				this.SetValue("Connect Timeout", value);
				this.connectionTimeout = value;
			}
		}

		[DisplayName("Convert Zero Datetime"), Description("Should illegal datetime values be converted to DateTime.MinValue"), DefaultValue(false), RefreshProperties(RefreshProperties.All), Category("Advanced")]
		public bool ConvertZeroDateTime {
			get { return this.convertZeroDatetime; }
			set {
				this.SetValue("Convert Zero Datetime", value);
				this.convertZeroDatetime = value;
			}
		}

		[RefreshProperties(RefreshProperties.All), Category("Connection"), Description("Database to use initially")]
		public string Database {
			get { return this.database; }
			set {
				this.SetValue("Database", value);
				this.database = value;
			}
		}

		[Description("The default timeout that MySqlCommand objects will use\r\n                     unless changed."), DisplayName("Default Command Timeout"), Category("Connection"), DefaultValue(30), RefreshProperties(RefreshProperties.All)]
		public uint DefaultCommandTimeout {
			get { return this.defaultCommandTimeout; }
			set {
				this.SetValue("Default Command Timeout", value);
				this.defaultCommandTimeout = value;
			}
		}

		[DisplayName("Driver Type"), DefaultValue(0), RefreshProperties(RefreshProperties.All), Browsable(false), Category("Connection"), Description("Specifies the type of driver to use for this connection")]
		public MySqlDriverType DriverType {
			get { return this.driverType; }
			set {
				this.SetValue("Driver Type", value);
				this.driverType = value;
			}
		}

		[Description("Should all server functions be treated as returning string?"), DisplayName("Functions Return String"), DefaultValue(false), Category("Advanced")]
		public bool FunctionsReturnString {
			get { return this.functionsReturnString; }
			set {
				this.SetValue("Functions Return String", value);
				this.functionsReturnString = value;
			}
		}

		[DefaultValue(true), Description("Instructs the provider to ignore any attempts to prepare a command."), RefreshProperties(RefreshProperties.All), DisplayName("Ignore Prepare"), Category("Advanced")]
		public bool IgnorePrepare {
			get { return this.ignorePrepare; }
			set {
				this.SetValue("Ignore Prepare", value);
				this.ignorePrepare = value;
			}
		}

		[DefaultValue(false), RefreshProperties(RefreshProperties.All), DisplayName("Interactive Session"), Description("Should this session be considered interactive?"), Category("Advanced")]
		public bool InteractiveSession {
			get { return this.interactiveSession; }
			set {
				this.SetValue("Interactive Session", value);
				this.interactiveSession = value;
			}
		}

		public override object this[string keyword] {
			get {
				Keyword key = GetKey(keyword);
				return this.GetValue(key);
			}
			set {
				if (value == null) {
					this.Remove(keyword);
				} else {
					this.SetValue(keyword, value);
				}
			}
		}

		[Category("Connection"), Description("Enables output of diagnostic messages"), RefreshProperties(RefreshProperties.All), DefaultValue(false)]
		public bool Logging {
			get { return this.logging; }
			set {
				this.SetValue("Logging", value);
				this.logging = value;
			}
		}

		[RefreshProperties(RefreshProperties.All), DefaultValue(100), Category("Pooling"), DisplayName("Maximum Pool Size"), Description("The maximum number of connections allowed in the pool.")]
		public uint MaximumPoolSize {
			get { return this.maxPoolSize; }
			set {
				this.SetValue("Maximum Pool Size", value);
				this.maxPoolSize = value;
			}
		}

		[Description("The minimum number of connections allowed in the pool."), Category("Pooling"), DefaultValue(0), RefreshProperties(RefreshProperties.All), DisplayName("Minimum Pool Size")]
		public uint MinimumPoolSize {
			get { return this.minPoolSize; }
			set {
				this.SetValue("Minimum Pool Size", value);
				this.minPoolSize = value;
			}
		}

		[Description("Indicates the password to be used when connecting to the data source."), Category("Security"), PasswordPropertyText(true), RefreshProperties(RefreshProperties.All)]
		public string Password {
			get { return this.password; }
			set {
				this.SetValue("Password", value);
				this.password = value;
			}
		}

		[DisplayName("Persist Security Info"), Category("Security"), RefreshProperties(RefreshProperties.All), Description("When false, security-sensitive information, such as the password, is not returned as part of the connection if the connection is open or has ever been in an open state.")]
		public bool PersistSecurityInfo {
			get { return this.persistSI; }
			set {
				this.SetValue("Persist Security Info", value);
				this.persistSI = value;
			}
		}

		[RefreshProperties(RefreshProperties.All), Category("Connection"), DisplayName("Pipe Name"), Description("Name of pipe to use when connecting with named pipes (Win32 only)"), DefaultValue("MYSQL")]
		public string PipeName {
			get { return this.pipeName; }
			set {
				this.SetValue("Pipe Name", value);
				this.pipeName = value;
			}
		}

		[Description("When true, the connection object is drawn from the appropriate pool, or if necessary, is created and added to the appropriate pool."), Category("Pooling"), RefreshProperties(RefreshProperties.All), DefaultValue(true)]
		public bool Pooling {
			get { return this.pooling; }
			set {
				this.SetValue("Pooling", value);
				this.pooling = value;
			}
		}

		[DefaultValue(0xcea), RefreshProperties(RefreshProperties.All), Description("Port to use for TCP/IP connections"), Category("Connection")]
		public uint Port {
			get { return this.port; }
			set {
				this.SetValue("Port", value);
				this.port = value;
			}
		}

		[RefreshProperties(RefreshProperties.All), Category("Advanced"), DisplayName("Procedure Cache Size"), Description("Indicates how many stored procedures can be cached at one time. A value of 0 effectively disables the procedure cache."), DefaultValue(0x19)]
		public uint ProcedureCacheSize {
			get { return this.procCacheSize; }
			set {
				this.SetValue("Procedure Cache Size", value);
				this.procCacheSize = value;
			}
		}

		[RefreshProperties(RefreshProperties.All), Description("Should binary flags on column metadata be respected."), DefaultValue(true), Category("Advanced"), DisplayName("Respect Binary Flags")]
		public bool RespectBinaryFlags {
			get { return this.respectBinaryFlags; }
			set {
				this.SetValue("Respect Binary Flags", value);
				this.respectBinaryFlags = value;
			}
		}

		[RefreshProperties(RefreshProperties.All), Category("Connection"), Description("Server to connect to")]
		public string Server {
			get { return this.server; }
			set {
				this.SetValue("Server", value);
				this.server = value;
			}
		}

		[DisplayName("Shared Memory Name"), Description("Name of the shared memory object to use"), DefaultValue("MYSQL"), RefreshProperties(RefreshProperties.All), Category("Connection")]
		public string SharedMemoryName {
			get { return this.sharedMemName; }
			set {
				this.SetValue("Shared Memory Name", value);
				this.sharedMemName = value;
			}
		}

		[Description("Should binary blobs be treated as UTF8"), Category("Advanced"), RefreshProperties(RefreshProperties.All), DisplayName("Treat Blobs As UTF8")]
		public bool TreatBlobsAsUTF8 {
			get { return this.treatBlobsAsUTF8; }
			set {
				this.SetValue("TreatBlobsAsUTF8", value);
				this.treatBlobsAsUTF8 = value;
			}
		}

		[RefreshProperties(RefreshProperties.All), DisplayName("Treat Tiny As Boolean"), Description("Should the provider treat TINYINT(1) columns as boolean."), DefaultValue(true), Category("Advanced")]
		public bool TreatTinyAsBoolean {
			get { return this.treatTinyAsBoolean; }
			set {
				this.SetValue("Treat Tiny As Boolean", value);
				this.treatTinyAsBoolean = value;
			}
		}

		[Description("Should the connection ues compression"), Category("Connection"), DefaultValue(false), RefreshProperties(RefreshProperties.All), DisplayName("Use Compression")]
		public bool UseCompression {
			get { return this.compress; }
			set {
				this.SetValue("Use Compression", value);
				this.compress = value;
			}
		}

		[RefreshProperties(RefreshProperties.All), DefaultValue(false), Category("Connection"), Obsolete("Use Old Syntax is no longer needed.  See documentation"), DisplayName("Use Old Syntax"), Description("Allows the use of old style @ syntax for parameters")]
		public bool UseOldSyntax {
			get { return this.oldSyntax; }
			set {
				this.SetValue("Use Old Syntax", value);
				this.oldSyntax = value;
			}
		}

		[Description("Indicates that performance counters should be updated during execution."), Category("Advanced"), DisplayName("Use Performance Monitor"), RefreshProperties(RefreshProperties.All), DefaultValue(false)]
		public bool UsePerformanceMonitor {
			get { return this.usePerfMon; }
			set {
				this.SetValue("Use Performance Monitor", value);
				this.usePerfMon = value;
			}
		}

		[RefreshProperties(RefreshProperties.All), DefaultValue(true), Description("Indicates if stored procedure bodies will be available for parameter detection."), Category("Advanced"), DisplayName("Use Procedure Bodies")]
		public bool UseProcedureBodies {
			get { return this.useProcedureBodies; }
			set {
				this.SetValue("Use Procedure Bodies", value);
				this.useProcedureBodies = value;
			}
		}

		[DisplayName("User Id"), RefreshProperties(RefreshProperties.All), Category("Security"), Description("Indicates the user ID to be used when connecting to the data source.")]
		public string UserID {
			get { return this.userId; }
			set {
				this.SetValue("User Id", value);
				this.userId = value;
			}
		}

		[Category("Authentication"), DefaultValue(false), Description("Should the connection use SSL.  This currently has no effect."), RefreshProperties(RefreshProperties.All)]
		internal bool UseSSL {
			get { return this.useSSL; }
			set {
				this.SetValue("UseSSL", value);
				this.useSSL = value;
			}
		}

		[DefaultValue(false), Description("Logs inefficient database operations"), Category("Advanced"), RefreshProperties(RefreshProperties.All), DisplayName("Use Usage Advisor")]
		public bool UseUsageAdvisor {
			get { return this.useUsageAdvisor; }
			set {
				this.SetValue("Use Usage Advisor", value);
				this.useUsageAdvisor = value;
			}
		}

	}

}

