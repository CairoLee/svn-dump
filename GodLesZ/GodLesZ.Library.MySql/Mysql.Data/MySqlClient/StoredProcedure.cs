using GodLesZ.Library.MySql.Properties;
using GodLesZ.Library.MySql.Data.Types;
using System;
using System.Data;
using System.Globalization;
using System.Text;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	internal class StoredProcedure : PreparableStatement {
		private string outSelect;
		private DataTable parametersTable;
		private string resolvedCommandText;

		public StoredProcedure(MySqlCommand cmd, string text)
			: base(cmd, text) {
			cmd.parameterHash = ((uint)DateTime.Now.GetHashCode()).ToString();
		}

		public override void Close() {
			base.Close();
			if (this.outSelect.Length != 0) {
				MySqlCommand command = new MySqlCommand("SELECT " + this.outSelect, base.Connection);
				string parameterHash = base.command.parameterHash;
				command.parameterHash = parameterHash;
				using (MySqlDataReader reader = command.ExecuteReader()) {
					for (int i = 0; i < reader.FieldCount; i++) {
						string parameterName = reader.GetName(i).Remove(0, parameterHash.Length + 1);
						MySqlParameter parameterFlexible = base.Parameters.GetParameterFlexible(parameterName, true);
						reader.values[i] = MySqlField.GetIMySqlValue(parameterFlexible.MySqlDbType);
					}
					if (reader.Read()) {
						for (int j = 0; j < reader.FieldCount; j++) {
							string str3 = reader.GetName(j).Remove(0, parameterHash.Length + 1);
							base.Parameters.GetParameterFlexible(str3, true).Value = reader.GetValue(j);
						}
					}
				}
			}
		}

		public static string GetFlags(string dtd) {
			int startIndex = dtd.Length - 1;
			while ((startIndex > 0) && (char.IsLetterOrDigit(dtd[startIndex]) || (dtd[startIndex] == ' '))) {
				startIndex--;
			}
			return dtd.Substring(startIndex).ToUpper(CultureInfo.InvariantCulture);
		}

		private DataSet GetParameters(string procName) {
			if (base.Connection.Settings.UseProcedureBodies) {
				return base.Connection.ProcedureCache.GetProcedure(base.Connection, procName);
			}
			DataSet set = new DataSet();
			string[] restrictionValues = new string[4];
			int index = procName.IndexOf('.');
			restrictionValues[1] = procName.Substring(0, index++);
			restrictionValues[2] = procName.Substring(index, procName.Length - index);
			set.Tables.Add(base.Connection.GetSchema("procedures", restrictionValues));
			DataTable routines = new DataTable();
			DataTable procedureParameters = new ISSchemaProvider(base.Connection).GetProcedureParameters(null, routines);
			procedureParameters.TableName = "procedure parameters";
			set.Tables.Add(procedureParameters);
			int num2 = 1;
			foreach (MySqlParameter parameter in base.command.Parameters) {
				if (!parameter.TypeHasBeenSet) {
					throw new InvalidOperationException(Resources.NoBodiesAndTypeNotSet);
				}
				DataRow row = procedureParameters.NewRow();
				row["PARAMETER_NAME"] = parameter.ParameterName;
				row["PARAMETER_MODE"] = "IN";
				if (parameter.Direction == ParameterDirection.InputOutput) {
					row["PARAMETER_MODE"] = "INOUT";
				} else if (parameter.Direction == ParameterDirection.Output) {
					row["PARAMETER_MODE"] = "OUT";
				} else if (parameter.Direction == ParameterDirection.ReturnValue) {
					row["PARAMETER_MODE"] = "OUT";
					row["ORDINAL_POSITION"] = 0;
				} else {
					row["ORDINAL_POSITION"] = num2++;
				}
				procedureParameters.Rows.Add(row);
			}
			return set;
		}

		private string GetReturnParameter() {
			if (base.Parameters != null) {
				foreach (MySqlParameter parameter in base.Parameters) {
					if (parameter.Direction == ParameterDirection.ReturnValue) {
						string str = parameter.ParameterName.Substring(1);
						return (base.command.parameterHash + str);
					}
				}
			}
			return null;
		}

		public override void Resolve() {
			string commandText = base.commandText;
			string parameterHash = base.command.parameterHash;
			if (commandText.IndexOf(".") == -1) {
				commandText = base.Connection.Database + "." + commandText;
			}
			DataSet parameters = this.GetParameters(commandText);
			DataTable table = parameters.Tables["procedures"];
			this.parametersTable = parameters.Tables["procedure parameters"];
			StringBuilder builder = new StringBuilder();
			StringBuilder builder2 = new StringBuilder();
			this.outSelect = string.Empty;
			string returnParameter = this.GetReturnParameter();
			foreach (DataRow row in this.parametersTable.Rows) {
				if (row["ORDINAL_POSITION"].Equals(0)) {
					continue;
				}
				string str4 = (string)row["PARAMETER_MODE"];
				string parameterName = (string)row["PARAMETER_NAME"];
				MySqlParameter parameterFlexible = base.command.Parameters.GetParameterFlexible(parameterName, true);
				if (!parameterFlexible.TypeHasBeenSet) {
					string typeName = (string)row["DATA_TYPE"];
					bool unsigned = GetFlags(row["DTD_IDENTIFIER"].ToString()).IndexOf("UNSIGNED") != -1;
					bool realAsFloat = table.Rows[0]["SQL_MODE"].ToString().IndexOf("REAL_AS_FLOAT") != -1;
					parameterFlexible.MySqlDbType = MetaData.NameToType(typeName, unsigned, realAsFloat, base.Connection);
				}
				string str7 = parameterName;
				if (parameterName.StartsWith("@") || parameterName.StartsWith("?")) {
					str7 = parameterName.Substring(1);
				}
				string str8 = string.Format("@{0}{1}", parameterHash, str7);
				parameterName = parameterFlexible.ParameterName;
				if (!parameterName.StartsWith("@") && !parameterName.StartsWith("?")) {
					parameterName = "@" + parameterName;
				}
				switch (str4) {
					case "OUT":
					case "INOUT":
						this.outSelect = this.outSelect + str8 + ", ";
						builder.Append(str8);
						builder.Append(", ");
						break;

					default:
						builder.Append(parameterName);
						builder.Append(", ");
						break;
				}
				if (str4 == "INOUT") {
					builder2.AppendFormat(CultureInfo.InvariantCulture, "SET {0}={1};", new object[] { str8, parameterName });
					this.outSelect = this.outSelect + str8 + ", ";
				}
			}
			string str9 = builder.ToString().TrimEnd(new char[] { ' ', ',' });
			this.outSelect = this.outSelect.TrimEnd(new char[] { ' ', ',' });
			if (table.Rows[0]["ROUTINE_TYPE"].Equals("PROCEDURE")) {
				str9 = string.Format("call {0} ({1})", base.commandText, str9);
			} else {
				if (returnParameter == null) {
					returnParameter = parameterHash + "dummy";
				} else {
					this.outSelect = string.Format("@{0}", returnParameter);
				}
				str9 = string.Format("SET @{0}={1}({2})", returnParameter, base.commandText, str9);
			}
			if (builder2.Length > 0) {
				str9 = builder2 + str9;
			}
			this.resolvedCommandText = str9;
		}

		public override string ResolvedCommandText {
			get { return this.resolvedCommandText; }
		}
	}
}

