using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace SysRix.Controllers
{
    [Route("api/")]
    public class ServicesController : Controller
    {
        // GET api/ice
        [HttpGet("ice")]
        public IEnumerable<string> Get(string ident, string secret, string domain, string application, string room)
        {
            return new string[] { "Server1", "address" };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}