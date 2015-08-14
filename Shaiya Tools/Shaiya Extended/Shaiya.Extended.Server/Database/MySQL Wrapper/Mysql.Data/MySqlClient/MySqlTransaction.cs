using System;
using System.Data;
using System.Data.Common;

namespace Shaiya.Extended.Server.MySql.Data.MySqlClient {

	public sealed class MySqlTransaction : DbTransaction {
		private MySqlConnection mConnection;
		private System.Data.IsolationLevel mLevel;
		private bool mOpen;

		new public MySqlConnection Connection {
			get { return mConnection; }
		}

		protected override System.Data.Common.DbConnection DbConnection {
			get { return mConnection; }
		}

		public override System.Data.IsolationLevel IsolationLevel {
			get { return mLevel; }
		}


		internal MySqlTransaction( MySqlConnection c, System.Data.IsolationLevel il ) {
			mConnection = c;
			mLevel = il;
			mOpen = true;
		}


		public override void Commit() {
			if( mConnection == null || ( mConnection.State != ConnectionState.Open && !mConnection.SoftClosed ) ) 
				throw new InvalidOperationException( "Connection must be valid and open to commit transaction" );
			if( !mOpen ) 
				throw new InvalidOperationException( "Transaction has already been committed or is not pending" );

			new MySqlCommand( "COMMIT", mConnection ).ExecuteNonQuery();
			mOpen = false;
		}

		protected override void Dispose( bool disposing ) {
			if( ( ( mConnection != null && mConnection.State == ConnectionState.Open ) || mConnection.SoftClosed ) && mOpen )
				Rollback();
			base.Dispose( disposing );
		}

		public override void Rollback() {
			if( mConnection == null || ( mConnection.State != ConnectionState.Open && !mConnection.SoftClosed ) ) 
				throw new InvalidOperationException( "Connection must be valid and open to rollback transaction" );
			if( !this.mOpen )
				throw new InvalidOperationException( "Transaction has already been rolled back or is not pending" );

			new MySqlCommand( "ROLLBACK", mConnection ).ExecuteNonQuery();
			mOpen = false;
		}

	}

}

