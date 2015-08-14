using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Shaiya.Extended.Server.MySql.Data.MySqlClient {

	[Designer( "Shaiya.Extended.Server.MySql.Data.MySqlClient.Design.MySqlDataAdapterDesigner,MySqlClient.Design" ), DesignerCategory( "Code" ), ToolboxBitmap( typeof( MySqlDataAdapter ), "MySqlClient.resources.dataadapter.bmp" )]
	public sealed class MySqlDataAdapter : DbDataAdapter, IDbDataAdapter, IDataAdapter, ICloneable {
		private List<IDbCommand> commandBatch;
		private bool loadingDefaults;
		private int updateBatchSize;

		public event MySqlRowUpdatedEventHandler RowUpdated;

		public event MySqlRowUpdatingEventHandler RowUpdating;

		public MySqlDataAdapter() {
			this.loadingDefaults = true;
			this.updateBatchSize = 1;
		}

		public MySqlDataAdapter( MySqlCommand selectCommand )
			: this() {
			this.SelectCommand = selectCommand;
		}

		public MySqlDataAdapter( string selectCommandText, MySqlConnection connection )
			: this() {
			this.SelectCommand = new MySqlCommand( selectCommandText, connection );
		}

		public MySqlDataAdapter( string selectCommandText, string selectConnString )
			: this() {
			this.SelectCommand = new MySqlCommand( selectCommandText, new MySqlConnection( selectConnString ) );
		}

		protected override int AddToBatch( IDbCommand command ) {
			MySqlCommand command2 = (MySqlCommand)command;
			if( command2.BatchableCommandText == null ) {
				command2.GetCommandTextForBatching();
			}
			IDbCommand item = (IDbCommand)( (ICloneable)command ).Clone();
			this.commandBatch.Add( item );
			return ( this.commandBatch.Count - 1 );
		}

		protected override void ClearBatch() {
			if( this.commandBatch.Count > 0 ) {
				MySqlCommand command = (MySqlCommand)this.commandBatch[ 0 ];
				if( command.Batch != null ) {
					command.Batch.Clear();
				}
			}
			this.commandBatch.Clear();
		}

		protected override RowUpdatedEventArgs CreateRowUpdatedEvent( DataRow dataRow, IDbCommand command, StatementType statementType, DataTableMapping tableMapping ) {
			return new MySqlRowUpdatedEventArgs( dataRow, command, statementType, tableMapping );
		}

		protected override RowUpdatingEventArgs CreateRowUpdatingEvent( DataRow dataRow, IDbCommand command, StatementType statementType, DataTableMapping tableMapping ) {
			return new MySqlRowUpdatingEventArgs( dataRow, command, statementType, tableMapping );
		}

		protected override int ExecuteBatch() {
			int num = 0;
			int num2 = 0;
			while( num2 < this.commandBatch.Count ) {
				MySqlCommand command = (MySqlCommand)this.commandBatch[ num2++ ];
				int num3 = num2;
				while( num3 < this.commandBatch.Count ) {
					MySqlCommand command2 = (MySqlCommand)this.commandBatch[ num3 ];
					if( command2.CommandText != command.CommandText ) {
						break;
					}
					command.AddToBatch( command2 );
					num3++;
					num2++;
				}
				num += command.ExecuteNonQuery();
			}
			return num;
		}

		protected override IDataParameter GetBatchedParameter( int commandIdentifier, int parameterIndex ) {
			return (IDataParameter)this.commandBatch[ commandIdentifier ].Parameters[ parameterIndex ];
		}

		protected override void InitializeBatching() {
			this.commandBatch = new List<IDbCommand>();
		}

		protected override void OnRowUpdated( RowUpdatedEventArgs value ) {
			if( this.RowUpdated != null ) {
				this.RowUpdated( this, value as MySqlRowUpdatedEventArgs );
			}
		}

		protected override void OnRowUpdating( RowUpdatingEventArgs value ) {
			if( this.RowUpdating != null ) {
				this.RowUpdating( this, value as MySqlRowUpdatingEventArgs );
			}
		}

		protected override void TerminateBatching() {
			this.ClearBatch();
			this.commandBatch = null;
		}

		[Description( "Used during Update for deleted rows in Dataset." )]
		new public MySqlCommand DeleteCommand {
			get { return (MySqlCommand)base.DeleteCommand; }
			set { base.DeleteCommand = value; }
		}

		[Description( "Used during Update for new rows in Dataset." )]
		new public MySqlCommand InsertCommand {
			get { return (MySqlCommand)base.InsertCommand; }
			set { base.InsertCommand = value; }
		}

		internal bool LoadDefaults {
			get { return this.loadingDefaults; }
			set { this.loadingDefaults = value; }
		}

		[Description( "Used during Fill/FillSchema" ), Category( "Fill" )]
		new public MySqlCommand SelectCommand {
			get { return (MySqlCommand)base.SelectCommand; }
			set { base.SelectCommand = value; }
		}

		public override int UpdateBatchSize {
			get { return this.updateBatchSize; }
			set { this.updateBatchSize = value; }
		}

		[Description( "Used during Update for modified rows in Dataset." )]
		new public MySqlCommand UpdateCommand {
			get { return (MySqlCommand)base.UpdateCommand; }
			set { base.UpdateCommand = value; }
		}

	}

}

