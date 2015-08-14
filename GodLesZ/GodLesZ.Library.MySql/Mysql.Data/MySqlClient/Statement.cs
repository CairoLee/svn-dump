using GodLesZ.Library.MySql.Data.Common;
using GodLesZ.Library.MySql.Properties;
using System;
using System.Collections;
using System.IO;
using System.Text;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	internal abstract class Statement {
		private ArrayList buffers;
		protected MySqlCommand command;
		protected string commandText;

		private Statement(MySqlCommand cmd) {
			this.command = cmd;
			this.buffers = new ArrayList();
		}

		public Statement(MySqlCommand cmd, string text)
			: this(cmd) {
			this.commandText = text;
		}

		protected virtual void BindParameters() {
			MySqlParameterCollection parameters = this.command.Parameters;
			int num = 0;
			do {
				this.InternalBindParameters(this.ResolvedCommandText, parameters, null);
				if (this.command.Batch != null) {
					while (num < this.command.Batch.Count) {
						MySqlCommand command = this.command.Batch[num++];
						MySqlStream stream = (MySqlStream)this.buffers[this.buffers.Count - 1];
						long num2 = command.EstimatedSize();
						if ((stream.InternalBuffer.Length + num2) > this.Connection.driver.MaxPacketSize) {
							parameters = command.Parameters;
							break;
						}
						this.buffers.RemoveAt(this.buffers.Count - 1);
						long length = stream.InternalBuffer.Length;
						string batchableCommandText = command.BatchableCommandText;
						if (batchableCommandText.StartsWith("(")) {
							stream.WriteStringNoNull(", ");
						} else {
							stream.WriteStringNoNull("; ");
						}
						this.InternalBindParameters(batchableCommandText, command.Parameters, stream);
						if (stream.InternalBuffer.Length > this.Connection.driver.MaxPacketSize) {
							stream.InternalBuffer.SetLength(length);
							parameters = command.Parameters;
							break;
						}
					}
				} else {
					return;
				}
			}
			while (num != this.command.Batch.Count);
		}

		public virtual void Close() {
		}

		public virtual void Execute() {
			this.BindParameters();
			this.ExecuteNext();
		}

		public virtual bool ExecuteNext() {
			if (this.buffers.Count == 0) {
				return false;
			}
			MySqlStream stream = (MySqlStream)this.buffers[0];
			MemoryStream internalBuffer = stream.InternalBuffer;
			this.Driver.Query(internalBuffer.GetBuffer(), (int)internalBuffer.Length);
			this.buffers.RemoveAt(0);
			return true;
		}

		private void InternalBindParameters(string sql, MySqlParameterCollection parameters, MySqlStream stream) {
			ArrayList list = this.TokenizeSql(sql);
			if (stream == null) {
				stream = new MySqlStream(this.Driver.Encoding);
				stream.Version = this.Driver.Version;
			}
			string str = (string)list[list.Count - 1];
			if (str != ";") {
				list.Add(";");
			}
			foreach (string str2 in list) {
				if (str2.Trim().Length == 0) {
					continue;
				}
				if (str2 == ";") {
					this.buffers.Add(stream);
					stream = new MySqlStream(this.Driver.Encoding);
					continue;
				}
				if (((str2.Length < 2) || (((str2[0] != '@') || (str2[1] == '@')) && (str2[0] != '?'))) || !this.SerializeParameter(parameters, stream, str2)) {
					stream.WriteStringNoNull(str2);
				}
			}
		}

		public virtual void Resolve() {
		}

		private bool SerializeParameter(MySqlParameterCollection parameters, MySqlStream stream, string parmName) {
			MySqlParameter parameterFlexible = parameters.GetParameterFlexible(parmName, false);
			if (parameterFlexible == null) {
				if (!parmName.StartsWith("@") || !this.ShouldIgnoreMissingParameter(parmName)) {
					throw new MySqlException(string.Format(Resources.ParameterMustBeDefined, parmName));
				}
				return false;
			}
			parameterFlexible.Serialize(stream, false);
			return true;
		}

		protected virtual bool ShouldIgnoreMissingParameter(string parameterName) {
			if (!this.Connection.Settings.AllowUserVariables) {
				if ((this.command.parameterHash != null) && parameterName.StartsWith("@" + this.command.parameterHash)) {
					return true;
				}
				if ((parameterName.Length <= 1) || ((parameterName[1] != '`') && (parameterName[1] != '\''))) {
					return false;
				}
			}
			return true;
		}

		public ArrayList TokenizeSql(string sql) {
			bool flag = this.Connection.Settings.AllowBatch & this.Driver.SupportsBatch;
			char ch = '\0';
			StringBuilder builder = new StringBuilder();
			bool flag2 = false;
			ArrayList list = new ArrayList();
			sql = sql.TrimStart(new char[] { ';' }).TrimEnd(new char[] { ';' });
			char c = '\0';
			for (int i = 0; i < sql.Length; i++) {
				c = sql[i];
				if (flag2) {
					flag2 = !flag2;
				} else if (c == ch) {
					ch = '\0';
				} else {
					if (((c == ';') && !flag2) && ((ch == '\0') && !flag)) {
						list.Add(builder.ToString());
						list.Add(";");
						builder.Remove(0, builder.Length);
						continue;
					}
					if ((((c == '\'') || (c == '"')) || (c == '`')) && (!flag2 && (ch == '\0'))) {
						ch = c;
					} else if (c == '\\') {
						flag2 = !flag2;
					} else if ((((builder.Length != 1) || (builder[0] != '@')) || (c != '@')) && (((builder.Length <= 0) || (builder[0] != '?')) || (c != '@'))) {
						if (((c == '@') || (c == '?')) && ((ch == '\0') && !flag2)) {
							if (builder[0] != c) {
								list.Add(builder.ToString());
								builder.Remove(0, builder.Length);
							}
						} else if (((builder.Length > 0) && ((builder[0] == '@') || (builder[0] == '?'))) && ((!char.IsLetterOrDigit(c) && (c != '_')) && ((c != '.') && (c != '$')))) {
							list.Add(builder.ToString());
							builder.Remove(0, builder.Length);
						}
					}
				}
				builder.Append(c);
			}
			list.Add(builder.ToString());
			return list;
		}

		private ArrayList TokenizeSql2(string sql) {
			ArrayList list = new ArrayList();
			StringBuilder builder = new StringBuilder();
			bool flag = this.Connection.Settings.AllowBatch & this.Driver.SupportsBatch;
			int startIndex = 0;
			SqlTokenizer tokenizer = new SqlTokenizer(sql);
			string str = this.Connection.driver.Property("sql_mode");
			if (str != null) {
				str = str.ToString().ToLower();
				tokenizer.AnsiQuotes = str.IndexOf("ansi_quotes") != -1;
				tokenizer.BackslashEscapes = str.IndexOf("no_backslash_escapes") == -1;
			}
			for (string str2 = tokenizer.NextToken(); str2 != null; str2 = tokenizer.NextToken()) {
				if ((str2 == ";") && !flag) {
					list.Add(builder.ToString());
					builder.Remove(0, builder.Length);
				} else if ((str2.Length >= 2) && (((str2[0] == '@') && (str2[1] != '@')) || (str2[0] == '?'))) {
					list.Add(builder.ToString());
					builder.Remove(0, builder.Length);
				} else {
					builder.Append(sql.Substring(startIndex, (tokenizer.Index - startIndex) + 1));
					startIndex = tokenizer.Index;
				}
			}
			if (builder.Length > 0) {
				list.Add(builder.ToString());
			}
			return list;
		}

		protected MySqlConnection Connection {
			get { return this.command.Connection; }
		}

		protected GodLesZ.Library.MySql.Data.MySqlClient.Driver Driver {
			get { return this.command.Connection.driver; }
		}

		protected MySqlParameterCollection Parameters {
			get { return this.command.Parameters; }
		}

		public virtual string ResolvedCommandText {
			get { return this.commandText; }
		}
	}
}

