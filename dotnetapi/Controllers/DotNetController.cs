using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DotNetController : ControllerBase
    {
        [HttpGet("{n:int?}")]
        public ActionResult<IEnumerable<string>> Get(int n = 10)
        {
            var list = new List<string>();   
            for (var i = 0; i < n; i++)
            {
                list.Add("Test" + i);
            }
            return Ok(list);
        }
    }
}
