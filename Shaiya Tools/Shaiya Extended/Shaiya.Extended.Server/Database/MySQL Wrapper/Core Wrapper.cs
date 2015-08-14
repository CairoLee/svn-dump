using System;
using System.Data;
using System.IO;
using System.Text;
using Shaiya.Extended.Server.MySql.Data.MySqlClient;

namespace Shaiya.Extended.Server.MySql {

	public enum MysqlState {
		Closed = 1,
		Open = 2,

		Error = 10
	}

	public enum MysqlError {
		/// <summary>
		/// No Error, all went fine
		/// </summary>
		None = 0,

		/***************
		 * Open() 
		 ***************/

		/// <summary>
		/// <see cref="mConnection"/> was not Instanced
		/// </summary>
		OpenBeforeInit,
		/// <summary>
		/// catched Exception, Invalid Connection Info or something else
		/// </summary>
		CanNotConnectToDB,
		/// <summary>
		/// No Exception, but cant open SQL Connection
		/// </summary>
		FailedToOpen,
		/// <summary>
		/// catched Exception, unkown thing while trying <see cref="Open"/>() Method
		/// </summary>
		UnknownOpen,



		/***************
		 * Close() 
		 ***************/

		/// <summary>
		/// <see cref="mConnection"/> was not Instanced
		/// </summary>
		CloseBeforeInit,
		/// <summary>
		/// catched Exception, unkown thing while trying <see cref="Close"/>() Method
		/// </summary>
		CanNotDisconnectFromDB,
		/// <summary>
		/// No Exception, but cant close SQL Connection
		/// </summary>
		FailedToClose,
		/// <summary>
		/// catched Exception, unkown thing while trying <see cref="Close"/>() Method
		/// </summary>
		UnknownClose,
	}

	public class MySqlWrapper : IDisposable {

		#region Variable Declare
		private MySqlConnection mConnection;
		private MySqlCommand mCommand;
		private MySqlDataAdapter mAdapter;
		private MySqlDataReader mReader;
		private Exception mLastError;
		private MysqlState mState;

		private string mConnectionString;
		internal string mServer;
		internal int mPort;
		internal string mUser;
		internal string mPassword;
		private string mDatabase;
		#endregion

		
		#region Setter and Getter

		public MysqlState State {
			get { return mState; }
		}

		/// <summary>
		/// returns the Last thrown Exception
		/// </summary>
		public Exception LastError {
			get { return mLastError; }
		}

		/// <summary>
		/// returns the MySqlConnection object
		/// </summary>
		public MySqlConnection Connection {
			get { return mConnection; }
		}

		/// <summary>
		/// returns the MySqlCommand object
		/// </summary>
		public MySqlCommand Command {
			get { return mCommand; }
		}

		/// <summary>
		/// returns the MySqlDataAdapter object
		/// </summary>
		public MySqlDataAdapter Apdapter {
			get { return mAdapter; }
		}

		/// <summary>
		/// returns the MySqlDataReader object
		/// </summary>
		public MySqlDataReader Reader {
			get { return mReader; }
		}

		/// <summary>
		/// returns or sets the Connection string
		/// </summary>
		public string ConnectionString {
			get { return mConnectionString; }
			set { mConnectionString = value; }
		}

		/// <summary>
		/// returns or sets the Database
		/// <para>If set, the Connection will be re-created - see <see cref="Prepare"/>()</para>
		/// </summary>
		public string Database {
			get { return mDatabase; }
			set {
				mDatabase = value;
				Prepare(); // rebuild Connection
			}
		}

		/// <summary>
		/// returns true/false about the <see cref="System.Data.ConnectionState"/>
		/// </summary>
		public bool IsConnected {
			get { return mConnection != null && mConnection.State == System.Data.ConnectionState.Open; }
		}

		/// <summary>
		/// returns the <see cref="ConnectionHolder"/> Object
		/// </summary>
		public ConnectionHolder ConnectionHolder {
			get { return new ConnectionHolder( mServer, mPort, mUser, mPassword, mDatabase ); }
		}
		#endregion

		
		#region Constructor
		/// <summary>
		/// Main Constructor - will instance a new MySqlConnection without Open.
		/// </summary>
		/// <param name="Server"></param>
		/// <param name="User"></param>
		/// <param name="Password"></param>
		/// <param name="Database"></param>
		public MySqlWrapper( string Server, int Port, string User, string Password, string Database ) {
			mServer = Server;
			mPort = Port;
			mUser = User;
			mPassword = Password;
			mDatabase = Database;
			mState = MysqlState.Closed;
		}

