using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;
using MongoDB.Driver.Linq;
using MongodbConnect.Models.StreetAddress;
using MongodbConnect.Repository;


namespace MongodbConnect.FeatureRepository
{
    public class StreetAddressRepository: BaseMongoRepository<StreetAddressDocument>
    {
        private const string CollectionName = "street_addresses";

        private readonly MongoDbContext _dataContext;

        public StreetAddressRepository (MongoDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        protected override IMongoCollection<StreetAddressDocument> Collection =>
            _dataContext.Database.GetCollection<StreetAddressDocument>(CollectionName);


        public virtual IMongoQueryable<StreetAddressDocument> FindStreetAddressByName(string phrase)
        {
            Expression<Func<StreetAddressDocument, bool>> predicate = p => p.StreetAddress.ToLower().Contains(phrase.ToLower());

            return Collection.AsQueryable().Where(predicate);
        }

        public virtual PagingResult<StreetAddressDocument> FindStreetAddressByNamePaging(string phrase, int numberofrecords, int page)
        {
            Expression<Func<StreetAddressDocument, bool>> predicate = p => p.StreetAddress.ToLower().Contains(phrase.ToLower());

            return FindAllWithPaging(predicate, page - 1, numberofrecords);
        }


    }
}
