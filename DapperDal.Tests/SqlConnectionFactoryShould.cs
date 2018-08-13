using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace DapperDal.Tests
{
    [TestClass]
    public class SqlConnectionFactoryShould
    {
        [TestMethod]
        public void ReturnSqlConnection()
        {
            //Arrange
            var connectionString = "Server=server;Database=database;User Id=user;Password=password";
            var connectionStringFactory = new ConnectionStringFactory(connectionString);
            var connectionFactory = new SqlConnectionFactory(connectionStringFactory);

            //Act
            var result = connectionFactory.Create();

            //Assert
            Assert.IsInstanceOfType(result, typeof(SqlConnection));
        }
    }
}
