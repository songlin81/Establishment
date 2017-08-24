using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Repository;
using System.Data.Common;
using System.Linq;

namespace Test.Repositories
{
    [TestClass]
    public class CountryRepositoryTest
    {
        DbConnection connection;
        TestContext databaseContext;
        CountryRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {
            connection = Effort.DbConnectionFactory.CreateTransient();
            databaseContext = new TestContext(connection);
            objRepo = new CountryRepository(databaseContext);

        }

        [TestMethod]
        public void Country_Repository_Get_ALL()
        {
            var result = objRepo.GetAll().ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("US", result[0].Name);
            Assert.AreEqual("India", result[1].Name);
            Assert.AreEqual("Russia", result[2].Name);
        }

        [TestMethod]
        public void Country_Repository_Create()
        {
            Country c = new Country() { Name = "UK" };

            var result = objRepo.Add(c);
            databaseContext.SaveChanges();
            var lst = objRepo.GetAll().ToList();

            Assert.AreEqual(4, lst.Count);
            Assert.AreEqual("UK", lst.Last().Name);
        }
    }
}
