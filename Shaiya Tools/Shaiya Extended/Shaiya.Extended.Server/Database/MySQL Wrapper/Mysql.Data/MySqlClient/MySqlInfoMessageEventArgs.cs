namespace Shaiya.Extended.Server.MySql.Data.MySqlClient
{
    using System;

    public class MySqlInfoMessageEventArgs : EventArgs
    {
        public MySqlError[] errors;
    }
}

