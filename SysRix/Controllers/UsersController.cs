using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using SysRix.Models;

namespace SysRix.Controllers
{
	[Route("api/[controller]")]
	public class UsersController : Controller
	{
		private readonly IUserRepository userRepo;

		public UsersController(IUserRepository repo)
		{
			userRepo = repo;
		}

		[HttpGet]
		public IEnumerable<User> GetAll()
		{
			return userRepo.GetAll();
		}

		[HttpGet("{id}", Name = "GetUserById")]
		public IActionResult Get(int id)
		{
			var user = userRepo.Find(id);
			if (user == null)
				return NotFound();

			return new ObjectResult(user);
		}

		[HttpPost]
		public IActionResult Create([FromBody] User user)
		{
			Console.WriteLine(user);
			if (user == null)
				return BadRequest();

			user.Domain = "example.com";
			user.Usage = 0;

			userRepo.Add(user);

			return CreatedAtRoute("GetUserById", new {id = user.Id}, user);
		}
	}
}