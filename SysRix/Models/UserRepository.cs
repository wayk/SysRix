using System;
using System.Linq;
using System.Collections.Generic;

namespace SysRix.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly SysRixDBContext ctx;

        public UserRepository(SysRixDBContext context)
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

        public User FindMatch(string name, string secret, string domain)
        {
            try
            {
                var user = ctx.Users.FirstOrDefault(t => t.Username == name && t.Domain == domain);

                if (user == null)
                    return null;

                return user.Secret != secret ? null : user;
            }
            catch (Exception e)
            {
                return null;
            }

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