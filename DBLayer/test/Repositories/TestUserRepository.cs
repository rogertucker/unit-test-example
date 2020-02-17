using System.Collections.Generic;
using System.Linq;
using DBLayer.Models;
using DBLayer.Repositories;
using DBLayer.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBLayer.Tests.Repositories {
    [TestClass]
    public class TestAssumptionRepository: BaseRepositoryTest {
        

        [TestMethod]
        public void TestGetUserByLastName(){
            User result = null;
            UserRepository repository = new UserRepository(TestDb.Context);
                result = repository.GetUserByLastName("User1");
    
            Assert.IsNotNull(result);
            Assert.AreEqual("Test", result.FirstName);
            Assert.AreEqual("User1", result.LastName);
            Assert.IsNotNull(result.Addresses.SingleOrDefault(x => x.Address1 == "User1Address11"));
            Assert.IsNotNull(result.Addresses.SingleOrDefault(x => x.Address1 == "User1Address12"));
            Assert.IsNotNull(result.PhoneNumbers.SingleOrDefault(x => x.Number == "TestUser1MobilePhone"));
            Assert.IsNotNull(result.PhoneNumbers.SingleOrDefault(x => x.Number == "TestUser1HomePhone"));
        }
    }
}