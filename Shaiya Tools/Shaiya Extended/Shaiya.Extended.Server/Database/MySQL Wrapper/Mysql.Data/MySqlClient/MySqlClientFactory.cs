namespace Shaiya.Extended.Server.MySql.Data.MySqlClient
{
    using System;
    using System.Data.Common;

    public sealed class MySqlClientFactory : DbProviderFactory
    {
        public static readonly MySqlClientFactory Instance = new MySqlClientFactory();

        public override DbCommand CreateCommand()
        {
            return new MySqlCommand();
        }

        public override DbCommandBuilder CreateCommandBuilder()
        {
            return new MySqlCommandBuilder();
        }

        public override DbConnection CreateConnection()
        {
            return new MySqlConnection();
        }

        public override DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return new MySqlConnectionStringBuilder();
        }

        public override DbDataAdapter CreateDataAdapter()
        {
            return new MySqlDataAdapter();
        }

        public override DbParameter CreateParameter()
        {
            return new MySqlParameter();
        }

        public override bool CanCreateDataSourceEnumerator
        {
            get
            {
                return false;
            }
        }
    }
}