		/// <summary>
		/// Main Constructor - will instance a new MySqlConnection without Open.
		/// </summary>
		public MySqlWrapper() {
			mState = MysqlState.Closed;
		} 
		#endregion

		
		#region Prepare(), Open(), Close()
		/// <summary>
		/// Method to set the <see cref="mConnectionString"/> and <see cref="mConnection"/>
		/// <para>Also, the Connection will be Opened and Closed afterwards</para>
		/// </summary>
		public MysqlError Prepare() {
			MysqlError result = MysqlError.None;
			mConnectionString = String.Format( "SERVER={0};PORT={1};UID={2};PASSWORD={3};DATABASE={4};", mServer, mPort, mUser, mPassword, mDatabase );
			mConnection = new MySqlConnection( mConnectionString );

			result = Open();
			if( result == MysqlError.None )
				result = Close( false );

			return result;
		}

		/// <summary>
		/// method to Open an instanced Connection
		/// </summary>
		/// <returns></returns>
		public MysqlError Open() {
			mLastError = null;

			if( mConnection == null )
				return MysqlError.OpenBeforeInit;

			// no need to open if allready done
			if( mConnection.State == System.Data.ConnectionState.Open ) {
				mState = MysqlState.Open;
				return MysqlError.None;
			}

			try {
				mConnection.Open();

				if( mConnection.State != System.Data.ConnectionState.Open ) {
					mState = MysqlState.Error;
					return MysqlError.FailedToOpen;
				}
			} catch( MySqlException e ) {
				mState = MysqlState.Error;
				mLastError = e;
				return MysqlError.CanNotConnectToDB;
			} catch( Exception e ) {
				mState = MysqlState.Error;
				mLastError = e;
				return MysqlError.UnknownOpen;
			}

			mState = MysqlState.Open;
			return MysqlError.None;
		}

		/// <summary>
		/// internal method to Close an instanced Connection
		/// </summary>
		/// <param name="FreeConnection"></param>
		/// <returns></returns>
		public MysqlError Close( bool FreeConnection ) {
			mLastError = null;

			if( mConnection == null ) {
				mState = MysqlState.Error;
				return MysqlError.CloseBeforeInit;
			}

			try {
				mConnection.Close();

				if( mConnection.State != System.Data.ConnectionState.Closed ) {
					mState = MysqlState.Error;
					return MysqlError.FailedToClose;
				}
			} catch( MySqlException e ) {
				mState = MysqlState.Error;
				mLastError = e;
				return MysqlError.CanNotDisconnectFromDB;
			} catch( Exception e ) {
				mState = MysqlState.Error;
				mLastError = e;
				return MysqlError.UnknownClose;
			} finally {
				// free Memory
				if( mCommand != null )
					mCommand.Dispose();
				if( mAdapter != null )
					mAdapter.Dispose();
				if( FreeConnection == true && mConnection != null )
					mConnection.Dispose();
			}

			mState = MysqlState.Closed;
			return MysqlError.None;
		} 
		#endregion

		public MysqlError Init( ConnectionHolder Holder ) {
			mServer = Holder.Host;
			mPort = Holder.Port;
			mUser = Holder.Username;
			mPassword = Holder.Password;
			mDatabase = Holder.Database;

			return Prepare();
		}


		/// <summary>
		/// Returns the MySQL LAST_INSERT_ID() Statement
		/// </summary>
		/// <returns></returns>
		public int GetLastInsertID() {
			ResultTable table = Query( "SELECT LAST_INSERT_ID()" );
			if( table.Rows.Count == 0 )
				return -1;

			return table[ 0 ][ 0 ].GetInt();
		}
		
		#region Query Methods
		/// <summary>
		/// Executes a simple Query and returns the Affected Rows
		/// </summary>
		/// <param name="Query"></param>
		/// <param name="arg"></param>
		/// <returns></returns>
		public int QuerySimple( string Query, params object[] arg ) {
			return QuerySimple( String.Format( Query, arg ) );
		}

		/// <summary>
		/// Executes a simple Query and returns the Affected Rows
		/// </summary>
		/// <param name="Query"></param>
		/// <returns></returns>
		public int QuerySimple( string Query ) {
			int result = 0;
			mLastError = null;
			if( Query.Length == 0 )
				return result;

			try {
				Open();
				mCommand = mConnection.CreateCommand();
				mCommand.CommandText = Query;

				result = mCommand.ExecuteNonQuery();
			} catch( Exception ex ) {
				System.Diagnostics.Debug.WriteLine( ex );
				mLastError = ex;
				return 0;
			}

			return result;
		}

		/// <summary>
		/// Loads all Text from an File and try to Execute the Commands
		/// <para>Used the Basic Enconding "<see cref="Encoding.Default"/>"</para>
		/// <para>Used <see cref="QuerySimple"/>, so the return will be the Affected Rows</para>
		/// </summary>
		/// <param name="FilePath"></param>
		/// <returns>Affected Row Count</returns>
		public int QueryFromFile( string FilePath ) {
			return QueryFromFile( FilePath, Encoding.Default );
		}

