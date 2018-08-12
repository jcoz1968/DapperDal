using System;
using System.Collections.Generic;
using System.Text;

namespace DapperDal.Interfaces
{
    /// <summary>
    /// Provides methods for creating a connection string
    /// </summary>
    public interface IConnectionStringFactory
    {
        /// <summary>
        /// Create a connection string
        /// </summary>
        /// <returns></returns>
        string Create();
    }
}
