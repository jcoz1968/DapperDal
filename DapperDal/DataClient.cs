using DapperDal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DapperDal
{
    public class DataClient : IDataClient
    {
        public Task ExecuteAsync(string command, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetManyAsync<T>(string commandString, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetScalarAsync<T>(string commandString, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetSingleAsync<T>(string commandString, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }
    }
}
