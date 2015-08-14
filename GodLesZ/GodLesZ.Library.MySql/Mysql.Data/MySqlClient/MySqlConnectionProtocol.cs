using System;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	public enum MySqlConnectionProtocol {
		Sockets,
		NamedPipe,
		UnixSocket,
		SharedMemory
	}
}

