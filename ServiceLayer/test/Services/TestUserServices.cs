using System.Collections.Generic;
using DBLayer.Models;
using DBLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceLayer.Services;

namespace ServiceLayer.Tests.Services
{
    [TestClass]
    public class TestUserServices {
        [TestMethod]
        public void TestGetById(){
            User user = new User{
                ID = 1,
                FirstName = "Test",
                LastName = "User1"
            };


            Mock<IUserRepository> repositoryMock = new Mock<IUserRepository>();
            repositoryMock.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(user);
            User result = new UserService(repositoryMock.Object).GetById(1);
            Assert.AreEqual(1, result.ID);
            Assert.AreEqual("Test", result.FirstName);
            Assert.AreEqual("User1", result.LastName);
            
            repositoryMock.Verify(mock => mock.GetById(1), Times.Once);


        }

        [TestMethod]
        public void TestGetByLastName(){
            User user = new User{
                ID = 1,
                FirstName = "Test",
                LastName = "User1"
            };

            Mock<IUserRepository> repositoryMock = new Mock<IUserRepository>();
            repositoryMock.Setup(mock => mock.GetUserByLastName(It.IsAny<string>())).Returns(user);
            User result = new UserService(repositoryMock.Object).GetUserByLastName("User1");
            Assert.AreEqual(1, result.ID);
            Assert.AreEqual("Test", result.FirstName);
            Assert.AreEqual("User1", result.LastName);
            
            repositoryMock.Verify(mock => mock.GetUserByLastName("User1"), Times.Once);


        }

        [TestMethod]
        public void TestAddUser(){
            User user = new User{
                ID = 1,
                FirstName = "Test",
                LastName = "User1"
            };

            Mock<IUserRepository> repositoryMock = new Mock<IUserRepository>();
            repositoryMock.Setup(mock => mock.Create(It.IsAny<User>()));
            new UserService(repositoryMock.Object).AddUser(user);
            
            repositoryMock.Verify(mock => mock.Create(user), Times.Once);


        }

    }
}