using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SysRix.Controllers
{
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        // GET api/users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Server1", "address" };
        }
    }
}