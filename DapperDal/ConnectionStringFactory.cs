using DapperDal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DapperDal
{
    public class ConnectionStringFactory : IConnectionStringFactory
    {
        private readonly string _connectionString;

        public ConnectionStringFactory(string ConnectionString)
        {
            new SqlConnectionStringBuilder(ConnectionString);
            _connectionString = ConnectionString;
        }

        public string Create()
        {
            return _connectionString;
        }
    }
}
