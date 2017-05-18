using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using SysRix.Models;


namespace SysRix.Controllers
{
    [Route("api/")]
    public class ServicesController : Controller
    {
        private readonly IServerRepository serverRepo;
        private readonly IUserRepository userRepo;

        public ServicesController(IServerRepository srepo, IUserRepository urepo)
        {
            serverRepo = srepo;
            userRepo = urepo;
        }

        // GET api/ice
        [HttpGet("ice")]
        public IActionResult Get(string ident, string secret, string domain, string application, string room)
        {
            if (ident == null || secret == null || domain == null || application == null || room == null)
            {
                return NotFound("Invalid params");
            }

            var httpConnectionFeature = HttpContext.Features.Get<IHttpConnectionFeature>();
            var localIpAddress = httpConnectionFeature?.LocalIpAddress;

            var user = userRepo.FindMatch(ident, secret, domain);

            if (user == null)
            {
                return NotFound("Invalid params");
            }

            var iceServer = new IceServer
            {
                Credential = Guid.NewGuid().ToString(),
                Username = Guid.NewGuid().ToString(),
                ServerList = new Server[]
                {
                    new Server
                    {
                        Id = 0,
                        Port = 3478,
                        TransportType = "",
                        Type = "stun",
                        Url = localIpAddress.ToString()
                    },
                    new Server
                    {
                        Id = 1,
                        Port = 3478,
                        TransportType = "udp",
                        Type = "turn",
                        Url = localIpAddress.ToString()
                    }
                }
            };


            return new ObjectResult(iceServer);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


    }
}