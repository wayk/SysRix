using System.Collections.Generic;
using System.Linq;

namespace SysRix.Models
{
	public class ServerRepository : IServerRepository
	{
		private readonly SysRixDBContext ctx;

		public ServerRepository(SysRixDBContext context)
		{
			ctx = context;
		}

		public IEnumerable<Server> GetAll()
		{
			return ctx.Servers.ToList();
		}

		public Server Find(long id)
		{
			return ctx.Servers.FirstOrDefault(t => t.Id == id);
		}

		public void Add(Server server)
		{
			ctx.Servers.Add(server);
			ctx.SaveChanges();
		}

		public void Remove(long id)
		{
			var entity = ctx.Servers.First(t => t.Id == id);
			ctx.Servers.Remove(entity);
			ctx.SaveChanges();
		}

		public void Update(Server server)
		{
			ctx.Servers.Update(server);
			ctx.SaveChanges();
		}
	}
}