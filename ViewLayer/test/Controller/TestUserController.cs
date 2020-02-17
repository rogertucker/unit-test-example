using DBLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceLayer.Services;
using ViewLayer.Controllers;

namespace ViewLayer.Test
{
    [TestClass]
    public class TestUserController{
        [TestMethod]
        public void TestCreate(){
            User user = new User{
                ID=1,
                FirstName = "First",
                LastName = "Last"
            };

            Mock<IUserService> userServiceMock = new Mock<IUserService>();
            Mock<ILogger<UserController>> loggerMock = new Mock<ILogger<UserController>>();

            userServiceMock.Setup(mock => mock.AddUser(It.IsAny<User>())).Returns(user);

            UserController controller = new UserController(userServiceMock.Object, loggerMock.Object);

            var result = controller.Create(user) as CreatedResult;
            Assert.AreEqual("api/user/1", result.Location);
            Assert.AreEqual(201, result.StatusCode);
            Assert.AreEqual("First", ((User)result.Value).FirstName);
            Assert.AreEqual("Last", ((User)result.Value).LastName);
            Assert.AreEqual(1, ((User)result.Value).ID);

            userServiceMock.Verify(mock => mock.AddUser(user), Times.Once);
        }

        [TestMethod]
         public void TestGetById(){
            User user = new User{
                ID=1,
                FirstName = "First",
                LastName = "Last"
            };

            Mock<IUserService> userServiceMock = new Mock<IUserService>();
            Mock<ILogger<UserController>> loggerMock = new Mock<ILogger<UserController>>();

            userServiceMock.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(user);

            UserController controller = new UserController(userServiceMock.Object, loggerMock.Object);

            var result = controller.GetById(1) as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual("First", ((User)result.Value).FirstName);
            Assert.AreEqual("Last", ((User)result.Value).LastName);
            Assert.AreEqual(1, ((User)result.Value).ID);

            userServiceMock.Verify(mock => mock.GetById(1), Times.Once);
        }

        [TestMethod]
         public void GetByLastName(){
            User user = new User{
                ID=1,
                FirstName = "First",
                LastName = "Last"
            };

            Mock<IUserService> userServiceMock = new Mock<IUserService>();
            Mock<ILogger<UserController>> loggerMock = new Mock<ILogger<UserController>>();

            userServiceMock.Setup(mock => mock.GetUserByLastName(It.IsAny<string>())).Returns(user);

            UserController controller = new UserController(userServiceMock.Object, loggerMock.Object);

            var result = controller.GetByLastName("Last") as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual("First", ((User)result.Value).FirstName);
            Assert.AreEqual("Last", ((User)result.Value).LastName);
            Assert.AreEqual(1, ((User)result.Value).ID);

            userServiceMock.Verify(mock => mock.GetUserByLastName("Last"), Times.Once);
        }
    }
}