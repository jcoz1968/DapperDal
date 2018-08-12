using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace DapperDal.Interfaces
{
    public interface IDataClient
    {
        /// <summary>
        /// Execute a query with no results returned
        /// </summary>
        /// <param name="commandString">The SQL statement or stored procedure to execute</param>
        /// <param name="param">Parameters object</param>
        /// <param name="commandType">Specifies how the command string is interpreted</param>
        /// <returns></returns>
        Task ExecuteAsync(string command, object param = null, CommandType commandType = CommandType.StoredProcedure);

        /// <summary>
        /// Execute a query with results returned (IEnumerable T)
        /// </summary>
        /// <typeparam name="T">The type that is expected to be returned</typeparam>
        /// <param name="commandString">The SQL statement or stored procedure to execute</param>
        /// <param name="param">Parameters object</param>
        /// <param name="commandType">Specifies how the command string is interpreted</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetManyAsync<T>(string commandString, object param = null, CommandType commandType = CommandType.StoredProcedure);

        /// <summary>
        /// Execute a query with a single result T returned
        /// </summary>
        /// <typeparam name="T">The type that is expected to be returned</typeparam>
        /// <param name="commandString">The SQL statement or stored procedure to execute</param>
        /// <param name="param">Parameters object</param>
        /// <param name="commandType">Specifies how the command string is interpreted</param>
        /// <returns></returns>
        Task<T> GetSingleAsync<T>(string commandString, object param = null, CommandType commandType = CommandType.StoredProcedure);

        /// <summary>
        /// Executes a query with a scalar value returned
        /// </summary>
        /// <typeparam name="T">The type that is expected to be returned</typeparam>
        /// <param name="commandString">The SQL statement or stored procedure to execute</param>
        /// <param name="param">Parameters object</param>
        /// <param name="commandType">Specifies how the command string is interpreted</param>
        /// <returns></returns>
        Task<T> GetScalarAsync<T>(string commandString, object param = null, CommandType commandType = CommandType.StoredProcedure);

    }
}
