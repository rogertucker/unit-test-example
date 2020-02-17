using System.Collections.Generic;
using DBLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DBLayer.Tests.Models{
    [TestClass]
    public class TestUser{

        [TestMethod]
        public void  TestFirstName(){
            var user = new User();
            user.FirstName = "first-name";
            Assert.AreEqual("first-name", user.FirstName);
        }

        [TestMethod]
        public void TestLastName(){
            var user = new User();
            user.LastName = "last-name";
            Assert.AreEqual("last-name", user.LastName);
        }

        [TestMethod]
        public void TestAddress(){
            var user = new User();
            Mock<IEnumerable<Address>> addressesMock = new Mock<IEnumerable<Address>>();
            user.Addresses = addressesMock.Object;
            Assert.AreEqual(addressesMock.Object, user.Addresses);
        }


        [TestMethod]
        public void TestPhoneNumber(){
            var user = new User();
            Mock<IEnumerable<PhoneNumber>> phoneNumberMock = new Mock<IEnumerable<PhoneNumber>>();
            user.PhoneNumbers = phoneNumberMock.Object;
            Assert.AreEqual(phoneNumberMock.Object, user.PhoneNumbers);
        }


      
    }
}