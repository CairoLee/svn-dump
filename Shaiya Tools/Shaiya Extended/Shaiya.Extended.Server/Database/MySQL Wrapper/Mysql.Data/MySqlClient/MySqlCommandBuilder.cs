using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Text;
using Shaiya.Extended.Server.MySql.Data.MySqlClient.Properties;
using Shaiya.Extended.Server.MySql.Data.Types;

namespace Shaiya.Extended.Server.MySql.Data.MySqlClient {

	[ToolboxItem( false ), DesignerCategory( "Code" )]
	public sealed class MySqlCommandBuilder : DbCommandBuilder {
		private string finalSelect;
		private bool returnGeneratedIds;

		new public MySqlDataAdapter DataAdapter {
			get { return (MySqlDataAdapter)base.DataAdapter; }
			set { base.DataAdapter = value; }
		}

		public bool ReturnGeneratedIdentifiers {
			get { return this.returnGeneratedIds; }
			set { this.returnGeneratedIds = value; }
		}


		public MySqlCommandBuilder() {
			this.QuotePrefix = this.QuoteSuffix = "`";
			this.ReturnGeneratedIdentifiers = true;
		}

		public MySqlCommandBuilder( MySqlDataAdapter adapter )
			: this() {
			this.DataAdapter = adapter;
		}


		protected override void ApplyParameterInfo( DbParameter parameter, DataRow row, StatementType statementType, bool whereClause ) {
			( (MySqlParameter)parameter ).MySqlDbType = (MySqlDbType)row[ "ProviderType" ];
		}

		private void CreateFinalSelect() {
			StringBuilder builder = new StringBuilder();
			foreach( DataRow row in this.GetSchemaTable( this.DataAdapter.SelectCommand ).Rows ) {
				if( (bool)row[ "IsAutoIncrement" ] ) {
					builder.AppendFormat( CultureInfo.InvariantCulture, "; SELECT last_insert_id() AS `{0}`", new object[] { row[ "ColumnName" ] } );
					break;
				}
			}
			this.finalSelect = builder.ToString();
		}

		public static void DeriveParameters( MySqlCommand command ) {
			if( !command.Connection.driver.Version.isAtLeast( 5, 0, 0 ) ) {
				throw new MySqlException( "DeriveParameters is not supported on MySQL versions prior to 5.0" );
			}
			string commandText = command.CommandText;
			if( commandText.IndexOf( "." ) == -1 ) {
				commandText = command.Connection.Database + "." + commandText;
			}
			DataSet procedure = command.Connection.ProcedureCache.GetProcedure( command.Connection, commandText );
			DataTable table = procedure.Tables[ "Procedure Parameters" ];
			DataTable table2 = procedure.Tables[ "Procedures" ];
			command.Parameters.Clear();
			foreach( DataRow row in table.Rows ) {
				MySqlParameter parameter = new MySqlParameter();
				parameter.ParameterName = string.Format( "@{0}", row[ "PARAMETER_NAME" ] );
				parameter.Direction = GetDirection( row );
				bool unsigned = StoredProcedure.GetFlags( row[ "DTD_IDENTIFIER" ].ToString() ).IndexOf( "UNSIGNED" ) != -1;
				bool realAsFloat = table2.Rows[ 0 ][ "SQL_MODE" ].ToString().IndexOf( "REAL_AS_FLOAT" ) != -1;
				parameter.MySqlDbType = MetaData.NameToType( row[ "DATA_TYPE" ].ToString(), unsigned, realAsFloat, command.Connection );
				if( !row[ "CHARACTER_MAXIMUM_LENGTH" ].Equals( DBNull.Value ) ) {
					parameter.Size = (int)row[ "CHARACTER_MAXIMUM_LENGTH" ];
				}
				if( !row[ "NUMERIC_PRECISION" ].Equals( DBNull.Value ) ) {
					parameter.Precision = (byte)row[ "NUMERIC_PRECISION" ];
				}
				if( !row[ "NUMERIC_SCALE" ].Equals( DBNull.Value ) ) {
					parameter.Scale = (byte)( (int)row[ "NUMERIC_SCALE" ] );
				}
				command.Parameters.Add( parameter );
			}
		}

		new public MySqlCommand GetDeleteCommand() {
			return (MySqlCommand)base.GetDeleteCommand();
		}

