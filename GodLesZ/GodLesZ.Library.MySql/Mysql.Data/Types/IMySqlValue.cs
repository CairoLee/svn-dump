using GodLesZ.Library.MySql.Data.MySqlClient;
using System;
using System.Data;

namespace GodLesZ.Library.MySql.Data.Types {

	internal interface IMySqlValue {
		IMySqlValue ReadValue(MySqlStream stream, long length, bool isNull);
		void SkipValue(MySqlStream stream);
		void WriteValue(MySqlStream stream, bool binary, object value, int length);

		System.Data.DbType DbType { get; }

		bool IsNull { get; }

		GodLesZ.Library.MySql.Data.MySqlClient.MySqlDbType MySqlDbType { get; }

		string MySqlTypeName { get; }

		Type SystemType { get; }

		object Value { get; }
	}
}

