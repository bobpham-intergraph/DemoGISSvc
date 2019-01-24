using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongodbConnect.FeatureRepository;
using MongodbConnect.Repository;
using System.Linq.Expressions;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using MongodbConnect.Models.Park;
using System.Linq;

namespace MongodbConnect.UnitTests
{
    [TestClass]
    public class ParkRepositoryTest: DBContextTest
    {
        private ParkRepository _parkRepository;

        public ParkRepositoryTest():base()
        {
            string collectionName = ConfigurationManager.AppSettings["ParkCollection"].ToString();
            _parkRepository = new ParkRepository(_dbcontext, collectionName);
        }
        [TestMethod]
        public void  TestFindParkByName()
        {

            string parkName = "Beach";
            int total = _parkRepository.FindParkByName(parkName).Count();

            
            int totalUpperCase = _parkRepository.FindParkByName(parkName.ToUpper()).Count();


            Assert.Equals(total, totalUpperCase);

        }


    }
}
