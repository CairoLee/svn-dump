namespace Shaiya.Extended.Server.MySql.Data.MySqlClient
{
    using System;

    [Flags]
    internal enum ClientFlags
    {
        COMPRESS = 0x20,
        CONNECT_WITH_DB = 8,
        FOUND_ROWS = 2,
        IGNORE_SIGPIPE = 0x1000,
        IGNORE_SPACE = 0x100,
        INTERACTIVE = 0x400,
        LOCAL_FILES = 0x80,
        LONG_FLAG = 4,
        LONG_PASSWORD = 1,
        MULTI_RESULTS = 0x20000,
        MULTI_STATEMENTS = 0x10000,
        NO_SCHEMA = 0x10,
        ODBC = 0x40,
        PROTOCOL_41 = 0x200,
        RESERVED = 0x4000,
        SECURE_CONNECTION = 0x8000,
        SSL = 0x800,
        TRANSACTIONS = 0x2000
    }
}

