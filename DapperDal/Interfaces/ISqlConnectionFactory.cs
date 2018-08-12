using System.Data.Common;

namespace DapperDal.Interfaces
{
    public interface ISqlConnectionFactory
    {
        /// <summary>
        /// Creates a database connection
        /// </summary>
        /// <returns></returns>
        DbConnection Create();
    }
}