		/// <summary>
		/// Loads all Text from an File and try to Execute the Commands
		/// <para>Used <see cref="QuerySimple"/>, so the return will be the Affected Rows</para>
		/// </summary>
		/// <param name="FilePath"></param>
		/// <param name="Enc"></param>
		/// <returns>Affected Row Count</returns>
		public int QueryFromFile( string FilePath, Encoding Enc ) {
			return QuerySimple( File.ReadAllText( FilePath, Enc ) );
		}

		/// <summary>
		/// Executes a simple Query and Reads the first <see cref="Int32"/> Value!
		/// </summary>
		/// <param name="Query"></param>
		/// <param name="arg"></param>
		/// <returns>the first <see cref="Int32"/> Value ( Value > 0 )</returns>
		public bool QueryBool( string query, params object[] arg ) {
			return QueryBool( string.Format( query, arg ) );
		}

		/// <summary>
		/// Executes a simple Query and Reads the first <see cref="Int32"/> Value!
		/// </summary>
		/// <param name="Query"></param>
		/// <returns>the first <see cref="Int32"/> Value ( Value > 0 )</returns>
		public bool QueryBool( string Query ) {
			bool result = false;
			mLastError = null;
			if( Query.Length == 0 )
				return result;
			
			try {
				Open();
				mCommand = mConnection.CreateCommand();
				mCommand.CommandText = Query;

				mReader = mCommand.ExecuteReader();
				while( mReader.Read() ) {
					result = ( mReader.GetInt32( 0 ) > 0 );
				}
				mReader.Close();
			} catch( Exception ex ) {
				System.Diagnostics.Debug.WriteLine( ex );
				mLastError = ex;
				return false;
			}

			return result;
		}

		/// <summary>
		/// Executes a Query and returns all Results in a <see cref="DataTable"/>
		/// </summary>
		/// <param name="Query"></param>
		/// <param name="arg"></param>
		/// <returns>
		/// DataTable withh all Results
		/// <para>NOTE: the DataTable will be null if an Error occours</para>
		/// </returns>
		public ResultTable Query( string query, params object[] arg ) {
			return Query( string.Format( query, arg ) );
		}

		/// <summary>
		/// Executes a Query and returns all Results in a <see cref="DataTable"/>
		/// </summary>
		/// <param name="Query"></param>
		/// <returns>
		/// DataTable withh all Results
		/// <para>NOTE: the DataTable will be null if an Error occours</para>
		/// </returns>
		public ResultTable Query( string Query ) {
			DataTable result = new DataTable();
			mLastError = null;
			if( Query.Length == 0 )
				return new ResultTable();

			Open();

			mAdapter = new MySqlDataAdapter();
			mAdapter.SelectCommand = new MySqlCommand( Query, mConnection );
			try {
				mAdapter.Fill( result );
			} catch( Exception ex ) {
				System.Diagnostics.Debug.WriteLine( ex );
				mLastError = ex;
				return new ResultTable();
			}

			return new ResultTable( result );
		}

		/// <summary>
		/// Executes a Query and returns the first int32 Value
		/// </summary>
		/// <param name="Query"></param>
		/// <param name="arg"></param>
		public int QueryCount( string Query, params object[] arg ) {
			return QueryCount( string.Format( Query, arg ) );
		}

		/// <summary>
		/// Executes a Query and returns the first int32 Value
		/// </summary>
		/// <param name="Query"></param>
		public int QueryCount( string Query ) {
			DataTable result = new DataTable();
			mLastError = null;
			if( Query.Length == 0 )
				return 0;

			Open();

			mAdapter = new MySqlDataAdapter();
			mAdapter.SelectCommand = new MySqlCommand( Query, mConnection );
			try {
				mAdapter.Fill( result );
			} catch( Exception ex ) {
				System.Diagnostics.Debug.WriteLine( ex );
				mLastError = ex;
				return 0;
			}

			ResultTable table = new ResultTable( result );
			if( table.Rows.Count == 0 )
				return 0;

			return table.Rows[ 0 ][ 0 ].GetInt32();
		}
		#endregion


		/// <summary>
		/// prints all DataTypes of the Table Fields (for Debug and Tests)
		/// </summary>
		/// <param name="Table"></param>
		public static void PrintTableTypes( DataTable Table ) {
			for( int i = 0; i < Table.Columns.Count; i++ ) {
				Console.WriteLine( "{0}: {1}", Table.Columns[ i ].ColumnName, Table.Columns[ i ].DataType );
			}

		}



		public void Dispose() {
			Close( true );
		}

		void IDisposable.Dispose() {
			Dispose();
		}
	}

}
