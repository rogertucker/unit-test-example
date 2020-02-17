using System;
using DBLayer.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBLayer.Tests.Repositories {
    [TestClass]
    public class BaseRepositoryTest{
        public static TestDb TestDb{ get; set; }
        [TestInitialize]
        public void TestInitialize()
        {
            TestDb = new TestDb();
            TestDb.SeedDb();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Console.WriteLine("CleaningDB");
            TestDb.Context.Database.EnsureDeleted();
        }
    }
}