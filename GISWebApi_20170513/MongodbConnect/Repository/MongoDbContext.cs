using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MongoDB.Driver;


/* Referenced Repository pattern
 *  http://www.maniuk.net/2016/08/dotnet-async-repository-using-mongodb.html 
 *  http://www.drdobbs.com/database/mongodb-with-c-deep-dive/240152181?pgno=1
 * 
 */


namespace MongodbConnect.Repository
{
    public class MongoDbContext
    {
        public IMongoDatabase Database { get; }
        public MongoDbContext(string connectionString, string connectedDB)
        {
           
            var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
           
            var client = new MongoClient(settings);
            Database = client.GetDatabase(connectedDB);
        }


       

    }
}
