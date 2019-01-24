using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using MongodbConnect.Repository;
using MongodbConnect.Models.Park;
using MongoDB.Bson;

namespace MongodbConnect.UnitTests
{
    [TestClass]
    public class DBContextTest
    {
        protected MongoDbContext _dbcontext;
        public DBContextTest()
        {
            if (_dbcontext == null)
            {
                string cs = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;

                string dbName = ConfigurationManager.AppSettings["MongoDbConnectionName"].ToString();


                _dbcontext = new MongoDbContext(cs, dbName);
            }

        }
        [TestMethod]
        public void TestDatabaaseParkCollection()
        {

            IMongoCollection<ParkDocument>  _parkCollection = _dbcontext.Database.GetCollection<ParkDocument>("parks_test");

            Assert.IsNotNull(_parkCollection);

            long count = _parkCollection.CountDocuments(new BsonDocument());

            Assert.AreEqual(count, 1079);
        }

       
    }
}
