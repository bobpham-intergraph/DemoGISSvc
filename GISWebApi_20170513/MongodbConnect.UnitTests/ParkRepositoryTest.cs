using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongodbConnect.FeatureRepository;
using MongodbConnect.Repository;

namespace MongodbConnect.UnitTests
{
    [TestClass]
    public class ParkRepositoryTest: DBContextTest
    {
        private ParkRepository _parkRepository;

        public ParkRepositoryTest():base()
        {
           
            _parkRepository = new ParkRepository(_dbcontext);
        }
        [TestMethod]
        public void TestParkCollection()
        {

          
        }
    }
}
