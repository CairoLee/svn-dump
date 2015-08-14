namespace Shaiya.Extended.Server.MySql.Data.MySqlClient {
	using Shaiya.Extended.Server.MySql.Data.Common;
	using Shaiya.Extended.Server.MySql.Data.MySqlClient.Properties;
	using System;
	using System.ComponentModel;
	using System.Data;
	using System.Data.Common;
	using System.Drawing;
	using System.Drawing.Design;
	using System.Runtime.CompilerServices;
	using System.Text;
	using System.Transactions;

	[ToolboxBitmap( typeof( MySqlConnection ), "MySqlClient.resources.connection.bmp" ), DesignerCategory( "Code" ), ToolboxItem( true )]
	public sealed class MySqlConnection : DbConnection, ICloneable {
		private Shaiya.Extended.Server.MySql.Data.MySqlClient.UsageAdvisor advisor;
		internal ConnectionState connectionState;
		private static Cache<string, MySqlConnectionStringBuilder> connectionStringCache = new Cache<string, MySqlConnectionStringBuilder>( 0, 0x19 );
		private string database;
		private MySqlDataReader dataReader;
		internal Driver driver;
		private bool hasBeenOpen;
		private bool isExecutingBuggyQuery;
		private PerformanceMonitor perfMonitor;
		private Shaiya.Extended.Server.MySql.Data.MySqlClient.ProcedureCache procedureCache;
		private SchemaProvider schemaProvider;
		private MySqlConnectionStringBuilder settings;

		public event MySqlInfoMessageEventHandler InfoMessage;

		public MySqlConnection() {
			this.settings = new MySqlConnectionStringBuilder();
			this.advisor = new Shaiya.Extended.Server.MySql.Data.MySqlClient.UsageAdvisor( this );
			this.database = string.Empty;
		}

		public MySqlConnection( string connectionString )
			: this() {
			this.ConnectionString = connectionString;
		}

		internal void Abort() {
			try {
				if( this.settings.Pooling ) {
					MySqlPoolManager.ReleaseConnection( this.driver );
				} else {
					this.driver.Close();
				}
			} catch( Exception ) {
			}
			this.SetState( ConnectionState.Closed, true );
		}

		protected override DbTransaction BeginDbTransaction( System.Data.IsolationLevel isolationLevel ) {
			if( isolationLevel == System.Data.IsolationLevel.Unspecified ) {
				return this.BeginTransaction();
			}
			return this.BeginTransaction( isolationLevel );
		}

		new public MySqlTransaction BeginTransaction() {
			return this.BeginTransaction( System.Data.IsolationLevel.RepeatableRead );
		}

		new public MySqlTransaction BeginTransaction( System.Data.IsolationLevel iso ) {
			if( this.State != ConnectionState.Open ) {
				throw new InvalidOperationException( Resources.ConnectionNotOpen );
			}
			if( ( this.driver.ServerStatus & ServerStatusFlags.InTransaction ) != 0 ) {
				throw new InvalidOperationException( Resources.NoNestedTransactions );
			}
			MySqlTransaction transaction = new MySqlTransaction( this, iso );
			MySqlCommand command = new MySqlCommand( "", this );
			command.CommandText = "SET SESSION TRANSACTION ISOLATION LEVEL ";
			switch( iso ) {
				case System.Data.IsolationLevel.Chaos:
					throw new NotSupportedException( Resources.ChaosNotSupported );

				case System.Data.IsolationLevel.ReadUncommitted:
					command.CommandText = command.CommandText + "READ UNCOMMITTED";
					goto Label_00F1;

				case System.Data.IsolationLevel.ReadCommitted:
					command.CommandText = command.CommandText + "READ COMMITTED";
					break;

				case System.Data.IsolationLevel.RepeatableRead:
					command.CommandText = command.CommandText + "REPEATABLE READ";
					break;

				case System.Data.IsolationLevel.Serializable:
					command.CommandText = command.CommandText + "SERIALIZABLE";
					break;
			}
Label_00F1:
			command.ExecuteNonQuery();
			command.CommandText = "BEGIN";
			command.ExecuteNonQuery();
			return transaction;
		}

		public override void ChangeDatabase( string databaseName ) {
			if( ( databaseName == null ) || ( databaseName.Trim().Length == 0 ) ) {
				throw new ArgumentException( Resources.ParameterIsInvalid, "databaseName" );
			}
			if( this.State != ConnectionState.Open ) {
				throw new InvalidOperationException( Resources.ConnectionNotOpen );
			}
			this.driver.SetDatabase( databaseName );
			this.database = databaseName;
		}

		public static void ClearAllPools() {
			MySqlPoolManager.ClearAllPools();
		}

		public static void ClearPool( MySqlConnection connection ) {
			MySqlPoolManager.ClearPool( connection.Settings );
		}

		public override void Close() {
			if( this.State != ConnectionState.Closed ) {
				if( this.dataReader != null ) {
					this.dataReader.Close();
				}
				if( this.driver != null ) {
					if( this.driver.CurrentTransaction == null ) {
						this.CloseFully();
					} else {
						this.driver.IsInActiveUse = false;
					}
				}
				this.SetState( ConnectionState.Closed, true );
			}
		}

		internal void CloseFully() {
			if( this.settings.Pooling && this.driver.IsOpen ) {
				if( ( this.driver.ServerStatus & ServerStatusFlags.InTransaction ) != 0 ) {
					new MySqlTransaction( this, System.Data.IsolationLevel.Unspecified ).Rollback();
				}
				MySqlPoolManager.ReleaseConnection( this.driver );
			} else {
				this.driver.Close();
			}
			this.driver = null;
		}

		new public MySqlCommand CreateCommand() {
			MySqlCommand command = new MySqlCommand();
			command.Connection = this;
			return command;
		}

		protected override DbCommand CreateDbCommand() {
			return this.CreateCommand();
		}

		internal string CurrentDatabase() {
			if( ( this.Database != null ) && ( this.Database.Length > 0 ) ) {
				return this.Database;
			}
			MySqlCommand command = new MySqlCommand( "SELECT database()", this );
			return command.ExecuteScalar().ToString();
		}

		protected override void Dispose( bool disposing ) {
			if( disposing && ( this.State == ConnectionState.Open ) ) {
				this.Close();
			}
			base.Dispose( disposing );
		}

		public override void EnlistTransaction( Transaction transaction ) {
			if( transaction != null ) {
				if( this.driver.CurrentTransaction != null ) {
					if( this.driver.CurrentTransaction.BaseTransaction != transaction ) {
						throw new MySqlException( "Already enlisted" );
					}
				} else {
					Driver driverInTransaction = DriverTransactionManager.GetDriverInTransaction( transaction );
					if( driverInTransaction != null ) {
						if( driverInTransaction.IsInActiveUse ) {
							throw new NotSupportedException( Resources.MultipleConnectionsInTransactionNotSupported );
						}
						string connectionString = driverInTransaction.Settings.GetConnectionString( true );
						string strB = this.Settings.GetConnectionString( true );
						if( string.Compare( connectionString, strB, true ) != 0 ) {
							throw new NotSupportedException( Resources.MultipleConnectionsInTransactionNotSupported );
						}
						this.CloseFully();
						this.driver = driverInTransaction;
					}
					if( this.driver.CurrentTransaction == null ) {
						MySqlPromotableTransaction promotableSinglePhaseNotification = new MySqlPromotableTransaction( this, transaction );
						if( !transaction.EnlistPromotableSinglePhase( promotableSinglePhaseNotification ) ) {
							throw new NotSupportedException( Resources.DistributedTxnNotSupported );
						}
						this.driver.CurrentTransaction = promotableSinglePhaseNotification;
						DriverTransactionManager.SetDriverInTransaction( this.driver );
						this.driver.IsInActiveUse = true;
					}
				}
			}
		}

		public override DataTable GetSchema() {
			return this.GetSchema( null );
		}

		public override DataTable GetSchema( string collectionName ) {
			if( collectionName == null ) {
				collectionName = SchemaProvider.MetaCollection;
			}
			return this.GetSchema( collectionName, null );
		}

		public override DataTable GetSchema( string collectionName, string[] restrictionValues ) {
			if( collectionName == null ) {
				collectionName = SchemaProvider.MetaCollection;
			}
			string[] restrictions = null;
			if( restrictionValues != null ) {
				restrictions = (string[])restrictionValues.Clone();
				for( int i = 0; i < restrictions.Length; i++ ) {
					string str = restrictions[ i ];
					if( str != null ) {
						if( str.StartsWith( "`" ) ) {
							str = str.Substring( 1 );
						}
						if( str.EndsWith( "`" ) ) {
							str = str.Substring( 0, str.Length - 1 );
						}
						restrictions[ i ] = str;
					}
				}
			}
			return this.schemaProvider.GetSchema( collectionName, restrictions );
		}

		internal void OnInfoMessage( MySqlInfoMessageEventArgs args ) {
			if( this.InfoMessage != null ) {
				this.InfoMessage( this, args );
			}
		}

		public override void Open() {
			if( this.State == ConnectionState.Open ) {
				throw new InvalidOperationException( Resources.ConnectionAlreadyOpen );
			}
			this.SetState( ConnectionState.Connecting, true );
			if( this.settings.AutoEnlist && ( Transaction.Current != null ) ) {
				this.driver = DriverTransactionManager.GetDriverInTransaction( Transaction.Current );
				if( ( this.driver != null ) && ( this.driver.IsInActiveUse || !this.driver.Settings.EquivalentTo( this.Settings ) ) ) {
					throw new NotSupportedException( Resources.MultipleConnectionsInTransactionNotSupported );
				}
			}
			try {
				if( this.settings.Pooling ) {
					MySqlPool pool = MySqlPoolManager.GetPool( this.settings );
					if( this.driver == null ) {
						this.driver = pool.GetConnection();
					}
					this.procedureCache = pool.ProcedureCache;
				} else {
					if( this.driver == null ) {
						this.driver = Driver.Create( this.settings );
					}
					this.procedureCache = new Shaiya.Extended.Server.MySql.Data.MySqlClient.ProcedureCache( (int)this.settings.ProcedureCacheSize );
				}
			} catch( Exception ) {
				this.SetState( ConnectionState.Closed, true );
				throw;
			}
			this.SetState( ConnectionState.Open, false );
			this.driver.Configure( this );
			if( ( this.settings.Database != null ) && ( this.settings.Database != string.Empty ) ) {
				this.ChangeDatabase( this.settings.Database );
			}
			if( this.driver.Version.isAtLeast( 5, 0, 0 ) ) {
				this.schemaProvider = new ISSchemaProvider( this );
			} else {
				this.schemaProvider = new SchemaProvider( this );
			}
			this.perfMonitor = new PerformanceMonitor( this );
			if( ( Transaction.Current != null ) && this.settings.AutoEnlist ) {
				this.EnlistTransaction( Transaction.Current );
			}
			this.hasBeenOpen = true;
			this.SetState( ConnectionState.Open, true );
		}

		public bool Ping() {
			if( ( this.driver != null ) && this.driver.Ping() )
				return true;

			this.driver = null;
			this.SetState( ConnectionState.Closed, true );
			return false;
		}

		internal void SetState( ConnectionState newConnectionState, bool broadcast ) {
			if( ( newConnectionState != this.connectionState ) || broadcast ) {
				ConnectionState connectionState = this.connectionState;
				this.connectionState = newConnectionState;
				if( broadcast ) {
					this.OnStateChange( new StateChangeEventArgs( connectionState, this.connectionState ) );
				}
			}
		}

		object ICloneable.Clone() {
			MySqlConnection connection = new MySqlConnection();
			string connectionString = this.settings.GetConnectionString( true );
			if( connectionString != null )
				connection.ConnectionString = connectionString;
			return connection;
		}

		[Editor( "Shaiya.Extended.Server.MySql.Data.MySqlClient.Design.ConnectionStringTypeEditor,MySqlClient.Design", typeof( UITypeEditor ) ), Description( "Information used to connect to a DataSource, such as 'Server=xxx;UserId=yyy;Password=zzz;Database=dbdb'." ), Browsable( true ), Category( "Data" )]
		public override string ConnectionString {
			get { return this.settings.GetConnectionString( !this.hasBeenOpen || this.settings.PersistSecurityInfo ); }
			set {
				MySqlConnectionStringBuilder builder;
				if( this.State != ConnectionState.Closed ) {
					throw new MySqlException( "Not allowed to change the 'ConnectionString' property while the connection (state=" + this.State + ")." );
				}
				lock( connectionStringCache ) {
					if( value == null ) {
						builder = new MySqlConnectionStringBuilder();
					} else {
						builder = connectionStringCache[ value ];
						if( builder == null ) {
							builder = new MySqlConnectionStringBuilder( value );
							connectionStringCache.Add( value, builder );
						}
					}
				}
				this.settings = builder;
				if( ( this.settings.Database != null ) && ( this.settings.Database.Length > 0 ) )
					this.database = this.settings.Database;

				if( this.driver != null )
					this.driver.Settings = builder;

			}
		}

		[Browsable( true )]
		public override int ConnectionTimeout {
			get { return (int)this.settings.ConnectionTimeout; }
		}

		[Browsable( true )]
		public override string Database {
			get { return this.database; }
		}

		[Browsable( true )]
		public override string DataSource {
			get { return this.settings.Server; }
		}

		internal System.Text.Encoding Encoding {
			get {
				if( this.driver == null )
					return System.Text.Encoding.Default;
				return this.driver.Encoding;
			}
		}

		internal bool IsExecutingBuggyQuery {
			get { return this.isExecutingBuggyQuery; }
			set { this.isExecutingBuggyQuery = value; }
		}

		internal PerformanceMonitor PerfMonitor {
			get { return this.perfMonitor; }
		}

		internal Shaiya.Extended.Server.MySql.Data.MySqlClient.ProcedureCache ProcedureCache {
			get { return this.procedureCache; }
		}

		internal MySqlDataReader Reader {
			get { return this.dataReader; }
			set { this.dataReader = value; }
		}

		[Browsable( false )]
		public int ServerThread {
			get { return this.driver.ThreadID; }
		}

		[Browsable( false )]
		public override string ServerVersion {
			get { return this.driver.Version.ToString(); }
		}

		internal MySqlConnectionStringBuilder Settings {
			get { return this.settings; }
		}

		internal bool SoftClosed {
			get { return this.State == ConnectionState.Closed && this.driver != null && this.driver.CurrentTransaction != null; }
		}

		[Browsable( false )]
		public override ConnectionState State {
			get { return this.connectionState; }
		}

		[Browsable( false )]
		internal Shaiya.Extended.Server.MySql.Data.MySqlClient.UsageAdvisor UsageAdvisor {
			get { return this.advisor; }
		}

		[Browsable( false )]
		public bool UseCompression {
			get { return this.settings.UseCompression; }
		}
	}
}

