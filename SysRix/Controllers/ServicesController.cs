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
        private static readonly Random random = new Random();

        public ServicesController(IServerRepository srepo, IUserRepository urepo)
        {
            serverRepo = srepo;
            userRepo = urepo;
        }

        public static string GenerateRealm(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // GET api/ice
        [HttpGet("ice")]
        public IActionResult Get(string ident, string secret, string domain, string application, string room)
        {
            if (ident == null || secret == null || domain == null || application == null || room == null)
            {
                return NotFound("Missing params");
            }

            if (userRepo.FindMatch(ident, secret, domain) == null)
            {
                return NotFound("Invalid params");
            }

            var localIpAddress = HttpContext.Features.Get<IHttpConnectionFeature>().LocalIpAddress;

            var credential = Guid.NewGuid().ToString();
            var username = Guid.NewGuid().ToString();


            var iceServer = new IceServer[]
            {
                new IceServer
                {
                    Credential = "",
                    Url = "stun:" + localIpAddress,
                    Username = ""
                },
                new IceServer
                {
                    Credential = credential,
                    Url = "turn:" + localIpAddress + "3478?transport=udp",
                    Username = username
                }
            };

            var realm = GenerateRealm(random.Next(32, 64));

            var args = "-a -u " + username + " -r " + realm + " -p " + credential;

            Process.Start("turnadmin", args);

            return new ObjectResult(iceServer);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


    }
}