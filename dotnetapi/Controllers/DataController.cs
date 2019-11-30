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
        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get2()
        {
            var client = new MongoClient("mongodb://root:example@localhost:27017");
            var dataBase = client.GetDatabase("AppDb");
            var collection = dataBase.GetCollection<Author>(typeof(Author).Name.ToLower());
            var list = collection.Find(Author => true).ToList();
            return Ok(list);
        }
    }
}