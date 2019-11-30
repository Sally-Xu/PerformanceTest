using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using dotnetapi.Models;

namespace dotnetapi.Controllers
{
    [ApiController]
    [Route("dotnet/[controller]")]
    public class DataController : ControllerBase
    {
        private IMongoDatabase Db {get;}
        public DataController(IMongoDatabase db)
        {
           Db = db;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get()
        {
            var collection = Db.GetCollection<Author>(typeof(Author).Name.ToLower());
            var list = collection.Find(Author => true).ToList();
            return Ok(list);
        }
    }
}