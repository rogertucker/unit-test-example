using DBLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBLayer.Tests.Models{
    [TestClass]
    public class TestPhoneNumber{

        [TestMethod]
        public void  TestPhoneType(){
            var phoneNumber = new PhoneNumber();
            phoneNumber.PhoneType = PhoneType.Home;
            Assert.AreEqual(PhoneType.Home, phoneNumber.PhoneType);
        }

        [TestMethod]
        public void TestNumber(){
            var phoneNumber = new PhoneNumber();
            phoneNumber.Number = "222-333-4444";
            Assert.AreEqual("222-333-4444", phoneNumber.Number);
        }
      
    }
}