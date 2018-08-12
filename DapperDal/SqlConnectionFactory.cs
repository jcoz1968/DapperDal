using DapperDal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DapperDal
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IConnectionStringFactory connectionStringFactory;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ConnectionStringFactory">ConnectionStringFactory instance (di)</param>
        public SqlConnectionFactory(IConnectionStringFactory ConnectionStringFactory)
        {
            connectionStringFactory = ConnectionStringFactory;
        }

        /// <summary>
        /// Creates a database connection object
        /// </summary>
        /// <returns>Sql Database Connection</returns>
        public DbConnection Create()
        {
            var connectionString = connectionStringFactory.Create();

            return new SqlConnection(connectionString);
        }
    }
}
