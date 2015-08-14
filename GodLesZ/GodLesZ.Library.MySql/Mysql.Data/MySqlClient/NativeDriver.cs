using GodLesZ.Library.MySql.Data.Common;
using GodLesZ.Library.MySql.Properties;
using GodLesZ.Library.MySql.Data.Types;
using System;
using System.Collections;
using System.IO;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	internal class NativeDriver : Driver {
		protected Stream baseStream;
		protected ClientFlags connectionFlags;
		protected string encryptionSeed;
		private BitArray nullMap;
		protected int protocol;
		protected MySqlStream stream;
		private int warningCount;

		public NativeDriver(MySqlConnectionStringBuilder settings)
			: base(settings) {
			base.isOpen = false;
		}

		public void Authenticate() {
			this.stream.WriteString(base.connectionString.UserID);
			if (this.version.isAtLeast(4, 1, 1)) {
				this.Authenticate411();
			} else {
				this.AuthenticateOld();
			}
		}

		private void Authenticate411() {
			if ((this.connectionFlags & ClientFlags.SECURE_CONNECTION) == 0) {
				this.AuthenticateOld();
			}
			this.stream.Write(Crypt.Get411Password(base.connectionString.Password, this.encryptionSeed));
			if (((this.connectionFlags & ClientFlags.CONNECT_WITH_DB) != 0) && (base.connectionString.Database != null)) {
				this.stream.WriteString(base.connectionString.Database);
			}
			this.stream.Flush();
			this.stream.OpenPacket();
			if (this.stream.IsLastPacket) {
				this.stream.StartOutput(0L, false);
				this.stream.WriteString(Crypt.EncryptPassword(base.connectionString.Password, this.encryptionSeed.Substring(0, 8), true));
				this.stream.Flush();
				this.ReadOk(true);
			} else {
				this.ReadOk(false);
			}
		}

		private void AuthenticateOld() {
			this.stream.WriteString(Crypt.EncryptPassword(base.connectionString.Password, this.encryptionSeed, this.protocol > 9));
			if (((this.connectionFlags & ClientFlags.CONNECT_WITH_DB) != 0) && (base.connectionString.Database != null)) {
				this.stream.WriteString(base.connectionString.Database);
			}
			this.stream.Flush();
			this.ReadOk(true);
		}

		private void CheckEOF() {
			if (!this.stream.IsLastPacket) {
				throw new MySqlException("Expected end of data packet");
			}
			this.stream.ReadByte();
			if (this.version.isAtLeast(3, 0, 0) && !this.version.isAtLeast(4, 1, 0)) {
				base.serverStatus = 0;
			}
			if (this.stream.HasMoreData && this.version.isAtLeast(4, 1, 0)) {
				this.warningCount = this.stream.ReadInteger(2);
				base.serverStatus = (ServerStatusFlags)this.stream.ReadInteger(2);
			}
		}

		public override void CloseStatement(int id) {
			this.stream.StartOutput(5L, true);
			this.stream.WriteByte(0x19);
			this.stream.WriteInteger((long)id, 4);
			this.stream.Flush();
		}

		public override void Configure(MySqlConnection conn) {
			base.Configure(conn);
			this.stream.MaxPacketSize = (ulong)base.maxPacketSize;
			this.stream.Encoding = base.Encoding;
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				try {
					if (base.isOpen) {
						this.ExecuteCommand(DBCmd.QUIT, null, 0);
					}
					if (this.stream != null) {
						this.stream.Close();
					}
					this.stream = null;
				} catch (Exception) {
				}
			}
			base.Dispose(disposing);
		}

		private void ExecuteCommand(DBCmd cmd, byte[] bytes, int length) {
			try {
				this.stream.StartOutput((ulong)(length + 1L), true);
				this.stream.WriteByte((byte)cmd);
				if (length > 0) {
					this.stream.Write(bytes, 0, length);
				}
				this.stream.Flush();
			} catch (MySqlException exception) {
				if (exception.IsFatal) {
					base.isOpen = false;
					this.Close();
				}
				throw;
			}
		}

		public override void ExecuteStatement(byte[] bytes) {
			this.ExecuteCommand(DBCmd.EXECUTE, bytes, bytes.Length);
			base.serverStatus |= ServerStatusFlags.AnotherQuery;
		}

		public override bool FetchDataRow(int statementId, int pageSize, int columns) {
			this.stream.OpenPacket();
			if (this.stream.IsLastPacket) {
				this.CheckEOF();
				return false;
			}
			this.nullMap = null;
			if (statementId > 0) {
				this.ReadNullMap(columns);
			}
			return true;
		}

		~NativeDriver() {
			this.Close();
		}

		private MySqlField GetFieldMetaData() {
			ColumnFlags flags;
			this.stream.Encoding = base.encoding;
			if (this.version.isAtLeast(4, 1, 0)) {
				return this.GetFieldMetaData41();
			}
			this.stream.OpenPacket();
			MySqlField field = new MySqlField(base.connection);
			field.Encoding = base.encoding;
			field.TableName = this.stream.ReadLenString();
			field.ColumnName = this.stream.ReadLenString();
			field.ColumnLength = this.stream.ReadNBytes();
			MySqlDbType type = (MySqlDbType)this.stream.ReadNBytes();
			this.stream.ReadByte();
			if ((this.Flags & ClientFlags.LONG_FLAG) != 0) {
				flags = (ColumnFlags)this.stream.ReadInteger(2);
			} else {
				flags = (ColumnFlags)this.stream.ReadByte();
			}
			field.SetTypeAndFlags(type, flags);
			field.Scale = (byte)this.stream.ReadByte();
			if (!this.version.isAtLeast(3, 0x17, 15) && this.version.isAtLeast(3, 0x17, 0)) {
				field.Scale = (byte)(field.Scale + 1);
			}
			return field;
		}

		private MySqlField GetFieldMetaData41() {
			ColumnFlags flags;
			MySqlField field = new MySqlField(base.connection);
			this.stream.OpenPacket();
			field.Encoding = base.encoding;
			field.CatalogName = this.stream.ReadLenString();
			field.DatabaseName = this.stream.ReadLenString();
			field.TableName = this.stream.ReadLenString();
			field.RealTableName = this.stream.ReadLenString();
			field.ColumnName = this.stream.ReadLenString();
			field.OriginalColumnName = this.stream.ReadLenString();
			this.stream.ReadByte();
			field.CharacterSetIndex = this.stream.ReadInteger(2);
			field.ColumnLength = this.stream.ReadInteger(4);
			MySqlDbType type = (MySqlDbType)this.stream.ReadByte();
			if ((this.Flags & ClientFlags.LONG_FLAG) != 0) {
				flags = (ColumnFlags)this.stream.ReadInteger(2);
			} else {
				flags = (ColumnFlags)this.stream.ReadByte();
			}
			field.SetTypeAndFlags(type, flags);
			field.Scale = (byte)this.stream.ReadByte();
			if (this.stream.HasMoreData) {
				this.stream.ReadInteger(2);
			}
			if ((base.charSets != null) && (field.CharacterSetIndex != -1)) {
				CharacterSet chararcterSet = CharSetMap.GetChararcterSet(base.Version, (string)base.charSets[field.CharacterSetIndex]);
				field.MaxLength = chararcterSet.byteCount;
				field.Encoding = CharSetMap.GetEncoding(base.version, (string)base.charSets[field.CharacterSetIndex]);
			}
			return field;
		}

		private static bool NoServerCheckValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
			return true;
		}

		public override void Open() {
			base.Open();
			try {
				if (base.Settings.ConnectionProtocol == MySqlConnectionProtocol.SharedMemory) {
					SharedMemoryStream stream = new SharedMemoryStream(base.Settings.SharedMemoryName);
					stream.Open(base.Settings.ConnectionTimeout);
					this.baseStream = stream;
				} else {
					string pipeName = base.Settings.PipeName;
					if (base.Settings.ConnectionProtocol != MySqlConnectionProtocol.NamedPipe) {
						pipeName = null;
					}
					this.baseStream = new StreamCreator(base.Settings.Server, base.Settings.Port, pipeName).GetStream(base.Settings.ConnectionTimeout);
				}
				if (this.baseStream == null) {
					throw new Exception();
				}
			} catch (Exception exception) {
				throw new MySqlException(Resources.UnableToConnectToHost, 0x412, exception);
			}
			if (this.baseStream == null) {
				throw new MySqlException("Unable to connect to any of the specified MySQL hosts");
			}
			int num = 0xfd02ff;
			this.stream = new MySqlStream(this.baseStream, base.encoding, false);
			this.stream.OpenPacket();
			this.protocol = this.stream.ReadByte();
			string versionString = this.stream.ReadString();
			base.version = DBVersion.Parse(versionString);
			base.threadId = this.stream.ReadInteger(4);
			this.encryptionSeed = this.stream.ReadString();
			if (this.version.isAtLeast(4, 0, 8)) {
				num = 0xffffff;
			}
			base.serverCaps = 0;
			if (this.stream.HasMoreData) {
				base.serverCaps = (ClientFlags)this.stream.ReadInteger(2);
			}
			if (this.version.isAtLeast(4, 1, 1)) {
				base.serverCharSetIndex = this.stream.ReadInteger(1);
				base.serverStatus = (ServerStatusFlags)this.stream.ReadInteger(2);
				this.stream.SkipBytes(13);
				string str3 = this.stream.ReadString();
				this.encryptionSeed = this.encryptionSeed + str3;
			}
			this.SetConnectionFlags();
			this.stream.StartOutput(0L, false);
			this.stream.WriteInteger((long)this.connectionFlags, this.version.isAtLeast(4, 1, 0) ? 4 : 2);
			if (base.connectionString.UseSSL && ((base.serverCaps & ClientFlags.SSL) != 0)) {
				this.stream.Flush();
				this.StartSSL();
				this.stream.StartOutput(0L, false);
				this.stream.WriteInteger((long)this.connectionFlags, this.version.isAtLeast(4, 1, 0) ? 4 : 2);
			}
			this.stream.WriteInteger((long)num, this.version.isAtLeast(4, 1, 0) ? 4 : 3);
			if (this.version.isAtLeast(4, 1, 1)) {
				this.stream.WriteByte(8);
				this.stream.Write(new byte[0x17]);
			}
			this.Authenticate();
			if ((this.connectionFlags & ClientFlags.COMPRESS) != 0) {
				this.stream = new MySqlStream(this.baseStream, base.encoding, true);
			}
			this.stream.Version = base.version;
			this.stream.MaxBlockSize = num;
			base.isOpen = true;
		}

		public override bool Ping() {
			try {
				this.ExecuteCommand(DBCmd.PING, null, 0);
				this.ReadOk(true);
				return true;
			} catch (Exception) {
				return false;
			}
		}

		public override int PrepareStatement(string sql, ref MySqlField[] parameters) {
			byte[] bytes = base.encoding.GetBytes(sql);
			this.ExecuteCommand(DBCmd.PREPARE, bytes, bytes.Length);
			this.stream.OpenPacket();
			if (this.stream.ReadByte() != 0) {
				throw new MySqlException("Expected prepared statement marker");
			}
			int num2 = this.stream.ReadInteger(4);
			int num3 = this.stream.ReadInteger(2);
			int count = this.stream.ReadInteger(2);
			this.stream.ReadInteger(3);
			if (count > 0) {
				parameters = this.ReadColumnMetadata(count);
				for (int i = 0; i < parameters.Length; i++) {
					parameters[i].Encoding = base.encoding;
				}
			}
			if (num3 > 0) {
				while (num3-- > 0) {
					this.stream.OpenPacket();
					this.stream.SkipPacket();
				}
				this.ReadEOF();
			}
			return num2;
		}

		public override void Query(byte[] bytes, int length) {
			if (base.Settings.Logging) {
				Logger.LogCommand(DBCmd.QUERY, base.encoding.GetString(bytes, 0, length));
			}
			this.ExecuteCommand(DBCmd.QUERY, bytes, length);
			base.serverStatus |= ServerStatusFlags.AnotherQuery;
		}

		public override MySqlField[] ReadColumnMetadata(int count) {
			MySqlField[] fieldArray = new MySqlField[count];
			for (int i = 0; i < count; i++) {
				fieldArray[i] = this.GetFieldMetaData();
			}
			this.ReadEOF();
			return fieldArray;
		}

		public override IMySqlValue ReadColumnValue(int index, MySqlField field, IMySqlValue valObject) {
			bool flag;
			long length = -1L;
			if (this.nullMap != null) {
				flag = this.nullMap[index + 2];
			} else {
				length = this.stream.ReadFieldLength();
				flag = length == -1L;
			}
			this.stream.Encoding = field.Encoding;
			return valObject.ReadValue(this.stream, length, flag);
		}

		private void ReadEOF() {
			this.stream.OpenPacket();
			this.CheckEOF();
		}

		private void ReadNullMap(int fieldCount) {
			this.nullMap = null;
			byte[] buffer = new byte[(fieldCount + 9) / 8];
			this.stream.ReadByte();
			this.stream.Read(buffer, 0, buffer.Length);
			this.nullMap = new BitArray(buffer);
		}

		private void ReadOk(bool read) {
			try {
				if (read) {
					this.stream.OpenPacket();
				}
				if (((byte)this.stream.ReadByte()) != 0) {
					throw new MySqlException("Out of sync with server", true, null);
				}
				this.stream.ReadFieldLength();
				this.stream.ReadFieldLength();
				if (this.stream.HasMoreData) {
					base.serverStatus = (ServerStatusFlags)this.stream.ReadInteger(2);
					this.stream.ReadInteger(2);
					if (this.stream.HasMoreData) {
						this.stream.ReadLenString();
					}
				}
			} catch (MySqlException exception) {
				if (exception.IsFatal) {
					base.isOpen = false;
					this.Close();
				}
				throw;
			}
		}

		public override long ReadResult(ref ulong affectedRows, ref long lastInsertId) {
			if ((base.serverStatus & (ServerStatusFlags.AnotherQuery | ServerStatusFlags.MoreResults)) == 0) {
				return -1L;
			}
			lastInsertId = -1L;
			this.stream.OpenPacket();
			long num = this.stream.ReadFieldLength();
			if (num <= 0L) {
				if (-1L == num) {
					string filename = this.stream.ReadString();
					this.SendFileToServer(filename);
					return this.ReadResult(ref affectedRows, ref lastInsertId);
				}
				base.serverStatus &= ~(ServerStatusFlags.AnotherQuery | ServerStatusFlags.MoreResults);
				affectedRows = (ulong)this.stream.ReadFieldLength();
				lastInsertId = this.stream.ReadFieldLength();
				if (this.version.isAtLeast(4, 1, 0)) {
					base.serverStatus = (ServerStatusFlags)this.stream.ReadInteger(2);
					this.warningCount = this.stream.ReadInteger(2);
					if (this.stream.HasMoreData) {
						this.stream.ReadLenString();
					}
				}
			}
			return num;
		}

		public override void Reset() {
			this.stream.StartOutput(0L, true);
			this.stream.WriteByte(0x11);
			this.Authenticate();
		}

		private void SendFileToServer(string filename) {
			byte[] buffer = new byte[0x2004];
			FileStream stream = null;
			long num = 0L;
			try {
				int num2;
				stream = new FileStream(filename, FileMode.Open);
				for (num = stream.Length; num > 0L; num -= num2) {
					num2 = stream.Read(buffer, 4, (num > 0x2000L) ? ((int)0x2000L) : ((int)num));
					this.stream.SendEntirePacketDirectly(buffer, num2);
				}
				this.stream.SendEntirePacketDirectly(buffer, 0);
			} catch (Exception exception) {
				throw new MySqlException("Error during LOAD DATA LOCAL INFILE", exception);
			} finally {
				stream.Close();
			}
		}

		private void SetConnectionFlags() {
			ClientFlags flags = ClientFlags.FOUND_ROWS;
			if (this.version.isAtLeast(4, 1, 1)) {
				flags |= ClientFlags.PROTOCOL_41;
				flags |= ClientFlags.TRANSACTIONS;
				if (base.connectionString.AllowBatch) {
					flags |= ClientFlags.MULTI_STATEMENTS;
				}
				flags |= ClientFlags.MULTI_RESULTS;
			} else if (this.version.isAtLeast(4, 1, 0)) {
				flags |= ClientFlags.RESERVED;
			}
			if ((base.serverCaps & ClientFlags.LONG_FLAG) != 0) {
				flags |= ClientFlags.LONG_FLAG;
			}
			if (((base.serverCaps & ClientFlags.COMPRESS) != 0) && base.connectionString.UseCompression) {
				flags |= ClientFlags.COMPRESS;
			}
			if (this.protocol > 9) {
				flags |= ClientFlags.LONG_PASSWORD;
			} else {
				flags &= ~ClientFlags.LONG_PASSWORD;
			}
			flags |= ClientFlags.LOCAL_FILES;
			if (base.Settings.InteractiveSession) {
				flags |= ClientFlags.INTERACTIVE;
			}
			if ((((base.serverCaps & ClientFlags.CONNECT_WITH_DB) != 0) && (base.connectionString.Database != null)) && (base.connectionString.Database.Length > 0)) {
				flags |= ClientFlags.CONNECT_WITH_DB;
			}
			if ((base.serverCaps & ClientFlags.SECURE_CONNECTION) != 0) {
				flags |= ClientFlags.SECURE_CONNECTION;
			}
			if (((base.serverCaps & ClientFlags.SSL) != 0) && base.connectionString.UseSSL) {
				flags |= ClientFlags.SSL;
			}
			this.connectionFlags = flags;
		}

		public override void SetDatabase(string dbName) {
			byte[] bytes = base.Encoding.GetBytes(dbName);
			this.ExecuteCommand(DBCmd.INIT_DB, bytes, bytes.Length);
			this.ReadOk(true);
		}

		public override void SkipColumnValue(IMySqlValue valObject) {
			long num = -1L;
			if (this.nullMap == null) {
				num = this.stream.ReadFieldLength();
				if (num == -1L) {
					return;
				}
			}
			if (num > -1L) {
				this.stream.SkipBytes((int)num);
			} else {
				valObject.SkipValue(this.stream);
			}
		}

		public override bool SkipDataRow() {
			bool flag = true;
			if (!this.stream.HasMoreData) {
				flag = this.FetchDataRow(-1, 0, 0);
			}
			if (flag) {
				this.stream.SkipPacket();
			}
			return flag;
		}

		private void StartSSL() {
			RemoteCertificateValidationCallback userCertificateValidationCallback = new RemoteCertificateValidationCallback(NativeDriver.NoServerCheckValidation);
			SslStream baseStream = new SslStream(this.baseStream, true, userCertificateValidationCallback, null);
			try {
				X509CertificateCollection clientCertificates = new X509CertificateCollection();
				baseStream.AuthenticateAsClient(string.Empty, clientCertificates, SslProtocols.Default, false);
				this.baseStream = baseStream;
				this.stream = new MySqlStream(baseStream, base.encoding, false);
				this.stream.SequenceByte = 2;
			} catch (Exception) {
				throw;
			}
		}

		public ClientFlags Flags {
			get { return this.connectionFlags; }
		}

		public override bool SupportsBatch {
			get {
				if ((this.Flags & ClientFlags.MULTI_STATEMENTS) == 0) {
					return false;
				}
				if (this.version.isAtLeast(4, 1, 0) && !this.version.isAtLeast(4, 1, 10)) {
					object obj2 = base.serverProps["query_cache_type"];
					object obj3 = base.serverProps["query_cache_size"];
					if (((obj2 != null) && obj2.Equals("ON")) && ((obj3 != null) && !obj3.Equals("0"))) {
						return false;
					}
				}
				return true;
			}
		}
	}
}