		private static ParameterDirection GetDirection( DataRow row ) {
			string str = row[ "PARAMETER_MODE" ].ToString();
			if( Convert.ToInt32( row[ "ORDINAL_POSITION" ] ) == 0 ) {
				return ParameterDirection.ReturnValue;
			}
			switch( str ) {
				case "IN":
					return ParameterDirection.Input;

				case "OUT":
					return ParameterDirection.Output;
			}
			return ParameterDirection.InputOutput;
		}

		new public MySqlCommand GetInsertCommand() {
			return (MySqlCommand)base.GetInsertCommand( false );
		}

		protected override string GetParameterName( int parameterOrdinal ) {
			return string.Format( "@p{0}", parameterOrdinal.ToString( CultureInfo.InvariantCulture ) );
		}

		protected override string GetParameterName( string parameterName ) {
			StringBuilder builder = new StringBuilder( parameterName );
			builder.Replace( " ", "" );
			builder.Replace( "/", "_per_" );
			builder.Replace( "-", "_" );
			builder.Replace( ")", "_cb_" );
			builder.Replace( "(", "_ob_" );
			builder.Replace( "%", "_pct_" );
			builder.Replace( "<", "_lt_" );
			builder.Replace( ">", "_gt_" );
			builder.Replace( ".", "_pt_" );
			return string.Format( "@{0}", builder.ToString() );
		}

		protected override string GetParameterPlaceholder( int parameterOrdinal ) {
			return string.Format( "@p{0}", parameterOrdinal.ToString( CultureInfo.InvariantCulture ) );
		}

		new public MySqlCommand GetUpdateCommand() {
			return (MySqlCommand)base.GetUpdateCommand();
		}

		protected override DbCommand InitializeCommand( DbCommand command ) {
			return base.InitializeCommand( command );
		}

		public override string QuoteIdentifier( string unquotedIdentifier ) {
			if( unquotedIdentifier == null ) {
				throw new ArgumentNullException( "unquotedIdentifier" );
			}
			if( unquotedIdentifier.StartsWith( this.QuotePrefix ) && unquotedIdentifier.EndsWith( this.QuoteSuffix ) ) {
				return unquotedIdentifier;
			}
			unquotedIdentifier = unquotedIdentifier.Replace( this.QuotePrefix, this.QuotePrefix + this.QuotePrefix );
			return string.Format( "{0}{1}{2}", this.QuotePrefix, unquotedIdentifier, this.QuoteSuffix );
		}

		public override void RefreshSchema() {
			base.RefreshSchema();
			this.finalSelect = null;
		}

		private void RowUpdating( object sender, MySqlRowUpdatingEventArgs args ) {
			base.RowUpdatingHandler( args );
			if( args.StatementType == StatementType.Insert ) {
				if( this.ReturnGeneratedIdentifiers ) {
					if( args.Command.UpdatedRowSource != UpdateRowSource.None ) {
						throw new InvalidOperationException( Resources.MixingUpdatedRowSource );
					}
					args.Command.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;
					if( this.finalSelect == null ) {
						this.CreateFinalSelect();
					}
				}
				if( ( this.finalSelect != null ) && ( this.finalSelect.Length > 0 ) ) {
					MySqlCommand command = args.Command;
					command.CommandText = command.CommandText + this.finalSelect;
				}
			}
		}

		protected override void SetRowUpdatingHandler( DbDataAdapter adapter ) {
			if( adapter != base.DataAdapter ) {
				( (MySqlDataAdapter)adapter ).RowUpdating += new MySqlRowUpdatingEventHandler( this.RowUpdating );
			} else {
				( (MySqlDataAdapter)adapter ).RowUpdating -= new MySqlRowUpdatingEventHandler( this.RowUpdating );
			}
		}

		public override string UnquoteIdentifier( string quotedIdentifier ) {
			if( quotedIdentifier == null ) {
				throw new ArgumentNullException( "quotedIdentifier" );
			}
			if( quotedIdentifier.StartsWith( this.QuotePrefix ) && quotedIdentifier.EndsWith( this.QuoteSuffix ) ) {
				if( quotedIdentifier.StartsWith( this.QuotePrefix ) ) {
					quotedIdentifier = quotedIdentifier.Substring( 1 );
				}
				if( quotedIdentifier.EndsWith( this.QuoteSuffix ) ) {
					quotedIdentifier = quotedIdentifier.Substring( 0, quotedIdentifier.Length - 1 );
				}
				quotedIdentifier = quotedIdentifier.Replace( this.QuotePrefix + this.QuotePrefix, this.QuotePrefix );
			}
			return quotedIdentifier;
		}

	}

}

