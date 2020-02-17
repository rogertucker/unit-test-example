using DBLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBLayer.Tests.Models{
    [TestClass]
    public class TestAddress{

        [TestMethod]
        public void  TestsAddress1(){
            var address = new Address();
            address.Address1 = "address1";
            Assert.AreEqual("address1", address.Address1);
        }

        [TestMethod]
        public void  TestsAddress2(){
            var address = new Address();
            address.Address2 = "address2";
            Assert.AreEqual("address2", address.Address2);
        }

        [TestMethod]
        public void  TestCity(){
            var address = new Address();
            address.City = "city";
            Assert.AreEqual("city", address.City);
        }

        [TestMethod]
        public void  TestState(){
            var address = new Address();
            address.State = "state";
            Assert.AreEqual("state", address.State);
        }

        [TestMethod]
        public void  TestPostalCode(){
            var address = new Address();
            address.PostalCode = "postalcode";
            Assert.AreEqual("postalcode", address.PostalCode);
        }
    }
}