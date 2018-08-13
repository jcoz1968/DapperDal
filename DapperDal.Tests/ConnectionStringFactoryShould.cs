using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Common;

namespace DapperDal.Tests
{
    [TestClass]
    public class ConnectionStringFactoryShould
    {
        [TestMethod]
        public void ReturnValidSameStringOnCreate()
        {
            //Arrange
            var connectionString = "Server=server;Database=database;User Id=user;Password=password";
            var factory = new ConnectionStringFactory(connectionString);

            //Act
            var result = factory.Create();

            //Assert
            Assert.AreEqual(connectionString, result);
        }

        [TestMethod]
        public void ReturnInvalidIfNotValidSqlConnectionString()
        {
            //Arrange
            var connectionString = "foo";
            string provider = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
            string result = "";
            var ex = new Exception();

            //Act
            try
            {
                var dalfactory = new ConnectionStringFactory(connectionString);
                result = dalfactory.Create();
            }
            catch (System.Exception e)
            {
                ex = e;
            }

            //Assert
            Assert.AreNotEqual(new Exception(), ex);
            Assert.AreNotEqual(string.Empty, ex.Message);
            Assert.AreEqual(string.Empty, result);
        }
    }
}
