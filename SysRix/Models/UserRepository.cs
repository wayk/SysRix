using System.Linq;
using System.Collections.Generic;

namespace SysRix.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext ctx;

        public UserRepository(UserContext context)
        {
            ctx = context;
        }

        public IEnumerable<User> GetAll()
        {
            return ctx.Users.ToList();
        }

        public void Add(User user)
        {
            ctx.Users.Add(user);
            ctx.SaveChanges();
        }

        public User Find(long id)
        {
            return ctx.Users.FirstOrDefault(t => t.Id == id);
        }

        public void Remove(long id)
        {
            var entity = ctx.Users.First(t => t.Id == id);
            ctx.Users.Remove(entity);
            ctx.SaveChanges();
        }

        public void Update(User user)
        {
            ctx.Users.Update(user);
            ctx.SaveChanges();
        }
    }
}