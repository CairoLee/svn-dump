using GodLesZ.Library.MySql.Data.Common;
using GodLesZ.Library.MySql.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	public class MySqlScript {
		private MySqlConnection connection;
		private string delimiter;
		private string query;

		public event MySqlScriptErrorEventHandler Error;

		public event EventHandler ScriptCompleted;

		public event MySqlStatementExecutedEventHandler StatementExecuted;

		public MySqlScript() {
			this.delimiter = ";";
		}

		public MySqlScript(MySqlConnection connection)
			: this() {
			this.connection = connection;
		}

		public MySqlScript(string query)
			: this() {
			this.query = query;
		}

		public MySqlScript(MySqlConnection connection, string query)
			: this() {
			this.connection = connection;
			this.query = query;
		}

		private List<ScriptStatement> BreakIntoStatements(bool ansiQuotes, bool noBackslashEscapes) {
			int startIndex = 0;
			List<ScriptStatement> list = new List<ScriptStatement>();
			List<int> lineNumbers = this.BreakScriptIntoLines();
			SqlTokenizer tokenizer = new SqlTokenizer(this.query);
			tokenizer.AnsiQuotes = ansiQuotes;
			tokenizer.BackslashEscapes = !noBackslashEscapes;
			for (string str = tokenizer.NextToken(); str != null; str = tokenizer.NextToken()) {
				if (!tokenizer.Quoted && !tokenizer.IsSize) {
					int index = str.IndexOf(this.Delimiter);
					if (index != -1) {
						int num3 = (tokenizer.Index - str.Length) + index;
						if (tokenizer.Index == (this.query.Length - 1)) {
							num3++;
						}
						string str2 = this.query.Substring(startIndex, num3 - startIndex);
						ScriptStatement item = new ScriptStatement();
						item.text = str2.Trim();
						item.line = this.FindLineNumber(startIndex, lineNumbers);
						item.position = startIndex - lineNumbers[item.line];
						list.Add(item);
						startIndex = num3 + this.delimiter.Length;
					}
				}
			}
			if (tokenizer.Index > startIndex) {
				string str3 = this.query.Substring(startIndex).Trim();
				if (!string.IsNullOrEmpty(str3)) {
					ScriptStatement statement2 = new ScriptStatement();
					statement2.text = str3;
					statement2.line = this.FindLineNumber(startIndex, lineNumbers);
					statement2.position = startIndex - lineNumbers[statement2.line];
					list.Add(statement2);
				}
			}
			return list;
		}

		private List<int> BreakScriptIntoLines() {
			List<int> list = new List<int>();
			StringReader reader = new StringReader(this.query);
			string str = reader.ReadLine();
			int item = 0;
			while (str != null) {
				list.Add(item);
				item += str.Length;
				str = reader.ReadLine();
			}
			return list;
		}

		public int Execute() {
			int num2;
			bool flag = false;
			if (this.connection == null) {
				throw new InvalidOperationException(Resources.ConnectionNotSet);
			}
			if ((this.query == null) || (this.query.Length == 0)) {
				return 0;
			}
			if (this.connection.State != ConnectionState.Open) {
				flag = true;
				this.connection.Open();
			}
			bool allowUserVariables = this.connection.Settings.AllowUserVariables;
			this.connection.Settings.AllowUserVariables = true;
			try {
				string str = this.connection.driver.Property("sql_mode").ToLower(CultureInfo.InvariantCulture);
				bool ansiQuotes = str.IndexOf("ansi_quotes") != -1;
				bool noBackslashEscapes = str.IndexOf("no_backslash_escpaes") != -1;
				List<ScriptStatement> list = this.BreakIntoStatements(ansiQuotes, noBackslashEscapes);
				int num = 0;
				MySqlCommand command = new MySqlCommand(null, this.connection);
				foreach (ScriptStatement statement in list) {
					command.CommandText = statement.text;
					try {
						command.ExecuteNonQuery();
						num++;
						this.OnQueryExecuted(statement);
						continue;
					} catch (Exception exception) {
						if (this.Error == null) {
							throw;
						}
						if (this.OnScriptError(exception)) {
							continue;
						}
						break;
					}
				}
				this.OnScriptCompleted();
				num2 = num;
			} finally {
				this.connection.Settings.AllowUserVariables = allowUserVariables;
				if (flag) {
					this.connection.Close();
				}
			}
			return num2;
		}

		private int FindLineNumber(int position, List<int> lineNumbers) {
			int num = 0;
			while ((num < lineNumbers.Count) && (position < lineNumbers[num])) {
				num++;
			}
			return num;
		}

		private void OnQueryExecuted(ScriptStatement statement) {
			if (this.StatementExecuted != null) {
				MySqlScriptEventArgs args = new MySqlScriptEventArgs();
				args.Statement = statement;
				this.StatementExecuted(this, args);
			}
		}

		private void OnScriptCompleted() {
			if (this.ScriptCompleted != null) {
				this.ScriptCompleted(this, null);
			}
		}

		private bool OnScriptError(Exception ex) {
			if (this.Error != null) {
				MySqlScriptErrorEventArgs args = new MySqlScriptErrorEventArgs(ex);
				this.Error(this, args);
				return args.Ignore;
			}
			return false;
		}

		public MySqlConnection Connection {
			get { return this.connection; }
			set { this.connection = value; }
		}

		public string Delimiter {
			get { return this.delimiter; }
			set { this.delimiter = value; }
		}

		public string Query {
			get { return this.query; }
			set { this.query = value; }
		}
	}
}

