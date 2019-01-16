using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using MongodbConnect.FeatureRepository;
using MongodbConnect.Models.Placename;
using MongodbConnect.Repository;

namespace GisWebApiDev_20170514.Controllers
{
    [RoutePrefix("api/placename")]
    public class PlacenameController : GisController
    {
        private PlacenameRepository _placenameRepository;
        public PlacenameController()
        {
            _placenameRepository = new PlacenameRepository(DbContext);
        }

        [HttpGet]
        [Route("info")]
        public string Info()
        {
            return "PlacenameController";
        }

        public PlacenameRepository SARepository
        {
            get
            {
                return _placenameRepository;
            }
        }

        [Route("byname/{name}")]
        [HttpGet]
        public IEnumerable<PlacenameDocument> GetPlacenameByName(string name)
        {
            return SARepository.FindPlacenameByName(name);
        }


        [Route("byId/{id}")]
        [HttpGet]
        public IEnumerable<PlacenameDocument> GetPlacenameById(int id)
        {
            return SARepository.FindPlacenameById(id);
        }


        [Route("byname/{name}/count")]
        [HttpGet]
        public int GetPlacenameByNameCount(string name)
        {
            return SARepository.FindPlacenameByName(name).Count();
        }


        [Route("byname/{name}/{numberofrecords}")]
        [HttpGet]
        public IEnumerable<PlacenameDocument> GetPlacenameByName(string name, int numberofrecords)
        {
            return SARepository.FindPlacenameByName(name).Take(numberofrecords);
        }


        [Route("byname/{name}/{numberofrecords}/{page}")]
        [HttpGet]
        public IEnumerable<PlacenameDocument> GetPlacenameByName(string name, int numberofrecords, int page)
        {
            if (page <= 0)
                page = 1;

            int count = SARepository.FindPlacenameByName(name).Count();

            if (numberofrecords <= 0)
                numberofrecords = 10;

            int allpage = ((count - (count / page) * page) > 0) ? count / page + 1 : count / page;

            return SARepository.FindPlacenameByName(name).Skip(page - 1).Take(numberofrecords);
        }


        [Route("bynamepaging/{name}/{numberofrecords}/{index}")]
        [HttpGet]
        public PagingResult<PlacenameDocument> GetPlacenameByNamePaging(string name, int numberofrecords, int index)
        {
            if (index <= 0)
                index = 1;

            if (numberofrecords <= 0)
                numberofrecords = 10;

            return SARepository.FindPlacenameByNamePaging(name, numberofrecords, index);
        }

    }
}
