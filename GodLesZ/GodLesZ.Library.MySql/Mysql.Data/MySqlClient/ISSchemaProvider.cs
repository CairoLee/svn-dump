using GodLesZ.Library.MySql.Data.Common;
using GodLesZ.Library.MySql.Properties;
using GodLesZ.Library.MySql.Data.Types;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlTypes;
using System.Globalization;
using System.Text;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	internal class ISSchemaProvider : SchemaProvider {
		public ISSchemaProvider(MySqlConnection connection)
			: base(connection) {
		}

		protected override DataTable GetCollections() {
			DataTable collections = base.GetCollections();
			object[][] data = new object[][] { new object[] { "Views", 2, 3 }, new object[] { "ViewColumns", 3, 4 }, new object[] { "Procedure Parameters", 5, 1 }, new object[] { "Procedures", 4, 3 }, new object[] { "Triggers", 2, 4 } };
			SchemaProvider.FillTable(collections, data);
			return collections;
		}

		public override DataTable GetColumns(string[] restrictions) {
			string[] keys = new string[] { "TABLE_CATALOG", "TABLE_SCHEMA", "TABLE_NAME", "COLUMN_NAME" };
			DataTable table = this.Query("COLUMNS", null, keys, restrictions);
			table.Columns.Remove("CHARACTER_OCTET_LENGTH");
			table.TableName = "Columns";
			return table;
		}

		public override DataTable GetDatabases(string[] restrictions) {
			string[] keys = new string[] { "SCHEMA_NAME" };
			DataTable table = this.Query("SCHEMATA", "", keys, restrictions);
			table.Columns[1].ColumnName = "database_name";
			table.TableName = "Databases";
			return table;
		}

		private static string GetDataTypeDefaults(string type, DataRow row) {
			string format = "({0},{1})";
			if (!MetaData.IsNumericType(type) || (row["NUMERIC_PRECISION"].ToString().Length != 0)) {
				return string.Empty;
			}
			row["NUMERIC_PRECISION"] = 10;
			row["NUMERIC_SCALE"] = 0;
			if (!MetaData.SupportScale(type)) {
				format = "({0})";
			}
			return string.Format(format, row["NUMERIC_PRECISION"], row["NUMERIC_SCALE"]);
		}

		private DataTable GetParametersFromIS(string[] restrictions) {
			StringBuilder builder = new StringBuilder("SELECT * FROM INFORMATION_SCHEMA.PARAMETERS");
			string[] keys = new string[] { "SPECIFIC_CATALOG", "SPECIFIC_SCHEMA", "SPECIFIC_NAME", "ROUTINE_TYPE", "PARAMETER_NAME" };
			string str = this.GetWhereClause(null, keys, restrictions);
			if (!string.IsNullOrEmpty(str)) {
				builder.AppendFormat(CultureInfo.InvariantCulture, " WHERE {0}", new object[] { str });
			}
			DataTable table = this.GetTable(builder.ToString());
			table.TableName = "Procedure Parameters";
			return table;
		}

		internal void GetParametersFromShowCreate(DataTable parametersTable, string[] restrictions, DataTable routines) {
			if (routines == null) {
				routines = this.GetSchema("procedures", restrictions);
			}
			MySqlCommand command = base.connection.CreateCommand();
			foreach (DataRow row in routines.Rows) {
				string str = string.Format("SHOW CREATE {0} `{1}`.`{2}`", row["ROUTINE_TYPE"], row["ROUTINE_SCHEMA"], row["ROUTINE_NAME"]);
				command.CommandText = str;
				try {
					string nameToRestrict = null;
					if (((restrictions != null) && (restrictions.Length == 5)) && (restrictions[4] != null)) {
						nameToRestrict = restrictions[4];
					}
					using (MySqlDataReader reader = command.ExecuteReader()) {
						reader.Read();
						string body = reader.GetString(2);
						reader.Close();
						this.ParseProcedureBody(parametersTable, body, row, nameToRestrict);
					}
					continue;
				} catch (SqlNullValueException exception) {
					throw new InvalidOperationException(Resources.UnableToRetrieveSProcData, exception);
				}
			}
		}

		private string GetProcedureParameterLine(DataRow isRow) {
			string format = "SHOW CREATE {0} `{1}`.`{2}`";
			MySqlCommand command = new MySqlCommand(string.Format(format, isRow["ROUTINE_TYPE"], isRow["ROUTINE_SCHEMA"], isRow["ROUTINE_NAME"]), base.connection);
			using (MySqlDataReader reader = command.ExecuteReader()) {
				string str4;
				reader.Read();
				if (reader.IsDBNull(2)) {
					return null;
				}
				string str2 = reader.GetString(1);
				string input = reader.GetString(2);
				SqlTokenizer tokenizer = new SqlTokenizer(input);
				tokenizer.AnsiQuotes = str2.IndexOf("ANSI_QUOTES") != -1;
				tokenizer.BackslashEscapes = str2.IndexOf("NO_BACKSLASH_ESCAPES") == -1;
				for (str4 = tokenizer.NextToken(); str4 != "("; str4 = tokenizer.NextToken()) {
				}
				int startIndex = tokenizer.Index + 1;
				str4 = tokenizer.NextToken();
				while ((str4 != ")") || tokenizer.Quoted) {
					str4 = tokenizer.NextToken();
					if ((str4 == "(") && !tokenizer.Quoted) {
						while ((str4 != ")") || tokenizer.Quoted) {
							str4 = tokenizer.NextToken();
						}
						str4 = tokenizer.NextToken();
					}
				}
				return input.Substring(startIndex, tokenizer.Index - startIndex);
			}
		}

		public virtual DataTable GetProcedureParameters(string[] restrictions, DataTable routines) {
			if (base.connection.driver.Version.isAtLeast(6, 0, 6)) {
				return this.GetParametersFromIS(restrictions);
			}
			DataTable parametersTable = new DataTable("Procedure Parameters");
			parametersTable.Columns.Add("SPECIFIC_CATALOG", typeof(string));
			parametersTable.Columns.Add("SPECIFIC_SCHEMA", typeof(string));
			parametersTable.Columns.Add("SPECIFIC_NAME", typeof(string));
			parametersTable.Columns.Add("ORDINAL_POSITION", typeof(int));
			parametersTable.Columns.Add("PARAMETER_MODE", typeof(string));
			parametersTable.Columns.Add("PARAMETER_NAME", typeof(string));
			parametersTable.Columns.Add("DATA_TYPE", typeof(string));
			parametersTable.Columns.Add("CHARACTER_MAXIMUM_LENGTH", typeof(int));
			parametersTable.Columns.Add("CHARACTER_OCTET_LENGTH", typeof(int));
			parametersTable.Columns.Add("NUMERIC_PRECISION", typeof(byte));
			parametersTable.Columns.Add("NUMERIC_SCALE", typeof(int));
			parametersTable.Columns.Add("CHARACTER_SET_NAME", typeof(string));
			parametersTable.Columns.Add("COLLATION_NAME", typeof(string));
			parametersTable.Columns.Add("DTD_IDENTIFIER", typeof(string));
			parametersTable.Columns.Add("ROUTINE_TYPE", typeof(string));
			this.GetParametersFromShowCreate(parametersTable, restrictions, routines);
			return parametersTable;
		}

		public override DataTable GetProcedures(string[] restrictions) {
			if (base.connection.Settings.UseProcedureBodies) {
				return base.GetProcedures(restrictions);
			}
			string[] keys = new string[] { "ROUTINE_CATALOG", "ROUTINE_SCHEMA", "ROUTINE_NAME", "ROUTINE_TYPE" };
			DataTable table = this.Query("ROUTINES", null, keys, restrictions);
			table.TableName = "Procedures";
			return table;
		}

		private DataTable GetProceduresWithParameters(string[] restrictions) {
			DataTable procedures = this.GetProcedures(restrictions);
			procedures.Columns.Add("ParameterList", typeof(string));
			foreach (DataRow row in procedures.Rows) {
				row["ParameterList"] = this.GetProcedureParameterLine(row);
			}
			return procedures;
		}

		protected override DataTable GetRestrictions() {
			DataTable restrictions = base.GetRestrictions();
			object[][] data = new object[][] { 
                new object[] { "Procedure Parameters", "Database", "", 0 }, new object[] { "Procedure Parameters", "Schema", "", 1 }, new object[] { "Procedure Parameters", "Name", "", 2 }, new object[] { "Procedure Parameters", "Type", "", 3 }, new object[] { "Procedure Parameters", "Parameter", "", 4 }, new object[] { "Procedures", "Database", "", 0 }, new object[] { "Procedures", "Schema", "", 1 }, new object[] { "Procedures", "Name", "", 2 }, new object[] { "Procedures", "Type", "", 3 }, new object[] { "Views", "Database", "", 0 }, new object[] { "Views", "Schema", "", 1 }, new object[] { "Views", "Table", "", 2 }, new object[] { "ViewColumns", "Database", "", 0 }, new object[] { "ViewColumns", "Schema", "", 1 }, new object[] { "ViewColumns", "Table", "", 2 }, new object[] { "ViewColumns", "Column", "", 3 }, 
                new object[] { "Triggers", "Database", "", 0 }, new object[] { "Triggers", "Schema", "", 1 }, new object[] { "Triggers", "Name", "", 2 }, new object[] { "Triggers", "EventObjectTable", "", 3 }
             };
			SchemaProvider.FillTable(restrictions, data);
			return restrictions;
		}

		protected override DataTable GetSchemaInternal(string collection, string[] restrictions) {
			DataTable schemaInternal = base.GetSchemaInternal(collection, restrictions);
			if (schemaInternal != null) {
				return schemaInternal;
			}
			switch (collection) {
				case "views":
					return this.GetViews(restrictions);

				case "procedures":
					return this.GetProcedures(restrictions);

				case "procedures with parameters":
					return this.GetProceduresWithParameters(restrictions);

				case "procedure parameters":
					return this.GetProcedureParameters(restrictions, null);

				case "triggers":
					return this.GetTriggers(restrictions);

				case "viewcolumns":
					return this.GetViewColumns(restrictions);
			}
			return null;
		}

		private DataTable GetTable(string sql) {
			DataTable dataTable = new DataTable();
			new MySqlDataAdapter(sql, base.connection).Fill(dataTable);
			return dataTable;
		}

		public override DataTable GetTables(string[] restrictions) {
			string[] keys = new string[] { "TABLE_CATALOG", "TABLE_SCHEMA", "TABLE_NAME", "TABLE_TYPE" };
			DataTable table = this.Query("TABLES", "TABLE_TYPE != 'VIEW'", keys, restrictions);
			table.TableName = "Tables";
			return table;
		}

		private DataTable GetTriggers(string[] restrictions) {
			string[] keys = new string[] { "TRIGGER_CATALOG", "TRIGGER_SCHEMA", "EVENT_OBJECT_TABLE", "TRIGGER_NAME" };
			DataTable table = this.Query("TRIGGERS", null, keys, restrictions);
			table.TableName = "Triggers";
			return table;
		}

		private DataTable GetViewColumns(string[] restrictions) {
			StringBuilder builder = new StringBuilder();
			StringBuilder builder2 = new StringBuilder("SELECT C.* FROM information_schema.columns C");
			builder2.Append(" JOIN information_schema.views V ");
			builder2.Append("ON C.table_schema=V.table_schema AND C.table_name=V.table_name ");
			if (((restrictions != null) && (restrictions.Length >= 2)) && (restrictions[1] != null)) {
				builder.AppendFormat(CultureInfo.InvariantCulture, "C.table_schema='{0}' ", new object[] { restrictions[1] });
			}
			if (((restrictions != null) && (restrictions.Length >= 3)) && (restrictions[2] != null)) {
				if (builder.Length > 0) {
					builder.Append("AND ");
				}
				builder.AppendFormat(CultureInfo.InvariantCulture, "C.table_name='{0}' ", new object[] { restrictions[2] });
			}
			if (((restrictions != null) && (restrictions.Length == 4)) && (restrictions[3] != null)) {
				if (builder.Length > 0) {
					builder.Append("AND ");
				}
				builder.AppendFormat(CultureInfo.InvariantCulture, "C.column_name='{0}' ", new object[] { restrictions[3] });
			}
			if (builder.Length > 0) {
				builder2.AppendFormat(CultureInfo.InvariantCulture, " WHERE {0}", new object[] { builder });
			}
			DataTable table = this.GetTable(builder2.ToString());
			table.TableName = "ViewColumns";
			table.Columns[0].ColumnName = "VIEW_CATALOG";
			table.Columns[1].ColumnName = "VIEW_SCHEMA";
			table.Columns[2].ColumnName = "VIEW_NAME";
			return table;
		}

		private DataTable GetViews(string[] restrictions) {
			string[] keys = new string[] { "TABLE_CATALOG", "TABLE_SCHEMA", "TABLE_NAME" };
			DataTable table = this.Query("VIEWS", null, keys, restrictions);
			table.TableName = "Views";
			return table;
		}

		private string GetWhereClause(string initial_where, string[] keys, string[] values) {
			StringBuilder builder = new StringBuilder(initial_where);
			if (values != null) {
				for (int i = 0; i < keys.Length; i++) {
					if (i >= values.Length) {
						break;
					}
					if ((values[i] != null) && (values[i] != string.Empty)) {
						if (builder.Length > 0) {
							builder.Append(" AND ");
						}
						builder.AppendFormat(CultureInfo.InvariantCulture, "{0} LIKE '{1}'", new object[] { keys[i], values[i] });
					}
				}
			}
			return builder.ToString();
		}

		private static void InitParameterRow(DataRow procedure, DataRow parameter) {
			parameter["SPECIFIC_CATALOG"] = null;
			parameter["SPECIFIC_SCHEMA"] = procedure["ROUTINE_SCHEMA"];
			parameter["SPECIFIC_NAME"] = procedure["ROUTINE_NAME"];
			parameter["PARAMETER_MODE"] = "IN";
			parameter["ORDINAL_POSITION"] = 0;
			parameter["ROUTINE_TYPE"] = procedure["ROUTINE_TYPE"];
		}

		private string ParseDataType(DataRow row, SqlTokenizer tokenizer) {
			StringBuilder builder = new StringBuilder(tokenizer.NextToken().ToUpper(CultureInfo.InvariantCulture));
			row["DATA_TYPE"] = builder.ToString();
			string type = row["DATA_TYPE"].ToString();
			string size = tokenizer.NextToken();
			if (tokenizer.IsSize) {
				builder.AppendFormat(CultureInfo.InvariantCulture, "({0})", new object[] { size });
				if ((type != "ENUM") && (type != "SET")) {
					ParseDataTypeSize(row, size);
				}
				size = tokenizer.NextToken();
			} else {
				builder.Append(GetDataTypeDefaults(type, row));
			}
			while (((size != ")") && (size != ",")) && (string.Compare(size, "begin", true) != 0)) {
				if ((string.Compare(size, "CHARACTER", true) != 0) && (string.Compare(size, "BINARY", true) != 0)) {
					if ((string.Compare(size, "SET", true) == 0) || (string.Compare(size, "CHARSET", true) == 0)) {
						row["CHARACTER_SET_NAME"] = tokenizer.NextToken();
					} else if (string.Compare(size, "ASCII", true) == 0) {
						row["CHARACTER_SET_NAME"] = "latin1";
					} else if (string.Compare(size, "UNICODE", true) == 0) {
						row["CHARACTER_SET_NAME"] = "ucs2";
					} else if (string.Compare(size, "COLLATE", true) == 0) {
						row["COLLATION_NAME"] = tokenizer.NextToken();
					} else {
						builder.AppendFormat(CultureInfo.InvariantCulture, " {0}", new object[] { size });
					}
				}
				size = tokenizer.NextToken();
			}
			if (builder.Length > 0) {
				row["DTD_IDENTIFIER"] = builder.ToString();
			}
			if (row["COLLATION_NAME"].ToString().Length == 0) {
				row["COLLATION_NAME"] = CharSetMap.GetDefaultCollation(row["CHARACTER_SET_NAME"].ToString(), base.connection);
			}
			if (row["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value) {
				row["CHARACTER_OCTET_LENGTH"] = CharSetMap.GetMaxLength(row["CHARACTER_SET_NAME"].ToString(), base.connection) * ((int)row["CHARACTER_MAXIMUM_LENGTH"]);
			}
			return size;
		}

		private static void ParseDataTypeSize(DataRow row, string size) {
			size = size.Trim(new char[] { '(', ')' });
			string[] strArray = size.Split(new char[] { ',' });
			if (!MetaData.IsNumericType(row["DATA_TYPE"].ToString())) {
				row["CHARACTER_MAXIMUM_LENGTH"] = int.Parse(strArray[0]);
			} else {
				row["NUMERIC_PRECISION"] = int.Parse(strArray[0]);
				if (strArray.Length == 2) {
					row["NUMERIC_SCALE"] = int.Parse(strArray[1]);
				}
			}
		}

		private void ParseProcedureBody(DataTable parametersTable, string body, DataRow row, string nameToRestrict) {
			string str2;
			ArrayList list = new ArrayList(new string[] { "IN", "OUT", "INOUT" });
			string str = row["SQL_MODE"].ToString();
			int num = 1;
			SqlTokenizer tokenizer = new SqlTokenizer(body);
			tokenizer.AnsiQuotes = str.IndexOf("ANSI_QUOTES") != -1;
			tokenizer.BackslashEscapes = str.IndexOf("NO_BACKSLASH_ESCAPES") == -1;
			for (str2 = tokenizer.NextToken(); str2 != "("; str2 = tokenizer.NextToken()) {
				if ((string.Compare(str2, "FUNCTION", true) == 0) && (nameToRestrict == null)) {
					parametersTable.Rows.Add(parametersTable.NewRow());
					InitParameterRow(row, parametersTable.Rows[0]);
				}
			}
			str2 = tokenizer.NextToken();
			while (str2 != ")") {
				DataRow parameter = parametersTable.NewRow();
				InitParameterRow(row, parameter);
				parameter["ORDINAL_POSITION"] = num++;
				string item = str2.ToUpper(CultureInfo.InvariantCulture);
				if (!tokenizer.Quoted && list.Contains(item)) {
					parameter["PARAMETER_MODE"] = item;
					str2 = tokenizer.NextToken();
				}
				parameter["PARAMETER_NAME"] = str2;
				str2 = this.ParseDataType(parameter, tokenizer);
				if (str2 == ",") {
					str2 = tokenizer.NextToken();
				}
				if ((nameToRestrict == null) || (string.Compare(parameter["PARAMETER_NAME"].ToString(), nameToRestrict, true) == 0)) {
					parametersTable.Rows.Add(parameter);
				}
			}
			if (string.Compare(tokenizer.NextToken().ToLower(CultureInfo.InvariantCulture), "returns", true) == 0) {
				DataRow row3 = parametersTable.Rows[0];
				row3["PARAMETER_NAME"] = "RETURN_VALUE";
				this.ParseDataType(row3, tokenizer);
			}
		}

		private DataTable Query(string table_name, string initial_where, string[] keys, string[] values) {
			StringBuilder builder = new StringBuilder("SELECT * FROM INFORMATION_SCHEMA.");
			builder.Append(table_name);
			string str = this.GetWhereClause(initial_where, keys, values);
			if (str.Length > 0) {
				builder.AppendFormat(CultureInfo.InvariantCulture, " WHERE {0}", new object[] { str });
			}
			return this.GetTable(builder.ToString());
		}
	}
}

