using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	internal class PreparableStatement : Statement {
		private int executionCount;
		private MySqlField[] paramList;
		private int statementId;

		public PreparableStatement(MySqlCommand command, string text)
			: base(command, text) {
		}

		public virtual void CloseStatement() {
			if (this.IsPrepared) {
				base.Driver.CloseStatement(this.statementId);
				this.statementId = 0;
			}
		}

		public override void Execute() {
			if (!this.IsPrepared) {
				base.Execute();
			} else {
				MySqlStream stream = new MySqlStream(base.Driver.Encoding);
				BitArray array = new BitArray(base.Parameters.Count);
				if (this.paramList != null) {
					for (int i = 0; i < this.paramList.Length; i++) {
						MySqlParameter parameter = base.Parameters[this.paramList[i].ColumnName];
						if ((parameter.Value == DBNull.Value) || (parameter.Value == null)) {
							array[i] = true;
						}
					}
				}
				byte[] buffer = new byte[(base.Parameters.Count + 7) / 8];
				if (buffer.Length > 0) {
					array.CopyTo(buffer, 0);
				}
				stream.WriteInteger((long)this.statementId, 4);
				stream.WriteByte(0);
				stream.WriteInteger(1L, 4);
				stream.Write(buffer);
				stream.WriteByte(1);
				if (this.paramList != null) {
					foreach (MySqlField field in this.paramList) {
						MySqlParameter parameter2 = base.Parameters[field.ColumnName];
						stream.WriteInteger((long)parameter2.GetPSType(), 2);
					}
					foreach (MySqlField field2 in this.paramList) {
						int index = base.Parameters.IndexOf(field2.ColumnName);
						if (index == -1) {
							throw new MySqlException("Parameter '" + field2.ColumnName + "' is not defined.");
						}
						MySqlParameter parameter3 = base.Parameters[index];
						if ((parameter3.Value != DBNull.Value) && (parameter3.Value != null)) {
							stream.Encoding = field2.Encoding;
							parameter3.Serialize(stream, true);
						}
					}
				}
				this.executionCount++;
				base.Driver.ExecuteStatement(stream.InternalBuffer.ToArray());
			}
		}

		public override bool ExecuteNext() {
			return (!this.IsPrepared && base.ExecuteNext());
		}

		public virtual void Prepare() {
			string str;
			ArrayList list = this.PrepareCommandText(out str);
			this.statementId = base.Driver.PrepareStatement(str, ref this.paramList);
			for (int i = 0; i < list.Count; i++) {
				this.paramList[i].ColumnName = (string)list[i];
			}
		}

		private ArrayList PrepareCommandText(out string stripped_sql) {
			StringBuilder builder = new StringBuilder();
			ArrayList list = new ArrayList();
			ArrayList list2 = base.TokenizeSql(this.ResolvedCommandText);
			list.Clear();
			foreach (string str in list2) {
				if ((str[0] != '@') && (str[0] != '?')) {
					builder.Append(str);
				} else {
					list.Add(str);
					builder.Append("?");
				}
			}
			stripped_sql = builder.ToString();
			return list;
		}

		public int ExecutionCount {
			get { return this.executionCount; }
			set { this.executionCount = value; }
		}

		public bool IsPrepared {
			get { return (this.statementId > 0); }
		}

		public int NumParameters {
			get { return this.paramList.Length; }
		}

		public int StatementId {
			get { return this.statementId; }
		}
	}
}

