using System;
using System.Data;
using System.Transactions;

namespace Shaiya.Extended.Server.MySql.Data.MySqlClient {

	internal sealed class MySqlPromotableTransaction : IPromotableSinglePhaseNotification, ITransactionPromoter {
		private Transaction baseTransaction;
		private MySqlConnection connection;
		private MySqlTransaction simpleTransaction;

		public MySqlPromotableTransaction( MySqlConnection connection, Transaction baseTransaction ) {
			this.connection = connection;
			this.baseTransaction = baseTransaction;
		}

		void IPromotableSinglePhaseNotification.Initialize() {
			string name = Enum.GetName( typeof( System.Transactions.IsolationLevel ), this.baseTransaction.IsolationLevel );
			System.Data.IsolationLevel iso = (System.Data.IsolationLevel)Enum.Parse( typeof( System.Data.IsolationLevel ), name );
			this.simpleTransaction = this.connection.BeginTransaction( iso );
		}

		void IPromotableSinglePhaseNotification.Rollback( SinglePhaseEnlistment singlePhaseEnlistment ) {
			this.simpleTransaction.Rollback();
			singlePhaseEnlistment.Aborted();
			DriverTransactionManager.RemoveDriverInTransaction( this.baseTransaction );
			this.connection.driver.CurrentTransaction = null;
			if( this.connection.State == ConnectionState.Closed ) {
				this.connection.CloseFully();
			}
		}

		void IPromotableSinglePhaseNotification.SinglePhaseCommit( SinglePhaseEnlistment singlePhaseEnlistment ) {
			this.simpleTransaction.Commit();
			singlePhaseEnlistment.Committed();
			DriverTransactionManager.RemoveDriverInTransaction( this.baseTransaction );
			this.connection.driver.CurrentTransaction = null;
			if( this.connection.State == ConnectionState.Closed ) {
				this.connection.CloseFully();
			}
		}

		byte[] ITransactionPromoter.Promote() {
			throw new NotSupportedException();
		}

		public Transaction BaseTransaction {
			get { return this.baseTransaction; }
		}

	}

}

