namespace Shaiya.Extended.Server.MySql.Data.Types
{
    using Shaiya.Extended.Server.MySql.Data.MySqlClient;
    using System;
    using System.Data;

    internal interface IMySqlValue
    {
        IMySqlValue ReadValue(MySqlStream stream, long length, bool isNull);
        void SkipValue(MySqlStream stream);
        void WriteValue(MySqlStream stream, bool binary, object value, int length);

        System.Data.DbType DbType { get; }

        bool IsNull { get; }

        Shaiya.Extended.Server.MySql.Data.MySqlClient.MySqlDbType MySqlDbType { get; }

        string MySqlTypeName { get; }

        Type SystemType { get; }

        object Value { get; }
    }
}

