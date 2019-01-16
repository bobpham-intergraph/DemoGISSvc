using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using MongodbConnect.Repository;

namespace GisWebApiDev_20170514.Controllers
{
    public class GisController : ApiController
    {

        protected MongoDbContext _dbcontext;
        public GisController()
        {
            
        }


        public MongoDbContext DbContext
        {
            get
            {
                if (_dbcontext == null)
                {
                    string cs = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;

                    string dbName = ConfigurationManager.AppSettings["MongoDbConnectionName"].ToString();


                    _dbcontext = new MongoDbContext(cs, dbName);
                }
                return _dbcontext;
            }
        }

    }
}
