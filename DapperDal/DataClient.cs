using Dapper;
using DapperDal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDal
{
    public class DataClient : IDataClient
    {
        private readonly ISqlConnectionFactory connectionFactory;
        public DataClient(ISqlConnectionFactory ConnectionFactory)
        {
            connectionFactory = ConnectionFactory;
        }

        /// <summary>
        /// Instantiates a DataClient given a SQL Server connection string
        /// </summary>
        /// <param name="SqlConnectionString">An MS SQL Server connection string</param>
        public static IDataClient Create(string SqlConnectionString)
        {
            return new DataClient(
                new SqlConnectionFactory(
                    new ConnectionStringFactory(SqlConnectionString)));
        }

        /// <summary>
        /// Execute a query with no results returned
        /// </summary>
        /// <param name="commandString">The SQL statement or stored procedure to execute</param>
        /// <param name="param">Parameters object</param>
        /// <param name="commandType">Specifies how the command string is interpreted</param>
        public async Task ExecuteAsync(string commandString, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var con = connectionFactory.Create())
            {
                await con.OpenAsync();
                await con.ExecuteAsync(commandString, param, commandType: commandType);
            }
        }

        /// <summary>
        /// Execute a query with results returned
        /// </summary>
        /// <typeparam name="T">The type that is expected to be returned</typeparam>
        /// <param name="commandString">The SQL statement or stored procedure to execute</param>
        /// <param name="param">Parameters object</param>
        /// <param name="commandType">Specifies how the command string is interpreted</param>
        public async Task<IEnumerable<T>> GetManyAsync<T>(string commandString, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var con = connectionFactory.Create())
            {
                await con.OpenAsync();
                return await con.QueryAsync<T>(commandString, param, commandType: commandType);
            }
        }

        /// <summary>
        /// Execute a query with results returned
        /// </summary>
        /// <typeparam name="T">The type that is expected to be returned</typeparam>
        /// <param name="commandString">The SQL statement or stored procedure to execute</param>
        /// <param name="param">Parameters object</param>
        /// <param name="commandType">Specifies how the command string is interpreted</param>
        public async Task<T> GetSingleAsync<T>(string commandString, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var con = connectionFactory.Create())
            {
                await con.OpenAsync();
                var results = await con.QueryAsync<T>(commandString, param, commandType: commandType);

                return (results.Count() == 1) ? results.First() : default(T);
            }
        }

        /// <summary>
        /// Executes a query with a scalar value returned
        /// </summary>
        /// <typeparam name="T">The type that is expected to be returned</typeparam>
        /// <param name="commandString">The SQL statement or stored procedure to execute</param>
        /// <param name="param">Parameters object</param>
        /// <param name="commandType">Specifies how the command string is interpreted</param>
        public async Task<T> GetScalarAsync<T>(string commandString, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var con = connectionFactory.Create())
            {
                await con.OpenAsync();
                return await con.ExecuteScalarAsync<T>(commandString, param, commandType: commandType);
            }
        }
    }
}
