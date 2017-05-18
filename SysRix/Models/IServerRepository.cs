using System.Collections.Generic;

namespace SysRix.Models
{
	public interface IServerRepository
	{
		void Add(Server server);
		IEnumerable<Server> GetAll();
		Server Find(long id);
		void Remove(long id);
		void Update(Server server);
	}
}