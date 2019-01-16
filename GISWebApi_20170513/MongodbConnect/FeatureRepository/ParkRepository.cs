using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;
using MongoDB.Driver.Linq;
using MongodbConnect.Models.Park;
using MongodbConnect.Repository;

namespace MongodbConnect.FeatureRepository
{
    public class ParkRepository: BaseMongoRepository<ParkDocument>
    {
        private const string CollectionName = "parks";

        private readonly MongoDbContext _dataContext;

        public ParkRepository(MongoDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        protected override IMongoCollection<ParkDocument> Collection =>
            _dataContext.Database.GetCollection<ParkDocument>(CollectionName);


        public virtual IMongoQueryable<ParkDocument> FindParkByName(string phrase)
        {
            Expression<Func<ParkDocument, bool>> predicate = p => p.ParkName.ToLower().Contains(phrase.ToLower());

            return Collection.AsQueryable().Where(predicate);
        }


        public virtual PagingResult<ParkDocument> FindParkByNamePaging(string phrase, int numberofrecords, int page)
        {
            Expression<Func<ParkDocument, bool>> predicate = p => p.ParkName.ToLower().Contains(phrase.ToLower());

            return FindAllWithPaging(predicate, page - 1, numberofrecords);
        }


        public virtual IMongoQueryable<ParkDocument> FindParkById(int id)
        {
            Expression<Func<ParkDocument, bool>> predicate = p => p.ParkId == id;

            return Collection.AsQueryable().Where(predicate);
        }
    }
}
