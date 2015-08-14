using System;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	[Flags]
	internal enum ServerStatusFlags {
		AnotherQuery = 8,
		AutoCommitMode = 2,
		BadIndex = 0x10,
		CursorExists = 0x40,
		InTransaction = 1,
		LastRowSent = 0x80,
		MoreResults = 4,
		NoIndex = 0x20
	}
}

