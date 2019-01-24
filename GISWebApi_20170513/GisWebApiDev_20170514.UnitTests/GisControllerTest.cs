using System;
using GisWebApiDev_20170514.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;

namespace GisWebApiDev_20170514.UnitTests
{
    [TestClass]
    public class GisControllerTest
    {
        [TestMethod]
        public void TestDBContext()
        {
            GisController c = new GisController();
            Assert.IsNotNull(c.DbContext.Database);
        }
    }
}
