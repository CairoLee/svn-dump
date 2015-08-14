using System;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	public enum MySqlErrorCode {
		AccessDenied = 0x415,
		AnonymousUser = 0x46b,
		DuplicateKey = 0x3fe,
		DuplicateKeyEntry = 0x426,
		DuplicateKeyName = 0x425,
		HostNotPrivileged = 0x46a,
		KeyNotFound = 0x408,
		NonExistingTableGrant = 0x47b,
		NoSuchTable = 0x47a,
		PacketTooLarge = 0x481,
		PasswordNoMatch = 0x46d,
		PasswordNotAllowed = 0x46c,
		UnableToConnectToHost = 0x412
	}
}

