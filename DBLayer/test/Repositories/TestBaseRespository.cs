using System.Collections.Generic;
using DBLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using DBLayer.Models;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace DBLayer.Tests.Repositories {
    [TestClass]
    public class TestBaseRepositories {
        [TestMethod]
        public void TestDeleteByInt() {
            Mock<ExampleDbContext> contextMock = new Mock<ExampleDbContext>();
            Mock<DbSet<BaseModel>> datasetMock = new Mock<DbSet<BaseModel>>();
            Mock<BaseModel> modelMock = new Mock<BaseModel>();
            Mock<BaseRepository<BaseModel>> repositoryMock = 
                new Mock<BaseRepository<BaseModel>>(contextMock.Object, datasetMock.Object);
            repositoryMock.CallBase = true;
            
            repositoryMock.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(modelMock.Object);
            contextMock.Setup(mock => mock.Remove(It.IsAny<BaseModel>()));

            repositoryMock.Object.Delete(1);
            repositoryMock.Verify(mock => mock.GetById(1), Times.Once);
            contextMock.Verify(mock => mock.Remove(modelMock.Object), Times.Once);
 
        }


        [TestMethod]
         public void TestGetAll() {
            Mock<ExampleDbContext> contextMock = new Mock<ExampleDbContext>();
            Mock<DbSet<BaseModel>> datasetMock = new Mock<DbSet<BaseModel>>();

            BaseRepository<BaseModel> repository = 
                new BaseRepository<BaseModel>(contextMock.Object, datasetMock.Object);

            IEnumerable<BaseModel> result = repository.GetAll();
            Assert.AreEqual(datasetMock.Object, result);
        }

        [TestMethod]
         public void TestCreateAsync() {
            Mock<BaseModel> modelMock = new Mock<BaseModel>();
            Mock<ExampleDbContext> contextMock = new Mock<ExampleDbContext>();
            Mock<DbSet<BaseModel>> datasetMock = new Mock<DbSet<BaseModel>>();

            BaseRepository<BaseModel> repository = 
                new BaseRepository<BaseModel>(contextMock.Object, datasetMock.Object);

            Task<int> task = Task.FromResult(1);
            contextMock.Setup(mock => mock.Add(It.IsAny<BaseModel>()));
            contextMock.Setup(mock => mock.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(task);
            
            Task<int>result = repository.CreateAsync(modelMock.Object);
            Assert.AreEqual(task.Result, result.Result);
            
            contextMock.Verify(mock => mock.Add(modelMock.Object), Times.Once);
            contextMock.Verify(mock => mock.SaveChangesAsync(new CancellationToken()), Times.Once);
        }

        [TestMethod]
         public void TestCreate() {
            Mock<BaseModel> modelMock = new Mock<BaseModel>();
            Mock<ExampleDbContext> contextMock = new Mock<ExampleDbContext>();
            Mock<DbSet<BaseModel>> datasetMock = new Mock<DbSet<BaseModel>>();

            BaseRepository<BaseModel> repository = 
                new BaseRepository<BaseModel>(contextMock.Object, datasetMock.Object);

            datasetMock.Setup(mock => mock.Add(It.IsAny<BaseModel>()));
            contextMock.Setup(mock => mock.SaveChanges()).Returns(1);
            contextMock.Setup(mock => mock.Add(It.IsAny<BaseModel>()));
            
            repository.Create(modelMock.Object);

            contextMock.Verify(mock => mock.Add(modelMock.Object), Times.Once);
            contextMock.Verify(mock => mock.SaveChanges(), Times.Once);
        }


        [TestMethod]
         public void TestUpdate() {
            Mock<BaseModel> modelMock = new Mock<BaseModel>();
            Mock<ExampleDbContext> contextMock = new Mock<ExampleDbContext>();
            Mock<DbSet<BaseModel>> datasetMock = new Mock<DbSet<BaseModel>>();

            BaseRepository<BaseModel> repository = 
                new BaseRepository<BaseModel>(contextMock.Object, datasetMock.Object);

            contextMock.Setup(mock => mock.SaveChanges()).Callback(() => modelMock.Object.ID = 2);
            
            Assert.AreEqual(2, repository.Update(modelMock.Object));
            
            contextMock.Verify(mock => mock.SaveChanges(), Times.Once);
        }
    }

}