using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongodbConnect.Repository
{
    public class PagingResult<T> where T: IMongoEntity
    {
        public int TotalCount { get; set; }
        public int NumberofRecordsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public ICollection<T> CurrentData { get; set; }
    }
}
